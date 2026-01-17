using System;
using System.Collections.Generic;
using System.Linq;

namespace NHSE.Core;

/// <summary>
/// Represents all saved data that is stored on the device for the New Horizon's game.
/// </summary>
/// <remarks>
/// Creates a HorizonSave from a file provider.
/// </remarks>
/// <param name="provider">Provider for reading/writing save files.</param>
public class HorizonSave(ISaveFileProvider provider)
{
    public readonly MainSave Main = new(provider);
    public readonly Player[] Players = Player.ReadMany(provider);
    private readonly ISaveFileProvider Provider = provider;

    public override string ToString() => $"{Players[0].Personal.TownName} - {Players[0]}";

    /// <summary>
    /// Creates a HorizonSave from an unpacked file path.
    /// </summary>
    /// <param name="folder">Path to the folder containing save files.</param>
    /// <returns>HorizonSave loaded from the folder.</returns>
    public static HorizonSave FromFolder(string folder)
    {
        var provider = new FolderSaveFileProvider(folder);
        return new HorizonSave(provider);
    }

    /// <summary>
    /// Creates a HorizonSave from a ZIP file path.
    /// </summary>
    /// <param name="zipPath">Path to the ZIP archive containing save files.</param>
    /// <returns>HorizonSave loaded from the ZIP archive.</returns>
    public static HorizonSave FromZip(string zipPath)
    {
        var provider = new ZipSaveFileProvider(zipPath);
        return new HorizonSave(provider);
    }

    /// <summary>
    /// Saves the data using the provided crypto <see cref="seed"/>.
    /// </summary>
    /// <param name="seed">Seed to initialize the RNG with when encrypting the files.</param>
    public void Save(uint seed)
    {
        Main.Hash();
        Main.Save(seed);
        foreach (var player in Players)
        {
            foreach (var pair in player)
            {
                pair.Hash();
                pair.Save(seed);
            }
        }
        Provider.Flush();
    }

    /// <summary>
    /// Gets every <see cref="FileHashRegion"/> that is deemed invalid.
    /// </summary>
    /// <remarks>
    /// Doesn't return any metadata about which file the hashes were bad for.
    /// Just check what's returned with what's implemented; the offsets are unique enough.
    /// </remarks>
    public IEnumerable<FileHashRegion> GetInvalidHashes()
    {
        foreach (var hash in Main.InvalidHashes())
            yield return hash;
        foreach (var hash in Players.SelectMany(z => z).SelectMany(z => z.InvalidHashes()))
            yield return hash;
    }

    public void ChangeIdentity(ReadOnlySpan<byte> original, ReadOnlySpan<byte> updated)
    {
        original = original.ToArray(); // defensive allocation to ensure the sequence stays the same during replacement
        Main.Data.ReplaceOccurrences(original, updated);
        foreach (var pair in Players.SelectMany(z => z))
            pair.Data.ReplaceOccurrences(original, updated);
    }

    public bool ValidateSizes()
    {
        var info = Main.Info.GetKnownRevisionIndex();
        if (info < 0)
            return false;
        var sizes = RevisionChecker.SizeInfo[info];
        if (Main.Data.Length != sizes.Main)
            return false;

        // Each player present in the savedata must have been migrated to this revision.
        foreach (var p in Players)
        {
            if (p.Personal.Data.Length != sizes.Personal)
                return false;
            if (p.Photo.Data.Length != sizes.PhotoStudioIsland)
                return false;
            if (p.PostBox.Data.Length != sizes.PostBox)
                return false;
            if (p.Profile.Data.Length != sizes.Profile)
                return false;
            if (p.WhereAreN is { } x && x.Data.Length != sizes.WhereAreN)
                return false;
        }
        return true;
    }

    public string GetSaveTitle(string prefix)
    {
        var townName = Players[0].Personal.TownName;
        var timestamp = Main.LastSaved.TimeStamp;

        return $"{prefix} - {townName} @ {timestamp}";
    }

    public string GetBackupFolderTitle()
    {
        var townName = Players[0].Personal.TownName;
        var timestamp = Main.LastSaved.TimeStamp.Replace(':', '.');
        return StringUtil.CleanFileName($"{townName} - {timestamp}");
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NHSE.Core;

/// <summary>
/// Stores references for all files in the Villager (<see cref="DirectoryName"/>) folder.
/// </summary>
public sealed class Player : IEnumerable<EncryptedFilePair>
{
    public readonly Personal Personal;
    public readonly PhotoStudioIsland Photo;
    public readonly PostBox PostBox;
    public readonly Profile Profile;
    public readonly WhereAreN? WhereAreN;

    /// <summary>
    /// Directory Name where the player data was loaded from. Not the full path.
    /// </summary>
    public readonly string DirectoryName;

    #region Override Implementations
    public IEnumerator<EncryptedFilePair> GetEnumerator()
    {
        IEnumerable<EncryptedFilePair> baseFiles = [Personal, Photo, PostBox, Profile];
        if (WhereAreN is not null)
            baseFiles = baseFiles.Concat([WhereAreN]);
        return baseFiles.AsEnumerable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public override string ToString() => Personal.PlayerName;
    #endregion

    /// <summary>
    /// Imports Player data from the requested provider.
    /// </summary>
    /// <param name="provider">Provider that contains the Player Villager sub-folders.</param>
    /// <returns>Player object array loaded from the provider.</returns>
    public static Player[] ReadMany(ISaveFileProvider provider)
    {
        var dirs = provider.GetDirectories("Villager*");
        var result = new Player[dirs.Length];
        for (int i = 0; i < result.Length; i++)
        {
            var subProvider = provider.GetSubdirectoryProvider(dirs[i]);
            result[i] = new Player(subProvider, dirs[i]);
        }
        return result;
    }

    private Player(ISaveFileProvider provider, string directoryName)
    {
        DirectoryName = directoryName;

        Personal = new Personal(provider);
        Photo = new PhotoStudioIsland(provider);
        PostBox = new PostBox(provider);
        Profile = new Profile(provider);

        if (EncryptedFilePair.Exists(provider, WhereAreN.FileName))
            WhereAreN = new WhereAreN(provider);
    }
}
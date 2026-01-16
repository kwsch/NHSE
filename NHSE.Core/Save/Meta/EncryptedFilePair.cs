using System;
using System.Collections.Generic;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// Represents two files -- <see cref="NameData"/> and <see cref="NameHeader"/> and their decrypted data.
/// </summary>
public abstract class EncryptedFilePair
{
    private readonly byte[] RawData;
    private readonly byte[] RawHeader;
    private readonly ISaveFileProvider Provider;

    protected Memory<byte> Raw => RawData;
    public Span<byte> Data => RawData;
    public Span<byte> Header => RawHeader;

    public readonly FileHeaderInfo Info;

    public readonly string NameData;
    public readonly string NameHeader;

    /// <summary>
    /// Checks if the file pair exists in the specified provider.
    /// </summary>
    public static bool Exists(ISaveFileProvider provider, string name)
    {
        var nameData = $"{name}.dat";
        var nameHeader = $"{name}Header.dat";
        return provider.FileExists(nameHeader) && provider.FileExists(nameData);
    }

    protected EncryptedFilePair(ISaveFileProvider provider, string name)
    {
        Provider = provider;
        NameData = $"{name}.dat";
        NameHeader = $"{name}Header.dat";

        var hd = provider.ReadFile(NameHeader);
        var md = provider.ReadFile(NameData);

        Encryption.Decrypt(hd, md);

        RawHeader = hd;
        RawData = md;

        Info = RawHeader[..FileHeaderInfo.SIZE].ToClass<FileHeaderInfo>();
    }

    public void Save(uint seed)
    {
        var encrypt = Encryption.Encrypt(RawData, seed, RawHeader);
        Provider.WriteFile(NameData, encrypt.Data.Span);
        Provider.WriteFile(NameHeader, encrypt.Header.Span);
    }


    /// <summary>
    /// Updates all hashes of <see cref="Data"/>.
    /// </summary>
    public void Hash()
    {
        var ver = Info.GetKnownRevisionIndex();
        var hash = RevisionChecker.HashInfo[ver];
        var details = hash.GetFile(NameData);
        ArgumentNullException.ThrowIfNull(details, nameof(NameData));
        foreach (var h in details.HashRegions)
            WriteUInt32LittleEndian(Data[h.HashOffset..], Murmur3.Hash(Data[h.HashedRange]));
    }

    public IEnumerable<FileHashRegion> InvalidHashes()
    {
        var ver = Info.GetKnownRevisionIndex();
        var hash = RevisionChecker.HashInfo[ver];
        var details = hash.GetFile(NameData);
        ArgumentNullException.ThrowIfNull(details, nameof(NameData));
        foreach (var h in details.HashRegions)
        {
            var current = Murmur3.Hash(Data[h.HashedRange]);
            var saved = ReadUInt32LittleEndian(Data[h.HashOffset..]);
            if (current != saved)
                yield return h;
        }
    }

    protected string GetString(int offset, int maxLength) => StringUtil.GetString(Data, offset, maxLength);
    protected static byte[] GetBytes(string value, int maxLength) => StringUtil.GetBytes(value, maxLength);
}
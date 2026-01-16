using System;
using System.Collections.Generic;
using System.IO;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// Represents two files -- <see cref="DataPath"/> and <see cref="HeaderPath"/> and their decrypted data.
/// </summary>
public abstract class EncryptedFilePair
{
    private readonly byte[] RawData;
    private readonly byte[] RawHeader;

    protected Memory<byte> Raw => RawData;
    public Span<byte> Data => RawData;
    public Span<byte> Header => RawHeader;

    public readonly FileHeaderInfo Info;

    public readonly string DataPath;
    public readonly string HeaderPath;
    public readonly string NameData;
    public readonly string NameHeader;

    public static bool Exists(string folder, string name)
    {
        var NameData = $"{name}.dat";
        var NameHeader = $"{name}Header.dat";
        var hdr = Path.Combine(folder, NameHeader);
        var dat = Path.Combine(folder, NameData);
        return File.Exists(hdr) && File.Exists(dat);
    }

    protected EncryptedFilePair(string folder, string name)
    {
        NameData = $"{name}.dat";
        NameHeader = $"{name}Header.dat";
        var hdr = Path.Combine(folder, NameHeader);
        var dat = Path.Combine(folder, NameData);

        var hd = File.ReadAllBytes(hdr);
        var md = File.ReadAllBytes(dat);

        Encryption.Decrypt(hd, md);

        RawHeader = hd;
        RawData = md;
        DataPath = dat;
        HeaderPath = hdr;

        Info = RawHeader[..FileHeaderInfo.SIZE].ToClass<FileHeaderInfo>();
    }

    public void Save(uint seed)
    {
        var encrypt = Encryption.Encrypt(RawData, seed, RawHeader);
        File.WriteAllBytes(DataPath, encrypt.Data.Span);
        File.WriteAllBytes(HeaderPath, encrypt.Header.Span);
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
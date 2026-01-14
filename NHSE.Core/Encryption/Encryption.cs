using System;
using System.Runtime.InteropServices;

namespace NHSE.Core;

public static class Encryption
{
    private const int BlockSize = 16;

    private static void GetParam(ReadOnlySpan<uint> data, int index, Span<byte> result)
    {
        var rand = new XorShift128(data[(int)data[index] & 0x7F]);
        var prms = data[(int)(data[index + 1] & 0x7F)] & 0x7F;

        var rndRollCount = (prms & 0xF) + 1;
        for (var i = 0; i < rndRollCount; i++)
            rand.Next64();

        for (var i = 0; i < result.Length; i++)
            result[i] = (byte)(rand.Next() >> 24);
    }

    /// <summary>
    /// Decrypts the <see cref="encData"/> using the <see cref="headerData"/> in place.
    /// </summary>
    /// <param name="headerData">Header Data (at least 0x300 bytes)</param>
    /// <param name="encData">Encrypted SaveData (modified in place)</param>
    public static void Decrypt(Span<byte> headerData, Span<byte> encData)
    {
        // First 256 bytes go unused; important data starts at offset 0x100
        var sourceSpan = headerData.Slice(0x100, 0x200);
        ReadOnlySpan<uint> importantData = MemoryMarshal.Cast<byte, uint>(sourceSpan);

        // Set up Key and Counter
        Span<byte> key = stackalloc byte[BlockSize];
        Span<byte> counter = stackalloc byte[BlockSize];
        GetParam(importantData, 0, key);
        GetParam(importantData, 2, counter);

        // Decrypt in place using AES-CTR
        AesCtr.Crypt(encData, key, counter);
    }

    private static CryptoFile GenerateHeaderFile(uint seed, ReadOnlySpan<byte> versionData)
    {
        // Generate 128 Random uints which will be used for params
        var random = new XorShift128(seed);
        Span<uint> encryptData = stackalloc uint[128];
        for (var i = 0; i < encryptData.Length; i++)
            encryptData[i] = random.Next();

        var headerData = new byte[0x300];
        var key = new byte[BlockSize];
        var ctr = new byte[BlockSize];

        versionData[..0x100].CopyTo(headerData);
        MemoryMarshal.AsBytes(encryptData).CopyTo(headerData.AsSpan(0x100));

        GetParam(encryptData, 0, key);
        GetParam(encryptData, 2, ctr);

        return new CryptoFile(headerData, key, ctr);
    }

    /// <summary>
    /// Encrypts the <see cref="data"/> (savedata) using the provided <see cref="seed"/>.
    /// </summary>
    /// <param name="data">SaveData to encrypt</param>
    /// <param name="seed">Seed to encrypt with</param>
    /// <param name="versionData">Version data to encrypt with</param>
    /// <returns>Encrypted SaveData, and associated headerData</returns>
    public static EncryptedSaveFile Encrypt(ReadOnlySpan<byte> data, uint seed, ReadOnlySpan<byte> versionData)
    {
        // Generate header file and get key and counter
        var header = GenerateHeaderFile(seed, versionData);

        // Encrypt using AES-CTR
        var encData = AesCtr.Encrypt(data, header.Key.Span, header.Ctr.Span);

        return new EncryptedSaveFile(encData, header.Data);
    }
}
using System;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// MurmurHash implementation used by Animal Crossing New Horizons
/// </summary>
public static class Murmur3
{
    private static uint Murmur32_Scramble(uint k)
    {
        k = (k * 0x16A88000) | ((k * 0xCC9E2D51) >> 17);
        k *= 0x1B873593;
        return k;
    }

    /// <summary>
    /// Updates the hash at the specified offset, using the input parameters.
    /// </summary>
    /// <param name="data">Data to hash</param>
    /// <param name="seed">Initial Murmur seed (optional)</param>
    /// <returns>Calculated hash.</returns>
    public static uint GetMurmur3Hash(ReadOnlySpan<byte> data, uint seed = 0)
    {
        var checksum = seed;
        var remaining = data;
        while (remaining.Length >= sizeof(uint))
        {
            var val = ReadUInt32LittleEndian(remaining);
            checksum ^= Murmur32_Scramble(val);
            checksum = (checksum >> 19) | (checksum << 13);
            checksum = (checksum * 5) + 0xE6546B64;
            remaining = remaining[sizeof(uint)..];
        }

        if (!remaining.IsEmpty)
        {
            uint val = 0;
            switch (remaining.Length)
            {
                case 3:
                    val |= (uint)remaining[2] << 16;
                    goto case 2;
                case 2:
                    val |= (uint)remaining[1] << 8;
                    goto case 1;
                case 1:
                    val |= remaining[0];
                    break;
            }

            checksum ^= Murmur32_Scramble(val);
        }

        checksum ^= (uint)data.Length;
        checksum ^= checksum >> 16;
        checksum *= 0x85EBCA6B;
        checksum ^= checksum >> 13;
        checksum *= 0xC2B2AE35;
        checksum ^= checksum >> 16;
        return checksum;
    }

    /// <summary>
    /// Updates the hash at the specified offset, using the input parameters.
    /// </summary>
    /// <param name="data">Data to hash</param>
    /// <param name="hashDestination">Location two write the hash</param>
    /// <returns>Calculated hash that was written back to the data.</returns>
    public static uint UpdateMurmur32(ReadOnlySpan<byte> data, Span<byte> hashDestination)
    {
        var newHash = GetMurmur3Hash(data);
        WriteUInt32LittleEndian(hashDestination, newHash);
        return newHash;
    }
}
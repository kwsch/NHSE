using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// MurmurHash implementation used by Animal Crossing New Horizons
/// </summary>
/// <remarks>
/// Never is any remainder in inputs, so we don't need to handle that case.
/// </remarks>
public static class Murmur3
{
    private static uint Scramble(uint value)
    {
        value = (value * 0x16A88000) | ((value * 0xCC9E2D51) >> 17);
        value *= 0x1B873593;
        return value;
    }

    private static uint Advance(uint checksum, uint value)
    {
        checksum ^= Scramble(value);
        checksum = (checksum >> 19) | (checksum << 13);
        checksum = (checksum * 5) + 0xE6546B64;
        return checksum;
    }

    private static uint Finalize(uint checksum, uint length)
    {
        checksum ^= length;
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
    /// <param name="seed">Initial Murmur seed (optional)</param>
    /// <returns>Calculated hash.</returns>
    public static uint Hash(ReadOnlySpan<byte> data, uint seed = 0)
    {
        Debug.Assert(data.Length % 4 == 0); // no irregular sizes (no remainder if processing as u32*)
        var checksum = seed;
        var u32 = MemoryMarshal.Cast<byte, uint>(data);
        foreach (var x in u32)
        {
            var value = x;
            if (!BitConverter.IsLittleEndian)
                value = ReverseEndianness(value);
            checksum = Advance(checksum, value);
        }

        return Finalize(checksum, (uint)data.Length);
    }

    /// <summary>
    /// Attempts to determine the length of data that produces the expected hash.
    /// </summary>
    /// <param name="data">Data to hash</param>
    /// <param name="expect">Expected checksum</param>
    /// <param name="seed">Initial Murmur seed (optional)</param>
    /// <returns>Length of data (in bytes) that produces the expected hash, or -1 if not found.</returns>
    public static int GetLength(ReadOnlySpan<byte> data, uint expect, uint seed = 0)
    {
        var checksum = seed;
        var u32 = MemoryMarshal.Cast<byte, uint>(data);
        for (int i = 0; i < u32.Length; i++)
        {
            var value = u32[i];
            if (!BitConverter.IsLittleEndian)
                value = ReverseEndianness(value);

            checksum = Advance(checksum, value);
            var length = ((i + 1) * sizeof(uint));
            var actual = Finalize(checksum, (uint)length);
            if (actual == expect)
                return length;
        }
        return -1; // not found
    }
}
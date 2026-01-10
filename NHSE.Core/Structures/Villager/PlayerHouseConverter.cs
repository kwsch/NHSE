using System;

namespace NHSE.Core;

/// <summary>
/// Converts Player House objects to different revisions.
/// </summary>
public static class PlayerHouseConverter
{
    /// <summary>
    /// Checks to see if the <see cref="size"/> matches any of the House object sizes.
    /// </summary>
    /// <param name="size">Size of the byte array that might represent a House object.</param>
    /// <returns>True if it matches any size.</returns>
    public static bool IsHouse(int size)
    {
        return size == PlayerHouse1.SIZE || size == PlayerHouse2.SIZE;
    }

    /// <summary>
    /// Checks to see if the input <see cref="size"/> can be converted to the <see cref="expect"/> size.
    /// </summary>
    /// <param name="size">Current house file size</param>
    /// <param name="expect">Expected house file size</param>
    /// <returns>True if can be converted, false if no conversion available.</returns>
    public static bool IsCompatible(int size, int expect)
    {
        return expect switch
        {
            // Can convert to any format
            PlayerHouse1.SIZE or PlayerHouse2.SIZE => IsHouse(size),
            // No conversion available
            _ => false,
        };
    }

    /// <summary>
    /// Converts the House data format to another format.
    /// </summary>
    /// <remarks>
    /// Before calling this method, check that a conversion method exists via <see cref="IsCompatible"/> and that the length of the <see cref="data"/> is not the same as what you <see cref="expect"/>.
    /// If the sizes are the same, it will return the input <see cref="data"/>.
    /// If no conversion path exists, it will return the input <see cref="data"/>.
    /// </remarks>
    /// <param name="data">Current format</param>
    /// <param name="expect">Target size</param>
    /// <returns>Converted data</returns>
    public static byte[] GetCompatible(byte[] data, int expect)
    {
        if (data.Length == expect)
            return data;

        return expect switch
        {
            PlayerHouse1.SIZE when data.Length == PlayerHouse2.SIZE => Convert21(data),
            PlayerHouse2.SIZE when data.Length == PlayerHouse1.SIZE => Convert12(data),
            _ => data,
        };
    }

    /// <summary>
    /// Converts a <see cref="PlayerHouse1"/> object byte array to a <see cref="PlayerHouse2"/>
    /// </summary>
    /// <param name="h1"><see cref="PlayerHouse1"/> object byte array</param>
    /// <returns><see cref="PlayerHouse2"/> object byte array</returns>
    private static byte[] Convert12(Memory<byte> h1) => new PlayerHouse1(h1).Upgrade().Data.ToArray();

    /// <summary>
    /// Converts a <see cref="PlayerHouse2"/> object byte array to a <see cref="PlayerHouse1"/>
    /// </summary>
    /// <param name="h2"><see cref="PlayerHouse2"/> object byte array</param>
    /// <returns><see cref="PlayerHouse1"/> object byte array</returns>
    private static byte[] Convert21(Memory<byte> h2) => new PlayerHouse2(h2).Downgrade().Data.ToArray();
}
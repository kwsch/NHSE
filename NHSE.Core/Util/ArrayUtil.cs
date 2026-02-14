using System;

namespace NHSE.Core;

/// <summary>
/// Array reusable logic
/// </summary>
public static class ArrayUtil
{
    public static int ReplaceOccurrences(this Span<byte> array, ReadOnlySpan<byte> pattern, ReadOnlySpan<byte> swap)
    {
        if (pattern.Length != swap.Length)
            return -1;
        if (pattern.SequenceEqual(swap))
            return 0;

        int count = 0;
        int ofs = 0;
        while (true)
        {
            var index = array[ofs..].IndexOf(pattern);
            if (index == -1)
                return count;
            ofs += index;

            swap.CopyTo(array[ofs..]);
            ofs += swap.Length; // skip past swapped data
            ++count;
        }
    }

    /// <summary>
    /// Pads the specified byte array on the left side with the given padding bytes until it reaches the desired total length.
    /// </summary>
    /// <param name="original">The original byte array to pad.</param>
    /// <param name="totalLength">The desired total length of the resulting array.</param>
    /// <param name="paddingBytes">The byte pattern to use for padding. If multiple bytes are provided, they will repeat as needed.</param>
    /// <returns>
    /// A new byte array of <paramref name="totalLength"/> with padding on the left and the original content on the right.
    /// If <paramref name="original"/> is already equal to or longer than <paramref name="totalLength"/>, returns the original array unchanged.
    /// </returns>
    public static byte[] PadLeft(byte[] original, int totalLength, byte[] paddingBytes)
    {
        int bytesNeeded = totalLength - original.Length;
        if (bytesNeeded <= 0) return original;

        byte[] paddedArray = new byte[totalLength];
        int padBytesCount = paddingBytes.Length;

        // Fill the left with padding bytes
        for (int i = 0; i < bytesNeeded; i += padBytesCount)
        {
            for (int j = 0; j < padBytesCount && i + j < bytesNeeded; j++)
                paddedArray[i + j] = paddingBytes[j];
        }

        // Copy the original array to the right of the padding
        Buffer.BlockCopy(original, 0, paddedArray, bytesNeeded, original.Length);
        return paddedArray;
    }
    /// <summary>
    /// Pads the specified byte array on the right side with the given padding bytes until it reaches the desired total length.
    /// </summary>
    /// <param name="original">The original byte array to pad.</param>
    /// <param name="totalLength">The desired total length of the resulting array.</param>
    /// <param name="paddingBytes">The byte pattern to use for padding. If multiple bytes are provided, they will repeat as needed.</param>
    /// <returns>
    /// A new byte array of <paramref name="totalLength"/> with the original content on the left and padding on the right.
    /// If <paramref name="original"/> is already equal to or longer than <paramref name="totalLength"/>, returns the original array unchanged.
    /// </returns>
    public static byte[] PadRight(byte[] original, int totalLength, byte[] paddingBytes)
    {
        int bytesNeeded = totalLength - original.Length;
        if (bytesNeeded <= 0) return original;

        byte[] paddedArray = new byte[totalLength];
        // Copy the original array to the left
        Buffer.BlockCopy(original, 0, paddedArray, 0, original.Length);

        int padBytesCount = paddingBytes.Length;

        // Fill the right with padding bytes
        for (int i = 0; i < bytesNeeded; i += padBytesCount)
        {
            for (int j = 0; j < padBytesCount && original.Length + i + j < totalLength; j++)
                paddedArray[original.Length + i + j] = paddingBytes[j];
        }

        return paddedArray;
    }
}
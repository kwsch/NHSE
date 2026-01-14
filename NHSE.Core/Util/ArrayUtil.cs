using System;

namespace NHSE.Core;

/// <summary>
/// Array reusable logic
/// </summary>
public static class ArrayUtil
{
  //public static int ReplaceOccurrences(this Span<byte> array, ReadOnlySpan<byte> pattern, ReadOnlySpan<byte> swap)
  //{
  //    int count = 0;
  //    int ofs = 0;
  //    while (true)
  //    {
  //        var index = array[ofs..].IndexOf(pattern);
  //        if (index == -1)
  //            return count;
  //        ofs += index;
  //
  //        swap.CopyTo(array[ofs..]);
  //        ofs += swap.Length; // skip past swapped data
  //        ++count;
  //    }
  //}

    public static int ReplaceOccurrences(this Span<byte> array, ReadOnlySpan<byte> pattern, ReadOnlySpan<byte> swap)
    {
        int count = 0;
        while (true)
        {
            int ofs = IndexOfBytes(array, pattern);
            if (ofs == -1)
                return count;
            swap.CopyTo(array[ofs..]);
            ++count;
        }
    }

    /// <summary>
    /// Finds a provided <see cref="pattern"/> within the supplied <see cref="array"/>.
    /// </summary>
    /// <param name="array">Array to look in</param>
    /// <param name="pattern">Pattern to look for</param>
    /// <param name="startIndex">Starting offset to look from</param>
    /// <param name="length">Amount of entries to look through</param>
    /// <returns>Index the pattern occurs at; if not found, returns -1.</returns>
    public static int IndexOfBytes(ReadOnlySpan<byte> array, ReadOnlySpan<byte> pattern, int startIndex = 0, int length = -1)
    {
        int len = pattern.Length;
        int endIndex = length > 0
            ? startIndex + length
            : array.Length - len - startIndex;

        endIndex = Math.Min(array.Length - pattern.Length, endIndex);

        int i = startIndex;
        int j = 0;
        while (true)
        {
            if (pattern[j] != array[i + j])
            {
                if (++i == endIndex)
                    return -1;
                j = 0;
            }
            else if (++j == len)
            {
                return i;
            }
        }
    }
}
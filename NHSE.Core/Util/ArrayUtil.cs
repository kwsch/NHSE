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
}
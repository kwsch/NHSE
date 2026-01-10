using System;

namespace NHSE.Core;

/// <summary>
/// Array reusable logic
/// </summary>
public static class ArrayUtil
{
    public static int ReplaceOccurrences(this Span<byte> array, ReadOnlySpan<byte> pattern, ReadOnlySpan<byte> swap)
    {
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
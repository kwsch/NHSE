using System;

namespace NHSE.Core;

/// <summary>
/// Array reusable logic
/// </summary>
public static class ArrayUtil
{
    public static byte[] Slice(this byte[] src, int offset, int length)
    {
        byte[] data = new byte[length];
        Buffer.BlockCopy(src, offset, data, 0, data.Length);
        return data;
    }

    public static int ReplaceOccurrences(this Span<byte> array, ReadOnlySpan<byte> pattern, ReadOnlySpan<byte> swap)
    {
        int count = 0;
        while (true)
        {
            int ofs = array.IndexOf(pattern);
            if (ofs == -1)
                return count;
            swap.CopyTo(array[ofs..]);
            ++count;
        }
    }
}
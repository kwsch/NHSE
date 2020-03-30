namespace NHSE.Core
{
    /// <summary>
    /// Utility logic for dealing with bitflags in a byte array.
    /// </summary>
    public static class FlagUtil
    {
        public static bool GetFlag(byte[] arr, int offset, int bitIndex)
        {
            var b = arr[offset + (bitIndex >> 3)];
            var mask = 1 << (bitIndex & 7);
            return (b & mask) != 0;
        }

        public static void SetFlag(byte[] arr, int offset, int bitIndex, bool value)
        {
            offset += (bitIndex >> 3);
            bitIndex &= 7; // ensure bit access is 0-7
            arr[offset] &= (byte)~(1 << bitIndex);
            arr[offset] |= (byte)((value ? 1 : 0) << bitIndex);
        }
    }
}
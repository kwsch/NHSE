using System.Runtime.InteropServices;

#pragma warning disable CS8618, CA1815, CA1819, IDE1006
namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GSavePlayerManpu
    {
        public const int SIZE = 0x88;
        private const int MaxCount = 64;
        private const int WheelCount = 8;

        /// <summary>
        /// List of known Reaction IDs
        /// </summary>
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxCount)]
        public Reaction[] ManpuBit { get; set; }

        /// <summary>
        /// Emotions that are currently bound to the Reaction Wheel.
        /// </summary>
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = WheelCount)]
        public Reaction[] UIList { get; set; }

        /// <summary>
        /// Flags indicating if an Reaction (at the same index?) is newly learned or not.
        /// </summary>
        [field: MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = MaxCount)]
        public bool[] NewFlag { get; set; }
    }
}

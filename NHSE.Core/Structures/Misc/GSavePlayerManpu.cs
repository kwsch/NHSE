using System;
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

        public void AddMissingReactions()
        {
            var all = (Reaction[])Enum.GetValues(typeof(Reaction));
            foreach (var react in all)
                AddReaction(react);
        }

        // returns true if failed
        public bool AddReaction(Reaction react)
        {
            if (react.ToString().StartsWith("UNUSED"))
                return true;

            var index = Array.IndexOf(ManpuBit, react);
            if (index >= 0)
                return false;

            var empty = EmptyIndex;
            if (empty < 0)
                return true;
            ManpuBit[empty] = react;
            return false;
        }

        private int EmptyIndex => Array.FindIndex(ManpuBit, z => z == 0);
    }
}

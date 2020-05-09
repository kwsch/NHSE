using System.Runtime.InteropServices;

#pragma warning disable CS8618, CA1815, CA1819, IDE1006
namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class GSaveFg
    {
        public const int SIZE = 0x928;
        private const int _7b9816fbCount = 0x900;
        private const int _e88f809dCount = 8;

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = _7b9816fbCount)]
        public byte[] _7b9816fb { get; set; }                                 // @0x0 size 0x900, align 1
        public ushort SpecialityFruit { get; set; }                           // @0x900 size 0x2, align 2
        public ushort SisterFruit { get; set; }                               // @0x902 size 0x2, align 2

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = _e88f809dCount)]
        public uint[] _e88f809d { get; set; }                                // @0x904 size 0x4, align 4
        public byte VillageFlower { get; set; }                              // @0x924 size 0x1, align 1
        public byte SpecialityFlower { get; set; }                           // @0x925 size 0x1, align 1
    }
}

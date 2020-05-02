using System.ComponentModel;
using System.Runtime.InteropServices;

#pragma warning disable CS8618, CA1815, CA1819, IDE1006
namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = SIZE)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct GSaveRoomFloorWall
    {
        public const int SIZE = 0x24;

        public GSaveItemName AccentWallItem { get; set; }             // @0x0 size 0x8, align 4
        public GSaveItemName WallItem { get; set; }                   // @0x8 size 0x8, align 4
        public GSaveItemName FloorItem { get; set; }                  // @0x10 size 0x8, align 4
        public ushort AccentWallMyDesignID { get; set; }              // @0x18 size 0x2, align 2
        public ushort WallMyDesignID { get; set; }                    // @0x1a size 0x2, align 2
        public ushort FloorMyDesignID { get; set; }                   // @0x1c size 0x2, align 2
        public byte AccentWallDirection { get; set; }                 // @0x1e size 0x1, align 1
        public byte InfoBit { get; set; }                             // @0x1f size 0x1, align 1
        public byte FloorDirection { get; set; }                      // @0x20 size 0x1, align 1
    }
}

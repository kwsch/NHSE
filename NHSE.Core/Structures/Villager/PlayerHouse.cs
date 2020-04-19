using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 4)]
    public class PlayerHouse : IHouseInfo
    {
        public const int SIZE = 0x26400;

        [field: FieldOffset(0x000)] public uint HouseLevel { get; set; }
        [field: FieldOffset(0x004)] public ushort WallUniqueID { get; set; }
        [field: FieldOffset(0x006)] public ushort RoofUniqueID { get; set; }
        [field: FieldOffset(0x008)] public ushort DoorUniqueID { get; set; }
        [field: FieldOffset(0x00A)] public ushort OrderWallUniqueID { get; set; }
        [field: FieldOffset(0x00C)] public ushort OrderRoofUniqueID { get; set; }
        [field: FieldOffset(0x00E)] public ushort OrderDoorUniqueID { get; set; }

        [field: FieldOffset(0x263D4)] public GSaveItemName DoorDecoItemName { get; set; }

        [field: FieldOffset(0x263E0)] public GSaveItemName PostItemName { get; set; }
        [field: FieldOffset(0x263E8)] public GSaveItemName OrderPostItemName { get; set; }
    }
}

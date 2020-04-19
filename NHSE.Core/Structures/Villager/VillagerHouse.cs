using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 4)]
    public class VillagerHouse
    {
        public const int SIZE = 0x1D4;
        public const int ItemCount = 36;

        [field: FieldOffset(0x000)] public uint HouseLevel { get; set; }
        [field: FieldOffset(0x004)] public uint HouseStatus { get; set; }
        [field: FieldOffset(0x008)] public ushort WallUniqueID { get; set; }
        [field: FieldOffset(0x00A)] public ushort RoofUniqueID { get; set; }
        [field: FieldOffset(0x00C)] public ushort DoorUniqueID { get; set; }
        [field: FieldOffset(0x00E)] public ushort OrderWallUniqueID { get; set; }
        [field: FieldOffset(0x010)] public ushort OrderRoofUniqueID { get; set; }
        [field: FieldOffset(0x012)] public ushort OrderDoorUniqueID { get; set; }

        [field: FieldOffset(0x1C4)] public sbyte NPC1 { get; set; }
        [field: FieldOffset(0x1C5)] public sbyte NPC2 { get; set; }

        [field: FieldOffset(0x1C8)] public GSaveItemName DoorDecoItemName { get; set; }
        [field: FieldOffset(0x1D0)] public sbyte BuildPlayer { get; set; }
    }

    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 1)]
    public struct GSaveItemName
    {
        public const int SIZE = 0x08;
        [field: FieldOffset(0x00)] public ushort UniqueID { get; set; }
        [field: FieldOffset(0x02)] public byte SystemParam { get; set; }
        [field: FieldOffset(0x03)] public byte AdditionalParam { get; set; }
        [field: FieldOffset(0x04)] public uint FreeParam { get; set; }

        // ReSharper disable once NonReadonlyMemberInGetHashCode
        public override int GetHashCode() => UniqueID;
        public override bool Equals(object obj) => obj is GSaveItemName i && i.Equals(this);
        public bool Equals(GSaveItemName obj) => obj.UniqueID == UniqueID && obj.SystemParam == SystemParam && obj.AdditionalParam == AdditionalParam;
        public static bool operator ==(GSaveItemName left, GSaveItemName right) => left.Equals(right);
        public static bool operator !=(GSaveItemName left, GSaveItemName right) => !(left == right);
    }
}

using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 1)]
    public struct VillagerHouseItem // GFtrData
    {
        public const int SIZE = 0xC;

        [field: FieldOffset(0x0)] public ushort ItemId { get; set; }
        [field: FieldOffset(0x2)] public byte Flags0 { get; set; }
        [field: FieldOffset(0x3)] public byte Flags1 { get; set; }
        [field: FieldOffset(0x4)] public ushort Count { get; set; }
        [field: FieldOffset(0x6)] public ushort UseCount { get; set; }

        [field: FieldOffset(0x8)] public byte UnitX { get; set; }
        [field: FieldOffset(0x9)] public byte UnitY { get; set; }
        [field: FieldOffset(0xA)] public byte Direction { get; set; }
        [field: FieldOffset(0xB)] public byte Layer { get; set; }

        // ReSharper disable once NonReadonlyMemberInGetHashCode
        public override int GetHashCode() => ItemId;
        public override bool Equals(object obj) => obj is VillagerHouseItem i && i.Equals(this);
        public bool Equals(VillagerHouseItem obj) => obj.ItemId == ItemId && obj.Flags0 == Flags0 && obj.Flags1 == Flags1;
        public static bool operator ==(VillagerHouseItem left, VillagerHouseItem right) => left.Equals(right);
        public static bool operator !=(VillagerHouseItem left, VillagerHouseItem right) => !(left == right);
    }
}

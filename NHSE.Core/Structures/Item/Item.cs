using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 1)]
    public class Item : IHeldItem
    {
        public static readonly Item NO_ITEM = new Item {ItemId = NONE};
        public const ushort NONE = 0xFFFE;
        public const int SIZE = 8;

        private static readonly ushort[] resolvedItemIdArray =
        {
            0x1E13, 0x1E14, 0x1E15, 0x1E16, 0x1E17, 0x1E18, 0x1E19, 0x1E1A,
            0x1E1B, 0x1E1C, 0x1E1D, 0x1E1E, 0x1E1F, 0x1E20, 0x1E21, 0x1E22
        };

        [field: FieldOffset(0)] public ushort ItemId { get; set; }
        [field: FieldOffset(2)] public byte Flags0 { get; set; }
        [field: FieldOffset(3)] public byte Flags1 { get; set; }
        [field: FieldOffset(4)] public ushort Count { get; set; }
        [field: FieldOffset(6)] public ushort UseCount { get; set; }

        public ItemType Type => (ItemType) (Flags1 & 3);
        public int ReservedIndex => (Flags1 >> 2) & 0xF;

        public Item() { } // marshalling

        public Item(ushort itemId = NONE, byte flags0 = 0, byte flags1 = 0, byte count = 0, ushort useCount = 0)
        {
            ItemId = itemId;
            Flags0 = flags0;
            Flags1 = flags1;
            Count = count;
            UseCount = useCount;
        }

        public void Delete()
        {
            ItemId = NONE;
            Flags0 = Flags1 = 0;
            Count = UseCount = 0;
        }

        public void CopyFrom(Item item)
        {
            ItemId = item.ItemId;
            Flags0 = item.Flags0;
            Flags1 = item.Flags1;
            Count = item.Count;
            UseCount = item.UseCount;
        }

        public static Item[] GetArray(byte[] data) => data.GetArray<Item>(SIZE);
        public static byte[] SetArray(IReadOnlyList<Item> data) => data.SetArray(SIZE);

        public ushort GetInventoryNameFromFlags()
        {
            if (ItemId == 0x16A1 || ItemId == 0x3100)
                return ItemId;

            return Type switch
            {
                ItemType.Reserved => resolvedItemIdArray[ReservedIndex],
                ItemType.Present => 0x1180,
                ItemType.Delivery => 0x1225,
                _ => ItemId,
            };
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public sealed class VillagerItem : Item
    {
        public new const int SIZE = 0x2C;
        public uint U08, U0C, U10, U14, U18, U1C, U20, U24, U28;
        public new static VillagerItem[] GetArray(byte[] data) => data.GetArray<VillagerItem>(SIZE);
        public static byte[] SetArray(IReadOnlyList<VillagerItem> data) => data.SetArray(SIZE);
    }
}

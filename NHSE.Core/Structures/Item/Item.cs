using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class Item
    {
        public static readonly Item NO_ITEM = new Item {ItemId = NONE};
        public const ushort NONE = 0xFFFE;
        public const int SIZE = 8;

        private static readonly ushort[] resolvedItemIdArray =
        {
            0x1E13, 0x1E14, 0x1E15, 0x1E16, 0x1E17, 0x1E18, 0x1E19, 0x1E1A,
            0x1E1B, 0x1E1C, 0x1E1D, 0x1E1E, 0x1E1F, 0x1E20, 0x1E21, 0x1E22
        };

        public ushort ItemId;
        public byte Flags0;
        public byte Flags1;
        public byte Count;
        public byte Flags2;
        public ushort UseCount;

        public ItemType Type => (ItemType) (Flags1 & 3);
        public int ReservedIndex => (Flags1 >> 2) & 0xF;

        public Item() { } // marshalling

        public Item(ushort itemId = NONE, byte flags0 = 0, byte flags1 = 0, byte count = 0, byte flags2 = 0, ushort useCount = 0)
        {
            ItemId = itemId;
            Flags0 = flags0;
            Flags1 = flags1;
            Flags2 = flags2;
            Count = count;
            UseCount = useCount;
        }

        public void Delete()
        {
            ItemId = NONE;
            Flags0 = Flags1 = Flags2 = Count = 0;
            UseCount = 0;
        }

        public void CopyFrom(Item item)
        {
            ItemId = item.ItemId;
            Flags0 = item.Flags0;
            Flags1 = item.Flags1;
            Flags2 = item.Flags2;
            Count = item.Count;
            UseCount = item.UseCount;
        }

        public static Item[] GetArray(byte[] data)
        {
            var result = new Item[data.Length / SIZE];
            for (int i = 0; i < result.Length; i++)
                result[i] = data.Slice(i * SIZE, SIZE).ToClass<Item>();
            return result;
        }

        public static byte[] SetArray(IReadOnlyList<Item> data)
        {
            var result = new byte[data.Count * SIZE];
            for (int i = 0; i < data.Count; i++)
                data[i].ToBytesClass().CopyTo(result, i * SIZE);
            return result;
        }

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
}

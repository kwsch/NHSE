using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 1)]
    public class FieldItem
    {
        public const ushort EXTENSION = 0xFFFD;
        public const ushort NONE = 0xFFFE;
        public const int SIZE = 8;

        public bool IsNone => ItemType == NONE;
        public bool IsExtension => ItemType == EXTENSION;
        public bool IsRoot => ItemType < EXTENSION;

        // Item Definition
        [FieldOffset(0)] public ushort ItemId;
        [FieldOffset(2)] public byte Flags0;
        [FieldOffset(3)] public byte Flags1;
        [FieldOffset(4)] public ushort Count;
        [FieldOffset(6)] public ushort UseCount;

        // Field Item Definition
        [FieldOffset(0)] public ushort ItemType;
        [FieldOffset(2)] public byte Rotation;
        [FieldOffset(3)] public byte E03;
        [FieldOffset(4)] public ushort ExtensionItemId;
        [FieldOffset(6)] public byte ExtensionX;
        [FieldOffset(7)] public byte ExtensionY;

        public ushort DisplayItemId => IsExtension ? ExtensionItemId : ItemId;

        public FieldItem() { } // marshalling

        public void CopyFrom(FieldItem item)
        {
            ItemType = item.ItemType;
            Rotation = item.Rotation;
            E03 = item.E03;
            ExtensionItemId = item.ExtensionItemId;
            ExtensionX = item.ExtensionX;
            ExtensionY = item.ExtensionY;
        }

        public FieldItem(ushort itemId = NONE, byte flags0 = 0, byte flags1 = 0, byte count = 0, ushort useCount = 0)
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

        public static FieldItem[] GetArray(byte[] data) => data.GetArray<FieldItem>(SIZE);
        public static byte[] SetArray(IReadOnlyList<FieldItem> data) => data.SetArray(SIZE);
    }
}

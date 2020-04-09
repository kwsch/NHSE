using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 1)]
    public class FieldItem : IHeldItem
    {
        public const ushort EXTENSION = 0xFFFD;
        public const ushort NONE = 0xFFFE;
        public const int SIZE = 8;

        private const string HeldItem = nameof(HeldItem);
        private const string ExtensionItem = nameof(ExtensionItem);
        private const string Derived = nameof(Derived);

        [Category(Derived)] public bool IsNone => ItemType == NONE;
        [Category(Derived)] public bool IsExtension => ItemType == EXTENSION;
        [Category(Derived)] public bool IsRoot => ItemType < EXTENSION;
        [Category(Derived)] public ushort DisplayItemId => IsExtension ? ExtensionItemId : ItemId;

        // Item Definition
        [field: FieldOffset(0)][Category(HeldItem)] public ushort ItemId { get; set; }
        [field: FieldOffset(2)][Category(HeldItem)] public byte Flags0 { get; set; }
        [field: FieldOffset(3)][Category(HeldItem)] public byte Flags1 { get; set; }
        [field: FieldOffset(4)][Category(HeldItem)] public ushort Count { get; set; }
        [field: FieldOffset(6)][Category(HeldItem)] public ushort UseCount { get; set; }

        // Field Item Definition
        [field: FieldOffset(0)][Category(ExtensionItem)] public ushort ItemType { get; set; }
        [field: FieldOffset(2)][Category(ExtensionItem)] public byte Rotation { get; set; }
        [field: FieldOffset(3)][Category(ExtensionItem)] public byte E03 { get; set; }
        [field: FieldOffset(4)][Category(ExtensionItem)] public ushort ExtensionItemId { get; set; }
        [field: FieldOffset(6)][Category(ExtensionItem)] public byte ExtensionX { get; set; }
        [field: FieldOffset(7)][Category(ExtensionItem)] public byte ExtensionY { get; set; }

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

        public void CopyFrom(IHeldItem item)
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

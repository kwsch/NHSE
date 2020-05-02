namespace NHSE.Core
{
    public static class ItemInfo
    {
        private static readonly byte[] ItemKinds = ResourceUtil.GetBinaryResource("item_kind.bin");
        private static readonly byte[] ItemSizes = ResourceUtil.GetBinaryResource("item_size.bin");

        public static ItemKind GetItemKind(IHeldItem item) => GetItemKind(item.ItemId);
        public static ItemKind GetItemKind(FieldItem item) => GetItemKind(item.DisplayItemId);

        public static ItemKind GetItemKind(ushort id)
        {
            if (id > ItemKinds.Length)
                return ItemKind.Unknown;
            return (ItemKind) ItemKinds[id];
        }

        public static ItemSizeType GetItemSize(IHeldItem item) => GetItemSize(item.ItemId);
        public static ItemSizeType GetItemSize(FieldItem item) => GetItemSize(item.DisplayItemId);

        public static ItemSizeType GetItemSize(ushort id)
        {
            if (id > ItemSizes.Length)
                return ItemSizeType.Unknown;
            return (ItemSizeType)ItemSizes[id];
        }
    }
}

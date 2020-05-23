namespace NHSE.Core
{
    /// <summary>
    /// Fetching metadata about an <see cref="Item"/>
    /// </summary>
    public static class ItemInfo
    {
        // derived from bcsv; only some data is needed for our logic
        private static readonly byte[] ItemKinds = ResourceUtil.GetBinaryResource("item_kind.bin");
        private static readonly byte[] ItemSizes = ResourceUtil.GetBinaryResource("item_size.bin");

        public static ItemKind GetItemKind(Item item) => GetItemKind(item.DisplayItemId);

        public static ItemKind GetItemKind(ushort id)
        {
            if (id > ItemKinds.Length)
                return FieldItemList.GetFieldItemKind(id);
            return (ItemKind) ItemKinds[id];
        }

        public static ItemSizeType GetItemSize(Item item)
        {
            if (item.IsBuried || item.IsDropped)
                return ItemSizeType.S_1_0x1_0;

            return GetItemSize(item.DisplayItemId);
        }

        public static ItemSizeType GetItemSize(ushort id)
        {
            if (id > ItemSizes.Length)
                return ItemSizeType.Unknown;
            return (ItemSizeType)ItemSizes[id];
        }
    }
}

namespace NHSE.Core
{
    public static class ItemInfo
    {
        private static readonly byte[] ItemKinds = ResourceUtil.GetBinaryResource("item_kind.bin");

        public static ItemKind GetItemKind(IHeldItem item) => GetItemKind(item.ItemId);
        public static ItemKind GetItemKind(FieldItem item) => GetItemKind(item.DisplayItemId);

        public static ItemKind GetItemKind(ushort id)
        {
            if (id > ItemKinds.Length)
                return ItemKind.Unknown;
            return (ItemKind) ItemKinds[id];
        }
    }
}
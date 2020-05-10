using System.Drawing;

namespace NHSE.Core
{
    public static class ItemColor
    {
        public static Color GetItemColor(Item item)
        {
            if (item.ItemId == Item.NONE)
                return Color.Transparent;
            var kind = ItemInfo.GetItemKind(item);
            if (kind == ItemKind.Unknown)
                return Color.LimeGreen;
            return ColorUtil.Colors[(int)kind];
        }

        public static Color GetItemColor(ushort item)
        {
            if (item == Item.NONE)
                return Color.Transparent;
            var kind = ItemInfo.GetItemKind(item);
            if (kind == ItemKind.Unknown)
                return Color.LimeGreen;
            return ColorUtil.Colors[(int)kind];
        }
    }
}

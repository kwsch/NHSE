using System;
using System.Drawing;
using System.Linq;
using NHSE.Core;

namespace NHSE.Sprites
{
    public static class ItemColor
    {
        private static readonly Color[] Colors = ((KnownColor[])Enum.GetValues(typeof(KnownColor)))
            .Select(Color.FromKnownColor).Select(z => ColorUtil.Blend(Color.White, z, 0.5d)).ToArray();

        public static Color GetItemColor(Item item)
        {
            if (item.ItemId == Item.NONE)
                return Color.Transparent;
            var kind = ItemInfo.GetItemKind(item);
            if (kind == ItemKind.Unknown)
                return Color.LimeGreen;
            return Colors[(int)kind];
        }
    }
}

using System;
using System.Drawing;
using System.Linq;
using NHSE.Core;

namespace NHSE.Sprites
{
    public static class FieldItemColor
    {
        public static Color GetItemColor(FieldItem item)
        {
            var kind = ItemInfo.GetItemKind(item);
            if (kind == ItemKind.Unknown)
                return item.DisplayItemId == FieldItem.NONE ? Color.Transparent : Color.DarkGreen;
            return Colors[(int)kind];
        }

        private static readonly Color[] Colors = ((KnownColor[])Enum.GetValues(typeof(KnownColor)))
            .Select(Color.FromKnownColor).Select(z => ColorUtil.Blend(Color.White, z, 0.5d)).ToArray();
    }
}

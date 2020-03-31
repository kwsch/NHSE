using System;
using System.Drawing;
using NHSE.Core;
using NHSE.Sprites.Properties;

namespace NHSE.Sprites
{
    public class ItemSpriteDrawer : IGridItem
    {
        public int Width { get; set; } = 32;
        public int Height { get; set; } = 32;

        public Image HoverBackground = Resources.itemHover;

        public Image? GetImage(Item item, Font font)
        {
            if (item.ItemId == Item.NONE)
                return null;

            return CreateFake(item, font);
        }

        public Image CreateFake(Item item, Font font)
        {
            var color = GetItemColor(item);
            var bmp = new Bitmap(Width, Height);
            using Graphics gfx = Graphics.FromImage(bmp);
            using SolidBrush brush = new SolidBrush(color);
            gfx.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);

            if (item.Count != 0)
                gfx.DrawString(item.Count.ToString(), font, Brushes.Black, 0, 0);
            if (item.UseCount != 0)
                gfx.DrawString(item.UseCount.ToString(), font, Brushes.Black, 10, 10);
            if (item.Flags0 != 0)
                gfx.DrawString(item.Flags0.ToString(), font, Brushes.Black, 20, 0);
            if (item.Flags1 != 0)
                gfx.DrawString(item.Flags1.ToString(), font, Brushes.Black, 0, 20);
            if (item.Flags2 != 0)
                gfx.DrawString(item.Flags2.ToString(), font, Brushes.Black, 20, 20);
            return bmp;
        }

        private static Color GetItemColor(Item item)
        {
            var kind = ItemInfo.GetItemKind(item);
            if (kind == ItemKind.Unknown)
                return Color.LimeGreen;
            var known = Colors[(int)kind];
            var color = Color.FromKnownColor(known);
            // soften the colors a little
            return Blend(Color.White, color, 0.5d);
        }

        public static Color Blend(Color color, Color backColor, double amount)
        {
            byte r = (byte)((color.R * amount) + (backColor.R * (1 - amount)));
            byte g = (byte)((color.G * amount) + (backColor.G * (1 - amount)));
            byte b = (byte)((color.B * amount) + (backColor.B * (1 - amount)));
            return Color.FromArgb(r, g, b);
        }

        private static readonly KnownColor[] Colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
    }
}

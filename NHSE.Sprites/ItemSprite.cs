using System;
using System.Drawing;
using NHSE.Core;
using NHSE.Sprites.Properties;

namespace NHSE.Sprites
{
    public class ItemSpriteDrawer : IGridItem
    {
        public int Width { get; } = 32;
        public int Height { get; } = 32;

        public readonly Image HoverBackground = Resources.itemHover;

        public Image? GetImage(Item item, Font font)
        {
            if (item.ItemId == Item.NONE)
                return null;

            return CreateFake(item, font);
        }

        public Bitmap CreateFake(Item item, Font font, bool slash = false)
        {
            var bmp = new Bitmap(Width, Height);

            const int x1 = 0;
            const int y1 = 0;
            int x2 = Width - 1;
            int y2 = Height - 1;
            using var gfx = Graphics.FromImage(bmp);
            DrawItemAt(gfx, item, font, x1, y1, x2, y2, slash);

            return bmp;
        }

        public static void DrawItemAt(Graphics gfx, Item item, Font font, int x1, int y1, int x2, int y2, bool slash = false)
        {
            var color = GetItemColor(item);
            using var brush = new SolidBrush(color);
            DrawItem(gfx, x1, y1, x2, y2, brush);

            if (slash)
            {
                var icolor = Color.FromArgb(color.R ^ 0xFF, color.G ^ 0xFF, color.B ^ 0xFF);
                using var ipen = new Pen(icolor);
                DrawForwardSlash(gfx, x1, y1, x2, y2, ipen);
                DrawBackwardSlash(gfx, x1, y1, x2, y2, ipen);
            }

            DrawInfo(gfx, font, item, x1, y1, Brushes.Black);
        }

        private static void DrawItem(Graphics gfx, int x1, int y1, int x2, int y2, Brush brush) => gfx.FillRectangle(brush, x1, y1, x2 + 1, y2 + 1);
        private static void DrawForwardSlash(Graphics gfx, int x1, int y1, int x2, int y2, Pen ipen) => gfx.DrawLine(ipen, x2, y1, x1, y2);
        private static void DrawBackwardSlash(Graphics gfx, int x1, int y1, int x2, int y2, Pen ipen) => gfx.DrawLine(ipen, x1, y1, x2, y2);

        private static void DrawInfo(Graphics gfx, Font font, Item item, int x1, int y1, Brush brush)
        {
            if (item.Count != 0)
                gfx.DrawString(item.Count.ToString(), font, brush, x1, y1);
            if (item.UseCount != 0)
                gfx.DrawString(item.UseCount.ToString(), font, brush, x1 + 10, y1 + 10);
            if (item.Flags0 != 0)
                gfx.DrawString(item.Flags0.ToString(), font, brush, x1 + 20, y1 + 0);
            if (item.Flags1 != 0)
                gfx.DrawString(item.Flags1.ToString(), font, brush, x1 + 0, y1 + 20);
        }

        private static Color GetItemColor(Item item)
        {
            var kind = ItemInfo.GetItemKind(item);
            if (kind == ItemKind.Unknown)
                return Color.LimeGreen;
            var known = Colors[(int)kind];
            var color = Color.FromKnownColor(known);
            // soften the colors a little
            return ColorUtil.Blend(Color.White, color, 0.5d);
        }

        private static readonly KnownColor[] Colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));

        public Bitmap GetItemArray(Item[] items, int height, Font f)
        {
            //var items = MapItem.GetArray(SAV.Main.Data.Slice(0x20191C, 0xA8000));
            var width = items.Length / height;

            var png = new Bitmap(width * Width, height * Height);
            var gfx = Graphics.FromImage(png);
            for (int i = 0; i < items.Length; i++)
            {
                var x = Height * (i / height);
                var y = Width * (i % height);
                DrawItemAt(gfx, items[i], f, x, y, x + Width - 1, y + Height - 1);
            }

            return png;
        }
    }
}

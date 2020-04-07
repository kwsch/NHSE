using System;
using System.Drawing;
using System.Linq;
using NHSE.Core;

namespace NHSE.Sprites
{
    public static class FieldItemSprite
    {
        public static Bitmap GetImage(FieldItem item, int width, int height)
        {
            if (item.ItemId == Item.NONE)
                return GetNone(width, height);

            return CreateFake(item, width, height);
        }

        private static Bitmap GetNone(int w, int h) => new Bitmap(w, h);

        public static Bitmap CreateFake(FieldItem item, int width, int height, bool slash = false)
        {
            var bmp = new Bitmap(width, height);

            const int x1 = 0;
            const int y1 = 0;
            int x2 = width - 1;
            int y2 = height - 1;
            using var gfx = Graphics.FromImage(bmp);
            DrawItemAt(gfx, item, x1, y1, x2, y2, slash);

            return bmp;
        }

        public static void DrawItemAt(Graphics gfx, FieldItem item, int x1, int y1, int x2, int y2, bool slash = false)
        {
            var color = GetItemColor(item);
            using var brush = new SolidBrush(color);
            DrawItem(gfx, x1, y1, x2, y2, brush);

            if (slash)
                DrawX(gfx, x1, y1, x2, y2, color);
        }

        private static void DrawX(Graphics gfx, int x1, int y1, int x2, int y2, Color color)
        {
            var icolor = Color.FromArgb(color.R ^ 0xFF, color.G ^ 0xFF, color.B ^ 0xFF);
            using var ipen = new Pen(icolor);
            DrawForwardSlash(gfx, x1, y1, x2, y2, ipen);
            DrawBackwardSlash(gfx, x1, y1, x2, y2, ipen);
        }

        private static void DrawItem(Graphics gfx, int x1, int y1, int x2, int y2, Brush brush) => gfx.FillRectangle(brush, x1, y1, x2 + 1, y2 + 1);
        private static void DrawForwardSlash(Graphics gfx, int x1, int y1, int x2, int y2, Pen ipen) => gfx.DrawLine(ipen, x2, y1, x1, y2);
        private static void DrawBackwardSlash(Graphics gfx, int x1, int y1, int x2, int y2, Pen ipen) => gfx.DrawLine(ipen, x1, y1, x2, y2);

        public static Color GetItemColor(FieldItem item)
        {
            var kind = ItemInfo.GetItemKind(item);
            if (kind == ItemKind.Unknown)
                return item.DisplayItemId == FieldItem.NONE ? Color.LimeGreen : Color.DarkGreen;
            return Colors[(int)kind];
        }

        private static readonly Color[] Colors = ((KnownColor[])Enum.GetValues(typeof(KnownColor)))
            .Select(Color.FromKnownColor).Select(z => ColorUtil.Blend(Color.White, z, 0.5d)).ToArray();
    }
}

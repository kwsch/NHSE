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
            var scramble = item.ItemId * 17;
            var b = scramble & 0xFF;
            var g = (scramble >> 8) & 0xFF;
            var color = Color.FromArgb(b, g, b);

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
    }
}

using System.Drawing;
using NHSE.Core;
using NHSE.Sprites.Properties;

namespace NHSE.Sprites
{
    public class ItemSpriteDrawer : IGridItem
    {
        public int Width { get; set; } = 32;
        public int Height { get; set; } = 32;

        public readonly Image HoverBackground = Resources.itemHover;

        public Bitmap GetImage(Item item, Font font) => ItemSprite.GetImage(item, font, Width, Height);
        public Bitmap GetImage(Item item) => ItemSprite.GetImage(item, Width, Height);

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
                ItemSprite.DrawItemAt(gfx, items[i], f, x, y, x + Width - 1, y + Height - 1);
            }

            return png;
        }
    }
}

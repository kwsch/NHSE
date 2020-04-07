using System.Collections.Generic;
using System.Drawing;
using NHSE.Core;

namespace NHSE.Sprites
{
    public class FieldItemSpriteDrawer
    {
        public int Width { get; set; } = 8;
        public int Height { get; set; } = 8;

        public Bitmap GetItemArray(IReadOnlyList<FieldItem> items, int height)
        {
            //var items = FieldItem.GetArray(SAV.Main.Data.Slice(0x20191C, 0xA8000));
            var width = items.Count / height;

            var png = new Bitmap(width * Width, height * Height);
            var gfx = Graphics.FromImage(png);
            for (int i = 0; i < items.Count; i++)
            {
                var x = Height * (i / height);
                var y = Width * (i % height);
                FieldItemSprite.DrawItemAt(gfx, items[i], x, y, x + Width - 1, y + Height - 1);
            }

            return png;
        }
    }
}

using System.Drawing;
using NHSE.Core;

namespace NHSE.Sprites
{
    public class FieldItemSpriteDrawer
    {
        public int Width { get; set; } = 8;
        public int Height { get; set; } = 8;

        public Bitmap GetImage(FieldItem item) => FieldItemSprite.GetImage(item, Width, Height);

        public Bitmap GetBitmapLayer(FieldItemLayer layer)
        {
            var items = layer.Tiles;
            var height = layer.MapHeight;
            var width = items.Length / height;

            const int w = 1;
            const int h = 1;
            var png = new Bitmap(width * w, height * h);
            for (int i = 0; i < items.Length; i++)
            {
                var x = h * (i / height);
                var y = w * (i % height);
                var color = FieldItemSprite.GetItemColor(items[i]);
                png.SetPixel(x, y, color);
            }

            return png;
        }

        public Bitmap GetBitmapLayer(FieldItemLayer layer, int x, int y)
        {
            var map = GetBitmapLayer(layer);
            using var gfx = Graphics.FromImage(map);
            using var pen = new Pen(Color.Red);

            const int scale = 1;
            int w = layer.GridWidth * scale;
            int h = layer.GridHeight * scale;
            gfx.DrawRectangle(pen, x * scale, y * scale, w, h);
            return map;
        }
    }
}

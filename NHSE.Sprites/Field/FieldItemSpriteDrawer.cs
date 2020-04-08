using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
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

            var bmpData = new int[width * height];
            for (int x = 0; x < width; x++)
            {
                var ix = x * height;
                for (int y = 0; y < height; y++)
                {
                    var index = ix + y;
                    var tile = items[index];
                    bmpData[(y * width) + x] = FieldItemSprite.GetItemColor(tile).ToArgb();
                }
            }

            var result = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var bData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(bmpData, 0, bData.Scan0, bmpData.Length);
            result.UnlockBits(bData);
            return result;
        }

        public Bitmap GetBitmapLayerAcre(FieldItemLayer layer, int x0, int y0)
        {
            var items = layer.Tiles;
            var height = layer.MapHeight;
            var width = items.Length / height;

            var bmpData = new int[width * height];
            var stride = layer.GridWidth;

            for (int x = 0; x < stride; x++)
            {
                for (int y = 0; y < stride; y++)
                {
                    var tile = layer.GetTile(x + x0, y + y0);
                    var color = FieldItemSprite.GetItemColor(tile).ToArgb();
                    var i = (y * width) + x;
                    bmpData[i] = color;
                }
            }

            var result = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var bData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(bmpData, 0, bData.Scan0, bmpData.Length);
            result.UnlockBits(bData);
            return result;
        }

        public Bitmap GetBitmapLayerAcre(FieldItemLayer layer, int x0, int y0, int scale)
        {
            var map = GetBitmapLayerAcre(layer, x0, y0);
            map = ImageUtil.ResizeImage(map, map.Width * scale, map.Height * scale);

            // Obtain raw data
            var bData = map.LockBits(new Rectangle(0, 0, map.Width, map.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            var ptr = bData.Scan0;
            var data = new int[map.Width * map.Height];
            Marshal.Copy(ptr, data, 0, data.Length);

            // draw symbols over special items now?

            // Slap on a grid
            var w = map.Width;
            var h = map.Height;
            const int grid = -0x1000000; // 0xFF000000u
            for (int x = scale; x < w; x += scale)
            {
                for (int y = scale; y < h; y += scale)
                {
                    var index = (y * w) + x;
                    data[index] = grid;
                }
            }

            // Return final data
            Marshal.Copy(data, 0, ptr, data.Length);
            map.UnlockBits(bData);
            return map;
        }

        public Bitmap GetBitmapLayer(FieldItemLayer layer, int x, int y, int scale = 1)
        {
            var map = GetBitmapLayer(layer);
            if (scale > 1)
                map = ImageUtil.ResizeImage(map, map.Width, map.Height);

            return DrawViewReticle(map, layer, x, y, scale);
        }

        private static Bitmap DrawViewReticle(Bitmap map, MapGrid g, int x, int y, int scale)
        {
            using var gfx = Graphics.FromImage(map);
            using var pen = new Pen(Color.Red);

            int w = g.GridWidth * scale;
            int h = g.GridHeight * scale;
            gfx.DrawRectangle(pen, x * scale, y * scale, w, h);
            return map;
        }
    }
}

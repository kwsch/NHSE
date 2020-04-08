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

        private static int[] GetBitmapLayerAcre(FieldItemLayer layer, int x0, int y0, out int width, out int height)
        {
            height = layer.GridWidth;
            width = layer.GridWidth;

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

            return bmpData;
        }

        public Bitmap GetBitmapLayerAcre(FieldItemLayer layer, int x0, int y0, int scale)
        {
            var map = GetBitmapLayerAcre(layer, x0, y0, out int mh, out int mw);
            var data = ImageUtil.ScalePixelImage(map, scale, mw, mh, out var fw, out var fh);

            // draw symbols over special items now?

            // Slap on a grid
            var w = fw;
            var h = fh;
            const int grid = -0x777778; // 0xFF888888u

            // Horizontal Lines
            for (int x = 0; x < w; x++)
            {
                for (int y = scale; y < h; y += scale)
                {
                    var index = (y * w) + x;
                    data[index] = grid;
                }
            }

            // Vertical Lines
            for (int y = 0; y < h; y++)
            {
                for (int x = scale; x < w; x += scale)
                {
                    var index = (y * w) + x;
                    data[index] = grid;
                }
            }

            // Return final data
            return ImageUtil.GetBitmap(data, fw, fh);
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

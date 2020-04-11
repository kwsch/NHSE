using System.Drawing;
using NHSE.Core;

namespace NHSE.Sprites
{
    public static class FieldItemSpriteDrawer
    {
        public static Bitmap GetBitmapLayer(FieldItemLayer layer)
        {
            var items = layer.Tiles;
            var height = layer.MapHeight;
            var width = items.Length / height;

            var bmpData = new int[width * height];
            LoadBitmapLayer(items, bmpData, width, height);

            return ImageUtil.GetBitmap(bmpData, width, height);
        }

        private static void LoadBitmapLayer(FieldItem[] items, int[] bmpData, int width, int height)
        {
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
        }

        private static int[] GetBitmapLayerAcre(FieldItemLayer layer, int x0, int y0, out int width, out int height)
        {
            height = layer.GridWidth;
            width = layer.GridWidth;

            var bmpData = new int[width * height];
            LoadPixelsFromLayer(layer, x0, y0, width, bmpData);

            return bmpData;
        }

        private static void LoadPixelsFromLayer(FieldItemLayer layer, int x0, int y0, int width, int[] bmpData)
        {
            var stride = layer.GridWidth;

            for (int y = 0; y < stride; y++)
            {
                var baseIndex = (y * width);
                for (int x = 0; x < stride; x++)
                {
                    var tile = layer.GetTile(x + x0, y + y0);
                    var color = FieldItemSprite.GetItemColor(tile).ToArgb();
                    var index = baseIndex + x;
                    bmpData[index] = color;
                }
            }
        }

        // non-allocation image generator
        public static Bitmap GetBitmapLayerAcre(FieldItemLayer layer, int x0, int y0, int scale, int[] acre1, int[] acreScale, Bitmap dest)
        {
            var w = layer.GridWidth;
            var h = layer.GridHeight;
            LoadPixelsFromLayer(layer, x0, y0, w, acre1);
            w *= scale;
            h *= scale;
            ImageUtil.ScalePixelImage(acre1, acreScale, w, h, scale);

            // draw symbols over special items now?
            DrawDirectionals(acreScale, layer, w, x0, y0, scale);

            // Slap on a grid
            DrawGrid(acreScale, w, h, scale);

            // Return final data
            ImageUtil.SetBitmapData(dest, acreScale);
            return dest;
        }

        // unused -- allocates!
        public static Bitmap GetBitmapLayerAcre(FieldItemLayer layer, int x0, int y0, int scale)
        {
            var map = GetBitmapLayerAcre(layer, x0, y0, out int mh, out int mw);
            var data = ImageUtil.ScalePixelImage(map, scale, mw, mh, out var w, out var h);

            // draw symbols over special items now?
            DrawDirectionals(data, layer, w, x0, y0, scale);

            // Slap on a grid
            DrawGrid(data, w, h, scale);

            // Return final data
            return ImageUtil.GetBitmap(data, w, h);
        }

        private static void DrawDirectionals(int[] data, FieldItemLayer layer, int w, int x0, int y0, int scale)
        {
            for (int x = x0; x < x0 + layer.GridWidth; x++)
            {
                for (int y = y0; y < y0 + layer.GridHeight; y++)
                {
                    var tile = layer.GetTile(x, y);
                    if (tile.IsNone)
                        continue;
                    if (tile.IsBuried)
                        DrawX(data, (x - x0) * scale, (y - y0) * scale, scale, w);
                    else if (tile.IsExtension)
                        DrawDirectional(data, tile, (x - x0) * scale, (y - y0) * scale, scale, w);
                }
            }
        }

        private static void DrawX(int[] data, int x0, int y0, int scale, int w)
        {
            var opposite = scale - 1;
            var wo = w * opposite;

            // Starting offsets for each of the slashes
            var bBackward = (w * y0) + x0; // Backwards \
            var bForward = bBackward + wo; //  Forwards /

            for (int x = 0; x < scale; x++)
            {
                var wx = w * x;
                var backward = bBackward + x + wx;
                data[backward] ^= 0x808080;
                var forward = bForward + x - wx;
                data[forward] ^= 0x808080;
            }
        }

        private static void DrawDirectional(int[] data, FieldItem tile, int x0, int y0, int scale, int w)
        {
            var eX = tile.ExtensionX;
            var eY = tile.ExtensionY;
            var sum = eX + eY;
            var start = scale / (sum + 1);
            var startX = eX >= eY ? 0 : start;
            var startY = eX <= eY ? 0 : start;

            var baseIndex = (w * y0) + x0;
            for (int x = startX, y = startY; x < scale && y < scale; x += eX, y += eY)
            {
                var index = baseIndex + (w * y) + x;
                data[index] ^= 0x808080;
            }
        }

        private static void DrawGrid(int[] data, int w, int h, int scale)
        {
            const int grid = -0x777778; // 0xFF888888u

            // Horizontal Lines
            for (int y = scale; y < h; y += scale)
            {
                var baseIndex = y * w;
                for (int x = 0; x < w; x++)
                {
                    var index = baseIndex + x;
                    data[index] = grid;
                }
            }

            // Vertical Lines
            for (int y = 0; y < h; y++)
            {
                var baseIndex = y * w;
                for (int x = scale; x < w; x += scale)
                {
                    var index = baseIndex + x;
                    data[index] = grid;
                }
            }
        }

        public static Bitmap GetBitmapLayer(FieldItemLayer layer, int x, int y, int scale = 1)
        {
            var map = GetBitmapLayer(layer);
            if (scale > 1)
                map = ImageUtil.ResizeImage(map, map.Width, map.Height);

            return DrawViewReticle(map, layer, x, y, scale);
        }

        public static Bitmap GetBitmapLayer(FieldItemLayer layer, int x, int y, int[] data, Bitmap dest)
        {
            LoadBitmapLayer(layer.Tiles, data, layer.MapWidth, layer.MapHeight);
            ImageUtil.SetBitmapData(dest, data);
            return DrawViewReticle(dest, layer, x, y);
        }

        private static Bitmap DrawViewReticle(Bitmap map, MapGrid g, int x, int y, int scale = 1)
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

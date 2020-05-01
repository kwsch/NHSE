using System.Collections.Generic;
using System.Drawing;
using NHSE.Core;

namespace NHSE.Sprites
{
    public static class TerrainSprite
    {
        private static readonly Brush Selected = Brushes.Red;
        private static readonly Brush Others = Brushes.Yellow;
        private static readonly Brush Text = Brushes.White;
        private static readonly Brush Plaza = Brushes.RosyBrown;
        private static readonly StringFormat BuildingTextFormat = new StringFormat
            { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        private const int PlazaWidth = 6 * 2;
        private const int PlazaHeight = 5 * 2;

        public static Bitmap CreateMap(TerrainManager mgr)
        {
            var bmp = new Bitmap(mgr.MapWidth, mgr.MapHeight);
            for (int x = 0; x < mgr.MapWidth; x++)
            {
                for (int y = 0; y < mgr.MapHeight; y++)
                {
                    var tile = mgr.GetTile(x, y);
                    var color = TerrainTileColor.GetTileColor(tile);
                    bmp.SetPixel(x, y, color);
                }
            }

            return bmp;
        }

        public static Bitmap CreateMap(TerrainManager mgr, int scale, int x, int y)
        {
            var img = CreateMap(mgr);
            var map = ImageUtil.ResizeImage(img, img.Width * scale, img.Height * scale);
            return DrawReticle(map, mgr, x, y, scale);
        }

        public static Bitmap CreateMap(TerrainManager mgr, int scale, int acreIndex = -1)
        {
            var img = CreateMap(mgr);
            var map = ImageUtil.ResizeImage(img, img.Width * scale, img.Height * scale);

            if (acreIndex < 0)
                return map;

            var acre = MapGrid.Acres[acreIndex];
            var x = acre.X * mgr.GridWidth;
            var y = acre.Y * mgr.GridHeight;

            return DrawReticle(map, mgr, x, y, scale);
        }

        private static Bitmap DrawReticle(Bitmap map, MapGrid mgr, int x, int y, int scale)
        {
            using var gfx = Graphics.FromImage(map);
            using var pen = new Pen(Color.Red);

            int w = mgr.GridWidth * scale;
            int h = mgr.GridHeight * scale;
            gfx.DrawRectangle(pen, x * scale, y * scale, w, h);
            return map;
        }

        public static Bitmap GetMapWithBuildings(TerrainManager mgr, IReadOnlyList<Building> buildings, ushort plazaX, ushort plazaY, Font? f, int scale = 4, int index = -1)
        {
            var map = CreateMap(mgr, scale);
            using var gfx = Graphics.FromImage(map);

            gfx.DrawPlaza(mgr, plazaX, plazaY, scale);
            gfx.DrawBuildings(mgr, buildings, f, scale, index);
            return map;
        }

        private static void DrawPlaza(this Graphics gfx, TerrainManager g, ushort px, ushort py, int scale)
        {
            g.GetBuildingCoordinate(px, py, scale, out var x, out var y);

            var width = scale * PlazaWidth;
            var height = scale * PlazaHeight;

            gfx.FillRectangle(Plaza, x, y, width, height);
        }

        private static void DrawBuildings(this Graphics gfx, TerrainManager g, IReadOnlyList<Building> buildings, Font? f, int scale, int index = -1)
        {
            for (int i = 0; i < buildings.Count; i++)
            {
                var b = buildings[i];
                if (b.BuildingType == 0)
                    continue;
                g.GetBuildingCoordinate(b.X, b.Y, scale, out var x, out var y);

                var pen = index == i ? Selected : Others;
                DrawBuilding(gfx, f, scale, pen, x, y, b, Text);
            }
        }

        private static void DrawBuilding(Graphics gfx, Font? f, int scale, Brush pen, int x, int y, Building b, Brush text)
        {
            gfx.FillRectangle(pen, x - scale, y - scale, scale * 2, scale * 2);

            if (f != null)
            {
                var name = b.BuildingType.ToString();
                gfx.DrawString(name, f, text, new PointF(x, y - (scale * 2)), BuildingTextFormat);
            }
        }

        public static Image GetAcre(in int topX, in int topY, TerrainManager t, int acreScale)
        {
            int[] data = new int[16 * 16];
            int index = 0;
            for (int y = 0; y < 16; y++)
            {
                var yi = y + topY;
                for (int x = 0; x < 16; x++, index++)
                {
                    var tile = t.GetTile(x + topX, yi);
                    data[index] = TerrainTileColor.GetTileColor(tile).ToArgb();
                }
            }

            var final = ImageUtil.ScalePixelImage(data, acreScale, 16, 16, out int fw, out int fh);
            return ImageUtil.GetBitmap(final, fw, fh);
        }

        public static Image GetAcre(in int topX, in int topY, TerrainManager t, int acreScale, IReadOnlyList<Building> buildings, ushort plazaX, ushort plazaY)
        {
            var img = GetAcre(topX, topY, t, acreScale);
            using var gfx = Graphics.FromImage(img);

            gfx.DrawAcrePlaza(t, topX, topY, plazaX, plazaY, acreScale);

            foreach (var b in buildings)
            {
                if (!t.GetBuildingRelativeCoordinate(topX, topY, acreScale, b.X, b.Y, out var x, out var y))
                {
                    // Draw the rectangle anyways. The graphics object will write the cropped rectangle correctly!
                }

                DrawBuilding(gfx, null, acreScale, Others, x, y, b, Text);
            }

            return img;
        }

        private static void DrawAcrePlaza(this Graphics gfx, TerrainManager g, int topX, int topY, ushort px, ushort py, int scale)
        {
            if (!g.GetBuildingRelativeCoordinate(topX, topY, scale, px, py, out var x, out var y))
            {
                // Draw the rectangle anyways. The graphics object will write the cropped rectangle correctly!
            }

            var width = scale * PlazaWidth;
            var height = scale * PlazaHeight;

            gfx.FillRectangle(Plaza, x, y, width, height);
        }
    }
}

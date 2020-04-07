using System;
using System.Collections.Generic;
using System.Drawing;
using NHSE.Core;

namespace NHSE.Sprites
{
    public static class TerrainSprite
    {
        public static Color GetTileColor(TerrainTile tile)
        {
            var name = tile.UnitModel.ToString();
            var baseColor = GetTileColor(name);
            if (tile.Elevation == 0)
                return baseColor;

            return ColorUtil.Blend(baseColor, Color.White, 1d / (tile.Elevation + 1));
        }

        private static Color GetTileColor(string name)
        {
            if (name.StartsWith("River")) // River
                return Color.DeepSkyBlue;
            if (name.StartsWith("Fall")) // Waterfall
                return Color.DarkBlue;
            if (name.Contains("Cliff"))
                return ColorUtil.Blend(Color.ForestGreen, Color.Black, 0.5d);
            return Color.ForestGreen;
        }

        private static readonly char[] Numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public static string GetTileName(TerrainTile tile)
        {
            var name = tile.UnitModel.ToString();
            var num = name.IndexOfAny(Numbers);
            if (num < 0)
                return name;
            return name.Substring(0, num) + Environment.NewLine + name.Substring(num);
        }

        public static Bitmap CreateMap(TerrainManager mgr)
        {
            var bmp = new Bitmap(mgr.MapWidth, mgr.MapHeight);
            for (int x = 0; x < mgr.MapWidth; x++)
            {
                for (int y = 0; y < mgr.MapHeight; y++)
                {
                    var tile = mgr.GetTile(x, y);
                    var color = GetTileColor(tile);
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

        public static Bitmap GetMapWithBuildings(TerrainManager mgr, IReadOnlyList<Building> buildings, ushort plazaX, ushort plazaY, Font f, int scale = 4, int index = -1)
        {
            var map = CreateMap(mgr, scale);
            using var gfx = Graphics.FromImage(map);

            gfx.DrawPlaza(mgr, plazaX, plazaY, scale);
            gfx.DrawBuildings(mgr, buildings, f, scale, index);
            return map;
        }

        private static void DrawPlaza(this Graphics gfx, MapGrid g, ushort px, ushort py, int scale)
        {
            var plaza = Brushes.RosyBrown;
            GetBuildingCoordinate(g, px, py, scale, out var x, out var y);

            var width = scale * 2 * 6;
            var height = scale * 2 * 5;

            gfx.FillRectangle(plaza, x, y, width, height);
        }

        private static void DrawBuildings(this Graphics gfx, MapGrid g, IReadOnlyList<Building> buildings, Font f, int scale, int index = -1)
        {
            var selected = Brushes.Red;
            var others = Brushes.Yellow;
            var text = Brushes.White;
            var stringFormat = new StringFormat {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center};

            for (int i = 0; i < buildings.Count; i++)
            {
                var b = buildings[i];
                if (b.BuildingType == 0)
                    continue;
                GetBuildingCoordinate(g,b.X, b.Y, scale, out var x, out var y);

                var pen = index == i ? selected : others;
                gfx.FillRectangle(pen, x - scale, y - scale, scale * 2, scale * 2);

                var name = b.BuildingType.ToString();
                gfx.DrawString(name, f, text, new PointF(x, y - (scale * 2)), stringFormat);
            }
        }

        private static void GetBuildingCoordinate(MapGrid g, ushort bx, ushort by, int scale, out int x, out int y)
        {
            // Although there is terrain in the Top Row and Left Column, no buildings can be placed there.
            // Adjust the building coordinates down-right by an acre.
            int buildingShift = g.GridWidth;
            x = (int) (((bx / 2f) - buildingShift) * scale);
            y = (int) (((by / 2f) - buildingShift) * scale);
        }
    }
}

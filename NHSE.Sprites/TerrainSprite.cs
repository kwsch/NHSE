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
            var bmp = new Bitmap(TerrainManager.MapWidth, TerrainManager.MapHeight);
            for (int x = 0; x < TerrainManager.MapWidth; x++)
            {
                for (int y = 0; y < TerrainManager.MapHeight; y++)
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
            return DrawReticle(map, x, y, scale);
        }

        public static Bitmap CreateMap(TerrainManager mgr, int scale, int acreIndex = -1)
        {
            var img = CreateMap(mgr);
            var map = ImageUtil.ResizeImage(img, img.Width * scale, img.Height * scale);

            if (acreIndex < 0)
                return map;

            var acre = mgr.Acres[acreIndex];
            var x = acre.X * TerrainManager.GridWidth;
            var y = acre.Y * TerrainManager.GridHeight;

            return DrawReticle(map, x, y, scale);
        }

        private static Bitmap DrawReticle(Bitmap map, int x, int y, int scale)
        {
            using var gfx = Graphics.FromImage(map);
            using var pen = new Pen(Color.Red);

            int w = TerrainManager.GridWidth * scale;
            int h = TerrainManager.GridHeight * scale;
            gfx.DrawRectangle(pen, x * scale, y * scale, w, h);
            return map;
        }

        public static Bitmap GetMapWithBuildings(TerrainManager mgr, IReadOnlyList<Building> buildings, Font f, int scale = 4, int index = -1)
        {
            // Although there is terrain in the Top Row and Left Column, no buildings can be placed there.
            // Adjust the building coordinates down-right by an acre.
            const int buildingShift = TerrainManager.GridWidth;
            var map = CreateMap(mgr, scale);
            using var gfx = Graphics.FromImage(map);

            var selected = Brushes.Red;
            var others = Brushes.Yellow;
            var text = Brushes.White;
            var stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            for (int i = 0; i < buildings.Count; i++)
            {
                var b = buildings[i];
                if (b.BuildingType == 0)
                    continue;
                var x = (int)(((b.X / 2f) - buildingShift) * scale);
                var y = (int)(((b.Y / 2f) - buildingShift) * scale);

                var pen = index == i ? selected : others;
                gfx.FillRectangle(pen, x - scale, y - scale, scale * 2, scale * 2);

                var name = b.BuildingType.ToString();
                gfx.DrawString(name, f, text, new PointF(x, y - (scale * 2)), stringFormat);
            }

            return map;
        }
    }
}
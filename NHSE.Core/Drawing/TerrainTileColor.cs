using System;
using System.Drawing;

namespace NHSE.Core
{
    public static class TerrainTileColor
    {
        public static Color GetTileColor(TerrainTile tile)
        {
            if (tile.UnitModelRoad.IsRoad())
                return Color.RosyBrown;
            var baseColor = GetTileDefaultColor(tile.UnitModel);
            if (tile.Elevation == 0)
                return baseColor;

            return ColorUtil.Blend(baseColor, Color.White, 1d / (tile.Elevation + 1));
        }

        private static readonly Color CliffBase = ColorUtil.Blend(Color.ForestGreen, Color.Black, 0.6d);

        private static Color GetTileDefaultColor(TerrainUnitModel mdl)
        {
            if (mdl.IsRiver())
                return Color.DeepSkyBlue;
            if (mdl.IsFall())
                return Color.DarkBlue;
            if (mdl.IsCliff())
                return CliffBase;
            return Color.ForestGreen;
        }

        private static readonly char[] Numbers = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

        public static string GetTileName(TerrainTile tile)
        {
            var name = tile.UnitModel.ToString();
            var num = name.IndexOfAny(Numbers);
            if (num < 0)
                return name;
            return name.Substring(0, num) + Environment.NewLine + name.Substring(num);
        }
    }

    public static class AcreTileColor
    {
        public static int GetAcreTileColor(byte acre, int x, int y)
        {
            return Color.ForestGreen.ToArgb();
        }
    }
}

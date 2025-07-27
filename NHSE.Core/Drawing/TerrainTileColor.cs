using System;
using System.Drawing;

namespace NHSE.Core
{
    public static class TerrainTileColor
    {
        private static readonly Color River = Color.FromArgb(128, 215, 195);

        public static Color GetTileColor(TerrainTile tile, int relativeX, int relativeY)
        {
            if (tile.UnitModelRoad.IsRoad())
                return GetRoadColor(tile.UnitModelRoad);
            var baseColor = GetTileDefaultColor(tile.UnitModel, tile.LandMakingAngle, relativeX, relativeY);
            if (tile.Elevation == 0)
                return baseColor;

            return ColorUtil.Blend(baseColor, Color.White, 1.4d / (tile.Elevation + 1));
        }

        private static Color GetRoadColor(TerrainUnitModel mdl)
        {
            if (mdl.IsRoadBrick())
                return Color.Firebrick;
            if (mdl.IsRoadDarkSoil())
                return Color.SaddleBrown;
            if (mdl.IsRoadSoil())
                return Color.Peru;
            if (mdl.IsRoadStone())
                return Color.DarkGray;
            if (mdl.IsRoadPattern())
                return Color.Ivory;
            if (mdl.IsRoadTile())
                return Color.SteelBlue;
            if (mdl.IsRoadSand())
                return Color.SandyBrown;
            return Color.BurlyWood;
        }

        /// <summary>
        /// Notes about rivers the number is how many sides / diagionals are water. ex: river3c immiedietly tells you there are 2 sides and a corner, or 3 sides, that are river
        /// <para>River0A single "hole" of water land all sides. rotation does nothing</para>
        /// <para>River1A narrow channel end opening on bottom, land on other sides</para>
        /// <para>River2A narrow water channel opening on top and bottom, land left and right</para>
        /// <para>River2B narrow 45 channel angled land top left with nub bottom right</para>
        /// <para>River2C narrow 90 channel corner land top left with nub bottom right</para>
        /// <para>River3A narrow 3 way land left side, nub top right and bottom right</para>
        /// <para>River3B river 45 corner angled land top left, no nub</para>
        /// <para>River3C river 90 corner corner land top left, no nub</para>
        /// <para>River4A river side with nub top land left side with nub top right only</para>
        /// <para>River4B river side with nub bottom land left side with nub bottom right only</para>
        /// <para>River4C narrow 4 way nub on all 4 corners, 4 sides water. rotation does nothing</para>
        /// <para>River5A river corner to 2 narrow Nub on top left, top right, and bottom right. 2 narrows meet a river</para>
        /// <para>River5B river side land on left side</para>
        /// <para>River6A river 2 opposing nubs nub on top left and bottom right</para>
        /// <para>River6B river 2 nubs same side nub on bottom left and bottom right corner, where 1 narrow meets river bottom side</para>
        /// <para>River7A river 1 nub nub on bottom left corner, fills gaps of diagonal bank</para>
        /// <para>River8A river no land just water. Rotation doesn't matter</para>
        /// </summary>
        private static Color GetRiverColor(TerrainUnitModel mdl, ushort landAngle, int relativeX, int relativeY)
        {
            // River no land just water. Rotation doesn't matter
            if (mdl == TerrainUnitModel.River0A && (relativeX < 4 || relativeX > 12 || relativeY < 4 || relativeY > 12))
                return Color.ForestGreen;
            if (mdl == TerrainUnitModel.River1A && (relativeX < 4 || relativeX > 12 || relativeY < 4))
                return Color.ForestGreen;
            if (mdl == TerrainUnitModel.River2A && (relativeX < 4 || relativeX > 12))
                return Color.ForestGreen;
            if (mdl == TerrainUnitModel.River3C && (relativeX < 4 || relativeY < 4))
                return Color.ForestGreen;
            if (mdl == TerrainUnitModel.River5B && relativeX < 4)
                return Color.ForestGreen;
            if (mdl == TerrainUnitModel.River8A)
                return River;


            return River;
        }

        private static readonly Color CliffBase = ColorUtil.Blend(Color.ForestGreen, Color.Black, 0.6d);

        private static Color GetTileDefaultColor(TerrainUnitModel mdl, ushort landAngle, int relativeX, int relativeY)
        {
            if (mdl.IsRiver())
                return GetRiverColor(mdl, landAngle, relativeX, relativeY);
            if (mdl.IsFall())
                return Color.DeepSkyBlue;
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
}

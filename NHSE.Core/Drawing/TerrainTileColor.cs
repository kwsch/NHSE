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

        /// <summary>Notes about rivers the number is how many sides / diagonals are water.</summary>
        private static Color GetRiverColor(TerrainUnitModel mdl, LandAngles landAngle, int relativeX, int relativeY)
        {
            // River0A single "hole" of water land all sides. Rotation does nothing
            if (mdl == TerrainUnitModel.River0A && (relativeX < 4 || relativeX >= 12 || relativeY < 4 || relativeY >= 12))
            {
                return Color.ForestGreen;
            }

            // River1A narrow channel end opening on bottom, land on other sides
            if (mdl == TerrainUnitModel.River1A)
            {
                return landAngle switch
                {
                    LandAngles.Default when relativeX < 4 || relativeX >= 12 || relativeY < 4 => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when relativeX < 4 || relativeY < 4 || relativeY >= 12 => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when relativeX < 4 || relativeX >= 12 || relativeY >= 12 => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when relativeY < 4 || relativeY >= 12 || relativeX >= 12 => Color.ForestGreen,
                    _ => River
                };
            }

            // River2A narrow water channel opening on top and bottom, land left and right
            if (mdl == TerrainUnitModel.River2A)
            {
                return landAngle switch
                {
                    LandAngles.Default when relativeX < 4 || relativeX >= 12 => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when relativeY >= 12 || relativeY < 4 => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when relativeX < 4 || relativeX >= 12 => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when relativeY < 4 || relativeY >= 12 => Color.ForestGreen,
                    _ => River
                };
            }

            // River2B narrow 45 channel angled land top left with nub bottom right
            if (mdl == TerrainUnitModel.River2B)
            {
                return landAngle switch
                {
                    LandAngles.Default when IsPointInMultiTriangle(relativeX, relativeY, new(4, 15), new(0, 0), new(15, 4), new(0, 15), new(15, 0))
                        || IsNubOnBottomRight(relativeX, relativeY)
                        || relativeX < 4 || relativeY < 4 => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when IsPointInMultiTriangle(relativeX, relativeY, new(4, 0), new(0, 15), new(15, 12), new(0, 0), new(15, 15))
                        || IsNubOnTopRight(relativeX, relativeY)
                        || relativeX < 4 || relativeY >= 12 => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when IsPointInMultiTriangle(relativeX, relativeY, new(0, 12), new(15, 15), new(12, 0), new(0, 15), new(15, 0))
                        || IsNubOnTopLeft(relativeX, relativeY)
                        || relativeX >= 12 || relativeY >= 12 => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when IsPointInMultiTriangle(relativeX, relativeY, new(0, 4), new(15, 0), new(12, 15), new(0, 0), new(15, 15))
                        || IsNubOnBottomLeft(relativeX, relativeY)
                        || relativeX >= 12 || relativeY < 4 => Color.ForestGreen,
                    _ => River
                };
            }

            // River2C narrow 90 channel corner land top left with nub bottom right
            if (mdl == TerrainUnitModel.River2C)
            {
                return landAngle switch
                {
                    LandAngles.Default when relativeX < 4 || relativeY < 4 || IsNubOnBottomRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when relativeX < 4 || relativeY >= 12 || IsNubOnTopRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when relativeX >= 12 || relativeY >= 12 || IsNubOnTopLeft(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when relativeX >= 12 || relativeY < 4 || IsNubOnBottomLeft(relativeX, relativeY) => Color.ForestGreen,
                    _ => River
                };
            }

            // River3A narrow 3 way land left side, nub top right and bottom right
            if (mdl == TerrainUnitModel.River3A)
            {
                return landAngle switch
                {
                    LandAngles.Default when relativeX < 4 || IsNubOnTopRight(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when relativeY >= 12 || IsNubOnTopLeft(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when relativeX >= 12 || IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnTopLeft(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when relativeY < 4 || IsNubOnBottomRight(relativeX, relativeY) || IsNubOnBottomLeft(relativeX, relativeY) => Color.ForestGreen,
                    _ => River
                };
            }

            // River3B river 45 corner angled land top left, no nub
            if (mdl == TerrainUnitModel.River3B)
            {
                return landAngle switch
                {
                    LandAngles.Default when IsPointInMultiTriangle(relativeX, relativeY, new(4, 15), new(0, 0), new(15, 4), new(0, 15), new(15, 0)) => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when IsPointInMultiTriangle(relativeX, relativeY, new(4, 0), new(0, 15), new(15, 12), new(0, 0), new(15, 15)) => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when IsPointInMultiTriangle(relativeX, relativeY, new(0, 12), new(15, 15), new(12, 0), new(0, 15), new(15, 0)) => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when IsPointInMultiTriangle(relativeX, relativeY, new(0, 4), new(15, 0), new(12, 15), new(0, 0), new(15, 15)) => Color.ForestGreen,
                    _ => River
                };
            }

            // River3C river 90 corner corner land top left, no nub
            if (mdl == TerrainUnitModel.River3C)
            {
                return landAngle switch
                {
                    LandAngles.Default when relativeX < 4 || relativeY < 4 => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when relativeX < 4 || relativeY >= 12 => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when relativeX >= 12 || relativeY >= 12 => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when relativeX >= 12 || relativeY < 4 => Color.ForestGreen,
                    _ => River
                };
            }

            // River4A river side with nub top land left side with nub top right only
            if (mdl == TerrainUnitModel.River4A)
            {
                return landAngle switch
                {
                    LandAngles.Default when relativeX < 4 || IsNubOnTopRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when relativeY >= 12 || IsNubOnTopLeft(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when relativeX >= 12 || IsNubOnBottomLeft(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when relativeY < 4 || IsNubOnBottomRight(relativeX, relativeY) => Color.ForestGreen,
                    _ => River
                };
            }

            // River4B river side with nub bottom land left side with nub bottom right only
            if (mdl == TerrainUnitModel.River4B)
            {
                return landAngle switch
                {
                    LandAngles.Default when relativeX < 4 || IsNubOnBottomRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when relativeY >= 12 || IsNubOnTopRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when relativeX >= 12 || IsNubOnTopLeft(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when relativeY < 4 || IsNubOnBottomLeft(relativeX, relativeY) => Color.ForestGreen,
                    _ => River
                };
            }

            // River4C narrow 4 way nub on all 4 corners, 4 sides water. rotation does nothing
            if (mdl == TerrainUnitModel.River4C && (
                IsNubOnBottomLeft(relativeX, relativeY) ||
                IsNubOnBottomRight(relativeX, relativeY) ||
                IsNubOnTopLeft(relativeX, relativeY) ||
                IsNubOnTopRight(relativeX, relativeY)))
            {
                return Color.ForestGreen;
            }

            // River5A river corner to 2 narrow Nub on top left, top right, and bottom right. 2 narrows meet a river
            if (mdl == TerrainUnitModel.River5A)
            {
                return landAngle switch
                {
                    LandAngles.Default when IsNubOnTopLeft(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnTopLeft(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) || IsNubOnTopLeft(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) => Color.ForestGreen,
                    _ => River
                };
            }

            // River5B river side land on left side
            if (mdl == TerrainUnitModel.River5B)
            {
                return landAngle switch
                {
                    LandAngles.Default when relativeX < 4 => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when relativeY >= 12 => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when relativeX >= 12 => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when relativeY < 4 => Color.ForestGreen,
                    _ => River
                };
            }

            // River6A river 2 opposing nubs nub on top left and bottom right
            if (mdl == TerrainUnitModel.River6A)
            {
                return landAngle switch
                {
                    LandAngles.Default when IsNubOnTopLeft(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when IsNubOnTopLeft(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) => Color.ForestGreen,
                    _ => River
                };
            }

            // River6B river 2 nubs same side nub on bottom left and bottom right corner, where 1 narrow meets river bottom side
            if (mdl == TerrainUnitModel.River6B)
            {
                return landAngle switch
                {
                    LandAngles.Default when IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when IsNubOnBottomRight(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when IsNubOnTopRight(relativeX, relativeY) || IsNubOnTopLeft(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when IsNubOnTopLeft(relativeX, relativeY) || IsNubOnBottomLeft(relativeX, relativeY) => Color.ForestGreen,
                    _ => River
                };
            }

            // River7A river 1 nub nub on bottom left corner, fills gaps of diagonal bank
            if (mdl == TerrainUnitModel.River7A)
            {
                return landAngle switch
                {
                    LandAngles.Default when IsNubOnBottomLeft(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate90ClockAnverse when IsNubOnBottomRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate180ClockAnverse when IsNubOnTopRight(relativeX, relativeY) => Color.ForestGreen,
                    LandAngles.Rotate270ClockAnverse when IsNubOnTopLeft(relativeX, relativeY) => Color.ForestGreen,
                    _ => River
                };
            }

            // River8A river is no land, just water. Rotation doesn't matter
            if (mdl == TerrainUnitModel.River8A)
            {
                return River;
            }

            return River;
        }

        private static bool IsNubOnTopLeft(int relativeX, int relativeY)
            => IsPointInTriangle(relativeX, relativeY, new(0, 4), new(0, 0), new(4, 0));

        private static bool IsNubOnTopRight(int relativeX, int relativeY)
            => IsPointInTriangle(relativeX, relativeY, new(12, 0), new(15, 0), new(15, 4));

        private static bool IsNubOnBottomLeft(int relativeX, int relativeY)
            => IsPointInTriangle(relativeX, relativeY, new(0, 12), new(0, 15), new(4, 15));

        private static bool IsNubOnBottomRight(int relativeX, int relativeY)
            => IsPointInTriangle(relativeX, relativeY, new(12, 15), new(15, 15), new(15, 12));

        private static bool IsPointInMultiTriangle(int px, int py, Coordinate a, Coordinate b, Coordinate c, Coordinate vortexA, Coordinate vortexB)
        {
            return IsPointInTriangle(px, py, a, vortexA, b)
                || IsPointInTriangle(px, py, a, b, c)
                || IsPointInTriangle(px, py, c, b, vortexB);
        }

        private static bool IsPointInTriangle(int px, int py, Coordinate a, Coordinate b, Coordinate c)
        {
            Coordinate p = new(px, py);
            float areaTotal = GetTriangleArea(a, b, c);
            float area1 = GetTriangleArea(p, b, c);
            float area2 = GetTriangleArea(a, p, c);
            float area3 = GetTriangleArea(a, b, p);

            return Math.Abs(areaTotal - (area1 + area2 + area3)) < 0.0001f;
        }

        private static float GetTriangleArea(Coordinate A, Coordinate B, Coordinate C)
        {
            return Math.Abs((A.X * (B.Y - C.Y) +
                             B.X * (C.Y - A.Y) +
                             C.X * (A.Y - B.Y)) / 2.0f);
        }

        private sealed record Coordinate(int X, int Y);

        private static readonly Color CliffBase = ColorUtil.Blend(Color.ForestGreen, Color.Black, 0.6d);

        private static Color GetTileDefaultColor(TerrainUnitModel mdl, ushort landAngle, int relativeX, int relativeY)
        {
            var angle = (LandAngles)landAngle;
            if (mdl.IsRiver())
                return GetRiverColor(mdl, angle, relativeX, relativeY);
            if (mdl.IsFall())
                return Color.DeepSkyBlue;
            if (mdl.IsCliff())
                return CliffBase;
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
    }
}

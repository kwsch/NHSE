using System;
using System.Drawing;
using static NHSE.Core.TerrainUnitModel;
using static NHSE.Core.LandAngles;

namespace NHSE.Core;

public static class TerrainTileColor
{
    private static readonly Color River = Color.FromArgb(128, 215, 195);
    private static readonly Color Grass = Color.ForestGreen;

    public static Color GetTileColor(TerrainTile tile, int relativeX, int relativeY)
    {
        if (tile.UnitModelRoad.IsRoad)
            return GetRoadColor(tile.UnitModelRoad);
        var baseColor = GetTileDefaultColor(tile.UnitModel, tile.LandMakingAngle, relativeX, relativeY);
        if (tile.Elevation == 0)
            return baseColor;

        return ColorUtil.Blend(baseColor, Color.White, 1.4d / (tile.Elevation + 1));
    }

    private static Color GetRoadColor(TerrainUnitModel mdl)
    {
        if (mdl.IsRoadBrick)
            return Color.Firebrick;
        if (mdl.IsRoadDarkSoil)
            return Color.SaddleBrown;
        if (mdl.IsRoadSoil)
            return Color.Peru;
        if (mdl.IsRoadStone)
            return Color.DarkGray;
        if (mdl.IsRoadPattern)
            return Color.Ivory;
        if (mdl.IsRoadTile)
            return Color.SteelBlue;
        if (mdl.IsRoadSand)
            return Color.SandyBrown;
        return Color.BurlyWood;
    }

    /// <summary>Notes about rivers the number is how many sides / diagonals are water.</summary>
    private static Color GetRiverColor(TerrainUnitModel mdl, LandAngles landAngle, int relativeX, int relativeY)
    {
        return mdl switch
        {
            // River0A single "hole" of water land all sides. Rotation does nothing
            River0A when (relativeX is (< 4 or >= 12) || relativeY is (< 4 or >= 12)) =>
                Grass,
            // River1A narrow channel end opening on bottom, land on other sides
            River1A => landAngle switch
            {
                Default when relativeX is (< 4 or >= 12) || relativeY < 4 => Grass,
                Rotate90ClockAnverse when relativeX < 4 || relativeY is (< 4 or >= 12) => Grass,
                Rotate180ClockAnverse when relativeX is (< 4 or >= 12) || relativeY >= 12 => Grass,
                Rotate270ClockAnverse when relativeY is (< 4 or >= 12) || relativeX >= 12 => Grass,
                _ => River
            },
            // River2A narrow water channel opening on top and bottom, land left and right
            River2A => landAngle switch
            {
                Default when relativeX is (< 4 or >= 12) => Grass,
                Rotate90ClockAnverse when relativeY is (< 4 or >= 12) => Grass,
                Rotate180ClockAnverse when relativeX is (< 4 or >= 12) => Grass,
                Rotate270ClockAnverse when relativeY is (< 4 or >= 12) => Grass,
                _ => River
            },
            // River2B narrow 45 channel angled land top left with nub bottom right
            River2B => landAngle switch
            {
                Default when IsPointInMultiTriangle(relativeX, relativeY, (4, 15), (0, 0), (15, 4), (0, 15), (15, 0)) || IsNubOnBottomRight(relativeX, relativeY) || relativeX < 4 || relativeY < 4 => Grass,
                Rotate90ClockAnverse when IsPointInMultiTriangle(relativeX, relativeY, (4, 0), (0, 15), (15, 12), (0, 0), (15, 15)) || IsNubOnTopRight(relativeX, relativeY) || relativeX < 4 || relativeY >= 12 => Grass,
                Rotate180ClockAnverse when IsPointInMultiTriangle(relativeX, relativeY, (0, 12), (15, 15), (12, 0), (0, 15), (15, 0)) || IsNubOnTopLeft(relativeX, relativeY) || relativeX >= 12 || relativeY >= 12 => Grass,
                Rotate270ClockAnverse when IsPointInMultiTriangle(relativeX, relativeY, (0, 4), (15, 0), (12, 15), (0, 0), (15, 15)) || IsNubOnBottomLeft(relativeX, relativeY) || relativeX >= 12 || relativeY < 4 => Grass,
                _ => River
            },
            // River2C narrow 90 channel corner land top left with nub bottom right
            River2C => landAngle switch
            {
                Default when relativeX < 4 || relativeY < 4 || IsNubOnBottomRight(relativeX, relativeY) => Grass,
                Rotate90ClockAnverse when relativeX < 4 || relativeY >= 12 || IsNubOnTopRight(relativeX, relativeY) => Grass,
                Rotate180ClockAnverse when relativeX >= 12 || relativeY >= 12 || IsNubOnTopLeft(relativeX, relativeY) => Grass,
                Rotate270ClockAnverse when relativeX >= 12 || relativeY < 4 || IsNubOnBottomLeft(relativeX, relativeY) => Grass,
                _ => River
            },
            // River3A narrow 3 way land left side, nub top right and bottom right
            River3A => landAngle switch
            {
                Default when relativeX < 4 || IsNubOnTopRight(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) => Grass,
                Rotate90ClockAnverse when relativeY >= 12 || IsNubOnTopLeft(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) => Grass,
                Rotate180ClockAnverse when relativeX >= 12 || IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnTopLeft(relativeX, relativeY) => Grass,
                Rotate270ClockAnverse when relativeY < 4 || IsNubOnBottomRight(relativeX, relativeY) || IsNubOnBottomLeft(relativeX, relativeY) => Grass,
                _ => River
            },
            // River3B river 45 corner angled land top left, no nub
            River3B => landAngle switch
            {
                Default when IsPointInMultiTriangle(relativeX, relativeY, (4, 15), (0, 0), (15, 4), (0, 15), (15, 0)) => Grass,
                Rotate90ClockAnverse when IsPointInMultiTriangle(relativeX, relativeY, (4, 0), (0, 15), (15, 12), (0, 0), (15, 15)) => Grass,
                Rotate180ClockAnverse when IsPointInMultiTriangle(relativeX, relativeY, (0, 12), (15, 15), (12, 0), (0, 15), (15, 0)) => Grass,
                Rotate270ClockAnverse when IsPointInMultiTriangle(relativeX, relativeY, (0, 4), (15, 0), (12, 15), (0, 0), (15, 15)) => Grass,
                _ => River
            },
            // River3C river 90 corner corner land top left, no nub
            River3C => landAngle switch
            {
                Default when relativeX < 4 || relativeY < 4 => Grass,
                Rotate90ClockAnverse when relativeX < 4 || relativeY >= 12 => Grass,
                Rotate180ClockAnverse when relativeX >= 12 || relativeY >= 12 => Grass,
                Rotate270ClockAnverse when relativeX >= 12 || relativeY < 4 => Grass,
                _ => River
            },
            // River4A river side with nub top land left side with nub top right only
            River4A => landAngle switch
            {
                Default when relativeX < 4 || IsNubOnTopRight(relativeX, relativeY) => Grass,
                Rotate90ClockAnverse when relativeY >= 12 || IsNubOnTopLeft(relativeX, relativeY) => Grass,
                Rotate180ClockAnverse when relativeX >= 12 || IsNubOnBottomLeft(relativeX, relativeY) => Grass,
                Rotate270ClockAnverse when relativeY < 4 || IsNubOnBottomRight(relativeX, relativeY) => Grass,
                _ => River
            },
            // River4B river side with nub bottom land left side with nub bottom right only
            River4B => landAngle switch
            {
                Default when relativeX < 4 || IsNubOnBottomRight(relativeX, relativeY) => Grass,
                Rotate90ClockAnverse when relativeY >= 12 || IsNubOnTopRight(relativeX, relativeY) => Grass,
                Rotate180ClockAnverse when relativeX >= 12 || IsNubOnTopLeft(relativeX, relativeY) => Grass,
                Rotate270ClockAnverse when relativeY < 4 || IsNubOnBottomLeft(relativeX, relativeY) => Grass,
                _ => River
            },
            // River4C narrow 4 way nub on all 4 corners, 4 sides water. rotation does nothing
            River4C when (IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) || IsNubOnTopLeft(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY)) => Grass,
            // River5A river corner to 2 narrow Nub on top left, top right, and bottom right. 2 narrows meet a river
            River5A => landAngle switch
            {
                Default when IsNubOnTopLeft(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) => Grass,
                Rotate90ClockAnverse when IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnTopLeft(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) => Grass,
                Rotate180ClockAnverse when IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) || IsNubOnTopLeft(relativeX, relativeY) => Grass,
                Rotate270ClockAnverse when IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) => Grass,
                _ => River
            },
            // River5B river side land on left side
            River5B => landAngle switch
            {
                Default when relativeX < 4 => Grass,
                Rotate90ClockAnverse when relativeY >= 12 => Grass,
                Rotate180ClockAnverse when relativeX >= 12 => Grass,
                Rotate270ClockAnverse when relativeY < 4 => Grass,
                _ => River
            },
            // River6A river 2 opposing nubs nub on top left and bottom right
            River6A => landAngle switch
            {
                Default when IsNubOnTopLeft(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) => Grass,
                Rotate90ClockAnverse when IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) => Grass,
                Rotate180ClockAnverse when IsNubOnTopLeft(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) => Grass,
                Rotate270ClockAnverse when IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) => Grass,
                _ => River
            },
            // River6B river 2 nubs same side nub on bottom left and bottom right corner, where 1 narrow meets river bottom side
            River6B => landAngle switch
            {
                Default when IsNubOnBottomLeft(relativeX, relativeY) || IsNubOnBottomRight(relativeX, relativeY) => Grass,
                Rotate90ClockAnverse when IsNubOnBottomRight(relativeX, relativeY) || IsNubOnTopRight(relativeX, relativeY) => Grass,
                Rotate180ClockAnverse when IsNubOnTopRight(relativeX, relativeY) || IsNubOnTopLeft(relativeX, relativeY) => Grass,
                Rotate270ClockAnverse when IsNubOnTopLeft(relativeX, relativeY) || IsNubOnBottomLeft(relativeX, relativeY) => Grass,
                _ => River
            },
            // River7A river 1 nub nub on bottom left corner, fills gaps of diagonal bank
            River7A => landAngle switch
            {
                Default when IsNubOnBottomLeft(relativeX, relativeY) => Grass,
                Rotate90ClockAnverse when IsNubOnBottomRight(relativeX, relativeY) => Grass,
                Rotate180ClockAnverse when IsNubOnTopRight(relativeX, relativeY) => Grass,
                Rotate270ClockAnverse when IsNubOnTopLeft(relativeX, relativeY) => Grass,
                _ => River
            },
            // River8A river is no land, just water. Rotation doesn't matter
            River8A => River,
            _ => River
        };
    }

    private static bool IsNubOnTopLeft(int relativeX, int relativeY) => IsPointInTriangle(relativeX, relativeY, (0, 4), (0, 0), (4, 0));
    private static bool IsNubOnTopRight(int relativeX, int relativeY) => IsPointInTriangle(relativeX, relativeY, (12, 0), (15, 0), (15, 4));
    private static bool IsNubOnBottomLeft(int relativeX, int relativeY) => IsPointInTriangle(relativeX, relativeY, (0, 12), (0, 15), (4, 15));
    private static bool IsNubOnBottomRight(int relativeX, int relativeY) => IsPointInTriangle(relativeX, relativeY, (12, 15), (15, 15), (15, 12));

    private static bool IsPointInMultiTriangle(int px, int py, Coordinate a, Coordinate b, Coordinate c, Coordinate vortexA, Coordinate vortexB)
    {
        return IsPointInTriangle(px, py, a, vortexA, b)
               || IsPointInTriangle(px, py, a, b, c)
               || IsPointInTriangle(px, py, c, b, vortexB);
    }

    private static bool IsPointInTriangle(int px, int py, Coordinate a, Coordinate b, Coordinate c)
    {
        Coordinate p = (px, py);
        float areaTotal = GetTriangleArea(a, b, c);
        float area1 = GetTriangleArea(p, b, c);
        float area2 = GetTriangleArea(a, p, c);
        float area3 = GetTriangleArea(a, b, p);

        return Math.Abs(areaTotal - (area1 + area2 + area3)) < 0.0001f;
    }

    private static float GetTriangleArea(Coordinate a, Coordinate b, Coordinate c)
    {
        return Math.Abs(((a.X * (b.Y - c.Y)) +
                         (b.X * (c.Y - a.Y)) +
                         (c.X * (a.Y - b.Y))) / 2.0f);
    }

    private readonly record struct Coordinate(int X, int Y)
    {
        public static implicit operator Coordinate((int X, int Y) tuple) => new(tuple.X, tuple.Y);
    }

    private static readonly Color CliffBase = ColorUtil.Blend(Grass, Color.Black, 0.6d);

    private static Color GetTileDefaultColor(TerrainUnitModel mdl, ushort landAngle, int relativeX, int relativeY)
    {
        var angle = (LandAngles)landAngle;
        if (mdl.IsRiver)
            return GetRiverColor(mdl, angle, relativeX, relativeY);
        if (mdl.IsFall)
            return Color.DeepSkyBlue;
        if (mdl.IsCliff)
            return CliffBase;
        return Grass;
    }

    public static string GetTileName(TerrainTile tile)
    {
        var name = tile.UnitModel.ToString();
        var num = name.IndexOfAnyInRange('0', '9');
        if (num < 0)
            return name;
        return name[..num] + Environment.NewLine + name[num..];
    }
}
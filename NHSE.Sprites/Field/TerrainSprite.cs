using System;
using NHSE.Core;
using System.Collections.Generic;
using System.Drawing;

namespace NHSE.Sprites;

public static class TerrainSprite
{
    private static readonly Brush Selected = Brushes.Red;
    private static readonly Brush Others = Brushes.Yellow;
    private static readonly Brush Text = Brushes.White;
    private static readonly Brush Tile = Brushes.Black;
    private static readonly Brush Plaza = Brushes.RosyBrown;
    private static readonly StringFormat BuildingTextFormat = new() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

    private const int PlazaWidth = 6 * 2;
    private const int PlazaHeight = 5 * 2;

    public static void CreateMap(TerrainLayer mgr, Span<int> pixels)
    {
        int i = 0;
        for (int y = 0; y < mgr.TileInfo.TotalHeight; y++)
        {
            for (int x = 0; x < mgr.TileInfo.TotalWidth; x++, i++)
            {
                pixels[i] = mgr.GetTileColor(x, y, x, y);
            }
        }
    }

    public static Bitmap CreateMap(TerrainLayer mgr, Span<int> scale1, int[] scaleX, Bitmap map, int scale, int acreIndex = -1)
    {
        CreateMap(mgr, scale1);
        ImageUtil.ScalePixelImage(scale1, scaleX, map.Width, map.Height, scale);
        ImageUtil.SetBitmapData(map, scaleX);

        if (acreIndex < 0)
            return map;

        var acre = AcreCoordinate.Acres[acreIndex];
        var x = acre.X * mgr.TileInfo.ViewWidth;
        var y = acre.Y * mgr.TileInfo.ViewHeight;

        return DrawReticle(map, mgr.TileInfo, x, y, scale);
    }

    private static Bitmap DrawReticle(Bitmap map, TileGridViewport mgr, int x, int y, int scale)
    {
        using var gfx = Graphics.FromImage(map);
        using var pen = new Pen(Color.Red);

        int w = mgr.ViewWidth * scale;
        int h = mgr.ViewHeight * scale;
        gfx.DrawRectangle(pen, x * scale, y * scale, w, h);
        return map;
    }

    public static Bitmap GetMapWithBuildings(MapTerrainStructure m, Font? f, Span<int> scale1, int[] scaleX, Bitmap map, int scale = 4, int index = -1)
    {
        CreateMap(m.Terrain, scale1, scaleX, map, scale);
        using var gfx = Graphics.FromImage(map);

        gfx.DrawPlaza(m.Terrain, (ushort)m.PlazaX, (ushort)m.PlazaY, scale);
        gfx.DrawBuildings(m.Terrain, m.Buildings, f, scale, index);
        return map;
    }

    private static void DrawPlaza(this Graphics gfx, TerrainLayer g, ushort px, ushort py, int scale)
    {
        g.GetBuildingCoordinate(px, py, scale, out var x, out var y);

        var width = scale * PlazaWidth;
        var height = scale * PlazaHeight;

        gfx.FillRectangle(Plaza, x, y, width, height);
    }

    private static void DrawBuildings(this Graphics gfx, TerrainLayer g, IReadOnlyList<Building> buildings, Font? f, int scale, int index = -1)
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

        if (f == null)
            return;

        var name = b.BuildingType.ToString();
        gfx.DrawString(name, f, text, new PointF(x, y - (scale * 2)), BuildingTextFormat);
    }

    private static void SetAcreTerrainPixels(int x, int y, TerrainLayer t, Span<int> data, Span<int> scaleX, int scale)
    {
        GetAcre1(x, y, t, data);
        ImageUtil.ScalePixelImage(data, scaleX, 16 * scale, 16 * scale, scale / 16);
    }

    private static void GetAcre1(int tileTopX, int tileTopY, TerrainLayer t, Span<int> data)
    {
        int index = 0;

        for (int tileY = 0; tileY < 16; tileY++)
        {
            var tileYIx = tileY + tileTopY;
            for (int pixelY = 0; pixelY < 16; pixelY++)
            {
                for (int tileX = 0; tileX < 16; tileX++)
                {
                    var tileXIx = tileX + tileTopX;
                    for (int pixelX = 0; pixelX < 16; pixelX++)
                    {
                        data[index] = t.GetTileColor(tileXIx, tileYIx, pixelX, pixelY);
                        index++;
                    }
                }
            }
        }
    }

    public static Bitmap GetAcre(MapView m, Font f, Span<int> scale1, int[] scaleX, Bitmap acre, int index, byte tbuild, byte tterrain)
    {
        int mx = m.X / 2;
        int my = m.Y / 2;
        SetAcreTerrainPixels(mx, my, m.Map.Terrain, scale1, scaleX, m.TerrainScale);

        const int grid1 = unchecked((int)0xFF888888u);
        const int grid2 = unchecked((int)0xFF666666u);
        ImageUtil.SetBitmapData(acre, scaleX);

        using var gfx = Graphics.FromImage(acre);

        gfx.DrawAcrePlaza(m.Map.Terrain, mx, my, (ushort)m.Map.PlazaX, (ushort)m.Map.PlazaY, m.TerrainScale, tbuild);

        var buildings = m.Map.Buildings;
        var t = m.Map.Terrain;
        for (var i = 0; i < buildings.Count; i++)
        {
            var b = buildings[i];
            t.GetBuildingRelativeCoordinates(mx, my, m.TerrainScale, b.X, b.Y, out var x, out var y);

            var pen = index == i ? Selected : Others;
            if (tbuild != byte.MaxValue)
            {
                var orig = ((SolidBrush)pen).Color;
                pen = new SolidBrush(Color.FromArgb(tbuild, orig));
            }

            DrawBuilding(gfx, null, m.TerrainScale, pen, x, y, b, Text);
        }

        ImageUtil.GetBitmapData(acre, scaleX);
        ItemLayerSprite.DrawGrid(scaleX, acre.Width, acre.Height, m.AcreScale, grid1);
        ItemLayerSprite.DrawGrid(scaleX, acre.Width, acre.Height, m.TerrainScale, grid2);
        ImageUtil.SetBitmapData(acre, scaleX);

        foreach (var b in buildings)
        {
            t.GetBuildingRelativeCoordinates(mx, my, m.TerrainScale, b.X, b.Y, out var x, out var y);
            if (!t.IsWithinGrid(m.TerrainScale, x, y))
                continue;
            var name = b.BuildingType.ToString();
            gfx.DrawString(name, f, Text, new PointF(x, y - (m.TerrainScale * 2)), BuildingTextFormat);
        }

        if (tterrain != 0)
            DrawTerrainTileNames(mx, my, gfx, t, f, m.TerrainScale, tterrain);

        return acre;
    }

    private static void DrawTerrainTileNames(int topX, int topY, Graphics gfx, TerrainLayer t, Font f, int scale, byte transparency)
    {
        var pen = transparency != byte.MaxValue ? new SolidBrush(Color.FromArgb(transparency, Color.Black)) : Tile;

        for (int y = 0; y < 16; y++)
        {
            var yi = y + topY;
            int cy = (y * scale) + (scale / 2);
            for (int x = 0; x < 16; x++)
            {
                var xi = x + topX;
                var tile = t.GetTile(xi, yi);

                int cx = (x * scale) + (scale / 2);
                var name = TerrainTileColor.GetTileName(tile);
                gfx.DrawString(name, f, pen, new PointF(cx, cy), BuildingTextFormat);
            }
        }
    }

    private static void DrawAcrePlaza(this Graphics gfx, TerrainLayer g, int topX, int topY, ushort px, ushort py, int scale, byte transparency)
    {
        g.GetBuildingRelativeCoordinates(topX, topY, scale, px, py, out var x, out var y);

        var width = scale * PlazaWidth;
        var height = scale * PlazaHeight;

        var pen = Plaza;
        if (transparency != byte.MaxValue)
        {
            var orig = ((SolidBrush)pen).Color;
            pen = new SolidBrush(Color.FromArgb(transparency, orig));
        }
        gfx.FillRectangle(pen, x, y, width, height);
    }
}
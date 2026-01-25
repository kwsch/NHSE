using System;
using NHSE.Core;
using System.Collections.Generic;
using System.Drawing;

namespace NHSE.Sprites;

/// <summary>
/// Logic to build a viewport render of a subsection of a map (or the entire "map", assuming it is small enough).
/// </summary>
public static class TerrainSprite
{
    private static readonly Brush Selected = Brushes.Red;
    private static readonly Brush Others = Brushes.Yellow;
    private static readonly Brush Text = Brushes.White;
    private static readonly Brush Tile = Brushes.Black;
    private static readonly Brush Plaza = Brushes.RosyBrown;
    private static readonly Color PlazaColor = Color.RosyBrown;
    private static readonly StringFormat BuildingTextFormat = new() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

    // 6x5 in a 16x16 acre scale. Since we are in 32x32 scale for items, our upscale is "double".
    // Tiles are always rendered as 16x16 squares, to match the precomputed tile appearance bitmaps.
    private const int TileScale = 16;
    private const int TilesPerViewport = 16;

    // To display in a 32x32 viewport from 16x16
    private const int Scale = 2;
    private const int PlazaWidth = 6 * Scale;
    private const int PlazaHeight = 5 * Scale;

    public static void GenerateMap(Bitmap map, MapMutator mut, Span<int> scale1, Span<int> scaleX, int imgScale, int acreIndex = -1)
    {
        // Load the terrain pixels, then upscale.
        var mgr = mut.Manager.LayerTerrain;
        LoadTerrainPixels(mgr, scale1);
        ImageUtil.ScalePixelImage(scale1, scaleX, map.Width, map.Height, imgScale);
        map.SetBitmapData(scaleX);

        if (acreIndex < 0)
          return;

        var acre = AcreCoordinate.Acres[acreIndex];
        var x = acre.X * mgr.TileInfo.ViewWidth;
        var y = acre.Y * mgr.TileInfo.ViewHeight;
        
        DrawReticle(map, mgr.TileInfo, x, y, imgScale);
    }

    public static Bitmap GetMapWithBuildings(Bitmap map, MapEditor m, Font? f,
        Span<int> scale1, Span<int> scaleX,
        int buildingIndex = -1)
    {
        GenerateMap(map, m.Mutator, scale1, scaleX, m.MapScale);
        using var gfx = Graphics.FromImage(map);

        var plaza = m.Mutator.Manager.Plaza;
        gfx.DrawPlaza(m, (ushort)plaza.X, (ushort)plaza.Z, m.MapScale);
        gfx.DrawBuildings(m, m.Buildings.Buildings, m.MapScale, f, buildingIndex);
        return map;
    }

    public static void LoadViewport(Bitmap img, MapEditor m, Font f,
        Span<int> scale1, Span<int> scaleX,
        int selectedBuildingIndex, byte transparencyBuilding, byte transTerrain)
    {
        // Convert from absolute to relative.
        var cfg = m.Mutator.Manager.ConfigTerrain;
        int absX = m.X / 2; // 32px => 16px basis
        int absY = m.Y / 2; // 32px => 16px basis
        var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);

        SetViewTerrainPixels(m.Terrain, cfg, relX, relY, scale1, scaleX, Scale);

        // Drawing building tiles currently uses the graphics API rather than writing pixels.
        img.SetBitmapData(scaleX);
        using var gfx = Graphics.FromImage(img);
        gfx.DrawViewPlaza(m, transparencyBuilding);
        gfx.DrawViewBuildings(m, selectedBuildingIndex, transparencyBuilding);

        // Return to pixel writing mode
        img.GetBitmapData(scaleX);

        // Apply Grid
        const int grid1 = unchecked((int)0xFF888888u); // lighter
        const int grid2 = unchecked((int)0xFF666666u); // darker
        ItemLayerSprite.DrawGrid(scaleX, img.Width, img.Height, grid1, m.ViewScale); // minor
        ItemLayerSprite.DrawGrid(scaleX, img.Width, img.Height, grid2, m.ViewScale * 2); // major

        // Switch back to graphics mode
        img.SetBitmapData(scaleX);
        // Draw Text of Building Names
        foreach (var b in m.Buildings.Buildings)
        {
            var (x, y) = m.GetViewCoordinatesBuilding(b.X, b.Y);
            const int cellsAbove = 2; // Show label above the building, 2 cells up.
            y -= (m.ViewScale * cellsAbove);

            // Don't bother drawing if not in view.
            if (!m.Mutator.View.IsWithinView(m.ViewScale, x, y))
                continue;

            var type = b.BuildingType;
            var name = type.ToString();
            var labelPosition = new PointF(x, y - (m.ViewScale * 2));
            gfx.DrawString(name, f, Text, labelPosition, BuildingTextFormat);
        }

        // Draw Text of Terrain Tile Names
        if (transTerrain != 0)
            DrawViewTerrainTileNames(gfx, m.Terrain, cfg, f, absX, absY, m.ViewScale, transTerrain);

        // Done.
    }

    private static void DrawViewBuildings(this Graphics gfx, MapEditor m, int selectedBuildingIndex, byte transBuild)
    {
        var buildings = m.Buildings.Buildings;
        for (var i = 0; i < buildings.Count; i++)
        {
            var b = buildings[i];
            var pen = selectedBuildingIndex == i ? Selected : Others;
            if (transBuild != byte.MaxValue)
            {
                var orig = ((SolidBrush)pen).Color;
                pen = new SolidBrush(Color.FromArgb(transBuild, orig));
            }
            gfx.DrawBuilding(b, m, pen, m.ViewScale, Text);
        }
    }

    private static void LoadTerrainPixels(LayerTerrain mgr, Span<int> pixels)
    {
        // Populate the image, with each pixel being a single tile.
        var width = mgr.TileInfo.TotalWidth;
        var height = mgr.TileInfo.TotalHeight;
        var i = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++, i++)
                pixels[i] = mgr.GetTileColor(x, y, x, y);
        }
    }

    private static void DrawReticle(Bitmap map, TileGridViewport mgr, int x, int y, int scale)
    {
        using var gfx = Graphics.FromImage(map);
        using var pen = new Pen(Color.Red);

        int w = mgr.ViewWidth * scale;
        int h = mgr.ViewHeight * scale;
        gfx.DrawRectangle(pen, x * scale, y * scale, w, h);
    }

    private static void DrawPlaza(this Graphics gfx, MapEditor map, ushort px, ushort py, int scale)
    {
        var (x, y) = map.GetViewCoordinatesBuilding(px, py);

        int width = scale * PlazaWidth;
        int height = scale * PlazaHeight;

        gfx.FillRectangle(Plaza, x, y, width, height);
    }

    private static void DrawBuildings(this Graphics gfx, MapEditor map, IReadOnlyList<Building> buildings, int imgScale, Font? textFont = null, int selectedBuildingIndex = -1)
    {
        for (int i = 0; i < buildings.Count; i++)
        {
            var b = buildings[i];
            if (b.BuildingType == 0)
                continue;

            var pen = selectedBuildingIndex == i ? Selected : Others;
            gfx.DrawBuilding(b, map, pen, imgScale, Text, textFont);
        }
    }

    private static void DrawBuilding(this Graphics gfx, Building b, MapEditor map, Brush bBrush, int imgScale, Brush textBrush, Font? textFont = null)
    {
        var (x, y) = map.GetViewCoordinatesBuilding(b.X, b.Y);
        var type = b.BuildingType;
        var (width, height) = type.GetDimensions();

        // Draw the building.
        x -= width / 2;
        y -= height / 2;
        gfx.FillRectangle(bBrush, x, y, width * imgScale, height * imgScale);

        if (textFont == null)
            return;

        // Draw the text label above it.
        const int cellsAbove = 2;
        var name = type.ToString();
        gfx.DrawString(name, textFont, textBrush, new PointF(x, y - (imgScale * cellsAbove)), BuildingTextFormat);
    }

    private static void SetViewTerrainPixels(LayerTerrain t, LayerPositionConfig cfg, int relX, int relY, Span<int> data, Span<int> scaleX, int imgScale)
    {
        GetViewTerrain1(t, cfg, relX, relY, data);
        ImageUtil.ScalePixelImage(data, scaleX, TilesPerViewport * imgScale, TilesPerViewport * imgScale, imgScale);
    }

    private static void GetViewTerrain1(LayerTerrain t, LayerPositionConfig cfg, int relX, int relY, Span<int> data)
    {
        int index = 0;
        for (int tileY = 0; tileY < TilesPerViewport; tileY++)
        {
            var actY = tileY + relY;
            for (int x = 0; x < TilesPerViewport; x++)
            {
                var actX = relX + x;
                if (!cfg.IsCoordinateValidRelative(actX, actY))
                    continue;

                var acreTemplate = t.GetAcreTemplate(actX, actY);
                for (int pixelY = 0; pixelY < TileScale; pixelY++)
                {
                    for (int pixelX = 0; pixelX < TileScale; pixelX++)
                    {
                        data[index] = t.GetTileColor(acreTemplate, actX, actY, pixelX, pixelY);
                        index++;
                    }
                }
            }
        }
    }

    private static void DrawViewTerrainTileNames(Graphics gfx, LayerTerrain t, LayerPositionConfig cfg, Font f,
        int relX, int relY, int scale, byte transparency)
    {
        var pen = Tile;
        if (transparency != byte.MaxValue)
            pen = new SolidBrush(Color.FromArgb(transparency, Color.Black));

        // iterate over every tile in the view
        for (int y = 0; y < TilesPerViewport; y++)
        {
            var actY = relY + y;
            var centerY = (y * scale) + (scale / 2);
            for (int x = 0; x < TilesPerViewport; x++)
            {
                var actX = relX + x;
                if (!cfg.IsCoordinateValidRelative(actX, actY))
                    continue;

                var tile = t.GetTile(actX, actY);
                var centerX = (x * scale) + (scale / 2);
                var name = TerrainTileColor.GetTileName(tile);
                gfx.DrawString(name, f, pen, centerX, centerY, BuildingTextFormat);
            }
        }
    }

    private static void DrawViewPlaza(this Graphics gfx, MapEditor m, byte transparency)
    {
        var plaza = m.Mutator.Manager.Plaza;
        var (x, y) = m.GetViewCoordinatesBuilding(plaza.X, plaza.Z);

        var scale = m.ViewScale;
        var width = scale * PlazaWidth;
        var height = scale * PlazaHeight;

        var pen = Plaza;
        if (transparency != byte.MaxValue)
            pen = new SolidBrush(Color.FromArgb(transparency, PlazaColor));
        gfx.FillRectangle(pen, x, y, width, height);
    }
}
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

    public const int ColorOcean = unchecked((int)0xFF80D7C3);
    private const int ColorGrid1 = unchecked((int)0xFF888888u); // lighter
    private const int ColorGrid2 = unchecked((int)0xFF666666u); // darker

    // 6x5 in a 16x16 acre scale. Since we are in 32x32 scale for items, our upscale is "double".
    // Tiles are always rendered as 16x16 squares, to match the precomputed tile appearance bitmaps.
    private const int TileScale = 16;
    private const int TilesPerViewport = 16;

    // To display in a 32x32 viewport from 16x16
    private const int Scale = 2;
    private const int PlazaWidth = 6 * Scale;
    private const int PlazaHeight = 5 * Scale;

    public static void GenerateMap(Bitmap map, MapMutator mut, Span<int> scale1, Span<int> scaleX, int imgScale)
    {
        // Load the terrain pixels, then upscale.
        var mgr = mut.Manager.LayerTerrain;
        LoadTerrainPixels(mgr, mut.Manager.ConfigTerrain, scale1);
        ImageUtil.ScalePixelImage(scale1, scaleX, map.Width, map.Height, imgScale);
        map.SetBitmapData(scaleX);
    }

    public static Bitmap GetMapWithBuildings(Bitmap map, MapEditor m, Span<int> scale1, Span<int> scaleX, int buildingIndex = -1)
    {
        var imgScale = m.MapScale * 2; // because terrain is 16px per tile, items are 32px per tile
        GenerateMap(map, m.Mutator, scale1, scaleX, imgScale);
        using var gfx = Graphics.FromImage(map);

        var plaza = m.Mutator.Manager.Plaza;
        gfx.DrawMapPlaza(m, (ushort)plaza.X, (ushort)plaza.Z, imgScale);
        gfx.DrawMapBuildings(m, m.Buildings.Buildings, imgScale, buildingIndex);
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
        ItemLayerSprite.DrawGrid(scaleX, img.Width, img.Height, ColorGrid1, m.ViewScale); // minor
        ItemLayerSprite.DrawGrid(scaleX, img.Width, img.Height, ColorGrid2, m.ViewScale * 2); // major

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
            DrawViewTerrainTileNames(gfx, m.Terrain, cfg, f, relX, relY, m.ViewScale * 2, transTerrain);

        // Done.
    }

    private static void DrawViewBuildings(this Graphics gfx, MapEditor m, int selectedBuildingIndex, byte transBuild)
    {
        var buildings = m.Buildings.Buildings;
        for (var i = 0; i < buildings.Count; i++)
        {
            var b = buildings[i];
            if (b.BuildingType == BuildingType.None)
                continue;
            var pen = selectedBuildingIndex == i ? Selected : Others;
            if (transBuild != byte.MaxValue)
            {
                var orig = ((SolidBrush)pen).Color;
                pen = new SolidBrush(Color.FromArgb(transBuild, orig));
            }
            gfx.DrawViewBuilding(m, b, pen, m.ViewScale, Text);
        }
    }

    private static void LoadTerrainPixels(LayerTerrain mgr, LayerPositionConfig cfg, Span<int> pixels)
    {
        var (shiftX, shiftY) = cfg.GetCoordinatesAbsolute(0, 0);

        // Iterate through the relative positions within the layer.
        // Then, map to absolute positions in the bitmap with the configured shift.
        var width = cfg.LayerTotalWidth;
        var height = cfg.LayerTotalHeight;
        var mapWidth = cfg.MapTotalWidth; // 1px scale

        // Populate the image, with each pixel being a single tile.
        // Only need to render the layer's width/height, as the rest is ocean/unable to be changed.
        for (int y = 0; y < height; y++)
        {
            var absY = y + shiftY;
            for (int x = 0; x < width; x++)
            {
                var absX = x + shiftX;
                var color = mgr.GetTileColor(x, y, 0, 0);
                var offset = (absY * mapWidth) + absX;
                pixels[offset] = color;
            }
        }
    }

    private static void DrawMapPlaza(this Graphics gfx, MapEditor map, ushort px, ushort py, int imgScale)
    {
        var (x, y) = (px, py);

        int width = imgScale * PlazaWidth;
        int height = imgScale * PlazaHeight;

        gfx.FillRectangle(Plaza, x, y, width, height);
    }

    private static void DrawMapBuildings(this Graphics gfx, MapEditor m, IReadOnlyList<Building> buildings, int imgScale, int selectedBuildingIndex = -1)
    {
        for (int i = 0; i < buildings.Count; i++)
        {
            var b = buildings[i];
            if (b.BuildingType == 0)
                continue;

            var (width, height) = b.BuildingType.GetDimensions();
            var pen = selectedBuildingIndex == i ? Selected : Others;
            gfx.FillRectangle(pen, b.X, b.Y, imgScale * width, imgScale * height);
        }
    }

    private static void DrawViewBuilding(this Graphics gfx, MapEditor m, Building b, Brush bBrush,
        int imgScale, Brush textBrush, Font? textFont = null)
    {
        var (x, y) = m.GetViewCoordinatesBuilding(b.X, b.Y);
        var type = b.BuildingType;
        var (width, height) = type.GetDimensions();
        x -= (width / 2) * m.ViewScale * 2;
        y -= (height / 2) * m.ViewScale * 2;

        // Draw the building.
        gfx.FillRectangle(bBrush, x, y, width * imgScale * 2, height * imgScale * 2);

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
        ImageUtil.ScalePixelImage(data, scaleX, TilesPerViewport * TileScale * imgScale, TilesPerViewport * TileScale * imgScale, imgScale);
    }

    private static void GetViewTerrain1(LayerTerrain t, LayerPositionConfig cfg, int relX, int relY, Span<int> data)
    {
        for (int tileY = 0; tileY < TilesPerViewport; tileY++)
        {
            var actY = tileY + relY;
            for (int x = 0; x < TilesPerViewport; x++)
            {
                var actX = relX + x;
                if (!cfg.IsCoordinateValidRelative(actX, actY))
                {
                    // Fill tile's square with a solid color.
                    for (int pixelY = 0; pixelY < TileScale; pixelY++)
                    {
                        var index = (tileY * TileScale + pixelY) * (TilesPerViewport * TileScale) + x * TileScale;
                        for (int pixelX = 0; pixelX < TileScale; pixelX++)
                        {
                            data[index] = ColorOcean;
                            index++;
                        }
                    }
                }
                else
                {
                    // Fill tile's square from terrain data.
                    var acreTemplate = t.GetAcreTemplate(actX, actY);
                    var tile = t.GetTile(actX, actY);
                    for (int pixelY = 0; pixelY < TileScale; pixelY++)
                    {
                        var index = (tileY * TileScale + pixelY) * (TilesPerViewport * TileScale) + x * TileScale;
                        for (int pixelX = 0; pixelX < TileScale; pixelX++)
                        {
                            data[index] = t.GetTileColor(acreTemplate, tile, actX, actY, pixelX, pixelY);
                            index++;
                        }
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

        var scale = m.ViewScale * 2;
        var width = scale * PlazaWidth;
        var height = scale * PlazaHeight;

        var pen = Plaza;
        if (transparency != byte.MaxValue)
            pen = new SolidBrush(Color.FromArgb(transparency, PlazaColor));
        gfx.FillRectangle(pen, x, y, width, height);
    }
}
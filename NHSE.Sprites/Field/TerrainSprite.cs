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
    private static readonly Brush Text = Brushes.Black;
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

    /// <summary>
    /// Generates a terrain map by loading, scaling, and applying terrain data to the specified bitmap.
    /// </summary>
    /// <param name="map">The bitmap to which the generated terrain map will be applied.</param>
    /// <param name="mut">The map information manager that provides access to terrain configuration and management.</param>
    /// <param name="scale1">A span of integers used as a buffer for the initial terrain pixel data.</param>
    /// <param name="scaleX">A span of integers used as a buffer for the upscaled terrain pixel data.</param>
    /// <param name="imgScale">The scaling factor to apply when upscaling the terrain image. Must be a positive integer.</param>
    private static void GenerateMapTerrainAndUpscale(Bitmap map, MapMutator mut, Span<int> scale1, Span<int> scaleX, int imgScale)
    {
        // Load the terrain pixels, then upscale.
        var mgr = mut.Manager.LayerTerrain;
        LoadTerrainPixels(mgr, mut.Manager.ConfigTerrain, scale1);
        ImageUtil.ScalePixelImage(scale1, scaleX, map.Width, map.Height, imgScale);
        map.SetBitmapData(scaleX);
    }

    /// <summary>
    /// Draws the map with all buildings and the plaza overlay onto the specified bitmap, using the provided map editor
    /// and scaling information.
    /// </summary>
    /// <remarks>
    /// The method modifies the provided bitmap in place.
    /// The scaling spans must be properly initialized to match the expected map dimensions.
    /// If a specific building index is provided, only that building may be highlighted or rendered differently;
    /// otherwise, all buildings are drawn normally.
    /// </remarks>
    /// <param name="map">The bitmap on which the map, buildings, and plaza will be rendered.</param>
    /// <param name="m">The map editor instance containing map data, building information, and scaling parameters.</param>
    /// <param name="scale1">A span representing the primary scaling factors for rendering the map.</param>
    /// <param name="scaleX">A span representing the secondary scaling factors for rendering the map.</param>
    /// <param name="buildingIndex">
    /// The index of a specific building to highlight or focus on.
    /// Set to -1 to render all buildings without highlighting any particular one.
    /// </param>
    /// <returns>The bitmap with the map, plaza, and buildings drawn onto it. The same instance as the input bitmap is returned.</returns>
    public static Bitmap GetMapWithBuildings(Bitmap map, MapEditor m, Span<int> scale1, Span<int> scaleX, int buildingIndex = -1)
    {
        var imgScale = m.MapScale * 2; // because terrain is 16px per tile, items are 32px per tile
        GenerateMapTerrainAndUpscale(map, m.Mutator, scale1, scaleX, imgScale);
        using var gfx = Graphics.FromImage(map);

        var plaza = m.Mutator.Manager.Plaza;
        gfx.DrawMapPlaza((ushort)plaza.X, (ushort)plaza.Z, imgScale);
        gfx.DrawMapBuildings(m.Buildings.Buildings, imgScale, buildingIndex);
        return map;
    }

    /// <summary>
    /// Renders the current map viewport onto the specified bitmap, including terrain, buildings, grid overlays, and labels.
    /// </summary>
    /// <remarks>
    /// This method draws both graphical and textual elements of the map viewport, including overlays and labels.
    /// It should be called whenever the viewport needs to be refreshed, such as after map edits or navigation.
    /// The method modifies the provided bitmap in place.
    /// </remarks>
    /// <param name="img">The bitmap onto which the viewport will be drawn.</param>
    /// <param name="m">The map editor instance providing map data, building information, and viewport configuration.</param>
    /// <param name="textFont">The font used to render building and terrain tile names within the viewport.</param>
    /// <param name="scale1">A span representing the primary scaling factors for rendering terrain pixels.</param>
    /// <param name="scaleX">A span used for horizontal scaling and pixel data manipulation during rendering.</param>
    /// <param name="selectedBuildingIndex">
    /// The index of the currently selected building.
    /// Used to highlight or annotate the selected building in the viewport.
    /// </param>
    /// <param name="transparencyBuilding">
    /// The transparency level to apply when rendering buildings.
    /// A value of 0xFF is fully opaque; lower values increase transparency.
    /// </param>
    /// <param name="transTerrain">
    /// The transparency level to apply when rendering terrain tile names.
    /// A value of 0xFF is fully opaque; lower values increase transparency.
    /// </param>
    public static void LoadViewport(Bitmap img, MapEditor m, Font textFont,
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

        // Draw Text of Terrain Tile Names
        if (transTerrain != 0)
            gfx.DrawViewTerrainTileNames(m.Terrain, cfg, textFont, relX, relY, m.ViewScale * 2, transTerrain);

        // Draw Text of Building Names
        if (transparencyBuilding != 0)
            gfx.DrawViewBuildingNames(m, textFont, transparencyBuilding);

        // Done.
    }

    private static void DrawViewBuildingNames(this Graphics gfx, MapEditor m, Font textFont, byte transparency)
    {
        var brush = Text;
        if (transparency != byte.MaxValue)
            brush = new SolidBrush(Color.FromArgb(transparency, Color.Black));

        foreach (var b in m.Buildings.Buildings)
        {
            var (x, y) = m.GetViewCoordinatesBuilding(b.X, b.Y);
            const int cellsAbove = -2; // Show label inside the building square, 2 cells inside.
            y -= (m.ViewScale * cellsAbove);

            var type = b.BuildingType;
            var name = type.ToString();
            var labelPosition = new PointF(x, y - (m.ViewScale * 2));
            gfx.DrawString(name, textFont, brush, labelPosition, BuildingTextFormat);
        }
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
            gfx.DrawViewBuilding(m, b, pen, m.ViewScale);
        }
    }

    private static void LoadTerrainPixels(LayerTerrain mgr, LayerPositionConfig cfg, Span<int> pixels)
    {
        var (shiftX, shiftY) = cfg.GetCoordinatesAbsolute();

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

        var mapHeight = cfg.MapTotalHeight;
        // Render each exterior acre, just in case it was changed from a sea acre.
        // If the acre (x,y) is a customizable terrain acre, skip it since we already did it above.
        for (int y = 0; y < mapHeight; y += TileScale)
        {
            for (int x = 0; x < mapWidth; x += TileScale)
            {
                var (relX, relY) = cfg.GetCoordinatesRelative(x, y);
                if (cfg.IsCoordinateValidRelative(relX, relY))
                    continue; // already done

                // Render the acre template (usually sea).
                var acreTemplate = mgr.GetAcreTemplate(relX, relY);
                for (int tileY = 0; tileY < TileScale; tileY++)
                {
                    for (int tileX = 0; tileX < TileScale; tileX++)
                    {
                        var color = AcreTileColor.GetAcreTileColor(acreTemplate, tileX, tileY);
                        if (color == -0x1000000) // transparent (dynamic)
                            color = Color.ForestGreen.ToArgb(); // just in case; it's invalid anyway.
                        var offset = ((y + tileY) * mapWidth) + (x + tileX);
                        pixels[offset] = color;
                    }
                }
            }
        }
    }

    private static void DrawMapPlaza(this Graphics gfx, ushort px, ushort py, int imgScale)
    {
        var (x, y) = (px, py);

        int width = imgScale * PlazaWidth;
        int height = imgScale * PlazaHeight;

        gfx.FillRectangle(Plaza, x, y, width, height);
    }

    private static void DrawMapBuildings(this Graphics gfx, IReadOnlyList<Building> buildings, int imgScale, int selectedBuildingIndex = -1)
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

    private static void DrawViewBuilding(this Graphics gfx, MapEditor m, Building b, Brush bBrush, int imgScale)
    {
        var (x, y) = m.GetViewCoordinatesBuilding(b.X, b.Y);
        var type = b.BuildingType;
        var (width, height) = type.GetDimensions();
        x -= (width / 2) * m.ViewScale * 2;
        y -= (height / 2) * m.ViewScale * 2;

        // Draw the building.
        gfx.FillRectangle(bBrush, x, y, width * imgScale * 2, height * imgScale * 2);
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
            for (int tileX = 0; tileX < TilesPerViewport; tileX++)
            {
                var actX = relX + tileX;
                if (!cfg.IsCoordinateValidRelative(actX, actY))
                {
                    // Fill tile's square with a solid color.
                    var acreTemplate = t.GetAcreTemplate(actX, actY);
                    for (int pixelY = 0; pixelY < TileScale; pixelY++)
                    {
                        var index = (tileY * TileScale + pixelY) * (TilesPerViewport * TileScale) + tileX * TileScale;
                        for (int pixelX = 0; pixelX < TileScale; pixelX++)
                        {
                            var color = AcreTileColor.GetAcreTileColor(acreTemplate, actX % 16, actY % 16);
                            if (color == -0x1000000) // transparent (dynamic)
                                color = Color.ForestGreen.ToArgb(); // just in case; it's invalid anyway.
                            data[index] = color;
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
                        var index = (tileY * TileScale + pixelY) * (TilesPerViewport * TileScale) + tileX * TileScale;
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

    private static void DrawViewTerrainTileNames(this Graphics gfx, LayerTerrain t, LayerPositionConfig cfg, Font f,
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
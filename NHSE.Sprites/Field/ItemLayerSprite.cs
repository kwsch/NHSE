using System;
using System.Drawing;
using NHSE.Core;

namespace NHSE.Sprites;

/// <summary>
/// Logic for rendering an <see cref="LayerItem"/>.
/// </summary>
public static class ItemLayerSprite
{
    private static readonly Pen Reticle = new(Color.Red);

    /// <summary>
    /// Populates a bitmap data buffer with color values derived from a collection of items, arranging the colors in column-major order based on the specified width and height.
    /// </summary>
    /// <remarks>
    /// Each item's color is determined using <see cref="FieldItemColor.GetItemColor"/> and stored in ARGB format.
    /// Colors are written to bmpData in column-major order, where each column is filled from top to bottom.
    /// </remarks>
    /// <param name="items">List of items from which color values are extracted. The span must contain at least width × height elements.</param>
    /// <param name="bmpData">Pixel data for the bitmap. The span must have a length of at least width × height.</param>
    /// <param name="cfg">Configuration for layer positioning.</param>
    private static void LoadBitmapLayer(ReadOnlySpan<Item> items, Span<int> bmpData, in LayerPositionConfig cfg)
    {
        var (shiftX, shiftY) = cfg.GetCoordinatesAbsolute();

        // Iterate through the relative positions within the layer.
        // Then, map to absolute positions in the bitmap with the configured shift.
        var width = cfg.LayerTotalWidth;
        var height = cfg.LayerTotalHeight;
        var mapWidth = cfg.MapTotalWidth; // 1px scale
        for (int relX = 0; relX < width; relX++)
        {
            var absX = relX + shiftX;
            for (int relY = 0; relY < height; relY++)
            {
                // Get the tile at this position.
                var tile = items[relY + relX * height];

                // Get the actual shifted position in the bitmap.
                var absY = relY + shiftY;
                var offset = (absY * mapWidth) + absX;

                // Write the color to the bitmap data.
                bmpData[offset] = FieldItemColor.GetItemColor(tile).ToArgb();
            }
        }
    }

    /// <summary>
    /// Loads an item layer into a bitmap, scaling it up to the desired size, drawing special symbols, and overlaying a grid.
    /// </summary>
    /// <param name="imgScaled">Inflated acre bitmap to write to.</param>
    /// <param name="layer">Item layer to draw from.</param>
    /// <param name="cfg">Configuration for layer positioning.</param>
    /// <param name="absX">Top-left X coordinate to start drawing from, relative to the origin of the map.</param>
    /// <param name="absY">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgSingle">Pixel data for 1px per tile image.</param>
    /// <param name="imgUpscaled">>Pixel data for final inflated image.</param>
    /// <param name="imgScale">Scaling factor from 1px => final image dimensions.</param>
    /// <param name="transparency">Optional transparency override color.</param>
    /// <param name="gridlineColor">Color to use for gridlines.</param>
    public static void LoadViewport(Bitmap imgScaled, LayerItem layer, in LayerPositionConfig cfg, int absX, int absY,
        Span<int> imgSingle, Span<int> imgUpscaled, int imgScale, int transparency = -1, int gridlineColor = 0)
    {
        // Update the 1px view-grid image pixel data.
        LoadViewport(layer, cfg, imgSingle, absX, absY);

        // Get the final inflated size of the image.
        var imgWidth = imgScaled.Width;
        var imgHeight = imgScaled.Height;
        // Inflate to the final size storage.
        ImageUtil.ScalePixelImage(imgSingle, imgUpscaled, imgWidth, imgHeight, imgScale);

        // Draw symbols over special items now?
        DrawDirectionals(layer, cfg, imgUpscaled, absX, absY, imgWidth, imgScale);

        // Optional transparency clamping to make image fainter.
        if (transparency >>> 24 != 0xFF)
            ImageUtil.ClampAllTransparencyTo(imgUpscaled, transparency);

        // Apply gridlines to visually separate each cell.
        DrawGrid(imgUpscaled, imgWidth, imgHeight, gridlineColor, imgScale);

        // Update the bitmap, final data.
        imgScaled.SetBitmapData(imgUpscaled);
    }

    /// <summary>
    /// Loads pixel data from the specified layer into the provided span, using the given starting coordinates and the layer's view dimensions.
    /// </summary>
    /// <param name="layer">The layer from which to load pixel data.</param>
    /// <param name="cfg">Configuration for layer positioning.</param>
    /// <param name="data">Pixel data of the final image.</param>
    /// <param name="absX">The x-coordinate of the upper-left corner in the map from which to start loading pixels.</param>
    /// <param name="absY">The y-coordinate of the upper-left corner in the map from which to start loading pixels.</param>
    private static void LoadViewport(LayerItem layer, in LayerPositionConfig cfg, Span<int> data, int absX, int absY)
    {
        var width = layer.TileInfo.ViewWidth;
        var height = layer.TileInfo.ViewHeight;

        var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);

        for (int y = 0; y < height; y++)
        {
            var baseIndex = (y * width);
            var tileY = relY + y;
            for (int x = 0; x < width; x++)
            {
                var tileX = relX + x;
                if (!cfg.IsCoordinateValidRelative(tileX, tileY))
                    continue;
                var tile = layer.GetTile(tileX, tileY);
                var color = FieldItemColor.GetItemColor(tile).ToArgb();

                var index = baseIndex + x;
                data[index] = color;
            }
        }
    }

    /// <summary>
    /// Draws extension tile info for the tiles in the specified layer onto the provided pixel data.
    /// </summary>
    /// <param name="layer">The layer containing the tiles to process.</param>
    /// <param name="cfg">Configuration for layer positioning.</param>
    /// <param name="data">Pixel data of the entire image.</param>
    /// <param name="absX">Top-left X coordinate to start drawing from, relative to the origin of the map.</param>
    /// <param name="absY">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    /// <param name="imgScale">Scaling factor from 1px => final image dimensions.</param>
    private static void DrawDirectionals(LayerItem layer, in LayerPositionConfig cfg,
        Span<int> data,
        int absX, int absY, int imgWidth, int imgScale)
    {
        var width = cfg.TilesPerAcre;
        var height = cfg.TilesPerAcre;

        var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);

        for (int viewX = 0; viewX < width; viewX++)
        {
            for (int viewY = 0; viewY < height; viewY++)
            {
                var pX = relX + viewX;
                var pY = relY + viewY;
                if (!cfg.IsCoordinateValidRelative(pX, pY))
                    continue;
                var tile = layer.GetTile(pX, pY);
                if (tile.IsNone)
                    continue;

                // Apply cosmetic details based on the tile's details.
                if (tile.IsBuried)
                    DrawX(data, viewX * imgScale, viewY * imgScale, imgScale, imgWidth);
                else if (tile.IsDropped)
                    DrawPlus(data, viewX * imgScale, viewY * imgScale, imgScale, imgWidth);
                else if (tile.IsExtension)
                    DrawDirectional(data, tile, viewX * imgScale, viewY * imgScale, imgScale, imgWidth);

                // Based on the display item, apply details.
                var id = tile.DisplayItemId;
                var kind = ItemInfo.GetItemKind(id);
                if (kind.IsFlowerGene(id))
                {
                    var geneIndex = GetGeneIndex(ref tile, layer, pX, pY);
                    var genes = ((uint)tile.Genes ^ 0b00_11_00_00); // invert W bits
                    var geneValue = (genes >> (geneIndex * 2)) & 3;
                    if (geneValue == 0)
                        continue;
                    DrawGene(data, viewX * imgScale, viewY * imgScale, imgScale, imgWidth, geneValue, geneIndex);
                }
            }
        }
    }

    /// <summary>
    /// Gets the index of the gene based on the specified extension value. Repoints the tile to root node if it is an extension tile.
    /// </summary>
    private static int GetGeneIndex(ref Item tile, LayerItem layer, int relX, int relY)
    {
        if (tile.IsRoot)
            return 0;

        // Sanity check: can only extend by 1 in either direction, and must extend in same direction as relative position.
        // Ignore bad extension values; we know the gene index from position alone.
        var eX = relX & 1;
        var eY = relY & 1;
        var geneIndex = (eY << 1) | eX;
        tile = layer.GetTile(relX - eX, relY - eY);
        return geneIndex;
    }

    /// <summary>
    /// Draws a flower gene on the item cell.
    /// </summary>
    /// <param name="data">Pixel data of the entire image.</param>
    /// <param name="viewX">Top-left X coordinate to start drawing from.</param>
    /// <param name="viewY">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgScale">Scale of the entire cell.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    /// <param name="geneValue">Value of the gene (0-3).</param>
    /// <param name="geneIndex">0-3 value indicating which gene (quadrant) to draw.</param>
    private static void DrawGene(Span<int> data, int viewX, int viewY, int imgScale, int imgWidth, uint geneValue, int geneIndex)
    {
        var c = ShiftToGeneCoordinate(ref viewX, ref viewY, imgScale, geneIndex);
        FillSquare(data, viewX, viewY, imgScale / 2, imgWidth, c, geneValue == 3 ? 1 : 2);
    }

    /// <summary>
    /// Fills a square region within a one-dimensional span with the specified color value, using a given increment to control the fill step.
    /// </summary>
    /// <remarks>This method assumes that the specified region fits within the bounds of the provided span.
    /// No bounds checking is performed.
    /// The increment parameter can be used to fill a subset with the square's elements, which may be useful for performance or pattern effects.
    /// </remarks>
    /// <param name="data">The span representing the target buffer to fill. Each element corresponds to a pixel or cell in a row-major order grid.</param>
    /// <param name="viewX">Top-left X coordinate to start drawing from.</param>
    /// <param name="viewY">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgScale">Scale of the entire cell.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    /// <param name="color">The color value to assign to each filled element in the square region.</param>
    /// <param name="increment">The step size to use when filling elements. Must be positive. A larger increment skips more elements within the square.</param>
    private static void FillSquare(Span<int> data, int viewX, int viewY, int imgScale, int imgWidth, int color, int increment)
    {
        var baseIndex = (viewY * imgWidth) + viewX;
        for (int i = 0; i < imgScale * imgScale; i += increment)
        {
            var x = i % imgScale;
            var y = i / imgScale;
            var index = (y * imgWidth) + x;
            data[baseIndex + index] = color;
        }
    }

    /// <summary>
    /// Adjusts the specified coordinates to the center of a gene region based on the given gene index and scale, and returns the corresponding ARGB color value for that region.
    /// </summary>
    /// <remarks>
    /// The method modifies the input coordinates in place according to the specified gene region.
    /// The returned color value corresponds to the region: Red for bottom right, Yellow for bottom left, AntiqueWhite  for top right, and Black for top left or any other index.
    /// </remarks>
    /// <param name="absX">Top-left X coordinate to start drawing from.</param>
    /// <param name="absY">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgScale">Scale of the entire cell.</param>
    /// <param name="geneIndex">The index of the gene region to shift to. Valid values are 0 (bottom right), 1 (bottom left), 2 (top right), and any other value for top left.</param>
    /// <returns>An integer representing the ARGB color value associated with the specified gene region.</returns>
    private static int ShiftToGeneCoordinate(ref int absX, ref int absY, int imgScale, int geneIndex)
    {
        switch (geneIndex)
        {
            case 0: // bottom right
                absX += imgScale / 2;
                absY += imgScale / 2;
                return Color.Red.ToArgb();
            case 1: // bottom left
                absY += imgScale / 2;
                return Color.Yellow.ToArgb();
            case 2: // top right
                absX += imgScale / 2;
                return Color.AntiqueWhite.ToArgb();
            default: // top left
                return Color.Black.ToArgb();
        }
    }

    /// <summary>
    /// Updates the pixel data to draw a `+`, indicating the item as "dropped".
    /// </summary>
    /// <param name="data">Pixel data of the entire image.</param>
    /// <param name="viewX">Top-left X coordinate to start drawing from.</param>
    /// <param name="viewY">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgScale">Scaling factor from 1px => final image dimensions.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    private static void DrawPlus(Span<int> data, int viewX, int viewY, int imgScale, int imgWidth)
    {
        var x0y0 = (imgWidth * viewY) + viewX;
        var s2 = imgScale / 2;
        var ws2 = imgWidth * s2;

        var v0 = x0y0 + s2;
        var h0 = x0y0 + ws2;

        for (int x = imgScale / 4; x <= 3 * (imgScale / 4); x++)
        {
            var vert = v0 + (imgWidth * x);
            data[vert] ^= 0x808080;
            var hori = h0 + x;
            data[hori] ^= 0x808080;
        }
    }

    /// <summary>
    /// Updates the pixel data to draw an `X`, indicating the item as "buried".
    /// </summary>
    /// <param name="data">Pixel data of the entire image.</param>
    /// <param name="viewX">Top-left X coordinate to start drawing from.</param>
    /// <param name="viewY">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgScale">Scaling factor from 1px => final image dimensions.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    private static void DrawX(Span<int> data, int viewX, int viewY, int imgScale, int imgWidth)
    {
        var opposite = imgScale - 1;
        var wo = imgWidth * opposite;

        // Starting offsets for each of the slashes
        var bBackward = (imgWidth * viewY) + viewX; // Backwards \
        var bForward = bBackward + wo; //  Forwards /

        for (int x = 0; x < imgScale; x++)
        {
            var wx = imgWidth * x;
            var backward = bBackward + x + wx;
            data[backward] ^= 0x808080;
            var forward = bForward + x - wx;
            data[forward] ^= 0x808080;
        }
    }

    /// <summary>
    /// Updates the pixel data to draw a directional, indicating the item as an extension of a root item node.
    /// </summary>
    /// <param name="data">Pixel data of the entire image.</param>
    /// <param name="tile">Extension tile data.</param>
    /// <param name="viewX">Top-left X coordinate to start drawing from.</param>
    /// <param name="viewY">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgScale">Scaling factor from 1px => final image dimensions.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    private static void DrawDirectional(Span<int> data, Item tile, int viewX, int viewY, int imgScale, int imgWidth)
    {
        var eX = tile.ExtensionX;
        var eY = tile.ExtensionY;
        if (eX == 0 && eY == 0)
            return;
        var sum = eX + eY;
        var start = imgScale / (sum + 1);
        var startX = eX >= eY ? 0 : start;
        var startY = eX <= eY ? 0 : start;

        var baseIndex = (imgWidth * viewY) + viewX;
        for (int x = startX, y = startY; x < imgScale && y < imgScale; x += eX, y += eY)
        {
            var index = baseIndex + (imgWidth * y) + x;
            if (index >= data.Length) // Since we can't guarantee valid extension values, just skip bad ones.
                continue;
            data[index] ^= 0x00_808080;
        }
    }

    /// <summary>
    /// Draws gridlines on the provided pixel data at the specified scale.
    /// </summary>
    /// <param name="data">Pixel data of the entire image.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    /// <param name="imgHeight">Height of the entire image.</param>
    /// <param name="gridlineColor">Color to use for gridlines.</param>
    /// <param name="gridlineInterval">Pixel interval to draw gridlines.</param>
    public static void DrawGrid(Span<int> data, int imgWidth, int imgHeight, int gridlineColor, int gridlineInterval)
    {
        // Horizontal Lines
        for (int y = gridlineInterval; y < imgHeight; y += gridlineInterval)
        {
            var baseIndex = y * imgWidth;
            for (int x = 0; x < imgWidth; x++)
            {
                var index = baseIndex + x;
                data[index] = gridlineColor;
            }
        }

        // Vertical Lines
        for (int y = 0; y < imgHeight; y++)
        {
            var baseIndex = y * imgWidth;
            for (int x = gridlineInterval; x < imgWidth; x += gridlineInterval)
            {
                var index = baseIndex + x;
                data[index] = gridlineColor;
            }
        }
    }

    /// <summary>
    /// Loads an item layer into a viewport bitmap.
    /// </summary>
    /// <param name="cfg">Configuration for layer positioning.</param>
    /// <param name="layer">Item layer to draw from.</param>
    /// <param name="data">Pixel data of the final image.</param>
    /// <param name="transparency">Optional transparency override color.</param>
    public static void LoadItemLayer1(LayerPositionConfig cfg, LayerItem layer, Span<int> data, int transparency = -1)
    {
        LoadBitmapLayer(layer.Tiles, data, cfg);
        if (transparency >>> 24 != 0xFF)
            ImageUtil.ClampAllTransparencyTo(data, transparency);
    }

    /// <summary>
    /// Draws a square reticle on the specified map image to indicate the current viewport area.
    /// </summary>
    /// <param name="map">The bitmap image on which to draw the reticle.</param>
    /// <param name="g">The viewport describing the area of the map present within the viewport.</param>
    /// <param name="absX">The absolute X-coordinate, in tile units, of the top-left corner of the viewport.</param>
    /// <param name="absY">The absolute Y-coordinate, in tile units, of the top-left corner of the viewport.</param>
    /// <param name="scale">The image upscale scale factor to apply to the reticle's size and position. Must be a positive integer. The default is 1.</param>
    public static void DrawViewReticle(Bitmap map, TileGridViewport g, int absX, int absY, int scale = 1)
    {
        using var gfx = Graphics.FromImage(map);
        var reticleWidth = g.ViewWidth * scale;
        var reticleHeight = g.ViewHeight * scale;
        gfx.DrawRectangle(Reticle, absX * scale, absY * scale, reticleWidth, reticleHeight);
    }
}
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
    /// Generates a bitmap representation of the provided item layer at a 1px-per-tile scale.
    /// </summary>
    /// <param name="layer">Item layer to render.</param>
    public static Bitmap GetBitmapItemLayer(LayerItem layer)
    {
        var items = layer.Tiles;
        var imgHeight = layer.TileInfo.TotalHeight;
        var imgWidth = items.Length / imgHeight;

        var bmpData = new int[imgWidth * imgHeight];
        LoadBitmapLayer(items, bmpData, imgWidth, imgHeight);

        return ImageUtil.GetBitmap(bmpData, imgWidth, imgHeight);
    }

    /// <summary>
    /// Populates a bitmap data buffer with color values derived from a collection of items, arranging the colors in column-major order based on the specified width and height.
    /// </summary>
    /// <remarks>
    /// Each item's color is determined using FieldItemColor.GetItemColor and stored in ARGB format.
    /// Colors are written to bmpData in column-major order, where each column is filled from top to bottom.
    /// </remarks>
    /// <param name="items">List of items from which color values are extracted. The span must contain at least width × height elements.</param>
    /// <param name="bmpData">Pixel data for the bitmap. The span must have a length of at least width × height.</param>
    /// <param name="imgWidth">The number of columns in the bitmap. Must be greater than zero.</param>
    /// <param name="imgHeight">The number of rows in the bitmap. Must be greater than zero.</param>
    private static void LoadBitmapLayer(ReadOnlySpan<Item> items, Span<int> bmpData, int imgWidth, int imgHeight)
    {
        for (int x = 0; x < imgWidth; x++)
        {
            var ix = x * imgHeight;
            for (int y = 0; y < imgHeight; y++)
            {
                var index = ix + y;
                var tile = items[index];
                bmpData[(y * imgWidth) + x] = FieldItemColor.GetItemColor(tile).ToArgb();
            }
        }
    }

    /// <summary>
    /// Loads an item layer into a bitmap, scaling it up to the desired size, drawing special symbols, and overlaying a grid.
    /// </summary>
    /// <param name="img">Inflated acre bitmap to write to.</param>
    /// <param name="layer">Item layer to draw from.</param>
    /// <param name="relX">Top-left X coordinate to start drawing from, relative to the origin of the layer (not map coordinates).</param>
    /// <param name="relY">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgSingle">Pixel data for 1px per tile image.</param>
    /// <param name="imgUpscaled">>Pixel data for final inflated image.</param>
    /// <param name="imgScale">Scaling factor from 1px => final image dimensions.</param>
    /// <param name="transparency">Optional transparency override color.</param>
    /// <param name="gridlineColor">Color to use for gridlines.</param>
    public static void LoadItemLayerViewGrid(Bitmap img, LayerItem layer, int relX, int relY,
        Span<int> imgSingle, Span<int> imgUpscaled, int imgScale, int transparency = -1, int gridlineColor = 0)
    {
        // Update the 1px view-grid image pixel data.
        LoadViewport(imgSingle, layer, relX, relY);

        // Get the final inflated size of the image.
        int imgWidth = layer.TileInfo.ViewWidth;
        int h = layer.TileInfo.ViewHeight;
        imgWidth *= imgScale;
        h *= imgScale;
        // Inflate to the final size storage.
        ImageUtil.ScalePixelImage(imgSingle, imgUpscaled, imgWidth, h, imgScale);

        // Optional transparency clamping to make image fainter.
        if (transparency >>> 24 != 0xFF)
            ImageUtil.ClampAllTransparencyTo(imgUpscaled, transparency);

        // Draw symbols over special items now?
        DrawDirectionals(imgUpscaled, layer, relX, relY, imgWidth, imgScale);

        // Apply gridlines to visually separate each cell.
        DrawGrid(imgUpscaled, imgWidth, h, gridlineColor, imgScale);

        // Update the bitmap, final data.
        img.SetBitmapData(imgUpscaled);
    }

    /// <summary>
    /// Loads pixel data from the specified layer into the provided span, using the given starting coordinates and the layer's view dimensions.
    /// </summary>
    /// <param name="data">Pixel data of the final image.</param>
    /// <param name="layer">The layer from which to load pixel data.</param>
    /// <param name="relX">The x-coordinate of the upper-left corner in the layer from which to start loading pixels.</param>
    /// <param name="relY">The y-coordinate of the upper-left corner in the layer from which to start loading pixels.</param>
    private static void LoadViewport(Span<int> data, LayerItem layer, int relX, int relY)
    {
        var width = layer.TileInfo.ViewWidth;
        var height = layer.TileInfo.ViewHeight;

        for (int y = 0; y < height; y++)
        {
            var baseIndex = (y * width);
            for (int x = 0; x < width; x++)
            {
                var tile = layer.GetTile(relX + x, relY + y);
                var color = FieldItemColor.GetItemColor(tile).ToArgb();
                var index = baseIndex + x;
                data[index] = color;
            }
        }
    }

    /// <summary>
    /// Draws extension tile info for the tiles in the specified layer onto the provided pixel data.
    /// </summary>
    /// <param name="data">Pixel data of the entire image.</param>
    /// <param name="layer">The layer containing the tiles to process.</param>
    /// <param name="relX">Top-left X coordinate to start drawing from, relative to the origin of the layer (not map coordinates).</param>
    /// <param name="relY">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    /// <param name="imgScale">Scaling factor from 1px => final image dimensions.</param>
    private static void DrawDirectionals(Span<int> data, LayerItem layer, int relX, int relY, int imgWidth, int imgScale)
    {
        var width = layer.TileInfo.ViewWidth;
        var height = layer.TileInfo.ViewHeight;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var pX = relX + x;
                var pY = relY + y;
                var tile = layer.GetTile(pX, pY);
                if (tile.IsNone)
                    continue;

                // Apply cosmetic details based on the tile's details.
                if (tile.IsBuried)
                    DrawX(data, relX * imgScale, relY * imgScale, imgScale, imgWidth);
                else if (tile.IsDropped)
                    DrawPlus(data, relX * imgScale, relY * imgScale, imgScale, imgWidth);
                else if (tile.IsExtension)
                    DrawDirectional(data, tile, relX * imgScale, relY * imgScale, imgScale, imgWidth);

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
                    DrawGene(data, relX * imgScale, relY * imgScale, imgScale, imgWidth, geneValue, geneIndex);
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
        var geneIndex = (tile.ExtensionY << 1) | tile.ExtensionX;
        tile = layer.GetTile(relX - tile.ExtensionX, relY - tile.ExtensionY);
        return geneIndex;
    }

    /// <summary>
    /// Draws a flower gene on the item cell.
    /// </summary>
    /// <param name="data">Pixel data of the entire image.</param>
    /// <param name="x0">Top-left X coordinate to start drawing from.</param>
    /// <param name="y0">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgScale">Scale of the entire cell.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    /// <param name="geneValue">Value of the gene (0-3).</param>
    /// <param name="geneIndex">0-3 value indicating which gene (quadrant) to draw.</param>
    private static void DrawGene(Span<int> data, int x0, int y0, int imgScale, int imgWidth, uint geneValue, int geneIndex)
    {
        var c = ShiftToGeneCoordinate(ref x0, ref y0, imgScale, geneIndex);
        FillSquare(data, x0, y0, imgScale / 2, imgWidth, c, geneValue == 3 ? 1 : 2);
    }

    /// <summary>
    /// Fills a square region within a one-dimensional span with the specified color value, using a given increment to  control the fill step.
    /// </summary>
    /// <remarks>This method assumes that the specified region fits within the bounds of the provided span.
    /// No bounds checking is performed.
    /// The increment parameter can be used to fill a subset with the square's elements, which may be useful for performance or pattern effects.
    /// </remarks>
    /// <param name="data">The span representing the target buffer to fill. Each element corresponds to a pixel or cell in a row-major order grid.</param>
    /// <param name="x0">Top-left X coordinate to start drawing from.</param>
    /// <param name="y0">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgScale">Scale of the entire cell.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    /// <param name="color">The color value to assign to each filled element in the square region.</param>
    /// <param name="increment">The step size to use when filling elements. Must be positive. A larger increment skips more elements within the square.</param>
    private static void FillSquare(Span<int> data, int x0, int y0, int imgScale, int imgWidth, int color, int increment)
    {
        var baseIndex = (y0 * imgWidth) + x0;
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
    /// <param name="x0">Top-left X coordinate to start drawing from.</param>
    /// <param name="y0">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgScale">Scale of the entire cell.</param>
    /// <param name="geneIndex">The index of the gene region to shift to. Valid values are 0 (bottom right), 1 (bottom left), 2 (top right), and any other value for top left.</param>
    /// <returns>An integer representing the ARGB color value associated with the specified gene region.</returns>
    private static int ShiftToGeneCoordinate(ref int x0, ref int y0, int imgScale, int geneIndex)
    {
        switch (geneIndex)
        {
            case 0: // bottom right
                x0 += imgScale / 2;
                y0 += imgScale / 2;
                return Color.Red.ToArgb();
            case 1: // bottom left
                y0 += imgScale / 2;
                return Color.Yellow.ToArgb();
            case 2: // top right
                x0 += imgScale / 2;
                return Color.AntiqueWhite.ToArgb();
            default: // top left
                return Color.Black.ToArgb();
        }
    }

    /// <summary>
    /// Updates the pixel data to draw a `+`, indicating the item as "dropped".
    /// </summary>
    /// <param name="data">Pixel data of the entire image.</param>
    /// <param name="x0">Top-left X coordinate to start drawing from.</param>
    /// <param name="y0">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgScale">Scaling factor from 1px => final image dimensions.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    private static void DrawPlus(Span<int> data, int x0, int y0, int imgScale, int imgWidth)
    {
        var x0y0 = (imgWidth * y0) + x0;
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
    /// <param name="x0">Top-left X coordinate to start drawing from.</param>
    /// <param name="y0">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgScale">Scaling factor from 1px => final image dimensions.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    private static void DrawX(Span<int> data, int x0, int y0, int imgScale, int imgWidth)
    {
        var opposite = imgScale - 1;
        var wo = imgWidth * opposite;

        // Starting offsets for each of the slashes
        var bBackward = (imgWidth * y0) + x0; // Backwards \
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
    /// <param name="x0">Top-left X coordinate to start drawing from.</param>
    /// <param name="y0">Top-left Y coordinate to start drawing from.</param>
    /// <param name="imgScale">Scaling factor from 1px => final image dimensions.</param>
    /// <param name="imgWidth">Width of the entire image.</param>
    private static void DrawDirectional(Span<int> data, Item tile, int x0, int y0, int imgScale, int imgWidth)
    {
        var eX = tile.ExtensionX;
        var eY = tile.ExtensionY;
        if (eX == 0 && eY == 0)
            return;
        var sum = eX + eY;
        var start = imgScale / (sum + 1);
        var startX = eX >= eY ? 0 : start;
        var startY = eX <= eY ? 0 : start;

        var baseIndex = (imgWidth * y0) + x0;
        for (int x = startX, y = startY; x < imgScale && y < imgScale; x += eX, y += eY)
        {
            var index = baseIndex + (imgWidth * y) + x;
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

    public static Bitmap GetBitmapItemLayer(Bitmap dest, LayerItem layer, int topX, int topY, Span<int> data, int transparency = -1)
    {
        LoadBitmapLayer(layer.Tiles, data, layer.TileInfo.TotalWidth, layer.TileInfo.TotalHeight);
        if (transparency >>> 24 != 0xFF)
            ImageUtil.ClampAllTransparencyTo(data, transparency);
        dest.SetBitmapData(data);
        return DrawViewReticle(dest, layer.TileInfo, topX, topY);
    }

    private static Bitmap DrawViewReticle(Bitmap map, TileGridViewport g, int topX, int topY, int scale = 1)
    {
        using var gfx = Graphics.FromImage(map);
        gfx.DrawViewReticle(g, topX, topY, scale);
        return map;
    }

    private static void DrawViewReticle(this Graphics gfx, TileGridViewport g, int topX, int topY, int scale)
    {
        int w = g.ViewWidth * scale;
        int h = g.ViewHeight * scale;
        gfx.DrawRectangle(Reticle, topX * scale, topY * scale, w, h);
    }
}
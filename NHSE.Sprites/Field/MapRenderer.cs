using System;
using System.Drawing;
using NHSE.Core;

namespace NHSE.Sprites;

/// <summary>
/// Produces bitmaps for viewing map acres and full maps.
/// </summary>
public sealed class MapRenderer : IDisposable
{
    private readonly MapEditor Map;
    private int MapScale => Map.MapScale;
    private int ViewScale => Map.ViewScale;

    private const byte FieldItemWidthOld = 7;
    private const byte FieldItemWidthNew = 9;

    // Cached acre view objects to remove allocation/GC
    private readonly int[] PixelsItemAcre1;
    private readonly int[] PixelsItemAcreX;
    private readonly Bitmap ScaleAcre;
    private readonly int[] PixelsItemMap;
    private readonly Bitmap MapReticle;

    private readonly int[] PixelsBackgroundAcre1;
    private readonly int[] PixelsBackgroundAcreX;
    private readonly Bitmap BackgroundAcre;

    private readonly int[] PixelsBackgroundMap1;
    private readonly int[] PixelsBackgroundMapX;
    private readonly Bitmap BackgroundMap;

    public MapRenderer(MapEditor m)
    {
        Map = m;

        var l1 = m.Mutator.Manager.FieldItems.Layer0;
        var info = l1.TileInfo;
        PixelsItemAcre1 = new int[info.ViewWidth * info.ViewHeight];
        PixelsItemAcreX = new int[PixelsItemAcre1.Length * ViewScale * ViewScale];
        ScaleAcre = new Bitmap(info.ViewWidth * ViewScale, info.ViewHeight * ViewScale);

        PixelsItemMap = new int[info.TotalWidth * info.TotalHeight * MapScale * MapScale];
        MapReticle = new Bitmap(info.TotalWidth * MapScale, info.TotalHeight * MapScale);

        PixelsBackgroundAcre1 = new int[PixelsItemAcre1.Length];
        PixelsBackgroundAcreX = new int[PixelsItemAcreX.Length];
        BackgroundAcre = new Bitmap(ScaleAcre.Width, ScaleAcre.Height);

        PixelsBackgroundMap1 = new int[PixelsItemMap.Length / (MapScale * MapScale)];
        PixelsBackgroundMapX = new int[PixelsItemMap.Length];
        BackgroundMap = new Bitmap(MapReticle.Width, MapReticle.Height);
    }

    public void Dispose()
    {
        ScaleAcre.Dispose();
        MapReticle.Dispose();
        BackgroundAcre.Dispose();
        BackgroundMap.Dispose();
    }

    public Bitmap GetLayerAcre(int t) => GetLayerAcre(Map.Mutator.View.X, Map.Mutator.View.Y, t);
    public Bitmap GetMapWithReticle(int t) => GetMapWithReticle(Map.Mutator.View.X, Map.Mutator.View.Y, t, Map.Mutator.CurrentLayer);

    public Bitmap GetBackgroundTerrain(int index = -1)
    {
        return TerrainSprite.GetMapWithBuildings(Map, null, PixelsBackgroundMap1, PixelsBackgroundMapX, BackgroundMap, index);
    }

    public Bitmap GetInflatedImage(Bitmap regular)
    {
        // Insert 1 acre on each side
        int columnWidth = (regular.Width / FieldItemWidthOld);
        var newWidth = columnWidth * FieldItemWidthNew;
        var bmp = new Bitmap(newWidth, regular.Height);
        using var g = Graphics.FromImage(bmp);

        // Fill with blue
        // g.Clear(Color.FromArgb(100, 149, 237));

        // Draw regular centered to new bitmap
        g.DrawImage(regular, columnWidth, 0, regular.Width, regular.Height);

        return bmp;
    }

    private Bitmap GetLayerAcre(int topX, int topY, int transparency)
    {
        var layer = Map.Mutator.CurrentLayer;
        ItemLayerSprite.LoadItemLayerViewGrid(ScaleAcre, layer, topX, topY, PixelsItemAcre1, PixelsItemAcreX, ViewScale, transparency);
        return ScaleAcre;
    }

    public Bitmap GetBackgroundAcre(Font f, byte transparencyBuilding, byte transparencyTerrain, int index = -1)
    {
        TerrainSprite.LoadViewport(BackgroundAcre, Map, f, PixelsBackgroundAcre1, PixelsBackgroundAcreX, index, transparencyBuilding, transparencyTerrain);
        return BackgroundAcre;
    }

    private Bitmap GetMapWithReticle(int topX, int topY, int t, LayerFieldItem layerField)
    {
        return ItemLayerSprite.GetBitmapItemLayer(MapReticle, layerField, topX, topY, PixelsItemMap, t);
    }
}
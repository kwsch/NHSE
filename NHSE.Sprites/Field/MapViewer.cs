using System;
using System.Drawing;
using NHSE.Core;

namespace NHSE.Sprites;

public sealed class MapViewer : MapView, IDisposable
{
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

    public MapViewer(MapManager m, int scale) : base(m, scale)
    {
        var l1 = m.Items.Layer1;
        var info = l1.TileInfo;
        PixelsItemAcre1 = new int[info.ViewWidth * info.ViewHeight];
        PixelsItemAcreX = new int[PixelsItemAcre1.Length * AcreScale * AcreScale];
        ScaleAcre = new Bitmap(info.ViewWidth * AcreScale, info.ViewHeight * AcreScale);

        PixelsItemMap = new int[info.TotalWidth * info.TotalHeight * MapScale * MapScale];
        MapReticle = new Bitmap(info.TotalWidth * MapScale, info.TotalHeight * MapScale);

        PixelsBackgroundAcre1 = new int[(int)Math.Pow(16, 4)];
        PixelsBackgroundAcreX = new int[PixelsItemAcreX.Length];
        BackgroundAcre = new Bitmap(ScaleAcre.Width, ScaleAcre.Height);

        PixelsBackgroundMap1 = new int[PixelsItemMap.Length / 4];
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

    public Bitmap GetLayerAcre(int t) => GetLayerAcre(X, Y, t);
    public Bitmap GetMapWithReticle(int t) => GetMapWithReticle(X, Y, t, Map.CurrentLayer);

    public Bitmap GetBackgroundTerrain(int index = -1)
    {
        return TerrainSprite.GetMapWithBuildings(Map, null, PixelsBackgroundMap1, PixelsBackgroundMapX, BackgroundMap, 2, index);
    }

    private Bitmap GetLayerAcre(int topX, int topY, int t)
    {
        var layer = Map.CurrentLayer;
        return ItemLayerSprite.GetBitmapItemLayerViewGrid(layer, topX, topY, AcreScale, PixelsItemAcre1, PixelsItemAcreX, ScaleAcre, t);
    }

    public Bitmap GetBackgroundAcre(Font f, byte tbuild, byte tterrain, int index = -1)
    {
        return TerrainSprite.GetAcre(this, f, PixelsBackgroundAcre1, PixelsBackgroundAcreX, BackgroundAcre, index, tbuild, tterrain);
    }

    private Bitmap GetMapWithReticle(int topX, int topY, int t, FieldItemLayer layer)
    {
        return ItemLayerSprite.GetBitmapItemLayer(layer, topX, topY, PixelsItemMap, MapReticle, t);
    }
}
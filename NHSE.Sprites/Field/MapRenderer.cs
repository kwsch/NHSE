using NHSE.Core;
using System;
using System.Drawing;

namespace NHSE.Sprites;

/// <summary>
/// Produces bitmaps for viewing map acres and full maps.
/// </summary>
public sealed class MapRenderer : IDisposable
{
    /// <summary>
    /// Data source for map rendering.
    /// </summary>
    private readonly MapEditor Map;

    /// <summary> Scale factor for full map rendering. </summary>
    private int MapScale => Map.MapScale;

    /// <summary> Scale factor for acre viewport rendering. </summary>
    private int ViewScale => Map.ViewScale;

    // Cached acre view objects to remove allocation/GC

    /// <summary> 1px scale viewport item layer pixel data. </summary>
    private readonly int[] ViewportItems1;
    /// <summary> Upscaled viewport item layer pixel data. </summary>
    private readonly int[] ViewportItemsX;
    /// <summary> Upscaled viewport item layer image. </summary>
    private readonly Bitmap ViewportItemsImage;

    /// <summary> Upscaled map item layer pixel data with reticle. </summary>
    private readonly int[] MapItemsReticleX;
    /// <summary> Upscaled map item layer image with reticle. </summary>
    private readonly Bitmap MapItemsReticleImage;

    /// <summary> 1px scale viewport terrain layer pixel data. </summary>
    private readonly int[] ViewportTerrain1;
    /// <summary> Upscaled viewport terrain layer pixel data. </summary>
    private readonly int[] ViewportTerrainX;
    /// <summary> Upscaled viewport terrain layer image. </summary>
    private readonly Bitmap ViewportTerrainImage;

    /// <summary> 1px scale map terrain layer pixel data. </summary>
    private readonly int[] MapTerrain1;
    /// <summary> Upscaled map terrain layer pixel data. </summary>
    private readonly int[] MapTerrainX;
    /// <summary> Upscaled map terrain layer image. </summary>
    private readonly Bitmap MapTerrainImage;

    public MapRenderer(MapEditor m)
    {
        Map = m;

        // Initialize cached objects based on map size
        // Get tile info from layer 0 (item layer is the tiniest cell we can render)
        var l1 = m.Mutator.Manager.FieldItems.Layer0;
        var info = l1.TileInfo;

        MapItemsReticleX = new int[info.TotalWidth * info.TotalHeight * MapScale * MapScale];
        MapItemsReticleImage = new Bitmap(info.TotalWidth * MapScale, info.TotalHeight * MapScale);

        MapTerrain1 = new int[MapItemsReticleX.Length / (MapScale * MapScale)];
        MapTerrainX = new int[MapItemsReticleX.Length];
        MapTerrainImage = new Bitmap(MapItemsReticleImage.Width, MapItemsReticleImage.Height);

        ViewportItems1 = new int[info.ViewWidth * info.ViewHeight];
        ViewportItemsX = new int[ViewportItems1.Length * ViewScale * ViewScale];
        ViewportItemsImage = new Bitmap(info.ViewWidth * ViewScale, info.ViewHeight * ViewScale);

        ViewportTerrain1 = new int[16*16 * 16*16]; // each terrain tile is drawn as 16px, then we upscale
        ViewportTerrainX = new int[ViewportItemsX.Length]; // 2x upscale
        ViewportTerrainImage = new Bitmap(ViewportItemsImage.Width, ViewportItemsImage.Height);
    }

    public void Dispose()
    {
        MapItemsReticleImage.Dispose();
        MapTerrainImage.Dispose();

        ViewportItemsImage.Dispose();
        ViewportTerrainImage.Dispose();
    }

    /// <summary>
    /// Updates the map items reticle bitmap for the current layer and view position.
    /// </summary>
    /// <param name="transparency">Transparency of items (not including reticle).</param>
    /// <param name="drawReticle">Option to draw the reticle.</param>
    /// <returns>Updated bitmap with reticle.</returns>
    public Bitmap UpdateMapItemsReticle(int transparency, bool drawReticle = true)
        => UpdateMapItemsReticle(Map.Mutator.CurrentLayer, Map.Mutator.View.X, Map.Mutator.View.Y, transparency, drawReticle);

    /// <summary>
    /// Updates the map terrain bitmap.
    /// </summary>
    /// <param name="selectedBuildingIndex">Index of building to highlight, or -1 for none.</param>
    /// <returns>Updated map terrain bitmap.</returns>
    public Bitmap UpdateMapTerrain(int selectedBuildingIndex = -1)
        => TerrainSprite.GetMapWithBuildings(MapTerrainImage, Map, null, MapTerrain1, MapTerrainX, selectedBuildingIndex);

    /// <summary>
    /// Updates the viewport items bitmap for the current layer and view position.
    /// </summary>
    /// <param name="transparency">Transparency of items.</param>
    public Bitmap UpdateViewportItems(int transparency)
        => UpdateViewportItems(Map.Mutator.View.X, Map.Mutator.View.Y, transparency);

    /// <summary>
    /// Updates the viewport terrain bitmap.
    /// </summary>
    /// <param name="f">Font to use for building labels.</param>
    /// <param name="transparencyBuilding">Transparency for building shapes drawn on terrain.</param>
    /// <param name="transparencyTerrain">Transparency for terrain layer.</param>
    /// <param name="selectedBuildingIndex">Index of building to highlight, or -1 for none.</param>
    /// <returns></returns>
    public Bitmap UpdateViewportTerrain(Font f, byte transparencyBuilding, byte transparencyTerrain, int selectedBuildingIndex = -1)
    {
        TerrainSprite.LoadViewport(ViewportTerrainImage, Map, f, ViewportTerrain1, ViewportTerrainX, selectedBuildingIndex, transparencyBuilding, transparencyTerrain);
        return ViewportTerrainImage;
    }

    private Bitmap UpdateMapItemsReticle(LayerFieldItem layer, int absX, int absY, int transparency, bool drawReticle = true)
    {
        var cfg = Map.Mutator.Manager.ConfigItems;
        ItemLayerSprite.LoadItemLayerDrawReticle(cfg, layer, MapItemsReticleX, transparency);
        MapItemsReticleImage.SetBitmapData(MapItemsReticleX);
        if (drawReticle)
            ItemLayerSprite.DrawViewReticle(MapItemsReticleImage, layer.TileInfo, absX, absY);
        return MapItemsReticleImage;
    }

    private Bitmap UpdateViewportItems(int absX, int absY, int transparency)
    {
        var cfg = Map.Mutator.Manager.ConfigItems;
        var layer = Map.Mutator.CurrentLayer;
        ItemLayerSprite.LoadViewport(ViewportItemsImage, layer, cfg, absX, absY, ViewportItems1, ViewportItemsX, ViewScale, transparency);
        return ViewportItemsImage;
    }
}
namespace NHSE.Core;

public static class MapTileManagerUtil
{
    /// <summary>
    /// Retrieves a <see cref="MapTileManager"/> from the provided <see cref="MainSave"/>.
    /// </summary>
    public static MapTileManager FromSaveFile(MainSave sav) => new()
    {
        ConfigTerrain = LayerPositionConfig.Create(7, 6, 16, 1),
        ConfigBuildings = LayerPositionConfig.Create(5, 4, 16, 2),
        ConfigItems = LayerPositionConfig.Create(sav.FieldItemAcreWidth, sav.FieldItemAcreHeight, 32, 1),

        LayerTerrain = new LayerTerrain(sav.GetTerrainTiles(), sav.GetAcreBytes()),
        LayerBuildings = new LayerBuilding { Buildings = sav.Buildings },
        FieldItems = new LayerFieldItemSet
        {
            Layer0 = new LayerFieldItem(sav.GetFieldItemLayer0(), sav.FieldItemAcreWidth, sav.FieldItemAcreHeight),
            Layer1 = new LayerFieldItem(sav.GetFieldItemLayer1(), sav.FieldItemAcreWidth, sav.FieldItemAcreHeight),
        },
        LayerItemFlag0 = new LayerFieldItemFlag(sav.FieldItemFlag0Data, sav.FieldItemAcreWidth, sav.FieldItemAcreHeight),
        LayerItemFlag1 = new LayerFieldItemFlag(sav.FieldItemFlag1Data, sav.FieldItemAcreWidth, sav.FieldItemAcreHeight),
        Plaza = new MapStatePlaza { X = sav.EventPlazaLeftUpX, Z = sav.EventPlazaLeftUpZ },
    };

    /// <summary>
    /// Sets the values from the provided <see cref="MapTileManager"/> into the provided <see cref="MainSave"/>.
    /// </summary>
    public static void SetManager(this MapTileManager mgr, MainSave sav)
    {
        sav.Buildings = mgr.LayerBuildings.Buildings;
        sav.SetTerrainTiles(mgr.LayerTerrain.Tiles);
        sav.SetFieldItemLayer0(mgr.FieldItems.Layer0.Tiles);
        sav.SetFieldItemLayer1(mgr.FieldItems.Layer1.Tiles);
        mgr.LayerItemFlag0.Save(sav.FieldItemFlag0Data.Span);
        mgr.LayerItemFlag1.Save(sav.FieldItemFlag1Data.Span);
        sav.SetAcreBytes(mgr.LayerTerrain.BaseAcres.Span);
        sav.EventPlazaLeftUpX = mgr.Plaza.X;
        sav.EventPlazaLeftUpZ = mgr.Plaza.Z;
    }
}
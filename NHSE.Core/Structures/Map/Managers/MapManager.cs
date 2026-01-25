namespace NHSE.Core;

public sealed class MapTileManager
{
    public required LayerPositionConfig ConfigTerrain { get; init; }
    public required LayerPositionConfig ConfigItems { get; init; }
    public required LayerPositionConfig ConfigBuildings { get; init; }

    public required ILayerFieldItemSet FieldItems { get; init; }
    public required ILayerFieldItemFlag LayerItemFlag0 { get; init; }
    public required ILayerFieldItemFlag LayerItemFlag1 { get; init; }
    public required ILayerBuilding LayerBuildings { get; init; }

    public required MapStatePlaza Plaza { get; init; }
    public required LayerTerrain LayerTerrain { get; set; }
}
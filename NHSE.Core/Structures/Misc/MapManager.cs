using System.Collections.Generic;

namespace NHSE.Core;

public sealed class MapManager(MainSave sav) : MapTerrainStructure(sav)
{
    public readonly FieldItemManager Items = new(sav);

    public int MapLayer { get; set; } // 0 or 1

    public FieldItemLayer CurrentLayer => MapLayer == 0 ? Items.Layer1 : Items.Layer2;
}

public abstract class MapTerrainStructure(MainSave sav)
{
    public readonly TerrainLayer Terrain = new(sav.GetTerrainTiles(), sav.GetAcreBytes());
    public readonly IReadOnlyList<Building> Buildings = sav.Buildings;

    public uint PlazaX { get; set; } = sav.EventPlazaLeftUpX;
    public uint PlazaY { get; set; } = sav.EventPlazaLeftUpZ;
}
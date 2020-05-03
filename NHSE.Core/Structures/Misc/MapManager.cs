using System.Collections.Generic;

namespace NHSE.Core
{
    public class MapManager : MapTerrainStructure
    {
        public readonly FieldItemManager Items;

        public int MapLayer { get; set; } // 0 or 1

        public MapManager(MainSave sav) : base(sav)
        {
            Items = new FieldItemManager(sav.GetFieldItems());
        }

        public FieldItemLayer CurrentLayer => MapLayer == 0 ? Items.Layer1 : Items.Layer2;
    }

    public class MapTerrainStructure
    {
        public readonly TerrainManager Terrain;
        public readonly IReadOnlyList<Building> Buildings;

        public uint PlazaX { get; set; }
        public uint PlazaY { get; set; }

        public MapTerrainStructure(MainSave sav)
        {
            Terrain = new TerrainManager(sav.GetTerrainTiles());
            Buildings = sav.Buildings;
            PlazaX = sav.PlazaX;
            PlazaY = sav.PlazaY;
        }
    }
}

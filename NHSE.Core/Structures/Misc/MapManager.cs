using System.Collections.Generic;

namespace NHSE.Core
{
    public class MapManager
    {
        public readonly FieldItemManager Items;
        public readonly TerrainManager Terrain;
        public readonly IReadOnlyList<Building> Buildings;

        public uint PlazaX { get; set; }
        public uint PlazaY { get; set; }

        public int MapLayer { get; set; } // 0 or 1

        public MapManager(MainSave sav)
        {
            Items = new FieldItemManager(sav.GetFieldItems());
            Terrain = new TerrainManager(sav.GetTerrainTiles());
            Buildings = sav.Buildings;
            PlazaX = sav.PlazaX;
            PlazaY = sav.PlazaY;
        }

        public FieldItemLayer CurrentLayer => MapLayer == 0 ? Items.Layer1 : Items.Layer2;
    }
}

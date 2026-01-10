using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NHSE.Core;

public class MapManager : MapTerrainStructure
{
    public readonly FieldItemManager Items;

    public int MapLayer { get; set; } // 0 or 1

    public MapManager(MainSave sav) : base(sav)
    {
        Items = new FieldItemManager(sav);
    }

    public FieldItemLayer CurrentLayer => MapLayer == 0 ? Items.Layer1 : Items.Layer2;

    public static void ClearDesignTiles(MainSave sav)
    {
        var tiles = sav.GetMapDesignTiles();
        for (int i = 0; i < tiles.Length; i++)
            tiles[i] = MainSave.MapDesignNone;
        sav.SetMapDesignTiles(tiles);
    }

    public static byte[] ExportDesignTiles(MainSave sav)
    {
        var tiles = sav.GetMapDesignTiles();
        var result = new byte[tiles.Length * 2];
        Buffer.BlockCopy(tiles, 0, result, 0, result.Length);
        return result;
    }

    public static void ImportDesignTiles(MainSave sav, ReadOnlySpan<byte> result)
    {
        var tiles = sav.GetMapDesignTiles();
        MemoryMarshal.Cast<byte, ushort>(result).CopyTo(tiles);
        sav.SetMapDesignTiles(tiles);
    }
}

public class MapTerrainStructure
{
    public readonly TerrainLayer Terrain;
    public readonly IReadOnlyList<Building> Buildings;

    public uint PlazaX { get; set; }
    public uint PlazaY { get; set; }

    public MapTerrainStructure(MainSave sav)
    {
        Terrain = new TerrainLayer(sav.GetTerrainTiles(), sav.GetAcreBytes());
        Buildings = sav.Buildings;
        PlazaX = sav.EventPlazaLeftUpX;
        PlazaY = sav.EventPlazaLeftUpZ;
    }
}
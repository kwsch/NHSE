using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NHSE.Core;

public class MapManager(MainSave sav) : MapTerrainStructure(sav)
{
    public readonly FieldItemManager Items = new(sav);

    public int MapLayer { get; set; } // 0 or 1

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

public class MapTerrainStructure(MainSave sav)
{
    public readonly TerrainLayer Terrain = new(sav.GetTerrainTiles(), sav.GetAcreBytes());
    public readonly IReadOnlyList<Building> Buildings = sav.Buildings;

    public uint PlazaX { get; set; } = sav.EventPlazaLeftUpX;
    public uint PlazaY { get; set; } = sav.EventPlazaLeftUpZ;
}
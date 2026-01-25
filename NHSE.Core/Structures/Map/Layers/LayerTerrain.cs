using System;
using System.Diagnostics;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// Grid of <see cref="TerrainTile"/>
/// </summary>
public sealed record LayerTerrain : AcreSelectionGrid
{
    public TerrainTile[] Tiles { get; init; }
    public Memory<byte> BaseAcres { get; init; }

    public const byte TilesPerAcreDim = 16;

    private const byte CountAcreWidth = 7;
    private const byte CountAcreHeight = 6;

    private static TileGridViewport Viewport => new(TilesPerAcreDim, TilesPerAcreDim, CountAcreWidth, CountAcreHeight);

    public LayerTerrain(TerrainTile[] tiles, Memory<byte> acres) : base(Viewport)
    {
        BaseAcres = acres;
        Tiles = tiles;
        Debug.Assert(TileInfo.TotalCount == tiles.Length);
    }

    public TerrainTile GetTile(int x, int y) => this[TileInfo.GetTileIndex(x, y)];
    public TerrainTile GetTile(int acreX, int acreY, int gridX, int gridY) => this[TileInfo.GetTileIndex(acreX, acreY, gridX, gridY)];
    public TerrainTile GetAcreTile(int acreIndex, int tileIndex) => this[GetAcreTileIndex(acreIndex, tileIndex)];

    public TerrainTile this[int index]
    {
        get => Tiles[index];
        set => Tiles[index] = value;
    }

    /// <summary>
    /// Flattens the terrain tiles into a contiguous byte array.
    /// </summary>
    public byte[] DumpAll() => TerrainTile.SetArray(Tiles);

    /// <summary>
    /// Gets the tiles local to the specified acre as a contiguous byte array.
    /// </summary>
    /// <param name="acre">Terrain acre index.</param>
    public byte[] DumpAcre(int acre)
    {
        int count = TileInfo.ViewCount;
        var result = new byte[TerrainTile.SIZE * count];
        for (int i = 0; i < count; i++)
        {
            var tile = GetAcreTile(acre, i);
            var bytes = tile.ToBytesClass();
            bytes.CopyTo(result, i * TerrainTile.SIZE);
        }

        return result;
    }

    /// <summary>
    /// Imports terrain tiles from a contiguous byte array.
    /// </summary>
    /// <param name="data">Byte array containing terrain tile data.</param>
    public void ImportAll(ReadOnlySpan<byte> data)
    {
        var tiles = TerrainTile.GetArray(data);
        for (int i = 0; i < tiles.Length; i++)
            Tiles[i].CopyFrom(tiles[i]);
    }

    /// <summary>
    /// Imports terrain tiles for the specified acre from a contiguous byte array.
    /// </summary>
    /// <param name="acre">Terrain acre index.</param>
    /// <param name="data">Byte array containing terrain tile data.</param>
    public void ImportAcre(int acre, ReadOnlySpan<byte> data)
    {
        int count = TileInfo.ViewCount;
        var tiles = TerrainTile.GetArray(data);
        for (int i = 0; i < count; i++)
        {
            var tile = GetAcreTile(acre, i);
            tile.CopyFrom(tiles[i]);
        }
    }

    /// <summary>
    /// Sets all tiles to the specified tile.
    /// </summary>
    /// <param name="tile"></param>
    /// <param name="interiorOnly">If true, only sets the interior tiles, skipping the outermost ring of beach/rock acres.</param>
    public void SetAll(TerrainTile tile, in bool interiorOnly = true)
    {
        if (interiorOnly)
        {
            // skip outermost ring of tiles
            int xmin = TileInfo.ViewWidth;
            int ymin = TileInfo.ViewHeight;
            int xmax = TileInfo.TotalWidth - TileInfo.ViewWidth;
            int ymax = TileInfo.TotalHeight - TileInfo.ViewHeight;
            for (int x = xmin; x < xmax; x++)
            {
                for (int y = ymin; y < ymax; y++)
                    GetTile(x, y).CopyFrom(tile);
            }
        }
        else
        {
            foreach (var t in Tiles)
                t.CopyFrom(tile);
        }
    }

    /// <summary>
    /// Sets all road tiles (not the terrain itself, but the road atop) to the specified tile.
    /// </summary>
    /// <param name="tile">Road tile info to copy from.</param>
    /// <param name="interiorOnly">If true, only sets the interior tiles, skipping the outermost ring of beach/rock acres.</param>
    public void SetAllRoad(TerrainTile tile, bool interiorOnly = true)
    {
        if (interiorOnly)
        {
            // skip outermost ring of tiles
            int xmin = TileInfo.ViewWidth;
            int ymin = TileInfo.ViewHeight;
            int xmax = TileInfo.TotalWidth - TileInfo.ViewWidth;
            int ymax = TileInfo.TotalHeight - TileInfo.ViewHeight;
            for (int x = xmin; x < xmax; x++)
            {
                for (int y = ymin; y < ymax; y++)
                    GetTile(x, y).CopyRoadFrom(tile);
            }
        }
        else
        {
            foreach (var t in Tiles)
                t.CopyRoadFrom(tile);
        }
    }

    public int GetTileColor(int x, int y, int insideX, int insideY)
    {
        var acre = GetAcreTemplate(x, y);
        return GetTileColor(acre, x, y, insideX, insideY);
    }

    public int GetTileColor(ushort acre, int x, int y, int insideX, int insideY)
    {
        if (acre != 0) // predefined appearance
        {
            var c = AcreTileColor.GetAcreTileColor(acre, x % 16, y % 16);
            if (c != -0x1000000) // transparent
                return c;
        }

        // dynamic (terrain-based) appearance
        var tile = GetTile(x, y);
        return TerrainTileColor.GetTileColor(tile, insideX, insideY).ToArgb();
    }

    public ushort GetAcreTemplate(int terrainX, int terrainY)
    {
        // Acres are 16x16 tiles, and the acre data has a 1-acre deep-sea border around it.
        var acreX = 1 + (terrainX / 16);
        var acreY = 1 + (terrainY / 16);

        var acreIndex = ((CountAcreWidth + 2) * acreY) + acreX;
        var ofs = acreIndex * 2;
        return ReadUInt16LittleEndian(BaseAcres.Span[ofs..]);
    }
}
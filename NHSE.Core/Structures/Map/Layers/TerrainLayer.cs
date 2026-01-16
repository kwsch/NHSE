using System;
using System.Diagnostics;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// Grid of <see cref="TerrainTile"/>
/// </summary>
public sealed record TerrainLayer : AcreSelectionGrid
{
    public TerrainTile[] Tiles { get; init; }
    public Memory<byte> BaseAcres { get; init; }

    public const byte TilesPerAcreDim = 16;

    private const byte CountAcreWidth = 7;
    private const byte CountAcreHeight = 6;

    private static TileGridViewport Viewport => new(TilesPerAcreDim, TilesPerAcreDim, CountAcreWidth, CountAcreHeight);

    public TerrainLayer(TerrainTile[] tiles, Memory<byte> acres) : base(Viewport)
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

    public byte[] DumpAll()
    {
        var result = new byte[Tiles.Length * TerrainTile.SIZE];
        for (int i = 0; i < Tiles.Length; i++)
            Tiles[i].ToBytesClass().CopyTo(result, i * TerrainTile.SIZE);
        return result;
    }

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

    public void ImportAll(ReadOnlySpan<byte> data)
    {
        var tiles = TerrainTile.GetArray(data);
        for (int i = 0; i < tiles.Length; i++)
            Tiles[i].CopyFrom(tiles[i]);
    }

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

    public void SetAll(TerrainTile tile, in bool interiorOnly)
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

    public void SetAllRoad(TerrainTile tile, in bool interiorOnly)
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

    public void GetBuildingCoordinate(ushort bx, ushort by, int scale, out int x, out int y)
    {
        // Although there is terrain in the Top Row and Left Column, no buildings can be placed there.
        // Adjust the building coordinates down-right by an acre.
        int buildingShift = TileInfo.ViewWidth;
        x = (int)(((bx / 2f) - buildingShift) * scale);
        y = (int)(((by / 2f) - buildingShift) * scale);
    }

    public void GetBuildingRelativeCoordinates(int topX, int topY, int acreScale, ushort bx, ushort by, out int relX, out int relY)
    {
        GetBuildingCoordinate(bx, by, acreScale, out var x, out var y);
        relX = x - (topX * acreScale);
        relY = y - (topY * acreScale);
    }

    public bool IsWithinGrid(int acreScale, int relX, int relY)
    {
        if ((uint)relX >= TileInfo.ViewWidth * acreScale)
            return false;

        if ((uint)relY >= TileInfo.ViewHeight * acreScale)
            return false;

        return true;
    }

    public int GetTileColor(int x, in int y, int relativeX, int relativeY)
    {
        var acre = GetTileAcre(x, y);
        if (acre != 0)
        {
            var c = AcreTileColor.GetAcreTileColor(acre, x % 16, y % 16);
            if (c != -0x1000000) // transparent
                return c;
        }

        var tile = GetTile(x, y);
        return TerrainTileColor.GetTileColor(tile, relativeX, relativeY).ToArgb();
    }

    private ushort GetTileAcre(int x, int y)
    {
        var acreX = 1 + (x / 16);
        var acreY = 1 + (y / 16);

        var acreIndex = ((CountAcreWidth + 2) * acreY) + acreX;
        var ofs = acreIndex * 2;
        return ReadUInt16LittleEndian(BaseAcres.Span[ofs..]);
    }
}
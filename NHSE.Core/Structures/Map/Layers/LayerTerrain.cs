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

    /// <inheritdoc cref="GetTileColor(ushort,int,int,int,int)"/>
    public int GetTileColor(int relX, int relY, int insideX, int insideY)
    {
        var acre = GetAcreTemplate(relX, relY);
        return GetTileColor(acre, relX, relY, insideX, insideY);
    }

    /// <summary>
    /// Gets the base acre tile color at the specified terrain coordinates.
    /// </summary>
    /// <remarks>
    /// If the acre has a predefined appearance, that is used; otherwise, the terrain-based appearance is used.
    /// </remarks>
    /// <param name="acre">Base acre underneath the terrain tile.</param>
    /// <param name="relX">Relative X coordinate in terrain tiles.</param>
    /// <param name="relY">Relative Y coordinate in terrain tiles.</param>
    /// <param name="insideX">Inside X coordinate of the terrain tile (16px max).</param>
    /// <param name="insideY">Inside Y coordinate of the terrain tile (16px max).</param>
    /// <returns>ARGB color value.</returns>
    public int GetTileColor(ushort acre, int relX, int relY, int insideX, int insideY)
    {
        if (acre != 0) // predefined appearance
        {
            var c = AcreTileColor.GetAcreTileColor(acre, relX % 16, relY % 16);
            if (c != -0x1000000) // transparent
                return c;
        }

        // dynamic (terrain-based) appearance
        var tile = GetTile(relX, relY);
        return TerrainTileColor.GetTileColor(tile, insideX, insideY).ToArgb();
    }


    /// <summary>
    /// Gets the base acre tile color at the specified terrain coordinates.
    /// </summary>
    /// <remarks>
    /// If the acre has a predefined appearance, that is used; otherwise, the terrain-based appearance is used.
    /// </remarks>
    /// <param name="acre">Base acre underneath the terrain tile.</param>
    /// <param name="tile">Terrain tile to render.</param>
    /// <param name="relX">Relative X coordinate in terrain tiles.</param>
    /// <param name="relY">Relative Y coordinate in terrain tiles.</param>
    /// <param name="insideX">Inside X coordinate of the terrain tile (16px max).</param>
    /// <param name="insideY">Inside Y coordinate of the terrain tile (16px max).</param>
    /// <returns>ARGB color value.</returns>
    public int GetTileColor(ushort acre, TerrainTile tile, int relX, int relY, int insideX, int insideY)
    {
        // If acre is entirely transparent (interior acre), dynamic (terrain-based) appearance
        if (acre == 0)
            return TerrainTileColor.GetTileColor(tile, insideX, insideY).ToArgb();

        // For beaches, a slim edge is customizable (indicative by a transparent value).
        // Check if pre-defined appearance governs
        var color = AcreTileColor.GetAcreTileColor(acre, relX % 16, relY % 16);
        if (color == -0x1000000) // transparent (dynamic)
            return TerrainTileColor.GetTileColor(tile, insideX, insideY).ToArgb();

        return color; // pre-defined appearance
    }

    /// <summary>
    /// Gets the base acre template at the specified terrain coordinates.
    /// </summary>
    /// <param name="relX">Relative X coordinate in terrain tiles.</param>
    /// <param name="relY">Relative Y coordinate in terrain tiles.</param>
    /// <returns>Base acre underneath the terrain tile.</returns>
    public ushort GetAcreTemplate(int relX, int relY)
    {
        // Acres are 16x16 tiles, and the acre data has a 1-acre deep-sea border around it.
        var acreX = 1 + (relX / 16);
        var acreY = 1 + (relY / 16);

        var acreIndex = ((CountAcreWidth + 2) * acreY) + acreX;
        var ofs = acreIndex * 2;
        return ReadUInt16LittleEndian(BaseAcres.Span[ofs..]);
    }
}
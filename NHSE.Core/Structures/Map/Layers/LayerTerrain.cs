using System;
using System.Diagnostics;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// Grid of <see cref="TerrainTile"/>
/// </summary>
public sealed record LayerTerrain : AcreSelectionGrid
{
    /// <summary>
    /// Terrain tiles in this layer, stored in column-major order.
    /// </summary>
    public TerrainTile[] Tiles { get; }

    /// <summary>
    /// Gets the underlying memory buffer containing the base acre template data (such as sea, beach, interior).
    /// </summary>
    public Memory<byte> BaseAcres { get; }

    /// <summary>
    /// 16x16 tiles per acre.
    /// </summary>
    public const byte TilesPerAcreDim = 16;

    /// <summary>
    /// Interior acre-count width (without the deep-sea border).
    /// </summary>
    private const byte CountAcreWidth = 7;

    /// <summary>
    /// Interior acre-count height (without the deep-sea border).
    /// </summary>
    private const byte CountAcreHeight = 6;

    private static TileGridViewport Viewport => new(TilesPerAcreDim, TilesPerAcreDim, CountAcreWidth, CountAcreHeight);

    public LayerTerrain(TerrainTile[] tiles, Memory<byte> acres) : base(Viewport)
    {
        BaseAcres = acres;
        Tiles = tiles;
        Debug.Assert(TileInfo.TotalCount == tiles.Length);
    }

    /// <summary>
    /// Gets the terrain tile at the specified coordinates.
    /// </summary>
    /// <param name="relX">The requested tile's X-coordinate, relative to the layer origin.</param>
    /// <param name="relY">The requested tile's Y-coordinate, relative to the layer origin.</param>
    /// <remarks>
    /// An exception is thrown if the requested coordinates are out of the layer's range.
    /// </remarks>
    public TerrainTile GetTile(int relX, int relY) => this[TileInfo.GetTileIndex(relX, relY)];

    private TerrainTile GetTileSafe(int relX, int relY)
    {
        if (Contains(relX, relY))
            return new TerrainTile();
        return GetTile(relX, relY);
    }

    private bool SetTileSafe(int relX, int relY, TerrainTile tile)
    {
        if (Contains(relX, relY))
            return false;
        GetTile(relX, relY).CopyFrom(tile);
        return true;
    }

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
    /// Retrieves the serialized data for the acre at the specified relative coordinates.
    /// </summary>
    /// <param name="relX">The relative X-coordinate of the top-left tile of the acre to dump.</param>
    /// <param name="relY">The relative Y-coordinate of the top-left tile of the acre to dump.</param>
    /// <returns>
    /// A byte array containing the serialized terrain data of the specified acre.
    /// The array length is determined by the terrain tile size and the view count.
    /// </returns>
    public byte[] DumpAcre(int relX, int relY)
    {
        int count = TileInfo.ViewCount;
        var result = new byte[TerrainTile.SIZE * count];
        DumpAcre(result, relX, relY);
        return result;
    }

    /// <summary>
    /// Writes the serialized data for an acre of tiles, starting at the specified relative coordinates, into the provided buffer.
    /// </summary>
    /// <remarks>
    /// If a tile at the specified coordinates is out of range, a default value is written for that tile.
    /// The data is written in column-major order, with each tile's bytes written sequentially into the buffer.
    /// </remarks>
    /// <param name="result">
    /// The buffer that receives the serialized tile data.
    /// Must be large enough to hold the data for the entire acre.
    /// </param>
    /// <param name="relX">The relative X-coordinate of the top-left tile of the acre to dump.</param>
    /// <param name="relY">The relative Y-coordinate of the top-left tile of the acre to dump.</param>
    public void DumpAcre(Span<byte> result, int relX, int relY)
    {
        // Store columns first. If the x,y is out of range, store default.
        int offset = 0;
        for (int y = 0; y < TileInfo.ViewHeight; y++)
        {
            var tileY = relY + y;
            for (int x = 0; x < TileInfo.ViewWidth; x++)
            {
                var tileX = relX + x;
                var tile = GetTileSafe(tileX, tileY);
                tile.ToBytesClass().CopyTo(result[offset..]);
                offset += Item.SIZE;
            }
        }
    }

    /// <summary>
    /// Imports terrain tile data into the layer at the specified relative coordinates.
    /// </summary>
    /// <param name="data">
    /// A read-only span of bytes containing the serialized terrain tile data to import.
    /// The data must be in the format expected by TerrainTile.GetArray.
    /// </param>
    /// <param name="relX">The X-coordinate, relative to the layer origin, where the imported tiles will be placed.</param>
    /// <param name="relY">The Y-coordinate, relative to the layer origin, where the imported tiles will be placed.</param>
    /// <returns>The number of tiles successfully imported. Returns 0 if no tiles were imported.</returns>
    public int ImportAcre(ReadOnlySpan<byte> data, int relX, int relY)
    {
        int count = 0;
        int i = 0;
        var tiles = TerrainTile.GetArray(data);
        for (int y = 0; y < TileInfo.ViewHeight; y++)
        {
            var tileY = relY + y;
            for (int x = 0; x < TileInfo.ViewWidth; x++)
            {
                var tileX = relX + x;
                SetTileSafe(tileX, tileY, tiles[i++]);
            }
        }
        return count;
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
        var span = GetBaseAcreSpan(acreIndex);
        return ReadUInt16LittleEndian(span);
    }

    /// <summary>
    /// Gets the base acre template span at the specified index.
    /// </summary>
    /// <param name="index">Index of the acre.</param>
    /// <returns>Span of bytes representing the base acre template.</returns>
    public Span<byte> GetBaseAcreSpan(int index) => BaseAcres.Span.Slice(index * 2, 2);
}
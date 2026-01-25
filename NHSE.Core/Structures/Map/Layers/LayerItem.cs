using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace NHSE.Core;

public abstract record LayerItem : AcreSelectionGrid
{
    /// <summary>
    /// All items in this layer, stored in column-major order.
    /// </summary>
    public Item[] Tiles { get; }

#pragma warning disable CA1857
    protected LayerItem(Item[] tiles, [ConstantExpected] byte w, [ConstantExpected] byte h) : this(tiles, new(w, h, w, h))
#pragma warning restore CA1857
    {
    }

    protected LayerItem(Item[] tiles, TileGridViewport tileTileInfo) : base(tileTileInfo)
    {
        Tiles = tiles;
        Debug.Assert(TileInfo.TotalWidth * TileInfo.TotalHeight == tiles.Length);
    }

    /// <summary>
    /// Retrieves the tile at the specified relative coordinates, or a default value if the coordinates are outside the
    /// valid layer bounds.
    /// </summary>
    /// <param name="relX">The requested tile's X-coordinate, relative to the layer origin.</param>
    /// <param name="relY">The requested tile's Y-coordinate, relative to the layer origin.</param>
    /// <returns>The tile at the specified coordinates if they are within the layer; otherwise, a value indicating no item.</returns>
    public Item GetTileSafe(in int relX, in int relY)
    {
        if (!Contains(relX, relY))
            return Item.NO_ITEM;
        return GetTile(relX, relY);
    }

    /// <summary>
    /// Sets the tile at the specified relative coordinates if they are within the valid layer bounds.
    /// </summary>
    /// <param name="relX">The requested tile's X-coordinate, relative to the layer origin.</param>
    /// <param name="relY">The requested tile's Y-coordinate, relative to the layer origin.</param>
    /// <param name="tile">The tile to set at the specified coordinates.</param>
    /// <returns>Returns true if the tile was set, false if the coordinates were out of bounds.</returns>
    public bool SetTileSafe(in int relX, in int relY, Item tile)
    {
        if (!Contains(relX, relY))
            return false;
        SetTile(relX, relY, tile);
        return true;
    }

    /// <summary>
    /// Dumps the contents of an acre at the specified relative coordinates into a byte array.
    /// </summary>
    /// <param name="relX">The requested tile's X-coordinate, relative to the layer origin.</param>
    /// <param name="relY">The requested tile's Y-coordinate, relative to the layer origin.</param>
    /// <returns>A byte array containing the serialized data for the specified acre. The array length is determined by the number
    /// of tiles in the view and the size of each item.</returns>
    public byte[] DumpAcre(int relX, int relY)
    {
        int count = TileInfo.ViewCount;
        var result = new byte[Item.SIZE * count];
        DumpAcre(result, relX, relY);
        return result;
    }

    /// <summary>
    /// Writes the serialized data for an acre of tiles into the specified buffer, starting at the given relative X and Y coordinates.
    /// </summary>
    /// <remarks>
    /// If a tile at the specified coordinates is out of range, a default item is written for that position.
    /// The data is written in column-major order, with columns stored before rows.
    /// </remarks>
    /// <param name="result">The buffer that receives the serialized bytes for the acre. Must be large enough to hold all tile data.</param>
    /// <param name="relX">The top-left tile's X-coordinate, relative to the layer origin.</param>
    /// <param name="relY">The top-left tile's Y-coordinate, relative to the layer origin.</param>
    public void DumpAcre(Span<byte> result, int relX, int relY)
    {
        // Store columns first. If the x,y is out of range, store default item.
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
    /// Imports a block of tile data into the map at the specified relative coordinates.
    /// </summary>
    /// <remarks>The method attempts to set each tile in the specified region. Only tiles that are valid and
    /// within the map bounds are imported; others are ignored. The return value indicates how many tiles were actually
    /// updated.</remarks>
    /// <param name="data">A read-only span of bytes containing the tile data to import. The data must be formatted as expected by the tile
    /// array parser.</param>
    /// <param name="relX">The top-left tile's X-coordinate, relative to the layer origin.</param>
    /// <param name="relY">The top-left tile's Y-coordinate, relative to the layer origin.</param>
    /// <returns>The number of tiles that were successfully imported and set in the map.</returns>
    public int ImportAcre(ReadOnlySpan<byte> data, int relX, int relY)
    {
        int count = 0;
        int i = 0;
        var tiles = Item.GetArray(data);
        for (int y = 0; y < TileInfo.ViewHeight; y++)
        {
            var tileY = relY + y;
            for (int x = 0; x < TileInfo.ViewWidth; x++)
            {
                var tileX = relX + x;
                if (SetTileSafe(tileX, tileY, tiles[i++]))
                    count++;
            }
        }
        return count;
    }

    /// <summary>
    /// Retrieves the tile at the specified relative coordinates.
    /// </summary>
    /// <param name="relX">The X-coordinate of the tile, relative to the layer origin.</param>
    /// <param name="relY">The Y-coordinate of the tile, relative to the layer origin.</param>
    /// <returns>The tile at the specified coordinates.</returns>
    public Item GetTile(in int relX, in int relY) => this[TileInfo.GetTileIndex(relX, relY)];

    /// <summary>
    /// Sets the tile at the specified relative X and Y coordinates to the given tile value.
    /// </summary>
    /// <param name="relX">The X-coordinate of the tile, relative to the layer origin.</param>
    /// <param name="relY">The Y-coordinate of the tile, relative to the layer origin.</param>
    /// <param name="tile">The tile value to assign at the specified coordinates.</param>
    public void SetTile(in int relX, in int relY, Item tile) => this[TileInfo.GetTileIndex(relX, relY)] = tile;

    public Item this[int index]
    {
        get => Tiles[index];
        set => Tiles[index] = value;
    }

    /// <summary>
    /// Serializes all tiles into a single byte array.
    /// </summary>
    /// <returns>
    /// A byte array containing the serialized data of all tiles, concatenated in order.
    /// The length of the array is equal to the number of tiles multiplied by the size of each item.
    /// </returns>
    public byte[] DumpAll()
    {
        var result = new byte[Tiles.Length * Item.SIZE];
        DumpAll(result);
        return result;
    }

    /// <summary>
    /// Writes the byte representation of all tiles to the specified buffer.
    /// </summary>
    /// <param name="result">A buffer that receives the serialized bytes of all tiles.</param>
    public void DumpAll(Span<byte> result)
    {
        for (int i = 0; i < Tiles.Length; i++)
            Tiles[i].ToBytesClass().CopyTo(result[(i * Item.SIZE)..]);
    }

    /// <summary>
    /// Imports all tiles from the provided byte data into the layer.
    /// </summary>
    /// <param name="data">A read-only span of bytes containing the tile data to import.</param>
    public void ImportAll(ReadOnlySpan<byte> data)
    {
        var tiles = Item.GetArray(data);
        for (int i = 0; i < tiles.Length; i++)
            Tiles[i].CopyFrom(tiles[i]);
    }

    /// <summary>
    /// Removes all items within the specified rectangular region that match the given criteria.
    /// </summary>
    /// <remarks>
    /// The method evaluates the criteria for each item in the specified region and removes only those items for which the criteria returns <see langword="true"/>.
    /// Items outside the specified region are not affected.
    /// </remarks>
    /// <param name="xmin">The relative x-coordinate of the upper-left corner of the region to search.</param>
    /// <param name="ymin">The relative y-coordinate of the upper-left corner of the region to search.</param>
    /// <param name="width">The width, in tiles, of the region to search. Must be greater than or equal to 0.</param>
    /// <param name="height">The height, in tiles, of the region to search. Must be greater than or equal to 0.</param>
    /// <param name="criteria">
    /// A function that defines the condition each item must satisfy to be removed.
    /// The function is invoked for each item in the region.
    /// </param>
    /// <returns>The number of items that were removed.</returns>
    public int RemoveAll(in int xmin, in int ymin, in int width, in int height, Func<Item, bool> criteria)
    {
        int count = 0;
        for (int x = xmin; x < xmin + width; x++)
        {
            for (int y = ymin; y < ymin + height; y++)
            {
                var t = GetTile(x, y);
                if (!criteria(t))
                    continue;
                t.Delete();
                count++;
            }
        }

        return count;
    }

    /// <summary>
    /// Deletes all extension tiles associated with the specified tile at the given coordinates, except for the main (root) tile itself.
    /// </summary>
    /// <remarks>
    /// This method removes only the extension tiles that are part of the same logical group as the specified main tile,
    /// leaving the main tile itself intact.
    /// Use this method to clean up extension tiles when the main tile is being modified or removed.
    /// </remarks>
    /// <param name="tile">The main tile whose extension tiles are to be deleted.</param>
    /// <param name="x">The relative x-coordinate of the main (root) tile.</param>
    /// <param name="y">The relative y-coordinate of the main (root) tile.</param>
    public void DeleteExtensionTiles(Item tile, int x, int y)
    {
        GetTileWidthHeight(tile, x, y, out var w, out var h);

        for (int ix = 0; ix < w; ix++)
        {
            for (int iy = 0; iy < h; iy++)
            {
                if (iy == 0 && ix == 0)
                    continue;
                var t = GetTile(x + ix, y + iy);
                t.Delete();
            }
        }
    }

    /// <summary>
    /// Marks all tiles covered by the specified multi-tile item, except the origin tile,
    /// as extension tiles associated with the given item at the specified coordinates.
    /// </summary>
    /// <remarks>
    /// This method is typically used when placing a multi-tile item to ensure that all tiles it occupies,
    /// except for the origin, are correctly marked as extensions.
    /// The origin tile at the specified coordinates is not modified by this method.</remarks>
    /// <param name="tile">The multi-tile item whose extension tiles are to be set.</param>
    /// <param name="x">The relative x-coordinate of the main (root) tile.</param>
    /// <param name="y">The relative y-coordinate of the main (root) tile.</param>
    public void SetExtensionTiles(Item tile, in int x, in int y)
    {
        GetTileWidthHeight(tile, x, y, out var w, out var h);

        for (byte ix = 0; ix < w; ix++)
        {
            for (byte iy = 0; iy < h; iy++)
            {
                if (iy == 0 && ix == 0)
                    continue;
                var t = GetTile(x + ix, y + iy);
                t.SetAsExtension(tile, ix, iy);
            }
        }
    }

    private void GetTileWidthHeight(Item tile, int x, int y, out int w, out int h)
    {
        var type = ItemInfo.GetItemSize(tile);
        w = type.Width;
        h = type.Height;

        // Rotation
        if ((tile.Rotation & 1) == 1)
            (w, h) = (h, w);

        // Clamp to grid bounds
        if (x + w - 1 >= TileInfo.TotalWidth)
            w = TileInfo.TotalWidth - x;
        if (y + h - 1 >= TileInfo.TotalHeight)
            h = TileInfo.TotalHeight - y;
    }

    /// <summary>
    /// Checks if writing the <see cref="tile"/> at the specified <see cref="x"/> and <see cref="y"/> coordinates will overlap with any existing tiles.
    /// </summary>
    /// <returns>True if any tile will be overwritten, false if nothing is there.</returns>
    public PlacedItemPermission IsOccupied(Item tile, in int x, in int y)
    {
        var type = ItemInfo.GetItemSize(tile);
        var w = type.Width;
        var h = type.Height;

        if ((tile.Rotation & 1) == 1)
            (w, h) = (h, w);

        if (x + w - 1 >= TileInfo.TotalWidth)
            return PlacedItemPermission.OutOfBounds;
        if (y + h - 1 >= TileInfo.TotalHeight)
            return PlacedItemPermission.OutOfBounds;

        for (byte ix = 0; ix < w; ix++)
        {
            for (byte iy = 0; iy < h; iy++)
            {
                var t = GetTile(x + ix, y + iy);
                if (!t.IsNone)
                    return PlacedItemPermission.Collision;
            }
        }

        return PlacedItemPermission.NoCollision;
    }

    /// <summary>
    /// Replaces all occurrences of a specified item with a new item within the defined rectangular region.
    /// </summary>
    /// <remarks>
    /// Only root tiles that exactly match <paramref name="oldItem"/> are replaced.
    /// No replacements are made if the item sizes differ.
    /// </remarks>
    /// <param name="oldItem">The item to search for and replace within the specified region.</param>
    /// <param name="newItem">The item to use as a replacement for each occurrence of <paramref name="oldItem"/>.</param>
    /// <param name="xmin">The relative x-coordinate of the upper-left corner of the region in which to perform replacements.</param>
    /// <param name="ymin">The relative y-coordinate of the upper-left corner of the region in which to perform replacements.</param>
    /// <param name="width">The width, in tiles, of the region in which to perform replacements. Must be greater than zero.</param>
    /// <param name="height">The height, in tiles, of the region in which to perform replacements. Must be greater than zero.</param>
    /// <returns>
    /// The number of items replaced within the specified region,
    /// or -1 if <paramref name="oldItem"/> and <paramref name="newItem"/> are incompatible.
    /// </returns>
    public int ReplaceAll(Item oldItem, Item newItem, in int xmin, in int ymin, in int width, in int height)
    {
        var sizeOld = ItemInfo.GetItemSize(oldItem);
        var sizeNew = ItemInfo.GetItemSize(newItem);

        if (sizeOld != sizeNew)
            return -1;

        int count = 0;
        for (int x = xmin; x < xmin + width; x++)
        {
            for (int y = ymin; y < ymin + height; y++)
            {
                var t = GetTile(x, y);
                if (!t.IsRoot)
                    continue;

                if (!t.Equals(oldItem))
                    continue;

                DeleteExtensionTiles(t, x, y);
                t.CopyFrom(newItem);
                SetExtensionTiles(t, x, y);
                count++;
            }
        }

        return count;
    }

    /// <summary>
    /// Removes all invalid or dangling extensions within the specified rectangular region.
    /// </summary>
    /// <remarks>
    /// Only extension tiles that are determined to be invalid or dangling are removed.
    /// Valid extension tiles within the region are not changed.
    /// </remarks>
    /// <param name="xmin">The relative x-coordinate of the upper-left corner of the region in which to perform replacements.</param>
    /// <param name="ymin">The relative y-coordinate of the upper-left corner of the region in which to perform replacements.</param>
    /// <param name="width">The width of the region, in tiles. Must be greater than zero.</param>
    /// <param name="height">The height of the region, in tiles. Must be greater than zero.</param>
    /// <returns>The number of extensions that were removed from the specified region.</returns>
    public int ClearDanglingExtensions(in int xmin, in int ymin, in int width, in int height)
    {
        int count = 0;
        for (int x = xmin; x < xmin + width; x++)
        {
            for (int y = ymin; y < ymin + height; y++)
            {
                var t = GetTile(x, y);
                if (IsValidExtension(t, x, y))
                    continue;
                t.Delete();
                count++;
            }
        }
        return count;
    }

    private bool IsValidExtension(Item t, int x, int y)
    {
        if (!t.IsExtension)
            return true;
        var parentX = x - t.ExtensionX;
        var parentY = y - t.ExtensionY;

        try
        {
            var parent = GetTile(parentX, parentY);
            if (parent.ItemId == t.ExtensionItemId)
                return true;
        }
        catch
        {
            // corrupt?
        }
        return false;
    }
}
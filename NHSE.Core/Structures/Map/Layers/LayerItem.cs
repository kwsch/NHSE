using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace NHSE.Core;

public abstract record LayerItem : AcreSelectionGrid
{
    public readonly Item[] Tiles;

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

    public Item GetTile(in int x, in int y) => this[TileInfo.GetTileIndex(x, y)];
    public void SetTile(in int x, in int y, Item tile) => this[TileInfo.GetTileIndex(x, y)] = tile;

    public Item this[int index]
    {
        get => Tiles[index];
        set => Tiles[index] = value;
    }

    public byte[] DumpAll()
    {
        var result = new byte[Tiles.Length * Item.SIZE];
        for (int i = 0; i < Tiles.Length; i++)
            Tiles[i].ToBytesClass().CopyTo(result, i * Item.SIZE);
        return result;
    }

    public void ImportAll(ReadOnlySpan<byte> data)
    {
        var tiles = Item.GetArray(data);
        for (int i = 0; i < tiles.Length; i++)
            Tiles[i].CopyFrom(tiles[i]);
    }

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
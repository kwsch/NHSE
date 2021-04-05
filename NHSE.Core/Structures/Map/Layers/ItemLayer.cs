using System;
using System.Diagnostics;

namespace NHSE.Core
{
    public abstract class ItemLayer : MapGrid
    {
        public readonly Item[] Tiles;

        protected ItemLayer(Item[] tiles, int w, int h) : this(tiles, w, h, w, h)
        {
        }

        protected ItemLayer(Item[] tiles, int w, int h, int gw, int gh) : base(gw, gh, w, h)
        {
            Tiles = tiles;
            Debug.Assert(MaxWidth * MaxHeight == tiles.Length);
        }

        public Item GetTile(in int x, in int y) => this[GetTileIndex(x, y)];

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

        public void ImportAll(byte[] data)
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
            w = type.GetWidth();
            h = type.GetHeight();

            // Rotation
            if ((tile.Rotation & 1) == 1)
            {
                var tmp = w;
                w = h;
                h = tmp;
            }

            // Clamp to grid bounds
            if (x + w - 1 >= MaxWidth)
                w = MaxWidth - x;
            if (y + h - 1 >= MaxHeight)
                h = MaxHeight - y;
        }

        /// <summary>
        /// Checks if writing the <see cref="tile"/> at the specified <see cref="x"/> and <see cref="y"/> coordinates will overlap with any existing tiles.
        /// </summary>
        /// <returns>True if any tile will be overwritten, false if nothing is there.</returns>
        public PlacedItemPermission IsOccupied(Item tile, in int x, in int y)
        {
            var type = ItemInfo.GetItemSize(tile);
            var w = type.GetWidth();
            var h = type.GetHeight();

            if (x + w - 1 >= MaxWidth)
                return PlacedItemPermission.OutOfBounds;
            if (y + h - 1 >= MaxHeight)
                return PlacedItemPermission.OutOfBounds;

            if ((tile.Rotation & 1) == 1)
            {
                var tmp = w;
                w = h;
                h = tmp;
            }

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
#pragma warning disable CA1031 // Do not catch general exception types
            catch
            {
                // corrupt?
            }
#pragma warning restore CA1031 // Do not catch general exception types
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NHSE.Core
{
    public class FieldItemLayer : MapGrid
    {
        public readonly FieldItem[] Tiles;

        public FieldItemLayer(FieldItem[] tiles) : base(32, 32)
        {
            Tiles = tiles;
            Debug.Assert(MapTileCount == tiles.Length);
        }

        public FieldItem GetTile(int x, int y) => this[GetTileIndex(x, y)];
        public FieldItem GetTile(int acreX, int acreY, int gridX, int gridY) => this[GetTileIndex(acreX, acreY, gridX, gridY)];
        public FieldItem GetAcreTile(int acreIndex, int tileIndex) => this[GetAcreTileIndex(acreIndex, tileIndex)];

        public FieldItem this[int index]
        {
            get => Tiles[index];
            set => Tiles[index] = value;
        }

        public byte[] DumpAcre(int acre)
        {
            int count = AcreTileCount;
            var result = new byte[FieldItem.SIZE * count];
            for (int i = 0; i < count; i++)
            {
                var tile = GetAcreTile(acre, i);
                var bytes = tile.ToBytesClass();
                bytes.CopyTo(result, i * FieldItem.SIZE);
            }
            return result;
        }

        public byte[] DumpAllAcres()
        {
            var result = new byte[Tiles.Length * FieldItem.SIZE];
            for (int i = 0; i < Tiles.Length; i++)
                Tiles[i].ToBytesClass().CopyTo(result, i * FieldItem.SIZE);
            return result;
        }

        public void ImportAllAcres(byte[] data)
        {
            var tiles = FieldItem.GetArray(data);
            for (int i = 0; i < tiles.Length; i++)
                Tiles[i].CopyFrom(tiles[i]);
        }

        public void ImportAcre(int acre, byte[] data)
        {
            int count = AcreTileCount;
            var tiles = FieldItem.GetArray(data);
            for (int i = 0; i < count; i++)
            {
                var tile = GetAcreTile(acre, i);
                tile.CopyFrom(tiles[i]);
            }
        }

        public int ClearFieldPlanted(Func<FieldItemKind, bool> criteria) => ClearFieldPlanted(0, 0, MapWidth, MapHeight, criteria);
        public int RemoveAll(Func<FieldItem, bool> criteria) => RemoveAll(0, 0, MapWidth, MapHeight, criteria);
        public int RemoveAll(HashSet<ushort> items) => RemoveAll(0, 0, MapWidth, MapHeight, z => items.Contains(z.DisplayItemId));
        public int RemoveAll(ushort item) => RemoveAll(0, 0, MapWidth, MapHeight, z => z.DisplayItemId == item);

        public int ClearFieldPlanted(int xmin, int ymin, int width, int height, Func<FieldItemKind, bool> criteria)
        {
            int count = 0;
            var fi = FieldItemList.Items;

            for (int x = xmin; x < xmin + width; x++)
            {
                for (int y = ymin; y < ymin + height; y++)
                {
                    var t = GetTile(x, y);
                    var disp = t.DisplayItemId;
                    if (!fi.TryGetValue(disp, out var val))
                        continue;

                    if (!criteria(val.Kind))
                        continue;
                    t.Delete();
                    count++;
                }
            }
            return count;
        }

        public int RemoveAll(int xmin, int ymin, int width, int height, Func<FieldItem, bool> criteria)
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

        public int RemoveAllHoles() => ClearFieldPlanted(z => z == FieldItemKind.UnitIconHole);
        public int RemoveAllWeeds() => ClearFieldPlanted(z => z.IsWeed());
        public int RemoveAllPlants() => ClearFieldPlanted(z => z.IsPlant());
        public int RemoveAllFences() => ClearFieldPlanted(z => z.IsFence());
        public int RemoveAllObjects() => ClearFieldPlanted(_ => true);
        public int RemoveAll() => RemoveAll(_ => true);

        public int RemoveAllHoles(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, z => z == FieldItemKind.UnitIconHole);
        public int RemoveAllWeeds(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, z => z.IsWeed());
        public int RemoveAllPlants(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, z => z.IsPlant());
        public int RemoveAllFences(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, z => z.IsFence());
        public int RemoveAllFlowers(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, z => z.IsFlower());
        public int RemoveAllObjects(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, _ => true);

        public int RemoveAll(int xmin, int ymin, int width, int height) => RemoveAll(xmin, ymin, width, height, _ => true);
        public int RemoveAllShells(int xmin, int ymin, int width, int height) => RemoveAll(xmin, ymin, width, height, z => GameLists.Shells.Contains(z.DisplayItemId));
        public int RemoveAllBranches(int xmin, int ymin, int width, int height) => RemoveAll(xmin, ymin, width, height, z => z.DisplayItemId == 2500);
        public int RemoveAllPlacedItems(int xmin, int ymin, int width, int height) => RemoveAll(xmin, ymin, width,
            height, z => z.DisplayItemId != FieldItem.NONE && !FieldItemList.Items.ContainsKey(z.DisplayItemId));

        public void DeleteExtensionTiles(FieldItem tile, in int x, in int y)
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

        public void SetExtensionTiles(FieldItem tile, in int x, in int y)
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

        private void GetTileWidthHeight(FieldItem tile, int x, int y, out int w, out int h)
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
            if (x + w - 1 >= MapWidth)
                w = MapWidth - x;
            if (y + h - 1 >= MapHeight)
                h = MapHeight - y;
        }

        /// <summary>
        /// Checks if writing the <see cref="tile"/> at the specified <see cref="x"/> and <see cref="y"/> coordinates will overlap with any existing tiles.
        /// </summary>
        /// <returns>True if any tile will be overwritten, false if nothing is there.</returns>
        public FieldItemPermission IsOccupied(FieldItem tile, in int x, in int y)
        {
            var type = ItemInfo.GetItemSize(tile);
            var w = type.GetWidth();
            var h = type.GetHeight();

            if (x + w - 1 >= MapWidth)
                return FieldItemPermission.OutOfBounds;
            if (y + h - 1 >= MapHeight)
                return FieldItemPermission.OutOfBounds;

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
                        return FieldItemPermission.Collision;
                }
            }

            return FieldItemPermission.NoCollision;
        }
    }

    public enum FieldItemPermission
    {
        NoCollision,
        Collision,
        OutOfBounds,
    }
}

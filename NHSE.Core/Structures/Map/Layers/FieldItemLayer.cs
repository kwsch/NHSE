using System;
using System.Collections.Generic;

namespace NHSE.Core
{
    public class FieldItemLayer : ItemLayer
    {
        public const int TilesPerAcreDim = 32;
        public const int FieldItemWidth = TilesPerAcreDim * AcreWidth;
        public const int FieldItemHeight = TilesPerAcreDim * AcreHeight;

        public FieldItemLayer(Item[] tiles) : base(tiles, FieldItemWidth, FieldItemHeight, TilesPerAcreDim, TilesPerAcreDim)
        {
        }

        public Item GetTile(int acreX, int acreY, int gridX, int gridY) => this[GetTileIndex(acreX, acreY, gridX, gridY)];
        public Item GetAcreTile(int acreIndex, int tileIndex) => this[GetAcreTileIndex(acreIndex, tileIndex)];

        public byte[] DumpAcre(int acre)
        {
            int count = GridTileCount;
            var result = new byte[Item.SIZE * count];
            for (int i = 0; i < count; i++)
            {
                var tile = GetAcreTile(acre, i);
                var bytes = tile.ToBytesClass();
                bytes.CopyTo(result, i * Item.SIZE);
            }
            return result;
        }

        public void ImportAcre(int acre, byte[] data)
        {
            int count = GridTileCount;
            var tiles = Item.GetArray(data);
            for (int i = 0; i < count; i++)
            {
                var tile = GetAcreTile(acre, i);
                tile.CopyFrom(tiles[i]);
            }
        }

        public int ClearFieldPlanted(Func<FieldItemKind, bool> criteria) => ClearFieldPlanted(0, 0, MaxWidth, MaxHeight, criteria);
        public int RemoveAll(Func<Item, bool> criteria) => RemoveAll(0, 0, MaxWidth, MaxHeight, criteria);
        public int RemoveAll(HashSet<ushort> items) => RemoveAll(0, 0, MaxWidth, MaxHeight, z => items.Contains(z.DisplayItemId));
        public int RemoveAll(ushort item) => RemoveAll(0, 0, MaxWidth, MaxHeight, z => z.DisplayItemId == item);

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

        public int ModifyAll(int xmin, int ymin, int width, int height, Func<Item, bool> criteria, Action<Item> action)
        {
            int count = 0;
            for (int x = xmin; x < xmin + width; x++)
            {
                for (int y = ymin; y < ymin + height; y++)
                {
                    var t = GetTile(x, y);
                    if (!criteria(t))
                        continue;
                    action(t);
                    count++;
                }
            }
            return count;
        }

        public int RemoveAllHoles(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, z => z == FieldItemKind.UnitIconHole);
        public int RemoveAllWeeds(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, z => z.IsWeed());
        public int RemoveAllTrees(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, z => z.IsTree());
        public int RemoveAllPlants(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, z => z.IsPlant());
        public int RemoveAllFences(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, z => z.IsFence());
        public int RemoveAllFlowers(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, z => z.IsFlower());
        public int RemoveAllBushes(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, z => z.IsBush());
        public int RemoveAllObjects(int xmin, int ymin, int width, int height) => ClearFieldPlanted(xmin, ymin, width, height, _ => true);

        public int RemoveAll(int xmin, int ymin, int width, int height) => RemoveAll(xmin, ymin, width, height, _ => true);
        public int RemoveAllShells(int xmin, int ymin, int width, int height) => RemoveAll(xmin, ymin, width, height, z => GameLists.Shells.Contains(z.DisplayItemId));
        public int RemoveAllBranches(int xmin, int ymin, int width, int height) => RemoveAll(xmin, ymin, width, height, z => z.DisplayItemId == 2500);
        public int RemoveAllPlacedItems(int xmin, int ymin, int width, int height) => RemoveAll(xmin, ymin, width,
            height, z => !z.IsNone && !FieldItemList.Items.ContainsKey(z.DisplayItemId));

        public int WaterAllFlowers(int xmin, int ymin, int width, int height, bool all)
        {
            var fi = FieldItemList.Items;

            bool IsFlowerWaterable(Item item)
            {
                if (item.IsNone)
                    return false;
                if (!item.IsRoot)
                    return false;
                if (!fi.TryGetValue(item.ItemId, out var def))
                    return false;
                if (!def.Kind.IsFlower())
                    return false;
                return true;
            }

            return ModifyAll(xmin, ymin, width, height, IsFlowerWaterable, z => z.Water(all));
        }
    }
}

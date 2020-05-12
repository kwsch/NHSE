using System;
using System.Collections.Generic;

namespace NHSE.Core
{
    public class FieldItemLayer : ItemLayer
    {
        public FieldItemLayer(Item[] tiles) : base(tiles, 32 * AcreWidth, 32 * AcreHeight, 32, 32)
        {
        }

        public Item GetTile(int acreX, int acreY, int gridX, int gridY) => this[GetTileIndex(acreX, acreY, gridX, gridY)];
        public Item GetAcreTile(int acreIndex, int tileIndex) => this[GetAcreTileIndex(acreIndex, tileIndex)];

        public byte[] DumpAcre(int acre)
        {
            int count = AcreTileCount;
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
            int count = AcreTileCount;
            var tiles = Item.GetArray(data);
            for (int i = 0; i < count; i++)
            {
                var tile = GetAcreTile(acre, i);
                tile.CopyFrom(tiles[i]);
            }
        }

        public int ClearFieldPlanted(Func<FieldItemKind, bool> criteria) => ClearFieldPlanted(0, 0, MapWidth, MapHeight, criteria);
        public int RemoveAll(Func<Item, bool> criteria) => RemoveAll(0, 0, MapWidth, MapHeight, criteria);
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
            height, z => z.DisplayItemId != Item.NONE && !FieldItemList.Items.ContainsKey(z.DisplayItemId));
    }
}

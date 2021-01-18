using System;
using System.Collections.Generic;
using System.Linq;

namespace NHSE.Core
{
    /// <summary>
    /// Converts <see cref="Item"/> into columns of writable Item tiles.
    /// </summary>
    public static class FieldItemDropper
    {
        private const int MapHeight = FieldItemLayer.FieldItemHeight;
        private const int MapWidth = FieldItemLayer.FieldItemWidth;

        // Each dropped item is a 2x2 square, with the top left tile being the root node, and the other 3 being extensions pointing back to the root.

        public static bool CanFitDropped(int x, int y, int count, int vStride)
        {
            if (2 * (Math.Max(16, y) + vStride) > MapHeight - 32)
                return false;

            var xStride = count / vStride;
            if (2 * (Math.Max(16, x) + xStride) > MapWidth - 32)
                return false;

            return count < (MapHeight * MapWidth / 32);
        }

        public static IReadOnlyList<FieldItemColumn> InjectItemsAsDropped(int mapX, int mapY, IReadOnlyList<Item> item)
        {
            int yStride = (item.Count > 16) ? 16 : item.Count;
            return InjectItemsAsDropped(mapX, mapY, item, yStride);
        }

        public static IReadOnlyList<FieldItemColumn> InjectItemsAsDropped(int mapX, int mapY, IReadOnlyList<Item> item, int yStride)
        {
            var xStride = item.Count / yStride;
            List<FieldItemColumn> result = new(yStride * xStride);
            for (int i = 0; i < xStride; i++)
            {
                var x = mapX + (i * 2);
                var y = mapY;
                var itemSlice = item.Skip(i * yStride).Take(yStride).ToArray();

                // Root+ExtensionY
                var offset = GetTileOffset(x, y);
                var data = GetColumnRoot(itemSlice);
                var column = new FieldItemColumn(x, y, offset, data);
                result.Add(column);

                // Ex X/XY
                ++x;
                offset = GetTileOffset(x, y);
                data = GetColumnExtension(itemSlice);
                column = new FieldItemColumn(x, y, offset, data);
                result.Add(column);
            }
            return result;
        }

        private static byte[] GetColumnRoot(Item[] items)
        {
            var col = new Item[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                var idx = i * 2;
                col[idx] = GetDroppedItem(item);
                col[idx + 1] = GetExtension(item, 0, 1);
            }
            return Item.SetArray(col);
        }

        private static byte[] GetColumnExtension(Item[] items)
        {
            var col = new Item[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                var idx = i * 2;
                col[idx] = GetExtension(item, 1, 0);
                col[idx + 1] = GetExtension(item, 1, 1);
            }
            return Item.SetArray(col);
        }

        private static int GetTileOffset(int x, int y)
        {
            return Item.SIZE * (y + (x * MapHeight));
        }

        private static Item GetDroppedItem(Item item)
        {
            var copy = new Item();
            copy.CopyFrom(item);
            copy.ClearFlags();
            copy.IsDropped = true;
            return copy;
        }

        private static Item GetExtension(Item item, byte x, byte y) => new(Item.EXTENSION) { ExtensionItemId = item.ItemId, ExtensionX = x, ExtensionY = y };
    }
}

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

        /// <inheritdoc cref="CanFitDropped(int,int,int,int,int,int,int,int)"/>
        /// <param name="x">Raw X coordinate for the top-left item root tile.</param>
        /// <param name="y">Raw Y coordinate for the top-left item root tile.</param>
        /// <param name="totalCount">Total count of items to be dropped (not tiles).</param>
        /// <param name="yCount">Count of items tall the overall spawn-rectangle is.</param>
        /// <param name="borderX">Excluded outer tile count. Useful for enforcing that beach acre tiles are skipped.</param>
        /// <param name="borderY">Excluded outer tile count. Useful for enforcing that beach acre tiles are skipped.</param>
        public static bool CanFitDropped(int x, int y, int totalCount, int yCount, int borderX, int borderY)
        {
            return CanFitDropped(x, y, totalCount, yCount, borderX, borderX, borderY, borderY);
        }

        /// <summary>
        /// Checks if the requested <see cref="totalCount"/> of items can be dropped on the field item layer. Does not check terrain or existing items.
        /// </summary>
        /// <remarks>Coordinates should be 32x32 style instead of 16x16.</remarks>
        /// <param name="x">Raw X coordinate for the top-left item root tile.</param>
        /// <param name="y">Raw Y coordinate for the top-left item root tile.</param>
        /// <param name="totalCount">Total count of items to be dropped (not tiles).</param>
        /// <param name="yCount">Count of items tall the overall spawn-rectangle is.</param>
        /// <param name="leftX">Excluded outer tile count. Useful for enforcing that beach acre tiles are skipped.</param>
        /// <param name="rightX">Excluded outer tile count. Useful for enforcing that beach acre tiles are skipped.</param>
        /// <param name="topY">Excluded outer tile count. Useful for enforcing that beach acre tiles are skipped.</param>
        /// <param name="botY">Excluded outer tile count. Useful for enforcing that beach acre tiles are skipped.</param>
        /// <returns>True if can fit, false if not.</returns>
        public static bool CanFitDropped(int x, int y, int totalCount, int yCount, int leftX, int rightX, int topY, int botY)
        {
            var xCount = totalCount / yCount;
            if (x < leftX || (x + (xCount * 2)) > MapWidth - rightX)
                return false;
            if (y < topY || (y + (yCount * 2)) > MapHeight - botY)
                return false;

            return totalCount < (MapHeight * MapWidth / 32);
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

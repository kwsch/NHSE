using System;
using System.Collections.Generic;
using System.Linq;

namespace NHSE.Core
{
    /// <summary>
    /// Handles operations for parsing the player inventory.
    /// </summary>
    /// <remarks>
    /// Player Inventory is comprised of multiple values, which we won't bother reimplementing as a convertible data structure.
    /// <br>Refer to GSavePlayerItemBaggage's ItemBag &amp; ItemPocket in the dumped c-structure schema.</br>
    /// </remarks>
    public static class PlayerItemSet
    {
        private const int ItemSet_Quantity = 2; // Pouch (Bag) & Pocket.
        private const int ItemSet_ItemCount = 20; // 20 items per item set.
        private const int ItemSet_ItemSize = Item.SIZE * ItemSet_ItemCount;
        private const int ItemSet_MetaSize = 4 + ItemSet_ItemCount;
        private const int ItemSet_TotalSize = (ItemSet_ItemSize + ItemSet_MetaSize) * ItemSet_Quantity;
        private const int ShiftToTopOfStructure = -ItemSet_MetaSize - (Item.SIZE * ItemSet_ItemCount); // shifts slot1 offset => top of data structure

        /// <summary>
        /// Gets the Offset and Size to read from based on the Item 1 RAM offset.
        /// </summary>
        /// <param name="slot1">Item Slot 1 offset in RAM</param>
        /// <param name="offset">Offset to read from</param>
        /// <param name="length">Length of data to read from <see cref="offset"/></param>
        public static void GetOffsetLength(uint slot1, out uint offset, out int length)
        {
            offset = (uint)((int)slot1 + ShiftToTopOfStructure);
            length = ItemSet_TotalSize;
        }

        /// <summary>
        /// Compares the raw data to the expected data layout.
        /// </summary>
        /// <param name="data">Raw RAM from the game from the offset read (as per <see cref="GetOffsetLength"/>).</param>
        /// <returns>True if valid, false if not valid or corrupt.</returns>
        public static bool ValidateItemBinary(byte[] data)
        {
            // Check the unlocked slot count -- expect 0,10,20
            var bagCount = BitConverter.ToUInt32(data, ItemSet_ItemSize);
            if (bagCount > ItemSet_ItemCount || bagCount % 10 != 0) // pouch21-39 count
                return false;

            var pocketCount = BitConverter.ToUInt32(data, ItemSet_ItemSize + ItemSet_MetaSize + ItemSet_ItemSize);
            if (pocketCount != ItemSet_ItemCount) // pouch0-19 count should be 20.
                return false;

            // Check the item wheel binding -- expect -1 or [0,7]
            // Disallow duplicate binds!
            // Don't bother checking that bind[i] (when ! -1) is not NONE at items[i]. We don't need to check everything!
            var bound = new List<byte>();
            if (!ValidateBindList(data, ItemSet_ItemSize + 4, bound))
                return false;
            if (!ValidateBindList(data, ItemSet_ItemSize + 4 + (ItemSet_ItemSize + ItemSet_MetaSize), bound))
                return false;

            return true;
        }

        private static bool ValidateBindList(byte[] data, int bindStart, ICollection<byte> bound)
        {
            for (int i = 0; i < ItemSet_ItemCount; i++)
            {
                var bind = data[bindStart + i];
                if (bind == 0xFF) // Not bound
                    continue;
                if (bind > 7) // Only [0,7] permitted as the wheel has 8 spots
                    return false;
                if (bound.Contains(bind)) // Wheel index is already bound to another item slot
                    return false;

                bound.Add(bind);
            }

            return true;
        }

        /// <summary>
        /// Reads the items present in the player inventory packet and returns the list of items.
        /// </summary>
        /// <param name="data">Player Inventory packet</param>
        public static Item[] ReadPlayerInventory(byte[] data)
        {
            var items = GetEmptyItemArray(40);
            ReadPlayerInventory(data, items);
            return items;
        }

        private static Item[] GetEmptyItemArray(int count)
        {
            var items = new Item[count];
            for (int i = 0; i < items.Length; i++)
                items[i] = new Item();
            return items;
        }

        /// <summary>
        /// Reads the items present in the player inventory packet into the <see cref="destination"/> list of items.
        /// </summary>
        /// <param name="data">Player Inventory packet</param>
        /// <param name="destination">40 Item array</param>
        public static void ReadPlayerInventory(byte[] data, IReadOnlyList<Item> destination)
        {
            var pocket2 = destination.Take(20).ToArray();
            var pocket1 = destination.Skip(20).ToArray();
            var p1 = Item.GetArray(data.Slice(0, ItemSet_ItemSize));
            var p2 = Item.GetArray(data.Slice(ItemSet_ItemSize + 0x18, ItemSet_ItemSize));

            for (int i = 0; i < pocket1.Length; i++)
                pocket1[i].CopyFrom(p1[i]);

            for (int i = 0; i < pocket2.Length; i++)
                pocket2[i].CopyFrom(p2[i]);
        }

        /// <summary>
        /// Writes the items in the <see cref="source"/> list of items to the player inventory packet.
        /// </summary>
        /// <param name="data">Player Inventory packet</param>
        /// <param name="source">40 Item array</param>
        public static void WritePlayerInventory(byte[] data, IReadOnlyList<Item> source)
        {
            var pocket2 = source.Take(20).ToArray();
            var pocket1 = source.Skip(20).ToArray();
            var p1 = Item.SetArray(pocket1);
            var p2 = Item.SetArray(pocket2);

            p1.CopyTo(data, 0);
            p2.CopyTo(data, ItemSet_ItemSize + 0x18);
        }
    }
}

using System.Collections.Generic;

namespace NHSE.Core
{
    public class InventorySet
    {
        public readonly InventoryType Type;
        public readonly IReadOnlyList<Item> Items;

        public InventorySet(InventoryType type, IReadOnlyList<Item> items)
        {
            Type = type;
            Items = items;
        }
    }
}
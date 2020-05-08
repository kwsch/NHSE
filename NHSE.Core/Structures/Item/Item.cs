using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 1)]
    public class Item : IHeldItem, ICopyableItem<IHeldItem>
    {
        public static readonly Item NO_ITEM = new Item {ItemId = NONE};
        public const ushort NONE = 0xFFFE;
        public const ushort DIYRecipe = 0x16A2;
        public const int SIZE = 8;

        private static readonly ushort[] resolvedItemIdArray =
        {
            0x1E13, 0x1E14, 0x1E15, 0x1E16, 0x1E17, 0x1E18, 0x1E19, 0x1E1A,
            0x1E1B, 0x1E1C, 0x1E1D, 0x1E1E, 0x1E1F, 0x1E20, 0x1E21, 0x1E22
        };

        [field: FieldOffset(0)] public ushort ItemId { get; set; }
        [field: FieldOffset(2)] public byte SystemParam { get; set; }
        [field: FieldOffset(3)] public byte AdditionalParam { get; set; }
        [field: FieldOffset(4)] public int FreeParam { get; set; }

        #region Stackable Items
        [field: FieldOffset(4)] public ushort Count { get; set; }
        [field: FieldOffset(6)] public ushort UseCount { get; set; }
        #endregion

        #region Customizable Items
        public int BodyType
        {
            get => FreeParam & 7;
            set => FreeParam = (FreeParam & ~7) | (value & 7);
        }

        public int PatternSource // see RemakeDesignSource
        {
            get => (FreeParam >> 3) & 3;
            set => FreeParam = (FreeParam & ~0x18) | ((value & 3) << 3);
        }

        public int PatternChoice
        {
            get => FreeParam >> 5;
            set => FreeParam = (FreeParam & 0x1F) | ((value & 0x7FF) << 5);
        }
        #endregion

        #region Flowers

        // flowers only -- this is really just a packed u32
        [field: FieldOffset(4)] public FlowerGene Genes { get; set; }
        [field: FieldOffset(5)] private ushort Watered { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        [field: FieldOffset(7)] private byte Watered2 { get; set; }
        // offset 7 is unused bits

        public int DaysWatered
        {
            get => Watered & 0x1F;
            set => Watered = (ushort)((Watered & 0xFFE0) | (value & 0x1F));
        }

        public bool GetIsWateredByVisitor(int visitor)
        {
            if ((uint)visitor >= 10)
                throw new ArgumentOutOfRangeException(nameof(visitor));

            var shift = 5 + visitor;
            return (Watered & (1 << shift)) != 0;
        }

        public void SetIsWateredByVisitor(int visitor, bool value = true)
        {
            if ((uint)visitor >= 10)
                throw new ArgumentOutOfRangeException(nameof(visitor));

            var shift = 5 + visitor;
            var bit = (1 << shift);
            var mask = ~bit;

            Watered = (ushort)((Watered & mask) | (value ? bit : 0));
        }

        public bool IsWatered
        {
            get => ((Watered >> 15) & 1) == 1;
            set => Watered = (ushort)((Watered & 0x7FFF) | (value ? 0x8000 : 0));
        }

        public bool IsWateredGold
        {
            get => (Watered2 & 1) == 1;
            set => Watered2 = (byte)((Watered2 & 0xFE) | (value ? 1 : 0));
        }

        public void Water(bool all = false)
        {
            if (all)
            {
                Watered = 0xFFFF;
                Watered2 = 1;
                return;
            }

            DaysWatered = 31;
            IsWatered = true;
        }

        #endregion

        public ItemType Type => (ItemType) (AdditionalParam & 3);
        public int ReservedIndex => (AdditionalParam >> 2) & 0xF;

        public Item() { } // marshalling

        public Item(ushort itemId = NONE, byte systemParam = 0, byte additionalParam = 0, byte count = 0, ushort useCount = 0)
        {
            ItemId = itemId;
            SystemParam = systemParam;
            AdditionalParam = additionalParam;
            Count = count;
            UseCount = useCount;
        }

        public void Delete()
        {
            ItemId = NONE;
            SystemParam = AdditionalParam = 0;
            Count = UseCount = 0;
        }

        public virtual int Size => SIZE;

        public void CopyFrom(IHeldItem item)
        {
            ItemId = item.ItemId;
            SystemParam = item.SystemParam;
            AdditionalParam = item.AdditionalParam;
            Count = item.Count;
            UseCount = item.UseCount;
        }

        public static Item[] GetArray(byte[] data) => data.GetArray<Item>(SIZE);
        public static byte[] SetArray(IReadOnlyList<Item> data) => data.SetArray(SIZE);

        public ushort GetInventoryNameFromFlags()
        {
            if (ItemId == 0x16A1 || ItemId == 0x3100)
                return ItemId;

            return Type switch
            {
                ItemType.Reserved => resolvedItemIdArray[ReservedIndex],
                ItemType.Present => 0x1180,
                ItemType.Delivery => 0x1225,
                _ => ItemId,
            };
        }
    }
}

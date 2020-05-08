using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 1)]
    public class Item : ICopyableItem<Item>
    {
        public static readonly Item NO_ITEM = new Item {ItemId = NONE};
        public const ushort NONE = 0xFFFE;
        public const ushort EXTENSION = 0xFFFD;
        public const ushort FieldItemMin = 60_000;

        public const ushort MessageBottle = 0x16A1;
        public const ushort DIYRecipe = 0x16A2;
        public const ushort MessageBottleEgg = 0x3100;
        public const int SIZE = 8;

        private static readonly ushort[] WrappingRedirect =
        {
            0x1E13, 0x1E14, 0x1E15, 0x1E16, 0x1E17, 0x1E18, 0x1E19, 0x1E1A,
            0x1E1B, 0x1E1C, 0x1E1D, 0x1E1E, 0x1E1F, 0x1E20, 0x1E21, 0x1E22
        };

        [field: FieldOffset(0)] public ushort ItemId { get; set; }
        [field: FieldOffset(2)] public byte SystemParam { get; set; }
        [field: FieldOffset(3)] public byte AdditionalParam { get; set; }
        [field: FieldOffset(4)] public int FreeParam { get; set; }

        public int Rotation => SystemParam & 3;
        public bool IsBuried => (SystemParam & 4) != 0;

        public ItemWrapping WrappingType => (ItemWrapping)(AdditionalParam & 3);
        public int WrappingIndex => (AdditionalParam >> 2) & 0xF;

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

        #region Item Extensions
        public ushort DisplayItemId => IsExtension ? ExtensionItemId : ItemId;
        public bool IsNone => ItemId == NONE;
        public bool IsExtension => ItemId == EXTENSION;
        public bool IsRoot => ItemId < EXTENSION;
        [field: FieldOffset(4)] public ushort ExtensionItemId { get; set; }
        [field: FieldOffset(6)] public byte ExtensionX { get; set; }
        [field: FieldOffset(7)] public byte ExtensionY { get; set; }

        public void SetAsExtension(Item tile, byte x, byte y)
        {
            ItemId = EXTENSION;
            SystemParam = 0;
            AdditionalParam = 0;
            ExtensionX = x;
            ExtensionY = y;
            ExtensionItemId = tile.ItemId;
        }
        #endregion

        public Item() { } // marshalling

        public Item(ushort itemId = NONE)
        {
            ItemId = itemId;
        }

        public void Delete()
        {
            ItemId = NONE;
            SystemParam = AdditionalParam = 0;
            FreeParam = 0;
        }

        public virtual int Size => SIZE;

        public void CopyFrom(Item item)
        {
            ItemId = item.ItemId;
            SystemParam = item.SystemParam;
            AdditionalParam = item.AdditionalParam;
            FreeParam = item.FreeParam;
        }

        public static Item[] GetArray(byte[] data) => data.GetArray<Item>(SIZE);
        public static byte[] SetArray(IReadOnlyList<Item> data) => data.SetArray(SIZE);

        public ushort GetInventoryNameFromFlags()
        {
            if (ItemId == MessageBottle || ItemId == MessageBottleEgg)
                return ItemId;

            return WrappingType switch
            {
                ItemWrapping.Reserved => WrappingRedirect[WrappingIndex],
                ItemWrapping.Present => 0x1180,
                ItemWrapping.Delivery => 0x1225,
                _ => ItemId,
            };
        }
    }
}

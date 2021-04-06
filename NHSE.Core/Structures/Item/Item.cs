using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 1)]
    public class Item : ICopyableItem<Item>, IEquatable<Item>
    {
        public static readonly Item NO_ITEM = new() {ItemId = NONE};
        public const ushort NONE = 0xFFFE;
        public const ushort EXTENSION = 0xFFFD;
        public const ushort FieldItemMin = 60_000;
        public const ushort LLOYD = 63_005;

        public const ushort MessageBottle = 0x16A1;
        public const ushort DIYRecipe = 0x16A2;
        public const ushort MessageBottleEgg = 0x3100;
        public const int SIZE = 8;

        [field: FieldOffset(0)] public ulong RawValue { get; set; }

        [field: FieldOffset(0)] public ushort ItemId { get; set; }
        [field: FieldOffset(2)] public byte SystemParam { get; set; }
        [field: FieldOffset(3)] public byte AdditionalParam { get; set; }
        [field: FieldOffset(4)] public int FreeParam { get; set; }

        public void ClearFlags() => SystemParam = 0;
        public int Rotation   { get => SystemParam & 3; set => SystemParam = (byte)((SystemParam & ~3) | (value & 3)); }
        public bool IsBuried  { get => (SystemParam & 0x04) != 0; set => SystemParam = (byte) ((SystemParam & ~0x04) | (value ? 0x04 : 0)); }
        public bool Is_08     { get => (SystemParam & 0x08) != 0; set => SystemParam = (byte) ((SystemParam & ~0x08) | (value ? 0x08 : 0)); }
        public bool Is_10     { get => (SystemParam & 0x10) != 0; set => SystemParam = (byte) ((SystemParam & ~0x10) | (value ? 0x10 : 0)); }
        public bool IsDropped { get => (SystemParam & 0x20) != 0; set => SystemParam = (byte) ((SystemParam & ~0x20) | (value ? 0x20 : 0)); }
        public bool Is_40     { get => (SystemParam & 0x40) != 0; set => SystemParam = (byte) ((SystemParam & ~0x40) | (value ? 0x40 : 0)); }
        public bool Is_80     { get => (SystemParam & 0x80) != 0; set => SystemParam = (byte) ((SystemParam & ~0x80) | (value ? 0x80 : 0)); }

        #region Flag1 (Wrapping / Etc)
        public bool IsWrapped
        {
            get
            {
                if (AdditionalParam == 0)
                    return false;
                var id = DisplayItemId;
                return id != MessageBottle && id != MessageBottleEgg;
            }
        }

        public ItemWrapping WrappingType
        {
            get
            {
                var value = (ItemWrapping) (AdditionalParam & 3);
                if (value is ItemWrapping.Delivery && WrappingPaper is ItemWrappingPaper.Black)
                    return ItemWrapping.Festive;
                return value;
            }
            set
            {
                if (value is ItemWrapping.Festive)
                {
                    value = ItemWrapping.Delivery; // 3 (11)
                    WrappingPaper = ItemWrappingPaper.Black; // 15 (1111)
                }
                AdditionalParam = (byte) ((AdditionalParam & ~3) | ((byte) value & 3));
            }
        }

        public ItemWrappingPaper WrappingPaper
        {
            get => (ItemWrappingPaper) ((AdditionalParam >> 2) & 0xF);
            set => AdditionalParam = (byte)((AdditionalParam & 3) | ((byte)value & 0xF) << 2);
        }

        public void SetWrapping(ItemWrapping wrap, ItemWrappingPaper color, bool showItem = false, bool item80 = false)
        {
            if (wrap is ItemWrapping.Nothing or > ItemWrapping.Festive)
            {
                AdditionalParam = 0;
                return;
            }
            WrappingPaper = wrap == ItemWrapping.WrappingPaper ? color : 0;
            WrappingType = wrap;
            WrappingShowItem = showItem;
            Wrapping80 = item80;
        }

        public bool WrappingShowItem
        {
            get => (AdditionalParam & 0x40) != 0;
            set => AdditionalParam = (byte)((AdditionalParam & ~0x40) | (value ? 1 << 6 : 0));
        }

        public bool Wrapping80
        {
            get => (AdditionalParam & 0x80) != 0;
            set => AdditionalParam = (byte)((AdditionalParam & ~0x80) | (value ? 1 << 7 : 0));
        }
        #endregion

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
        public bool IsFieldItem => IsRoot && ItemId >= 60_000;
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
        public Item(ulong raw) => RawValue = raw;
        public Item(ushort itemId = NONE) => ItemId = itemId;

        public void Delete() => RawValue = NONE; // clears & sets the two lowest byte as ItemID

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

        public ushort GetWrappedItemName()
        {
            return WrappingType switch
            {
                ItemWrapping.WrappingPaper => (ushort) (0x1E13 + (ushort)WrappingPaper),
                ItemWrapping.Present => 0x1180,
                ItemWrapping.Delivery => 0x1225,
                _ => ItemId,
            };
        }

        public bool Equals(Item? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return RawValue == other.RawValue;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Item) obj);
        }

        public override int GetHashCode() => RawValue.GetHashCode();
        public static bool operator ==(Item? left, Item? right) => Equals(left, right);
        public static bool operator !=(Item? left, Item? right) => !Equals(left, right);
    }
}

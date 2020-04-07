using System;

namespace NHSE.Core
{
    /// <summary>
    /// Offset info and object retrieval logic for <see cref="MainSave"/>
    /// </summary>
    public abstract class MainSaveOffsets
    {
        public abstract int Villager { get; }
        public const int VillagerSize = 0x12AB0;
        public const int VillagerCount = 10;

        public abstract int Patterns { get; }
        public const int PatternCount = 50;

        public abstract int Buildings { get; }
        public const int BuildingCount = 40; // actual count unknown, max may be 46

        public abstract int RecycleBin { get; }
        public const int RecycleBinCount = 40;

        public abstract int TurnipExchange { get; }

        public abstract int FieldItem { get; }
        public abstract int Acres { get; }
        public abstract int Terrain { get; }

        public static MainSaveOffsets GetOffsets(FileHeaderInfo Info)
        {
            var rev = Info.GetKnownRevisionIndex();
            return rev switch
            {
                0 => new MainSaveOffsets10(),
                1 => new MainSaveOffsets11(),
                2 => new MainSaveOffsets11(),
                3 => new MainSaveOffsets11(),
                4 => new MainSaveOffsets11(),
                5 => new MainSaveOffsets11(),
                _ => throw new IndexOutOfRangeException("Unknown revision!"),
            };
        }

        public DesignPattern ReadPattern(byte[] data, int index)
        {
            if ((uint)index >= PatternCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            var v = data.Slice(Patterns + (index * DesignPattern.SIZE), DesignPattern.SIZE);
            return new DesignPattern(v);
        }

        public void WritePattern(DesignPattern p, byte[] data, int index)
        {
            if ((uint)index >= PatternCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            p.Data.CopyTo(data, Patterns + (index * DesignPattern.SIZE));
        }

        public Villager ReadVillager(byte[] data, int index)
        {
            if ((uint)index >= VillagerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            var v = data.Slice(Villager + (index * VillagerSize), VillagerSize);
            return new Villager(v);
        }

        public void WriteVillager(Villager v, byte[] data, int index)
        {
            if ((uint)index >= VillagerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            v.Data.CopyTo(data, Villager + (index * VillagerSize));
        }
    }
}
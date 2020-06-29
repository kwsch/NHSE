using System;

namespace NHSE.Core
{
    /// <summary>
    /// Offset info and object retrieval logic for <see cref="MainSave"/>
    /// </summary>
    public abstract class MainSaveOffsets
    {
        public const int PlayerCount = 8;
        public const int VillagerCount = 10;
        public const int PatternCount = 50;
        public const int PatternTailorCount = 8;
        public const int BuildingCount = 46;
        public const int RecycleBinCount = 40;

        public abstract int Animal { get; }

        public abstract int LandMyDesign { get; }
        public abstract int PatternsPRO { get; }
        public abstract int PatternFlag { get; }
        public abstract int PatternTailor { get; }

        public abstract int WeatherArea { get; }
        public abstract int WeatherRandSeed { get; }

        public abstract int MainFieldStructure { get; }

        public abstract int EventFlagLand { get; }
        public abstract int FieldItem { get; }
        public abstract int LandMakingMap { get; }
        public abstract int OutsideField { get; }
        public abstract int MyDesignMap { get; }
        public abstract int PlayerHouseList { get; }
        public abstract int NpcHouseList { get; }
        public abstract int ShopKabu { get; }
        public abstract int Museum { get; }
        public abstract int Visitor { get; }

        public abstract int SaveFg { get; }
        public abstract int BulletinBoard { get; }
        public abstract int AirportThemeColor { get; }

        public abstract int LostItemBox { get; }
        public abstract int LastSavedTime { get; }

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
                6 => new MainSaveOffsets12(),
                7 => new MainSaveOffsets12(),
                _ => throw new IndexOutOfRangeException("Unknown revision!"),
            };
        }

        public DesignPattern ReadPattern(byte[] data, int index)
        {
            if ((uint)index >= PatternCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            return ReadPatternAtOffset(data, LandMyDesign + (index * DesignPattern.SIZE));
        }

        public static DesignPattern ReadPatternAtOffset(byte[] data, int offset)
        {
            var v = data.Slice(offset, DesignPattern.SIZE);
            return new DesignPattern(v);
        }

        public void WritePattern(DesignPattern p, byte[] data, int index)
        {
            if ((uint)index >= PatternCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            p.Data.CopyTo(data, LandMyDesign + (index * DesignPattern.SIZE));
        }

        public DesignPatternPRO ReadPatternPRO(byte[] data, int index)
        {
            if ((uint)index >= PatternCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            var ofs = PatternsPRO + (index * DesignPatternPRO.SIZE);
            return ReadPatternPROAtOffset(data, ofs);
        }

        public static DesignPatternPRO ReadPatternPROAtOffset(byte[] data, int ofs)
        {
            var v = data.Slice(ofs, DesignPatternPRO.SIZE);
            return new DesignPatternPRO(v);
        }

        public void WritePatternPRO(DesignPatternPRO p, byte[] data, int index)
        {
            if ((uint)index >= PatternCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            p.Data.CopyTo(data, PatternsPRO + (index * DesignPatternPRO.SIZE));
        }

        public Villager ReadVillager(byte[] data, int index)
        {
            if ((uint)index >= VillagerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            var v = data.Slice(Animal + (index * Villager.SIZE), Villager.SIZE);
            return new Villager(v);
        }

        public void WriteVillager(Villager v, byte[] data, int index)
        {
            if ((uint)index >= VillagerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            v.Data.CopyTo(data, Animal + (index * Villager.SIZE));
        }
    }
}
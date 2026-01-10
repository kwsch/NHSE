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
        public virtual int PatternCount => PatternCount1;
        protected const int PatternCount1 = 50;
        protected const int PatternCount2 = 100;
        public const int PatternTailorCount = 8;
        public const int BuildingCount = 46;
        public const int RecycleBinCount = 40;

        public abstract int Animal { get; }

        public abstract int LandMyDesign { get; }
        public abstract int PatternsPRO { get; }
        public abstract int PatternFlag { get; }
        public abstract int PatternTailor { get; }

        public abstract int PatternsEditFlagStart { get; }
        public abstract int PatternsProEditFlagStart { get; }

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

        public abstract int VillagerSize { get; }
        public abstract int VillagerHouseSize { get; }
        public abstract int PlayerHouseSize { get; }
        public abstract int PlayerRoomSize { get; }

        public abstract IVillager ReadVillager(byte[] data);
        public abstract IVillagerHouse ReadVillagerHouse(byte[] data);
        public abstract IPlayerHouse ReadPlayerHouse(byte[] data);
        public abstract IPlayerRoom ReadPlayerRoom(byte[] data);

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
                8 => new MainSaveOffsets13(),
                9 => new MainSaveOffsets13(),
                10 => new MainSaveOffsets14(),
                11 => new MainSaveOffsets14(),
                12 => new MainSaveOffsets14(),
                13 => new MainSaveOffsets15(),
                14 => new MainSaveOffsets15(),
                15 => new MainSaveOffsets16(),
                16 => new MainSaveOffsets17(),
                17 => new MainSaveOffsets18(),
                18 => new MainSaveOffsets19(),
                19 => new MainSaveOffsets110(),
                20 => new MainSaveOffsets111(),
                21 => new MainSaveOffsets111(),
                22 => new MainSaveOffsets20(),
                23 => new MainSaveOffsets20(),
                24 => new MainSaveOffsets20(),
                25 => new MainSaveOffsets20(),
                26 => new MainSaveOffsets20(),
                27 => new MainSaveOffsets20(),
                28 => new MainSaveOffsets20(),
                29 => new MainSaveOffsets20(),
                30 => new MainSaveOffsets20(),
                _ => throw new IndexOutOfRangeException("Unknown revision!" + Environment.NewLine + Info),
            };
        }

        public DesignPattern ReadPattern(ReadOnlySpan<byte> data, int index)
        {
            if ((uint)index >= PatternCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            return ReadPatternAtOffset(data, LandMyDesign + (index * DesignPattern.SIZE));
        }

        public static DesignPattern ReadPatternAtOffset(ReadOnlySpan<byte> data, int offset)
        {
            var v = data.Slice(offset, DesignPattern.SIZE).ToArray();
            return new DesignPattern(v);
        }

        public void WritePattern(DesignPattern p, Span<byte> data, int index, Span<byte> playerID, Span<byte> townID)
        {
            if ((uint)index >= PatternCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            playerID.CopyTo(p.Data.AsSpan(0x54)); // overwrite playerID bytes so player owns
            townID.CopyTo(p.Data.AsSpan(0x38)); // overwrite townID bytes so player owns
            byte[] wipeflag = [0x02, 0xEE, 0x00, 0x00]; // wipe so player owns
            wipeflag.CopyTo(p.Data.AsSpan(0x70));
            p.Data.CopyTo(data[(LandMyDesign + (index * DesignPattern.SIZE))..]);
            byte[] editedflag = [0x00];
            editedflag.CopyTo(data[(PatternsEditFlagStart + index)..]); // set edited flag for name import to work
        }

        public DesignPatternPRO ReadPatternPRO(ReadOnlySpan<byte> data, int index)
        {
            if ((uint)index >= PatternCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            var ofs = PatternsPRO + (index * DesignPatternPRO.SIZE);
            return ReadPatternPROAtOffset(data, ofs);
        }

        public static DesignPatternPRO ReadPatternPROAtOffset(ReadOnlySpan<byte> data, int ofs)
        {
            var v = data.Slice(ofs, DesignPatternPRO.SIZE).ToArray();
            return new DesignPatternPRO(v);
        }

        public void WritePatternPRO(DesignPatternPRO p, Span<byte> data, int index, Span<byte> playerID, Span<byte> townID)
        {
            if ((uint)index >= PatternCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            playerID.CopyTo(p.Data.AsSpan(0x54)); // overwrite playerID bytes so player owns
            townID.CopyTo(p.Data.AsSpan(0x38)); // overwrite townID bytes so player owns
            ReadOnlySpan<byte> wipeflag = [0x00, 0x00, 0x00, 0x00]; // wipe so player owns
            wipeflag.CopyTo(p.Data.AsSpan(0x70));
            p.Data.CopyTo(data[(PatternsPRO + (index * DesignPatternPRO.SIZE))..]);
            byte[] editedflag = [0x00];
            editedflag.CopyTo(data[(PatternsProEditFlagStart + index)..]); // set edited flag for name import to work
        }

        public IVillager ReadVillager(ReadOnlySpan<byte> data, int index)
        {
            if ((uint)index >= VillagerCount)
                throw new ArgumentOutOfRangeException(nameof(index));

            var size = VillagerSize;
            var v = data.Slice(Animal + (index * size), size).ToArray();
            return ReadVillager(v);
        }

        public void WriteVillager(IVillager v, Span<byte> data, int index)
        {
            if ((uint)index >= VillagerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            var size = VillagerSize;
            v.Write().CopyTo(data[(Animal + (index * size))..]);
        }

        public IVillagerHouse ReadVillagerHouse(ReadOnlySpan<byte> data, int index)
        {
            if ((uint)index >= VillagerCount)
                throw new ArgumentOutOfRangeException(nameof(index));

            var size = VillagerHouseSize;
            var v = data.Slice(NpcHouseList + (index * size), size).ToArray();
            return ReadVillagerHouse(v);
        }

        public void WriteVillagerHouse(IVillagerHouse v, Span<byte> data, int index)
        {
            if ((uint)index >= VillagerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            var size = VillagerHouseSize;
            v.Write().CopyTo(data[(NpcHouseList + (index * size))..]);
        }

        public IPlayerHouse ReadPlayerHouse(ReadOnlySpan<byte> data, int index)
        {
            if ((uint)index >= PlayerCount)
                throw new ArgumentOutOfRangeException(nameof(index));

            var size = PlayerHouseSize;
            var v = data.Slice(PlayerHouseList + (index * size), size).ToArray();
            return ReadPlayerHouse(v);
        }

        public void WritePlayerHouse(IPlayerHouse v, Span<byte> data, int index)
        {
            if ((uint)index >= PlayerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            var size = PlayerHouseSize;
            v.Write().CopyTo(data[(PlayerHouseList + (index * size))..]);
        }
    }
}

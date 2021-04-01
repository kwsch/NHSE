using System;
using System.Collections.Generic;

namespace NHSE.Core
{
    /// <summary>
    /// main.dat
    /// </summary>
    public sealed class MainSave : EncryptedFilePair
    {
        public readonly MainSaveOffsets Offsets;
        public MainSave(string folder) : base(folder, "main") => Offsets = MainSaveOffsets.GetOffsets(Info);

        public Hemisphere Hemisphere { get => (Hemisphere)Data[Offsets.WeatherArea]; set => Data[Offsets.WeatherArea] = (byte)value; }
        public AirportColor AirportThemeColor { get => (AirportColor)Data[Offsets.AirportThemeColor]; set => Data[Offsets.AirportThemeColor] = (byte)value; }
        public uint WeatherSeed { get => BitConverter.ToUInt32(Data, Offsets.WeatherRandSeed); set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.WeatherRandSeed); }

        public IVillager GetVillager(int index) => Offsets.ReadVillager(Data, index);
        public void SetVillager(IVillager value, int index) => Offsets.WriteVillager(value, Data, index);

        public IVillager[] GetVillagers()
        {
            var villagers = new IVillager[MainSaveOffsets.VillagerCount];
            for (int i = 0; i < villagers.Length; i++)
                villagers[i] = GetVillager(i);
            return villagers;
        }

        public void SetVillagers(IReadOnlyList<IVillager> villagers)
        {
            for (int i = 0; i < villagers.Count; i++)
                SetVillager(villagers[i], i);
        }

        public DesignPattern GetDesign(int index) => Offsets.ReadPattern(Data, index);
        public void SetDesign(DesignPattern value, int index) => Offsets.WritePattern(value, Data, index);
        public DesignPatternPRO GetDesignPRO(int index) => Offsets.ReadPatternPRO(Data, index);
        public void SetDesignPRO(DesignPatternPRO value, int index) => Offsets.WritePatternPRO(value, Data, index);

        public IReadOnlyList<Item> RecycleBin
        {
            get => Item.GetArray(Data.Slice(Offsets.LostItemBox, MainSaveOffsets.RecycleBinCount * Item.SIZE));
            set => Item.SetArray(value).CopyTo(Data, Offsets.LostItemBox);
        }

        public IReadOnlyList<Building> Buildings
        {
            get => Building.GetArray(Data.Slice(Offsets.MainFieldStructure, MainSaveOffsets.BuildingCount * Building.SIZE));
            set => Building.SetArray(value).CopyTo(Data, Offsets.MainFieldStructure);
        }

        public PlayerHouse GetPlayerHouse(int index)
        {
            if ((uint)index >= MainSaveOffsets.PlayerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            return new PlayerHouse(Data.Slice(Offsets.PlayerHouseList + (index * PlayerHouse.SIZE), PlayerHouse.SIZE));
        }

        public void SetPlayerHouse(PlayerHouse h, int index)
        {
            if ((uint)index >= MainSaveOffsets.PlayerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            h.Data.CopyTo(Data, Offsets.PlayerHouseList + (index * PlayerHouse.SIZE));
        }

        public VillagerHouse GetVillagerHouse(int index)
        {
            if ((uint)index >= MainSaveOffsets.VillagerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            return new VillagerHouse(Data.Slice(Offsets.NpcHouseList + (index * VillagerHouse.SIZE), VillagerHouse.SIZE));
        }

        public void SetVillagerHouse(VillagerHouse h, int index)
        {
            if ((uint)index >= MainSaveOffsets.VillagerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            h.Data.CopyTo(Data, Offsets.NpcHouseList + (index * VillagerHouse.SIZE));
        }

        public VillagerHouse[] GetVillagerHouses()
        {
            var villagers = new VillagerHouse[MainSaveOffsets.VillagerCount];
            for (int i = 0; i < villagers.Length; i++)
                villagers[i] = GetVillagerHouse(i);
            return villagers;
        }

        public void SetVillagerHouses(IReadOnlyList<VillagerHouse> houses)
        {
            for (int i = 0; i < houses.Count; i++)
                SetVillagerHouse(houses[i], i);
        }

        public PlayerHouse[] GetPlayerHouses()
        {
            var villagers = new PlayerHouse[MainSaveOffsets.PlayerCount];
            for (int i = 0; i < villagers.Length; i++)
                villagers[i] = GetPlayerHouse(i);
            return villagers;
        }

        public void SetPlayerHouses(IReadOnlyList<PlayerHouse> houses)
        {
            for (int i = 0; i < houses.Count; i++)
                SetPlayerHouse(houses[i], i);
        }

        public DesignPattern[] GetDesigns()
        {
            var result = new DesignPattern[Offsets.PatternCount];
            for (int i = 0; i <result.Length; i++)
                result[i] = GetDesign(i);
            return result;
        }

        public void SetDesigns(IReadOnlyList<DesignPattern> value)
        {
            var count = Math.Min(Offsets.PatternCount, value.Count);
            for (int i = 0; i < count; i++)
                SetDesign(value[i], i);
        }

        public DesignPatternPRO[] GetDesignsPRO()
        {
            var result = new DesignPatternPRO[Offsets.PatternCount];
            for (int i = 0; i < result.Length; i++)
                result[i] = GetDesignPRO(i);
            return result;
        }

        public void SetDesignsPRO(IReadOnlyList<DesignPatternPRO> value)
        {
            var count = Math.Min(Offsets.PatternCount, value.Count);
            for (int i = 0; i < count; i++)
                SetDesignPRO(value[i], i);
        }

        public DesignPattern FlagMyDesign
        {
            get => MainSaveOffsets.ReadPatternAtOffset(Data, Offsets.PatternFlag);
            set => value.Data.CopyTo(Data, Offsets.PatternFlag);
        }

        public DesignPatternPRO[] GetDesignsTailor()
        {
            var result = new DesignPatternPRO[MainSaveOffsets.PatternTailorCount];
            for (int i = 0; i < result.Length; i++)
                result[i] = MainSaveOffsets.ReadPatternPROAtOffset(Data, Offsets.PatternTailor + (i * DesignPatternPRO.SIZE));
            return result;
        }

        public void SetDesignsTailor(IReadOnlyList<DesignPatternPRO> value)
        {
            var count = Math.Min(Offsets.PatternCount, value.Count);
            for (int i = 0; i < count; i++)
                value[i].Data.CopyTo(Data, Offsets.PatternTailor + (i * DesignPatternPRO.SIZE));
        }

        private const int EventFlagsSaveCount = 0x400;

        public short[] GetEventFlagLand()
        {
            var value = new short[EventFlagsSaveCount];
            Buffer.BlockCopy(Data, Offsets.EventFlagLand, value, 0, sizeof(short) * value.Length);
            return value;
        }

        public void SetEventFlagLand(short[] value)
        {
            Buffer.BlockCopy(value, 0, Data, Offsets.EventFlagLand, sizeof(short) * value.Length);
        }

        public TurnipStonk Turnips
        {
            get => Data.Slice(Offsets.ShopKabu, TurnipStonk.SIZE).ToClass<TurnipStonk>();
            set => value.ToBytesClass().CopyTo(Data, Offsets.ShopKabu);
        }

        public Museum Museum
        {
            get => new(Data.Slice(Offsets.Museum, Museum.SIZE));
            set => value.Data.CopyTo(Data, Offsets.Museum);
        }

        public const int AcreWidth = 7 + (2 * 1); // 1 on each side cannot be traversed
        private const int AcreHeight = 6 + (2 * 1); // 1 on each side cannot be traversed
        private const int AcreMax = AcreWidth * AcreHeight;
        private const int AcreSizeAll = AcreMax * 2;

        public ushort GetAcre(int index)
        {
            if ((uint)index > AcreMax)
                throw new ArgumentOutOfRangeException(nameof(index));
            return BitConverter.ToUInt16(Data, Offsets.OutsideField + (index * 2));
        }

        public void SetAcre(int index, ushort value)
        {
            if ((uint)index > AcreMax)
                throw new ArgumentOutOfRangeException(nameof(index));
            BitConverter.GetBytes(value).CopyTo(Data, Offsets.OutsideField + (index * 2));
        }

        public byte[] GetAcreBytes() => Data.Slice(Offsets.OutsideField, AcreSizeAll);

        public void SetAcreBytes(byte[] data)
        {
            if (data.Length != AcreSizeAll)
                throw new ArgumentOutOfRangeException(nameof(data.Length));
            data.CopyTo(Data, Offsets.OutsideField);
        }

        public TerrainTile[] GetTerrainTiles() => TerrainTile.GetArray(Data.Slice(Offsets.LandMakingMap, MapGrid.MapTileCount16x16 * TerrainTile.SIZE));
        public void SetTerrainTiles(IReadOnlyList<TerrainTile> array) => TerrainTile.SetArray(array).CopyTo(Data, Offsets.LandMakingMap);

        public const int MapDesignNone = 0xF800;

        public ushort[] GetMapDesignTiles()
        {
            var value = new ushort[112*96];
            Buffer.BlockCopy(Data, Offsets.MyDesignMap, value, 0, sizeof(ushort) * value.Length);
            return value;
        }

        public void SetMapDesignTiles(ushort[] value)
        {
            Buffer.BlockCopy(value, 0, Data, Offsets.MyDesignMap, sizeof(ushort) * value.Length);
        }

        private const int FieldItemLayerSize = MapGrid.MapTileCount32x32 * Item.SIZE;
        private const int FieldItemFlagSize = MapGrid.MapTileCount32x32 / 8; // bitflags

        private int FieldItemLayer1 => Offsets.FieldItem;
        private int FieldItemLayer2 => Offsets.FieldItem + FieldItemLayerSize;
        public int FieldItemFlag1 => Offsets.FieldItem + (FieldItemLayerSize * 2);
        public int FieldItemFlag2 => Offsets.FieldItem + (FieldItemLayerSize * 2) + FieldItemFlagSize;

        public Item[] GetFieldItemLayer1() => Item.GetArray(Data.Slice(FieldItemLayer1, FieldItemLayerSize));
        public void SetFieldItemLayer1(IReadOnlyList<Item> array) => Item.SetArray(array).CopyTo(Data, FieldItemLayer1);

        public Item[] GetFieldItemLayer2() => Item.GetArray(Data.Slice(FieldItemLayer2, FieldItemLayerSize));
        public void SetFieldItemLayer2(IReadOnlyList<Item> array) => Item.SetArray(array).CopyTo(Data, FieldItemLayer2);

        public ushort OutsideFieldTemplateUniqueId
        {
            get => BitConverter.ToUInt16(Data, Offsets.OutsideField + AcreSizeAll);
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.OutsideField + AcreSizeAll);
        }

        public ushort MainFieldParamUniqueID
        {
            get => BitConverter.ToUInt16(Data, Offsets.OutsideField + AcreSizeAll + 2);
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.OutsideField + AcreSizeAll + 2);
        }

        public uint EventPlazaLeftUpX
        {
            get => BitConverter.ToUInt32(Data, Offsets.OutsideField + AcreSizeAll + 4);
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.OutsideField + AcreSizeAll + 4);
        }

        public uint EventPlazaLeftUpZ
        {
            get => BitConverter.ToUInt32(Data, Offsets.OutsideField + AcreSizeAll + 8);
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.OutsideField + AcreSizeAll + 8);
        }

        public GSaveVisitorNpc Visitor
        {
            get => Data.ToClass<GSaveVisitorNpc>(Offsets.Visitor, GSaveVisitorNpc.SIZE);
            set => value.ToBytesClass().CopyTo(Data, Offsets.Visitor);
        }

        public GSaveFg SaveFg
        {
            get => Data.ToClass<GSaveFg>(Offsets.SaveFg, GSaveFg.SIZE);
            set => value.ToBytesClass().CopyTo(Data, Offsets.SaveFg);
        }

        public GSaveTime LastSaved => Data.Slice(Offsets.LastSavedTime, GSaveTime.SIZE).ToStructure<GSaveTime>();

        public GSaveBulletinBoard Bulletin
        {
            get => Data.Slice(Offsets.BulletinBoard, GSaveBulletinBoard.SIZE).ToStructure<GSaveBulletinBoard>();
            set => value.ToBytes().CopyTo(Data, Offsets.BulletinBoard);
        }
    }
}

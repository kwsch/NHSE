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

        public const int VillagerCount = 10;
        public Villager GetVillager(int index) => Offsets.ReadVillager(Data, index);
        public void SetVillager(Villager value, int index) => Offsets.WriteVillager(value, Data, index);

        public Villager[] GetVillagers()
        {
            var villagers = new Villager[VillagerCount];
            for (int i = 0; i < villagers.Length; i++)
                villagers[i] = GetVillager(i);
            return villagers;
        }

        public void SetVillagers(IReadOnlyList<Villager> villagers)
        {
            for (int i = 0; i < villagers.Count; i++)
                SetVillager(villagers[i], i);
        }

        public DesignPattern GetDesign(int index) => Offsets.ReadPattern(Data, index);
        public void SetDesign(DesignPattern value, int index) => Offsets.WritePattern(value, Data, index);

        public IReadOnlyList<Item> RecycleBin
        {
            get => Item.GetArray(Data.Slice(Offsets.RecycleBin, MainSaveOffsets.RecycleBinCount * Item.SIZE));
            set => Item.SetArray(value).CopyTo(Data, Offsets.RecycleBin);
        }

        public IReadOnlyList<Building> Buildings
        {
            get => Building.GetArray(Data.Slice(Offsets.Buildings, MainSaveOffsets.BuildingCount * Building.SIZE));
            set => Building.SetArray(value).CopyTo(Data, Offsets.Buildings);
        }

        public PlayerHouse GetPlayerHouse(int index)
        {
            if ((uint)index >= MainSaveOffsets.PlayerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            return Data.Slice(Offsets.PlayerHouseList + (index * PlayerHouse.SIZE), PlayerHouse.SIZE).ToClass<PlayerHouse>();
        }

        public void SetPlayerHouse(PlayerHouse h, int index)
        {
            if ((uint)index >= MainSaveOffsets.PlayerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            h.ToBytesClass().CopyTo(Data, Offsets.PlayerHouseList + (index * PlayerHouse.SIZE));
        }

        public VillagerHouse GetVillagerHouse(int index)
        {
            if ((uint)index >= MainSaveOffsets.VillagerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            return Data.Slice(Offsets.NpcHouseList + (index * VillagerHouse.SIZE), VillagerHouse.SIZE).ToClass<VillagerHouse>();
        }

        public void SetVillagerHouse(VillagerHouse h, int index)
        {
            if ((uint)index >= MainSaveOffsets.VillagerCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            h.ToBytesClass().CopyTo(Data, Offsets.NpcHouseList + (index * VillagerHouse.SIZE));
        }

        public VillagerHouse[] GetVillagerHouses()
        {
            var villagers = new VillagerHouse[VillagerCount];
            for (int i = 0; i < villagers.Length; i++)
                villagers[i] = GetVillagerHouse(i);
            return villagers;
        }

        public void SetVillagerHouses(IReadOnlyList<VillagerHouse> houses)
        {
            for (int i = 0; i < houses.Count; i++)
                SetVillagerHouse(houses[i], i);
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
            get => Data.Slice(Offsets.TurnipExchange, TurnipStonk.SIZE).ToClass<TurnipStonk>();
            set => value.ToBytesClass().CopyTo(Data, Offsets.TurnipExchange);
        }

        public const int AcreWidth = 7 + (2 * 1); // 1 on each side cannot be traversed
        private const int AcreHeight = 6 + (2 * 1); // 1 on each side cannot be traversed
        private const int AcreMax = AcreWidth * AcreHeight;
        private const int AcreSizeAll = AcreMax * 2;

        public ushort GetAcre(int index)
        {
            if ((uint)index > AcreMax)
                throw new ArgumentOutOfRangeException(nameof(index));
            return BitConverter.ToUInt16(Data, Offsets.Acres + (index * 2));
        }

        public void SetAcre(int index, ushort value)
        {
            if ((uint)index > AcreMax)
                throw new ArgumentOutOfRangeException(nameof(index));
            BitConverter.GetBytes(value).CopyTo(Data, Offsets.Acres + (index * 2));
        }

        public byte[] GetAcreBytes() => Data.Slice(Offsets.Acres, AcreSizeAll);

        public void SetAcreBytes(byte[] data)
        {
            if (data.Length != AcreSizeAll)
                throw new ArgumentOutOfRangeException(nameof(data.Length));
            data.CopyTo(Data, Offsets.Acres);
        }

        public TerrainTile[] GetTerrain() => TerrainTile.GetArray(Data.Slice(Offsets.Terrain, MapGrid.MapTileCount16x16 * TerrainTile.SIZE));
        public void SetTerrain(IReadOnlyList<TerrainTile> array) => TerrainTile.SetArray(array).CopyTo(Data, Offsets.Terrain);

        public FieldItem[] GetFieldItems() => FieldItem.GetArray(Data.Slice(Offsets.FieldItem, MapGrid.MapTileCount32x32 * FieldItem.SIZE * 2));
        public void SetFieldItems(IReadOnlyList<FieldItem> array) => FieldItem.SetArray(array).CopyTo(Data, Offsets.FieldItem);

        public ushort OutsideFieldTemplateUniqueId
        {
            get => BitConverter.ToUInt16(Data, Offsets.Acres + AcreSizeAll);
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.Acres + AcreSizeAll);
        }

        public ushort MainFieldParamUniqueID
        {
            get => BitConverter.ToUInt16(Data, Offsets.Acres + AcreSizeAll + 2);
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.Acres + AcreSizeAll + 2);
        }

        public uint PlazaX
        {
            get => BitConverter.ToUInt32(Data, Offsets.Acres + AcreSizeAll + 4);
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.Acres + AcreSizeAll + 4);
        }

        public uint PlazaY
        {
            get => BitConverter.ToUInt32(Data, Offsets.Acres + AcreSizeAll + 8);
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.Acres + AcreSizeAll + 8);
        }

        public GSaveTime LastSaved => Data.Slice(Offsets.LastSavedTime, GSaveTime.SIZE).ToStructure<GSaveTime>();
    }
}
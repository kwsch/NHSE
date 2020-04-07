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

        public Villager GetVillager(int index) => Offsets.ReadVillager(Data, index);
        public void SetVillager(Villager value, int index) => Offsets.WriteVillager(value, Data, index);
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
    }
}
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
    }
}
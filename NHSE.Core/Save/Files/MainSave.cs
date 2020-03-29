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

        public IReadOnlyList<Item> RecycleBin
        {
            get => Item.GetArray(Data.Slice(Offsets.RecycleBin, MainSaveOffsets.RecycleBinCount * Item.SIZE));
            set => Item.SetArray(value).CopyTo(Data, Offsets.RecycleBin);
        }
    }
}
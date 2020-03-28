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

        public static MainSaveOffsets GetOffsets(FileHeaderInfo Info)
        {
            var rev = Info.GetKnownRevisionIndex();
            return rev switch
            {
                0 => new MainSaveOffsets10(),
                1 => new MainSaveOffsets11(),
                2 => new MainSaveOffsets11(),
                _ => throw new IndexOutOfRangeException("Unknown revision!"),
            };
        }

        public abstract Villager ReadVillager(byte[] data, int index);
        public void WriteVillager(Villager v, byte[] data, int index)
        {
            v.Data.CopyTo(data, Villager + (index * VillagerSize));
        }
    }
}
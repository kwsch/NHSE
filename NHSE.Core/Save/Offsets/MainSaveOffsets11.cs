namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="MainSaveOffsets"/>
    /// </summary>
    public class MainSaveOffsets11 : MainSaveOffsets
    {
        public override int Villager => 0x120;

        public override Villager ReadVillager(byte[] data, int index)
        {
            var v = data.Slice(Villager + (index * VillagerSize), VillagerSize);
            return new Villager(v);
        }
    }
}
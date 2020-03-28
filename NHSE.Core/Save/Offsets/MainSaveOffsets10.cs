namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="MainSaveOffsets"/>
    /// </summary>
    public class MainSaveOffsets10 : MainSaveOffsets
    {
        public override int Villager => 0x110;

        public override Villager ReadVillager(byte[] data, int index)
        {
            var v = data.Slice(Villager + (index * VillagerSize), VillagerSize);
            return new Villager(v);
        }
    }
}
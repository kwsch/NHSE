namespace NHSE.Villagers
{
    public class VillagerData
    {
        public readonly byte[] Villager;
        public readonly byte[] House;

        public VillagerData(byte[] villager, byte[] house)
        {
            Villager = villager;
            House = house;
        }
    }
}

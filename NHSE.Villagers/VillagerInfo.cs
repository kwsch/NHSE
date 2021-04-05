using NHSE.Core;

namespace NHSE.Villagers
{
    public class VillagerInfo
    {
        public readonly Villager2 Villager;
        public readonly VillagerHouse House;

        public VillagerInfo(Villager2 villager, VillagerHouse house)
        {
            Villager = villager;
            House = house;
        }
    }
}

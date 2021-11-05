using NHSE.Core;

namespace NHSE.Villagers
{
    public class VillagerInfo
    {
        public readonly Villager2 Villager;
        public readonly IVillagerHouse House;

        public VillagerInfo(Villager2 villager, IVillagerHouse house)
        {
            Villager = villager;
            House = house;
        }
    }
}

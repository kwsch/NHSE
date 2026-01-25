using NHSE.Core;

namespace NHSE.Villagers;

public readonly record struct VillagerInfo(Villager2 Villager, IVillagerHouse House);
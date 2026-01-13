using System;

namespace NHSE.Villagers;

public class VillagerData
{
    public readonly Memory<byte> Villager;
    public readonly Memory<byte> House;

    public VillagerData(Memory<byte> villager, Memory<byte> house)
    {
        Villager = villager;
        House = house;
    }
}
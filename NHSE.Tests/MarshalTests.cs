using FluentAssertions;
using NHSE.Core;
using Xunit;

namespace NHSE.Tests;

public class MarshalTests
{
    [Fact] public void MarshalItem() => MarshalTest<Item>(Item.SIZE);
    [Fact] public void MarshalVillagerItem() => MarshalTest<VillagerItem>(VillagerItem.SIZE);
    [Fact] public void MarshalTerrainTile() => MarshalTest<TerrainTile>(TerrainTile.SIZE);
    [Fact] public void MarshalTurnip() => MarshalTest<TurnipStonk>(TurnipStonk.SIZE);
    [Fact] public void MarshalBuilding() => MarshalTest<Building>(Building.SIZE);

    [Fact] public void MarshalVillagerHouseItem() => MarshalTestS<VillagerHouseItem>(VillagerHouseItem.SIZE);
    [Fact] public void MarshalGSaveItemName() => MarshalTestS<GSaveItemName>(GSaveItemName.SIZE);

    [Fact] public void MarshalHouse1() => MarshalTestS<s_f9acc222>(s_f9acc222.SIZE);
    [Fact] public void MarshalHouse2() => MarshalTestS<s_e74059db>(s_e74059db.SIZE);
    [Fact] public void MarshalHouse3() => MarshalTestS<s_a7a72585>(s_a7a72585.SIZE);
    [Fact] public void MarshalHouse4() => MarshalTestS<GSaveRoomFloorWall>(GSaveRoomFloorWall.SIZE);
    [Fact] public void MarshalHouse5() => MarshalTestS<s_e13a81f4>(s_e13a81f4.SIZE);
    [Fact] public void MarshalHouse6() => MarshalTestS<GSaveAudioRegister>(GSaveAudioRegister.SIZE);

    private static void MarshalTest<T>(int size) where T : class, new()
    {
        var obj = new T();
        var bytes = obj.ToBytesClass();
        bytes.Length.Should().Be(size);

        var recomputed = bytes.ToClass<T>();
        recomputed.Should().NotBeNull();
    }

    private static void MarshalTestS<T>(int size) where T : struct
    {
        var obj = new T();
        var bytes = obj.ToBytes();
        bytes.Length.Should().Be(size);

        var recomputed = bytes.ToStructure<T>();
        recomputed.Should().NotBeNull();
    }
}
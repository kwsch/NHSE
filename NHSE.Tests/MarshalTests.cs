using FluentAssertions;
using NHSE.Core;
using Xunit;

namespace NHSE.Tests
{
    public class MarshalTests
    {
        [Fact] public void MarshalItem() => MarshalTest<Item>(Item.SIZE);
        [Fact] public void MarshalVillagerItem() => MarshalTest<VillagerItem>(VillagerItem.SIZE);
        [Fact] public void MarshalTerrainTile() => MarshalTest<TerrainTile>(TerrainTile.SIZE);
        [Fact] public void MarshalTurnip() => MarshalTest<TurnipStonk>(TurnipStonk.SIZE);
        [Fact] public void MarshalBuilding() => MarshalTest<Building>(Building.SIZE);
        [Fact] public void MarshalVillagerHouse() => MarshalTest<VillagerHouse>(VillagerHouse.SIZE);
        [Fact] public void MarshalPlayerHouse() => MarshalTest<PlayerHouse>(PlayerHouse.SIZE);

        [Fact] public void MarshalVillagerHouseItem() => MarshalTestS<VillagerHouseItem>(VillagerHouseItem.SIZE);
        [Fact] public void MarshalGSaveItemName() => MarshalTestS<GSaveItemName>(GSaveItemName.SIZE);

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
}

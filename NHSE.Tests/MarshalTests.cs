using FluentAssertions;
using NHSE.Core;
using Xunit;

namespace NHSE.Tests
{
    public class MarshalTests
    {
        [Fact]
        public void ItemMarshal()
        {
            var item = new Item();
            var bytes = item.ToBytesClass();
            bytes.Length.Should().Be(Item.SIZE);
        }

        [Fact]
        public void VillagerItemMarshal()
        {
            var item = new VillagerItem();
            var bytes = item.ToBytesClass();
            bytes.Length.Should().Be(VillagerItem.SIZE);
        }

        [Fact]
        public void FieldItemMarshal()
        {
            var item = new FieldItem();
            var bytes = item.ToBytesClass();
            bytes.Length.Should().Be(Item.SIZE);

            var other = new FieldItem();
            item.CopyFrom(other);
        }

        [Fact]
        public void TerrainTileMarshal()
        {
            var obj = new TerrainTile();
            var bytes = obj.ToBytesClass();
            bytes.Length.Should().Be(TerrainTile.SIZE);
        }
    }
}

using System.Linq;
using FluentAssertions;
using NHSE.Core;
using Xunit;

namespace NHSE.Tests
{
    public class BuildingTests
    {
        [Fact]
        public void BuildingMarshal()
        {
            var building = new Building();
            var bytes = building.ToBytesClass();
            bytes.Length.Should().Be(Building.SIZE);
        }

        [Fact]
        public void BuildingClear()
        {
            var item = new Building {BuildingType = BuildingType.PlayerHouse1, X=5, Y=7};
            var bytes = item.ToBytesClass();
            bytes.Any(z => z != 0).Should().BeTrue();

            item.Clear();
            bytes = item.ToBytesClass();
            bytes.Any(z => z != 0).Should().BeFalse();
        }
    }
}

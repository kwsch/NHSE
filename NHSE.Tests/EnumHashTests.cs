using FluentAssertions;
using NHSE.Parsing;
using Xunit;

namespace NHSE.Tests
{
    public class EnumHashTests
    {
        [Theory]
        [InlineData("Base", 0x6086515F)]
        [InlineData("River", 0x3422482F)]
        [InlineData("RoadStone", 0x13011867)]
        public void ChecksumMatches(string str, uint val)
        {
            var computed = CRC32.Compute(str);
            computed.Should().Be(val);
        }

        [Fact]
        public void DUmmy()
        {
            var folder = @"D:\Kurt\Desktop\v11 bcsv";
            GameBCSVDumper.UpdateDumps(folder, folder, true);
        }
    }
}

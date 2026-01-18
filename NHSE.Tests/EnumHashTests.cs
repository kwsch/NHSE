using FluentAssertions;
using NHSE.Parsing;
using Xunit;

namespace NHSE.Tests;

public static class EnumHashTests
{
    [Theory]
    [InlineData("Base", 0x6086515F)]
    [InlineData("River", 0x3422482F)]
    [InlineData("RoadStone", 0x13011867)]
    public static void ChecksumMatches(string str, uint val)
    {
        var computed = CRC32.Compute(str);
        computed.Should().Be(val);
    }
}
using FluentAssertions;
using NHSE.Parsing;
using NHSE.Tests.Properties;
using Xunit;

namespace NHSE.Tests
{
    public static class MSBTTests
    {
        [Fact]
        public static void TestTownDefaultNames()
        {
            var data = Resources.STR_TownName;
            var obj = new MSBT(data);
            obj.SectionOrder.Count.Should().Be(3);
            obj.TXT2.Strings.Count.Should().BeGreaterThan(0);

            var str = obj.TXT2.Strings[8].ToString(obj.FileEncoding).TrimEnd('\0');
            str.Should().Be("Awesome Beach");
            obj.DebugDumpLines();
        }

        [Fact]
        public static void TestTurnip()
        {
            var data = Resources.STR_ItemName_41_Turnip;
            var obj = new MSBT(data);
            obj.SectionOrder.Count.Should().Be(3);
            obj.TXT2.Strings.Count.Should().BeGreaterThan(0);
            obj.DebugDumpLines();
        }
    }
}

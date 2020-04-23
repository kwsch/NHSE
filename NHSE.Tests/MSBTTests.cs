using System.Collections.Generic;
using System.IO;
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

        [Fact]
        public static void TestX()
        {
            const string cs = @"C:\Users\Kurt\Documents\GitHub\NHSE\NHSE.Core\Resources\text\";
            const string folder = @"D:\Kurt\Desktop\v12\romSARC\Message\String_{0}.sarc.zs\String_{0}.sarc";
            var langs = new Dictionary<string, string>
            {
                {"de", "EUde"},
            };

            foreach (var entry in langs)
            {
                var c = entry.Key;
                var l = entry.Value;
                var dest = Path.Combine(cs, c, $"text_item_{c}.txt");
                var src = string.Format(folder, l);
                var items = GameMSBTDumper.GetItemListResource(src);
                File.WriteAllLines(dest, items);
            }

        }
    }
}

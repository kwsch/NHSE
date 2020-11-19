using System.Collections.Generic;
using System.IO;
using NHSE.Parsing;
using Xunit;

namespace NHSE.Tests
{
    public static class DumpTests
    {
        private const string ver = "v16";

        [Fact]
        public static void DumpBCSV()
        {
            var folder = $@"D:\Kurt\Desktop\{ver}\bcsv";
            GameBCSVDumper.UpdateDumps(folder, folder, true);
        }

        [Fact]
        public static void DumpMSBT()
        {
            const string cs = @"C:\Users\Kurt\Documents\GitHub\NHSE\NHSE.Core\Resources\text\";
            string folder = $@"D:\Kurt\Desktop\{ver}\Message\String_{{0}}.sarc";
            var langs = new Dictionary<string, string>
            {
                {"en", "USen"},
                {"jp", "JPja"},
                {"zhs", "CNzh"},
                {"zht", "TWzh"},
                {"de", "EUde"},
                {"fr", "EUfr"},
                {"it", "EUit"},
                {"es", "EUes"},
                {"ko", "KRko"},
            };

            foreach (var (code, langName) in langs)
            {
                // item
                var dest = Path.Combine(cs, code, $"text_item_{code}.txt");
                var src = string.Format(folder, langName);
                var items = GameMSBTDumper.GetItemListResource(src, code);
                File.WriteAllLines(dest, items);

                // villager
                dest = Path.Combine(cs, code, $"text_villager_{code}.txt");
                src = string.Format(folder, langName);
                var villager = GameMSBTDumper.GetVillagerListResource(src);
                File.WriteAllLines(dest, villager);
            }
		}
    }
}

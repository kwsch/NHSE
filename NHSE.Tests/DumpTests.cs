using System.IO;
using NHSE.Parsing;
using Xunit;
using static NHSE.Parsing.GameMSBTDumperNHSE;

namespace NHSE.Tests
{
    public static class DumpTests
    {
        private const string RepoPath = @"C:\Users\Kurt\Documents\GitHub";
        private const string PatchDumpPath = @"D:\Kurt\Desktop\" + PatchFolderName;
        private const string PatchFolderName = "v17";
        private const string MessageDumpFormat = @"\Message\String_{0}";

        [Fact]
        public static void DumpBCSV()
        {
            const string folder = PatchDumpPath + @"\bcsv";
            GameBCSVDumper.UpdateDumps(folder, folder, true);
        }

        [Fact]
        public static void DumpMSBT()
        {
            const string cs = RepoPath + @"\NHSE\NHSE.Core\Resources\text\";
            const string folder = PatchDumpPath + MessageDumpFormat;
            var langs = Languages;

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

using NHSE.Parsing;
using Xunit;

namespace NHSE.Tests
{
    public static class DumpTests
    {
        private const string RepoPath = @"C:\Users\Kurt\Documents\GitHub";
        private const string PatchDumpPath = @"D:\Kurt\Desktop\ac\" + PatchFolderName;
        private const string PatchFolderName = "v110";
        private const string MessageDumpFormat = @"Message\String_{0}";

        [Fact]
        public static void DumpBCSV()
        {
            const string folder = PatchDumpPath + @"\bcsv";
            GameBCSVDumper.UpdateDumps(folder, folder, true);
        }

        [Fact]
        public static void DumpMSBT()
        {
            GameMSBTDumperNHSE.Dump(RepoPath, PatchDumpPath, MessageDumpFormat);
		}
    }
}

using System.IO;
using NHSE.Parsing;
using Xunit;

namespace NHSE.Tests;

public static class DumpTests
{
    private const string RepoPath = @"C:\Users\kapho\source\repos";
    private const string PatchDumpPath = @"E:\acnh\" + PatchFolderName;
    private const string PatchFolderName = "v20";
    private const string MessageDumpFormat = @"Message\String_{0}";

    [Fact]
    public static void DumpBCSV()
    {
        const string folder = PatchDumpPath + @"\bcsv";
        if (!Directory.Exists(folder)) // skip this test if not properly configured for this test
            return;

        GameBCSVDumper.UpdateDumps(folder, folder, true);
    }

    [Fact]
    public static void DumpMSBT()
    {
        const string folder = RepoPath;
        if (!Directory.Exists(folder)) // skip this test if not properly configured for this test
            return;
        const string dump = PatchDumpPath;
        if (!Directory.Exists(dump)) // skip this test if not properly configured for this test
            return;
        GameMSBTDumperNHSE.Dump(folder, dump, MessageDumpFormat);
    }
}
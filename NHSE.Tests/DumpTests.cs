using System.IO;
using NHSE.Parsing;
using Xunit;

namespace NHSE.Tests;

public static class DumpTests
{
    private const string RepoPath = @"C:\Users\kapho\source\repos";
    private const string PatchDumpPath = @"E:\acnh\" + PatchFolderName;
    private const string PatchFolderName = "v30";
    private const string MessageDumpFormat = @"Message\String_{0}";

    [Fact]
    public static void DumpBCSV()
    {
        const string folder = PatchDumpPath + @"\bcsv";
        Assert.SkipUnless(Directory.Exists(folder), "Directory not found, skip."); // skip this test if not properly configured for this test

        GameBCSVDumper.UpdateDumps(folder, folder, true);
    }

    [Fact]
    public static void DumpMSBT()
    {
        const string folder = RepoPath;
        const string dump = PatchDumpPath;
        Assert.SkipUnless(Directory.Exists(folder), "Repo not found, skip."); // skip this test if not properly configured for this test
        Assert.SkipUnless(Directory.Exists(dump), "Dump not found, skip."); // skip this test if not properly configured for this test

        GameMSBTDumperNHSE.Dump(folder, dump, MessageDumpFormat);

        GameMSBTDumper.UpdateDumps(dump, dump);
    }
}
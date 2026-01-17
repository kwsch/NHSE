using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NHSE.Parsing;

public static class MSBTUtil
{
    public static void DebugDumpLines(this MSBT obj)
    {
        var lines = obj.GetOrderedLines();
        foreach (var line in lines)
            Debug.WriteLine(line);
    }

    public static IEnumerable<string> GetOrderedLines(string path, int indexBias = 0) => new MSBT(File.ReadAllBytes(path)).GetOrderedLines(indexBias);

    public static IEnumerable<string> GetCSV(string path, int indexBias = 0, char delim = '\t')
    {
        var obj = new MSBT(File.ReadAllBytes(path));
        var sorted = obj.LBL1.Labels
            .Where(z => !z.Name.EndsWith("_pl"))
            .OrderBy(z => z.Index);
        foreach (var x in sorted)
        {
            var index = x.Index;
            var name = x.Name;
            var strings = obj.TXT2.Strings;
            var line = GetStringIndex(index, strings, obj);
            yield return $"{index + indexBias}{delim}\"{name}\"{delim}\"{line.Replace("\"", "\"\"")}\"";
        }
    }

    private static string GetStringIndex(uint index, List<MSBTTextString> strings, MSBT obj)
    {
        if (index >= strings.Count)
            return $"INVALID INDEX?? {index}";
        var data = strings[(int)index];
        var line = data.ToString(obj.FileEncoding).TrimEnd('\0');
        return line;
    }

    public static IEnumerable<string> GetOrderedLines(this MSBT obj, int indexBias = 0)
    {
        var sorted = obj.LBL1.Labels
            .Where(z => !z.Name.EndsWith("_pl"))
            .OrderBy(z => z.Index);

        foreach (var x in sorted)
        {
            var index = x.Index;
            var name = x.Name;
            var data = obj.TXT2.Strings[(int)index];
            var line = data.ToString(obj.FileEncoding).TrimEnd('\0');
            yield return $"{line} = {index + indexBias}, // {name}";
        }
    }
}
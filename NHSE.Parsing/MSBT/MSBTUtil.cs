using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NHSE.Parsing
{
    public static class MSBTUtil
    {
        public static void DebugDumpLines(this MSBT obj)
        {
            var lines = obj.GetOrderedLines();
            foreach (var line in lines)
                Debug.WriteLine(line);
        }

        public static IEnumerable<string> GetOrderedLines(string path, int indexBias = 0) => new MSBT(File.ReadAllBytes(path)).GetOrderedLines(indexBias);

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
}

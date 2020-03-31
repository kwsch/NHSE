using System.Diagnostics;
using System.Linq;

namespace NHSE.Parsing
{
    public static class MSBTUtil
    {
        public static void DebugDumpLines(this MSBT obj)
        {
            var sorted = obj.LBL1.Labels
                .Where(z => !z.Name.EndsWith("_pl"))
                .OrderBy(z => z.Index);

            foreach (var x in sorted)
            {
                var index = x.Index;
                var name = x.Name;
                var data = obj.TXT2.Strings[(int) index];
                var line = data.ToString(obj.FileEncoding).TrimEnd('\0');
                Debug.WriteLine($"{index}\t{name}\t{line}");
            }
        }
    }
}

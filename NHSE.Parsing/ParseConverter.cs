using System.IO;
using System.Linq;

namespace NHSE.Parsing
{
    public static class ParseConverter
    {
        public static void ConvertItemStrings(string input, string output)
        {
            var result = ConvertItemList(input);
            File.WriteAllLines(output, result);
        }

        private static string[] ConvertItemList(string path)
        {
            var lines = File.ReadAllLines(path);
            var items = lines.Select(z => new ParseItem(z)).ToArray();

            var max = items.Max(z => z.Index);
            var result = new string[max + 1];
            foreach (var item in items)
            {
                result[item.Index] = item.Name;
            }
            return result;
        }
    }

    public class ParseItem
    {
        public int Index;
        public string Name;
        public ParseItem(string line)
        {
            var split = line.Split(new[] { ", " }, 0);
            Index = int.Parse(split[0], System.Globalization.NumberStyles.HexNumber);
            Name = split[1];
        }
    }
}

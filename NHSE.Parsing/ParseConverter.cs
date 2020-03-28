using System.IO;
using System.Linq;

namespace NHSE.Parsing
{
    /// <summary>
    /// Logic for converting various dumps to resources used by the Core project.
    /// </summary>
    public static class ParseConverter
    {
        /// <summary>
        /// Converts {Hex, Name} to an index-able list of strings.
        /// </summary>
        /// <param name="input">Path to Key Value pair listing, with keys being hex numbers (without 0x prefix)</param>
        /// <param name="output">File to write the result list to</param>
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

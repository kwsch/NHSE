using System;
using System.Collections.Generic;

namespace NHSE.Parsing
{
    public class BCSVEnumDictionary
    {
        private readonly Dictionary<uint, string> Lookup = new Dictionary<uint, string>();

        public BCSVEnumDictionary(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var trim = line.Trim();
                if (!trim.StartsWith("("))
                    continue;
                if (!trim.EndsWith("),"))
                    continue;

                var text = trim.Split('\'')[1];
                if (text.Length == 0)
                    continue;

                var hash = CRC32.Compute(text);
                if (Lookup.TryGetValue(hash, out var exist))
                {
                    if (exist == text)
                        continue;
                    Console.WriteLine($"Duplicate KVP: {exist} -- old, {text} -- new.");
                    continue;
                }
                Lookup.Add(hash, text);
            }
        }

        public string this[uint key] => Lookup.TryGetValue(key, out var val) ? val : $"0x{key:X8}";
    }
}

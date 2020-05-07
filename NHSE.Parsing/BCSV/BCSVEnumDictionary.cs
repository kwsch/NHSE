using System;
using System.Collections.Generic;
using System.Linq;
using NHSE.Core;

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
                if (trim.StartsWith("("))
                    AddEnumName(trim);
                if (trim.Contains(" = "))
                    AddColumnName(trim);
            }
        }

        private void AddColumnName(string trim)
        {
            if (!trim.EndsWith(")"))
                return;
            if (trim.StartsWith("_"))
                return;

            var text = trim.Split(new [] {" = "}, 0);

            var name = text[0];
            var value = text[1].Substring(text[1].IndexOf('(') + 1);
            value = value.Substring(2, value.Length - 3);
            var hex = StringUtil.GetHexValue(value);

            if (Lookup.TryGetValue(hex, out var exist))
            {
                if (exist == name)
                    return;
                Console.WriteLine($"Duplicate KVP: {exist} -- old, {name} -- new.");
                return;
            }

            Lookup.Add(hex, name);
        }

        private void AddEnumName(string trim)
        {
            if (!trim.EndsWith("),"))
                return;

            var text = trim.Split('\'')[1];
            if (text.Length == 0)
                return;

            var hash = CRC32.Compute(text);
            if (Lookup.TryGetValue(hash, out var exist))
            {
                if (exist == text)
                    return;
                Console.WriteLine($"Duplicate KVP: {exist} -- old, {text} -- new.");
                return;
            }

            Lookup.Add(hash, text);
        }

        public IEnumerable<string> Dump() => Lookup.Select(z => $"{z.Key:X8}\t{z.Value}");

        public string this[uint key] => Lookup.TryGetValue(key, out var val) ? val : $"0x{key:X8}";
    }
}

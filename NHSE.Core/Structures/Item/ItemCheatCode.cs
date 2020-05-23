using System;
using System.Collections.Generic;
using System.Globalization;

namespace NHSE.Core
{
    /// <summary>
    /// Converts cheat codes to and from <see cref="Item"/>
    /// </summary>
    public static class ItemCheatCode
    {
        public static byte[] ReadCode(string paste)
        {
            var lines = paste.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return ReadCode(lines);
        }

        public static byte[] ReadCode(IEnumerable<string> lines)
        {
            var result = new List<byte>();
            foreach (var l in lines)
            {
                var lastSpace = l.LastIndexOf(' ');
                if (lastSpace < 0)
                    continue;
                var lastChunk = l.Substring(lastSpace + 1);
                if (!uint.TryParse(lastChunk, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var hex))
                    continue;
                var bytes = BitConverter.GetBytes(hex);
                result.AddRange(bytes);
            }
            return result.ToArray();
        }

        public static IEnumerable<string> WriteCode(IEnumerable<Item> items, uint offset)
        {
            int ctr = 0;
            foreach (var item in items)
            {
                var bytes = item.ToBytesClass();
                var lower = BitConverter.ToUInt32(bytes, 0);
                var upper = BitConverter.ToUInt32(bytes, 4);
                yield return $"04100000 {offset + (ctr++*4):X8} {lower:X8}";
                yield return $"04100000 {offset + (ctr++*4):X8} {upper:X8}";
            }
        }
    }
}

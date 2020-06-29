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
            foreach (var line in lines)
            {
                var l = line.Trim();
                var chunkCount = GetChunkCount(l);
                if (chunkCount == 0)
                    continue;

                // Since the codes are stored BB AA, we need to import them in reverse (AA BB)
                int indexOfSpace = l.Length - 1;
                for (int i = 0; i < chunkCount; i++)
                {
                    indexOfSpace = l.LastIndexOf(' ', indexOfSpace);
                    if (indexOfSpace < 0)
                        continue;

                    var length = l.Length - indexOfSpace - 1;
                    if (length < 8)
                        continue;

                    var lastChunk = l.Substring(indexOfSpace + 1, 8);
                    AddU32Chunk(lastChunk, result);
                    indexOfSpace -= 2;
                }
            }
            return result.ToArray();
        }

        private static int GetChunkCount(string line)
        {
            if (line.Length < 2)
                return 0;

            // 08 or 04
            var second = line[1];
            return second == '8' ? 2 : 1;
        }

        private static void AddU32Chunk(string lastChunk, List<byte> result)
        {
            if (!uint.TryParse(lastChunk, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var hex))
                return;
            var bytes = BitConverter.GetBytes(hex);
            result.AddRange(bytes);
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

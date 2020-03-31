using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using NHSE.Core;

namespace NHSE.Parsing
{
    public static class GameBCSVDumper
    {
        public static byte[] GetItemTypeArray(string pathBCSV)
        {
            var data = File.ReadAllBytes(pathBCSV);
            var bcsv = new BCSV(data);

            var dict = bcsv.GetFieldDictionary();
            var fType = dict[0xFC275E86];
            var fID = dict[0x54706054];

            var types = new Dictionary<ushort, ItemKind>();
            ushort max = 0;
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var id = bcsv.ReadValue(i, fID);
                var ival = ushort.Parse(id);
                var type = bcsv.ReadValue(i, fType).TrimEnd('\0');

                if (!Enum.TryParse<ItemKind>(type, out var k))
                    throw new InvalidEnumArgumentException($"{type} is not a known enum value @ index {i}.");
                types.Add(ival, k);

                if (ival > max)
                    max = ival;
            }

            byte[] result = new byte[max + 1];
            foreach (var kvp in types)
                result[kvp.Key] = (byte) kvp.Value;

            return result;
        }
    }
}

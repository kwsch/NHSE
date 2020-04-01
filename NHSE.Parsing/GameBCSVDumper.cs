using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using NHSE.Core;

namespace NHSE.Parsing
{
    public static class GameBCSVDumper
    {
        public static byte[] GetItemTypeArray(string pathBCSV, string fn = "ItemParam.bcsv")
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
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

        public static List<string> GetRecipeList(string pathBCSV, string fn = "RecipeCraftParam.bcsv")
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
            var bcsv = new BCSV(data);

            var dict = bcsv.GetFieldDictionary();
            var frecipe = dict[0x54706054];
            var fitemID = dict[0x89A3482C];

            var items = GameInfo.Strings.itemlist;

            var result = new List<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var iid = bcsv.ReadValue(i, fitemID);
                var ival = ushort.Parse(iid);

                var rid = bcsv.ReadValue(i, frecipe);
                var rval = ushort.Parse(rid);

                var kvp = $"{{0x{rval:X3}, {ival:00000}}}, // {items[ival]}";
                result.Add(kvp);
            }

            result.Sort();
            return result;
        }

        public static List<string> GetMilestoneList(string pathBCSV, string fn = "EventFlagsLifeSupportAchievementParam.bcsv")
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
            var bcsv = new BCSV(data);

            var dict = bcsv.GetFieldDictionary();
            var findex = dict[0x54706054];
            var fname = dict[0x45F320F2];
            var fjp = dict[0x85CF1615];

            var result = new List<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var iid = bcsv.ReadValue(i, findex);
                var ival = ushort.Parse(iid);

                var name = bcsv.ReadValue(i, fname).TrimEnd('\0');
                var jp = bcsv.ReadValue(i, fjp).TrimEnd('\0');

                var kvp = $"{{{ival:00}, \"{name}\"}}, // {jp}";
                result.Add(kvp);
            }

            result.Sort();
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using NHSE.Core;

namespace NHSE.Parsing
{
    /// <summary>
    /// Converts <see cref="BCSV"/> files to other formats digestible by the program.
    /// </summary>
    public static class GameBCSVDumper
    {
        /// <summary>
        /// Dumps everything the program uses to the provided <see cref="dest"/>, using the provided <see cref="pathBCSV"/>.
        /// </summary>
        /// <param name="pathBCSV">Source of <see cref="BCSV"/> files.</param>
        /// <param name="dest">Destination folder where the dumps will be saved.</param>
        public static void UpdateDumps(string pathBCSV, string dest)
        {
            BCSVConverter.DumpAll(pathBCSV, dest);
            var itemNames = GameInfo.Strings.itemlist;

            void DumpS(string fn, IEnumerable<string> lines)
            {
                File.WriteAllLines(Path.Combine(dest, fn), lines);
                Console.WriteLine($"Created {fn}");
            }

            void DumpB(string fn, byte[] bytes)
            {
                File.WriteAllBytes(Path.Combine(dest, fn), bytes);
                Console.WriteLine($"Created {fn}");
            }

            DumpS("milestones.txt", GetMilestoneList(pathBCSV));
            DumpS("recipeDictionary.txt", GetRecipeList(pathBCSV));

            DumpS("fish.txt", GetFishList(pathBCSV, itemNames));
            DumpS("bugs.txt", GetInsectList(pathBCSV, itemNames));

            DumpS("ItemKind.txt", GetItemKindsEnum(pathBCSV));
            DumpB("item_kind.bin", GetItemKindArray(pathBCSV));
        }

        public static IEnumerable<string> GetItemKinds(string pathBCSV, string fn = "ItemParam.bcsv")
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
            var bcsv = new BCSV(data);

            var dict = bcsv.GetFieldDictionary();
            var fType = dict[0xFC275E86];

            var types = new HashSet<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var type = bcsv.ReadValue(i, fType).TrimEnd('\0');
                if (!types.Contains(type))
                    types.Add(type);
            }

            return types;
        }

        private static IEnumerable<string> GetItemKindsEnum(string pathBCSV)
        {
            var kinds = GetItemKinds(pathBCSV);
            var ordered = kinds.OrderBy(z => z);
            return ordered.Select(z => $"{z},");
        }

        public static byte[] GetItemKindArray(string pathBCSV, string fn = "ItemParam.bcsv")
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
                    throw new InvalidEnumArgumentException($"{type} is not a known enum value @ index {i}. Update the enum index first.");
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
            var bcsv = BCSVConverter.GetBCSV(pathBCSV, fn);

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
            var bcsv = BCSVConverter.GetBCSV(pathBCSV, fn);

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

        public static IEnumerable<ushort> GetInsectList(string pathBCSV, string fn = "InsectStatusParam.bcsv")
        {
            return GetItemList(pathBCSV, fn, 0x20CB67BC);
        }

        public static IEnumerable<ushort> GetFishList(string pathBCSV, string fn = "FishStatusParam.bcsv")
        {
            return GetItemList(pathBCSV, fn, 0x20CB67BC);
        }

        public static IEnumerable<string> GetInsectList(string pathBCSV, IReadOnlyList<string> items, string fn = "InsectStatusParam.bcsv")
        {
            var insects = GetInsectList(pathBCSV, fn);
            return insects.Select(z => $"{z:00000}, // {items[z]}");
        }

        public static IEnumerable<string> GetFishList(string pathBCSV, IReadOnlyList<string> items, string fn = "FishStatusParam.bcsv")
        {
            var insects = GetFishList(pathBCSV, fn);
            return insects.Select(z => $"{z:00000}, // {items[z]}");
        }

        private static IEnumerable<ushort> GetItemList(string pathBCSV, string fn, uint keyItemIDColumn)
        {
            var bcsv = BCSVConverter.GetBCSV(pathBCSV, fn);
            var dict = bcsv.GetFieldDictionary();
            var findex = dict[keyItemIDColumn];

            var result = new List<ushort>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var iid = bcsv.ReadValue(i, findex);
                var ival = ushort.Parse(iid);
                result.Add(ival);
            }

            result.Sort();
            return result;
        }
    }
}

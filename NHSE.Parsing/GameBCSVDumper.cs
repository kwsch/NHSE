using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
        /// <param name="csv">Convert all <see cref="BCSV"/> files to CSV for easy viewing.</param>
        /// <param name="delim">Delimiter when exporting the <see cref="csv"/> files</param>
        public static void UpdateDumps(string pathBCSV, string dest, bool csv = false, string delim = "\t")
        {
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
            DumpS("outsideAcres.txt", GetAcreNames(pathBCSV));

            DumpS("fish.txt", GetFishList(pathBCSV, itemNames));
            DumpS("bugs.txt", GetInsectList(pathBCSV, itemNames));
            DumpS("eventFlagPlayer.txt", GetEventFlagNames(pathBCSV));
            DumpS("eventFlagVillager.txt", GetVillagerEventFlagNames(pathBCSV));
            DumpS("eventFlagLand.txt", GetLandEventFlagNames(pathBCSV));

            DumpS("ItemKind.txt", GetPossibleEnum(pathBCSV, "ItemParam.bcsv", 0xFC275E86));
            DumpS("PlantKind.txt", GetPossibleEnum(pathBCSV, "FgMainParam.bcsv", 0x48EF0398));
            DumpS("TerrainKind.txt", GetNumberedEnumValues(pathBCSV, "FieldLandMakingUnitModelParam.bcsv", 0x39B5A93D, 0x54706054));
            DumpS("BridgeKind.txt", GetNumberedEnumValues(pathBCSV, "StructureBridgeParam.bcsv", 0x39B5A93D, 0x54706054));
            DumpS("BridgeMaterial.txt", GetNumberedEnumValues(pathBCSV, "StructureBridgeTypeParam.bcsv", 0x68CF5938, 0x54706054));
            DumpS("SlopeKind.txt", GetNumberedEnumValues(pathBCSV, "StructureSlopeParam.bcsv", 0x39B5A93D, 0x54706054));
            DumpS("RoofKind.txt", GetNumberedEnumValues(pathBCSV, "StructureHouseRoofParam.bcsv", 0x39B5A93D, 0x54706054));
            DumpS("DoorKind.txt", GetNumberedEnumValues(pathBCSV, "StructureHouseDoorParam.bcsv", 0x39B5A93D, 0x54706054));
            DumpS("WallKind.txt", GetNumberedEnumValues(pathBCSV, "StructureHouseWallParam.bcsv", 0x39B5A93D, 0x54706054));

            DumpB("item_kind.bin", GetItemKindArray(pathBCSV));
            DumpS("plants.txt", GetPlantedNames(pathBCSV));

            if (csv)
                BCSVConverter.DumpAll(pathBCSV, dest, delim);
        }

        private static IEnumerable<string> GetPossibleEnumValues(string pathBCSV, string fn, uint key)
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
            var bcsv = new BCSV(data);

            var dict = bcsv.GetFieldDictionary();
            var fType = dict[key];

            var types = new HashSet<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var type = bcsv.ReadValue(i, fType).TrimEnd('\0');
                if (!types.Contains(type))
                    types.Add(type);
            }

            return types;
        }

        private static IEnumerable<string> GetNumberedEnumValues(string pathBCSV, string fn, uint keyName, uint keyValue)
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
            var bcsv = new BCSV(data);

            var dict = bcsv.GetFieldDictionary();
            var fType = dict[keyName];
            var fitemID = dict[keyValue];

            var types = new List<string>();
            var set = new Dictionary<string, int>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var iid = bcsv.ReadValue(i, fitemID);
                var ival = ushort.Parse(iid);
                var type = bcsv.ReadValue(i, fType).TrimEnd('\0');
                if (set.TryGetValue(type, out var count))
                {
                    count++;
                    set[type] = count;
                    type += $"_{count}";
                }
                else
                {
                    set.Add(type, 1);
                }

                types.Add($"{type} = 0x{ival:X2},");
            }

            return types;
        }

        private static IEnumerable<string> GetPossibleEnum(string pathBCSV, string fn, uint key)
        {
            var kinds = GetPossibleEnumValues(pathBCSV, fn, key);
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

        private static IEnumerable<string> GetAcreNames(string pathBCSV, string fn = "FieldOutsideParts.bcsv")
        {
            var bcsv = BCSVConverter.GetBCSV(pathBCSV, fn);
            var dict = bcsv.GetFieldDictionary();
            var findex = dict[0x54706054];
            var fname = dict[0x39B5A93D];

            var result = new List<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var iid = bcsv.ReadValue(i, findex);
                var ival = ushort.Parse(iid);

                var name = bcsv.ReadValue(i, fname).TrimEnd('\0');

                var kvp = $"{{0x{ival:X2}, \"{name}\"}}, // {ival}";
                result.Add(kvp);
            }

            result.Sort();
            return result;
        }

        private static IEnumerable<string> GetPlantedNames(string pathBCSV, string fn = "FgMainParam.bcsv")
        {
            var bcsv = BCSVConverter.GetBCSV(pathBCSV, fn);
            var dict = bcsv.GetFieldDictionary();
            var fType = dict[0x48EF0398];
            var fname = dict[0x87BF00E8];
            var findex = dict[0x54706054];
            var fcomment = dict[0x3F45F2BF];

            var result = new List<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var iid = bcsv.ReadValue(i, findex);
                var ival = (ushort)short.Parse(iid);

                var name = bcsv.ReadValue(i, fname).TrimEnd('\0');
                var comment = bcsv.ReadValue(i, fcomment).TrimEnd('\0');
                var type = bcsv.ReadValue(i, fType).TrimEnd('\0');

                if (!Enum.TryParse<FieldItemKind>(type, out var k))
                    throw new InvalidEnumArgumentException($"{type} is not a known enum value @ index {i}. Update the enum index first.");

                var v = $"new {nameof(FieldItemDefinition)}(0x{ival:X}, \"{name}\", {nameof(FieldItemKind)}.{k})";
                var kvp = $"{{0x{ival:X}, {v}}}, // {comment}";
                result.Add(kvp);
            }

            result.Sort();
            return result;
        }

        private static IEnumerable<string> GetEventFlagNames(string pathBCSV, string fn = "EventFlagsPlayerParam.bcsv")
        {
            var bcsv = BCSVConverter.GetBCSV(pathBCSV, fn);
            var dict = bcsv.GetFieldDictionary();
            var fv1 = dict[0x4C24F1CF];
            var fv2 = dict[0x344B17D7];
            var fname = dict[0x45F320F2];
            var findex = dict[0x54706054];
            var fcomment = dict[0x85CF1615];

            var result = new List<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var iv1 = bcsv.ReadValue(i, fv1).Substring(2);
                var iv1a = short.Parse(iv1, NumberStyles.HexNumber);

                var iv2 = bcsv.ReadValue(i, fv2).Substring(2);
                var iv2a = short.Parse(iv2, NumberStyles.HexNumber);

                var iid = bcsv.ReadValue(i, findex);
                var ival = (ushort)short.Parse(iid);

                var name = bcsv.ReadValue(i, fname).TrimEnd('\0');
                var comment = bcsv.ReadValue(i, fcomment).TrimEnd('\0');

                var paddedName = $"\"{name}\"".PadRight(45, ' ');
                var v = $"new {nameof(EventFlagPlayer)}({iv1a,-2}, {iv2a,-4}, {ival:0000}, {paddedName})";
                var kvp = $"{{0x{ival:X3}, {v}}}, // {comment}";
                result.Add(kvp);
            }

            result.Sort();
            return result;
        }

        private static IEnumerable<string> GetVillagerEventFlagNames(string pathBCSV, string fn = "EventFlagsNpcSaveParam.bcsv")
        {
            var bcsv = BCSVConverter.GetBCSV(pathBCSV, fn);
            var dict = bcsv.GetFieldDictionary();
            var fv1 = dict[0x4C24F1CF];
            var fv2 = dict[0x344B17D7];
            var fname = dict[0x45F320F2];
            var findex = dict[0x54706054];
            var fcomment = dict[0x85CF1615];

            var result = new List<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var iv1 = bcsv.ReadValue(i, fv1).Substring(2);
                var iv1a = short.Parse(iv1, NumberStyles.HexNumber);

                var iv2 = bcsv.ReadValue(i, fv2).Substring(2);
                var iv2a = short.Parse(iv2, NumberStyles.HexNumber);

                var iid = bcsv.ReadValue(i, findex);
                var ival = (ushort)short.Parse(iid);

                var name = bcsv.ReadValue(i, fname).TrimEnd('\0');
                var comment = bcsv.ReadValue(i, fcomment).TrimEnd('\0');

                var paddedName = $"\"{name}\"".PadRight(45, ' ');
                var v = $"new {nameof(EventFlagVillager)}({iv1a,-2}, {iv2a,-4}, {ival:0000}, {paddedName})";
                var kvp = $"{{0x{ival:X3}, {v}}}, // {comment}";
                result.Add(kvp);
            }

            result.Sort();
            return result;
        }

        private static IEnumerable<string> GetLandEventFlagNames(string pathBCSV, string fn = "EventFlagsLandParam.bcsv")
        {
            var bcsv = BCSVConverter.GetBCSV(pathBCSV, fn);
            var dict = bcsv.GetFieldDictionary();
            var fv1 = dict[0x4C24F1CF];
            var fv2 = dict[0x344B17D7];
            var fname = dict[0x45F320F2];
            var findex = dict[0x54706054];
            var fcomment = dict[0x85CF1615];

            var result = new List<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var iv1 = bcsv.ReadValue(i, fv1).Substring(2);
                var iv1a = short.Parse(iv1, NumberStyles.HexNumber);

                var iv2 = bcsv.ReadValue(i, fv2).Substring(2);
                var iv2a = short.Parse(iv2, NumberStyles.HexNumber);

                var iid = bcsv.ReadValue(i, findex);
                var ival = (ushort)short.Parse(iid);

                var name = bcsv.ReadValue(i, fname).TrimEnd('\0');
                var comment = bcsv.ReadValue(i, fcomment).TrimEnd('\0');

                var paddedName = $"\"{name}\"".PadRight(45, ' ');
                var v = $"new {nameof(EventFlagLand)}({iv1a,-2}, {iv2a,-5}, {ival:0000}, {paddedName})";
                var kvp = $"{{0x{ival:X3}, {v}}}, // {comment}";
                result.Add(kvp);
            }

            result.Sort();
            return result;
        }
    }
}

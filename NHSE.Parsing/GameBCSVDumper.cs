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
        /// <param name="remapBCSV">Change BCSV magic numbers to string if available</param>
        /// <param name="delim">Delimiter when exporting the <see cref="csv"/> files</param>
        public static void UpdateDumps(string pathBCSV, string dest, bool csv = false, bool remapBCSV = true, string delim = "\t")
        {
            ExtractInfo(pathBCSV, dest);

            if (csv)
                UpdateCSV(pathBCSV, Path.Combine(dest, "csv"), remapBCSV, delim);
        }

        private static void ExtractInfo(string pathBCSV, string dest)
        {
            var itemNames = GameInfo.Strings.itemlist;

            void DumpS(string fn, IEnumerable<string> lines, string dir = "text")
            {
                Directory.CreateDirectory(Path.Combine(dest, dir));
                File.WriteAllLines(Path.Combine(dest, dir, fn), lines);
                Console.WriteLine($"Created {fn}");
            }

            void DumpB(string fn, byte[] bytes, string dir = "bin")
            {
                Directory.CreateDirectory(Path.Combine(dest, dir));
                File.WriteAllBytes(Path.Combine(dest, dir, fn), bytes);
                Console.WriteLine($"Created {fn}");
            }

            void DumpU(string fn, ushort[] ushorts, string dir = "bin")
            {
                Directory.CreateDirectory(Path.Combine(dest, dir));
                byte[] bytes = new byte[ushorts.Length * 2];
                Buffer.BlockCopy(ushorts, 0, bytes, 0, ushorts.Length * 2);
                File.WriteAllBytes(Path.Combine(dest, dir, fn), bytes);
                Console.WriteLine($"Created {fn}");
            }

            void DumpD<T, S>(string fn, Dictionary<T, S> dict, string dir = "text")
            {
                Directory.CreateDirectory(Path.Combine(dest, dir));
                var lines = dict.Select(z => $"{{{z.Key}, {z.Value:00000}}},");
                File.WriteAllLines(Path.Combine(dest, dir, fn), lines);
                Console.WriteLine($"Created {fn}");
            }

            DumpS("bcsv_map.txt", BCSV.EnumLookup.Dump());
            DumpS("lifeSupportAchievement.txt", GetLifeSupportAchievementList(pathBCSV));
            DumpS("recipeDictionary.txt", GetRecipeList(pathBCSV));
            DumpS("outsideAcres.txt", GetAcreNames(pathBCSV));

            DumpS("fish.txt", GetFishList(pathBCSV, itemNames));
            DumpS("dive.txt", GetDiveList(pathBCSV, itemNames));
            DumpS("bugs.txt", GetInsectList(pathBCSV, itemNames));
            DumpS("fossils.txt", GetFossilList(pathBCSV, itemNames));
            DumpS("eventFlagPlayer.txt", GetEventFlagNames(pathBCSV));
            DumpS("eventFlagHouse.txt", GetEventFlagHouse(pathBCSV));
            DumpS("eventFlagVillager.txt", GetVillagerEventFlagNames(pathBCSV));
            DumpS("eventFlagVillagerMemoryPlayer.txt", GetVillagerEventFlagNamesMemoryPlayer(pathBCSV));
            DumpS("eventFlagLand.txt", GetLandEventFlagNames(pathBCSV));

            DumpS("ItemKind.txt", GetPossibleEnum(pathBCSV, "ItemParam.bcsv", 0xFC275E86));
            DumpS("ItemSize.txt", GetPossibleEnum(pathBCSV, "ItemParam.bcsv", 0xE06FB090));
            DumpS("ItemMenuIcon.txt", GetPossibleEnum(pathBCSV, "ItemParam.bcsv", 0x348D7B06));
            DumpS("PlantKind.txt", GetPossibleEnum(pathBCSV, "FgMainParam.bcsv", 0x48EF0398));
            DumpS("TerrainKind.txt", GetNumberedEnumValues(pathBCSV, "FieldLandMakingUnitModelParam.bcsv", 0x39B5A93D, 0x54706054));
            DumpS("BridgeKind.txt", GetNumberedEnumValues(pathBCSV, "StructureBridgeParam.bcsv", 0x39B5A93D, 0x54706054));
            DumpS("BridgeMaterial.txt", GetNumberedEnumValues(pathBCSV, "StructureBridgeTypeParam.bcsv", 0x68CF5938, 0x54706054));
            DumpS("SlopeKind.txt", GetNumberedEnumValues(pathBCSV, "StructureSlopeParam.bcsv", 0x39B5A93D, 0x54706054));
            DumpS("RoofKind.txt", GetNumberedEnumValues(pathBCSV, "StructureHouseRoofParam.bcsv", 0x39B5A93D, 0x54706054));
            DumpS("DoorKind.txt", GetNumberedEnumValues(pathBCSV, "StructureHouseDoorParam.bcsv", 0x39B5A93D, 0x54706054));
            DumpS("WallKind.txt", GetNumberedEnumValues(pathBCSV, "StructureHouseWallParam.bcsv", 0x39B5A93D, 0x54706054));

            DumpD("ItemStack.txt", GetItemStackDict(pathBCSV));

            DumpB("item_kind.bin", GetItemKindArray(pathBCSV));
            DumpB("item_size.bin", GetItemSizeArray(pathBCSV));
            DumpU("item_menuicon.bin", GetItemMenuIconArray(pathBCSV));
            DumpS("plants.txt", GetPlantedNames(pathBCSV));
            DumpS("item_size_dictionary.txt", GetItemSizeDictionary(pathBCSV));
            DumpS("item_remake.txt", GetItemRemakeDictionary(pathBCSV));
            DumpS("itemRemakeInfo.txt", GetItemRemakeColors(pathBCSV));
        }

        public static void UpdateCSV(string pathBCSV, string dest, bool remapColumns = false, string delim = "\t")
        {
            BCSV.DecodeColumnNames = remapColumns;
            Directory.CreateDirectory(dest);
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

        public static byte[] GetItemSizeArray(string pathBCSV, string fn = "ItemParam.bcsv")
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
            var bcsv = new BCSV(data);

            var dict = bcsv.GetFieldDictionary();
            var fType = dict[0xE06FB090];
            var fID = dict[0x54706054];

            var types = new Dictionary<ushort, ItemSizeType>();
            ushort max = 0;
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var id = bcsv.ReadValue(i, fID);
                var ival = ushort.Parse(id);
                var type = bcsv.ReadValue(i, fType).TrimEnd('\0');
                type = ItemSizeExtensions.EnumPrefix + type; // can't start with numbers

                if (!Enum.TryParse<ItemSizeType>(type, out var k))
                    throw new InvalidEnumArgumentException($"{type} is not a known enum value @ index {i}. Update the enum index first.");
                types.Add(ival, k);

                if (ival > max)
                    max = ival;
            }

            byte[] result = new byte[max + 1];
            foreach (var kvp in types)
                result[kvp.Key] = (byte)kvp.Value;

            return result;
        }

        public static Dictionary<ItemKind, ushort> GetItemStackDict(string pathBCSV, string fn = "ItemKind.bcsv")
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
            var bcsv = new BCSV(data);

            var dict = bcsv.GetFieldDictionary();
            var fStack = dict[0x4C9BA961]; // MultiHoldMaxNum
            var fKind = dict[0x87BF00E8]; // Label

            // clothing is split out more granularly in ItemKind and would cause errors
            // since it's not likely to ever be stackable, we can skip
            // none-type can be skipped and doesn't exist in ItemKind either
            List<string> skipLabels = new()
            {
                "TopsDefault",
                "Tops",
                "OnePiece",
                "MarineSuit",
                "BottomsDefault",
                "Bottoms",
                "Shoes",
                "None"
            };

            var result = new Dictionary<ItemKind, ushort>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var stack = bcsv.ReadValue(i, fStack);
                switch (stack)
                {
                    case "-1": // for some reason turnips have a stack value of -1, should be 10...
                        stack = "10";
                        break;
                    case "0": // the game stores items that cannot be stacked as 0, so technically they stack to 1
                        stack = "1";
                        break;
                }

                var stackval = ushort.Parse(stack);
                var kind = bcsv.ReadValue(i, fKind).TrimEnd('\0');
                if (skipLabels.Contains(kind))
                    continue;

                kind = "Kind_" + kind;
                if (!Enum.TryParse<ItemKind>(kind, out var k))
                    throw new InvalidEnumArgumentException($"{kind} is not a known enum value @ index {i}. Update the enum index first.");
                result.Add(k, stackval);
            }

            return result;
        }

        public static ushort[] GetItemMenuIconArray(string pathBCSV, string fn = "ItemParam.bcsv")
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
            var bcsv = new BCSV(data);

            var dict = bcsv.GetFieldDictionary();
            var fType = dict[0x348D7B06];
            var fID = dict[0x54706054];

            var types = new Dictionary<ushort, ItemMenuIconType>();
            ushort max = 0;
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var id = bcsv.ReadValue(i, fID);
                var ival = ushort.Parse(id);
                var type = bcsv.ReadValue(i, fType).TrimEnd('\0');

                if (type.StartsWith("0x"))
                    type = $"_{type}"; // enum name can't start with number

                if (!Enum.TryParse<ItemMenuIconType>(type, out var k))
                    throw new InvalidEnumArgumentException($"{type} is not a known enum value @ index {i}. Update the {nameof(ItemMenuIconType)} enum index first.");
                types.Add(ival, k);

                if (ival > max)
                    max = ival;
            }

            ushort[] result = new ushort[max + 1];
            foreach (var kvp in types)
                result[kvp.Key] = (ushort)kvp.Value;

            return result;
        }

        public static string[] GetItemSizeDictionary(string pathBCSV, string fn = "ItemSize.bcsv")
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
            var bcsv = new BCSV(data);

            var dict = bcsv.GetFieldDictionary();

            var fw = dict[0x16B8F524];
            var fh = dict[0xBCB13DAF];
            var fs = dict[0x87BF00E8];
            var fc = dict[0x977ADFCE];

            string[] result = new string[bcsv.EntryCount];

            const string prefix = nameof(ItemSizeType) + "." + ItemSizeExtensions.EnumPrefix;
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var w = bcsv.ReadValue(i, fw).TrimEnd('\0');
                var h = bcsv.ReadValue(i, fh).TrimEnd('\0');
                var s = bcsv.ReadValue(i, fs).TrimEnd('\0');
                var c = bcsv.ReadValue(i, fc).TrimEnd('\0');

                result[i] = $"{{{prefix}{s,-12}, new ItemSize({w,2}, {h,2})}}, // {c}";
            }

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

        public static List<string> GetLifeSupportAchievementList(string pathBCSV, string fn = "EventFlagsLifeSupportAchievementParam.bcsv")
        {
            var bcsv = BCSVConverter.GetBCSV(pathBCSV, fn);

            var dict = bcsv.GetFieldDictionary();
            var findex = dict[0x54706054];
            var fname = dict[0x45F320F2];
            var fcomment = dict[0x85CF1615];
            var fLand = dict[0x3FE43170];
            var fPlayer = dict[0x4171A41D];

            var fmaxLevel = dict[0x1BE772F0];
            var fThreshold1 = dict[0xCE0933FC];
            var fThreshold2 = dict[0x89A9492C];
            var fThreshold3 = dict[0xB4C9609C];
            var fThreshold4 = dict[0x06E9BC8C];
            var fThreshold5 = dict[0x3B89953C];

            var result = new List<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                int readHex(BCSVFieldParam p) => int.Parse(bcsv.ReadValue(i, p).Substring(2), NumberStyles.HexNumber);

                var iid = bcsv.ReadValue(i, findex);
                var index = ushort.Parse(iid);

                var land = readHex(fLand);
                var player = readHex(fPlayer);

                var name = bcsv.ReadValue(i, fname).TrimEnd('\0');
                var paddedName = $"\"{name}\"".PadRight(30, ' ');

                var comment = bcsv.ReadValue(i, fcomment).TrimEnd('\0');

                var tmp = bcsv.ReadValue(i, fmaxLevel);
                var max = ushort.Parse(tmp);
                var t1 = readHex(fThreshold1);
                var t2 = readHex(fThreshold2);
                var t3 = readHex(fThreshold3);
                var t4 = readHex(fThreshold4);
                var t5 = readHex(fThreshold5);

                var values = $"{max}, {t1:0000}, {t2:0000}, {t3:0000}, {t4:0000}, {t5:0000}";

                var v = $"new {nameof(LifeSupportAchievement)}({index:000}, {values}, {land,3}, {player,3}, {paddedName})";
                var kvp = $"{{0x{index:X2}, {v}}}, // {comment}";
                result.Add(kvp);
            }

            result.Sort();
            return result;
        }

        public static IEnumerable<ushort> GetInsectList(string pathBCSV, string fn = "InsectStatusParam.bcsv")
        {
            return GetItemList(pathBCSV, fn, 0x20CB67BC);
        }

        public static IEnumerable<ushort> GetFossilList(string pathBCSV, string fn = "MuseumFossilDonateInfo.bcsv")
        {
            return GetItemList(pathBCSV, fn, 0xB76B7D37);
        }

        public static IEnumerable<ushort> GetFishList(string pathBCSV, string fn = "FishStatusParam.bcsv")
        {
            return GetItemList(pathBCSV, fn, 0x20CB67BC);
        }

        public static IEnumerable<ushort> GetDiveList(string pathBCSV, string fn = "SeafoodStatusParam.bcsv")
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

        public static IEnumerable<string> GetDiveList(string pathBCSV, IReadOnlyList<string> items, string fn = "SeafoodStatusParam.bcsv")
        {
            var insects = GetDiveList(pathBCSV, fn);
            return insects.Select(z => $"{z:00000}, // {items[z]}");
        }

        public static IEnumerable<string> GetFossilList(string pathBCSV, IReadOnlyList<string> items, string fn = "MuseumFossilDonateInfo.bcsv")
        {
            var fossils = GetFossilList(pathBCSV, fn);
            return fossils.Select(z => $"{z:00000}, // {items[z]}");
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

            var fdig = dict[0xF4678F13];
            var fpic = dict[0xB7A46956];

            var result = new List<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var iid = bcsv.ReadValue(i, findex);
                var ival = (ushort)short.Parse(iid);

                var name = bcsv.ReadValue(i, fname).TrimEnd('\0');
                var comment = bcsv.ReadValue(i, fcomment).TrimEnd('\0');
                var type = bcsv.ReadValue(i, fType).TrimEnd('\0');

                var did = bcsv.ReadValue(i, fdig);
                var dval = (ushort)short.Parse(did);

                var pid = bcsv.ReadValue(i, fpic);
                var pval = (ushort)short.Parse(pid);

                if (!Enum.TryParse<FieldItemKind>(type, out var k))
                    throw new InvalidEnumArgumentException($"{type} is not a known enum value @ index {i}. Update the enum index first.");

                var strname = $"\"{name}\"";
                var v = $"new {nameof(FieldItemDefinition)}({ival,-5}, {dval,-5}, {pval,-5}, {strname,-24}, {nameof(FieldItemKind)}.{k,-20})";
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

        private static IEnumerable<string> GetEventFlagHouse(string pathBCSV, string fn = "EventFlagsHouseParam.bcsv")
        {
            var bcsv = BCSVConverter.GetBCSV(pathBCSV, fn);
            var dict = bcsv.GetFieldDictionary();
            var findex = dict[0x54706054];

            var fdefault = dict[0x4C24F1CF];
            var fmax = dict[0x344B17D7];
            var fname = dict[0x45F320F2];
            var fcomment = dict[0x85CF1615];

            var result = new List<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var ivd = bcsv.ReadValue(i, fdefault).Substring(2);
                var vd = short.Parse(ivd, NumberStyles.HexNumber);

                var ivm = bcsv.ReadValue(i, fmax).Substring(2);
                var vm = short.Parse(ivm, NumberStyles.HexNumber);

                var iid = bcsv.ReadValue(i, findex);
                var ival = (ushort)short.Parse(iid);

                var name = bcsv.ReadValue(i, fname).TrimEnd('\0');
                var comment = bcsv.ReadValue(i, fcomment).TrimEnd('\0');

                var paddedName = $"\"{name}\"".PadRight(45, ' ');
                var v = $"new {nameof(EventFlagHouse)}({vd}, {vm,-5}, {ival:0000}, {paddedName})";
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

        private static IEnumerable<string> GetVillagerEventFlagNamesMemoryPlayer(string pathBCSV, string fn = "EventFlagsNpcMemoryParam.bcsv")
        {
            var bcsv = BCSVConverter.GetBCSV(pathBCSV, fn);
            var dict = bcsv.GetFieldDictionary();
            var finit = dict[0xD55938BD];
            var fmax = dict[0xBD7682F5];
            var fname = dict[0x45F320F2];
            var findex = dict[0x54706054];
            var fcomment = dict[0x85CF1615];

            var result = new List<string>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var isinit = bcsv.ReadValue(i, finit);
                var iinit = short.Parse(isinit);

                var ismax = bcsv.ReadValue(i, fmax);
                var imax = short.Parse(ismax);

                var iid = bcsv.ReadValue(i, findex);
                var index = (ushort)short.Parse(iid);

                var name = bcsv.ReadValue(i, fname).TrimEnd('\0');
                var comment = bcsv.ReadValue(i, fcomment).TrimEnd('\0');

                var paddedName = $"\"{name}\"".PadRight(45, ' ');
                var v = $"new {nameof(EventFlagVillagerMemoryPlayer)}({iinit,-2}, {imax,-3}, {index:000}, {paddedName})";
                var kvp = $"{{0x{index:X2}, {v}}}, // {comment}";
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

        public static IEnumerable<string> GetItemRemakeDictionary(string pathBCSV, string fn = "ItemParam.bcsv")
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
            var bcsv = new BCSV(data);

            var dict = bcsv.GetFieldDictionary();
            var fID = dict[0x54706054];
            var fRid = dict[0xCB5EB33F];

            var result = new Dictionary<ushort, short>();
            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var rid = bcsv.ReadValue(i, fRid);
                var rival = short.Parse(rid);

                if (rival < 0)
                    continue;

                var id = bcsv.ReadValue(i, fID);
                var ival = ushort.Parse(id);

                result.Add(ival, rival);
            }

            var str = GameInfo.Strings.itemlist;
            return result.Select(z => $"{{{z.Key:00000}, {z.Value:0000}}}, // {str[z.Key]}");
        }

        public static IEnumerable<string> GetItemRemakeColors(string pathBCSV, string fn = "ItemRemake.bcsv")
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
            var bcsv = new BCSV(data);

            var dict = bcsv.GetFieldDictionary();

            var fid = dict[0xFD9AF1E1]; // ItemUniqueID
            //var fct = dict[0x29ECB129]; // RemakeKitNum
            var rid = dict[0x54706054]; // UniqueID
            // var unk = dict[0xD4F43B0B]; // 
            var b00 = dict[0x1B98FDF8]; // ReBodyPattern0Color0
            var b01 = dict[0xA3249A9D]; // ReBodyPattern0Color1
            var b10 = dict[0xF45A96C6]; // ReBodyPattern1Color0
            var b11 = dict[0x4CE6F1A3]; // ReBodyPattern1Color1
            var b20 = dict[0x1F6D2DC5]; // ReBodyPattern2Color0
            var b21 = dict[0xA7D14AA0]; // ReBodyPattern2Color1
            var b30 = dict[0xF0AF46FB]; // ReBodyPattern3Color0
            var b31 = dict[0x4813219E]; // ReBodyPattern3Color1
            var b40 = dict[0x12735D82]; // ReBodyPattern4Color0
            var b41 = dict[0xAACF3AE7]; // ReBodyPattern4Color1
            var b50 = dict[0xFDB136BC]; // ReBodyPattern5Color0
            var b51 = dict[0x450D51D9]; // ReBodyPattern5Color1
            var b60 = dict[0x16868DBF]; // ReBodyPattern6Color0
            var b61 = dict[0xAE3AEADA]; // ReBodyPattern6Color1
            var b70 = dict[0xF944E681]; // ReBodyPattern7Color0
            var b71 = dict[0x41F881E4]; // ReBodyPattern7Color1
            var bct = dict[0xB0304B0D]; // ReBodyPatternNum
            var f00 = dict[0x545F8769]; // ReFabricPattern0Color0
            var f01 = dict[0xECE3E00C]; // ReFabricPattern0Color1
            var fvf = dict[0x62C23ED0]; // ReFabricPattern0VisibleOff
            var f10 = dict[0xBB9DEC57]; // ReFabricPattern1Color0
            var f11 = dict[0x03218B32]; // ReFabricPattern1Color1
            var f20 = dict[0x50AA5754]; // ReFabricPattern2Color0
            var f21 = dict[0xE8163031]; // ReFabricPattern2Color1
            var f30 = dict[0xBF683C6A]; // ReFabricPattern3Color0
            var f31 = dict[0x07D45B0F]; // ReFabricPattern3Color1
            var f40 = dict[0x5DB42713]; // ReFabricPattern4Color0
            var f41 = dict[0xE5084076]; // ReFabricPattern4Color1
            var f50 = dict[0xB2764C2D]; // ReFabricPattern5Color0
            var f51 = dict[0x0ACA2B48]; // ReFabricPattern5Color1
            var f60 = dict[0x5941F72E]; // ReFabricPattern6Color0
            var f61 = dict[0xE1FD904B]; // ReFabricPattern6Color1
            var f70 = dict[0xB6839C10]; // ReFabricPattern7Color0
            var f71 = dict[0x0E3FFB75]; // ReFabricPattern7Color1

            var str = GameInfo.Strings.itemlist;
            var bc0 = new[] { b00, b10, b20, b30, b40, b50, b60, b70 };
            var bc1 = new[] { b01, b11, b21, b31, b41, b51, b61, b71 };
            var fc0 = new[] { f00, f10, f20, f30, f40, f50, f60, f70 };
            var fc1 = new[] { f01, f11, f21, f31, f41, f51, f61, f71 };

            for (int i = 0; i < bcsv.EntryCount; i++)
            {
                var index = i;
                int get(BCSVFieldParam f)
                {
                    var val = bcsv.ReadValue(index, f);
                    return int.Parse(val);
                }

                string getArr(IEnumerable<BCSVFieldParam> arr)
                {
                    var entries = arr.Select(get).Select(z => z.ToString("00"));
                    var bytes = string.Join(", ", entries);
                    return $"new byte[] {{{bytes}}}";
                }

                var vbc0 = getArr(bc0);
                var vbc1 = getArr(bc1);
                var vfc0 = getArr(fc0);
                var vfc1 = getArr(fc1);

                var vfvf = get(fvf) == 1;
                var ct = get(bct);

                var vid = get(fid);
                //var vct = get(fct);
                var vrd = get(rid);

                // (short index, ushort id, sbyte count, byte[] bc0, byte[] bc1, byte[] fc0, byte[] fc1, bool fp0)
                yield return $"{{{vrd:0000}, new {nameof(ItemRemakeInfo)}({vrd:0000}, {vid:00000}, {(sbyte)ct,2}, {vbc0}, {vbc1}, {vfc0}, {vfc1}, {(vfvf ? " true": "false")})}}, // {str[vid]}";
            }
        }
    }
}

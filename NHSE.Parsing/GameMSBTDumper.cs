using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NHSE.Core;

namespace NHSE.Parsing
{
    public static class GameMSBTDumper
    {
        public static string[] GetItemListResource(string msgPath, string language)
        {
            var list = GetItemList(msgPath, language);
            var max = list.Max(z => z.Key);
            var result = new string?[max + 1];

            foreach (var item in list)
                result[item.Key] = item.Value;
            for (int i = 0; i < result.Length; i++)
                result[i] ??= string.Empty;

            FinalizeItemList(language, result!);
            return result!;
        }

        private static void FinalizeItemList(string language, string[] result)
        {
            result[0] = $"({GetNoneName(language)})";
            result[5794] = $"({GetDIYRecipeName(language)})";
            foreach (var internalItem in InternalItemList)
                result[internalItem.Key] = internalItem.Value;
        }

        public static string[] GetArtList(string msgPath)
        {
            var file = Path.Combine(msgPath, "Item", "STR_ItemName_01_Art.msbt");
            var pairs = GetLabelList(file).ToArray(); // (itemID, itemName)

            var result = new List<string>();
            foreach (var (Label, Text) in pairs)
            {
                var label = Label;
                var underscore = label.IndexOf('_');
                var itemIDs = label.Substring(underscore + 1);
                ushort itemID = ushort.Parse(itemIDs);

                var fake = label.Contains("Fake") ? " (forgery)" : string.Empty;
                result.Add($"{itemID:00000}, // {Text}{fake}");
            }
            result.Sort();
            return result.ToArray();
        }

        public static string[] GetVillagerListResource(string msgPath)
        {
            var file = Path.Combine(msgPath, "Npc", "STR_NNpcName.msbt");
            var list = GetLabelList(file);
            var normal = list.Select(z => $"{z.Label}\t{z.Text}").OrderBy(z => z);

            file = Path.Combine(msgPath, "Npc", "STR_SNpcName.msbt");
            list = GetLabelList(file);
            var special = list.Select(z => $"{z.Label}\t{z.Text}").OrderBy(z => z);

            return normal.Concat(special).ToArray();
        }

        public static Dictionary<ushort, string> GetItemList(string msgPath, string language)
        {
            var result = new Dictionary<ushort, string>();
            AddRegularItems(result, msgPath, language);
            AddColoredItems(result, msgPath);
            return result;
        }

        private static void AddRegularItems(IDictionary<ushort, string> result, string msgPath, string language)
        {
            var pitem = Path.Combine(msgPath, "Item");
            var fitem = Directory.EnumerateFiles(pitem);
            var regularItemList = GetLabelList(fitem); // (itemID, itemName)

            var forgery = GetForgerySuffix(language);
            foreach (var (label, text) in regularItemList)
            {
                if (label.EndsWith("_pl"))
                    continue;

                var underscore = label.IndexOf('_');
                var itemIDs = label.Substring(underscore + 1);
                ushort itemID = ushort.Parse(itemIDs);

                var itemText = text;
                if (label.StartsWith("PictureFake") || label.StartsWith("SculptureFake"))
                    itemText = $"{itemText} ({forgery})";

                result.Add(itemID, itemText);
            }
        }

        private static string GetNoneName(string language)
        {
            return language switch
            {
                "de" => "Leer",
                "es" => "Ningun",
                "fr" => "Aucun",
                "it" => "Nessuna",
                "ko" => "없음",
                "ja" => "無し",
                "chs" => "没有",
                "cht" => "沒有",
                _ => "None",
            };
        }

        private static string GetDIYRecipeName(string language)
        {
            return language switch
            {
                "de" => "DIY recipe",
                "es" => "DIY recipe",
                "fr" => "DIY recipe",
                "it" => "DIY recipe",
                "ko" => "DIY recipe",
                "ja" => "DIY recipe",
                "chs" => "DIY recipe",
                "cht" => "DIY recipe",
                _ => "DIY recipe",
            };
        }

        private static string GetForgerySuffix(string language)
        {
            return language switch
            {
                "de" => "fälschung",
                "es" => "falsificación",
                "fr" => "falsification",
                "it" => "falsificazione",
                "ko" => "위조",
                "ja" => "偽造",
                "chs" => "伪造",
                "cht" => "偽造",
                _ => "forgery",
            };
        }

        private static readonly Dictionary<int, string> InternalItemList = new()
        {
            {4200, "k.k. slider's guitar (internal)"},
        };

        private static void AddColoredItems(IDictionary<ushort, string> result, string msgPath)
        {
            var pgname = Path.Combine(msgPath, "Outfit", "GroupName"); // (baseItemName, groupID)
            var pgcolor = Path.Combine(msgPath, "Outfit", "GroupColor"); // (itemID_type_groupID, color)
            var fgname = Directory.EnumerateFiles(pgname);
            var fgcolor = Directory.EnumerateFiles(pgcolor);

            var coloredItemList = GetLabelList(fgcolor);
            var coloredItemBaseNameList = GetLabelList(fgname);
            var baseColorItem = coloredItemBaseNameList
                .ToDictionary(z => (ushort) short.Parse(z.Label), z => z.Text);

            foreach (var (label, text) in coloredItemList)
            {
                var (itemID, baseId) = GetUniqueColorItemDefinition(label);
                if (!baseColorItem.TryGetValue(baseId, out var baseItemName))
                    continue;

                var itemName = $"{baseItemName} ({text})";
                result.Add(itemID, itemName);
            }
        }

        private static IEnumerable<(string Label, string Text)> GetLabelList(IEnumerable<string> files)
        {
            foreach (var path in files.Where(z => z.EndsWith("msbt")))
            {
                foreach (var valueTuple in GetLabelList(path))
                    yield return valueTuple;
            }
        }

        public static IEnumerable<(string Label, string Text)> GetLabelList(string path)
        {
            var msbt = new MSBT(File.ReadAllBytes(path));
            foreach (var e in msbt.LBL1.Labels)
                yield return GetCleanLabelText(e, msbt.TXT2.Strings);
        }

        private static (string Label, string Text) GetCleanLabelText(MSBTLabel lbl, IList<MSBTTextString> txt)
        {
            var label = lbl.Name;
            var index = (int)lbl.Index;
            var strObj = txt[index];
            var text = strObj.ToStringNoAtoms();
            return (label, text);
        }

        private static (ushort ItemID, ushort BaseID) GetUniqueColorItemDefinition(string line)
        {
            var split = line.Split('_');

            var BaseID = ushort.Parse(split[0]);
            //Type = split[1];
            var ItemID = ushort.Parse(split[2]);

            return (ItemID, BaseID);
        }
    }
}

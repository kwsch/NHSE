using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NHSE.Core;

namespace NHSE.Parsing
{
    public static class GameMSBTDumper
    {
        public static string[] GetItemListResource(string msgPath)
        {
            var list = GetItemList(msgPath);
            var max = list.Max(z => z.Key);
            var result = new string[max + 1];

            foreach (var item in list)
                result[item.Key] = item.Value;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] is null)
                    result[i] = string.Empty;
            }
            result[0] = "(None)";
            return result;
        }

        public static Dictionary<ushort, string> GetItemList(string msgPath)
        {
            var result = new Dictionary<ushort, string>();
            AddRegularItems(result, msgPath);
            AddColoredItems(result, msgPath);
            return result;
        }

        private static void AddRegularItems(IDictionary<ushort, string> result, string msgPath)
        {
            var pitem = Path.Combine(msgPath, "Item");
            var fitem = Directory.EnumerateFiles(pitem);
            var regularItemList = GetLabelList(fitem); // (itemID, itemName)
            foreach (var (label, text) in regularItemList)
            {
                if (label.EndsWith("_pl"))
                    continue;

                var underscore = label.IndexOf('_');
                var itemIDs = label.Substring(underscore + 1);
                ushort itemID = ushort.Parse(itemIDs);

                var itemText = text;
                if (label.StartsWith("PictureFake") || label.StartsWith("SculptureFake"))
                    itemText = $"{itemText} (forgery)";

                result.Add(itemID, itemText);
            }
        }

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
                var msbt = new MSBT(File.ReadAllBytes(path));
                foreach (var e in msbt.LBL1.Labels)
                    yield return GetCleanLabelText(e, msbt.TXT2.Strings);
            }
        }

        private static (string Label, string Text) GetCleanLabelText(MSBTLabel lbl, IList<MSBTTextString> txt)
        {
            var label = lbl.Name;

            var index = (int)lbl.Index;
            var text = txt[index].ToString(Encoding.Unicode);
            if (text.StartsWith("\u000e")) // string formatting present; discard formatting!
                text = text.Substring(6);
            text = StringUtil.TrimFromZero(text);

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

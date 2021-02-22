using System.Collections.Generic;

namespace NHSE.Core
{
    /// <summary>
    /// Stores game localization strings for use by logic.
    /// </summary>
    public sealed class GameStrings : IRemakeString
    {
        private readonly string lang;

        public readonly string[] villagers;
        public readonly string[] itemlist;
        public readonly string[] itemlistdisplay;
        public readonly string[] villagerDefaultPhrases;
        public readonly Dictionary<string, string> VillagerMap;
        public readonly Dictionary<string, string> VillagerDefaultPhraseMap;
        public readonly List<ComboItem> ItemDataSource;
        public readonly Dictionary<string, string> InternalNameTranslation = new();

        public IReadOnlyDictionary<string, string> BodyParts { get; }
        public IReadOnlyDictionary<string, string> BodyColor { get; }
        public IReadOnlyDictionary<string, string> FabricParts { get; }
        public IReadOnlyDictionary<string, string> FabricColor { get; }

        private string[] Get(string ident) => GameLanguage.GetStrings(ident, lang);

        public GameStrings(string l)
        {
            lang = l;
            villagers = Get("villager");
            VillagerMap = GetMap(villagers);
            villagerDefaultPhrases = Get("phrase");
            VillagerDefaultPhraseMap = GetMap(villagerDefaultPhrases);
            itemlist = Get("item");
            itemlistdisplay = GetItemDisplayList(itemlist);
            ItemDataSource = CreateItemDataSource(itemlistdisplay);

            BodyParts = GetDictionary(Get("body_parts"));
            BodyColor = GetDictionary(Get("body_color"));
            FabricParts = GetDictionary(Get("fabric_parts"));
            FabricColor = GetDictionary(Get("fabric_color"));
        }

        private static IReadOnlyDictionary<string, string> GetDictionary(IEnumerable<string> lines, char split = '\t')
        {
            var result = new Dictionary<string, string>();
            foreach (var s in lines)
            {
                if (s.Length == 0)
                    continue;
                var index = s.IndexOf(split);
                var key = s.Substring(0, index);
                var value = s.Substring(index + 1);
                result.Add(key, value);
            }
            return result;
        }

        private List<ComboItem> CreateItemDataSource(string[] strings)
        {
            var dataSource = ComboItemUtil.GetArray(strings);

            // load special
            dataSource.Add(new ComboItem(itemlist[0], Item.NONE));
            dataSource.SortByText();

            return dataSource;
        }

        public List<ComboItem> CreateItemDataSource(IReadOnlyCollection<ushort> dict, bool none = true)
        {
            var display = itemlistdisplay;
            var result = new List<ComboItem>(dict.Count);
            foreach (var x in dict)
                result.Add(new ComboItem(display[x], x));

            if (none)
                result.Add(new ComboItem(itemlist[0], Item.NONE));

            result.SortByText();
            return result;
        }

        public List<ComboItem> CreateItemDataSource(IReadOnlyCollection<KeyValuePair<ushort, ushort>> dict, bool none = true)
        {
            var display = itemlistdisplay;
            var result = new List<ComboItem>(dict.Count);
            foreach (var x in dict)
                result.Add(new ComboItem(display[x.Value], x.Key));

            if (none)
                result.Add(new ComboItem(itemlist[0], Item.NONE));

            result.SortByText();
            return result;
        }

        private static Dictionary<string, string> GetMap(IReadOnlyCollection<string> arr)
        {
            var map = new Dictionary<string, string>(arr.Count);
            foreach (var kvp in arr)
            {
                var index = kvp.IndexOf('\t');
                if (index < 0)
                    continue;
                var abbrev = kvp.Substring(0, index);
                var name = kvp.Substring(index + 1);
                map.Add(abbrev, name);
            }
            return map;
        }

        public string GetVillager(string name)
        {
            return VillagerMap.TryGetValue(name, out var result) ? result : name;
        }

        public string GetVillagerDefaultPhrase(string name)
        {
            return VillagerDefaultPhraseMap.TryGetValue(name, out var result) ? result : name; // I know it shouldn't be name but I have to return something
        }

        public static string[] GetItemDisplayList(string[] items)
        {
            items = (string[])items.Clone();
            items[0] = string.Empty;
            var set = new HashSet<string>();
            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                if (string.IsNullOrEmpty(item))
                    items[i] = $"(Item #{i:000})";
                else if (set.Contains(item))
                    items[i] += $" (#{i:000})";
                else
                    set.Add(item);
            }
            return items;
        }

        public string GetItemName(Item item)
        {
            var index = item.ItemId;
            if (index == Item.NONE)
                return itemlist[0];
            if (index == Item.EXTENSION)
                return GetItemName(item.ExtensionItemId);

            var kind = ItemInfo.GetItemKind(index);

            if (kind.IsFlowerGene(index))
            {
                var display = GetItemName(index);
                if (item.Genes != 0)
                    return $"{display} - {item.Genes}";
            }

            if (kind == ItemKind.Kind_DIYRecipe || kind == ItemKind.Kind_MessageBottle)
            {
                var display = itemlistdisplay[index];
                var recipeID = (ushort)item.FreeParam;
                var isKnown = RecipeList.Recipes.TryGetValue(recipeID, out var result);
                var makes = isKnown ? GetItemName(result) : recipeID.ToString("000");
                return $"{display} - {makes}";
            }

            if (kind == ItemKind.Kind_FossilUnknown)
            {
                var display = itemlistdisplay[index];
                var fossilID = (ushort)item.FreeParam;
                var fossilName = GetItemName(fossilID);
                return $"{display} - {fossilName}";
            }

            if (kind == ItemKind.Kind_Tree)
            {
                var display = GetItemName(index);
                var willDrop = item.Count;
                if (willDrop != 0)
                {
                    var dropName = GetItemName(willDrop);
                    return $"{display} - {dropName}";
                }
            }

            return GetItemName(index);
        }

        public string GetItemName(ushort index)
        {
            if (index >= itemlistdisplay.Length)
                return GetItemName60000(index);
            return itemlistdisplay[index];
        }

        private static string GetItemName60000(ushort index)
        {
            if (FieldItemList.Items.TryGetValue(index, out var val))
                return val.Name;

            // 63,000 ???
            if (index == Item.LLOYD)
                return "Lloyd";

            return "???";
        }

        /// <summary>
        /// Returns clothing or item recolors not a part of ItemRemake with brackets in their names
        /// </summary>
        /// <param name="id">ItemID of the color variation search</param>
        /// <param name="baseItemName">Item name without the associated recolors</param>
        /// <returns>Map of ItemID, ItemName</returns>
        public List<ComboItem> GetAssociatedItems(ushort id, out string baseItemName)
        {
            var stringMatch = GetItemName(id);
            var index = stringMatch.IndexOf('(');
            if (index < 0)
            {
                baseItemName = string.Empty;
                return new List<ComboItem>();
            }

            var search = baseItemName = stringMatch.Substring(0, index);
            return ItemDataSource.FindAll(x => x.Text.StartsWith(search));
        }
    }

    public interface IRemakeString
    {
        IReadOnlyDictionary<string, string> BodyParts { get; }
        IReadOnlyDictionary<string, string> BodyColor { get; }
        IReadOnlyDictionary<string, string> FabricParts { get; }
        IReadOnlyDictionary<string, string> FabricColor { get; }
    }
}

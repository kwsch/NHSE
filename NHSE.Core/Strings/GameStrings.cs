using System.Collections.Generic;

namespace NHSE.Core
{
    public sealed class GameStrings
    {
        private readonly string lang;

        public readonly string[] villagers;
        public readonly string[] itemlist;
        public readonly string[] itemlistdisplay;
        public readonly Dictionary<string, string> VillagerMap;
        public readonly List<ComboItem> ItemDataSource;

        private string[] Get(string ident) => GameLanguage.GetStrings(ident, lang);

        public GameStrings(string l)
        {
            lang = l;
            villagers = Get("villager");
            VillagerMap = GetMap(villagers);
            itemlist = Get("item");
            itemlistdisplay = GetItemDisplayList(itemlist);
            ItemDataSource = CreateItemDataSource(itemlistdisplay);
        }

        private List<ComboItem> CreateItemDataSource(string[] strings)
        {
            var dataSource = ComboItemUtil.GetArray(strings);

            // load special
            dataSource.Add(new ComboItem(itemlist[0], Item.NONE));
            dataSource.SortByText();

            return dataSource;
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
                var split = kvp.Split('\t');
                map.Add(split[0], split[1]);
            }
            return map;
        }

        public string GetVillager(string name)
        {
            return VillagerMap.TryGetValue(name, out var result) ? result : name;
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
            var kind = ItemInfo.GetItemKind(index);

            if (kind == ItemKind.Kind_DIYRecipe)
            {
                var display = itemlistdisplay[index];
                var recipeID = item.Count;
                var isKnown = RecipeList.Recipes.TryGetValue(recipeID, out var result);
                var makes = isKnown ? GetItemName(result) : recipeID.ToString("000");
                return $"{display} - {makes}";
            }

            return GetItemName(index);
        }

        public string GetItemName(FieldItem item)
        {
            var index = item.DisplayItemId;
            if (index == FieldItem.NONE)
                return itemlist[0];

            var items = itemlistdisplay;
            if (index >= items.Length)
            {
                if (FieldItemList.Items.TryGetValue(index, out var val))
                    return val.Name;
                return "???";
            }

            var kind = ItemInfo.GetItemKind(index);
            if (kind == ItemKind.Kind_DIYRecipe)
            {
                var display = itemlistdisplay[index];
                var recipeID = item.Count;
                var isKnown = RecipeList.Recipes.TryGetValue(recipeID, out var result);
                var makes = isKnown ? GetItemName(result) : recipeID.ToString("000");
                return $"{display} - {makes}";
            }

            return GetItemName(index);
        }

        public string GetItemName(ushort index)
        {
            if (index >= itemlistdisplay.Length)
                return "???";
            return itemlistdisplay[index];
        }
    }
}

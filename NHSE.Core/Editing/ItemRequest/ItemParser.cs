using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NHSE.Core
{
    /// <summary>
    /// Logic for retrieving <see cref="Item"/> details based off input strings.
    /// </summary>
    public static class ItemParser
    {
        /// <summary>
        /// Invert the recipe dictionary so we can look up recipe IDs from an input item ID.
        /// </summary>
        public static readonly IReadOnlyDictionary<ushort, ushort> InvertedRecipeDictionary =
            RecipeList.Recipes.ToDictionary(z => z.Value, z => z.Key);

        // Users can put spaces between item codes, or newlines. Recognize both!
        private static readonly string[] SplittersHex = {" ", "\n", "\r\n"};
        private static readonly string[] SplittersName = {",", "\n", "\r\n"};

        /// <summary>
        /// Gets a list of items from the requested hex string(s).
        /// </summary>
        /// <remarks>
        /// If the first input is a language code (2 characters), the logic will try to parse item names for that language instead of item IDs.
        /// </remarks>
        /// <param name="requestHex">8 byte hex item values (u64 format)</param>
        /// <param name="cfg">Options for packaging items</param>
        /// <param name="type">End destination of the item</param>
        public static IReadOnlyCollection<Item> GetItemsFromUserInput(string requestHex, IConfigItem cfg, ItemDestination type = ItemDestination.PlayerDropped)
        {
            try
            {
                // having a language 2char code will cause an exception in parsing; this is fine and is handled by our catch statement.
                var split = requestHex.Split(SplittersHex, StringSplitOptions.RemoveEmptyEntries);
                return GetItemsHexCode(split, cfg, type);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
#pragma warning restore CA1031 // Do not catch general exception types
            {
                var split = requestHex.Split(SplittersName, StringSplitOptions.RemoveEmptyEntries);
                return GetItemsLanguage(split, cfg, type, GameLanguage.DefaultLanguage);
            }
        }

        /// <summary>
        /// Gets a list of DIY item cards from the requested list of DIY IDs.
        /// </summary>
        /// <remarks>
        /// If the first input is a language code (2 characters), the logic will try to parse item names for that language instead of DIY IDs.
        /// </remarks>
        /// <param name="requestHex">8 byte hex item values (u64 format)</param>
        public static IReadOnlyCollection<Item> GetDIYsFromUserInput(string requestHex)
        {
            try
            {
                // having a language 2char code will cause an exception in parsing; this is fine and is handled by our catch statement.
                var split = requestHex.Split(SplittersHex, StringSplitOptions.RemoveEmptyEntries);
                return GetDIYItemsHexCode(split);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
#pragma warning restore CA1031 // Do not catch general exception types
            {
                var split = requestHex.Split(SplittersName, StringSplitOptions.RemoveEmptyEntries);
                return GetDIYItemsLanguage(split);
            }
        }

        /// <summary>
        /// Gets a list of items from the requested list of DIY hex code strings.
        /// </summary>
        /// <remarks>
        /// If a hex code parse fails or a recipe ID does not exist, exceptions will be thrown.
        /// </remarks>
        /// <param name="split">List of recipe IDs as u16 hex</param>
        public static IReadOnlyCollection<Item> GetDIYItemsHexCode(IReadOnlyList<string> split)
        {
            var result = new Item[split.Count];
            for (int i = 0; i < result.Length; i++)
            {
                var text = split[i].Trim();
                bool parse = ulong.TryParse(text, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out var value);
                if (!parse)
                    throw new Exception($"Item value out of expected range ({text}).");

                if (!RecipeList.Recipes.TryGetValue((ushort)value, out _))
                    throw new Exception($"DIY recipe appears to be invalid ({text}).");

                result[i] = new Item(Item.DIYRecipe) { Count = (ushort)value };
            }
            return result;
        }

        /// <summary>
        /// Gets a list of DIY item cards from the requested list of item name strings.
        /// </summary>
        /// <remarks>
        /// If a item name parse fails or a recipe ID does not exist, exceptions will be thrown.
        /// </remarks>
        /// <param name="split">List of item names</param>
        /// <param name="lang">Language code to parse with. If the first entry in <see cref="split"/> is a language code, it will be used instead of <see cref="lang"/>.</param>
        public static IReadOnlyCollection<Item> GetDIYItemsLanguage(IReadOnlyList<string> split, string lang = GameLanguage.DefaultLanguage)
        {
            if (split.Count > 1 && split[0].Length < 3)
            {
                var langIndex = GameLanguage.GetLanguageIndex(split[0]);
                lang = GameLanguage.Language2Char(langIndex);
                split = split.Skip(1).ToArray();
            }

            var result = new Item[split.Count];
            for (int i = 0; i < result.Length; i++)
            {
                var text = split[i].Trim();
                var item = GetItem(text, lang);
                if (!InvertedRecipeDictionary.TryGetValue(item.ItemId, out var diy))
                    throw new Exception($"DIY recipe appears to be invalid ({text}).");

                result[i] = new Item(Item.DIYRecipe) { Count = diy };
            }
            return result;
        }

        /// <summary>
        /// Gets a list of items from the requested list of item name strings.
        /// </summary>
        /// <remarks>
        /// If a item name parse fails or the item ID does not exist as a known item, exceptions will be thrown.
        /// </remarks>
        /// <param name="split">List of item names</param>
        /// <param name="config">Item packaging options</param>
        /// <param name="type">Destination where the item will end up at</param>
        /// <param name="lang">Language code to parse with. If the first entry in <see cref="split"/> is a language code, it will be used instead of <see cref="lang"/>.</param>
        public static IReadOnlyCollection<Item> GetItemsLanguage(IReadOnlyList<string> split, IConfigItem config, ItemDestination type = ItemDestination.PlayerDropped, string lang = GameLanguage.DefaultLanguage)
        {
            if (split.Count > 1 && split[0].Length < 3)
            {
                var langIndex = GameLanguage.GetLanguageIndex(split[0]);
                lang = GameLanguage.Language2Char(langIndex);
                split = split.Skip(1).ToArray();
            }

            var strings = GameInfo.Strings.itemlistdisplay;
            var result = new Item[split.Count];
            for (int i = 0; i < result.Length; i++)
            {
                var text = split[i].Trim();
                var item = CreateItem(text, i, config, type, lang);

                if (item.ItemId >= strings.Length)
                    throw new Exception($"Item requested is out of expected range ({item.ItemId:X4} > {strings.Length:X4}).");
                if (string.IsNullOrWhiteSpace(strings[item.ItemId]))
                    throw new Exception($"Item requested does not have a valid name ({item.ItemId:X4}).");

                result[i] = item;
            }
            return result;
        }

        /// <summary>
        /// Gets a list of items from the requested list of item hex code strings.
        /// </summary>
        /// <remarks>
        /// If a hex code parse fails or a recipe ID does not exist, exceptions will be thrown.
        /// </remarks>
        /// <param name="split">List of recipe IDs as u16 hex</param>
        /// <param name="config">Item packaging options</param>
        /// <param name="type">Destination where the item will end up at</param>
        public static IReadOnlyCollection<Item> GetItemsHexCode(IReadOnlyList<string> split, IConfigItem config, ItemDestination type = ItemDestination.PlayerDropped)
        {
            var strings = GameInfo.Strings.itemlistdisplay;
            var result = new Item[split.Count];
            for (int i = 0; i < result.Length; i++)
            {
                var text = split[i].Trim();
                var convert = GetBytesFromString(text);
                var item = CreateItem(convert, i, config, type);

                if (item.ItemId >= strings.Length)
                    throw new Exception($"Item requested is out of expected range ({item.ItemId:X4} > {strings.Length:X4}).");
                if (string.IsNullOrWhiteSpace(strings[item.ItemId]))
                    throw new Exception($"Item requested does not have a valid name ({item.ItemId:X4}).");

                result[i] = item;
            }
            return result;
        }

        private static byte[] GetBytesFromString(string text)
        {
            if (!ulong.TryParse(text, NumberStyles.AllowHexSpecifier, CultureInfo.CurrentCulture, out var value))
                return Item.NONE.ToBytes();
            return BitConverter.GetBytes(value);
        }

        private static Item CreateItem(string name, int requestIndex, IConfigItem config, ItemDestination type, string lang = "en")
        {
            var item = GetItem(name, lang);
            if (item.IsNone)
                throw new Exception($"Failed to convert item (index {requestIndex}: {name}) for Language {lang}.");

            return FinalizeItem(requestIndex, config, type, item);
        }

        private static Item CreateItem(byte[] convert, int requestIndex, IConfigItem config, ItemDestination type)
        {
            Item item;
            try
            {
                if (convert.Length != Item.SIZE)
                    throw new Exception();
                item = convert.ToClass<Item>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to convert item (index {requestIndex}: {ex.Message}).");
            }

            return FinalizeItem(requestIndex, config, type, item);
        }

        private static Item FinalizeItem(int requestIndex, IConfigItem config, ItemDestination type, Item item)
        {
            if (type == ItemDestination.PlayerDropped)
            {
                if (!ItemInfo.IsSaneItemForDrop(item))
                    throw new Exception($"Unsupported item: (index {requestIndex}).");
                if (config.WrapAllItems && item.ShouldWrapItem())
                    item.SetWrapping(ItemWrapping.WrappingPaper, config.WrappingPaper, true);
            }

            item.IsDropped = type == ItemDestination.FieldItemDropped;

            return item;
        }

        private static readonly CompareInfo Comparer = CultureInfo.InvariantCulture.CompareInfo;
        private const CompareOptions optIncludeSymbols = CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreWidth;
        private const CompareOptions optIgnoreSymbols = CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreWidth;

        /// <summary>
        /// Gets a sensitive compare option, depending on the input string's qualities.
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>Default options if no symbols,</returns>
        private static CompareOptions GetCompareOption(string str) => str.Any(ch => !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch)) ? optIgnoreSymbols & ~CompareOptions.IgnoreSymbols : optIgnoreSymbols;

        /// <summary>
        /// Gets the first item name-value that contains the <see cref="itemName"/> (case insensitive).
        /// </summary>
        /// <param name="itemName">Requested Item</param>
        /// <param name="lang">Game strings language to fetch with</param>
        /// <returns>Returns <see cref="Item.NO_ITEM"/> if no match found.</returns>
        public static Item GetItem(string itemName, string lang = "en")
        {
            var strings = GameInfo.GetStrings(lang).ItemDataSource;
            return GetItem(itemName, strings);
        }

        /// <summary>
        /// Gets the first item name-value that contains the <see cref="itemName"/> (case insensitive).
        /// </summary>
        /// <param name="itemName">Requested Item</param>
        /// <param name="strings">Game strings</param>
        /// <returns>Returns <see cref="Item.NO_ITEM"/> if no match found.</returns>
        public static Item GetItem(string itemName, IReadOnlyList<ComboItem> strings)
        {
            if (TryGetItem(itemName, strings, out var id))
                return new Item(id);
            return Item.NO_ITEM;
        }

        /// <summary>
        /// Gets the first item name-value that contains the <see cref="itemName"/> (case insensitive).
        /// </summary>
        /// <param name="itemName">Requested Item</param>
        /// <param name="strings">List of item name-values</param>
        /// <param name="value">Item ID, if found. Otherwise, 0</param>
        /// <returns>True if found, false if none.</returns>
        public static bool TryGetItem(string itemName, IReadOnlyList<ComboItem> strings, out ushort value)
        {
            if (TryGetItem(itemName, strings, out value, optIncludeSymbols))
                return true;
            return TryGetItem(itemName, strings, out value, optIgnoreSymbols);
        }

        private static bool TryGetItem(string itemName, IEnumerable<ComboItem> strings, out ushort value, CompareOptions opt)
        {
            foreach (var item in strings)
            {
                var result = Comparer.Compare(item.Text, 0, itemName, 0, opt);
                if (result != 0)
                    continue;

                value = (ushort)item.Value;
                return true;
            }

            value = Item.NONE;
            return false;
        }

        /// <summary>
        /// Gets an enumerable list of item key-value pairs that contain (case insensitive) the requested <see cref="itemName"/>.
        /// </summary>
        /// <param name="itemName">Item name</param>
        /// <param name="strings">Item names (and their Item ID values)</param>
        public static IEnumerable<ComboItem> GetItemsMatching(string itemName, IEnumerable<ComboItem> strings)
        {
            var opt = GetCompareOption(itemName);
            foreach (var item in strings)
            {
                var result = Comparer.IndexOf(item.Text, itemName, opt);
                if (result < 0)
                    continue;
                yield return item;
            }
        }

        /// <summary>
        /// Gets an enumerable list of item key-value pairs that contain (case insensitive) the requested <see cref="itemName"/>.
        /// </summary>
        /// <remarks>
        /// Orders the items based on the closest match (<see cref="LevenshteinDistance"/>).
        /// </remarks>
        /// <param name="itemName">Item name</param>
        /// <param name="strings">Item names (and their Item ID values)</param>
        public static IEnumerable<ComboItem> GetItemsMatchingOrdered(string itemName, IEnumerable<ComboItem> strings)
        {
            var matches = GetItemsMatching(itemName, strings);
            return GetItemsClosestOrdered(itemName, matches);
        }

        /// <summary>
        /// Gets an enumerable list of item key-value pairs ordered by the closest <see cref="LevenshteinDistance"/> for the requested <see cref="itemName"/>.
        /// </summary>
        /// <param name="itemName">Item name</param>
        /// <param name="strings">Item names (and their Item ID values)</param>
        public static IEnumerable<ComboItem> GetItemsClosestOrdered(string itemName, IEnumerable<ComboItem> strings)
        {
            return strings.OrderBy(z => LevenshteinDistance.Compute(z.Text, itemName));
        }

        /// <summary>
        /// Gets the Item Name and raw 8-byte value as a string.
        /// </summary>
        /// <param name="item">Item value</param>
        public static string GetItemText(Item item)
        {
            var value = BitConverter.ToUInt64(item.ToBytesClass(), 0);
            var name = GameInfo.Strings.GetItemName(item.ItemId);
            return $"{name}: {value:X16}";
        }

        /// <summary>
        /// Gets the u16 item ID from the input hex code.
        /// </summary>
        /// <param name="text">Hex code for the item (preferably 4 digits)</param>
        public static ushort GetID(string text)
        {
            if (!ulong.TryParse(text.Trim(), NumberStyles.AllowHexSpecifier, CultureInfo.CurrentCulture, out var value))
                return Item.NONE;
            return (ushort)value;
        }
    }

    public enum ItemDestination
    {
        PlayerDropped,
        FieldItemDropped,
        HeldItem,
    }
}

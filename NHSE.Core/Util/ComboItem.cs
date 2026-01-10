using System;
using System.Collections.Generic;

namespace NHSE.Core
{
    /// <summary>
    /// Key Value pair for a displayed <see cref="T:System.String" /> and underlying <see cref="T:System.Int32" /> value.
    /// </summary>
    public record ComboItem(string Text, int Value);

    public static class ComboItemUtil
    {
        public static List<ComboItem> GetArray(ReadOnlySpan<string> items)
        {
            var result = new List<ComboItem>(items.Length / 2);
            for (int i = 0; i < items.Length; i++)
            {
                var text = items[i];
                if (text.Length == 0)
                    continue;
                var item = new ComboItem(text, i);
                result.Add(item);
            }

            return result;
        }

        public static List<ComboItem> GetArray<T>(Type t) where T : struct, IFormattable
        {
            var names = Enum.GetNames(t);
            var values = (T[])Enum.GetValues(t);

            var acres = new List<ComboItem>(names.Length);
            for (int i = 0; i < names.Length; i++)
                acres.Add(new ComboItem($"{names[i]} - {values[i]:X}", (ushort)(object)values[i]));
            acres.SortByText();
            return acres;
        }

        public static List<ComboItem> GetArray(ReadOnlySpan<ushort> values, ReadOnlySpan<string> names)
        {
            var result = new List<ComboItem>(values.Length);
            foreach (var value in values)
            {
                var text = names[value];
                var item = new ComboItem(text, value);
                result.Add(item);
            }

            return result;
        }

        public static void Add(this List<ComboItem> storage, IReadOnlyList<INamedValue> tuples, Dictionary<string, string> translate)
        {
            int initial = storage.Count;
            storage.Capacity = storage.Count + tuples.Count;
            foreach (var kvp in tuples)
            {
                var translated = translate.TryGetValue(kvp.Name, out var t) ? t : kvp.Name;
                var item = new ComboItem(translated, kvp.Index);
                storage.Add(item);
            }
            storage.Sort(initial, storage.Count - initial, Comparer);
        }

        public static string ToStringList(this List<ComboItem> arr, bool includeValues)
        {
            string format = string.Empty;
            foreach (var ci in arr)
                format += includeValues ? $"{ci.Text} ({ci.Value:X})\n" : $"{ci.Text}\n";
            return format;
        }

        public static void SortByText(this List<ComboItem> arr) => arr.Sort(Comparer);

        private static readonly FunctorComparer<ComboItem> Comparer =
            new((a, b) => string.CompareOrdinal(a.Text, b.Text));

        private sealed class FunctorComparer<T>(Comparison<T> Comparison) : IComparer<T> where T : notnull
        {
            public int Compare(T? x, T? y)
            {
                if (x is null)
                    return y is null ? 0 : -1;
                return y is null ? 1 : Comparison(x, y);
            }
        }
    }
}

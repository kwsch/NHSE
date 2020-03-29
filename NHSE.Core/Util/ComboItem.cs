using System;
using System.Collections.Generic;

namespace NHSE.Core
{
    /// <summary>
    /// Key Value pair for a displayed <see cref="T:System.String" /> and underlying <see cref="T:System.Int32" /> value.
    /// </summary>
    public readonly struct ComboItem : IEquatable<int>
    {
        public string Text { get; }
        public int Value { get; }

        public ComboItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public bool Equals(ComboItem other) => Value == other.Value && string.Equals(Text, other.Text);
        public bool Equals(int other) => Value == other;
        public override bool Equals(object obj) => obj is ComboItem other && Equals(other);
        public override int GetHashCode() => Value;
        public static bool operator ==(ComboItem left, ComboItem right) => left.Equals(right);
        public static bool operator !=(ComboItem left, ComboItem right) => !(left == right);
    }

    public static class ComboItemUtil
    {
        public static List<ComboItem> GetArray(string[] items)
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

        public static void SortByText(this List<ComboItem> arr) => arr.Sort(Comparer);

        private static readonly FunctorComparer<ComboItem> Comparer =
            new FunctorComparer<ComboItem>((a, b) => string.CompareOrdinal(a.Text, b.Text));

        private sealed class FunctorComparer<T> : IComparer<T>
        {
            private readonly Comparison<T> Comparison;
            public FunctorComparer(Comparison<T> comparison) => Comparison = comparison;
            public int Compare(T x, T y) => Comparison(x, y);
        }
    }
}

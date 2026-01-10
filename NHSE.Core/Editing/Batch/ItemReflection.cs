using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NHSE.Core
{
    public class ItemReflection
    {
        public static ItemReflection Default { get; } = new();

        public readonly Type[] Types = [typeof(Item), typeof(VillagerItem)];
        public string[][] Properties => GetProperties.Value;

        /// <summary>
        /// Extra properties to show in the list of selectable properties (GUI)
        /// </summary>
        private static readonly string[] CustomProperties =
        [
        ];

        public readonly Dictionary<string, PropertyInfo>.AlternateLookup<ReadOnlySpan<char>>[] Props;
        private readonly Lazy<string[][]> GetProperties;

        public ItemReflection()
        {
            Props = GetPropertyDictionaries(Types);
            GetProperties = new Lazy<string[][]>(() => GetPropArray(Props, CustomProperties));
        }

        private static Dictionary<string, PropertyInfo>.AlternateLookup<ReadOnlySpan<char>>[] GetPropertyDictionaries(ReadOnlySpan<Type> types)
        {
            var result = new Dictionary<string, PropertyInfo>.AlternateLookup<ReadOnlySpan<char>>[types.Length];
            for (int i = 0; i < types.Length; i++)
                result[i] = GetPropertyDictionary(types[i], ReflectUtil.GetAllPropertyInfoPublic).GetAlternateLookup<ReadOnlySpan<char>>();
            return result;
        }

        private static Dictionary<string, PropertyInfo> GetPropertyDictionary(Type type, Func<Type, IEnumerable<PropertyInfo>> selector)
        {
            const int expectedMax = 8;
            var dict = new Dictionary<string, PropertyInfo>(expectedMax);
            var props = selector(type);
            foreach (var p in props)
                dict.TryAdd(p.Name, p);
            return dict;
        }

        private static string[][] GetPropArray<T>(Dictionary<string, T>.AlternateLookup<ReadOnlySpan<char>>[] types, ReadOnlySpan<string> extra)
        {
            // Create a list for all types, [inAny, ..types, inAll]
            var result = new string[types.Length + 2][];
            var p = result.AsSpan(1, types.Length);

            for (int i = 0; i < p.Length; i++)
            {
                var type = types[i].Dictionary;
                string[] combine = [.. type.Keys, .. extra];
                Array.Sort(combine);
                p[i] = combine;
            }

            // Properties for any PKM
            // Properties shared by all PKM
            var first = p[0];
            var any = new HashSet<string>(first);
            var all = new HashSet<string>(first);
            foreach (var set in p[1..])
            {
                any.UnionWith(set);
                all.IntersectWith(set);
            }

            var arrAny = any.ToArray();
            Array.Sort(arrAny);
            result[0] = arrAny;

            var arrAll = all.ToArray();
            Array.Sort(arrAll);
            result[^1] = arrAll;

            return result;
        }
    }
}

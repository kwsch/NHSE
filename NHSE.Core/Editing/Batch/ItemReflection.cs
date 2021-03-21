using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NHSE.Core
{
    public class ItemReflection
    {
        public static ItemReflection Default { get; } = new();

        public readonly Type[] Types = { typeof(Item), typeof(VillagerItem) };
        public readonly Dictionary<string, PropertyInfo>[] Props;
        public readonly string[][] Properties;

        public ItemReflection()
        {
            Props = Types
                .Select(z => ReflectUtil.GetAllPropertyInfoPublic(z)
                    .GroupBy(p => p.Name)
                    .Select(g => g.First())
                    .ToDictionary(p => p.Name))
                .ToArray();

            Properties = GetPropArray();
        }

        public string[][] GetPropArray()
        {
            var p = new string[Types.Length][];
            for (int i = 0; i < p.Length; i++)
            {
                var pz = ReflectUtil.GetPropertiesPublic(Types[i]);
                p[i] = pz.OrderBy(a => a).ToArray();
            }

            // Properties for any
            var any = ReflectUtil.GetPropertiesPublic(typeof(Item)).Union(p.SelectMany(a => a)).OrderBy(a => a).ToArray();
            // Properties shared by all
            var all = p.Aggregate(new HashSet<string>(p[0]), (h, e) => { h.IntersectWith(e); return h; }).OrderBy(a => a).ToArray();

            var p1 = new string[Types.Length + 2][];
            Array.Copy(p, 0, p1, 1, p.Length);
            p1[0] = any;
            p1[p1.Length - 1] = all;

            return p1;
        }
    }
}

using System.Collections.Generic;

namespace NHSE.Core
{
    public sealed class GameStrings
    {
        private readonly string lang;

        public readonly string[] villagers;
        public readonly string[] itemlist;
        public readonly Dictionary<string, string> VillagerMap;

        private string[] Get(string ident) => GameLanguage.GetStrings(ident, lang);

        public GameStrings(string l)
        {
            lang = l;
            villagers = Get("villager");
            VillagerMap = GetMap(villagers);
            itemlist = Get("item");
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
            return VillagerMap.TryGetValue(name, out var result) ? result : "???";
        }
    }
}

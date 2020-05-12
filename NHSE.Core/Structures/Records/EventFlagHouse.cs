using System.Collections.Generic;

namespace NHSE.Core
{
    public class EventFlagHouse : INamedValue
    {
        // these are actually unsigned
        public readonly short DefaultValue;
        public readonly short MaxValue;

        public ushort Index { get; }
        public string Name { get; }

        public EventFlagHouse(short init, short max, ushort index, string name)
        {
            Name = name;
            Index = index;
            DefaultValue = init;
            MaxValue = max;
        }

        public static readonly IReadOnlyDictionary<ushort, EventFlagHouse> List = new Dictionary<ushort, EventFlagHouse>
        {
            {0x001, new EventFlagHouse(0, 1    , 0001, "HouseOrder1"                                )}, // テント→6x6増築申込
            {0x002, new EventFlagHouse(0, 1    , 0002, "HouseOrder2"                                )}, // 6x6→8x8増築申込
            {0x003, new EventFlagHouse(0, 1    , 0003, "HouseOrder3"                                )}, // 8x8→8x8+奥増築申込
            {0x004, new EventFlagHouse(0, 1    , 0004, "HouseOrder4"                                )}, // 8x8+奥→8x8+奥左増築申込
            {0x005, new EventFlagHouse(0, 1    , 0005, "HouseOrder5"                                )}, // 8x8+奥左→8x8+奥左右増築申込
            {0x006, new EventFlagHouse(0, 1    , 0006, "HouseOrder6"                                )}, // 8x8+奥左右→2F増築申込
            {0x007, new EventFlagHouse(0, 1    , 0007, "HouseOrder7"                                )}, // 2F→地下増築申込
            {0x009, new EventFlagHouse(0, 10000, 0009, "CountHouseBuild"                            )}, // テントから家になって何日目か
            {0x00A, new EventFlagHouse(0, 10000, 0010, "CountUnderGroundBuild"                      )}, // 地下室ができて何日目か
            {0x00B, new EventFlagHouse(0, 10000, 0011, "CountHouseExtension"                        )}, // 最後に増築してからの日数
        };

        private const string Unknown = "???";

        public static string GetName(ushort index, short count, IReadOnlyDictionary<string, string> str)
        {
            var dict = List;
            if (dict.TryGetValue(index, out var val))
            {
                string name = val.Name;
                if (str.TryGetValue(name, out var translated))
                    name = translated;
                return $"{index:00} - {name} = {count}";
            }
            return $"{index:00} - {Unknown} = {count}";
        }

        public static string GetName(ushort index, short count)
        {
            var dict = List;
            if (dict.TryGetValue(index, out var val))
                return $"{index:00} - {val.Name} = {count}";
            return $"{index:00} - {Unknown} = {count}";
        }
    }
}
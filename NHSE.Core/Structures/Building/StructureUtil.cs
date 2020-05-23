using System.Collections.Generic;
using System.Linq;

namespace NHSE.Core
{
    /// <summary>
    /// Retrieves value metadata for customizing structures.
    /// </summary>
    public static class StructureUtil
    {
        public static Dictionary<string, string[]> GetStructureHelpList()
        {
            var kvpa = new[]
            {
                EnumUtil.GetEnumList<BuildingType>(),

                EnumUtil.GetEnumList<DoorKind>(),
                EnumUtil.GetEnumList<RoofType>(),
                EnumUtil.GetEnumList<WallType>(),

                EnumUtil.GetEnumList<BridgeType>(),
                EnumUtil.GetEnumList<BridgeMaterial>(),
                EnumUtil.GetEnumList<SlopeType>(),
            };
            return kvpa.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}

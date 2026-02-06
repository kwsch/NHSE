using System;
using System.Diagnostics;
using System.Linq;
using NHSE.Core;
using static NHSE.Villagers.Properties.Resources;

namespace NHSE.Villagers;

public static class VillagerResources
{
    private static string GetResourceNameVillager(string villagerName) => $"{villagerName}V";
    private static string GetResourceNameHouse(string villagerName) => $"{villagerName}H";

    /// <summary>
    /// Checks if the villager name is in the database.
    /// </summary>
    /// <param name="villagerName">Internal villager name.</param>
    /// <returns>True if exists in database</returns>
    public static bool IsVillagerDataKnown(string villagerName) => ResourceManager.GetObject(GetResourceNameVillager(villagerName)) != null;

    /// <summary>
    /// Gets the raw Villager data and house data for the <see cref="villagerName"/>.
    /// </summary>
    /// <param name="villagerName">Internal villager name.</param>
    public static VillagerData GetVillager(string villagerName)
    {
        var nv = GetResourceNameVillager(villagerName);
        var nh = GetResourceNameHouse(villagerName);

        if (ResourceManager.GetObject(nv) is not byte[] bv)
            throw new ArgumentException($"Villager data not found for {villagerName} ({nv})", nameof(villagerName));

        if (ResourceManager.GetObject(nh) is not byte[] bh)
            throw new ArgumentException($"House data not found for {villagerName} ({nh})", nameof(villagerName));

        Debug.Assert(bv.Length == Villager2.SIZE);
        Debug.Assert(bh.Length == VillagerHouse2.SIZE);

        return new VillagerData(bv.ToArray(), bh.ToArray());
    }
}
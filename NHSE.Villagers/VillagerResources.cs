using System.Diagnostics;
using NHSE.Core;
using static NHSE.Villagers.Properties.Resources;

namespace NHSE.Villagers
{
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

            var bv = (byte[])ResourceManager.GetObject(nv);
            var bh = (byte[])ResourceManager.GetObject(nh);
            Debug.Assert(bv.Length == Villager2.SIZE);
            Debug.Assert(bh.Length == VillagerHouse.SIZE);

            return new VillagerData(bv, bh);
        }
    }
}

using System.Drawing;
using NHSE.Core;
using NHSE.Sprites.Properties;

namespace NHSE.Sprites
{
    /// <summary>
    /// Provides sprites for Villagers.
    /// </summary>
    public static class VillagerSprite
    {
        /// <summary>
        /// Gets the Villager's 128x128 sprite based on the input parameters.
        /// </summary>
        /// <param name="species">Species of Villager</param>
        /// <param name="variant">Variant of Villager</param>
        public static Image? GetVillagerSprite(VillagerSpecies species, int variant)
        {
            var asset = VillagerUtil.GetInternalVillagerName(species, variant);
            return GetVillagerSprite(asset);
        }

        /// <summary>
        /// Gets the sprite for the Villager based on its internal name.
        /// </summary>
        /// <param name="asset">Internal name of the villager (3char, 2digit)</param>
        public static Image? GetVillagerSprite(string asset)
        {
            return (Image?)Resources.ResourceManager.GetObject(asset);
        }
    }
}

using System.Drawing;
using NHSE.Core;
using NHSE.Sprites.Properties;

namespace NHSE.Sprites
{
    public static class VillagerSprite
    {
        public static Image? GetVillagerSprite(VillagerSpecies species, int variant)
        {
            var asset = VillagerUtil.GetInternalVillagerName(species, variant);
            return GetVillagerSprite(asset);
        }

        public static Image? GetVillagerSprite(string asset)
        {
            return (Image?)Resources.ResourceManager.GetObject(asset);
        }
    }
}

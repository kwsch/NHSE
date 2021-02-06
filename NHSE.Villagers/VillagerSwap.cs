using NHSE.Core;

namespace NHSE.Villagers
{
    public static class VillagerSwap
    {
        public static VillagerData GetReplacementVillager(VillagerInfo exist, string newVillager, bool prepMoveOut = false)
        {
            var replace = VillagerResources.GetVillager(newVillager);
            return AdaptVillager(exist, replace, prepMoveOut);
        }

        private static VillagerData AdaptVillager(VillagerInfo exist, VillagerData replace, bool prepMoveOut = false)
        {
            var ov = exist.Villager;
            var oh = exist.House;
            var nv = new Villager2(replace.Villager);
            _ = new VillagerHouse(replace.House) {NPC1 = oh.NPC1, NPC2 = oh.NPC2, BuildPlayer = oh.BuildPlayer};

            // Copy Memories
            var om = nv.GetMemory(0);
            var nm = ov.GetMemory(0);
            nm.PlayerId = om.PlayerId;
            nv.SetMemory(nm, 0);

            if (!prepMoveOut)
                return replace;

            nv.MovingOut = true;
            return replace;
        }
    }
}

namespace NHSE.Core
{
    public static class VillagerUtil
    {
        public static string GetInternalVillagerName(VillagerSpecies species, int variant) => $"{species}{variant:00}";
    }

    public enum VillagerSpecies
    {
        ant = 0,
        bea = 1,
        brd = 2,
        bul = 3,
        cat = 4,
        cbr = 5,
        chn = 6,
        cow = 7,
        crd = 8,
        der = 9,
        dog = 10,
        duk = 11,
        elp = 12,
        flg = 13,
        goa = 14,
        gor = 15,
        ham = 16,
        hip = 17,
        hrs = 18,
        kal = 19,
        kgr = 20,
        lon = 21,
        mnk = 22,
        mus = 23,
        ocp = 24,
        ost = 25,
        pbr = 26,
        pgn = 27,
        pig = 28,
        rbt = 29,
        rhn = 30,
        shp = 31,
        squ = 32,
        tig = 33,
        wol = 34,
        non = 35,
    }
}

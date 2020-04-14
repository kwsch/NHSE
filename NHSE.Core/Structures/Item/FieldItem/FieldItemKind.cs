namespace NHSE.Core
{
    public enum FieldItemKind : byte
    {
        FenceBamboo,
        FenceBarbedWire,
        FenceChinese,
        FenceDriedStraw,
        FenceEasterEgg,
        FenceHorizontalLog,
        FenceHorizontalWood,
        FenceIronAndStone,
        FenceJapanese,
        FenceLattice,
        FenceLog,
        FencePegRope,
        FenceSharply,
        FenceSteel,
        FenceStone,
        FenceVerticalWood,
        FenceWallRenga,
        FenceWoodWhite,
        PltFlwAnemone,
        PltFlwCosmos,
        PltFlwHyacinth,
        PltFlwLily,
        PltFlwMum,
        PltFlwPansy,
        PltFlwRose,
        PltFlwRoseGold,
        PltFlwTulip,
        PltFlwYuri,
        PltTreeBamboo,
        PltTreeCedar,
        PltTreeCedarDeco,
        PltTreeOak,
        PltTreePalm,
        PltWeedAut0,
        PltWeedAut1,
        PltWeedAut2,
        PltWeedSmr,
        PltWeedSpr,
        PltWeedWin0,
        PltWeedWin1,
        StoneA,
        StoneB,
        StoneC,
        StoneD,
        StoneE,
        UnitIconHole,
    }

    public static class FieldItemKindExtensions
    {
        public static bool IsWeed(this FieldItemKind type) => FieldItemKind.PltWeedAut0 <= type && type <= FieldItemKind.PltWeedWin1;
        public static bool IsPlant(this FieldItemKind type) => FieldItemKind.PltFlwAnemone <= type && type <= FieldItemKind.PltWeedWin1;
        public static bool IsFence(this FieldItemKind type) => FieldItemKind.FenceBamboo <= type && type <= FieldItemKind.FenceWoodWhite;
    }
}

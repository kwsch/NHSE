using static NHSE.Core.FieldItemKind;

namespace NHSE.Core;

public enum FieldItemKind : byte
{
    FenceBamboo,
    FenceBarbedWire,
    FenceChinese,
    FenceConcreteBlock,
    FenceCorrugatedIron,
    FenceCrossedBamboo,
    FenceDriedStraw,
    FenceEasterEgg,
    FenceGardenPegRope,
    FenceHalloween,
    FenceHorizontalLog,
    FenceHorizontalWood,
    FenceIce,
    FenceIkegaki,
    FenceIronAndStone,
    FenceJapanese,
    FenceJuneBride,
    FenceLattice,
    FenceLatticeBig,
    FenceLog,
    FenceLogWall,
    FenceMermaid,
    FencePark,
    FencePegRope,
    FenceSandProtection,
    FenceSharply,
    FenceSteel,
    FenceStone,
    FenceVerticalWood,
    FenceWallRenga,
    FenceWoodWhite,
    LadderKitA,
    LadderKitB,
    LadderKitC,
    LadderKitD,
    PltBushAzalea,
    PltBushCamellia,
    PltBushHibiscus,
    PltBushHolly,
    PltBushHydrangea,
    PltBushOsmanthus,
    PltBushPlumeria,
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
    PltVgtCarrot,
    PltVgtPotato,
    PltVgtPumpkin,
    PltVgtSugarcane,
    PltVgtTomato,
    PltVgtWheat,
    PltVine,
    PltWeedAut0,
    PltWeedAut1,
    PltWeedAut2,
    PltWeedLight,
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
    extension(FieldItemKind type)
    {
        public bool IsWeed => type is (>= PltWeedAut0 and <= PltWeedWin1);
        public bool IsPlant => type is (>= PltFlwAnemone and <= PltWeedWin1);
        public bool IsFence => type is (>= FenceBamboo and <= FenceWoodWhite);
        public bool IsBush => type is (>= PltBushAzalea and <= PltBushOsmanthus);
        public bool IsFlower => type is (>= PltFlwAnemone and <= PltFlwYuri);
        public bool IsTree => type is (>= PltTreeBamboo and <= PltTreePalm);
        public bool IsStone => type is (>= StoneA and <= StoneE);

        public ItemKind ToItemKind()
        {
            if (type.IsTree)
                return ItemKind.Kind_Tree;
            if (type.IsFlower)
                return ItemKind.Kind_Flower;
            if (type.IsWeed)
                return ItemKind.Kind_Weed;
            return ItemKind.Unknown;
        }
    }
}
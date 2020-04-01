using System.Collections.Generic;

namespace NHSE.Core
{
    public static class ActivityNames
    {
        private const string Unknown = "???";

        private static readonly IReadOnlyDictionary<int, string> Dictionary = new Dictionary<int, string>
        {
            // {00,"PlayTime"},
            // {01,"GetFishCount"},
            // {02,"GetInsectCount"},
            // {03,"GetShellfishCount"},
            // {04,"GetShellDriftCount"},
            // {05,"BreakBalloonCount"},
            // {06,"WishStarCount"},
            // {07,"ShakeTreeCount"},
            // {08,"DropWoodCount"},
            // {09,"CutTreeCount"},
            // {10,"PlantTreeCount"},
            // {11,"WaterFlowerCount"},
            // {12,"UseReactionCount"},
            // {13,"VisitOtherIslandCount"},
            // {14,"InviteVisitorNum"},
            // {15,"DiyCount"},
            // {16,"BreakToolCount"},
            // {17,"InMyHouseTime"},
            // {18,"InFieldTime"},
            // {19,"FillPitCount"},
            // {20,"CaughtPitCount"},
            // {21,"InteriorModeTime"},
            // {22,"DesignEditTime"},
            // {34,"TalkNpc0Count"},
            // {35,"TalkNpc1Count"},
            // {36,"TalkNpc2Count"},
            // {37,"TalkNpc3Count"},
            // {38,"TalkNpc4Count"},
            // {39,"TalkNpc5Count"},
            // {40,"TalkNpc6Count"},
            // {41,"TalkNpc7Count"},
            // {42,"TalkNpc8Count"},
            // {43,"TalkNpc9Count"},
            // {44,"TalkAllNpcCount"},
            // {45,"BittenBeeCount"},
            // {46,"DigFossilCount"},
            // {47,"HitStoneCount"},
            // {48,"PlantMoneyFlag"},
            // {49,"PickUpFruitsCount"},
            // {50,"UseSmartphoneFieldCount"},
            // {51,"UseSmartphoneFieldTime"},
            // {52,"WayEditCount"},
            // {53,"RiverEditCount"},
            // {54,"CliffEditCount"},
            // {55,"FenceEditCount"},
            // {56,"MoveFurnitureFieldCount"},
            // {57,"GetMiles"},
            // {58,"ReturnLoanFlag"},
            // {59,"EnterShopCount"},
            // {60,"ChangeMelodyFlag"},
            // {61,"ChangeFlagFlag"},
            // {62,"TransformFieldCount"},
            // {63,"JumpWithPoleCount"},
            // {64,"TurnipBuyTotal"},
            // {65,"TurnipSellPrice"},
            // {66,"ChatBalloonCount"},
            // {67,"PullWeedCount"},
            // {68,"ChangeHairFlag"},
            // {69,"ChangeFaceFlag"},
            // {70,"TakePictureCount"},
        };

        public static string GetActivityName(int index, uint count)
        {
            var dict = Dictionary;
            if (dict.TryGetValue(index, out var val))
                return $"{index:00} - {val} = {count}";
            return $"{index:00} - {Unknown} = {count}";
        }
    }
}

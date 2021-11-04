using System.Collections.Generic;

namespace NHSE.Core
{
    public static class FieldItemList
    {
        public static ItemKind GetFieldItemKind(ushort id)
        {
            if (!Items.TryGetValue(id, out var definition))
                return ItemKind.Unknown;

            var remap = definition.HeldItemId;
            if (remap >= 60_000)
                return definition.Kind.ToItemKind();

            var rkind = ItemInfo.GetItemKind(remap);
            if (rkind != ItemKind.Unknown)
                return rkind;

            // shouldn't reach here, but play it safe
            return definition.Kind.ToItemKind();
        }

        public static readonly IReadOnlyDictionary<ushort, FieldItemDefinition> Items = new Dictionary<ushort, FieldItemDefinition>
        {
            {0xEA60, new FieldItemDefinition(60000, 2799 , 65534, "PltTreeOak4"           , FieldItemKind.PltTreeOak          )}, // 広葉樹（成木）
            {0xEA61, new FieldItemDefinition(60001, 3360 , 65534, "PltTreeApple"          , FieldItemKind.PltTreeOak          )}, // リンゴの木（成木）
            {0xEA62, new FieldItemDefinition(60002, 3365 , 65534, "PltTreeOrange"         , FieldItemKind.PltTreeOak          )}, // オレンジの木（成木）
            {0xEA65, new FieldItemDefinition(60005, 5152 , 65534, "PltTreeOak0"           , FieldItemKind.PltTreeOak          )}, // 広葉樹（苗）
            {0xEA66, new FieldItemDefinition(60006, 2796 , 65534, "PltTreeOak1"           , FieldItemKind.PltTreeOak          )}, // 広葉樹（成長１）
            {0xEA67, new FieldItemDefinition(60007, 2797 , 65534, "PltTreeOak2"           , FieldItemKind.PltTreeOak          )}, // 広葉樹（成長２）
            {0xEA68, new FieldItemDefinition(60008, 2798 , 65534, "PltTreeOak3"           , FieldItemKind.PltTreeOak          )}, // 広葉樹（成長３）
            {0xEA69, new FieldItemDefinition(60009, 2805 , 65534, "PltTreeCedar4"         , FieldItemKind.PltTreeCedar        )}, // 針葉樹（成木）
            {0xEA6F, new FieldItemDefinition(60015, 2627 , 2627 , "PltFlwCosmos1Red"      , FieldItemKind.PltFlwCosmos        )}, // コスモス赤（茎）
            {0xEA70, new FieldItemDefinition(60016, 2628 , 2628 , "PltFlwCosmos2Red"      , FieldItemKind.PltFlwCosmos        )}, // コスモス赤（つぼみ）
            {0xEA71, new FieldItemDefinition(60017, 3824 , 2304 , "PltFlwCosmos3Red"      , FieldItemKind.PltFlwCosmos        )}, // コスモス赤（花）
            {0xEA72, new FieldItemDefinition(60018, 2630 , 2630 , "PltFlwCosmos1White"    , FieldItemKind.PltFlwCosmos        )}, // コスモス白（茎）
            {0xEA73, new FieldItemDefinition(60019, 2631 , 2631 , "PltFlwCosmos2White"    , FieldItemKind.PltFlwCosmos        )}, // コスモス白（つぼみ）
            {0xEA74, new FieldItemDefinition(60020, 3826 , 2305 , "PltFlwCosmos3White"    , FieldItemKind.PltFlwCosmos        )}, // コスモス白（花）
            {0xEA76, new FieldItemDefinition(60022, 2815 , 65534, "PltTreeBamboo4"        , FieldItemKind.PltTreeBamboo       )}, // 竹（成木）
            {0xEA77, new FieldItemDefinition(60023, 2810 , 65534, "PltTreePalm4"          , FieldItemKind.PltTreePalm         )}, // ヤシの木（成木）
            {0xEA79, new FieldItemDefinition(60025, 65534, 65534, "Hole"                  , FieldItemKind.UnitIconHole        )}, // 穴
            {0xEA7C, new FieldItemDefinition(60028, 12897, 65534, "PltVgtTomato0"         , FieldItemKind.PltVgtTomato        )}, // トマト（苗）
            {0xEA7D, new FieldItemDefinition(60029, 2651 , 65534, "PltVgtTomato1"         , FieldItemKind.PltVgtTomato        )}, // トマト（成長１）
            {0xEA7E, new FieldItemDefinition(60030, 2652 , 65534, "PltVgtTomato2"         , FieldItemKind.PltVgtTomato        )}, // トマト（成長２）
            {0xEA7F, new FieldItemDefinition(60031, 12898, 2570 , "PltVgtTomato3"         , FieldItemKind.PltVgtTomato        )}, // トマト（成木）
            {0xEA81, new FieldItemDefinition(60033, 2624 , 2624 , "PltWeedAut1A"          , FieldItemKind.PltWeedAut0         )}, // 秋の雑草01A
            {0xEA82, new FieldItemDefinition(60034, 2624 , 2624 , "PltWeedAut1B"          , FieldItemKind.PltWeedAut0         )}, // 秋の雑草01B
            {0xEA83, new FieldItemDefinition(60035, 2624 , 2624 , "PltWeedAut1C"          , FieldItemKind.PltWeedAut0         )}, // 秋の雑草01C
            {0xEA86, new FieldItemDefinition(60038, 2624 , 2624 , "PltWeedSmr1A"          , FieldItemKind.PltWeedSmr          )}, // 夏の雑草1A
            {0xEA87, new FieldItemDefinition(60039, 2624 , 2624 , "PltWeedSmr1B"          , FieldItemKind.PltWeedSmr          )}, // 夏の雑草1B
            {0xEA88, new FieldItemDefinition(60040, 2624 , 2624 , "PltWeedSmr1C"          , FieldItemKind.PltWeedSmr          )}, // 夏の雑草1C
            {0xEA89, new FieldItemDefinition(60041, 2865 , 2865 , "PltFlwCosmos1Yellow"   , FieldItemKind.PltFlwCosmos        )}, // コスモス黄（茎）
            {0xEA8A, new FieldItemDefinition(60042, 2866 , 2866 , "PltFlwCosmos2Yellow"   , FieldItemKind.PltFlwCosmos        )}, // コスモス黄（つぼみ）
            {0xEA8B, new FieldItemDefinition(60043, 3828 , 2863 , "PltFlwCosmos3Yellow"   , FieldItemKind.PltFlwCosmos        )}, // コスモス黄（花）
            {0xEA9F, new FieldItemDefinition(60063, 65534, 65534, "PltTreeOak4Stump"      , FieldItemKind.PltTreeOak          )}, // 広葉樹（成木の切り株）
            {0xEAA1, new FieldItemDefinition(60065, 65534, 11711, "FenceWoodWhite"        , FieldItemKind.FenceWoodWhite      )}, // そぼくなもくせいのさく・白
            {0xEAB4, new FieldItemDefinition(60084, 65534, 65534, "PltTreeCedar4Stump"    , FieldItemKind.PltTreeCedar        )}, // 針葉樹（成木の切り株）
            {0xEAB5, new FieldItemDefinition(60085, 5151 , 65534, "PltTreeCedar0"         , FieldItemKind.PltTreeCedar        )}, // 針葉樹（苗）
            {0xEAB6, new FieldItemDefinition(60086, 2803 , 65534, "PltTreeCedar2"         , FieldItemKind.PltTreeCedar        )}, // 針葉樹（成長２）
            {0xEAB7, new FieldItemDefinition(60087, 2802 , 65534, "PltTreeCedar1"         , FieldItemKind.PltTreeCedar        )}, // 針葉樹（成長１）
            {0xEAB8, new FieldItemDefinition(60088, 2804 , 65534, "PltTreeCedar3"         , FieldItemKind.PltTreeCedar        )}, // 針葉樹（成長３）
            {0xEABE, new FieldItemDefinition(60094, 65534, 65534, "PltTreePalm4Stump"     , FieldItemKind.PltTreePalm         )}, // ヤシの木（成木の切り株）
            {0xEABF, new FieldItemDefinition(60095, 2806 , 65534, "PltTreePalm0"          , FieldItemKind.PltTreePalm         )}, // ヤシの木（苗）
            {0xEAC0, new FieldItemDefinition(60096, 2808 , 65534, "PltTreePalm2"          , FieldItemKind.PltTreePalm         )}, // ヤシの木（成長２）
            {0xEAC1, new FieldItemDefinition(60097, 2807 , 65534, "PltTreePalm1"          , FieldItemKind.PltTreePalm         )}, // ヤシの木（成長１）
            {0xEAC2, new FieldItemDefinition(60098, 2809 , 65534, "PltTreePalm3"          , FieldItemKind.PltTreePalm         )}, // ヤシの木（成長３）
            {0xEAC3, new FieldItemDefinition(60099, 65534, 65534, "PltTreeBamboo4Stump"   , FieldItemKind.PltTreeBamboo       )}, // 竹（成木の切り株）
            {0xEAC4, new FieldItemDefinition(60100, 2811 , 65534, "PltTreeBamboo0"        , FieldItemKind.PltTreeBamboo       )}, // 竹（苗）
            {0xEAC5, new FieldItemDefinition(60101, 2813 , 65534, "PltTreeBamboo2"        , FieldItemKind.PltTreeBamboo       )}, // 竹（成長２）
            {0xEAC6, new FieldItemDefinition(60102, 2812 , 65534, "PltTreeBamboo1"        , FieldItemKind.PltTreeBamboo       )}, // 竹（成長１）
            {0xEAC7, new FieldItemDefinition(60103, 2814 , 65534, "PltTreeBamboo3"        , FieldItemKind.PltTreeBamboo       )}, // 竹（成長３）
            {0xEAC8, new FieldItemDefinition(60104, 3370 , 65534, "PltTreePear"           , FieldItemKind.PltTreeOak          )}, // ナシの木（成木）
            {0xEAC9, new FieldItemDefinition(60105, 3381 , 65534, "PltTreeCherry"         , FieldItemKind.PltTreeOak          )}, // さくらんぼの木（成木）
            {0xEACA, new FieldItemDefinition(60106, 3375 , 65534, "PltTreePeach"          , FieldItemKind.PltTreeOak          )}, // モモの木（成木）
            {0xEACB, new FieldItemDefinition(60107, 2861 , 65534, "PltBushAzalea3White"   , FieldItemKind.PltBushAzalea       )}, // ツツジ白（成木花）
            {0xEACC, new FieldItemDefinition(60108, 12747, 65534, "PltBushAzalea0White"   , FieldItemKind.PltBushAzalea       )}, // ツツジ白（苗）
            {0xEACD, new FieldItemDefinition(60109, 2861 , 65534, "PltBushAzalea2White"   , FieldItemKind.PltBushAzalea       )}, // ツツジ白（成木つぼみ）
            {0xEACF, new FieldItemDefinition(60111, 2861 , 65534, "PltBushAzalea4White"   , FieldItemKind.PltBushAzalea       )}, // ツツジ白（成木花なし）
            {0xEAD0, new FieldItemDefinition(60112, 2860 , 65534, "PltBushAzalea1White"   , FieldItemKind.PltBushAzalea       )}, // ツツジ白（成長１）
            {0xEAD1, new FieldItemDefinition(60113, 3022 , 65534, "PltBushHibiscus3Red"   , FieldItemKind.PltBushHibiscus     )}, // ハイビスカス赤（成木花）
            {0xEAD2, new FieldItemDefinition(60114, 12752, 65534, "PltBushHibiscus0Red"   , FieldItemKind.PltBushHibiscus     )}, // ハイビスカス赤（苗）
            {0xEAD3, new FieldItemDefinition(60115, 3022 , 65534, "PltBushHibiscus2Red"   , FieldItemKind.PltBushHibiscus     )}, // ハイビスカス赤（成木つぼみ）
            {0xEAD4, new FieldItemDefinition(60116, 3022 , 65534, "PltBushHibiscus4Red"   , FieldItemKind.PltBushHibiscus     )}, // ハイビスカス赤（成木花なし）
            {0xEAD5, new FieldItemDefinition(60117, 3021 , 65534, "PltBushHibiscus1Red"   , FieldItemKind.PltBushHibiscus     )}, // ハイビスカス赤（成長１）
            {0xEAD6, new FieldItemDefinition(60118, 3027 , 65534, "PltBushHolly3"         , FieldItemKind.PltBushHolly        )}, // ヒイラギ（成木花）
            {0xEAD7, new FieldItemDefinition(60119, 12757, 65534, "PltBushHolly0"         , FieldItemKind.PltBushHolly        )}, // ヒイラギ（苗）
            {0xEAD8, new FieldItemDefinition(60120, 3027 , 65534, "PltBushHolly2"         , FieldItemKind.PltBushHolly        )}, // ヒイラギ（成木つぼみ）
            {0xEAD9, new FieldItemDefinition(60121, 3026 , 65534, "PltBushHolly1"         , FieldItemKind.PltBushHolly        )}, // ヒイラギ（成長１）
            {0xEADA, new FieldItemDefinition(60122, 3027 , 65534, "PltBushHolly4"         , FieldItemKind.PltBushHolly        )}, // ヒイラギ（成木花なし）
            {0xEADC, new FieldItemDefinition(60124, 3033 , 65534, "PltVgtWheat2"          , FieldItemKind.PltVgtWheat         )}, // 小麦（成長２）
            {0xEADD, new FieldItemDefinition(60125, 12899, 3029 , "PltVgtWheat3"          , FieldItemKind.PltVgtWheat         )}, // 小麦（成木）
            {0xEADE, new FieldItemDefinition(60126, 3032 , 65534, "PltVgtWheat1"          , FieldItemKind.PltVgtWheat         )}, // 小麦（成長１）
            {0xEADF, new FieldItemDefinition(60127, 3031 , 65534, "PltVgtWheat0"          , FieldItemKind.PltVgtWheat         )}, // 小麦（苗）
            {0xEAE6, new FieldItemDefinition(60134, 12900, 3034 , "PltVgtSugarCane3"      , FieldItemKind.PltVgtSugarcane     )}, // サトウキビ（成木）
            {0xEAE7, new FieldItemDefinition(60135, 3037 , 65534, "PltVgtSugarCane1"      , FieldItemKind.PltVgtSugarcane     )}, // サトウキビ（成長１）
            {0xEAE8, new FieldItemDefinition(60136, 12901, 65534, "PltVgtSugarCane0"      , FieldItemKind.PltVgtSugarcane     )}, // サトウキビ（苗）
            {0xEAE9, new FieldItemDefinition(60137, 3038 , 65534, "PltVgtSugarCane2"      , FieldItemKind.PltVgtSugarcane     )}, // サトウキビ（成長２）
            {0xEAEA, new FieldItemDefinition(60138, 12902, 3039 , "PltVgtPotato3"         , FieldItemKind.PltVgtPotato        )}, // ジャガイモ（成木）
            {0xEAEB, new FieldItemDefinition(60139, 3042 , 65534, "PltVgtPotato1"         , FieldItemKind.PltVgtPotato        )}, // ジャガイモ（成長１）
            {0xEAEC, new FieldItemDefinition(60140, 12903, 65534, "PltVgtPotato0"         , FieldItemKind.PltVgtPotato        )}, // ジャガイモ（苗）
            {0xEAED, new FieldItemDefinition(60141, 3043 , 65534, "PltVgtPotato2"         , FieldItemKind.PltVgtPotato        )}, // ジャガイモ（成長２）
            {0xEAEE, new FieldItemDefinition(60142, 12905, 3044 , "PltVgtCarrot3"         , FieldItemKind.PltVgtCarrot        )}, // ニンジン（成木）
            {0xEAEF, new FieldItemDefinition(60143, 3047 , 65534, "PltVgtCarrot1"         , FieldItemKind.PltVgtCarrot        )}, // ニンジン（成長１）
            {0xEAF0, new FieldItemDefinition(60144, 3046 , 65534, "PltVgtCarrot0"         , FieldItemKind.PltVgtCarrot        )}, // ニンジン（苗）
            {0xEAF1, new FieldItemDefinition(60145, 3048 , 65534, "PltVgtCarrot2"         , FieldItemKind.PltVgtCarrot        )}, // ニンジン（成長２）
            {0xEAF7, new FieldItemDefinition(60151, 2878 , 2878 , "PltFlwCosmos2Black"    , FieldItemKind.PltFlwCosmos        )}, // コスモス黒（つぼみ）
            {0xEAF8, new FieldItemDefinition(60152, 3832 , 2871 , "PltFlwCosmos3Orange"   , FieldItemKind.PltFlwCosmos        )}, // コスモスオレンジ（花）
            {0xEAF9, new FieldItemDefinition(60153, 3834 , 2875 , "PltFlwCosmos3Black"    , FieldItemKind.PltFlwCosmos        )}, // コスモス黒（花）
            {0xEAFA, new FieldItemDefinition(60154, 3830 , 2867 , "PltFlwCosmos3Pink"     , FieldItemKind.PltFlwCosmos        )}, // コスモス桃（花）
            {0xEAFB, new FieldItemDefinition(60155, 2877 , 2877 , "PltFlwCosmos1Black"    , FieldItemKind.PltFlwCosmos        )}, // コスモス黒（茎）
            {0xEAFC, new FieldItemDefinition(60156, 2873 , 2873 , "PltFlwCosmos1Orange"   , FieldItemKind.PltFlwCosmos        )}, // コスモスオレンジ（茎）
            {0xEAFD, new FieldItemDefinition(60157, 2874 , 2874 , "PltFlwCosmos2Orange"   , FieldItemKind.PltFlwCosmos        )}, // コスモスオレンジ（つぼみ）
            {0xEAFE, new FieldItemDefinition(60158, 2869 , 2869 , "PltFlwCosmos1Pink"     , FieldItemKind.PltFlwCosmos        )}, // コスモス桃（茎）
            {0xEAFF, new FieldItemDefinition(60159, 2870 , 2870 , "PltFlwCosmos2Pink"     , FieldItemKind.PltFlwCosmos        )}, // コスモス桃（つぼみ）
            {0xEB00, new FieldItemDefinition(60160, 65534, 3080 , "FenceWallRenga"        , FieldItemKind.FenceWallRenga      )}, // レンガの壁
            {0xEB01, new FieldItemDefinition(60161, 2624 , 2624 , "PltWeedSmr3"           , FieldItemKind.PltWeedSmr          )}, // 夏の雑草3
            {0xEB02, new FieldItemDefinition(60162, 2624 , 2624 , "PltWeedSmr2A"          , FieldItemKind.PltWeedSmr          )}, // 夏の雑草2A
            {0xEB03, new FieldItemDefinition(60163, 2624 , 2624 , "PltWeedSmr2C"          , FieldItemKind.PltWeedSmr          )}, // 夏の雑草2C
            {0xEB04, new FieldItemDefinition(60164, 2624 , 2624 , "PltWeedSmr2B"          , FieldItemKind.PltWeedSmr          )}, // 夏の雑草2B
            {0xEB05, new FieldItemDefinition(60165, 2624 , 2624 , "PltWeedAut3"           , FieldItemKind.PltWeedAut0         )}, // 秋の雑草03
            {0xEB12, new FieldItemDefinition(60178, 65534, 65534, "StoneA"                , FieldItemKind.StoneA              )}, // 岩A
            {0xEB13, new FieldItemDefinition(60179, 65534, 65534, "StoneB"                , FieldItemKind.StoneB              )}, // 岩B
            {0xEB14, new FieldItemDefinition(60180, 65534, 65534, "StoneE"                , FieldItemKind.StoneE              )}, // 岩E
            {0xEB15, new FieldItemDefinition(60181, 65534, 65534, "StoneD"                , FieldItemKind.StoneD              )}, // 岩D
            {0xEB16, new FieldItemDefinition(60182, 65534, 65534, "StoneC"                , FieldItemKind.StoneC              )}, // 岩C
            {0xEB17, new FieldItemDefinition(60183, 2624 , 2624 , "PltWeedAut2B"          , FieldItemKind.PltWeedAut0         )}, // 秋の雑草02B
            {0xEB18, new FieldItemDefinition(60184, 2624 , 2624 , "PltWeedAut2C"          , FieldItemKind.PltWeedAut0         )}, // 秋の雑草02C
            {0xEB19, new FieldItemDefinition(60185, 2624 , 2624 , "PltWeedAut2A"          , FieldItemKind.PltWeedAut0         )}, // 秋の雑草02A
            {0xEB28, new FieldItemDefinition(60200, 2624 , 2624 , "PltWeedSpr1A"          , FieldItemKind.PltWeedSpr          )}, // 春の雑草1A
            {0xEB30, new FieldItemDefinition(60208, 2624 , 2624 , "PltWeedSpr1B"          , FieldItemKind.PltWeedSpr          )}, // 春の雑草1B
            {0xEB31, new FieldItemDefinition(60209, 2624 , 2624 , "PltWeedSpr1C"          , FieldItemKind.PltWeedSpr          )}, // 春の雑草1C
            {0xEB32, new FieldItemDefinition(60210, 2624 , 2624 , "PltWeedSpr2A"          , FieldItemKind.PltWeedSpr          )}, // 春の雑草2A
            {0xEB33, new FieldItemDefinition(60211, 2624 , 2624 , "PltWeedSpr2B"          , FieldItemKind.PltWeedSpr          )}, // 春の雑草2B
            {0xEB34, new FieldItemDefinition(60212, 2624 , 2624 , "PltWeedSpr2C"          , FieldItemKind.PltWeedSpr          )}, // 春の雑草2C
            {0xEB35, new FieldItemDefinition(60213, 2624 , 2624 , "PltWeedSpr3"           , FieldItemKind.PltWeedSpr          )}, // 春の雑草3
            {0xEB36, new FieldItemDefinition(60214, 2624 , 2624 , "PltWeedWin1A"          , FieldItemKind.PltWeedWin0         )}, // 冬の雑草01A
            {0xEB37, new FieldItemDefinition(60215, 2624 , 2624 , "PltWeedWin1B"          , FieldItemKind.PltWeedWin0         )}, // 冬の雑草01B
            {0xEB38, new FieldItemDefinition(60216, 2624 , 2624 , "PltWeedWin1C"          , FieldItemKind.PltWeedWin0         )}, // 冬の雑草01C
            {0xEB39, new FieldItemDefinition(60217, 2624 , 2624 , "PltWeedWin2A"          , FieldItemKind.PltWeedWin0         )}, // 冬の雑草02A
            {0xEB3A, new FieldItemDefinition(60218, 2624 , 2624 , "PltWeedWin2B"          , FieldItemKind.PltWeedWin0         )}, // 冬の雑草02B
            {0xEB3B, new FieldItemDefinition(60219, 2624 , 2624 , "PltWeedWin2C"          , FieldItemKind.PltWeedWin0         )}, // 冬の雑草02C
            {0xEB3C, new FieldItemDefinition(60220, 2624 , 2624 , "PltWeedWin3"           , FieldItemKind.PltWeedWin0         )}, // 冬の雑草03
            {0xEB3D, new FieldItemDefinition(60221, 2881 , 2881 , "PltFlwTulip1White"     , FieldItemKind.PltFlwTulip         )}, // チューリップ白（茎）
            {0xEB3E, new FieldItemDefinition(60222, 2882 , 2882 , "PltFlwTulip2White"     , FieldItemKind.PltFlwTulip         )}, // チューリップ白（つぼみ）
            {0xEB3F, new FieldItemDefinition(60223, 3836 , 2879 , "PltFlwTulip3White"     , FieldItemKind.PltFlwTulip         )}, // チューリップ白（花）
            {0xEB40, new FieldItemDefinition(60224, 2885 , 2885 , "PltFlwTulip1Red"       , FieldItemKind.PltFlwTulip         )}, // チューリップ赤（茎）
            {0xEB41, new FieldItemDefinition(60225, 2886 , 2886 , "PltFlwTulip2Red"       , FieldItemKind.PltFlwTulip         )}, // チューリップ赤（つぼみ）
            {0xEB42, new FieldItemDefinition(60226, 3838 , 2883 , "PltFlwTulip3Red"       , FieldItemKind.PltFlwTulip         )}, // チューリップ赤（花）
            {0xEB43, new FieldItemDefinition(60227, 2889 , 2889 , "PltFlwTulip1Yellow"    , FieldItemKind.PltFlwTulip         )}, // チューリップ黄（茎）
            {0xEB44, new FieldItemDefinition(60228, 2890 , 2890 , "PltFlwTulip2Yellow"    , FieldItemKind.PltFlwTulip         )}, // チューリップ黄（つぼみ）
            {0xEB45, new FieldItemDefinition(60229, 3840 , 2887 , "PltFlwTulip3Yellow"    , FieldItemKind.PltFlwTulip         )}, // チューリップ黄（花）
            {0xEB46, new FieldItemDefinition(60230, 2893 , 2893 , "PltFlwTulip1Pink"      , FieldItemKind.PltFlwTulip         )}, // チューリップ桃（茎）
            {0xEB47, new FieldItemDefinition(60231, 2894 , 2894 , "PltFlwTulip2Pink"      , FieldItemKind.PltFlwTulip         )}, // チューリップ桃（つぼみ）
            {0xEB48, new FieldItemDefinition(60232, 3842 , 2891 , "PltFlwTulip3Pink"      , FieldItemKind.PltFlwTulip         )}, // チューリップ桃（花）
            {0xEB49, new FieldItemDefinition(60233, 2897 , 2897 , "PltFlwTulip1Orange"    , FieldItemKind.PltFlwTulip         )}, // チューリップオレンジ（茎）
            {0xEB4A, new FieldItemDefinition(60234, 2898 , 2898 , "PltFlwTulip2Orange"    , FieldItemKind.PltFlwTulip         )}, // チューリップオレンジ（つぼみ）
            {0xEB4B, new FieldItemDefinition(60235, 3844 , 2895 , "PltFlwTulip3Orange"    , FieldItemKind.PltFlwTulip         )}, // チューリップオレンジ（花）
            {0xEB4C, new FieldItemDefinition(60236, 2901 , 2901 , "PltFlwTulip1Purple"    , FieldItemKind.PltFlwTulip         )}, // チューリップ紫（茎）
            {0xEB4D, new FieldItemDefinition(60237, 2902 , 2902 , "PltFlwTulip2Purple"    , FieldItemKind.PltFlwTulip         )}, // チューリップ紫（つぼみ）
            {0xEB4E, new FieldItemDefinition(60238, 3846 , 2899 , "PltFlwTulip3Purple"    , FieldItemKind.PltFlwTulip         )}, // チューリップ紫（花）
            {0xEB4F, new FieldItemDefinition(60239, 2905 , 2905 , "PltFlwTulip1Black"     , FieldItemKind.PltFlwTulip         )}, // チューリップ黒（茎）
            {0xEB50, new FieldItemDefinition(60240, 2906 , 2906 , "PltFlwTulip2Black"     , FieldItemKind.PltFlwTulip         )}, // チューリップ黒（つぼみ）
            {0xEB51, new FieldItemDefinition(60241, 3848 , 2903 , "PltFlwTulip3Black"     , FieldItemKind.PltFlwTulip         )}, // チューリップ黒（花）
            {0xEB52, new FieldItemDefinition(60242, 2909 , 2909 , "PltFlwPansy1White"     , FieldItemKind.PltFlwPansy         )}, // パンジー白（茎）
            {0xEB53, new FieldItemDefinition(60243, 2910 , 2910 , "PltFlwPansy2White"     , FieldItemKind.PltFlwPansy         )}, // パンジー白（つぼみ）
            {0xEB54, new FieldItemDefinition(60244, 3850 , 2907 , "PltFlwPansy3White"     , FieldItemKind.PltFlwPansy         )}, // パンジー白（花）
            {0xEB55, new FieldItemDefinition(60245, 2913 , 2913 , "PltFlwPansy1Red"       , FieldItemKind.PltFlwPansy         )}, // パンジー赤（茎）
            {0xEB56, new FieldItemDefinition(60246, 2914 , 2914 , "PltFlwPansy2Red"       , FieldItemKind.PltFlwPansy         )}, // パンジー赤（つぼみ）
            {0xEB57, new FieldItemDefinition(60247, 3852 , 2911 , "PltFlwPansy3Red"       , FieldItemKind.PltFlwPansy         )}, // パンジー赤（花）
            {0xEB58, new FieldItemDefinition(60248, 2917 , 2917 , "PltFlwPansy1Yellow"    , FieldItemKind.PltFlwPansy         )}, // パンジー黄（茎）
            {0xEB59, new FieldItemDefinition(60249, 2918 , 2918 , "PltFlwPansy2Yellow"    , FieldItemKind.PltFlwPansy         )}, // パンジー黄（つぼみ）
            {0xEB5A, new FieldItemDefinition(60250, 3854 , 2915 , "PltFlwPansy3Yellow"    , FieldItemKind.PltFlwPansy         )}, // パンジー黄（花）
            {0xEB5B, new FieldItemDefinition(60251, 2921 , 2921 , "PltFlwPansy1RedYellow" , FieldItemKind.PltFlwPansy         )}, // パンジー赤黄（茎）
            {0xEB5C, new FieldItemDefinition(60252, 2922 , 2922 , "PltFlwPansy2RedYellow" , FieldItemKind.PltFlwPansy         )}, // パンジー赤黄（つぼみ）
            {0xEB5D, new FieldItemDefinition(60253, 3856 , 2919 , "PltFlwPansy3RedYellow" , FieldItemKind.PltFlwPansy         )}, // パンジー赤黄（花）
            {0xEB5E, new FieldItemDefinition(60254, 2925 , 2925 , "PltFlwPansy1Purple"    , FieldItemKind.PltFlwPansy         )}, // パンジー紫（茎）
            {0xEB5F, new FieldItemDefinition(60255, 2926 , 2926 , "PltFlwPansy2Purple"    , FieldItemKind.PltFlwPansy         )}, // パンジー紫（つぼみ）
            {0xEB60, new FieldItemDefinition(60256, 3858 , 2923 , "PltFlwPansy3Purple"    , FieldItemKind.PltFlwPansy         )}, // パンジー紫（花）
            {0xEB61, new FieldItemDefinition(60257, 2929 , 2929 , "PltFlwPansy1Blue"      , FieldItemKind.PltFlwPansy         )}, // パンジー青（茎）
            {0xEB62, new FieldItemDefinition(60258, 2930 , 2930 , "PltFlwPansy2Blue"      , FieldItemKind.PltFlwPansy         )}, // パンジー青（つぼみ）
            {0xEB63, new FieldItemDefinition(60259, 3860 , 2927 , "PltFlwPansy3Blue"      , FieldItemKind.PltFlwPansy         )}, // パンジー青（花）
            {0xEB64, new FieldItemDefinition(60260, 2933 , 2933 , "PltFlwRose1White"      , FieldItemKind.PltFlwRose          )}, // バラ白（茎）
            {0xEB65, new FieldItemDefinition(60261, 2934 , 2934 , "PltFlwRose2White"      , FieldItemKind.PltFlwRose          )}, // バラ白（つぼみ）
            {0xEB66, new FieldItemDefinition(60262, 3862 , 2931 , "PltFlwRose3White"      , FieldItemKind.PltFlwRose          )}, // バラ白（花）
            {0xEB67, new FieldItemDefinition(60263, 2937 , 2937 , "PltFlwRose1Red"        , FieldItemKind.PltFlwRose          )}, // バラ赤（茎）
            {0xEB68, new FieldItemDefinition(60264, 2938 , 2938 , "PltFlwRose2Red"        , FieldItemKind.PltFlwRose          )}, // バラ赤（つぼみ）
            {0xEB69, new FieldItemDefinition(60265, 3864 , 2935 , "PltFlwRose3Red"        , FieldItemKind.PltFlwRose          )}, // バラ赤（花）
            {0xEB6A, new FieldItemDefinition(60266, 2941 , 2941 , "PltFlwRose1Yellow"     , FieldItemKind.PltFlwRose          )}, // バラ黄（茎）
            {0xEB6B, new FieldItemDefinition(60267, 2942 , 2942 , "PltFlwRose2Yellow"     , FieldItemKind.PltFlwRose          )}, // バラ黄（つぼみ）
            {0xEB6C, new FieldItemDefinition(60268, 3866 , 2939 , "PltFlwRose3Yellow"     , FieldItemKind.PltFlwRose          )}, // バラ黄（花）
            {0xEB6D, new FieldItemDefinition(60269, 2945 , 2945 , "PltFlwRose1Pink"       , FieldItemKind.PltFlwRose          )}, // バラ桃（茎）
            {0xEB6E, new FieldItemDefinition(60270, 2946 , 2946 , "PltFlwRose2Pink"       , FieldItemKind.PltFlwRose          )}, // バラ桃（つぼみ）
            {0xEB6F, new FieldItemDefinition(60271, 3868 , 2943 , "PltFlwRose3Pink"       , FieldItemKind.PltFlwRose          )}, // バラ桃（花）
            {0xEB70, new FieldItemDefinition(60272, 2949 , 2949 , "PltFlwRose1Orange"     , FieldItemKind.PltFlwRose          )}, // バラオレンジ（茎）
            {0xEB71, new FieldItemDefinition(60273, 2950 , 2950 , "PltFlwRose2Orange"     , FieldItemKind.PltFlwRose          )}, // バラオレンジ（つぼみ）
            {0xEB72, new FieldItemDefinition(60274, 3870 , 2947 , "PltFlwRose3Orange"     , FieldItemKind.PltFlwRose          )}, // バラオレンジ（花）
            {0xEB73, new FieldItemDefinition(60275, 2953 , 2953 , "PltFlwRose1Purple"     , FieldItemKind.PltFlwRose          )}, // バラ紫（茎）
            {0xEB74, new FieldItemDefinition(60276, 2954 , 2954 , "PltFlwRose2Purple"     , FieldItemKind.PltFlwRose          )}, // バラ紫（つぼみ）
            {0xEB75, new FieldItemDefinition(60277, 3872 , 2951 , "PltFlwRose3Purple"     , FieldItemKind.PltFlwRose          )}, // バラ紫（花）
            {0xEB76, new FieldItemDefinition(60278, 2957 , 2957 , "PltFlwRose1Black"      , FieldItemKind.PltFlwRose          )}, // バラ黒（茎）
            {0xEB77, new FieldItemDefinition(60279, 2958 , 2958 , "PltFlwRose2Black"      , FieldItemKind.PltFlwRose          )}, // バラ黒（つぼみ）
            {0xEB78, new FieldItemDefinition(60280, 3874 , 2955 , "PltFlwRose3Black"      , FieldItemKind.PltFlwRose          )}, // バラ黒（花）
            {0xEB79, new FieldItemDefinition(60281, 2961 , 2961 , "PltFlwRose1Blue"       , FieldItemKind.PltFlwRose          )}, // バラ青（茎）
            {0xEB7A, new FieldItemDefinition(60282, 2962 , 2962 , "PltFlwRose2Blue"       , FieldItemKind.PltFlwRose          )}, // バラ青（つぼみ）
            {0xEB7B, new FieldItemDefinition(60283, 3876 , 2959 , "PltFlwRose3Blue"       , FieldItemKind.PltFlwRose          )}, // バラ青（花）
            {0xEB7C, new FieldItemDefinition(60284, 2965 , 2965 , "PltFlwRose1Gold"       , FieldItemKind.PltFlwRoseGold      )}, // バラ金（茎）
            {0xEB7D, new FieldItemDefinition(60285, 2966 , 2966 , "PltFlwRose2Gold"       , FieldItemKind.PltFlwRoseGold      )}, // バラ金（つぼみ）
            {0xEB7E, new FieldItemDefinition(60286, 3878 , 2963 , "PltFlwRose3Gold"       , FieldItemKind.PltFlwRoseGold      )}, // バラ金（花）
            {0xEB88, new FieldItemDefinition(60296, 2981 , 2981 , "PltFlwYuri1White"      , FieldItemKind.PltFlwYuri          )}, // ユリ白（茎）
            {0xEB89, new FieldItemDefinition(60297, 2982 , 2982 , "PltFlwYuri2White"      , FieldItemKind.PltFlwYuri          )}, // ユリ白（つぼみ）
            {0xEB8A, new FieldItemDefinition(60298, 3886 , 2979 , "PltFlwYuri3White"      , FieldItemKind.PltFlwYuri          )}, // ユリ白（花）
            {0xEB8B, new FieldItemDefinition(60299, 2985 , 2985 , "PltFlwYuri1Red"        , FieldItemKind.PltFlwYuri          )}, // ユリ赤（茎）
            {0xEB8C, new FieldItemDefinition(60300, 2986 , 2986 , "PltFlwYuri2Red"        , FieldItemKind.PltFlwYuri          )}, // ユリ赤（つぼみ）
            {0xEB8D, new FieldItemDefinition(60301, 3888 , 2983 , "PltFlwYuri3Red"        , FieldItemKind.PltFlwYuri          )}, // ユリ赤（花）
            {0xEB8E, new FieldItemDefinition(60302, 2989 , 2989 , "PltFlwYuri1Yellow"     , FieldItemKind.PltFlwYuri          )}, // ユリ黄（茎）
            {0xEB8F, new FieldItemDefinition(60303, 2990 , 2990 , "PltFlwYuri2Yellow"     , FieldItemKind.PltFlwYuri          )}, // ユリ黄（つぼみ）
            {0xEB90, new FieldItemDefinition(60304, 3890 , 2987 , "PltFlwYuri3Yellow"     , FieldItemKind.PltFlwYuri          )}, // ユリ黄（花）
            {0xEB91, new FieldItemDefinition(60305, 2993 , 2993 , "PltFlwYuri1Pink"       , FieldItemKind.PltFlwYuri          )}, // ユリ桃（茎）
            {0xEB92, new FieldItemDefinition(60306, 2994 , 2994 , "PltFlwYuri2Pink"       , FieldItemKind.PltFlwYuri          )}, // ユリ桃（つぼみ）
            {0xEB93, new FieldItemDefinition(60307, 3892 , 2991 , "PltFlwYuri3Pink"       , FieldItemKind.PltFlwYuri          )}, // ユリ桃（花）
            {0xEB94, new FieldItemDefinition(60308, 2997 , 2997 , "PltFlwYuri1Orange"     , FieldItemKind.PltFlwYuri          )}, // ユリオレンジ（茎）
            {0xEB95, new FieldItemDefinition(60309, 2998 , 2998 , "PltFlwYuri2Orange"     , FieldItemKind.PltFlwYuri          )}, // ユリオレンジ（つぼみ）
            {0xEB96, new FieldItemDefinition(60310, 3894 , 2995 , "PltFlwYuri3Orange"     , FieldItemKind.PltFlwYuri          )}, // ユリオレンジ（花）
            {0xEB97, new FieldItemDefinition(60311, 3001 , 3001 , "PltFlwYuri1Black"      , FieldItemKind.PltFlwYuri          )}, // ユリ黒（茎）
            {0xEB98, new FieldItemDefinition(60312, 3002 , 3002 , "PltFlwYuri2Black"      , FieldItemKind.PltFlwYuri          )}, // ユリ黒（つぼみ）
            {0xEB99, new FieldItemDefinition(60313, 3896 , 2999 , "PltFlwYuri3Black"      , FieldItemKind.PltFlwYuri          )}, // ユリ黒（花）
            {0xEBBA, new FieldItemDefinition(60346, 65534, 3402 , "FenceVerticalWood"     , FieldItemKind.FenceVerticalWood   )}, // たていたのさく
            {0xEBBF, new FieldItemDefinition(60351, 65534, 3403 , "FenceBamboo"           , FieldItemKind.FenceBamboo         )}, // たけがき
            {0xEBC0, new FieldItemDefinition(60352, 3380 , 65534, "PltTreeCherry3"        , FieldItemKind.PltTreeOak          )}, // さくらんぼの木（成長３）
            {0xEBC1, new FieldItemDefinition(60353, 3379 , 65534, "PltTreeCherry2"        , FieldItemKind.PltTreeOak          )}, // さくらんぼの木（成長２）
            {0xEBC2, new FieldItemDefinition(60354, 3377 , 65534, "PltTreeCherry0"        , FieldItemKind.PltTreeOak          )}, // さくらんぼの木（苗）
            {0xEBC3, new FieldItemDefinition(60355, 3378 , 65534, "PltTreeCherry1"        , FieldItemKind.PltTreeOak          )}, // さくらんぼの木（成長１）
            {0xEBC4, new FieldItemDefinition(60356, 3371 , 65534, "PltTreePeach0"         , FieldItemKind.PltTreeOak          )}, // モモの木（苗）
            {0xEBC5, new FieldItemDefinition(60357, 3372 , 65534, "PltTreePeach1"         , FieldItemKind.PltTreeOak          )}, // モモの木（成長１）
            {0xEBC6, new FieldItemDefinition(60358, 3373 , 65534, "PltTreePeach2"         , FieldItemKind.PltTreeOak          )}, // モモの木（成長２）
            {0xEBC7, new FieldItemDefinition(60359, 3374 , 65534, "PltTreePeach3"         , FieldItemKind.PltTreeOak          )}, // モモの木（成長３）
            {0xEBC8, new FieldItemDefinition(60360, 3361 , 65534, "PltTreeOrange0"        , FieldItemKind.PltTreeOak          )}, // オレンジの木（苗）
            {0xEBC9, new FieldItemDefinition(60361, 3362 , 65534, "PltTreeOrange1"        , FieldItemKind.PltTreeOak          )}, // オレンジの木（成長１）
            {0xEBCA, new FieldItemDefinition(60362, 3363 , 65534, "PltTreeOrange2"        , FieldItemKind.PltTreeOak          )}, // オレンジの木（成長２）
            {0xEBCB, new FieldItemDefinition(60363, 3364 , 65534, "PltTreeOrange3"        , FieldItemKind.PltTreeOak          )}, // オレンジの木（成長３）
            {0xEBCC, new FieldItemDefinition(60364, 3366 , 65534, "PltTreePear0"          , FieldItemKind.PltTreeOak          )}, // ナシの木（苗）
            {0xEBCD, new FieldItemDefinition(60365, 3367 , 65534, "PltTreePear1"          , FieldItemKind.PltTreeOak          )}, // ナシの木（成長１）
            {0xEBCE, new FieldItemDefinition(60366, 3368 , 65534, "PltTreePear2"          , FieldItemKind.PltTreeOak          )}, // ナシの木（成長２）
            {0xEBCF, new FieldItemDefinition(60367, 3369 , 65534, "PltTreePear3"          , FieldItemKind.PltTreeOak          )}, // ナシの木（成長３）
            {0xEBD0, new FieldItemDefinition(60368, 3357 , 65534, "PltTreeApple1"         , FieldItemKind.PltTreeOak          )}, // リンゴの木（成長１）
            {0xEBD1, new FieldItemDefinition(60369, 3358 , 65534, "PltTreeApple2"         , FieldItemKind.PltTreeOak          )}, // リンゴの木（成長２）
            {0xEBD2, new FieldItemDefinition(60370, 3359 , 65534, "PltTreeApple3"         , FieldItemKind.PltTreeOak          )}, // リンゴの木（成長３）
            {0xEBD3, new FieldItemDefinition(60371, 3356 , 65534, "PltTreeApple0"         , FieldItemKind.PltTreeOak          )}, // リンゴの木（苗）
            {0xEBD4, new FieldItemDefinition(60372, 65534, 11712, "FenceLattice"          , FieldItemKind.FenceLattice        )}, // ラティス・青
            {0xEBD5, new FieldItemDefinition(60373, 65534, 4349 , "FenceHorizontalWood"   , FieldItemKind.FenceHorizontalWood )}, // よこいたのさく
            {0xEBD6, new FieldItemDefinition(60374, 65534, 4350 , "FenceLog"              , FieldItemKind.FenceLog            )}, // まるたのさく
            {0xEBD7, new FieldItemDefinition(60375, 65534, 4351 , "FenceHorizontalLog"    , FieldItemKind.FenceHorizontalLog  )}, // よこむきのまるたのさく
            {0xEBD8, new FieldItemDefinition(60376, 65534, 4352 , "FencePegRope"          , FieldItemKind.FencePegRope        )}, // ペグとロープ
            {0xEBDA, new FieldItemDefinition(60378, 3918 , 3744 , "PltFlwHyacinth3Red"    , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス赤（花）
            {0xEBDB, new FieldItemDefinition(60379, 3906 , 3723 , "PltFlwAnemones3Red"    , FieldItemKind.PltFlwAnemone       )}, // アネモネ赤（花）
            {0xEBDC, new FieldItemDefinition(60380, 3932 , 3768 , "PltFlwMum3Red"         , FieldItemKind.PltFlwMum           )}, // キク赤（花）
            {0xEBDD, new FieldItemDefinition(60381, 3770 , 3770 , "PltFlwMum1Red"         , FieldItemKind.PltFlwMum           )}, // キク赤（茎）
            {0xEBDE, new FieldItemDefinition(60382, 3771 , 3771 , "PltFlwMum2Red"         , FieldItemKind.PltFlwMum           )}, // キク赤（つぼみ）
            {0xEBDF, new FieldItemDefinition(60383, 3725 , 3725 , "PltFlwAnemones1Red"    , FieldItemKind.PltFlwAnemone       )}, // アネモネ赤（茎）
            {0xEBE0, new FieldItemDefinition(60384, 3726 , 3726 , "PltFlwAnemones2Red"    , FieldItemKind.PltFlwAnemone       )}, // アネモネ赤（つぼみ）
            {0xEBE1, new FieldItemDefinition(60385, 3746 , 3746 , "PltFlwHyacinth1Red"    , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス赤（茎）
            {0xEBE2, new FieldItemDefinition(60386, 3747 , 3747 , "PltFlwHyacinth2Red"    , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス赤（つぼみ）
            {0xEBE4, new FieldItemDefinition(60388, 3910 , 3730 , "PltFlwHyacinth3White"  , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス白（花）
            {0xEBE5, new FieldItemDefinition(60389, 3733 , 3733 , "PltFlwHyacinth2White"  , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス白（つぼみ）
            {0xEBE6, new FieldItemDefinition(60390, 3732 , 3732 , "PltFlwHyacinth1White"  , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス白（茎）
            {0xEBE7, new FieldItemDefinition(60391, 3737 , 3737 , "PltFlwHyacinth2Yellow" , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス黄（つぼみ）
            {0xEBE8, new FieldItemDefinition(60392, 3912 , 3734 , "PltFlwHyacinth3Yellow" , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス黄（花）
            {0xEBE9, new FieldItemDefinition(60393, 3736 , 3736 , "PltFlwHyacinth1Yellow" , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス黄（茎）
            {0xEBEA, new FieldItemDefinition(60394, 3920 , 3748 , "PltFlwHyacinth3Blue"   , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス青（花）
            {0xEBEB, new FieldItemDefinition(60395, 3914 , 3738 , "PltFlwHyacinth3Pink"   , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス桃（花）
            {0xEBEC, new FieldItemDefinition(60396, 3916 , 3741 , "PltFlwHyacinth3Orange" , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンスオレンジ（花）
            {0xEBED, new FieldItemDefinition(60397, 3922 , 3751 , "PltFlwHyacinth3Purple" , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス紫（花）
            {0xEBEE, new FieldItemDefinition(60398, 3753 , 3753 , "PltFlwHyacinth2Purple" , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス紫（つぼみ）
            {0xEBEF, new FieldItemDefinition(60399, 3752 , 3752 , "PltFlwHyacinth1Purple" , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス紫（茎）
            {0xEBF0, new FieldItemDefinition(60400, 3743 , 3743 , "PltFlwHyacinth2Orange" , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンスオレンジ（つぼみ）
            {0xEBF1, new FieldItemDefinition(60401, 3740 , 3740 , "PltFlwHyacinth2Pink"   , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス桃（つぼみ）
            {0xEBF2, new FieldItemDefinition(60402, 3739 , 3739 , "PltFlwHyacinth1Pink"   , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス桃（茎）
            {0xEBF3, new FieldItemDefinition(60403, 3749 , 3749 , "PltFlwHyacinth1Blue"   , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス青（茎）
            {0xEBF4, new FieldItemDefinition(60404, 3750 , 3750 , "PltFlwHyacinth2Blue"   , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス青（つぼみ）
            {0xEBF5, new FieldItemDefinition(60405, 3742 , 3742 , "PltFlwHyacinth1Orange" , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンスオレンジ（茎）
            {0xEBF9, new FieldItemDefinition(60409, 12749, 65534, "PltBushHydrangea"      , FieldItemKind.PltBushHydrangea    )}, // あじさい青（苗）
            {0xEBFB, new FieldItemDefinition(60411, 12750, 65534, "PltBushHydrangea0Pink" , FieldItemKind.PltBushHydrangea    )}, // あじさい桃（苗）
            {0xEBFC, new FieldItemDefinition(60412, 3799 , 65534, "PltBushHydrangea1Blue" , FieldItemKind.PltBushHydrangea    )}, // あじさい青（成長１）
            {0xEBFD, new FieldItemDefinition(60413, 3800 , 65534, "PltBushHydrangea2Blue" , FieldItemKind.PltBushHydrangea    )}, // あじさい青（成木つぼみ）
            {0xEBFE, new FieldItemDefinition(60414, 3800 , 65534, "PltBushHydrangea3Blue" , FieldItemKind.PltBushHydrangea    )}, // あじさい青（成木花）
            {0xEBFF, new FieldItemDefinition(60415, 3800 , 65534, "PltBushHydrangea4Blue" , FieldItemKind.PltBushHydrangea    )}, // あじさい青（成木花なし）
            {0xEC00, new FieldItemDefinition(60416, 3795 , 65534, "PltBushHydrangea1Pink" , FieldItemKind.PltBushHydrangea    )}, // あじさい桃（成長１）
            {0xEC01, new FieldItemDefinition(60417, 3796 , 65534, "PltBushHydrangea2Pink" , FieldItemKind.PltBushHydrangea    )}, // あじさい桃（成木つぼみ）
            {0xEC02, new FieldItemDefinition(60418, 3796 , 65534, "PltBushHydrangea3Pink" , FieldItemKind.PltBushHydrangea    )}, // あじさい桃（成木花）
            {0xEC03, new FieldItemDefinition(60419, 3796 , 65534, "PltBushHydrangea4Pink" , FieldItemKind.PltBushHydrangea    )}, // あじさい桃（成木花なし）
            {0xEC04, new FieldItemDefinition(60420, 3756 , 3756 , "PltFlwMum1White"       , FieldItemKind.PltFlwMum           )}, // キク白（茎）
            {0xEC05, new FieldItemDefinition(60421, 3760 , 3760 , "PltFlwMum1Yellow"      , FieldItemKind.PltFlwMum           )}, // キク黄（茎）
            {0xEC06, new FieldItemDefinition(60422, 3763 , 3763 , "PltFlwMum1Purple"      , FieldItemKind.PltFlwMum           )}, // キク紫（茎）
            {0xEC07, new FieldItemDefinition(60423, 3766 , 3766 , "PltFlwMum1Pink"        , FieldItemKind.PltFlwMum           )}, // キク桃（茎）
            {0xEC08, new FieldItemDefinition(60424, 3757 , 3757 , "PltFlwMum2White"       , FieldItemKind.PltFlwMum           )}, // キク白（つぼみ）
            {0xEC09, new FieldItemDefinition(60425, 3924 , 3754 , "PltFlwMum3White"       , FieldItemKind.PltFlwMum           )}, // キク白（花）
            {0xEC0A, new FieldItemDefinition(60426, 3761 , 3761 , "PltFlwMum2Yellow"      , FieldItemKind.PltFlwMum           )}, // キク黄（つぼみ）
            {0xEC0B, new FieldItemDefinition(60427, 3764 , 3764 , "PltFlwMum2Purple"      , FieldItemKind.PltFlwMum           )}, // キク紫（つぼみ）
            {0xEC0C, new FieldItemDefinition(60428, 3767 , 3767 , "PltFlwMum2Pink"        , FieldItemKind.PltFlwMum           )}, // キク桃（つぼみ）
            {0xEC0D, new FieldItemDefinition(60429, 3926 , 3758 , "PltFlwMum3Yellow"      , FieldItemKind.PltFlwMum           )}, // キク黄（花）
            {0xEC0E, new FieldItemDefinition(60430, 3928 , 3762 , "PltFlwMum3Purple"      , FieldItemKind.PltFlwMum           )}, // キク紫（花）
            {0xEC0F, new FieldItemDefinition(60431, 3930 , 3765 , "PltFlwMum3Pink"        , FieldItemKind.PltFlwMum           )}, // キク桃（花）
            {0xEC11, new FieldItemDefinition(60433, 3711 , 3711 , "PltFlwAnemones1White"  , FieldItemKind.PltFlwAnemone       )}, // アネモネ白（茎）
            {0xEC12, new FieldItemDefinition(60434, 3712 , 3712 , "PltFlwAnemones2White"  , FieldItemKind.PltFlwAnemone       )}, // アネモネ白（つぼみ）
            {0xEC13, new FieldItemDefinition(60435, 3898 , 3709 , "PltFlwAnemones3White"  , FieldItemKind.PltFlwAnemone       )}, // アネモネ白（花）
            {0xEC14, new FieldItemDefinition(60436, 3718 , 3718 , "PltFlwAnemones1Blue"   , FieldItemKind.PltFlwAnemone       )}, // アネモネ青（茎）
            {0xEC15, new FieldItemDefinition(60437, 3728 , 3728 , "PltFlwAnemones1Purple" , FieldItemKind.PltFlwAnemone       )}, // アネモネ紫（茎）
            {0xEC16, new FieldItemDefinition(60438, 3721 , 3721 , "PltFlwAnemones1Pink"   , FieldItemKind.PltFlwAnemone       )}, // アネモネ桃（茎）
            {0xEC17, new FieldItemDefinition(60439, 3715 , 3715 , "PltFlwAnemones1Orange" , FieldItemKind.PltFlwAnemone       )}, // アネモネオレンジ（茎）
            {0xEC18, new FieldItemDefinition(60440, 3719 , 3719 , "PltFlwAnemones2Blue"   , FieldItemKind.PltFlwAnemone       )}, // アネモネ青（つぼみ）
            {0xEC19, new FieldItemDefinition(60441, 3902 , 3717 , "PltFlwAnemones3Blue"   , FieldItemKind.PltFlwAnemone       )}, // アネモネ青（花）
            {0xEC1A, new FieldItemDefinition(60442, 3729 , 3729 , "PltFlwAnemones2Purple" , FieldItemKind.PltFlwAnemone       )}, // アネモネ紫（つぼみ）
            {0xEC1B, new FieldItemDefinition(60443, 3908 , 3727 , "PltFlwAnemones3Purple" , FieldItemKind.PltFlwAnemone       )}, // アネモネ紫（花）
            {0xEC1C, new FieldItemDefinition(60444, 3722 , 3722 , "PltFlwAnemones2Pink"   , FieldItemKind.PltFlwAnemone       )}, // アネモネ桃（つぼみ）
            {0xEC1D, new FieldItemDefinition(60445, 3904 , 3720 , "PltFlwAnemones3Pink"   , FieldItemKind.PltFlwAnemone       )}, // アネモネ桃（花）
            {0xEC1E, new FieldItemDefinition(60446, 3716 , 3716 , "PltFlwAnemones2Orange" , FieldItemKind.PltFlwAnemone       )}, // アネモネオレンジ（つぼみ）
            {0xEC1F, new FieldItemDefinition(60447, 3900 , 3713 , "PltFlwAnemones3Orange" , FieldItemKind.PltFlwAnemone       )}, // アネモネオレンジ（花）
            {0xEC20, new FieldItemDefinition(60448, 3787 , 65534, "PltBushAzalea1Pink"    , FieldItemKind.PltBushAzalea       )}, // ツツジ桃（成長１）
            {0xEC21, new FieldItemDefinition(60449, 12748, 65534, "PltBushAzalea0Pink"    , FieldItemKind.PltBushAzalea       )}, // ツツジ桃（苗）
            {0xEC22, new FieldItemDefinition(60450, 3788 , 65534, "PltBushAzalea2Pink"    , FieldItemKind.PltBushAzalea       )}, // ツツジ桃（成長つぼみ）
            {0xEC23, new FieldItemDefinition(60451, 3788 , 65534, "PltBushAzalea3Pink"    , FieldItemKind.PltBushAzalea       )}, // ツツジ桃（成木花）
            {0xEC24, new FieldItemDefinition(60452, 3788 , 65534, "PltBushAzalea4Pink"    , FieldItemKind.PltBushAzalea       )}, // ツツジ桃（成木花なし）
            {0xEC25, new FieldItemDefinition(60453, 12751, 65534, "PltBushHibiscus0Yellow", FieldItemKind.PltBushHibiscus     )}, // ハイビスカス黄（苗）
            {0xEC26, new FieldItemDefinition(60454, 3791 , 65534, "PltBushHibiscus1Yellow", FieldItemKind.PltBushHibiscus     )}, // ハイビスカス黄（成長１）
            {0xEC27, new FieldItemDefinition(60455, 3792 , 65534, "PltBushHibiscus2Yellow", FieldItemKind.PltBushHibiscus     )}, // ハイビスカス黄（成木つぼみ）
            {0xEC28, new FieldItemDefinition(60456, 3792 , 65534, "PltBushHibiscus3Yellow", FieldItemKind.PltBushHibiscus     )}, // ハイビスカス黄（成木花）
            {0xEC29, new FieldItemDefinition(60457, 3792 , 65534, "PltBushHibiscus4Yellow", FieldItemKind.PltBushHibiscus     )}, // ハイビスカス黄（成木花なし）
            {0xEC32, new FieldItemDefinition(60466, 3778 , 3778 , "PltFlwMum1Green"       , FieldItemKind.PltFlwMum           )}, // キク緑（茎）
            {0xEC33, new FieldItemDefinition(60467, 3779 , 3779 , "PltFlwMum2Green"       , FieldItemKind.PltFlwMum           )}, // キク緑（つぼみ）
            {0xEC34, new FieldItemDefinition(60468, 3934 , 5175 , "PltFlwMum3Green"       , FieldItemKind.PltFlwMum           )}, // キク緑（花）
            {0xEC38, new FieldItemDefinition(60472, 3909 , 3909 , "PltFlwHyacinth0White"  , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス白（芽）
            {0xEC3A, new FieldItemDefinition(60474, 3925 , 3925 , "PltFlwMum0Yellow"      , FieldItemKind.PltFlwMum           )}, // キク黄（芽）
            {0xEC3B, new FieldItemDefinition(60475, 3911 , 3911 , "PltFlwHyacinth0Yellow" , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス黄（芽）
            {0xEC3F, new FieldItemDefinition(60479, 3917 , 3917 , "PltFlwHyacinth0Red"    , FieldItemKind.PltFlwHyacinth      )}, // ヒヤシンス赤（芽）
            {0xEC42, new FieldItemDefinition(60482, 3905 , 3905 , "PltFlwAnemones0Red"    , FieldItemKind.PltFlwAnemone       )}, // アネモネ赤（芽）
            {0xEC43, new FieldItemDefinition(60483, 3897 , 3897 , "PltFlwAnemones0White"  , FieldItemKind.PltFlwAnemone       )}, // アネモネ白（芽）
            {0xEC47, new FieldItemDefinition(60487, 3899 , 3899 , "PltFlwAnemones0Orange" , FieldItemKind.PltFlwAnemone       )}, // アネモネオレンジ（芽）
            {0xEC48, new FieldItemDefinition(60488, 3931 , 3931 , "PltFlwM0Red"           , FieldItemKind.PltFlwMum           )}, // キク赤（芽）
            {0xEC49, new FieldItemDefinition(60489, 3923 , 3923 , "PltFlwMum0White"       , FieldItemKind.PltFlwMum           )}, // キク白（芽）
            {0xEC4A, new FieldItemDefinition(60490, 3839 , 3839 , "PltFlwTulip0Yellow"    , FieldItemKind.PltFlwTulip         )}, // チューリップ黄（芽）
            {0xEC50, new FieldItemDefinition(60496, 3849 , 3849 , "PltFlwPansy0White"     , FieldItemKind.PltFlwPansy         )}, // パンジー白（芽）
            {0xEC51, new FieldItemDefinition(60497, 3851 , 3851 , "PltFlwPansy0Red"       , FieldItemKind.PltFlwPansy         )}, // パンジー赤（芽）
            {0xEC52, new FieldItemDefinition(60498, 3853 , 3853 , "PltFlwPansy0Yellow"    , FieldItemKind.PltFlwPansy         )}, // パンジー黄（芽）
            {0xEC56, new FieldItemDefinition(60502, 3861 , 3861 , "PltFlwRose0White"      , FieldItemKind.PltFlwRose          )}, // バラ白（芽）
            {0xEC57, new FieldItemDefinition(60503, 3863 , 3863 , "PltFlwRose0Red"        , FieldItemKind.PltFlwRose          )}, // バラ赤（芽）
            {0xEC58, new FieldItemDefinition(60504, 3865 , 3865 , "PltFlwRose0Yellow"     , FieldItemKind.PltFlwRose          )}, // バラ黄（芽）
            {0xEC5B, new FieldItemDefinition(60507, 3889 , 3889 , "PltFlwYuri0Yellow"     , FieldItemKind.PltFlwYuri          )}, // ユリ黄（芽）
            {0xEC60, new FieldItemDefinition(60512, 3885 , 3885 , "PltFlwYuri0White"      , FieldItemKind.PltFlwYuri          )}, // ユリ白（芽）
            {0xEC61, new FieldItemDefinition(60513, 3887 , 3887 , "PltFlwYuri0Red"        , FieldItemKind.PltFlwYuri          )}, // ユリ赤（芽）
            {0xEC62, new FieldItemDefinition(60514, 3823 , 3823 , "PltFlwCosmos0Red"      , FieldItemKind.PltFlwCosmos        )}, // コスモス赤（芽）
            {0xEC63, new FieldItemDefinition(60515, 3837 , 3837 , "PltFlwTulip0Red"       , FieldItemKind.PltFlwTulip         )}, // チューリップ赤（芽）
            {0xEC64, new FieldItemDefinition(60516, 3827 , 3827 , "PltFlwCosmos0Yellow"   , FieldItemKind.PltFlwCosmos        )}, // コスモス黄（芽）
            {0xEC65, new FieldItemDefinition(60517, 3825 , 3825 , "PltFlwCosmos0White"    , FieldItemKind.PltFlwCosmos        )}, // コスモス白（芽）
            {0xEC69, new FieldItemDefinition(60521, 3835 , 3835 , "PltFlwTulip0White"     , FieldItemKind.PltFlwTulip         )}, // チューリップ白（芽）
            {0xEC6B, new FieldItemDefinition(60523, 65534, 65534, "PltTreeOak3Stump"      , FieldItemKind.PltTreeOak          )}, // 広葉樹（成長３の切り株）
            {0xEC6C, new FieldItemDefinition(60524, 65534, 65534, "PltTreeOak2Stump"      , FieldItemKind.PltTreeOak          )}, // 広葉樹（成長２の切り株）
            {0xEC6D, new FieldItemDefinition(60525, 65534, 65534, "PltTreeOak1Stump"      , FieldItemKind.PltTreeOak          )}, // 広葉樹（成長１の切り株）
            {0xEC6E, new FieldItemDefinition(60526, 65534, 65534, "PltTreeCedar3Stump"    , FieldItemKind.PltTreeCedar        )}, // 針葉樹（成長３の切り株）
            {0xEC6F, new FieldItemDefinition(60527, 65534, 65534, "PltTreeCedar2Stump"    , FieldItemKind.PltTreeCedar        )}, // 針葉樹（成長２の切り株）
            {0xEC70, new FieldItemDefinition(60528, 65534, 65534, "PltTreeCedar1Stump"    , FieldItemKind.PltTreeCedar        )}, // 針葉樹（成長１の切り株）
            {0xEC71, new FieldItemDefinition(60529, 65534, 65534, "PltTreeBamboo3Stump"   , FieldItemKind.PltTreeBamboo       )}, // 竹（成長３の切り株）
            {0xEC72, new FieldItemDefinition(60530, 65534, 65534, "PltTreeBamboo2Stump"   , FieldItemKind.PltTreeBamboo       )}, // 竹（成長２の切り株）
            {0xEC73, new FieldItemDefinition(60531, 65534, 65534, "PltTreeBamboo1Stump"   , FieldItemKind.PltTreeBamboo       )}, // 竹（成長１の切り株）
            {0xEC74, new FieldItemDefinition(60532, 65534, 4354 , "FenceChinese"          , FieldItemKind.FenceChinese        )}, // オリエンタルなさく
            {0xEC78, new FieldItemDefinition(60536, 65534, 65534, "PltTreePalm1Stump"     , FieldItemKind.PltTreePalm         )}, // ヤシの木（成長１の切り株）
            {0xEC79, new FieldItemDefinition(60537, 65534, 65534, "PltTreePalm2Stump"     , FieldItemKind.PltTreePalm         )}, // ヤシの木（成長２の切り株）
            {0xEC7A, new FieldItemDefinition(60538, 65534, 65534, "PltTreePalm3Stump"     , FieldItemKind.PltTreePalm         )}, // ヤシの木（成長３の切り株）
            {0xEC7B, new FieldItemDefinition(60539, 65534, 4355 , "FenceConcreteBlock"    , FieldItemKind.FenceConcreteBlock  )}, // ブロック塀
            {0xEC7C, new FieldItemDefinition(60540, 65534, 4356 , "FenceDriedStraw"       , FieldItemKind.FenceDriedStraw     )}, // わらぼしのさく
            {0xEC7D, new FieldItemDefinition(60541, 65534, 4357 , "FenceSteel"            , FieldItemKind.FenceSteel          )}, // てつのさく
            {0xEC7E, new FieldItemDefinition(60542, 65534, 4358 , "FenceSharply"          , FieldItemKind.FenceSharply        )}, // トゲトゲのさく
            {0xEC7F, new FieldItemDefinition(60543, 2624 , 2624 , "PltWeedAut23"          , FieldItemKind.PltWeedAut2         )}, // 秋の雑草23
            {0xEC80, new FieldItemDefinition(60544, 2624 , 2624 , "PltWeedAut22C"         , FieldItemKind.PltWeedAut2         )}, // 秋の雑草22C
            {0xEC81, new FieldItemDefinition(60545, 2624 , 2624 , "PltWeedAut22A"         , FieldItemKind.PltWeedAut2         )}, // 秋の雑草22A
            {0xEC82, new FieldItemDefinition(60546, 2624 , 2624 , "PltWeedAut22B"         , FieldItemKind.PltWeedAut2         )}, // 秋の雑草22B
            {0xEC83, new FieldItemDefinition(60547, 2624 , 2624 , "PltWeedAut21A"         , FieldItemKind.PltWeedAut2         )}, // 秋の雑草21A
            {0xEC84, new FieldItemDefinition(60548, 2624 , 2624 , "PltWeedAut21B"         , FieldItemKind.PltWeedAut2         )}, // 秋の雑草21B
            {0xEC85, new FieldItemDefinition(60549, 2624 , 2624 , "PltWeedAut21C"         , FieldItemKind.PltWeedAut2         )}, // 秋の雑草21C
            {0xEC86, new FieldItemDefinition(60550, 2624 , 2624 , "PltWeedAut11B"         , FieldItemKind.PltWeedAut1         )}, // 秋の雑草11B
            {0xEC87, new FieldItemDefinition(60551, 2624 , 2624 , "PltWeedAut11C"         , FieldItemKind.PltWeedAut1         )}, // 秋の雑草11C
            {0xEC88, new FieldItemDefinition(60552, 2624 , 2624 , "PltWeedAut12A"         , FieldItemKind.PltWeedAut1         )}, // 秋の雑草12A
            {0xEC89, new FieldItemDefinition(60553, 2624 , 2624 , "PltWeedAut12B"         , FieldItemKind.PltWeedAut1         )}, // 秋の雑草12B
            {0xEC8A, new FieldItemDefinition(60554, 2624 , 2624 , "PltWeedAut12C"         , FieldItemKind.PltWeedAut1         )}, // 秋の雑草12C
            {0xEC8B, new FieldItemDefinition(60555, 2624 , 2624 , "PltWeedAut13"          , FieldItemKind.PltWeedAut1         )}, // 秋の雑草13
            {0xEC8C, new FieldItemDefinition(60556, 2624 , 2624 , "PltWeedAut11A"         , FieldItemKind.PltWeedAut1         )}, // 秋の雑草11A
            {0xEC8D, new FieldItemDefinition(60557, 2624 , 2624 , "PltWeedWin13"          , FieldItemKind.PltWeedWin1         )}, // 冬の雑草13
            {0xEC8E, new FieldItemDefinition(60558, 2624 , 2624 , "PltWeedWin12C"         , FieldItemKind.PltWeedWin1         )}, // 冬の雑草12C
            {0xEC8F, new FieldItemDefinition(60559, 2624 , 2624 , "PltWeedWin12A"         , FieldItemKind.PltWeedWin1         )}, // 冬の雑草12A
            {0xEC90, new FieldItemDefinition(60560, 2624 , 2624 , "PltWeedWin12B"         , FieldItemKind.PltWeedWin1         )}, // 冬の雑草12B
            {0xEC91, new FieldItemDefinition(60561, 2624 , 2624 , "PltWeedWin11A"         , FieldItemKind.PltWeedWin1         )}, // 冬の雑草11A
            {0xEC92, new FieldItemDefinition(60562, 2624 , 2624 , "PltWeedWin11B"         , FieldItemKind.PltWeedWin1         )}, // 冬の雑草11B
            {0xEC93, new FieldItemDefinition(60563, 2624 , 2624 , "PltWeedWin11C"         , FieldItemKind.PltWeedWin1         )}, // 冬の雑草11C
            {0xEC94, new FieldItemDefinition(60564, 65534, 11711, "FenceWoodBlue"         , FieldItemKind.FenceWoodWhite      )}, // そぼくなもくせいのさく・青
            {0xEC97, new FieldItemDefinition(60567, 2805 , 65534, "PltTreeCedarDecoB"     , FieldItemKind.PltTreeCedarDeco    )}, // 飾りつき針葉樹B
            {0xEC9A, new FieldItemDefinition(60570, 2805 , 65534, "PltTreeCedarDecoA"     , FieldItemKind.PltTreeCedarDeco    )}, // 飾りつき針葉樹A
            {0xEC9B, new FieldItemDefinition(60571, 65534, 5212 , "FenceStone"            , FieldItemKind.FenceStone          )}, // いしかべ
            {0xEC9C, new FieldItemDefinition(60572, 4426 , 65534, "PltTreeMoney4"         , FieldItemKind.PltTreeOak          )}, // 金のなるの木（成木）
            {0xEC9D, new FieldItemDefinition(60573, 4439 , 65534, "PltTreeMoney3"         , FieldItemKind.PltTreeOak          )}, // 金のなるの木（成長３）
            {0xEC9E, new FieldItemDefinition(60574, 4438 , 65534, "PltTreeMoney2"         , FieldItemKind.PltTreeOak          )}, // 金のなるの木（成長２）
            {0xEC9F, new FieldItemDefinition(60575, 4436 , 65534, "PltTreeMoney0"         , FieldItemKind.PltTreeOak          )}, // 金のなるの木（苗）
            {0xECA0, new FieldItemDefinition(60576, 4437 , 65534, "PltTreeMoney1"         , FieldItemKind.PltTreeOak          )}, // 金のなるの木（成長１）
            {0xECA1, new FieldItemDefinition(60577, 4544 , 4528 , "PltVgtSquash3White"    , FieldItemKind.PltVgtPumpkin       )}, // カボチャ白（成木）
            {0xECA2, new FieldItemDefinition(60578, 4543 , 65534, "PltVgtSquash2White"    , FieldItemKind.PltVgtPumpkin       )}, // カボチャ白（成長２）
            {0xECA3, new FieldItemDefinition(60579, 4542 , 65534, "PltVgtSquash1White"    , FieldItemKind.PltVgtPumpkin       )}, // カボチャ白（成長１）
            {0xECA4, new FieldItemDefinition(60580, 4541 , 65534, "PltVgtSquash0White"    , FieldItemKind.PltVgtPumpkin       )}, // カボチャ白（苗）
            {0xECA5, new FieldItemDefinition(60581, 4538 , 65534, "PltVgtSquash1Green"    , FieldItemKind.PltVgtPumpkin       )}, // カボチャ緑（成長１）
            {0xECA6, new FieldItemDefinition(60582, 4539 , 65534, "PltVgtSquash2Green"    , FieldItemKind.PltVgtPumpkin       )}, // カボチャ緑（成長２）
            {0xECA7, new FieldItemDefinition(60583, 4540 , 4527 , "PltVgtSquash3Green"    , FieldItemKind.PltVgtPumpkin       )}, // カボチャ緑（成木）
            {0xECA9, new FieldItemDefinition(60585, 4532 , 4525 , "PltVgtSquash3Orange"   , FieldItemKind.PltVgtPumpkin       )}, // カボチャオレンジ（成木）
            {0xECAA, new FieldItemDefinition(60586, 4533 , 65534, "PltVgtSquash0Yellow"   , FieldItemKind.PltVgtPumpkin       )}, // カボチャ黄（苗）
            {0xECAB, new FieldItemDefinition(60587, 4534 , 65534, "PltVgtSquash1Yellow"   , FieldItemKind.PltVgtPumpkin       )}, // カボチャ黄（成長１）
            {0xECAC, new FieldItemDefinition(60588, 4535 , 65534, "PltVgtSquash2Yellow"   , FieldItemKind.PltVgtPumpkin       )}, // カボチャ黄（成長２）
            {0xECAD, new FieldItemDefinition(60589, 4536 , 4526 , "PltVgtSquash3Yellow"   , FieldItemKind.PltVgtPumpkin       )}, // カボチャ黄（成木）
            {0xECAE, new FieldItemDefinition(60590, 4537 , 65534, "PltVgtSquash0Green"    , FieldItemKind.PltVgtPumpkin       )}, // カボチャ緑（苗）
            {0xECAF, new FieldItemDefinition(60591, 4529 , 65534, "PltVgtSquash0Orange"   , FieldItemKind.PltVgtPumpkin       )}, // カボチャオレンジ（苗）
            {0xECB0, new FieldItemDefinition(60592, 4530 , 65534, "PltVgtSquash1Orange"   , FieldItemKind.PltVgtPumpkin       )}, // カボチャオレンジ（成長１）
            {0xECB1, new FieldItemDefinition(60593, 4531 , 65534, "PltVgtSquash2Orange"   , FieldItemKind.PltVgtPumpkin       )}, // カボチャオレンジ（成長２）
            {0xECB2, new FieldItemDefinition(60594, 65534, 5213 , "FenceBarbedWire"       , FieldItemKind.FenceBarbedWire     )}, // ゆうしてっせん
            {0xECB3, new FieldItemDefinition(60595, 65534, 5210 , "FenceLogWall"          , FieldItemKind.FenceLogWall        )}, // まるたかべのさく
            {0xECB4, new FieldItemDefinition(60596, 65534, 5208 , "FenceLatticeBig"       , FieldItemKind.FenceLatticeBig     )}, // おおきなラティス
            {0xECB5, new FieldItemDefinition(60597, 65534, 11711, "FenceWoodPink"         , FieldItemKind.FenceWoodWhite      )}, // そぼくなもくせいのさく・ピンク
            {0xECB6, new FieldItemDefinition(60598, 65534, 5207 , "FenceJapanese"         , FieldItemKind.FenceJapanese       )}, // 和風のさく
            {0xECB7, new FieldItemDefinition(60599, 65534, 5206 , "FenceIronAndStone"     , FieldItemKind.FenceIronAndStone   )}, // 洋風のさく
            {0xECB8, new FieldItemDefinition(60600, 65534, 3402 , "FenceVerticalWood2"    , FieldItemKind.FenceVerticalWood   )}, // たていたのさく・黒
            {0xECBA, new FieldItemDefinition(60602, 65534, 11712, "FenceLattice2"         , FieldItemKind.FenceLattice        )}, // ラティス・白
            {0xECBB, new FieldItemDefinition(60603, 65534, 5208 , "FenceLatticeBig2"      , FieldItemKind.FenceLatticeBig     )}, // おおきなラティス・白
            {0xECBC, new FieldItemDefinition(60604, 65534, 65534, "PltTreeFruitStump1"    , FieldItemKind.PltTreeOak          )}, // 果物の木（成長１の切り株）
            {0xECBD, new FieldItemDefinition(60605, 65534, 65534, "PltTreeFruitStump2"    , FieldItemKind.PltTreeOak          )}, // 果物の木（成長２の切り株）
            {0xECBE, new FieldItemDefinition(60606, 65534, 65534, "PltTreeFruitStump3"    , FieldItemKind.PltTreeOak          )}, // 果物の木（成長３の切り株）
            {0xECBF, new FieldItemDefinition(60607, 65534, 65534, "PltTreeFruitStump4"    , FieldItemKind.PltTreeOak          )}, // 果物の木（成長４の切り株）
            {0xECC1, new FieldItemDefinition(60609, 7651 , 65534, "PltFlwLily3"           , FieldItemKind.PltFlwLily          )}, // スズラン（花）
            {0xECC2, new FieldItemDefinition(60610, 65534, 11711, "FenceWoodNatural"      , FieldItemKind.FenceWoodWhite      )}, // そぼくなもくせいのさく
            {0xECC3, new FieldItemDefinition(60611, 65534, 11712, "FenceLattice3"         , FieldItemKind.FenceLattice        )}, // ラティス
            {0xECC4, new FieldItemDefinition(60612, 65534, 65534, "FenceCommune"          , FieldItemKind.FenceHorizontalLog  )}, // コミューン島専用柵
            {0xECC5, new FieldItemDefinition(60613, 65534, 11711, "FenceWoodYellow"       , FieldItemKind.FenceWoodWhite      )}, // そぼくなもくせいのさく・黒
            {0xECC6, new FieldItemDefinition(60614, 65534, 11711, "FenceWoodOrange"       , FieldItemKind.FenceWoodWhite      )}, // そぼくなもくせいのさく・オレンジ
            {0xECC7, new FieldItemDefinition(60615, 65534, 11711, "FenceWoodPurple"       , FieldItemKind.FenceWoodWhite      )}, // そぼくなもくせいのさく・紫
            {0xECC8, new FieldItemDefinition(60616, 65534, 11711, "FenceWoodGreen"        , FieldItemKind.FenceWoodWhite      )}, // そぼくなもくせいのさく・緑
            {0xECC9, new FieldItemDefinition(60617, 65534, 3402 , "FenceVerticalWood6"    , FieldItemKind.FenceVerticalWood   )}, // たていたのさく・青
            {0xECCA, new FieldItemDefinition(60618, 65534, 3402 , "FenceVerticalWood5"    , FieldItemKind.FenceVerticalWood   )}, // たていたのさく・緑
            {0xECCB, new FieldItemDefinition(60619, 65534, 3402 , "FenceVerticalWood3"    , FieldItemKind.FenceVerticalWood   )}, // たていたのさく・ピンク
            {0xECCC, new FieldItemDefinition(60620, 65534, 3402 , "FenceVerticalWood4"    , FieldItemKind.FenceVerticalWood   )}, // たていたのさく・黄
            {0xECCD, new FieldItemDefinition(60621, 65534, 11712, "FenceLattice8"         , FieldItemKind.FenceLattice        )}, // ラティス・薄紫
            {0xECCE, new FieldItemDefinition(60622, 65534, 11712, "FenceLattice7"         , FieldItemKind.FenceLattice        )}, // ラティス・黒
            {0xECCF, new FieldItemDefinition(60623, 65534, 11712, "FenceLattice5"         , FieldItemKind.FenceLattice        )}, // ラティス・黄
            {0xECD0, new FieldItemDefinition(60624, 65534, 11712, "FenceLattice6"         , FieldItemKind.FenceLattice        )}, // ラティス・緑
            {0xECD1, new FieldItemDefinition(60625, 65534, 11712, "FenceLattice4"         , FieldItemKind.FenceLattice        )}, // ラティス・ピンク
            {0xECD2, new FieldItemDefinition(60626, 65534, 5208 , "FenceLatticeBig8"      , FieldItemKind.FenceLatticeBig     )}, // おおきなラティス・黒
            {0xECD3, new FieldItemDefinition(60627, 65534, 5208 , "FenceLatticeBig7"      , FieldItemKind.FenceLatticeBig     )}, // おおきなラティス・青
            {0xECD4, new FieldItemDefinition(60628, 65534, 5208 , "FenceLatticeBig5"      , FieldItemKind.FenceLatticeBig     )}, // おおきなラティス・緑
            {0xECD5, new FieldItemDefinition(60629, 65534, 5208 , "FenceLatticeBig6"      , FieldItemKind.FenceLatticeBig     )}, // おおきなラティス・紫
            {0xECD6, new FieldItemDefinition(60630, 65534, 5208 , "FenceLatticeBig3"      , FieldItemKind.FenceLatticeBig     )}, // おおきなラティス・赤
            {0xECD7, new FieldItemDefinition(60631, 65534, 5208 , "FenceLatticeBig4"      , FieldItemKind.FenceLatticeBig     )}, // おおきなラティス・オレンジ
            {0xECD8, new FieldItemDefinition(60632, 65534, 5207 , "FenceJapanese8"        , FieldItemKind.FenceJapanese       )}, // 和風のさく・紫
            {0xECD9, new FieldItemDefinition(60633, 65534, 5207 , "FenceJapanese7"        , FieldItemKind.FenceJapanese       )}, // 和風のさく・緑
            {0xECDA, new FieldItemDefinition(60634, 65534, 5207 , "FenceJapanese5"        , FieldItemKind.FenceJapanese       )}, // 和風のさく・黄
            {0xECDB, new FieldItemDefinition(60635, 65534, 5207 , "FenceJapanese6"        , FieldItemKind.FenceJapanese       )}, // 和風のさく・ベージュ
            {0xECDC, new FieldItemDefinition(60636, 65534, 5207 , "FenceJapanese2"        , FieldItemKind.FenceJapanese       )}, // 和風のさく・青
            {0xECDD, new FieldItemDefinition(60637, 65534, 5207 , "FenceJapanese3"        , FieldItemKind.FenceJapanese       )}, // 和風のさく・赤
            {0xECDE, new FieldItemDefinition(60638, 65534, 5207 , "FenceJapanese4"        , FieldItemKind.FenceJapanese       )}, // 和風のさく・オレンジ
            {0xECDF, new FieldItemDefinition(60639, 65534, 4357 , "FenceSteel2"           , FieldItemKind.FenceSteel          )}, // てつのさく・赤
            {0xECE0, new FieldItemDefinition(60640, 65534, 4357 , "FenceSteel3"           , FieldItemKind.FenceSteel          )}, // てつのさく・黄
            {0xECE1, new FieldItemDefinition(60641, 65534, 4357 , "FenceSteel4"           , FieldItemKind.FenceSteel          )}, // てつのさく・緑
            {0xECE2, new FieldItemDefinition(60642, 65534, 14757, "FenceSandProtection"   , FieldItemKind.FenceSandProtection )}, // すだれのさく
            {0xECE3, new FieldItemDefinition(60643, 65534, 14755, "FenceCrossedBamboo"    , FieldItemKind.FenceCrossedBamboo  )}, // あおたけのさく
            {0xECE4, new FieldItemDefinition(60644, 65534, 14756, "FenceIce"              , FieldItemKind.FenceIce            )}, // こおりのさく
            {0xECE6, new FieldItemDefinition(60646, 65534, 14756, "FenceIce05"            , FieldItemKind.FenceIce            )}, // こおりのさく・緑
            {0xECE7, new FieldItemDefinition(60647, 65534, 14756, "FenceIce04"            , FieldItemKind.FenceIce            )}, // こおりのさく・オレンジ
            {0xECE8, new FieldItemDefinition(60648, 65534, 14756, "FenceIce06"            , FieldItemKind.FenceIce            )}, // こおりのさく・紫
            {0xECE9, new FieldItemDefinition(60649, 65534, 14756, "FenceIce01"            , FieldItemKind.FenceIce            )}, // こおりのさく・青
            {0xECEA, new FieldItemDefinition(60650, 65534, 14756, "FenceIce02"            , FieldItemKind.FenceIce            )}, // こおりのさく・ピンク
            {0xECEB, new FieldItemDefinition(60651, 65534, 14756, "FenceIce03"            , FieldItemKind.FenceIce            )}, // こおりのさく・黄
            {0xECF4, new FieldItemDefinition(60660, 12478, 65534, "PltBushOsmathus5Yello" , FieldItemKind.PltBushOsmanthus    )}, // キンモクセイ黄（成木花なし）
            {0xECF5, new FieldItemDefinition(60661, 12478, 65534, "PltBushOsmathus4Yello" , FieldItemKind.PltBushOsmanthus    )}, // キンモクセイ黄（成木花）
            {0xECF6, new FieldItemDefinition(60662, 12477, 65534, "PltBushOsmathus2Yello" , FieldItemKind.PltBushOsmanthus    )}, // キンモクセイ黄（成長１）
            {0xECF7, new FieldItemDefinition(60663, 12478, 65534, "PltBushOsmathus3Yello" , FieldItemKind.PltBushOsmanthus    )}, // キンモクセイ黄（成木つぼみ）
            {0xECF8, new FieldItemDefinition(60664, 12753, 65534, "PltBushOsmathus1Yello" , FieldItemKind.PltBushOsmanthus    )}, // キンモクセイ黄（苗）
            {0xECF9, new FieldItemDefinition(60665, 12482, 65534, "PltBushOsmathus5Orange", FieldItemKind.PltBushOsmanthus    )}, // キンモクセイオレンジ（成木花なし）
            {0xECFA, new FieldItemDefinition(60666, 12482, 65534, "PltBushOsmathus4Orange", FieldItemKind.PltBushOsmanthus    )}, // キンモクセイオレンジ（成木花）
            {0xECFB, new FieldItemDefinition(60667, 12482, 65534, "PltBushOsmathus3Orange", FieldItemKind.PltBushOsmanthus    )}, // キンモクセイオレンジ（成木つぼみ）
            {0xECFC, new FieldItemDefinition(60668, 12754, 65534, "PltBushOsmathus1Orange", FieldItemKind.PltBushOsmanthus    )}, // キンモクセイオレンジ（苗）
            {0xECFD, new FieldItemDefinition(60669, 12481, 65534, "PltBushOsmathus2Orange", FieldItemKind.PltBushOsmanthus    )}, // キンモクセイオレンジ（成長１）
            {0xECFE, new FieldItemDefinition(60670, 12756, 65534, "PltBushCamellia1Pink"  , FieldItemKind.PltBushCamellia     )}, // ツバキピンク（苗）
            {0xECFF, new FieldItemDefinition(60671, 12491, 65534, "PltBushCamellia2Pink"  , FieldItemKind.PltBushCamellia     )}, // ツバキピンク（成長１）
            {0xED00, new FieldItemDefinition(60672, 12492, 65534, "PltBushCamellia3Pink"  , FieldItemKind.PltBushCamellia     )}, // ツバキピンク（成木つぼみ）
            {0xED01, new FieldItemDefinition(60673, 12492, 65534, "PltBushCamellia4Pink"  , FieldItemKind.PltBushCamellia     )}, // ツバキピンク（成木花）
            {0xED02, new FieldItemDefinition(60674, 12755, 65534, "PltBushCamellia1Red"   , FieldItemKind.PltBushCamellia     )}, // ツバキ赤（苗）
            {0xED03, new FieldItemDefinition(60675, 12492, 65534, "PltBushCamellia5Pink"  , FieldItemKind.PltBushCamellia     )}, // ツバキピンク（成木花なし）
            {0xED04, new FieldItemDefinition(60676, 12488, 65534, "PltBushCamellia2Red"   , FieldItemKind.PltBushCamellia     )}, // ツバキ赤（成長１）
            {0xED05, new FieldItemDefinition(60677, 12489, 65534, "PltBushCamellia3Red"   , FieldItemKind.PltBushCamellia     )}, // ツバキ赤（成木つぼみ）
            {0xED06, new FieldItemDefinition(60678, 12489, 65534, "PltBushCamellia4Red"   , FieldItemKind.PltBushCamellia     )}, // ツバキ赤（成木花）
            {0xED07, new FieldItemDefinition(60679, 12489, 65534, "PltBushCamellia5Red"   , FieldItemKind.PltBushCamellia     )}, // ツバキ赤（成木花なし）
            {0xED08, new FieldItemDefinition(60680, 65534, 12758, "FenceIkegaki"          , FieldItemKind.FenceIkegaki        )}, // いけがき
            {0xED09, new FieldItemDefinition(60681, 65534, 12894, "FenceJuneBride4"       , FieldItemKind.FenceJuneBride      )}, // ウェディングな柵・赤
            {0xED0A, new FieldItemDefinition(60682, 65534, 12894, "FenceJuneBride2"       , FieldItemKind.FenceJuneBride      )}, // ウェディングな柵・青
            {0xED0B, new FieldItemDefinition(60683, 65534, 12894, "FenceJuneBride3"       , FieldItemKind.FenceJuneBride      )}, // ウェディングな柵・緑
            {0xED0C, new FieldItemDefinition(60684, 65534, 12630, "FenceEasterEgg"        , FieldItemKind.FenceEasterEgg      )}, // イースターの柵
            {0xED0D, new FieldItemDefinition(60685, 65534, 12894, "FenceJuneBride"        , FieldItemKind.FenceJuneBride      )}, // ウェディングな柵
            {0xED0E, new FieldItemDefinition(60686, 65534, 12894, "FenceJuneBride1"       , FieldItemKind.FenceJuneBride      )}, // ウェディングな柵・ピンク
            {0xED0F, new FieldItemDefinition(60687, 12550, 12550, "PltWeedLight3"         , FieldItemKind.PltWeedLight        )}, // ヒカリゴケ3
            {0xED10, new FieldItemDefinition(60688, 12550, 12550, "PltWeedLight2C"        , FieldItemKind.PltWeedLight        )}, // ヒカリゴケ2C
            {0xED11, new FieldItemDefinition(60689, 12550, 12550, "PltWeedLight2B"        , FieldItemKind.PltWeedLight        )}, // ヒカリゴケ2B
            {0xED12, new FieldItemDefinition(60690, 12550, 12550, "PltWeedLight1A"        , FieldItemKind.PltWeedLight        )}, // ヒカリゴケ1A
            {0xED13, new FieldItemDefinition(60691, 12550, 12550, "PltWeedLight2A"        , FieldItemKind.PltWeedLight        )}, // ヒカリゴケ2A
            {0xED14, new FieldItemDefinition(60692, 12550, 12550, "PltWeedLight1B"        , FieldItemKind.PltWeedLight        )}, // ヒカリゴケ1B
            {0xED15, new FieldItemDefinition(60693, 12550, 12550, "PltWeedLight1C"        , FieldItemKind.PltWeedLight        )}, // ヒカリゴケ1C
            {0xED16, new FieldItemDefinition(60694, 2799 , 65534, "PltTreeEasterEgg"      , FieldItemKind.PltTreeOak          )}, // イースターのタマゴの木
            {0xED17, new FieldItemDefinition(60695, 65534, 12551, "PltVine"               , FieldItemKind.PltVine             )}, // ツルA
            {0xED21, new FieldItemDefinition(60705, 65534, 14278, "FenceMermaid"          , FieldItemKind.FenceMermaid        )}, // マーメイドな柵
            {0xED25, new FieldItemDefinition(60709, 65534, 13275, "FenceHalloween"        , FieldItemKind.FenceHalloween      )}, // ハロウィンのさく
            {0xED26, new FieldItemDefinition(60710, 13264, 65534, "PltBushPlumeria4Pink"  , FieldItemKind.PltBushPlumeria     )}, // プルメリア桃（成木花なし）
            {0xED27, new FieldItemDefinition(60711, 13264, 65534, "PltBushPlumeria3Pink"  , FieldItemKind.PltBushPlumeria     )}, // プルメリア桃（成木花）
            {0xED28, new FieldItemDefinition(60712, 13263, 65534, "PltBushPlumeria1Pink"  , FieldItemKind.PltBushPlumeria     )}, // プルメリア桃（成長１）
            {0xED29, new FieldItemDefinition(60713, 13264, 65534, "PltBushPlumeria2Pink"  , FieldItemKind.PltBushPlumeria     )}, // プルメリア桃（成長つぼみ）
            {0xED2A, new FieldItemDefinition(60714, 13265, 65534, "PltBushPlumeria0Pink"  , FieldItemKind.PltBushPlumeria     )}, // プルメリア桃（苗）
            {0xED2B, new FieldItemDefinition(60715, 13350, 65534, "PltBushPlumeria4White" , FieldItemKind.PltBushPlumeria     )}, // プルメリア白（成木花なし）
            {0xED2C, new FieldItemDefinition(60716, 13350, 65534, "PltBushPlumeria3White" , FieldItemKind.PltBushPlumeria     )}, // プルメリア白（成木花）
            {0xED2D, new FieldItemDefinition(60717, 13350, 65534, "PltBushPlumeria2White" , FieldItemKind.PltBushPlumeria     )}, // プルメリア白（成長つぼみ）
            {0xED2E, new FieldItemDefinition(60718, 13351, 65534, "PltBushPlumeria0White" , FieldItemKind.PltBushPlumeria     )}, // プルメリア白（苗）
            {0xED2F, new FieldItemDefinition(60719, 13349, 65534, "PltBushPlumeria1White" , FieldItemKind.PltBushPlumeria     )}, // プルメリア白（成長１）
            {0xED30, new FieldItemDefinition(60720, 65534, 12551, "PltVineC"              , FieldItemKind.PltVine             )}, // ツルC
            {0xED31, new FieldItemDefinition(60721, 65534, 12551, "PltVineB"              , FieldItemKind.PltVine             )}, // ツルB
            {0xED33, new FieldItemDefinition(60723, 65534, 13534, "LadderKitC2"           , FieldItemKind.LadderKitC          )}, // ハシゴキットC2
            {0xED34, new FieldItemDefinition(60724, 65534, 13534, "LadderKitC0"           , FieldItemKind.LadderKitC          )}, // ハシゴキットC0
            {0xED35, new FieldItemDefinition(60725, 65534, 13534, "LadderKitC1"           , FieldItemKind.LadderKitC          )}, // ハシゴキットC1
            {0xED36, new FieldItemDefinition(60726, 65534, 13530, "LadderKitB0"           , FieldItemKind.LadderKitB          )}, // ハシゴキットB0
            {0xED37, new FieldItemDefinition(60727, 65534, 13530, "LadderKitB1"           , FieldItemKind.LadderKitB          )}, // ハシゴキットB1
            {0xED38, new FieldItemDefinition(60728, 65534, 13530, "LadderKitB2"           , FieldItemKind.LadderKitB          )}, // ハシゴキットB2
            {0xED39, new FieldItemDefinition(60729, 65534, 13530, "LadderKitB3"           , FieldItemKind.LadderKitB          )}, // ハシゴキットB3
            {0xED3A, new FieldItemDefinition(60730, 65534, 13526, "LadderKitA0"           , FieldItemKind.LadderKitA          )}, // ハシゴキットA0
            {0xED3B, new FieldItemDefinition(60731, 65534, 13526, "LadderKitA1"           , FieldItemKind.LadderKitA          )}, // ハシゴキットA1
            {0xED3C, new FieldItemDefinition(60732, 65534, 13526, "LadderKitA2"           , FieldItemKind.LadderKitA          )}, // ハシゴキットA2
            {0xED3F, new FieldItemDefinition(60735, 3052 , 65534, "PltVgtSquash0"         , FieldItemKind.PltVgtPumpkin       )}, // カボチャ（苗）
            {0xED40, new FieldItemDefinition(60736, 3053 , 65534, "PltVgtSquash1"         , FieldItemKind.PltVgtPumpkin       )}, // カボチャ（成長１）
            {0xED41, new FieldItemDefinition(60737, 4362 , 65534, "PltVgtSquash2"         , FieldItemKind.PltVgtPumpkin       )}, // カボチャ（成長２）
            {0xED42, new FieldItemDefinition(60738, 65534, 14470, "LadderKitD"            , FieldItemKind.LadderKitD          )}, // ハシゴキットD0
            {0xED43, new FieldItemDefinition(60739, 65534, 13530, "LadderKitB4"           , FieldItemKind.LadderKitB          )}, // ハシゴキットB4
            {0xED44, new FieldItemDefinition(60740, 65534, 13530, "LadderKitB5"           , FieldItemKind.LadderKitB          )}, // ハシゴキットB5
            {0xED46, new FieldItemDefinition(60742, 65534, 65534, "FenceGardenPegRope"    , FieldItemKind.FenceGardenPegRope  )}, // 庭専用柵（編集外用）
            {0xED47, new FieldItemDefinition(60743, 65534, 14758, "FenceCorrugatedIron"   , FieldItemKind.FenceCorrugatedIron )}, // トタンのさく
            {0xED48, new FieldItemDefinition(60744, 65534, 14759, "FencePark"             , FieldItemKind.FencePark           )}, // こうえんのさく・青
            {0xED49, new FieldItemDefinition(60745, 65534, 14759, "FencePark2"            , FieldItemKind.FencePark           )}, // こうえんのさく・赤
            {0xED4A, new FieldItemDefinition(60746, 65534, 14759, "FencePark5"            , FieldItemKind.FencePark           )}, // こうえんのさく・ピンク
            {0xED4B, new FieldItemDefinition(60747, 65534, 14759, "FencePark4"            , FieldItemKind.FencePark           )}, // こうえんのさく・緑
            {0xED4C, new FieldItemDefinition(60748, 65534, 14759, "FencePark6"            , FieldItemKind.FencePark           )}, // こうえんのさく・赤と黄
            {0xED4D, new FieldItemDefinition(60749, 65534, 14759, "FencePark3"            , FieldItemKind.FencePark           )}, // こうえんのさく・黄
            {0xED4E, new FieldItemDefinition(60750, 65534, 14759, "FencePark8"            , FieldItemKind.FencePark           )}, // こうえんのさく・青とピンク
            {0xED4F, new FieldItemDefinition(60751, 65534, 14759, "FencePark7"            , FieldItemKind.FencePark           )}, // こうえんのさく・緑とオレンジ
            {0xED50, new FieldItemDefinition(60752, 65534, 14758, "FenceCorrugatedIron1"  , FieldItemKind.FenceCorrugatedIron )}, // あおいトタンのさく
            {0xED51, new FieldItemDefinition(60753, 65534, 14758, "FenceCorrugatedIron2"  , FieldItemKind.FenceCorrugatedIron )}, // きいろいトタンのさく
            {0xED52, new FieldItemDefinition(60754, 65534, 14758, "FenceCorrugatedIron3"  , FieldItemKind.FenceCorrugatedIron )}, // みどりのトタンのさく
            {0xED53, new FieldItemDefinition(60755, 65534, 14758, "FenceCorrugatedIron5"  , FieldItemKind.FenceCorrugatedIron )}, // さびたトタンのさく
            {0xED54, new FieldItemDefinition(60756, 65534, 14758, "FenceCorrugatedIron4"  , FieldItemKind.FenceCorrugatedIron )}, // オレンジのトタンのさく
            {0xED55, new FieldItemDefinition(60757, 65534, 4357 , "FenceSteel8"           , FieldItemKind.FenceSteel          )}, // てつのさく・黒
            {0xED56, new FieldItemDefinition(60758, 65534, 4357 , "FenceSteel7"           , FieldItemKind.FenceSteel          )}, // てつのさく・白
            {0xED57, new FieldItemDefinition(60759, 65534, 4357 , "FenceSteel6"           , FieldItemKind.FenceSteel          )}, // てつのさく・ネイビー
            {0xED58, new FieldItemDefinition(60760, 65534, 4357 , "FenceSteel5"           , FieldItemKind.FenceSteel          )}, // てつのさく・オレンジ
            {0xED59, new FieldItemDefinition(60761, 65534, 14758, "FenceCorrugatedIron6"  , FieldItemKind.FenceCorrugatedIron )}, // しろいトタンのさく
            {0xED5A, new FieldItemDefinition(60762, 65534, 14758, "FenceCorrugatedIron7"  , FieldItemKind.FenceCorrugatedIron )}, // くろいトタンのさく
            {0xED5B, new FieldItemDefinition(60763, 65534, 3402 , "FenceVerticalWood8"    , FieldItemKind.FenceVerticalWood   )}, // たていたのさく・紫
            {0xED5C, new FieldItemDefinition(60764, 65534, 3402 , "FenceVerticalWood7"    , FieldItemKind.FenceVerticalWood   )}, // たていたのさく・白
            {0xED5D, new FieldItemDefinition(60765, 65534, 12894, "FenceJuneBride7"       , FieldItemKind.FenceJuneBride      )}, // ウェディングな柵・くろ
            {0xED5E, new FieldItemDefinition(60766, 65534, 12894, "FenceJuneBride6"       , FieldItemKind.FenceJuneBride      )}, // ウェディングな柵・むらさき
            {0xED5F, new FieldItemDefinition(60767, 65534, 12894, "FenceJuneBride5"       , FieldItemKind.FenceJuneBride      )}, // ウェディングな柵・きいろ
        };
    }
}

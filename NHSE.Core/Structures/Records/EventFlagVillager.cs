using System.Collections.Generic;
// ReSharper disable StringLiteralTypo

namespace NHSE.Core
{
    public class EventFlagVillager : INamedValue
    {
        public readonly short Value1;
        public readonly short Value2;

        public ushort Index { get; }
        public string Name { get; }

        public EventFlagVillager(short v1, short v2, ushort index, string name)
        {
            Name = name;
            Index = index;
            Value1 = v1;
            Value2 = v2;
        }

        public static readonly IReadOnlyDictionary<ushort, EventFlagVillager> List = new Dictionary<ushort, EventFlagVillager>
        {
            {0x000, new EventFlagVillager(0 , 200 , 0000, "NnpcHouseLoan"                              )}, // ローン返済カウント
            {0x001, new EventFlagVillager(0 , 1   , 0001, "NnpcHouseBuildOk"                           )}, // NPCテント建て替え許可
            {0x002, new EventFlagVillager(0 , 1   , 0002, "NnpcHouseBuilt"                             )}, // NPCの家建て替え済み
            {0x003, new EventFlagVillager(0 , 1   , 0003, "CoordinateUpdate"                           )}, // 家具配置更新済か
            {0x004, new EventFlagVillager(0 , 1   , 0004, "Is3rdNpc"                                   )}, // 3人目のNPCか？
            {0x005, new EventFlagVillager(0 , 1   , 0005, "MoveInCompletion"                           )}, // 引越し完了済みか
            {0x006, new EventFlagVillager(0 , 10  , 0006, "LastFtrNum"                                 )}, // 最後に配置した家具の数
            {0x007, new EventFlagVillager(10, 10  , 0007, "MoveRoomIndex"                              )}, // ダンボール部屋表示に使用したテンプレート番号
            {0x008, new EventFlagVillager(0 , 1   , 0008, "PlayerNamePhrase"                           )}, // 口癖はプレイヤーが設定したものか
            {0x009, new EventFlagVillager(0 , 2   , 0009, "AbandonedHouse"                             )}, // 自宅を空き家状態にするか
            {0x00A, new EventFlagVillager(0 , 1   , 0010, "InputPhrase"                                )}, // 口癖を設定した事あるか
            {0x00C, new EventFlagVillager(0 , 1   , 0012, "TalkLifeStart1P1st"                         )}, // React_1P_Lifestart発生したか
            {0x00E, new EventFlagVillager(0 , 1   , 0014, "FromSettlerQuest"                           )}, // 住人移住クエストで来たNPCか
            {0x00F, new EventFlagVillager(0 , 1   , 0015, "ChangeFirstWall"                            )}, // 初期住人用壁紙を変更したか
            {0x010, new EventFlagVillager(0 , 1   , 0016, "ChangeFirstFloor"                           )}, // 初期住人用床板を変更したか
            {0x012, new EventFlagVillager(0 , 1   , 0018, "GetFirstVillagerWallFtr1"                   )}, // 初期住人用壁掛け家具１を入手したか
            {0x013, new EventFlagVillager(0 , 1   , 0019, "GetFirstVillagerWallFtr2"                   )}, // 初期住人用壁掛け家具２を入手したか
            {0x014, new EventFlagVillager(0 , 2   , 0020, "UseAudioType"                               )}, // 今日使用するオーディオ家具の種類
            {0x015, new EventFlagVillager(0 , 3   , 0021, "TalkTransitionTimes"                        )}, // 序盤→日常移行会話を呼んだ回数
            {0x016, new EventFlagVillager(0 , 1   , 0022, "FinishTalkTransition"                       )}, // 序盤→日常移行会話を聞き終えたか
            {0x017, new EventFlagVillager(0 , 3   , 0023, "OutdoorCatnap"                              )}, // 深夜屋外でのうたた寝判定状況
            {0x018, new EventFlagVillager(0 , 1   , 0024, "ForceMoveOut"                               )}, // 強制的に転出させられるフラグ
            {0x019, new EventFlagVillager(0 , 3   , 0025, "EarlyOrLate"                                )}, // 早起き・夜更かしフラグ
            {0x01A, new EventFlagVillager(0 , 16  , 0026, "ContinuousNormalDay"                        )}, // 平常活動の連続日数
            {0x01B, new EventFlagVillager(0 , 1   , 0027, "React1stNpcPresent"                         )}, // React_1P_Lifestartのプレゼント装備の反応発生したか
            {0x01C, new EventFlagVillager(0 , 1   , 0028, "IsReFabricSmartPhone"                       )}, // スマホ柄に汎用布地を使うか？
            {0x01D, new EventFlagVillager(0 , 1   , 0029, "MarketBuildingSupport"                      )}, // お店の資材集め応援会話発生したか？
            {0x020, new EventFlagVillager(0 , 1   , 0032, "NnpcHouseBuiltToday"                        )}, // NPCの家建て替え済み当日
            {0x023, new EventFlagVillager(0 , 1   , 0035, "AppE_Happen1st"                             )}, // このNPCの評判UP応援アプローチ会話発生済か？
            {0x024, new EventFlagVillager(0 , 1   , 0036, "AppE_GetItem1st"                            )}, // このNPCの評判UP応援アイテムもらったことあるか？
            {0x025, new EventFlagVillager(0 , 1   , 0037, "AppE_Rep_HappenToday"                       )}, // 今日このNPCの評判UP応援アプローチ会話発生済か？
            {0x026, new EventFlagVillager(0 , 1   , 0038, "AppE_WelcomoMigrants"                       )}, // このNPCはAppE_WelcomoMigrants発生済か？
            {0x028, new EventFlagVillager(0 , 1   , 0040, "AppE_WelcomeMigrantsToday"                  )}, // このNPCのAppE_WelcomeMigrants発生当日か？
            {0x029, new EventFlagVillager(0 , 10  , 0041, "MoveInOrder"                                )}, // 土地売約済み状態のNPCの転入順
            {0x02A, new EventFlagVillager(0 , 1   , 0042, "EquipEasterWear"                            )}, // イースター用装備にする
            {0x02B, new EventFlagVillager(0 , 10  , 0043, "ForceMoveOutVillagerIndex"                  )}, // 強制転出に指定した住人番号
            {0x02C, new EventFlagVillager(0 , 1   , 0044, "DisplayJuneBridePresent"                    )}, // ジューンブライド | 絵皿を飾るか？
            {0x02D, new EventFlagVillager(0 , 7   , 0045, "ProgressDaysJuneBrideParty"                 )}, // ジューンブライド | 結婚パーティに参加してからの経過日数
            {0x031, new EventFlagVillager(0 , 6   , 0049, "EnableConvTalkDaysCount"                    )}, // 会話のフリを解禁するまでの日数
            {0x032, new EventFlagVillager(0 , 29  , 0050, "WantIngredients"                            )}, // ハーベスト｜要求する食材
            {0x033, new EventFlagVillager(0 , 29  , 0051, "BeforeGiveIngredients"                      )}, // ハーベスト｜直前にくれた食材
            {0x034, new EventFlagVillager(0 , 29  , 0052, "BeforeWantIngredients"                      )}, // ハーベスト｜直前に要求した食材
            {0x036, new EventFlagVillager(0 , 300 , 0054, "XmasEveWakeUpMinute"                        )}, // クリスマス|起床時刻制御用
            {0x037, new EventFlagVillager(0 , 1   , 0055, "EquipChristmasWear"                         )}, // クリスマス用装備にする
            {0x038, new EventFlagVillager(0 , 2   , 0056, "HarvestGiveHint1"                           )}, // ハーベスト｜1品目の隠し食材ヒント出したら1か2をセット
            {0x039, new EventFlagVillager(0 , 2   , 0057, "HarvestGiveHint2"                           )}, // ハーベスト｜2品目の隠し食材ヒント出したら1か2をセット
            {0x03A, new EventFlagVillager(0 , 2   , 0058, "HarvestGiveHint3"                           )}, // ハーベスト｜3品目の隠し食材ヒント出したら1か2をセット
            {0x03B, new EventFlagVillager(0 , 2   , 0059, "HarvestGiveHint4"                           )}, // ハーベスト｜4品目の隠し食材ヒント出したら1か2をセット
            {0x03D, new EventFlagVillager(0 , 3   , 0061, "CarnivalFeatherColor"                       )}, // カーニバル｜欲しがる羽の色
            {0x03E, new EventFlagVillager(0 , 10  , 0062, "DisplayValentinePresent"                    )}, // バレンタインデー｜飾られるブーケの種類
            {0x040, new EventFlagVillager(0 , 1   , 0064, "HarvestDemoEndWait"                         )}, // ハーベスト｜デモ終了待機中か？
            {0x041, new EventFlagVillager(0 , 1   , 0065, "WoreNewYearHat"                             )}, // カウントダウン｜ニューイヤーハットを被った
            {0x042, new EventFlagVillager(0 , 1   , 0066, "HarvestDemoStateNow"                        )}, // ハーベスト｜デモ参加状態か？
            {0x046, new EventFlagVillager(0 , 36  , 0070, "WearItemLayer1LayoutLimit"                  )}, // 成長処理家具入替時の装備品の二層目配置候補上限数
        };

        private const string Unknown = "???";

        public static string GetName(ushort index, uint count, IReadOnlyDictionary<string, string> str)
        {
            var dict = List;
            if (dict.TryGetValue(index, out var val))
            {
                string name = val.Name;
                if (str.TryGetValue(name, out var translated))
                    name = translated;
                return $"{index:00} - {name} = {count}";
            }
            return $"{index:00} - {Unknown} = {count}";
        }

        public static string GetName(ushort index, uint count)
        {
            var dict = List;
            if (dict.TryGetValue(index, out var val))
                return $"{index:00} - {val.Name} = {count}";
            return $"{index:00} - {Unknown} = {count}";
        }
    }
}

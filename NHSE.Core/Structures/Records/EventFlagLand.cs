using System.Collections.Generic;

namespace NHSE.Core
{
    public class EventFlagLand : INamedValue
    {
        // these are actually unsigned
        public readonly short DefaultValue;
        public readonly short MaxValue;

        public ushort Index { get; }
        public string Name { get; }

        public EventFlagLand(short init, short max, ushort index, string name)
        {
            Name = name;
            Index = index;
            DefaultValue = init;
            MaxValue = max;
        }

        public static readonly IReadOnlyDictionary<ushort, EventFlagLand> List = new Dictionary<ushort, EventFlagLand>
        {
            {0x000, new EventFlagLand(0 , 1    , 0000, "TodayCreateVillage"                         )}, // 今日村作成されたか
            {0x001, new EventFlagLand(0 , 1    , 0001, "TodayPlayerEmigrate"                        )}, // 今日プレイヤが移住してきたか？
            {0x002, new EventFlagLand(0 , 1    , 0002, "TkkFirstLive"                               )}, // とたけけ|初ライブを行ったか
            {0x003, new EventFlagLand(0 , 1    , 0003, "FinishiPC1Prologue"                         )}, // PC1の序盤プロローグ完了時にON
            {0x004, new EventFlagLand(0 , 1    , 0004, "IsMovingConsultationToPlayer"               )}, // NPCが引越相談をした
            {0x005, new EventFlagLand(0 , 1    , 0005, "EnableMarketBuild"                          )}, // まめつぶ商店建築条件満たした
            {0x006, new EventFlagLand(0 , 1    , 0006, "ValidateVillageSave"                        )}, // 村データが有効化された
            {0x007, new EventFlagLand(0 , 5    , 0007, "FreeEChatTimes"                             )}, // 村で告知会話を聞いた回数
            {0x008, new EventFlagLand(0 , 5    , 0008, "FreeFChatTimes"                             )}, // 村でイベント会話を聞いた回数
            {0x00A, new EventFlagLand(0 , -1   , 0010, "RandomKey"                                  )}, // ランダムキー
            {0x00B, new EventFlagLand(0 , 1    , 0011, "DoneMuseumConstruction"                     )}, // 博物館建築工事完了
            {0x00C, new EventFlagLand(0 , 1    , 0012, "Prologue4BuiltPlayer"                       )}, // 序盤プレイヤーテント設置したか？
            {0x00D, new EventFlagLand(0 , 1    , 0013, "Plorogue4BuiltMuseum"                       )}, // 博物館|フータテント予定地設置したか？
            {0x00E, new EventFlagLand(0 , 1    , 0014, "Prologue4BuiltShop"                         )}, // 商店の工事看板設置したか？
            {0x00F, new EventFlagLand(0 , 1    , 0015, "Prologue4BuiltNpcAN"                        )}, // 序盤ANテント設置したか？
            {0x010, new EventFlagLand(0 , 1    , 0016, "Prologue4BuiltNpcHA"                        )}, // 序盤HAテント設置したか？
            {0x011, new EventFlagLand(0 , 1    , 0017, "TodayStartTown1P"                           )}, // 1Pが村誕生させた初日か？
            {0x012, new EventFlagLand(0 , 1    , 0018, "ShopItemSet"                                )}, // 商店に商品を置いてよいか？
            {0x013, new EventFlagLand(0 , 1    , 0019, "VillageExtensionLevel2"                     )}, // 村の拡張段階2
            {0x014, new EventFlagLand(0 , 1    , 0020, "RcmGotSignboard"                            )}, // まめきちが看板を手に入れた
            {0x015, new EventFlagLand(0 , 1    , 0021, "InstalledMarketTentSign"                    )}, // まめきちテントの看板が設置された
            {0x016, new EventFlagLand(0 , 1    , 0022, "SandBankDisable"                            )}, // 中州判定が無効になったか？
            {0x017, new EventFlagLand(0 , 1    , 0023, "MarketRemodelingFlag1"                      )}, // まめきちの店|テント→商店（小）改装決定
            {0x018, new EventFlagLand(0 , 1    , 0024, "MarketOpen1stDay1"                          )}, // まめきちの店|新装開店当日(商店)
            {0x019, new EventFlagLand(0 , 9    , 0025, "SpotPrologueTimes"                          )}, // 序盤会話を呼んだ回数
            {0x01A, new EventFlagLand(0 , 20000, 0026, "PlazaDonationMoney"                         )}, // イベント広場寄付金額
            {0x01B, new EventFlagLand(0 , 20   , 0027, "PlazaDonationMaterial"                      )}, // イベント広場寄付素材数(ねんど)
            {0x01C, new EventFlagLand(0 , 1    , 0028, "PlazaDonationFinish"                        )}, // イベント広場募金集まったか？
            {0x01D, new EventFlagLand(0 , 1    , 0029, "EventPlazaBuilt"                            )}, // イベント広場完成
            {0x01E, new EventFlagLand(0 , 1    , 0030, "SzaGotGyroid"                               )}, // しずえがハニワくん入手した
            {0x01F, new EventFlagLand(0 , 1    , 0031, "PlazaGyroidBuilt"                           )}, // イベント広場募金ハニワくん設置
            {0x020, new EventFlagLand(0 , 1    , 0032, "MuseumGrowupEnable1"                        )}, // 博物館成長条件1達成
            {0x021, new EventFlagLand(0 , 5    , 0033, "MuseumConstruction1"                        )}, // 博物館テント→工事中
            {0x022, new EventFlagLand(0 , 1    , 0034, "Museum2Built"                               )}, // 博物館①完成
            {0x023, new EventFlagLand(0 , 1    , 0035, "Museum2BuiltToday"                          )}, // 博物館（建物）①完成当日か？
            {0x024, new EventFlagLand(0 , 5000 , 0036, "InsectNetHostCatchNumResult"                )}, // 通信開始時にネットホストのプレイヤーが今まで捕まえたムシの数
            {0x025, new EventFlagLand(0 , 1    , 0037, "GlobalEventAvailable"                       )}, // グローバルイベント解禁
            {0x026, new EventFlagLand(0 , 1    , 0038, "InsectFesFinished"                          )}, // 島で2回目以降のムシとり大会？（ムシとり大会の日をまたいだ？）
            {0x027, new EventFlagLand(0 , 1    , 0039, "MarketRemodelingFlag2"                      )}, // まめきちの店|商店（小）→倉庫　改装決定
            {0x028, new EventFlagLand(0 , 1    , 0040, "MarketOpen1stDay2"                          )}, // まめきちの店|新装開店当日(倉庫)
            {0x029, new EventFlagLand(0 , 6    , 0041, "RcoMoveReservedKind"                        )}, // たぬきち|建物移設の予約種類判別カウンタ
            {0x02A, new EventFlagLand(0 , 1    , 0042, "QuestReserveStart"                          )}, // クエスト予約解禁
            {0x02B, new EventFlagLand(0 , -1   , 0043, "VillageDaysCount"                           )}, // 村の経過日数
            {0x02C, new EventFlagLand(0 , 1    , 0044, "PeddlingAvailableSlo"                       )}, // 行商解禁済|レイジ
            {0x02D, new EventFlagLand(0 , 1    , 0045, "MarketBuilt"                                )}, // まめつぶ商店が建った
            {0x02E, new EventFlagLand(0 , 1    , 0046, "PeddingAvailableBoa"                        )}, // カブ解禁済｜カブリバ
            {0x02F, new EventFlagLand(0 , 1    , 0047, "MarketConstruction1"                        )}, // まめきちの店|テント→商店（小）工事中
            {0x030, new EventFlagLand(0 , 1    , 0048, "MarketConstruction2"                        )}, // まめきちの店||商店（小）→倉庫　工事中
            {0x031, new EventFlagLand(0 , 1    , 0049, "FirstKabuBuy"                               )}, // 島の誰かがカブを買ったことがある
            {0x032, new EventFlagLand(0 , 1    , 0050, "FirstKabuPattern"                           )}, // 初回カブ価パターン適用済みフラグ
            {0x033, new EventFlagLand(4 , 4    , 0051, "FoxArtStockCount"                           )}, // つねきち|美術品の在庫
            {0x034, new EventFlagLand(0 , 1    , 0052, "EventPlazaBuiltToday"                       )}, // イベント広場完成当日
            {0x035, new EventFlagLand(0 , 8    , 0053, "CountNnpcHouseSpaceSet"                     )}, // 建築予定地を確保し終えた数
            {0x036, new EventFlagLand(0 , 1    , 0054, "GlobalEventReady"                           )}, // グローバルイベント準備中
            {0x037, new EventFlagLand(0 , 6    , 0055, "BirthdayBbsVariation1"                      )}, // 誕生日の告知を掲示板に前回書き込んだときのバリエーション1人用
            {0x03A, new EventFlagLand(0 , 1    , 0058, "EnableBuildTownOffice"                      )}, // 役場建設条件が揃った
            {0x03B, new EventFlagLand(0 , 1    , 0059, "BuiltTownOffice"                            )}, // 案内所完成
            {0x03C, new EventFlagLand(0 , 1    , 0060, "BuiltTownOfficeToday"                       )}, // 案内所完成当日
            {0x03D, new EventFlagLand(0 , 1    , 0061, "StartBuildingTownOffice"                    )}, // 役場建設＆村長誘致開始可能
            {0x03E, new EventFlagLand(0 , 1111 , 0062, "SzaDonatedItemType"                         )}, // 役場建設用のアイテム寄贈状況(種類判別用)
            {0x03F, new EventFlagLand(0 , 4    , 0063, "SzaDonatedItemCount"                        )}, // 役場建設用のアイテム寄贈状況(個数判別用)
            {0x041, new EventFlagLand(0 , 1    , 0065, "IsNpcIncreased"                             )}, // NPCが1人でも引越してきたか？
            {0x042, new EventFlagLand(0 , 1    , 0066, "MuseumBuilt"                                )}, // 博物館テントが建った
            {0x043, new EventFlagLand(0 , 1    , 0067, "TailorBuilt"                                )}, // 仕立て屋|仕立て屋が建った
            {0x044, new EventFlagLand(0 , 2    , 0068, "IslandKanaType"                             )}, // 『島』のルビ
            {0x045, new EventFlagLand(0 , -1   , 0069, "TodayGlobalEventId"                         )}, // 今日行われるグローバルイベントのID
            {0x046, new EventFlagLand(0 , -1   , 0070, "TodayRegionEventId"                         )}, // 今日行われるリージョンイベントのID
            {0x047, new EventFlagLand(0 , 1    , 0071, "NoncompliantRegionCode"                     )}, // 非対応の地域設定でセーブしたか？
            {0x048, new EventFlagLand(0 , 1    , 0072, "GstTalkAnyone"                              )}, // ゆうたろう|ゆうたろうと誰か話したことある？
            {0x049, new EventFlagLand(0 , 1    , 0073, "OwlFoundFossil"                             )}, // フータに化石を見せたことがある
            {0x04A, new EventFlagLand(0 , 1    , 0074, "MarketSellRecipeScoopStick"                 )}, // お店|ショボいスコップ、たかとびぼうレシピの店売りを解禁する
            {0x04B, new EventFlagLand(0 , 1    , 0075, "TailorConstruction1"                        )}, // 仕立て屋|予定地→工事中
            {0x04C, new EventFlagLand(0 , 1    , 0076, "FishFesFinished"                            )}, // 島で2回目以降のつり大会？（つり大会の日をまたいだ？）
            {0x04D, new EventFlagLand(0 , 1    , 0077, "HghStayMarket"                              )}, // きぬよ|商店に来訪中
            {0x04E, new EventFlagLand(0 , 1    , 0078, "EnableHghStayField"                         )}, // きぬよ|来訪NPCに選んでよいか？
            {0x04F, new EventFlagLand(0 , 1    , 0079, "EnableTailorBuild"                          )}, // 仕立て屋|建築条件を満たした
            {0x050, new EventFlagLand(0 , 1    , 0080, "TailorReserved"                             )}, // 仕立て屋|工事看板(予定地)が建った
            {0x051, new EventFlagLand(0 , 1    , 0081, "TailorGetHousingkit"                        )}, // 仕立て屋|工事看板を受け取った
            {0x052, new EventFlagLand(0 , 1    , 0082, "ReportedTaiorReserve"                       )}, // 仕立て屋|工事看板(予定地)建てたこと報告済み
            {0x053, new EventFlagLand(0 , 99   , 0083, "CountTailorBuild"                           )}, // 仕立て屋|建築条件に関わるカウンタ
            {0x054, new EventFlagLand(0 , 10   , 0084, "NNpcPhoneColorChangeCounter"                )}, // 一般NPC|スマホ柄が汎用布地に変わるカウンタ
            {0x055, new EventFlagLand(0 , 1    , 0085, "RcoEnableBuyHousingKit"                     )}, // たぬきち|売り土地を探すの選択肢解禁
            {0x056, new EventFlagLand(0 , 99   , 0086, "OpeningSeqBGMChangeCounter"                 )}, // 序盤シーケンス|BGM切替カウンタ
            {0x060, new EventFlagLand(0 , 1    , 0096, "JohnnySitUpFlag"                            )}, // ジョニー|起きたかフラグ(海賊ジョニーでも使用)
            {0x062, new EventFlagLand(0 , 1    , 0098, "AllowNpcInterestActivity"                   )}, // NPCの認識行動が許可されたか
            {0x067, new EventFlagLand(0 , 1    , 0103, "RcoBuildCampsiteOngoing"                    )}, // たぬきち|キャンプ場設置の依頼を島の誰かが引き受けた
            {0x068, new EventFlagLand(0 , 1    , 0104, "RcoBuildCampsiteComplete"                   )}, // たぬきち|キャンプ場設置の依頼で、誰かが予定地を建てた
            {0x06A, new EventFlagLand(0 , 1    , 0106, "RcoMeetFirstVisitorRequest"                 )}, // たぬきち|1人目の客に会う依頼をしてくるようになる
            {0x06B, new EventFlagLand(0 , 1    , 0107, "RcoMeetFirstVisitorOngoing"                 )}, // たぬきち|1人目の客に会う依頼を島の誰かが引き受けた
            {0x06C, new EventFlagLand(0 , 1    , 0108, "RcoMeetFirstVisitorComplete"                )}, // たぬきち|1人目のキャンプ客の移住希望の話を、島の誰かが聞いた
            {0x06D, new EventFlagLand(0 , 1    , 0109, "RcoBuildFirstVisitorsHousingKitOngoing"     )}, // たぬきち|1人目の客のハウジングキットの設置依頼を、島の誰かが受けた
            {0x06E, new EventFlagLand(0 , 1    , 0110, "RcoBuildFirstVisitorsHousingKitComplete"    )}, // たぬきち|1人目の客のハウジングキットを、島の誰かが設置した
            {0x072, new EventFlagLand(15, 15   , 0114, "DonationAmountForMuseum"                    )}, // 博物館建設のために必要な寄贈の残り数
            {0x073, new EventFlagLand(0 , 1    , 0115, "OfficeConstruction1"                        )}, // 役場|工事中→役場
            {0x074, new EventFlagLand(0 , 1    , 0116, "JohnnyTalkAnyPlayerFlag"                    )}, // ジョニー|村の誰か話しかけたか(海賊ジョニー不使用)
            {0x076, new EventFlagLand(0 , 1    , 0118, "TkkReturn"                                  )}, // とたけけ|帰ったか？
            {0x077, new EventFlagLand(0 , 1    , 0119, "FlightBalloonEnable"                        )}, // 空飛ぶ風船|発生してよいか？
            {0x078, new EventFlagLand(0 , 1    , 0120, "ConfirmedFruit"                             )}, // フルーツの品種が特定された
            {0x079, new EventFlagLand(0 , 1    , 0121, "RctInTent"                                  )}, // つぶきち|たぬきちテントに帰る
            {0x07A, new EventFlagLand(0 , 1    , 0122, "GstAppearField"                             )}, // ゆうたろう|村に出現する
            {0x07B, new EventFlagLand(0 , 1    , 0123, "MuseumTentBuiltToday"                       )}, // 博物館テントオープン当日か？
            {0x07C, new EventFlagLand(0 , 1    , 0124, "TailorBuiltToday"                           )}, // 仕立て屋オープン当日か？
            {0x07D, new EventFlagLand(0 , 1    , 0125, "VillageExtensionLevel3"                     )}, // 村の拡張段階3
            {0x07E, new EventFlagLand(0 , 4    , 0126, "RcoBuildBridgeSlopeStatusCounter"           )}, // たぬきち|橋/坂建設工事に関するカウンタ
            {0x07F, new EventFlagLand(0 , 2    , 0127, "RcoMoveReservedAnyone"                      )}, // たぬきち|建物の移設予約カウンタ
            {0x080, new EventFlagLand(0 , 1    , 0128, "HgcVisitFlagForTailor"                      )}, // 仕立て屋商品けってい用ことの来訪フラグ
            {0x083, new EventFlagLand(0 , 1    , 0131, "RcoDeleteBridgeSlopeReservedAnyone"         )}, // たぬきち|誰かが橋/坂の撤去を予約してる
            {0x085, new EventFlagLand(0 , 1    , 0133, "RcoBuildBridgeSlopeSelector"                )}, // たぬきち|現在の建設対象が橋/坂どちらか？0橋1坂
            {0x086, new EventFlagLand(0 , 1    , 0134, "RcoIslandRevitilizationRefuse"              )}, // たぬきち|島おこし系クエスト断った
            {0x087, new EventFlagLand(0 , 1    , 0135, "MessageBottleAvailable"                     )}, // メッセージボトル漂着が解禁
            {0x088, new EventFlagLand(0 , 1    , 0136, "ImmQ_A_GetHousing"                          )}, // 移住Quest|住宅A|ハウジングキットもらった
            {0x089, new EventFlagLand(0 , 1    , 0137, "ImmQ_B_GetHousing"                          )}, // 移住Quest|住宅B|ハウジングキットもらった
            {0x08A, new EventFlagLand(0 , 1    , 0138, "ImmQ_C_GetHousing"                          )}, // 移住Quest|住宅C|ハウジングキットもらった
            {0x08B, new EventFlagLand(0 , 1    , 0139, "ImmQ_A_SetHousing"                          )}, // 移住Quest|住宅A|ハウジングキット設置した
            {0x08C, new EventFlagLand(0 , 1    , 0140, "ImmQ_B_SetHousing"                          )}, // 移住Quest|住宅B|ハウジングキット設置した
            {0x08D, new EventFlagLand(0 , 1    , 0141, "ImmQ_C_SetHousing"                          )}, // 移住Quest|住宅C|ハウジングキット設置した
            {0x08E, new EventFlagLand(0 , 1    , 0142, "ImmQ_A_Interior1Donate"                     )}, // 移住Quest|住宅A|屋内家具１寄贈
            {0x08F, new EventFlagLand(0 , 1    , 0143, "ImmQ_B_Interior1Donate"                     )}, // 移住Quest|住宅B|屋内家具１寄贈
            {0x090, new EventFlagLand(0 , 1    , 0144, "ImmQ_C_Interior1Donate"                     )}, // 移住Quest|住宅C|屋内家具１寄贈
            {0x091, new EventFlagLand(0 , 1    , 0145, "ImmQ_A_Interior2Donate"                     )}, // 移住Quest|住宅A|屋内家具２寄贈
            {0x092, new EventFlagLand(0 , 1    , 0146, "ImmQ_B_Interior2Donate"                     )}, // 移住Quest|住宅B|屋内家具２寄贈
            {0x093, new EventFlagLand(0 , 1    , 0147, "ImmQ_C_Interior2Donate"                     )}, // 移住Quest|住宅C|屋内家具２寄贈
            {0x094, new EventFlagLand(0 , 1    , 0148, "ImmQ_A_Interior3Donate"                     )}, // 移住Quest|住宅A|屋内家具３寄贈
            {0x095, new EventFlagLand(0 , 1    , 0149, "ImmQ_B_Interior3Donate"                     )}, // 移住Quest|住宅B|屋内家具３寄贈
            {0x096, new EventFlagLand(0 , 1    , 0150, "ImmQ_C_Interior3Donate"                     )}, // 移住Quest|住宅C|屋内家具３寄贈
            {0x097, new EventFlagLand(0 , 1    , 0151, "ImmQ_A_Outdoor1Set"                         )}, // 移住Quest|住宅A|外置き家具１配置
            {0x098, new EventFlagLand(0 , 1    , 0152, "ImmQ_B_Outdoor1Set"                         )}, // 移住Quest|住宅B|外置き家具１配置
            {0x099, new EventFlagLand(0 , 1    , 0153, "ImmQ_C_Outdoor1Set"                         )}, // 移住Quest|住宅C|外置き家具１配置
            {0x09A, new EventFlagLand(0 , 1    , 0154, "ImmQ_A_Outdoor2Set"                         )}, // 移住Quest|住宅A|外置き家具２配置
            {0x09B, new EventFlagLand(0 , 1    , 0155, "ImmQ_B_Outdoor2Set"                         )}, // 移住Quest|住宅B|外置き家具２配置
            {0x09C, new EventFlagLand(0 , 1    , 0156, "ImmQ_C_Outdoor2Set"                         )}, // 移住Quest|住宅C|外置き家具２配置
            {0x09D, new EventFlagLand(0 , 1    , 0157, "ImmQ_A_Outdoor3Set"                         )}, // 移住Quest|住宅A|外置き家具３配置
            {0x09E, new EventFlagLand(0 , 1    , 0158, "ImmQ_B_Outdoor3Set"                         )}, // 移住Quest|住宅B|外置き家具３配置
            {0x09F, new EventFlagLand(0 , 1    , 0159, "ImmQ_C_Outdoor3Set"                         )}, // 移住Quest|住宅C|外置き家具３配置
            {0x0A0, new EventFlagLand(0 , 1    , 0160, "ImmQ_A_Complete"                            )}, // 移住Quest|住宅A|全工程完了
            {0x0A1, new EventFlagLand(0 , 1    , 0161, "ImmQ_B_Complete"                            )}, // 移住Quest|住宅B|全工程完了
            {0x0A2, new EventFlagLand(0 , 1    , 0162, "ImmQ_C_Complete"                            )}, // 移住Quest|住宅C|全工程完了
            {0x0A3, new EventFlagLand(0 , 1    , 0163, "ImmQ_A_Invited"                             )}, // 移住Quest|移住者A|勧誘した
            {0x0A4, new EventFlagLand(0 , 1    , 0164, "ImmQ_B_Invited"                             )}, // 移住Quest|移住者B|勧誘した
            {0x0A5, new EventFlagLand(0 , 1    , 0165, "ImmQ_C_Invited"                             )}, // 移住Quest|移住者C|勧誘した
            {0x0A6, new EventFlagLand(0 , 1    , 0166, "RcmImmQuestOpen"                            )}, // たぬきち|移住Quest開始できる
            {0x0A7, new EventFlagLand(0 , 1    , 0167, "RcmImmQuestRunning"                         )}, // たぬきち|移住Quest実施中
            {0x0A8, new EventFlagLand(0 , 1    , 0168, "RcmImmQuestComplete"                        )}, // たぬきち|移住Quest完了
            {0x0A9, new EventFlagLand(0 , 9    , 0169, "JohnnyRequirePartsNum"                      )}, // ジョニー|必要なパーツの個数(海賊ジョニー不使用)
            {0x0AA, new EventFlagLand(0 , 1    , 0170, "ImmQ_A_InteriorDonateNow"                   )}, // 移住Quest|住宅A|屋内家具を今寄贈した
            {0x0AB, new EventFlagLand(0 , 1    , 0171, "ImmQ_B_InteriorDonateNow"                   )}, // 移住Quest|住宅B|屋内家具の今寄贈した
            {0x0AC, new EventFlagLand(0 , 1    , 0172, "ImmQ_C_InteriorDonateNow"                   )}, // 移住Quest|住宅C|屋内家具の今寄贈した
            {0x0AD, new EventFlagLand(0 , 1    , 0173, "RcoRemoveBridgeSlopeSelector"               )}, // たぬきち|現在の撤去対象が橋/坂どちらか？0橋1坂
            {0x0AE, new EventFlagLand(0 , 288  , 0174, "CeremonySlopeUnitX"                         )}, // セレモニ|坂建設位置Ｘ
            {0x0AF, new EventFlagLand(0 , 256  , 0175, "CeremonySlopeUnitZ"                         )}, // セレモニ|坂建設位置Z
            {0x0B0, new EventFlagLand(0 , 1    , 0176, "RcoNoticeBuildInfomationOffice"             )}, // たぬきち|案内所建物建築のお知らせ可能
            {0x0B1, new EventFlagLand(0 , 1    , 0177, "CampSiteBuilt"                              )}, // キャンプ場が建った
            {0x0B2, new EventFlagLand(0 , 1    , 0178, "RcoDeleteBridgeSlopeBuildPlayer"            )}, // たぬきち|橋/坂予定地を建てたプレイヤーが削除された
            {0x0B3, new EventFlagLand(0 , 100  , 0179, "VisitorPrayStarToday"                       )}, // 今日村に来たビジタが祈った回数
            {0x0B4, new EventFlagLand(0 , 1    , 0180, "AmiiboCampSiteCall"                         )}, // 今日amiiboを使ってキャンプ場にNPCを呼んだ
            {0x0B5, new EventFlagLand(0 , 1    , 0181, "ImmQ_SetBridge"                             )}, // 移住Quest|橋の予定地が配置された
            {0x0B6, new EventFlagLand(0 , 1    , 0182, "CampQuestInProgress"                        )}, // キャンプ家具クエスト進行中
            {0x0B7, new EventFlagLand(0 , 1    , 0183, "CampQuestClear"                             )}, // キャンプ家具クエストクリア済
            {0x0B9, new EventFlagLand(0 , 1    , 0185, "SzaTaled1stTimeAnyPlayer"                   )}, // 24時間BGMを案内所完成後用に切り替える
            {0x0BA, new EventFlagLand(0 , 288  , 0186, "CeremonyBridgeUnitX"                        )}, // セレモニ|橋建設位置Ｘ
            {0x0BB, new EventFlagLand(0 , 256  , 0187, "CeremonyBridgeUnitZ"                        )}, // セレモニ|橋建設位置Ｚ
            {0x0BC, new EventFlagLand(0 , 1    , 0188, "CeremonyBuildCampSite"                      )}, // セレモニ|セレモニ開催できる：キャンプ場
            {0x0BD, new EventFlagLand(0 , 1    , 0189, "CeremonyBuildTailor"                        )}, // セレモニ|廃止予定：置き換え可
            {0x0BE, new EventFlagLand(0 , 1    , 0190, "CeremonyBuildBridge"                        )}, // セレモニ|セレモニ開催できる：橋
            {0x0BF, new EventFlagLand(0 , 1    , 0191, "CeremonyBuildSlope"                         )}, // セレモニ|セレモニ開催できる：坂
            {0x0C0, new EventFlagLand(0 , 1    , 0192, "IslandDevQuestRunning"                      )}, // たぬきち|島の発展Quest実施中
            {0x0C1, new EventFlagLand(0 , 1    , 0193, "IslandDevQuestComplete"                     )}, // たぬきち|島の発展Quest完了
            {0x0C2, new EventFlagLand(0 , 10000, 0194, "CountTailorAfterBuild"                      )}, // 仕立て屋|オープンして何日目か
            {0x0C3, new EventFlagLand(0 , 10000, 0195, "CountMuseumAfterBuild"                      )}, // 博物館|オープンして何日目か
            {0x0C4, new EventFlagLand(0 , 10000, 0196, "CountMarket1AfterBuild"                     )}, // まめきちの店|小がオープンして何日目か
            {0x0C5, new EventFlagLand(0 , 10000, 0197, "CountMarket2AfterBuild"                     )}, // まめきちの店|大がオープンして何日目か
            {0x0C6, new EventFlagLand(0 , 10000, 0198, "CountOfficeAfterBuild"                      )}, // 案内所|オープンして何日目か
            {0x0C7, new EventFlagLand(0 , 7    , 0199, "CountFirstBridgeAfterBuild"                 )}, // 初めての橋に言及する会話を表示できる残り日数
            {0x0C8, new EventFlagLand(0 , 7    , 0200, "CountFirstSlopeAfterBuild"                  )}, // 初めての坂に言及する会話を表示できる残り日数
            {0x0C9, new EventFlagLand(0 , 1    , 0201, "IslandEvaluationUnlock"                     )}, // しずえ|島の評価島全体で解禁
            {0x0CA, new EventFlagLand(0 , 1    , 0202, "IslandEvaluationClearTkkLive"               )}, // しずえ|島の評価がとたけけライブ発生基準をクリアした
            {0x0CB, new EventFlagLand(0 , 10   , 0203, "HaveHousingKitCount"                        )}, // たぬきち|島の住人が所持ているハウジングキットの数
            {0x0CC, new EventFlagLand(0 , 1    , 0204, "BridgeBuilt"                                )}, // 橋を作ったことがある
            {0x0CD, new EventFlagLand(0 , 1    , 0205, "SlopeBuilt"                                 )}, // 坂を作ったことがある
            {0x0CE, new EventFlagLand(0 , 3    , 0206, "BeyRequireFishSize"                         )}, // 来訪新うおまさ|クエスト対象のサカナサイズ
            {0x0CF, new EventFlagLand(0 , 1    , 0207, "TanuportAmiiboUnlock"                       )}, // タヌポート|amiibo関連機能を解禁
            {0x0D8, new EventFlagLand(0 , 1    , 0216, "SpnVisitMainField"                          )}, // パニエル|メインフィールドに出現
            {0x0D9, new EventFlagLand(0 , 1    , 0217, "ChangePlazaFtrToNormal"                     )}, // 広場の序盤配置家具を撤去
            {0x0DA, new EventFlagLand(0 , 1    , 0218, "SetPrologueBonfire"                         )}, // 序盤シーケンス|イベント用キャンプファイア設置
            {0x0DB, new EventFlagLand(0 , 1    , 0219, "ImmQ_A_OutdoorPattern"                      )}, // 移住Quest|住宅A|外置き家具パターンがAかBか？
            {0x0DC, new EventFlagLand(0 , 1    , 0220, "ImmQ_B_OutdoorPattern"                      )}, // 移住Quest|住宅B|外置き家具パターンがAかBか？
            {0x0DD, new EventFlagLand(0 , 1    , 0221, "ImmQ_C_OutdoorPattern"                      )}, // 移住Quest|住宅C|外置き家具パターンがAかBか？
            {0x0DE, new EventFlagLand(0 , 1    , 0222, "TkkFirstLiveReserved"                       )}, // とたけけ|初ライブ当日か？
            {0x0DF, new EventFlagLand(0 , 2    , 0223, "BirthdayBbsVariation2"                      )}, // 誕生日の告知を掲示板に前回書き込んだときのバリエーション2人用
            {0x0E0, new EventFlagLand(0 , 1    , 0224, "AllowNpcGroupActivity"                      )}, // NPCの広場行動（集団）が許可されたか
            {0x0E1, new EventFlagLand(0 , 1    , 0225, "TanuportAmiiboCampUnlock"                   )}, // タヌポート|amiiboキャンプ場呼び出しが解禁可
            {0x0E2, new EventFlagLand(0 , 1    , 0226, "PickedUpMessageBottle"                      )}, // 最初のメッセージボトルが拾われた
            {0x0E3, new EventFlagLand(0 , 10   , 0227, "CountAppE_RepTalk"                          )}, // 一般NPC島評判UP応援アプローチ発生(アイテムもらった)回数カウント
            {0x0E4, new EventFlagLand(0 , 10   , 0228, "FlwLilyGrowCounter"                         )}, // スズラン|発生率決定カウンタ
            {0x0E5, new EventFlagLand(0 , 1    , 0229, "FlwLilyFirstGrow"                           )}, // スズラン|島に発生したことがある？
            {0x0E6, new EventFlagLand(0 , 1    , 0230, "CampFirstCamperVisit"                       )}, // キャンプ場|最初のキャンプ場客が滞在中か？
            {0x0E7, new EventFlagLand(0 , 1    , 0231, "RcmShopMaterial_Wood"                       )}, // まめきち|木材提供済？
            {0x0E8, new EventFlagLand(0 , 1    , 0232, "RcmShopMaterial_HardWood"                   )}, // まめきち|かたい木材提供済？
            {0x0E9, new EventFlagLand(0 , 1    , 0233, "RcmShopMaterial_SoftWood"                   )}, // まめきち|やわらかい木材提供済？
            {0x0EA, new EventFlagLand(0 , 1    , 0234, "RcmShopMaterial_Iron"                       )}, // まめきち|鉄鉱石提供済？
            {0x0EB, new EventFlagLand(0 , 1    , 0235, "RcmShopMaterialComplete"                    )}, // まめきち|すべての資材が揃った
            {0x0EC, new EventFlagLand(0 , 1    , 0236, "DailyQuestFivePointDay"                     )}, // 日課の5倍ポイントデーか？
            {0x0ED, new EventFlagLand(0 , 1    , 0237, "ReportFirstCamperAboutSetHousing"           )}, // キャンプ場|最初のキャンプ場客に家の予定地セットの報告した
            {0x0EE, new EventFlagLand(0 , 1    , 0238, "RcoRcmTalkingAboutStoreMaterial"            )}, // たぬきち&まめきち|商店建設資材の相談会話(初回)発生した
            {0x0EF, new EventFlagLand(0 , 1    , 0239, "PAnnounceRcoCalling"                        )}, // 島内放送|放送中の入電イベント初回発生済
            {0x0F1, new EventFlagLand(0 , 1    , 0241, "PAnnounceCeremony1st"                       )}, // 島内放送|初めてセレモニーの告知した
            {0x0F2, new EventFlagLand(0 , 1    , 0242, "PAnnounceCeremony1stToday"                  )}, // 島内放送|初めてセレモニーの告知入った当日のみON
            {0x0F3, new EventFlagLand(0 , 1    , 0243, "CampSiteBuiltToday"                         )}, // キャンプ場が建った当日
            {0x0F4, new EventFlagLand(0 , 10000, 0244, "CountCampSiteAfterBuild"                    )}, // キャンプ場|オープンして何日目か
            {0x0F5, new EventFlagLand(0 , 1    , 0245, "IslandLocalFruitApple"                      )}, // 島の特産フルーツがリンゴならON
            {0x0F6, new EventFlagLand(0 , 1    , 0246, "IslandLocalFruitOrange"                     )}, // 島の特産フルーツがオレンジならON
            {0x0F7, new EventFlagLand(0 , 1    , 0247, "IslandLocalFruitPear"                       )}, // 島の特産フルーツがナシならON
            {0x0F8, new EventFlagLand(0 , 1    , 0248, "IslandLocalFruitPeach"                      )}, // 島の特産フルーツがモモならON
            {0x0F9, new EventFlagLand(0 , 1    , 0249, "IslandLocalFruitCherry"                     )}, // 島の特産フルーツがサクランボならON
            {0x0FA, new EventFlagLand(0 , 1    , 0250, "HghPeddlerPurchaceToday"                    )}, // きぬよ行商|今回の来訪で島の誰かが商品購入した？
            {0x0FB, new EventFlagLand(0 , 1    , 0251, "PAnnounceKkProject"                         )}, // 島内放送|とたけけプロジェクトの予告発生した？
            {0x0FC, new EventFlagLand(0 , 1    , 0252, "TownNewsHeardEventStarted"                  )}, // 島内放送|イベント開始済み村内放送を聞いた？
            {0x0FD, new EventFlagLand(0 , 999  , 0253, "SzaIslandEvaluationBeforeLife"              )}, // しずえ|島の環境：前回の「生活」ポイント
            {0x0FE, new EventFlagLand(0 , 999  , 0254, "SzaIslandEvaluationBeforeNatural"           )}, // しずえ|島の環境：前回の「自然」ポイント
            {0x0FF, new EventFlagLand(0 , 5000 , 0255, "FishNetHostCatchNumResult"                  )}, // 通信開始時にネットホストのプレイヤーが今まで捕まえたサカナの数
            {0x100, new EventFlagLand(0 , 10   , 0256, "SzaIslandEvaluationBeforeDevelopment"       )}, // しずえ|島の環境：前回の「発展」要素
            {0x101, new EventFlagLand(0 , 1    , 0257, "SzaIslandEvaluationTodayRankUpdate"         )}, // しずえ|島の環境：今日のポイント更新したらON
            {0x102, new EventFlagLand(0 , 1    , 0258, "SzaIslandEvaluationImprovementLifeToday"    )}, // しずえ|島の環境：前回島内放送より「生活」ポイント向上
            {0x103, new EventFlagLand(0 , 1    , 0259, "SzaIslandEvaluationImprovementNaturalToday" )}, // しずえ|島の環境：前回島内放送より「自然」ポイント向上
            {0x104, new EventFlagLand(0 , 1    , 0260, "SzaIslandEvaluationImprovementDevelopToday" )}, // しずえ|島の環境：前回島内放送より発展要素が増えた
            {0x105, new EventFlagLand(0 , 1    , 0261, "AppE_WelcomoMigrants_AN"                    )}, // AppE_WelcomoMigrants_AN発生した
            {0x106, new EventFlagLand(0 , 1    , 0262, "AppE_WelcomoMigrants_HA"                    )}, // AppE_WelcomoMigrants_HA発生した
            {0x107, new EventFlagLand(0 , 1    , 0263, "TkkFirstLiveSubPlayer"                      )}, // とたけけ|2人目以降のプレイヤーが初ライブを見られる？
            {0x108, new EventFlagLand(0 , 1    , 0264, "PortableRadioControl"                       )}, // けいたいラジオ挙動制御用フラグ
            {0x109, new EventFlagLand(0 , 1    , 0265, "Market2Built"                               )}, // まめつぶ商店が大になった
            {0x10A, new EventFlagLand(0 , 1    , 0266, "OwlTentExplainFor1P"                        )}, // フータ|誰かに棒高跳び＆スコップレシピ提供済
            {0x10B, new EventFlagLand(0 , 1    , 0267, "MuseumConstructionToday"                    )}, // 今日、博物館工事当日であるか？
            {0x10C, new EventFlagLand(0 , 1    , 0268, "ShopUnlockAxe"                              )}, // お店|ショボいオノの店売りを解禁する
            {0x10D, new EventFlagLand(0 , 1    , 0269, "FinishMuseumPreparation1stDay"              )}, // フータ移住初日に博物館建築条件を達成した
            {0x10E, new EventFlagLand(0 , 2    , 0270, "MushroomProbability"                        )}, // キノコ|発生確率決定フラグ
            {0x10F, new EventFlagLand(0 , 3    , 0271, "NNpcContractProbablityAddPoint"             )}, // 一般NPC|売地契約補正値
            {0x110, new EventFlagLand(0 , 1    , 0272, "TkkFirstLiveEnable"                         )}, // とたけけ|初ライブ解禁か？
            {0x111, new EventFlagLand(0 , 1    , 0273, "ImmQClearNextDay"                           )}, // 移住Quest|クリアして1日経ったか？
            {0x112, new EventFlagLand(0 , 1    , 0274, "TodayImmQNotClear"                          )}, // 移住Quest|今日の最初に移住クエスト未クリアだった？
            {0x113, new EventFlagLand(0 , 1    , 0275, "NpcDIYScheduleSet"                          )}, // NPCのDIYスケジュールを決定したか
            {0x114, new EventFlagLand(0 , 1    , 0276, "PAnnounceToday"                             )}, // 今日、村で島内放送が発生した
            {0x115, new EventFlagLand(0 , 1    , 0277, "AirportOpen"                                )}, // 飛行場|オープンしたか？
            {0x117, new EventFlagLand(0 , 1    , 0279, "AnyGlobalEventFinished"                     )}, // いずれかのグローバルイベント日をまたいだ？
            {0x118, new EventFlagLand(0 , 1    , 0280, "LostPropertyFound"                          )}, // 島Pの誰かが落とし物を拾った
            {0x119, new EventFlagLand(0 , 1    , 0281, "MuseumFossilComplete"                       )}, // 博物館_化石部屋コンプ済
            {0x11A, new EventFlagLand(0 , 1    , 0282, "InduceInMysteriTourIslandToday"             )}, // 今日ミステリーツアー島で勧誘した
            {0x11B, new EventFlagLand(0 , 1    , 0283, "Tutorial1PTentLightON"                      )}, // 1P島代表のテントの明かりをONにするか？
            {0x11C, new EventFlagLand(0 , 9999 , 0284, "PynVisitYear"                               )}, // ぴょんたろうが来訪した年
            {0x11D, new EventFlagLand(0 , 1    , 0285, "PynVisitToday"                              )}, // ぴょんたろうが今日来訪NPCとして来訪する
            {0x11E, new EventFlagLand(0 , -1   , 0286, "CatchInsectFesGetTotalNum"                  )}, // ムシ取り大会|全員のムシ取得数
            {0x11F, new EventFlagLand(0 , -1   , 0287, "CatchFishFesGetTotalNum"                    )}, // つり大会|全員のサカナ取得数
            {0x120, new EventFlagLand(0 , 1    , 0288, "JohnnyQuestFinishFlagIsland"                )}, // ジョニー|その日に村で誰かがジョニーを助けたか？(海賊ジョニーでも使用)
            {0x121, new EventFlagLand(0 , 10   , 0289, "CampRandomSelectMoveOutNpc"                 )}, // キャンプ場|ランダム選出転出NPCが何番目の住人か？(0:未抽選/抽選対象なし)
            {0x122, new EventFlagLand(0 , 1    , 0290, "CampFireRemoved"                            )}, // 広場のキャンプファイアー撤去（実際の撤去とは連動してません）
            {0x125, new EventFlagLand(0 , 1    , 0293, "UnlockEaster"                               )}, // BCATにてイースター解禁
            {0x126, new EventFlagLand(0 , 5    , 0294, "MuseumConstruction2"                        )}, // 博物館1→2(美術部屋追加)への工事中
            {0x127, new EventFlagLand(0 , 1    , 0295, "MuseumGrowupEnable2"                        )}, // 博物館2(美術部屋追加)への成長条件達成
            {0x130, new EventFlagLand(0 , 1    , 0304, "OwlWantsPainting"                           )}, // フータの絵画クエストを開始した
            {0x131, new EventFlagLand(0 , 10   , 0305, "CampTodaySelectMoveOutNpc"                  )}, // キャンプ場|強制転出NPCが何番目の住人か？(0:未抽選/抽選対象なし)
            {0x132, new EventFlagLand(0 , 1    , 0306, "Museum3Built"                               )}, // 博物館②(美術部屋追加)完成
            {0x133, new EventFlagLand(0 , 1    , 0307, "Museum3BuiltToday"                          )}, // 博物館②(美術部屋追加)完成当日か？
            {0x134, new EventFlagLand(0 , 10000, 0308, "CountMuseum2AfterBuild"                     )}, // 博物館②(美術部屋追加)|オープンして何日目か
            {0x135, new EventFlagLand(0 , 1    , 0309, "Museum2ConstructionToday"                   )}, // 今日、博物館②(美術部屋追加)工事当日であるか？
            {0x136, new EventFlagLand(0 , 1    , 0310, "GrowUpAfterPatch1_1"                        )}, // 1.1適用して成長処理をした
            {0x137, new EventFlagLand(0 , 1    , 0311, "GrowUpAfterPatch1_2"                        )}, // 1.2適用して成長処理をした
            {0x138, new EventFlagLand(0 , 1    , 0312, "GrowUpAfterPatch1_3"                        )}, // 1.3適用して成長処理をした
            {0x139, new EventFlagLand(0 , 1    , 0313, "GrowUpAfterPatch1_4"                        )}, // 1.4適用して成長処理をした
            {0x13B, new EventFlagLand(0 , 1    , 0315, "EarthdaySloFirstVisit"                      )}, // アースデーの初回レイジを予約した
            {0x13C, new EventFlagLand(0 , 1    , 0316, "OwlFoundDiveFish"                           )}, // フータ|誰かが海の幸を見せたことがある
            {0x13D, new EventFlagLand(0 , 1    , 0317, "SloPeddlerPurchaceToday"                    )}, // レイジ行商|今回の来訪で島の誰かが商品購入した？
            {0x13E, new EventFlagLand(0 , 1    , 0318, "FoxPreVisitToday"                           )}, // つねきちが今日事前来訪する
            {0x13F, new EventFlagLand(0 , 1    , 0319, "AnyPlayerHouseBuilt"                        )}, // 住人の誰かのマイホームが１度でも建ったことがある
            {0x140, new EventFlagLand(0 , 50   , 0320, "MuseumFishStampRackLotID1"                  )}, // 国際ミュージアム|1つ目のサカナのスタンプ台ID
            {0x141, new EventFlagLand(0 , 50   , 0321, "MuseumFishStampRackLotID2"                  )}, // 国際ミュージアム|2つ目のサカナのスタンプ台ID
            {0x142, new EventFlagLand(0 , 50   , 0322, "MuseumFishStampRackLotID3"                  )}, // 国際ミュージアム|3つ目のサカナのスタンプ台ID
            {0x143, new EventFlagLand(0 , 50   , 0323, "MuseumInsectStampRackLotID1"                )}, // 国際ミュージアム|1つ目のムシのスタンプ台ID
            {0x144, new EventFlagLand(0 , 50   , 0324, "MuseumInsectStampRackLotID2"                )}, // 国際ミュージアム|2つ目のムシのスタンプ台ID
            {0x145, new EventFlagLand(0 , 50   , 0325, "MuseumInsectStampRackLotID3"                )}, // 国際ミュージアム|3つ目のムシのスタンプ台ID
            {0x146, new EventFlagLand(0 , 50   , 0326, "MuseumFossilStampRackLotID1"                )}, // 国際ミュージアム|1つ目のかせきのスタンプ台ID
            {0x147, new EventFlagLand(0 , 50   , 0327, "MuseumFossilStampRackLotID2"                )}, // 国際ミュージアム|2つ目のかせきのスタンプ台ID
            {0x148, new EventFlagLand(0 , 50   , 0328, "MuseumFossilStampRackLotID3"                )}, // 国際ミュージアム|3つ目のかせきのスタンプ台ID
            {0x149, new EventFlagLand(0 , 1    , 0329, "AOC_EventFlag_000"                          )}, // AOC同期フラグ| 000 Compass
            {0x14A, new EventFlagLand(0 , 1    , 0330, "AOC_EventFlag_001"                          )}, // AOC同期フラグ| 001 NSO加入特典
            {0x14C, new EventFlagLand(0 , 1    , 0332, "FoxPreVisitReserve"                         )}, // 事前来訪つねきちを翌日に予約する
            {0x14D, new EventFlagLand(0 , 1    , 0333, "FoxMovedToMarket"                           )}, // つねきち|来訪時にフィールドから船へ移動した
            {0x14E, new EventFlagLand(0 , 1    , 0334, "FoxAndShipReserve"                          )}, // つねきち船＋フィールドを予約する
            {0x14F, new EventFlagLand(0 , 1    , 0335, "BCAT_EventFlag_002"                         )}, // 国際ミュージアム解禁
            {0x150, new EventFlagLand(0 , 1    , 0336, "BCAT_EventFlag_004"                         )}, // ハーベスト解禁
            {0x151, new EventFlagLand(0 , 1    , 0337, "BCAT_EventFlag_001"                         )}, // メーデー解禁
            {0x152, new EventFlagLand(0 , 1    , 0338, "BCAT_EventFlag_003"                         )}, // ジューンブライド解禁
            {0x157, new EventFlagLand(0 , 1    , 0343, "FoxPreVisit1Today"                          )}, // つねきち1回目の事前来訪当日
            {0x158, new EventFlagLand(0 , 1    , 0344, "FoxPreVisit2Today"                          )}, // つねきち2回目の事前来訪当日
            {0x159, new EventFlagLand(0 , 1    , 0345, "EarthdaySloFirstVisitToday"                 )}, // 今日がアースデーの初回レイジ来訪日
            {0x15A, new EventFlagLand(0 , 1    , 0346, "IsDreamingBed"                              )}, // ゆめみ用ベッドある？
            {0x15B, new EventFlagLand(0 , 1    , 0347, "UnlockJuneBrideSeq"                         )}, // ゲーム進行的にジューンブライド解禁
            {0x15C, new EventFlagLand(0 , -1   , 0348, "RandomKey1"                                 )}, // ランダムキー1
            {0x15D, new EventFlagLand(0 , -1   , 0349, "RandomKey2"                                 )}, // ランダムキー2
            {0x15E, new EventFlagLand(0 , -1   , 0350, "RandomKey3"                                 )}, // ランダムキー3
            {0x15F, new EventFlagLand(0 , -1   , 0351, "RandomKey4"                                 )}, // ランダムキー4
            {0x160, new EventFlagLand(0 , 1    , 0352, "FoxPreVisitAlreadyBuyToday"                 )}, // つねきち|今日誰かが事前来訪中に美術品を買った
            {0x161, new EventFlagLand(0 , 1    , 0353, "RcoHasResolvedMoveKitBug"                   )}, // いせつキットバグを解消したか
            {0x162, new EventFlagLand(0 , 1    , 0354, "TapDreamEnable"                             )}, // ゆめみ|ゆめみ機能解禁か？
            {0x165, new EventFlagLand(0 , 1    , 0357, "GulBVisitEnable"                            )}, // 海賊ジョニーが来訪する条件を満たしたか
            {0x167, new EventFlagLand(0 , 9999 , 0359, "FireworksAddBbsYear"                        )}, // 花火大会予告の掲示板書き込みをした年
            {0x16A, new EventFlagLand(0 , 1    , 0362, "EnableMyDream"                              )}, // ゆめみ|現在、自分の島の夢を提供中か？
            {0x16B, new EventFlagLand(0 , 1    , 0363, "JohnnyInvisible"                            )}, // ジョニー非表示状態か
            {0x16C, new EventFlagLand(0 , 1    , 0364, "DreamUploadPlayerHaveCreaterID"             )}, // ゆめみ|夢の最終更新者がMyDesignショーケースの作者IDを持ってるか？
            {0x16D, new EventFlagLand(0 , 5000 , 0365, "DiveFishNetHostCatchNumResult"              )}, // 通信開始時にネットホストのプレイヤーが今までに捕まえた海の幸の数
            {0x16E, new EventFlagLand(0 , 9999 , 0366, "HalloweenSloVisitYear"                      )}, // ハロウィンの初回レイジを予約した年
            {0x16F, new EventFlagLand(0 , 1    , 0367, "HalloweenSloVisitToday"                     )}, // 今日がハロウィンのレイジ来訪日
            {0x171, new EventFlagLand(0 , 1    , 0369, "GrowUpAfterPatch1_5"                        )}, // 1.5適用して成長処理をした
            {0x172, new EventFlagLand(0 , 1    , 0370, "NeedUpdatePassword"                         )}, // セーブデータ復元後のパスワード更新必要
            {0x173, new EventFlagLand(0 , 1    , 0371, "IsHalloweenLessThanThreeDays"               )}, // ハロウィン３日前以内か？
            {0x174, new EventFlagLand(0 , 1    , 0372, "GrowUpAfterPatch1_6"                        )}, // 1.6適用して成長処理をした
            {0x175, new EventFlagLand(0 , 1    , 0373, "IslandProducedByPlayerMoving"               )}, // プレイヤーだけ引越し|プレイヤーだけ引越しによって作られた島か？
            {0x176, new EventFlagLand(0 , 1    , 0374, "EventObjFlag0"                              )}, // イベントオブジェフラグ0
            {0x179, new EventFlagLand(0 , 4    , 0377, "HarvestProgress"                            )}, // ハーベスト｜完成した料理の数（島単位）
            {0x17A, new EventFlagLand(0 , 1    , 0378, "PlayerMovingEnableShopMaterialCollect"      )}, // プレイヤーだけ引越し|お店の資材集め解禁していいか？
            {0x17B, new EventFlagLand(0 , 1    , 0379, "SecondPublicAnnouncement"                   )}, // 2回目島内放送の発生が必要か？
            {0x17C, new EventFlagLand(0 , 1    , 0380, "HarvestAfterTerm"                           )}, // ハーベスト｜アフター期間か？
            {0x17D, new EventFlagLand(0 , 1    , 0381, "FinishTreasureQuestByRollback"              )}, // 宝探しクエストが通信ロールバックで終了した
            {0x17E, new EventFlagLand(0 , 1    , 0382, "HarvestHQDish1Island"                       )}, // ハーベスト｜島の誰かが料理１クラムチャウダーの隠し食材納めた？
            {0x17F, new EventFlagLand(0 , 1    , 0383, "HarvestHQDish2Island"                       )}, // ハーベスト｜島の誰かが料理２パンプキンパイの隠し食材納めた？
            {0x180, new EventFlagLand(0 , 1    , 0384, "HarvestHQDish3Island"                       )}, // ハーベスト｜島の誰かが料理３グラタンの隠し食材納めた？
            {0x181, new EventFlagLand(0 , 1    , 0385, "HarvestHQDish4Island"                       )}, // ハーベスト｜島の誰かが料理４サカナのムニエルの隠し食材納めた？
            {0x182, new EventFlagLand(0 , 1    , 0386, "IsDisclosedMyDream"                         )}, // ゆめみ|現在、自分の島の夢をおまかせに公開中か？
            {0x183, new EventFlagLand(0 , 19   , 0387, "HarvestTukIngredient2_2"                    )}, // ハーベスト｜必要食材２－２
            {0x184, new EventFlagLand(0 , 19   , 0388, "HarvestTukIngredient3_1"                    )}, // ハーベスト｜必要食材３－１
            {0x185, new EventFlagLand(0 , 19   , 0389, "HarvestTukIngredient3_2"                    )}, // ハーベスト｜必要食材３－２
            {0x186, new EventFlagLand(0 , 19   , 0390, "HarvestTukIngredient4_2"                    )}, // ハーベスト｜必要食材４－２
            {0x187, new EventFlagLand(0 , 19   , 0391, "HarvestTukHideIngredient2_1"                )}, // ハーベスト｜隠し食材２－１
            {0x188, new EventFlagLand(0 , 19   , 0392, "HarvestTukHideIngredient2_2"                )}, // ハーベスト｜隠し食材２－２
            {0x189, new EventFlagLand(0 , 5    , 0393, "ReputaionMyIsland"                          )}, // ゆめみ｜現在の自分の島の評判値
            {0x18C, new EventFlagLand(0 , 9999 , 0396, "LastPlayXmasYear"                           )}, // 最後にプレイしたクリスマスの年
            {0x18D, new EventFlagLand(0 , 1    , 0397, "ShopSelectChristmasFtr"                     )}, // クリスマスおもちゃ家具抽選を今日したか
            {0x18E, new EventFlagLand(0 , 1    , 0398, "IsUploadDisclosedMyDream"                   )}, // ゆめみ|オマカセ公開で初回更新しなかったか？
            {0x18F, new EventFlagLand(0 , 1    , 0399, "TkkFirstLiveNow"                            )}, // とたけけ|初ライブステージか？
            {0x190, new EventFlagLand(0 , 1    , 0400, "ChristmasFtrFirstRound"                     )}, // クリスマス｜おもちゃ家具の商品抽選が1巡したか
            {0x191, new EventFlagLand(0 , 9999 , 0401, "HarvestFestivalAddBbsYear"                  )}, // ハーベストフェスティバル予告の掲示板書き込みをした年
            {0x192, new EventFlagLand(0 , 1    , 0402, "GrowUpAfterPatch1_7"                        )}, // 1.7適用して成長処理をした
            {0x193, new EventFlagLand(0 , 9999 , 0403, "XmasEveAddBbsYear"                          )}, // クリスマス予告の掲示板書き込みをした年
            {0x194, new EventFlagLand(0 , 1    , 0404, "BCAT_EventFlag_005"                         )}, // クリスマス準備期間解禁
            {0x195, new EventFlagLand(0 , -1   , 0405, "RandomKey5"                                 )}, // ランダムキー5
            {0x196, new EventFlagLand(0 , 1    , 0406, "ShopSocksFlag"                              )}, // かべかけソックス当選済み
            {0x197, new EventFlagLand(0 , -1   , 0407, "ShopHeartChocoSelect"                       )}, // ハートのチョコレート抽選済みカラバリ
            {0x198, new EventFlagLand(0 , -1   , 0408, "ShopHeartFlowerSelect"                      )}, // ハートのバラブーケ抽選済みカラバリ
            {0x199, new EventFlagLand(0 , -1   , 0409, "RandomKey6"                                 )}, // ランダムキー6
            {0x19A, new EventFlagLand(0 , -1   , 0410, "RandomKey7"                                 )}, // ランダムキー7
            {0x19B, new EventFlagLand(0 , -1   , 0411, "RandomKey8"                                 )}, // ランダムキー8
            {0x19C, new EventFlagLand(0 , 1    , 0412, "BCAT_EventFlag_006"                         )}, // クリスマスイブ解禁
            {0x19D, new EventFlagLand(0 , 1    , 0413, "BCAT_EventFlag_007"                         )}, // カーニバル本番、バレンタイン本番解禁
            {0x19E, new EventFlagLand(0 , 1    , 0414, "BCAT_EventFlag_008"                         )}, // マリオコラボ解禁
            {0x19F, new EventFlagLand(0 , 1    , 0415, "GrowUpAfterPatch1_8"                        )}, // 1.8適用して成長処理をした
            {0x1A0, new EventFlagLand(0 , 1    , 0416, "GrowUpAfterPatch1_9"                        )}, // 1.9適用して成長処理をした
            {0x1A1, new EventFlagLand(0 , -1   , 0417, "RandomKey9"                                 )}, // ランダムキー9
            {0x1A2, new EventFlagLand(0 , 1    , 0418, "BCAT_EventFlag_009"                         )}, // イースター2年目準備解禁
            {0x1A3, new EventFlagLand(0 , 9999 , 0419, "ValentineAddBbsYear"                        )}, // バレンタイン予告の掲示板書き込みをした年
            {0x1A4, new EventFlagLand(0 , 9999 , 0420, "CarnivalAddBbsYear"                         )}, // カーニバル予告の掲示板書き込みをした年
            {0x1A5, new EventFlagLand(0 , 1    , 0421, "CarnivalNpcFeatherColorDecided"             )}, // カーニバル｜NPCが欲しがる羽の色決定済み
            {0x1A6, new EventFlagLand(0 , 1    , 0422, "CarnivalEventPlazaNpcWander"                )}, // カーニバル｜広場行動NPCがぶらつくか
            {0x1AD, new EventFlagLand(0 , 1    , 0429, "BCAT_EventFlag_010"                         )}, // イースター2年目本番解禁
            {0x1AE, new EventFlagLand(0 , -1   , 0430, "RandomKey10"                                )}, // ランダムキー10
            {0x1B5, new EventFlagLand(0 , 1    , 0437, "AOC_EventFlag_002"                          )}, // AOC同期フラグ| 002 1.9.0NSO加入特典
            {0x1B6, new EventFlagLand(0 , 1    , 0438, "BCAT_EventFlag_011"                         )}, // ジューンブライド2年目解禁
            {0x1B7, new EventFlagLand(0 , -1   , 0439, "RandomKey11"                                )}, // ランダムキー11
            {0x1B8, new EventFlagLand(0 , 50   , 0440, "MuseumArtStampRackLotID1"                   )}, // 国際ミュージアム|1つ目の美術品のスタンプ台ID
            {0x1B9, new EventFlagLand(0 , 50   , 0441, "MuseumArtStampRackLotID2"                   )}, // 国際ミュージアム|2つ目の美術品のスタンプ台ID
            {0x1BA, new EventFlagLand(0 , 50   , 0442, "MuseumArtStampRackLotID3"                   )}, // 国際ミュージアム|3つ目の美術品のスタンプ台ID
            {0x1D2, new EventFlagLand(0 , 1    , 0466, "EventObjFlag1"                              )}, // イベントオブジェフラグ1
            {0x1D3, new EventFlagLand(0 , 1    , 0467, "EventObjFlag2"                              )}, // イベントオブジェフラグ2
            {0x1DD, new EventFlagLand(0 , 1    , 0477, "GrowUpAfterPatch1_10"                       )}, // 1.10適用して成長処理をした
            {0x1E3, new EventFlagLand(0 , 9999 , 0483, "MayDayAddBbsYear"                           )}, // メーデー予告の掲示板書き込みをした年
        };

        private const string Unknown = "???";

        public static string GetName(ushort index, short count, IReadOnlyDictionary<string, string> str)
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

        public static string GetName(ushort index, short count)
        {
            var dict = List;
            if (dict.TryGetValue(index, out var val))
                return $"{index:00} - {val.Name} = {count}";
            return $"{index:00} - {Unknown} = {count}";
        }
    }
}

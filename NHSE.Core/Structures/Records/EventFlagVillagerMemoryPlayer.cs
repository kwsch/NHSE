using System.Collections.Generic;

namespace NHSE.Core
{
    public class EventFlagVillagerMemoryPlayer : INamedValue
    {
        public readonly byte Initial;
        public readonly byte Maximum;

        public ushort Index { get; }
        public string Name { get; }

        public EventFlagVillagerMemoryPlayer(byte init, byte max, ushort index, string name)
        {
            Name = name;
            Index = index;
            Initial = init;
            Maximum = max;
        }

        public static readonly IReadOnlyDictionary<ushort, EventFlagVillagerMemoryPlayer> List = new Dictionary<ushort, EventFlagVillagerMemoryPlayer>
        {
            {0x00, new EventFlagVillagerMemoryPlayer(0 , 1  , 000, "TalkFreeMultiDayEventNow"                   )}, // （ボツ）今、期間型イベント用のFreeFを聞いたか？
            {0x01, new EventFlagVillagerMemoryPlayer(0 , 7  , 001, "ContinuousTalkDays"                         )}, // 何日連続で話しかけられたか
            {0x02, new EventFlagVillagerMemoryPlayer(0 , 1  , 002, "SameLand"                                   )}, // 同じ村に住んでいたことがあるか
            {0x03, new EventFlagVillagerMemoryPlayer(0 , 1  , 003, "SetGreeting"                                )}, // 挨拶を設定したことがある
            {0x04, new EventFlagVillagerMemoryPlayer(0 , 1  , 004, "EasterGetRecipeFlag"                        )}, // イースター|今日このNPCからアイテムを受け取った
            {0x05, new EventFlagVillagerMemoryPlayer(0 , 1  , 005, "TalkProgressMuseumBuilt2"                   )}, // 博物館2への拡張に関するFreeH_Progressを聞いたか？
            {0x06, new EventFlagVillagerMemoryPlayer(0 , 1  , 006, "NextMoveOutTalk"                            )}, // 引越ししたい会話したか
            {0x07, new EventFlagVillagerMemoryPlayer(0 , 1  , 007, "TalkMoveOut"                                )}, // 引越していく状態で会話したか
            {0x08, new EventFlagVillagerMemoryPlayer(0 , 7  , 008, "VisitCount"                                 )}, // そのプレイヤーの家に行った回数
            {0x09, new EventFlagVillagerMemoryPlayer(0 , 7  , 009, "VisitedCount"                               )}, // そのプレイヤーが家に来た回数
            {0x0A, new EventFlagVillagerMemoryPlayer(25, 255, 010, "Friendship"                                 )}, // 親密度
            {0x0B, new EventFlagVillagerMemoryPlayer(0 , 9  , 011, "TalkCountToday"                             )}, // 今日の会話回数（通算）
            {0x0C, new EventFlagVillagerMemoryPlayer(0 , 7  , 012, "TalkCountInNpcHouseToday"                   )}, // 今日NPCの家での会話回数
            {0x0D, new EventFlagVillagerMemoryPlayer(0 , 1  , 013, "HasAcquaintanceship"                        )}, // 面識ありか
            {0x0E, new EventFlagVillagerMemoryPlayer(0 , 1  , 014, "SitBenchFlag"                               )}, // NPCをベンチに座らせる
            {0x0F, new EventFlagVillagerMemoryPlayer(0 , 1  , 015, "TalkInDream"                                )}, // 今回の夢の中への訪問で話をしたか
            {0x10, new EventFlagVillagerMemoryPlayer(0 , 64 , 016, "HalloweenGiveCandyCount"                    )}, // ハロウィン|今日このNPCにアメをあげた回数
            {0x11, new EventFlagVillagerMemoryPlayer(0 , 255, 017, "PastCountFromLastVisitPlayerHouse"          )}, // 最後にP宅を訪問してからの経過日数
            {0x12, new EventFlagVillagerMemoryPlayer(0 , 1  , 018, "TalkedAsSameVillageResident"                )}, // 同じ村の住人として会話した
            {0x13, new EventFlagVillagerMemoryPlayer(0 , 1  , 019, "InputGreeting"                              )}, // 挨拶を設定した
            {0x14, new EventFlagVillagerMemoryPlayer(0 , 1  , 020, "InputPhraseMemory"                          )}, // 口癖を設定した
            {0x15, new EventFlagVillagerMemoryPlayer(0 , 1  , 021, "InputNickname"                              )}, // ニックネームを設定した
            {0x16, new EventFlagVillagerMemoryPlayer(0 , 1  , 022, "GEventTalkBeforeFlag"                       )}, // イベント共通|イベント前に会話した？
            {0x17, new EventFlagVillagerMemoryPlayer(0 , 1  , 023, "GEventTalkProgressFlag"                     )}, // イベント共通|イベント中に会話した？
            {0x18, new EventFlagVillagerMemoryPlayer(0 , 1  , 024, "GEventTalkAfterFlag"                        )}, // イベント共通|イベント後に会話した？
            {0x19, new EventFlagVillagerMemoryPlayer(0 , 1  , 025, "InduceFailFlag"                             )}, // 勧誘失敗フラグ
            {0x1A, new EventFlagVillagerMemoryPlayer(0 , 1  , 026, "InduceFailAlreadyInduced"                   )}, // 勧誘失敗理由|既に転入枠に勧誘されたNPCがいる
            {0x1B, new EventFlagVillagerMemoryPlayer(0 , 1  , 027, "InduceFailSameNpcLiving"                    )}, // 勧誘失敗理由|同名NPCが村に住んでいる
            {0x1C, new EventFlagVillagerMemoryPlayer(0 , 1  , 028, "InduceFailSameNpcMoveIn"                    )}, // 勧誘失敗理由|同名NPCが転入確定状態
            {0x1D, new EventFlagVillagerMemoryPlayer(0 , 1  , 029, "IsReceiptWrappingItem"                      )}, // プレゼントできるアイテムを受け取った
            {0x1E, new EventFlagVillagerMemoryPlayer(0 , 1  , 030, "BirhdayNPresentFlag"                        )}, // NPC誕生日|プレゼント渡した？
            {0x1F, new EventFlagVillagerMemoryPlayer(0 , 1  , 031, "NicknameOriginal"                           )}, // ニックネーム設定本人
            {0x20, new EventFlagVillagerMemoryPlayer(0 , 1  , 032, "BirhdayNTalkInFlag"                         )}, // NPC誕生日|家に入ったときの会話した？
            {0x21, new EventFlagVillagerMemoryPlayer(0 , 1  , 033, "BirhdayNTalkFlag"                           )}, // NPC誕生日|誕生会で会話した？
            {0x22, new EventFlagVillagerMemoryPlayer(0 , 1  , 034, "BirhdayNTalkOutFlag"                        )}, // NPC誕生日|家から出たときの会話した？
            {0x23, new EventFlagVillagerMemoryPlayer(0 , 1  , 035, "BirhdayPTalkFlag"                           )}, // プレイヤ誕生日|おめでとう会話した？
            {0x24, new EventFlagVillagerMemoryPlayer(0 , 1  , 036, "BirhdayPCupcakeFlag"                        )}, // プレイヤ誕生日|カップケーキ渡した？
            {0x25, new EventFlagVillagerMemoryPlayer(0 , 1  , 037, "FriendOfHostPC"                             )}, // ホストPCのフレンドとして訪問した
            {0x26, new EventFlagVillagerMemoryPlayer(0 , 1  , 038, "TalkClothesPToday"                          )}, // 今日ClothesPを見たか？ 
            {0x27, new EventFlagVillagerMemoryPlayer(0 , 1  , 039, "TalkedDuringSick"                           )}, // 病気中に会話した
            {0x28, new EventFlagVillagerMemoryPlayer(0 , 1  , 040, "InduceFailVillagerMax"                      )}, // 勧誘失敗理由|住人数が既に上限
            {0x29, new EventFlagVillagerMemoryPlayer(0 , 1  , 041, "FirstMeetGreetAtThisVillage"                )}, // この村で初対面の挨拶をした
            {0x2A, new EventFlagVillagerMemoryPlayer(0 , 1  , 042, "MoveCancelTalk"                             )}, // 引越し中止の報告したか
            {0x2B, new EventFlagVillagerMemoryPlayer(0 , 1  , 043, "BirthdayPAttendance"                        )}, // プレイヤ誕生日|出席していた
            {0x2C, new EventFlagVillagerMemoryPlayer(0 , 255, 044, "TalkCountInHouseToday"                      )}, // 室内で会話した回数 （訪問クエスト中）
            {0x2D, new EventFlagVillagerMemoryPlayer(0 , 1  , 045, "TalkClothesNToday"                          )}, // 今日ClothesNを見たか？ 
            {0x2E, new EventFlagVillagerMemoryPlayer(0 , 1  , 046, "TalkWantToday"                              )}, // 今日Wantを聞いたか？
            {0x2F, new EventFlagVillagerMemoryPlayer(0 , 1  , 047, "InduceFailSellPlaceNothing"                 )}, // 勧誘失敗理由|売り土地が無い
            {0x30, new EventFlagVillagerMemoryPlayer(0 , 1  , 048, "IsPlayedQuestVisitN"                        )}, // 訪問Nをクリアした事ある？ 
            {0x31, new EventFlagVillagerMemoryPlayer(0 , 1  , 049, "AcquaintanceshipFlagOff"                    )}, // 面識フラグを立てない 
            {0x32, new EventFlagVillagerMemoryPlayer(0 , 1  , 050, "InducementAtMovingDay"                      )}, // 転出当日に勧誘された
            {0x33, new EventFlagVillagerMemoryPlayer(0 , 1  , 051, "ChokeOffMoveOut"                            )}, // 引越を引き止められた
            {0x34, new EventFlagVillagerMemoryPlayer(0 , 1  , 052, "InducementFlag"                             )}, // 勧誘されて来たか
            {0x35, new EventFlagVillagerMemoryPlayer(0 , 1  , 053, "ApproachQuestOrdered"                       )}, // アプローチ経由でのクエスト発注か？ 
            {0x37, new EventFlagVillagerMemoryPlayer(0 , 255, 055, "ContinuousTalkCount"                        )}, // 連続会話回数
            {0x38, new EventFlagVillagerMemoryPlayer(0 , 255, 056, "Again2Count"                                )}, // XX_Again2を聞いた回数
            {0x39, new EventFlagVillagerMemoryPlayer(0 , 1  , 057, "TalkDIY"                                    )}, // DIY会話をした
            {0x3A, new EventFlagVillagerMemoryPlayer(0 , 2  , 058, "HalloweenDIYGetItem"                        )}, // ハロウィン|DIYしている時の報酬アイテムは？
            {0x3B, new EventFlagVillagerMemoryPlayer(0 , 1  , 059, "NewYearGreetingFlag"                        )}, // 新年（1月1日）のあいさつをした
            {0x3C, new EventFlagVillagerMemoryPlayer(0 , 1  , 060, "GotRecipeorMaterial"                        )}, // DIYレシピか素材をもらった
            {0x3D, new EventFlagVillagerMemoryPlayer(0 , 1  , 061, "GotMaterialItemFull"                        )}, // 素材をもらうときもちものがいっぱいだった
            {0x3E, new EventFlagVillagerMemoryPlayer(0 , 1  , 062, "MailedVisitPLayout"                         )}, // 訪問Pで手紙を投函した
            {0x3F, new EventFlagVillagerMemoryPlayer(0 , 1  , 063, "FirstMeetGreetAtThisVillageToday"           )}, // この村で初対面の挨拶をした当日
            {0x40, new EventFlagVillagerMemoryPlayer(0 , 1  , 064, "ReceivedFirstPresent"                       )}, // NPCから初めてPresentを貰った 
            {0x41, new EventFlagVillagerMemoryPlayer(0 , 1  , 065, "BanClothesN1Today"                          )}, // ClothesN1:今日は禁止
            {0x42, new EventFlagVillagerMemoryPlayer(0 , 1  , 066, "BanClothesN2Now"                            )}, // ClothesN2:今は禁止
            {0x43, new EventFlagVillagerMemoryPlayer(0 , 1  , 067, "BanClothesN1Now"                            )}, // ClothesN1:今は禁止
            {0x44, new EventFlagVillagerMemoryPlayer(0 , 1  , 068, "TalkWeekNow"                                )}, // 今、Weekを聞いたか？
            {0x45, new EventFlagVillagerMemoryPlayer(0 , 1  , 069, "TalkQuestionsNow"                           )}, // 今、Questionsを聞いたか？
            {0x46, new EventFlagVillagerMemoryPlayer(0 , 1  , 070, "TalkAlwaysNow"                              )}, // 今、Alwaysを聞いたか？
            {0x47, new EventFlagVillagerMemoryPlayer(0 , 1  , 071, "TalkAlwaysABNow"                            )}, // 今、AlwaysABを聞いたか？
            {0x48, new EventFlagVillagerMemoryPlayer(0 , 1  , 072, "TalkWeatherSPNow"                           )}, // 今、WeatherSPを聞いたか？
            {0x49, new EventFlagVillagerMemoryPlayer(0 , 1  , 073, "TalkWeatherNow"                             )}, // 今、Weatherを聞いたか？
            {0x4A, new EventFlagVillagerMemoryPlayer(0 , 1  , 074, "TalkSeasonsNow"                             )}, // 今、Seasonsを聞いたか？
            {0x4B, new EventFlagVillagerMemoryPlayer(0 , 1  , 075, "TalkSpotSPNow"                              )}, // 今、SpotSPを聞いたか？
            {0x4C, new EventFlagVillagerMemoryPlayer(0 , 1  , 076, "TalkSpotNow"                                )}, // 今、Spotを聞いたか？
            {0x4E, new EventFlagVillagerMemoryPlayer(0 , 1  , 078, "TalkItemNNow"                               )}, // 今、ItemNを聞いたか？
            {0x4F, new EventFlagVillagerMemoryPlayer(0 , 1  , 079, "TalkItemPNow"                               )}, // 今、ItemPを聞いたか？
            {0x50, new EventFlagVillagerMemoryPlayer(0 , 1  , 080, "TalkRumorOActionToday"                      )}, // （ボツ）今日RumorOP_Action（同じ島の住人P）を聞いたか？
            {0x51, new EventFlagVillagerMemoryPlayer(0 , 1  , 081, "TalkRumorVActionToday"                      )}, // 今日RumorOP_Action（ビジター）を聞いたか？
            {0x52, new EventFlagVillagerMemoryPlayer(0 , 1  , 082, "TalkRumorOFavoriteToday"                    )}, // 今日RumorO_Favoriteを聞いたか？
            {0x53, new EventFlagVillagerMemoryPlayer(0 , 1  , 083, "TalkRumorNToday"                            )}, // 今日このNPCからRumorN1を聞いたか？
            {0x54, new EventFlagVillagerMemoryPlayer(0 , 1  , 084, "TalkFreeMovingNow"                          )}, // 今、FreeD_Movingを聞いたか？
            {0x55, new EventFlagVillagerMemoryPlayer(0 , 1  , 085, "TalkFreeEventNow"                           )}, // 今日FreeE_Eventを聞いたか？
            {0x56, new EventFlagVillagerMemoryPlayer(0 , 1  , 086, "TalkSnpcNow"                                )}, // 今日Snpcを聞いたか？
            {0x57, new EventFlagVillagerMemoryPlayer(0 , 1  , 087, "TalkFreeFNow"                               )}, // 今、FreeFを聞いたか？
            {0x58, new EventFlagVillagerMemoryPlayer(0 , 1  , 088, "TalkFreeGNow"                               )}, // 今、FreeGを聞いたか？
            {0x59, new EventFlagVillagerMemoryPlayer(0 , 1  , 089, "FireworksCannotGetNnpcItemFlag"             )}, // 花火大会|このNPCから受け取り損ねたアイテムがある？
            {0x5A, new EventFlagVillagerMemoryPlayer(0 , 1  , 090, "TalkHHAToday"                               )}, // 今日FreeE_HHAを聞いたか？ 
            {0x5B, new EventFlagVillagerMemoryPlayer(0 , 5  , 091, "TalkReSelectLast"                           )}, // 再抽選前に聞いたファイル識別番号
            {0x5C, new EventFlagVillagerMemoryPlayer(0 , 1  , 092, "HHABuildCelebraition"                       )}, // 増築祝いの手紙を出した
            {0x5D, new EventFlagVillagerMemoryPlayer(0 , 1  , 093, "ChineseNewYearGreetingFlag"                 )}, // 旧正月のあいさつをした
            {0x5E, new EventFlagVillagerMemoryPlayer(0 , 1  , 094, "TalkFreeZodiacNow"                          )}, // 今、FreeF_NewYear_Zodiacを聞いたか？
            {0x5F, new EventFlagVillagerMemoryPlayer(0 , 1  , 095, "TalkProgressNpcHouseBuilt"                  )}, // 初期NPCの家に関するFreeH_Progressを聞いたか？
            {0x60, new EventFlagVillagerMemoryPlayer(0 , 1  , 096, "TalkProgressMyHouseBuilt"                   )}, // 現在プレイヤーの家に関するFreeH_Progressを聞いたか？
            {0x61, new EventFlagVillagerMemoryPlayer(0 , 1  , 097, "TalkProgressMyHouseBuilt2"                  )}, // 現在プレイヤーの家（地下室完成）に関するFreeH_Progressを聞いたか？
            {0x62, new EventFlagVillagerMemoryPlayer(0 , 1  , 098, "TalkProgressMigrantsQuest"                  )}, // 移住クエストに関するFreeH_Progressを聞いたか？
            {0x63, new EventFlagVillagerMemoryPlayer(0 , 1  , 099, "TalkProgressHelpBuildShop"                  )}, // 商店の木材集めに関するFreeH_Progressを聞いたか？
            {0x64, new EventFlagVillagerMemoryPlayer(0 , 1  , 100, "TalkProgressOfficeBuilt"                    )}, // 案内所の完成に関するFreeH_Progressを聞いたか？
            {0x65, new EventFlagVillagerMemoryPlayer(0 , 1  , 101, "TalkProgressShopBuilt"                      )}, // 商店の完成に関するFreeH_Progressを聞いたか？
            {0x66, new EventFlagVillagerMemoryPlayer(0 , 1  , 102, "TalkProgressShopBuilt2"                     )}, // 商店の拡張に関するFreeH_Progressを聞いたか？
            {0x67, new EventFlagVillagerMemoryPlayer(0 , 1  , 103, "TalkProgressMuseumTent"                     )}, // フータのテントに関するFreeH_Progressを聞いたか？
            {0x68, new EventFlagVillagerMemoryPlayer(0 , 1  , 104, "TalkProgressMuseumBuilt"                    )}, // 博物館の完成に関するFreeH_Progressを聞いたか？
            {0x69, new EventFlagVillagerMemoryPlayer(0 , 1  , 105, "TalkProgressTailorBuilt"                    )}, // 仕立て屋の完成に関するFreeH_Progressを聞いたか？
            {0x6A, new EventFlagVillagerMemoryPlayer(0 , 1  , 106, "TalkProgressBridgeBuilt"                    )}, // 初めての橋の完成に関するFreeH_Progressを聞いたか？
            {0x6B, new EventFlagVillagerMemoryPlayer(0 , 1  , 107, "TalkProgressSlopeBuilt"                     )}, // 初めての坂の完成に関するFreeH_Progressを聞いたか？
            {0x6C, new EventFlagVillagerMemoryPlayer(0 , 1  , 108, "TalkProgressOtherPlayerMoveIn"              )}, // 他プレイヤーの移住に関するFreeH_Progressを聞いたか？
            {0x6D, new EventFlagVillagerMemoryPlayer(0 , 1  , 109, "TalkRumorPActionToday"                      )}, // （ボツ）今日RumorP_Action（現在プレイヤー）を聞いたか？
            {0x6E, new EventFlagVillagerMemoryPlayer(0 , 1  , 110, "FirstNpcEarlyAcquaintanceFlag"              )}, // NPC宅がテントだった頃からの知り合い？
            {0x6F, new EventFlagVillagerMemoryPlayer(0 , 1  , 111, "TalkSickCured"                              )}, // Curedを聞いたか？
            {0x70, new EventFlagVillagerMemoryPlayer(0 , 1  , 112, "StandingUpFlag"                             )}, // NPCを立たせる
            {0x71, new EventFlagVillagerMemoryPlayer(0 , 1  , 113, "StoodUpFlag"                                )}, // NPCが立った
            {0x72, new EventFlagVillagerMemoryPlayer(0 , 1  , 114, "TalkBeefaceToday"                           )}, // 今日BeeFaceを聞いたか？
            {0x73, new EventFlagVillagerMemoryPlayer(0 , 1  , 115, "TalkItchingToday"                           )}, // 今日Itchingを聞いたか？
            {0x74, new EventFlagVillagerMemoryPlayer(0 , 1  , 116, "TalkEarlyLateToday"                         )}, // 今日EarlyLateを聞いたか？
            {0x75, new EventFlagVillagerMemoryPlayer(0 , 1  , 117, "FinishVisitPToday"                          )}, // 今日訪問Pクエストをしたか？
            {0x76, new EventFlagVillagerMemoryPlayer(0 , 1  , 118, "FinishVisitNToday"                          )}, // 今日訪問Nクエストをしたか？
            {0x77, new EventFlagVillagerMemoryPlayer(0 , 1  , 119, "OrderQuest"                                 )}, // クエストを発注or達成した
            {0x78, new EventFlagVillagerMemoryPlayer(0 , 1  , 120, "FirstGreetingAtNpcHome"                     )}, // 引越し当日のダンボール自宅でNPCと初対面会話をした(自分の村)
            {0x79, new EventFlagVillagerMemoryPlayer(0 , 1  , 121, "AppF_MoveinGiftOccured"                     )}, // 引越し挨拶アプローチ会話発生済か？
            {0x7A, new EventFlagVillagerMemoryPlayer(0 , 1  , 122, "UncollectedFishishTreasureHunt"             )}, // 宝未回収でクエスト終了した
            {0x7B, new EventFlagVillagerMemoryPlayer(0 , 7  , 123, "TalkCountInFacilityToday"                   )}, // 今日の会話回数（施設用）
            {0x7C, new EventFlagVillagerMemoryPlayer(0 , 1  , 124, "FriendshipBecomeAcqHToday"                  )}, // 今日親密度が知人（高）に到達した
            {0x7D, new EventFlagVillagerMemoryPlayer(0 , 1  , 125, "FriendshipBecomeAcqH"                       )}, // 親密度が知人（高）に到達済み
            {0x7E, new EventFlagVillagerMemoryPlayer(0 , 3  , 126, "DC_NPCBirthdayFlag"                         )}, // NPC誕生日|おでかけ先の村でもらうお返しの種類
            {0x7F, new EventFlagVillagerMemoryPlayer(0 , 1  , 127, "EasterCannotGetNnpcRecipeFlag"              )}, // イースター|このNPCから受け取り損ねたアイテムがある？
            {0x81, new EventFlagVillagerMemoryPlayer(0 , 1  , 129, "HalloweenTerrifyFlag"                       )}, // ハロウィン|今日パンプキングの恰好で脅かした？
            {0x82, new EventFlagVillagerMemoryPlayer(0 , 1  , 130, "HalloweenGetCandyFlag"                      )}, // ハロウィン|今日このNPCからアメもらった？
            {0x83, new EventFlagVillagerMemoryPlayer(0 , 1  , 131, "FireworksGetItemFlag"                       )}, // 花火大会|このNPCからリアクション会話で花火を受け取った
            {0x84, new EventFlagVillagerMemoryPlayer(0 , 1  , 132, "HaloweenTalkThisSceneFalg"                  )}, // ハロウィン|このシーンで会話した？
            {0x85, new EventFlagVillagerMemoryPlayer(0 , 1  , 133, "HaloweenGetCandyThisSceneFalg"              )}, // ハロウィン|このシーンでアメもらった？
            {0x88, new EventFlagVillagerMemoryPlayer(0 , 1  , 136, "HalloweenLastNotGetFlag"                    )}, // ハロウィン|最後の会話で報酬アイテムもらえなかった？
            {0x89, new EventFlagVillagerMemoryPlayer(0 , 16 , 137, "HalloweenLastNotGetItem"                    )}, // ハロウィン|最後の会話でもらえなかった報酬アイテム
            {0x8A, new EventFlagVillagerMemoryPlayer(0 , 1  , 138, "HarvestItemExchangeToday"                   )}, // ハーベスト｜物々交換を１度でも行ったか？
            {0x8B, new EventFlagVillagerMemoryPlayer(0 , 1  , 139, "ChristmasSantaPresentsFlag"                 )}, // サンタミッションのプレゼントを受け取ったか？
            {0x8C, new EventFlagVillagerMemoryPlayer(0 , 1  , 140, "ChristmasSantaPresentsNoGetFlag"            )}, // サンタミッションのお返しが持ち物一杯で受け取れなかった？
            {0x8D, new EventFlagVillagerMemoryPlayer(0 , 1  , 141, "ChristmasSantaPresentsReturnFlag"           )}, // サンタミッションでプレゼント渡したらお返しくれたか？
            {0x8E, new EventFlagVillagerMemoryPlayer(0 , 1  , 142, "ChristmasGiftExchangeFlag"                  )}, // そのNPCとプレゼント交換をしたか？
            {0x8F, new EventFlagVillagerMemoryPlayer(0 , 8  , 143, "ChristmasExchangeItemType"                  )}, // クリスマス｜プレゼント交換であげたプレゼントの種類
            {0x90, new EventFlagVillagerMemoryPlayer(0 , 1  , 144, "ChristmasCosJudgeFlag"                      )}, // イブにサンタの恰好をしているか？
            {0x91, new EventFlagVillagerMemoryPlayer(0 , 1  , 145, "ChristmasCannotGetNnpcItemFlag"             )}, // クリスマス|このNPCから受け取り損ねたアイテムがある？
            {0x92, new EventFlagVillagerMemoryPlayer(0 , 1  , 146, "ChristmasAfterMesFlag"                      )}, // クリスマス（25日）に専用会話を聞いた？
            {0x93, new EventFlagVillagerMemoryPlayer(0 , 1  , 147, "ChristmasWrappingGiftNoGetFlag"             )}, // クリスマス|持ち物一杯でラッピングペーパーを受け取り損ねた？
            {0x94, new EventFlagVillagerMemoryPlayer(0 , 8  , 148, "ChristmasSantaPresentItemType"              )}, // クリスマス｜サンタミッションであげたプレゼントの種類
            {0x95, new EventFlagVillagerMemoryPlayer(0 , 8  , 149, "ChristmasExchangeRemakeId"                  )}, // クリスマス｜プレゼント交換であげたプレゼントのリメイクID
            {0x96, new EventFlagVillagerMemoryPlayer(0 , 8  , 150, "ChristmasSantaPresentRemakeId"              )}, // クリスマス｜サンタミッションであげたプレゼントのリメイクID
            {0x97, new EventFlagVillagerMemoryPlayer(0 , 1  , 151, "CarnvalTalkWithoutFeatherFlag"              )}, // 一般NPC/カーニバル|はねを持たずに会話した？
            {0x98, new EventFlagVillagerMemoryPlayer(0 , 1  , 152, "CarnvalExchangeFeatherFlag"                 )}, // 一般NPC/カーニバル|このNPCとはね交換した？
            {0x99, new EventFlagVillagerMemoryPlayer(0 , 1  , 153, "CarnvalTalkOutdoorFlag"                     )}, // 一般NPC/カーニバル|今日屋外で会話した？
            {0x9A, new EventFlagVillagerMemoryPlayer(0 , 1  , 154, "CarnvalExchangeFeatherTalkFlag"             )}, // 一般NPC/カーニバル|このNPCとはね交換の会話をした？
            {0x9B, new EventFlagVillagerMemoryPlayer(0 , 1  , 155, "ValentinePresentFlag"                       )}, // バレンタイン|バレンタインのプレゼント渡した？
            {0x9C, new EventFlagVillagerMemoryPlayer(0 , 1  , 156, "EasterTalkOutdoorFlag"                      )}, // 一般NPC/イースター|今日屋外で会話した？
            {0x9D, new EventFlagVillagerMemoryPlayer(0 , 1  , 157, "EasterExchangeEggFlag"                      )}, // 一般NPC/イースターこのNPCとたまご交換した？
            {0x9E, new EventFlagVillagerMemoryPlayer(0 , 1  , 158, "EasterExchangeEggTalkFlag"                  )}, // 一般NPC/イースター|このNPCとたまご交換の会話をした？
            {0x9F, new EventFlagVillagerMemoryPlayer(0 , 1  , 159, "EasterCannotGetNnpcIsRecipeFlag"            )}, // イースター|このNPCから受け取り損ねたのはレシピか
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

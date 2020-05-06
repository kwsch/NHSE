using System.Collections.Generic;

namespace NHSE.Core
{
    public class LifeSupportAchievement : INamedValue
    {
        public readonly short FlagLand;
        public readonly short FlagPlayer;

        public ushort Index { get; }
        public string Name { get; }

        public LifeSupportAchievement(short land, short player, ushort index, string name)
        {
            Name = name;
            Index = index;
            FlagLand = land;
            FlagPlayer = player;
        }

        private const string Unknown = "???";

        public static readonly IReadOnlyDictionary<int, LifeSupportAchievement> List = new Dictionary<int, LifeSupportAchievement>
        {
            {0x000, new LifeSupportAchievement( 3,   -1, 0000, "CatchFish"                   )}, // サカナを釣った
            {0x001, new LifeSupportAchievement( 3,   -1, 0001, "CatchInsect"                 )}, // ムシを捕まえた
            {0x002, new LifeSupportAchievement(-1,   -1, 0002, "CatchFishContinuously"       )}, // 連続で釣りを成功させた回数の最高記録
            {0x003, new LifeSupportAchievement(-1,   -1, 0003, "FillFishList"                )}, // サカナ図鑑を埋めた
            {0x004, new LifeSupportAchievement(-1,   -1, 0004, "FillInsectList"              )}, // ムシ図鑑を埋めた
            {0x005, new LifeSupportAchievement(-1,   -1, 0005, "ShootDownBalloon"            )}, // ふうせんを撃ち落とした
            {0x006, new LifeSupportAchievement( 3,   -1, 0006, "PlantFlowerSeed"             )}, // 花の種を植えた
            {0x007, new LifeSupportAchievement(-1,   -1, 0007, "PlantFruit"                  )}, // 6種類のフルーツを植えた
            {0x008, new LifeSupportAchievement(-1,   -1, 0008, "PlantTreeSeedling"           )}, // 木の苗を植えた
            {0x009, new LifeSupportAchievement(-1,   -1, 0009, "BuyKabu"                     )}, // カブを買った
            {0x00A, new LifeSupportAchievement(-1,   -1, 0010, "HowmuchSellKabu"             )}, // カブで得た累計利益
            {0x00B, new LifeSupportAchievement(-1,   -1, 0011, "HowmuchBuyItem"              )}, // これまでの買い物総額
            {0x00C, new LifeSupportAchievement(-1,   -1, 0012, "BuyItemRcm"                  )}, // まめきちの店で買い物した
            {0x00D, new LifeSupportAchievement(-1,   -1, 0013, "SellItemRcm"                 )}, // まめきちの店で売った
            {0x00E, new LifeSupportAchievement(-1,   -1, 0014, "RemakeFurniture"             )}, // リメイクをした
            {0x00F, new LifeSupportAchievement(-1,   -1, 0015, "FillCatalog"                 )}, // カタログの項目数
            {0x010, new LifeSupportAchievement(-1,   -1, 0016, "BuyItemCatalog"              )}, // 通販を利用した
            {0x011, new LifeSupportAchievement(-1,   -1, 0017, "GotoTotakekeShow"            )}, // とたけけのライブを観た
            {0x012, new LifeSupportAchievement(-1,   -1, 0018, "VisitAnotherIsland"          )}, // よその島へのおでかけした
            {0x013, new LifeSupportAchievement(-1,   -1, 0019, "InviteFriend"                )}, // 島にフレンドを招いた
            {0x015, new LifeSupportAchievement(-1,   -1, 0021, "DayPlayed"                   )}, // 活動日数
            {0x017, new LifeSupportAchievement(-1,   -1, 0023, "WaterPlant"                  )}, // 水やりをした
            {0x018, new LifeSupportAchievement(-1,   -1, 0024, "BeStungbyWasp"               )}, // ハチに刺された
            {0x019, new LifeSupportAchievement(-1,   -1, 0025, "CatchSeminonukegara"         )}, // セミのぬけがらを取った
            {0x01A, new LifeSupportAchievement(-1,   -1, 0026, "CatchNomi"                   )}, // ノミを取ってあげた
            {0x01B, new LifeSupportAchievement(-1,   -1, 0027, "BeStungbyPoisonousInsect"    )}, // こわいムシで気絶した
            {0x01F, new LifeSupportAchievement(-1,   -1, 0031, "FillReactionList"            )}, // リアクションを覚えた
            {0x020, new LifeSupportAchievement(-1,   -1, 0032, "CatchTrash"                  )}, // ゴミを釣った
            {0x021, new LifeSupportAchievement(-1,   -1, 0033, "PayImmigrationCost"          )}, // 移住費用を支払った
            {0x022, new LifeSupportAchievement(-1,   -1, 0034, "RepayLoan"                   )}, // ローンを完済した
            {0x023, new LifeSupportAchievement( 3,   -1, 0035, "UseMydesign"                 )}, // マイデザインを使った
            {0x024, new LifeSupportAchievement(-1,   -1, 0036, "UseMydesignPRO"              )}, // マイデザインPROを使った
            {0x025, new LifeSupportAchievement(-1,   -1, 0037, "SellWeed"                    )}, // 雑草を引き取ってもらった
            {0x027, new LifeSupportAchievement(-1,   -1, 0039, "CollectGoldTool"             )}, // 6種類の金の道具を集めた
            {0x028, new LifeSupportAchievement(-1,   -1, 0040, "GetSRankonHHA"               )}, // HHAでSを取った
            {0x029, new LifeSupportAchievement(-1,   -1, 0041, "AttendFishingConvention"     )}, // 釣り大会に春夏秋冬参加した
            {0x02A, new LifeSupportAchievement(-1,   -1, 0042, "AttendInsectConvention"      )}, // ムシとり大会に6～9月参加した
            {0x02B, new LifeSupportAchievement(-1,   -1, 0043, "HelpGul"                     )}, // ジョニーを助けた
            {0x02C, new LifeSupportAchievement(-1,   -1, 0044, "HelpGst"                     )}, // ゆうたろうを助けた
            {0x02D, new LifeSupportAchievement(-1,   -1, 0045, "MakePerfectSnowball"         )}, // 最高のゆきだるまを作った
            {0x02E, new LifeSupportAchievement(-1,   -1, 0046, "ReachMyBirthday"             )}, // 誕生日を迎えた
            {0x02F, new LifeSupportAchievement(-1,   -1, 0047, "CelebrateVillagersBithday"   )}, // 村民の誕生日を祝ってあげた
            {0x030, new LifeSupportAchievement(-1,   -1, 0048, "AttendCountdownParty"        )}, // カウントダウンに参加した
            {0x031, new LifeSupportAchievement(-1,   -1, 0049, "BreakTool"                   )}, // 道具を壊した
            {0x032, new LifeSupportAchievement(-1,   -1, 0050, "SendLetter"                  )}, // 手紙を送った
            {0x033, new LifeSupportAchievement(-1,   -1, 0051, "MakePitfall"                 )}, // 落とし穴を作った
            {0x034, new LifeSupportAchievement(-1,   -1, 0052, "FallintoPitfall"             )}, // 落とし穴に落ちた
            {0x035, new LifeSupportAchievement(-1,   -1, 0053, "ImmigratetoIsland"           )}, // 島に移住した
            {0x036, new LifeSupportAchievement(-1,   -1, 0054, "BeFriendwithVillager"        )}, // どうぶつとなかよしになった
            {0x037, new LifeSupportAchievement(-1,   -1, 0055, "FillRecipeList"              )}, // 集めたレシピの数
            {0x038, new LifeSupportAchievement(-1,   -1, 0056, "BootPhone"                   )}, // スマホを起動した(上級)
            {0x039, new LifeSupportAchievement(-1,   -1, 0057, "StrikeRock8Times"            )}, // コイン岩を8連打した
            {0x03A, new LifeSupportAchievement(-1,  320, 0058, "AchieveAppQuest"             )}, // 村活クエストを達成した
            {0x03B, new LifeSupportAchievement(-1,   -1, 0059, "AchieveVillagersQuest"       )}, // どうぶつのお願いを聞いた
            {0x03C, new LifeSupportAchievement(-1,   -1, 0060, "DigBell"                     )}, // ベルを掘り出した
            {0x03D, new LifeSupportAchievement(-1,   -1, 0061, "DigFossil"                   )}, // 化石を掘り出した
            {0x03E, new LifeSupportAchievement(-1,   -1, 0062, "JudgeFossil"                 )}, // 化石を鑑定した
            {0x03F, new LifeSupportAchievement(66,   -1, 0063, "DigShell"                    )}, // 潮干狩りをした
            {0x040, new LifeSupportAchievement( 3,   -1, 0064, "PutFurnitureOutside"         )}, // 外に家具を置いた
            {0x043, new LifeSupportAchievement(-1,   -1, 0067, "StrikeWood"                  )}, // 木からもくざいを出した
            {0x044, new LifeSupportAchievement( 3,   -1, 0068, "GreetAllVillager"            )}, // 村民全員とあいさつをした
            {0x045, new LifeSupportAchievement( 3,   -1, 0069, "SellShell"                   )}, // 貝殻を売った
            {0x046, new LifeSupportAchievement( 3,   -1, 0070, "SellFruit"                   )}, // フルーツを売った
            {0x047, new LifeSupportAchievement(-1,   -1, 0071, "CatchBeeContinuously"        )}, // ハチを5連続捕まえた
            {0x048, new LifeSupportAchievement(-1,   -1, 0072, "DIYTool"                     )}, // 道具をDIYした
            {0x049, new LifeSupportAchievement(-1,   -1, 0073, "DIYFurniture"                )}, // 家具をDIYした
            {0x04B, new LifeSupportAchievement( 3,   -1, 0075, "TakePicture"                 )}, // カメラで写真を撮った
            {0x04C, new LifeSupportAchievement(-1,   -1, 0076, "BootPhoneBeginner"           )}, // スマホを起動した(初級)
            {0x04D, new LifeSupportAchievement(-1,   -1, 0077, "HouseStorageItem"            )}, // 家の倉庫に収納したアイテムの数
            {0x04E, new LifeSupportAchievement(-1,   -1, 0078, "PlaceFurnitureMyHouse"       )}, // 家に飾っている家具の数
            {0x04F, new LifeSupportAchievement(-1,   -1, 0079, "FallFurnitureLeaf"           )}, // 木を揺すって家具（葉っぱ）を落とした回数
            {0x050, new LifeSupportAchievement(-1,   -1, 0080, "DropPresentinWater"          )}, // 風船のプレゼントを撃ち水の中に落とした
            {0x051, new LifeSupportAchievement(-1,   -1, 0081, "ReformMyHome"                )}, // マイホームをリフォームした
            {0x052, new LifeSupportAchievement(-1,   -1, 0082, "ExtendMyHome"                )}, // マイホームを増築した
            {0x053, new LifeSupportAchievement( 3,   -1, 0083, "PostMessageBoard"            )}, // 自分の島の掲示板に書き込む
            {0x054, new LifeSupportAchievement(-1,   -1, 0084, "UseCloset"                   )}, // クローゼットで着替える
            {0x055, new LifeSupportAchievement(-1,   -1, 0085, "PrayShootingStar"            )}, // 流れ星に祈る
            {0x056, new LifeSupportAchievement(59,   -1, 0086, "ChangeSymbol"                )}, // 島の旗、島メロを変える
            {0x057, new LifeSupportAchievement( 3,   -1, 0087, "UpdatePassport"              )}, // パスポートを更新した
            {0x058, new LifeSupportAchievement(-1,  513, 0088, "ModifyIsland"                )}, // 各地形造成をやってみた
            {0x059, new LifeSupportAchievement(-1,  478, 0089, "BuildFence"                  )}, // 柵を置く
            {0x05A, new LifeSupportAchievement(-1,   -1, 0090, "DonateFake"                  )}, // 寄贈しようとした美術品が贋作だった
            {0x05B, new LifeSupportAchievement(-1,   -1, 0091, "BuyatTsunekichiShop"         )}, // いなりマーケットで芸術品を買った
            {0x05C, new LifeSupportAchievement(-1,   -1, 0092, "PlantBushSeedling"           )}, // 各種低木の苗を植えた
        };

        public static string GetName(int index, uint count, IReadOnlyDictionary<string, string> str)
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

        public static string GetName(int index, uint count)
        {
            var dict = List;
            if (dict.TryGetValue(index, out var val))
                return $"{index:00} - {val.Name} = {count}";
            return $"{index:00} - {Unknown} = {count}";
        }
    }
}

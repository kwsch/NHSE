using System;
using System.Collections.Generic;

namespace NHSE.Core
{
    /// <summary>
    /// Multi-milestone definition for tracking game-play achievements.
    /// </summary>
    public class LifeSupportAchievement : INamedValue
    {
        /// <summary>
        /// Amount of milestones an achievement can have.
        /// </summary>
        public const int MilestoneMax = 6;

        public readonly short FlagLand;
        public readonly short FlagPlayer;

        public ushort Index { get; }
        public string Name { get; }

        /// <summary> Total number of milestones for this achievement type. </summary>
        public readonly int AchievementCount;

        /// <summary> First Milestone's Satisfaction Threshold </summary>
        public readonly uint Threshold1;

        /// <summary> Second Milestone's Satisfaction Threshold </summary>
        public readonly uint Threshold2;

        /// <summary> Third Milestone's Satisfaction Threshold </summary>
        public readonly uint Threshold3;

        /// <summary> Fourth Milestone's Satisfaction Threshold </summary>
        public readonly uint Threshold4;

        /// <summary> Fifth Milestone's Satisfaction Threshold </summary>
        public readonly uint Threshold5;

        public LifeSupportAchievement(ushort index, byte max, uint t1, uint t2, uint t3, uint t4, uint t5, short land, short player, string name)
        {
            Index = index;
            AchievementCount = max;
            Threshold1 = t1;
            Threshold2 = t2;
            Threshold3 = t3;
            Threshold4 = t4;
            Threshold5 = t5;
            FlagLand = land;
            FlagPlayer = player;
            Name = name;
        }

        public uint MaxThreshold => Math.Max(Threshold1, Math.Max(Threshold2, Math.Max(Threshold3, Math.Max(Threshold4, Threshold5))));

        /// <summary>
        /// Gets the Milestone Threshold
        /// </summary>
        /// <param name="index">Milestone index</param>
        /// <returns>Zero if the milestone does not have a threshold</returns>
        public uint GetThresholdValue(in int index)
        {
            return index switch
            {
                0 => Threshold1,
                1 => Threshold2,
                2 => Threshold3,
                3 => Threshold4,
                4 => Threshold5,
                _ => 0,
            };
        }

        /// <summary>
        /// Checks if the Milestone is satisfied.
        /// </summary>
        /// <param name="index">Milestone index</param>
        /// <param name="count">Value stored for the entry</param>
        /// <returns>True if the milestone is satisfied, false if not.</returns>
        public bool GetIsSatisfied(in int index, in uint count)
        {
            if ((uint)index >= MilestoneMax)
                throw new ArgumentOutOfRangeException(nameof(index));

            // Threshold value milestone
            var threshold = GetThresholdValue(index);
            if (threshold != 0)
                return count >= threshold;

            // Bit-toggle milestone
            var bit = (count >> index) & 1;
            return bit != 0;
        }

        private const string Unknown = "???";

        public static readonly IReadOnlyDictionary<int, LifeSupportAchievement> List = new Dictionary<int, LifeSupportAchievement>
        {
            {0x00, new LifeSupportAchievement(000, 5, 0010, 0100, 0500, 2000, 5000,   3,  -1, "CatchFish"                   )}, // サカナを釣った
            {0x01, new LifeSupportAchievement(001, 5, 0010, 0100, 0500, 2000, 5000,   3,  -1, "CatchInsect"                 )}, // ムシを捕まえた
            {0x02, new LifeSupportAchievement(002, 3, 0010, 0050, 0100, 0000, 0000,  -1,  -1, "CatchFishContinuously"       )}, // 連続で釣りを成功させた回数の最高記録
            {0x03, new LifeSupportAchievement(003, 5, 0010, 0020, 0040, 0060, 0080,  -1,  -1, "FillFishList"                )}, // サカナ図鑑を埋めた
            {0x04, new LifeSupportAchievement(004, 5, 0010, 0020, 0040, 0060, 0080,  -1,  -1, "FillInsectList"              )}, // ムシ図鑑を埋めた
            {0x05, new LifeSupportAchievement(005, 5, 0005, 0020, 0050, 0100, 0300,  -1,  -1, "ShootDownBalloon"            )}, // ふうせんを撃ち落とした
            {0x06, new LifeSupportAchievement(006, 5, 0010, 0050, 0100, 0200, 0300,   3,  -1, "PlantFlowerSeed"             )}, // 花の種を植えた
            {0x07, new LifeSupportAchievement(007, 6, 0000, 0000, 0000, 0000, 0000,  -1,  -1, "PlantFruit"                  )}, // 6種類のフルーツを植えた
            {0x08, new LifeSupportAchievement(008, 3, 0005, 0010, 0030, 0000, 0000,  -1,  -1, "PlantTreeSeedling"           )}, // 木の苗を植えた
            {0x09, new LifeSupportAchievement(009, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "BuyKabu"                     )}, // カブを買った
            {0x0A, new LifeSupportAchievement(010, 5, 1000, 10000, 100000, 1000000, 10000000,  -1,  -1, "HowmuchSellKabu"             )}, // カブで得た累計利益
            {0x0B, new LifeSupportAchievement(011, 5, 5000, 50000, 500000, 2000000, 5000000,  -1,  -1, "HowmuchBuyItem"              )}, // これまでの買い物総額
            {0x0C, new LifeSupportAchievement(012, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "BuyItemRcm"                  )}, // まめきちの店で買い物した
            {0x0D, new LifeSupportAchievement(013, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "SellItemRcm"                 )}, // まめきちの店で売った
            {0x0E, new LifeSupportAchievement(014, 5, 0005, 0020, 0050, 0100, 0200,  -1,  -1, "RemakeFurniture"             )}, // リメイクをした
            {0x0F, new LifeSupportAchievement(015, 5, 0100, 0200, 0300, 0400, 0500,  -1,  -1, "FillCatalog"                 )}, // カタログの項目数
            {0x10, new LifeSupportAchievement(016, 5, 0001, 0020, 0050, 0100, 0200,  -1,  -1, "BuyItemCatalog"              )}, // 通販を利用した
            {0x11, new LifeSupportAchievement(017, 5, 0001, 0010, 0030, 0060, 0100,  -1,  -1, "GotoTotakekeShow"            )}, // とたけけのライブを観た
            {0x12, new LifeSupportAchievement(018, 3, 0001, 0005, 0010, 0000, 0000,  -1,  -1, "VisitAnotherIsland"          )}, // よその島へのおでかけした
            {0x13, new LifeSupportAchievement(019, 3, 0001, 0005, 0010, 0000, 0000,  -1,  -1, "InviteFriend"                )}, // 島にフレンドを招いた
            {0x15, new LifeSupportAchievement(021, 5, 0003, 0020, 0050, 0100, 0300,  -1,  -1, "DayPlayed"                   )}, // 活動日数
            {0x17, new LifeSupportAchievement(023, 5, 0010, 0050, 0100, 0500, 1000,  -1,  -1, "WaterPlant"                  )}, // 水やりをした
            {0x18, new LifeSupportAchievement(024, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "BeStungbyWasp"               )}, // ハチに刺された
            {0x19, new LifeSupportAchievement(025, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "CatchSeminonukegara"         )}, // セミのぬけがらを取った
            {0x1A, new LifeSupportAchievement(026, 3, 0001, 0005, 0010, 0000, 0000,  -1,  -1, "CatchNomi"                   )}, // ノミを取ってあげた
            {0x1B, new LifeSupportAchievement(027, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "BeStungbyPoisonousInsect"    )}, // こわいムシで気絶した
            {0x1F, new LifeSupportAchievement(031, 5, 0001, 0010, 0020, 0030, 0042,  -1,  -1, "FillReactionList"            )}, // リアクションを覚えた
            {0x20, new LifeSupportAchievement(032, 3, 0003, 0010, 0020, 0000, 0000,  -1,  -1, "CatchTrash"                  )}, // ゴミを釣った
            {0x21, new LifeSupportAchievement(033, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "PayImmigrationCost"          )}, // 移住費用を支払った
            {0x22, new LifeSupportAchievement(034, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "RepayLoan"                   )}, // ローンを完済した
            {0x23, new LifeSupportAchievement(035, 1, 0001, 0000, 0000, 0000, 0000,   3,  -1, "UseMydesign"                 )}, // マイデザインを使った
            {0x24, new LifeSupportAchievement(036, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "UseMydesignPRO"              )}, // マイデザインPROを使った
            {0x25, new LifeSupportAchievement(037, 5, 0050, 0200, 1000, 2000, 3000,  -1,  -1, "SellWeed"                    )}, // 雑草を引き取ってもらった
            {0x27, new LifeSupportAchievement(039, 6, 0000, 0000, 0000, 0000, 0000,  -1,  -1, "CollectGoldTool"             )}, // 6種類の金の道具を集めた
            {0x28, new LifeSupportAchievement(040, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "GetSRankonHHA"               )}, // HHAでSを取った
            {0x29, new LifeSupportAchievement(041, 4, 0000, 0000, 0000, 0000, 0000,  -1,  -1, "AttendFishingConvention"     )}, // 釣り大会に春夏秋冬参加した
            {0x2A, new LifeSupportAchievement(042, 4, 0000, 0000, 0000, 0000, 0000,  -1,  -1, "AttendInsectConvention"      )}, // ムシとり大会に6～9月参加した
            {0x2B, new LifeSupportAchievement(043, 3, 0001, 0010, 0020, 0000, 0000,  -1,  -1, "HelpGul"                     )}, // ジョニーを助けた
            {0x2C, new LifeSupportAchievement(044, 3, 0001, 0010, 0020, 0000, 0000,  -1,  -1, "HelpGst"                     )}, // ゆうたろうを助けた
            {0x2D, new LifeSupportAchievement(045, 3, 0001, 0010, 0020, 0000, 0000,  -1,  -1, "MakePerfectSnowball"         )}, // 最高のゆきだるまを作った
            {0x2E, new LifeSupportAchievement(046, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "ReachMyBirthday"             )}, // 誕生日を迎えた
            {0x2F, new LifeSupportAchievement(047, 3, 0001, 0010, 0020, 0000, 0000,  -1,  -1, "CelebrateVillagersBithday"   )}, // 村民の誕生日を祝ってあげた
            {0x30, new LifeSupportAchievement(048, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "AttendCountdownParty"        )}, // カウントダウンに参加した
            {0x31, new LifeSupportAchievement(049, 5, 0001, 0020, 0050, 0100, 0200,  -1,  -1, "BreakTool"                   )}, // 道具を壊した
            {0x32, new LifeSupportAchievement(050, 5, 0005, 0020, 0050, 0100, 0200,  -1,  -1, "SendLetter"                  )}, // 手紙を送った
            {0x33, new LifeSupportAchievement(051, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "MakePitfall"                 )}, // 落とし穴を作った
            {0x34, new LifeSupportAchievement(052, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "FallintoPitfall"             )}, // 落とし穴に落ちた
            {0x35, new LifeSupportAchievement(053, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "ImmigratetoIsland"           )}, // 島に移住した
            {0x36, new LifeSupportAchievement(054, 3, 0001, 0002, 0003, 0000, 0000,  -1,  -1, "BeFriendwithVillager"        )}, // どうぶつとなかよしになった
            {0x37, new LifeSupportAchievement(055, 5, 0010, 0050, 0100, 0150, 0200,  -1,  -1, "FillRecipeList"              )}, // 集めたレシピの数
            {0x38, new LifeSupportAchievement(056, 1, 1000, 0000, 0000, 0000, 0000,  -1,  -1, "BootPhone"                   )}, // スマホを起動した(上級)
            {0x39, new LifeSupportAchievement(057, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "StrikeRock8Times"            )}, // コイン岩を8連打した
            {0x3A, new LifeSupportAchievement(058, 5, 0005, 0050, 0200, 1000, 3000,  -1, 320, "AchieveAppQuest"             )}, // 村活クエストを達成した
            {0x3B, new LifeSupportAchievement(059, 5, 0001, 0010, 0050, 0100, 0300,  -1,  -1, "AchieveVillagersQuest"       )}, // どうぶつのお願いを聞いた
            {0x3C, new LifeSupportAchievement(060, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "DigBell"                     )}, // ベルを掘り出した
            {0x3D, new LifeSupportAchievement(061, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "DigFossil"                   )}, // 化石を掘り出した
            {0x3E, new LifeSupportAchievement(062, 5, 0005, 0030, 0100, 0300, 0500,  -1,  -1, "JudgeFossil"                 )}, // 化石を鑑定した
            {0x3F, new LifeSupportAchievement(063, 5, 0005, 0020, 0050, 0100, 0200,  66,  -1, "DigShell"                    )}, // 潮干狩りをした
            {0x40, new LifeSupportAchievement(064, 1, 0010, 0000, 0000, 0000, 0000,   3,  -1, "PutFurnitureOutside"         )}, // 外に家具を置いた
            {0x43, new LifeSupportAchievement(067, 5, 0020, 0100, 0500, 2000, 5000,  -1,  -1, "StrikeWood"                  )}, // 木からもくざいを出した
            {0x44, new LifeSupportAchievement(068, 5, 0001, 0010, 0020, 0030, 0050,   3,  -1, "GreetAllVillager"            )}, // 村民全員とあいさつをした
            {0x45, new LifeSupportAchievement(069, 5, 0010, 0050, 0200, 0500, 1000,   3,  -1, "SellShell"                   )}, // 貝殻を売った
            {0x46, new LifeSupportAchievement(070, 5, 0020, 0100, 0500, 1000, 3000,   3,  -1, "SellFruit"                   )}, // フルーツを売った
            {0x47, new LifeSupportAchievement(071, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "CatchBeeContinuously"        )}, // ハチを5連続捕まえた
            {0x48, new LifeSupportAchievement(072, 5, 0005, 0050, 0200, 1000, 3000,  -1,  -1, "DIYTool"                     )}, // 道具をDIYした
            {0x49, new LifeSupportAchievement(073, 5, 0005, 0050, 0200, 1000, 3000,  -1,  -1, "DIYFurniture"                )}, // 家具をDIYした
            {0x4B, new LifeSupportAchievement(075, 1, 0001, 0000, 0000, 0000, 0000,   3,  -1, "TakePicture"                 )}, // カメラで写真を撮った
            {0x4C, new LifeSupportAchievement(076, 1, 0010, 0000, 0000, 0000, 0000,  -1,  -1, "BootPhoneBeginner"           )}, // スマホを起動した(初級)
            {0x4D, new LifeSupportAchievement(077, 5, 0020, 0050, 0100, 0200, 0300,  -1,  -1, "HouseStorageItem"            )}, // 家の倉庫に収納したアイテムの数
            {0x4E, new LifeSupportAchievement(078, 5, 0005, 0015, 0030, 0100, 0150,  -1,  -1, "PlaceFurnitureMyHouse"       )}, // 家に飾っている家具の数
            {0x4F, new LifeSupportAchievement(079, 5, 0001, 0010, 0020, 0050, 0100,  -1,  -1, "FallFurnitureLeaf"           )}, // 木を揺すって家具（葉っぱ）を落とした回数
            {0x50, new LifeSupportAchievement(080, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "DropPresentinWater"          )}, // 風船のプレゼントを撃ち水の中に落とした
            {0x51, new LifeSupportAchievement(081, 3, 0001, 0003, 0005, 0000, 0000,  -1,  -1, "ReformMyHome"                )}, // マイホームをリフォームした
            {0x52, new LifeSupportAchievement(082, 5, 0001, 0002, 0005, 0006, 0007,  -1,  -1, "ExtendMyHome"                )}, // マイホームを増築した
            {0x53, new LifeSupportAchievement(083, 1, 0001, 0000, 0000, 0000, 0000,   3,  -1, "PostMessageBoard"            )}, // 自分の島の掲示板に書き込む
            {0x54, new LifeSupportAchievement(084, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "UseCloset"                   )}, // クローゼットで着替える
            {0x55, new LifeSupportAchievement(085, 3, 0001, 0030, 0200, 0000, 0000,  -1,  -1, "PrayShootingStar"            )}, // 流れ星に祈る
            {0x56, new LifeSupportAchievement(086, 2, 0000, 0000, 0000, 0000, 0000,  59,  -1, "ChangeSymbol"                )}, // 島の旗、島メロを変える
            {0x57, new LifeSupportAchievement(087, 1, 0001, 0000, 0000, 0000, 0000,   3,  -1, "UpdatePassport"              )}, // パスポートを更新した
            {0x58, new LifeSupportAchievement(088, 3, 0000, 0000, 0000, 0000, 0000,  -1, 513, "ModifyIsland"                )}, // 各地形造成をやってみた
            {0x59, new LifeSupportAchievement(089, 1, 0020, 0000, 0000, 0000, 0000,  -1, 478, "BuildFence"                  )}, // 柵を置く
            {0x5A, new LifeSupportAchievement(090, 1, 0001, 0000, 0000, 0000, 0000,  -1,  -1, "DonateFake"                  )}, // 寄贈しようとした美術品が贋作だった
            {0x5B, new LifeSupportAchievement(091, 3, 0001, 0010, 0020, 0000, 0000,  -1,  -1, "BuyatTsunekichiShop"         )}, // いなりマーケットで芸術品を買った
            {0x5C, new LifeSupportAchievement(092, 3, 0001, 0005, 0020, 0000, 0000,  -1,  -1, "PlantBushSeedling"           )}, // 各種低木の苗を植えた
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

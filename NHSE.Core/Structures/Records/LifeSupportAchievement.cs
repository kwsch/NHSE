using System.Collections.Generic;

namespace NHSE.Core
{
    public static class LifeSupportAchievement
    {
        private const string Unknown = "???";

        private static readonly IReadOnlyDictionary<int, string> Dictionary = new Dictionary<int, string>
        {
            {00, "CatchFish"}, // サカナを釣った
            {01, "CatchInsect"}, // ムシを捕まえた
            {02, "CatchFishContinuously"}, // 連続で釣りを成功させた回数の最高記録
            {03, "FillFishList"}, // サカナ図鑑を埋めた
            {04, "FillInsectList"}, // ムシ図鑑を埋めた
            {05, "ShootDownBalloon"}, // ふうせんを撃ち落とした
            {06, "PlantFlowerSeed"}, // 花の種を植えた
            {07, "PlantFruit"}, // 6種類のフルーツを植えた
            {08, "PlantTreeSeedling"}, // 木の苗を植えた
            {09, "BuyKabu"}, // カブを買った
            {10, "HowmuchSellKabu"}, // カブで得た累計利益
            {11, "HowmuchBuyItem"}, // これまでの買い物総額
            {12, "BuyItemRcm"}, // まめきちの店で買い物した
            {13, "SellItemRcm"}, // まめきちの店で売った
            {14, "RemakeFurniture"}, // リメイクをした
            {15, "FillCatalog"}, // カタログの項目数
            {16, "BuyItemCatalog"}, // 通販を利用した
            {17, "GotoTotakekeShow"}, // とたけけのライブを観た
            {18, "VisitAnotherIsland"}, // よその島へのおでかけした
            {19, "InviteFriend"}, // 島にフレンドを招いた
            {21, "DayPlayed"}, // 活動日数
            {23, "WaterPlant"}, // 水やりをした
            {24, "BeStungbyWasp"}, // ハチに刺された
            {25, "CatchSeminonukegara"}, // セミのぬけがらを取った
            {26, "CatchNomi"}, // ノミを取ってあげた
            {27, "BeStungbyPoisonousInsect"}, // こわいムシで気絶した
            {31, "FillReactionList"}, // リアクションを覚えた
            {32, "CatchTrash"}, // ゴミを釣った
            {33, "PayImmigrationCost"}, // 移住費用を支払った
            {34, "RepayLoan"}, // ローンを完済した
            {35, "UseMydesign"}, // マイデザインを使った
            {36, "UseMydesignPRO"}, // マイデザインPROを使った
            {37, "SellWeed"}, // 雑草を引き取ってもらった
            {39, "CollectGoldTool"}, // 6種類の金の道具を集めた
            {40, "GetSRankonHHA"}, // HHAでSを取った
            {41, "AttendFishingConvention"}, // 釣り大会に春夏秋冬参加した
            {42, "AttendInsectConvention"}, // ムシとり大会に6～9月参加した
            {43, "HelpGul"}, // ジョニーを助けた
            {44, "HelpGst"}, // ゆうたろうを助けた
            {45, "MakePerfectSnowball"}, // 最高のゆきだるまを作った
            {46, "ReachMyBirthday"}, // 誕生日を迎えた
            {47, "CelebrateVillagersBithday"}, // 村民の誕生日を祝ってあげた
            {48, "AttendCountdownParty"}, // カウントダウンに参加した
            {49, "BreakTool"}, // 道具を壊した
            {50, "SendLetter"}, // 手紙を送った
            {51, "MakePitfall"}, // 落とし穴を作った
            {52, "FallintoPitfall"}, // 落とし穴に落ちた
            {53, "ImmigratetoIsland"}, // 島に移住した
            {54, "BeFriendwithVillager"}, // どうぶつとなかよしになった
            {55, "FillRecipeList"}, // 集めたレシピの数
            {56, "BootPhone"}, // スマホを起動した(上級)
            {57, "StrikeRock8Times"}, // コイン岩を8連打した
            {58, "AchieveAppQuest"}, // 村活クエストを達成した
            {59, "AchieveVillagersQuest"}, // どうぶつのお願いを聞いた
            {60, "DigBell"}, // ベルを掘り出した
            {61, "DigFossil"}, // 化石を掘り出した
            {62, "JudgeFossil"}, // 化石を鑑定した
            {63, "DigShell"}, // 潮干狩りをした
            {64, "PutFurnitureOutside"}, // 外に家具を置いた
            {67, "StrikeWood"}, // 木からもくざいを出した
            {68, "GreetAllVillager"}, // 村民全員とあいさつをした
            {69, "SellShell"}, // 貝殻を売った
            {70, "SellFruit"}, // フルーツを売った
            {71, "CatchBeeContinuously"}, // ハチを5連続捕まえた
            {72, "DIYTool"}, // 道具をDIYした
            {73, "DIYFurniture"}, // 家具をDIYした
            {75, "TakePicture"}, // カメラで写真を撮った
            {76, "BootPhoneBeginner"}, // スマホを起動した(初級)
            {77, "HouseStorageItem"}, // 家の倉庫に収納したアイテムの数
            {78, "PlaceFurnitureMyHouse"}, // 家に飾っている家具の数
            {79, "FallFurnitureLeaf"}, // 木を揺すって家具（葉っぱ）を落とした回数
            {80, "DropPresentinWater"}, // 風船のプレゼントを撃ち水の中に落とした
            {81, "ReformMyHome"}, // マイホームをリフォームした
            {82, "ExtendMyHome"}, // マイホームを増築した
            {83, "PostMessageBoard"}, // 自分の島の掲示板に書き込む
            {84, "UseCloset"}, // クローゼットで着替える
            {85, "PrayShootingStar"}, // 流れ星に祈る
            {86, "ChangeSymbol"}, // 島の旗、島メロを変える
            {87, "UpdatePassport"}, // パスポートを更新した
            {88, "ModifyIsland"}, // 各地形造成をやってみた
            {89, "BuildFence"}, // 柵を置く
            {90, "DonateFake"}, // 寄贈しようとした美術品が贋作だった
            {91, "BuyatTsunekichiShop"}, // いなりマーケットで芸術品を買った
            {92, "PlantBushSeedling"}, // 各種低木の苗を植えた
        };

        public static string GetName(int index, uint count)
        {
            var dict = Dictionary;
            if (dict.TryGetValue(index, out var val))
                return $"{index:00} - {val} = {count}";
            return $"{index:00} - {Unknown} = {count}";
        }
    }
}

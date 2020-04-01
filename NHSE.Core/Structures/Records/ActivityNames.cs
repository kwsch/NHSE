using System.Collections.Generic;

namespace NHSE.Core
{
    public static class ActivityNames
    {
        private const string Unknown = "???";

        private static readonly IReadOnlyDictionary<int, string> Dictionary = new Dictionary<int, string>
        {
            {1,"CatchFish"}, // サカナを釣った
            {2,"CatchInsect"}, // ムシを捕まえた
            {3,"CatchFishContinuously"}, // 連続で釣りを成功させた回数の最高記録
            {4,"FillFishList"}, // サカナ図鑑を埋めた
            {5,"FillInsectList"}, // ムシ図鑑を埋めた
            {6,"ShootDownBalloon"}, // ふうせんを撃ち落とした
            {7,"PlantFlowerSeed"}, // 花の種を植えた
            {8,"PlantFruit"}, // 6種類のフルーツを植えた
            {9,"PlantTreeSeedling"}, // 木の苗を植えた
            {10,"BuyKabu"}, // カブを買った
            {11,"HowmuchSellKabu"}, // カブで得た累計利益
            {12,"HowmuchBuyItem"}, // これまでの買い物総額
            {13,"BuyItemRcm"}, // まめきちの店で買い物した
            {14,"SellItemRcm"}, // まめきちの店で売った
            {15,"RemakeFurniture"}, // リメイクをした
            {16,"FillCatalog"}, // カタログの項目数
            {17,"BuyItemCatalog"}, // 通販を利用した
            {18,"GotoTotakekeShow"}, // とたけけのライブを観た
            {19,"VisitAnotherIsland"}, // よその島へのおでかけした
            {20,"InviteFriend"}, // 島にフレンドを招いた
            {22,"DayPlayed"}, // 活動日数
            {24,"WaterPlant"}, // 水やりをした
            {25,"BeStungbyWasp"}, // ハチに刺された
            {26,"CatchSeminonukegara"}, // セミのぬけがらを取った
            {27,"CatchNomi"}, // ノミを取ってあげた
            {28,"BeStungbyPoisonousInsect"}, // こわいムシで気絶した
            {32,"FillReactionList"}, // リアクションを覚えた
            {33,"CatchTrash"}, // ゴミを釣った
            {34,"PayImmigrationCost"}, // 移住費用を支払った
            {35,"RepayLoan"}, // ローンを完済した
            {36,"UseMydesign"}, // マイデザインを使った
            {37,"UseMydesignPRO"}, // マイデザインPROを使った
            {38,"SellWeed"}, // 雑草を引き取ってもらった
            {40,"CollectGoldTool"}, // 6種類の金の道具を集めた
            {41,"GetSRankonHHA"}, // HHAでSを取った
            {42,"AttendFishingConvention"}, // 釣り大会に春夏秋冬参加した
            {43,"AttendInsectConvention"}, // ムシとり大会に6～9月参加した
            {44,"HelpGul"}, // ジョニーを助けた
            {45,"HelpGst"}, // ゆうたろうを助けた
            {46,"MakePerfectSnowball"}, // 最高のゆきだるまを作った
            {47,"ReachMyBirthday"}, // 誕生日を迎えた
            {48,"CelebrateVillagersBithday"}, // 村民の誕生日を祝ってあげた
            {49,"AttendCountdownParty"}, // カウントダウンに参加した
            {50,"BreakTool"}, // 道具を壊した
            {51,"SendLetter"}, // 手紙を送った
            {52,"MakePitfall"}, // 落とし穴を作った
            {53,"FallintoPitfall"}, // 落とし穴に落ちた
            {54,"ImmigratetoIsland"}, // 島に移住した
            {55,"BeFriendwithVillager"}, // どうぶつとなかよしになった
            {56,"FillRecipeList"}, // 集めたレシピの数
            {57,"BootPhone"}, // スマホを起動した(上級)
            {58,"StrikeRock8Times"}, // コイン岩を8連打した
            {59,"AchieveAppQuest"}, // 村活クエストを達成した
            {60,"AchieveVillagersQuest"}, // どうぶつのお願いを聞いた
            {61,"DigBell"}, // ベルを掘り出した
            {62,"DigFossil"}, // 化石を掘り出した
            {63,"JudgeFossil"}, // 化石を鑑定した
            {64,"DigShell"}, // 潮干狩りをした
            {65,"PutFurnitureOutside"}, // 外に家具を置いた
            {68,"StrikeWood"}, // 木からもくざいを出した
            {69,"GreetAllVillager"}, // 村民全員とあいさつをした
            {70,"SellShell"}, // 貝殻を売った
            {71,"SellFruit"}, // フルーツを売った
            {72,"CatchBeeContinuously"}, // ハチを5連続捕まえた
            {73,"DIYTool"}, // 道具をDIYした
            {74,"DIYFurniture"}, // 家具をDIYした
            {76,"TakePicture"}, // カメラで写真を撮った
            {77,"BootPhoneBeginner"}, // スマホを起動した(初級)
            {78,"HouseStorageItem"}, // 家の倉庫に収納したアイテムの数
            {79,"PlaceFurnitureMyHouse"}, // 家に飾っている家具の数
            {80,"FallFurnitureLeaf"}, // 木を揺すって家具（葉っぱ）を落とした回数
            {81,"DropPresentinWater"}, // 風船のプレゼントを撃ち水の中に落とした
            {82,"ReformMyHome"}, // マイホームをリフォームした
            {83,"ExtendMyHome"}, // マイホームを増築した
            {84,"PostMessageBoard"}, // 自分の島の掲示板に書き込む
            {85,"UseCloset"}, // クローゼットで着替える
            {86,"PrayShootingStar"}, // 流れ星に祈る
            {87,"ChangeSymbol"}, // 島の旗、島メロを変える
            {88,"UpdatePassport"}, // パスポートを更新した
            {89,"ModifyIsland"}, // 各地形造成をやってみた
            {90,"BuildFence"}, // 柵を置くハチを5連続捕まえた
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

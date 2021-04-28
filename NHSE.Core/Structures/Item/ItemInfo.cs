using System.Collections.Generic;
using System.Text;
using static NHSE.Core.ItemKind;

namespace NHSE.Core
{
    /// <summary>
    /// Fetching metadata about an <see cref="Item"/>
    /// </summary>
    public static class ItemInfo
    {
        // derived from bcsv; only some data is needed for our logic
        private static readonly byte[] ItemKinds = ResourceUtil.GetBinaryResource("item_kind.bin");
        private static readonly byte[] ItemSizes = ResourceUtil.GetBinaryResource("item_size.bin");
        private static readonly ushort[] ItemMenuIcons = ResourceUtil.GetBinaryResourceAsUshort("item_menuicon.bin");

        public static ItemKind GetItemKind(Item item) => GetItemKind(item.DisplayItemId);

        public static ItemKind GetItemKind(ushort id)
        {
            if (id > ItemKinds.Length)
                return FieldItemList.GetFieldItemKind(id);
            return (ItemKind) ItemKinds[id];
        }

        public static ItemSizeType GetItemSize(Item item)
        {
            if (item.IsBuried || item.IsDropped)
                return ItemSizeType.S_1_0x1_0;

            return GetItemSize(item.DisplayItemId);
        }

        public static ItemSizeType GetItemSize(ushort id)
        {
            if (id > ItemSizes.Length)
                return ItemSizeType.Unknown;
            return (ItemSizeType)ItemSizes[id];
        }

        public static ItemMenuIconType GetMenuIcon(ushort id)
        {
            if (id > ItemMenuIcons.Length)
                return ItemMenuIconType.Unknown;
            return (ItemMenuIconType)ItemMenuIcons[id];
        }

        public static bool TryGetMaxStackCount(Item item, out ushort max) => TryGetMaxStackCount(item.DisplayItemId, out max);

        public static bool TryGetMaxStackCount(ushort id, out ushort max)
        {
            var kind = GetItemKind(id);
            if (kind.IsFlowerPicked())
                kind = Kind_Flower;
            return MaxCountByKind.TryGetValue(kind, out max);
        }

        private static readonly Dictionary<ItemKind, ushort> MaxCountByKind = new()
        {
            {Kind_Ftr, 00001},
            {Kind_RoomWall, 00001},
            {Kind_RoomFloor, 00001},
            {Kind_Rug, 00001},
            {Kind_RugMyDesign, 00001},
            {Kind_Socks, 00001},
            {Kind_Cap, 00001},
            {Kind_Helmet, 00001},
            {Kind_Accessory, 00001},
            {Kind_Bag, 00001},
            {Kind_Umbrella, 00001},
            {Kind_FishingRod, 00001},
            {Kind_Net, 00001},
            {Kind_Shovel, 00001},
            {Kind_Axe, 00001},
            {Kind_Watering, 00001},
            {Kind_Slingshot, 00001},
            {Kind_ChangeStick, 00001},
            {Kind_WoodenStickTool, 00001},
            {Kind_Ladder, 00001},
            {Kind_GroundMaker, 00001},
            {Kind_RiverMaker, 00001},
            {Kind_CliffMaker, 00001},
            {Kind_PartyPopper, 00010},
            {Kind_Ocarina, 00001},
            {Kind_Panflute, 00001},
            {Kind_Tambourine, 00001},
            {Kind_FierworkHand, 00010},
            {Kind_StickLight, 00001},
            {Kind_Uchiwa, 00001},
            {Kind_Windmill, 00001},
            {Kind_BlowBubble, 00010},
            {Kind_Partyhorn, 00001},
            {Kind_Balloon, 00001},
            {Kind_Timer, 00001},
            {Kind_HandheldPennant, 00001},
            {Kind_BigbagPresent, 00001},
            {Kind_JuiceFuzzyapple, 00001},
            {Kind_Megaphone, 00001},
            {Kind_SoySet, 00001},
            {Kind_MaracasCarnival, 00001},
            {Kind_FlowerShower, 00001},
            {Kind_TreeSeedling, 00010},
            {Kind_Tree, 00001},
            {Kind_BushSeedling, 00010},
            {Kind_Bush, 00001},
            {Kind_VegeSeedling, 00010},
            {Kind_VegeTree, 00001},
            {Kind_Vegetable, 00010},
            {Kind_Weed, 00099},
            {Kind_FlowerSeed, 00010},
            {Kind_FlowerBud, 00001},
            {Kind_Flower, 00010},
            {Kind_Fruit, 00010},
            {Kind_Mushroom, 00010},
            {Kind_Turnip, 00010},
            {Kind_TurnipExpired, 00001},
            {Kind_FishBait, 00010},
            {Kind_PitFallSeed, 00010},
            {Kind_Medicine, 00010},
            {Kind_CraftMaterial, 00030},
            {Kind_CraftRemake, 00050},
            {Kind_Ore, 00030},
            {Kind_CraftPhoneCase, 00001},
            {Kind_Honeycomb, 00010},
            {Kind_Trash, 00001},
            {Kind_SnowCrystal, 00010},
            {Kind_AutumnLeaf, 00010},
            {Kind_Sakurapetal, 00010},
            {Kind_XmasDeco, 00010},
            {Kind_StarPiece, 00010},
            {Kind_Insect, 00001},
            {Kind_Fish, 00001},
            {Kind_DiveFish, 00001},
            {Kind_ShellDrift, 00010},
            {Kind_ShellFish, 00001},
            {Kind_FishToy, 00001},
            {Kind_InsectToy, 00001},
            {Kind_Fossil, 00001},
            {Kind_FossilUnknown, 00001},
            {Kind_Music, 00001},
            {Kind_MusicMiss, 00001},
            {Kind_Bromide, 00001},
            {Kind_Poster, 00001},
            {Kind_HousePost, 00001},
            {Kind_DoorDeco, 00001},
            {Kind_Fence, 00050},
            {Kind_DummyRecipe, 00001},
            {Kind_DummyDIYRecipe, 00001},
            {Kind_DummyHowtoBook, 00001},
            {Kind_LicenseItem, 00001},
            {Kind_BridgeItem, 00001},
            {Kind_SlopeItem, 00001},
            {Kind_DIYRecipe, 00001},
            {Kind_MessageBottle, 00001},
            {Kind_WrappingPaper, 00010},
            {Kind_Otoshidama, 00010},
            {Kind_HousingKit, 00001},
            {Kind_HousingKitRcoQuest, 00001},
            {Kind_HousingKitBirdge, 00001},
            {Kind_Money, 00010},
            {Kind_FireworkM, 00001},
            {Kind_BdayCupcake, 00010},
            {Kind_YutaroWisp, 00005},
            {Kind_JohnnyQuest, 00010},
            {Kind_JohnnyQuestDust, 00010},
            {Kind_PirateQuest, 00010},
            {Kind_QuestWrapping, 00001},
            {Kind_QuestChristmasPresentbox, 00001},
            {Kind_LostQuest, 00001},
            {Kind_LostQuestDust, 00001},
            {Kind_TailorTicket, 00010},
            {Kind_TreasureQuest, 00001},
            {Kind_TreasureQuestDust, 00001},
            {Kind_MilePlaneTicket, 00010},
            {Kind_RollanTicket, 00005},
            {Kind_EasterEgg, 00030},
            {Kind_LoveCrystal, 00030},
            {Kind_Candy, 00030},
            {Kind_HarvestDish, 00001},
            {Kind_Feather, 00003},
            {Kind_RainbowFeather, 00001},
            {Kind_Giftbox, 00001},
            {Kind_PinataStick, 00001},
            {Kind_NpcOutfit, 00001},
            {Kind_PlayerDemoOutfit, 00001},
            {Kind_Picture, 00001},
            {Kind_Sculpture, 00001},
            {Kind_PictureFake, 00001},
            {Kind_SculptureFake, 00001},
            {Kind_SmartPhone, 00001},
            {Kind_DummyFtr, 00001},
            {Kind_SequenceOnly, 00001},
            {Kind_MyDesignObject, 00001},
            {Kind_MyDesignTexture, 00001},
            {Kind_DummyWrapping, 00001},
            {Kind_DummyPresentbox, 00001},
            {Kind_DummyCardboard, 00001},
            {Kind_EventObjFtr, 00001},
            {Kind_NnpcRoomMarker, 00001},
            {Kind_PhotoStudioList, 00001},
            {Kind_DummyWrappingOtoshidama, 00001},
        };

        /// <summary>
        /// Lists the customization options for the requested <see cref="itemID"/>
        /// </summary>
        /// <param name="itemID">Item ID</param>
        public static string GetItemInfo(ushort itemID)
        {
            var remake = ItemRemakeUtil.GetRemakeIndex(itemID);
            if (remake < 0)
                return string.Empty;

            var info = ItemRemakeInfoData.List[remake];
            return GetItemInfo(info, GameInfo.Strings);
        }

        /// <summary>
        /// Lists the customization options for the requested <see cref="info"/>
        /// </summary>
        /// <param name="info">Item customization possibilities</param>
        /// <param name="str">Game strings</param>
        public static string GetItemInfo(ItemRemakeInfo info, IRemakeString str)
        {
            var sb = new StringBuilder();
            var body = info.GetBodySummary(str);
            if (body.Length > 0)
                sb.AppendLine(body);

            var fabric = info.GetFabricSummary(str);
            if (fabric.Length > 0)
                sb.AppendLine(fabric);

            return sb.ToString();
        }

        /// <summary>
        /// Calculates the position the "Drop" option shows up in the item's interaction menu.
        /// </summary>
        /// <param name="item">Item object to drop</param>
        /// <returns>How many times the down button has to be pressed to reach the "Drop" option.</returns>
        public static int GetItemDropOption(this Item item)
        {
            if (Item.DIYRecipe == item.ItemId)
                return 1;
            if (item.IsWrapped)
                return 0;

            var kind = GetItemKind(item);
            return kind switch
            {
                Kind_DIYRecipe => 1,

                Kind_Flower => 2,
                _ => 1,
            };
        }

        /// <summary>
        /// Determines if wrapping the <see cref="item"/> is possible.
        /// </summary>
        /// <param name="item">Item object to drop</param>
        /// <returns>True if can be wrapped</returns>
        public static bool ShouldWrapItem(this Item item)
        {
            if (Item.DIYRecipe == item.ItemId)
                return false;

            var kind = GetItemKind(item);
            return kind switch
            {
                Kind_DIYRecipe => false,

                Kind_Flower => false,
                _ => true,
            };
        }

        /// <summary>
        /// Checks if the <see cref="item"/> is able to be dropped by the player character.
        /// </summary>
        /// <param name="item">Item object to drop</param>
        /// <returns>True if can be dropped</returns>
        public static bool IsDroppable(Item item)
        {
            if (item.IsFieldItem)
                return false;
            if (item.IsExtension)
                return false;
            if (item.IsNone)
                return false;
            if (item.SystemParam > 3)
                return false; // buried, dropped, etc

            var kind = GetItemKind(item);
            return kind switch
            {
                Kind_Insect => false,

                Kind_DummyPresentbox => false,

                Kind_Fish => false,
                Kind_DiveFish => false,
                Kind_FlowerBud => false,
                Kind_Bush => false,
                Kind_Tree => false,

                _ => true,
            };
        }

        /// <summary>
        /// Checks if the item can be dropped, and sanitizes up any erroneous values if it can be.
        /// </summary>
        /// <param name="item">Requested item to drop.</param>
        /// <returns>True if can be dropped, false if cannot be dropped.</returns>
        public static bool IsSaneItemForDrop(Item item)
        {
            if (!IsDroppable(item))
                return false;

            // Sanitize Values
            if (item.ItemId == Item.MessageBottle || item.ItemId == Item.MessageBottleEgg)
            {
                item.ItemId = Item.DIYRecipe;
                item.FreeParam = 0;
            }

            return true;
        }
    }
}

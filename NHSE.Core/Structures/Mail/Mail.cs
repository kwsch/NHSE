using System.Collections.Generic;

namespace NHSE.Core;

public sealed class Mail
{
    public const int SIZE = 0x3C8;
    public const int MaxSlots = 299; // zero based (300 slots)

    public const int ReadUnread = 0x0; // 03 = unread, 04 = read
    public const int LetterFavourited = 0x1; // 00 = not marked fav, 01 = marked fav

    public const int PlayerSenderIslandID = 0x4; // Used if sender is a player
    public const int PlayerSenderIslandName = 0x8;
    public const int NPCSenderSpeciesID = 0x4; // Used if sender is a villager or NPC
    public const int NPCSenderVariantID = 0x5;
    public const int NPCSenderIslandID = 0x8;
    public const int NPCSenderIslandName = 0xC;

    public const int SenderID = 0x20; // Sender player identity 4 byte ID or 00000000.. = NPC, 02000000.. = villager
    public const int SenderName = 0x24; // Usual 20 byte string (10 char)

    public const int SenderType = 0x5C; // 00 = player, 01 = villager, 02 = NPC

    public const int ReceiverIslandID = 0x60; // Receiver island identity
    public const int ReceiverIslandName = 0x64;
    public const int ReceiverPlayerID = 0x7C; // Receiver player identity
    public const int ReceiverPlayerName = 0x80;

    public const int TimeStamp = 0xBC; // Timestamp start

    public const int AttachedItemID = 0xC0; // ID of item attached to mail, FFFE(le) if collected, type used is cleared
    public const int MailItemWrappingType = 0xC3; // Box type used for mail - cleared when item taken

    public const int MailType01 = 0xC8; // If boxed item only, then = 01 and MailType02 = 00
    public const int MailType02 = 0xCC; // If letter item, then = 01 and MailType01 = 00

    public const int LetterToLineText = 0xCE; // Max size for text in the to line up top (47 char) weird size
    public const int LetterToTextLength = 47; // Max renderable, not sure about official limit
    public const int LetterMessageText = 0x12E; // MSG start
    public const int LetterMessageTextLength = 239; // Max renderable size is 239 char despite official input UI limit of 168 char
    public const int LetterMessageTextLengthOfficial = 168;
    public const int LetterFromLineText = 0x30E; // Max size for text in the from line up top (47 char) weird size
    public const int LetterFromTextLength = 47; // Max renderable, not sure about official limit

    public const int MailStationerySkin = 0x36E; // Skin code (2 byte le int)

    public const int PostBoxSortIndex = 0x374; // PostBox index/slot 1->300(0->299)[0x0->0x12B] - position in postbox, bottom up

    public const int LanguageString = 0x390; // When sent by a player, shows language flag, like 'en-GB' otherwise not used

    /// <summary>
    /// Maps NPC sender IDs to their corresponding <see cref="SenderNPCInfo"/> data, including image identifiers, name conversions, and mapping indices.
    /// </summary>
    /// <remarks>
    /// The dictionary key represents the NPC's unique identifier stored at offset <see cref="NPCSenderSpeciesID"/> in the mail data.
    /// Each entry contains image asset names, localization keys, and index values for various in-game NPCs and services
    /// such as Tom Nook, Nook Inc., villagers, and special characters.
    /// </remarks>
    public record SenderNPCInfo(string Image, string NameConversion, int MappingIndex);
    public static readonly Dictionary<int, SenderNPCInfo> SenderNPCData = new()
    {
        { 22, new("rco",                "rco",                    0) },  // 0x1600 Tom Nook
        { 25, new("rco",                "npc_nookinc",            1) },  // 0x1900 Nook Inc.
        { 40, new("bey",                "bey",                    2) },  // 0x2800 C.J.
        { 41, new("chy",                "chy",                    3) },  // 0x2900 Flick
        { 42, new("pyn",                "pyn",                    4) },  // 0x2A00 Zipper
        { 43, new("fox",                "fox",                    5) },  // 0x2B00 Redd
        { 44, new("alp",                "alp",                    6) },  // 0x2C00 Reese & Cyrus
        { 45, new("gulB",               "gulB",                   7) },  // 0x2D00 Gullivarrr
        { 46, new("tap",                "tap",                    8) },  // 0x2E00 Luna
        { 47, new("pkn",                "pkn",                    9) },  // 0x2F00 Jack
        { 48, new("xct",                "xct",                    10) }, // 0x3000 Rover
        { 50, new("bpt",                "bpt",                    11) }, // 0x3200 Katrina
        { 51, new("slo",                "slo",                    12) }, // 0x3300 Lief
        { 52, new("spn",                "spn",                    13) }, // 0x3400 Harvey
        { 53, new("man",                "man",                    14) }, // 0x3500 Wardell
        { 54, new("OneroomCardboard",   "npc_paradiseplanning",   15) }, // 0x3600 Paradise Planning
        { 55, new("otg",                "otg",                    16) }, // 0x3700 Lottie
        { 56, new("mnc",                "mnc",                    17) }, // 0x3800 Niko
        { 57, new("kpg",                "npc_hotel",              18) }, // 0x3900 Hotel
        { 60, new("gul",                "gul",                    19) }, // 0x3C00 Gulliver
        { 61, new("gstA",               "gstA",                   20) }, // 0x3D00 Wisp
        { 62, new("hgc",                "hgc",                    21) }, // 0x3E00 Label
        { 63, new("tkkA",               "tkkA",                   22) }, // 0x3F00 K.K.
        { 64, new("boc",                "boc",                    23) }, // 0x4000 Daisy Mae
        { 65, new("SnowCrystal",        "npc_snowboy",            24) }, // 0x4100 Snowboy
        { 66, new("bey",                "bey",                    25) }, // 0x4200 C.J (Duplicate...?)
        { 67, new("chy",                "chy",                    26) }, // 0x4300 Flick (Duplicate...?)
        { 68, new("mol",                "mol",                    27) }, // 0x4400 Resetti
        { 80, new("ott",                "npc_hha",                28) }, // 0x5000 Happy Home Academy Ranking
        { 81, new("Leaf",               "npc_nintendo",           29) }, // 0x5100 Nintendo & Happy Home Academy Welcome
        { 82, new("MoneyBag010",        "npc_bankofnook",         30) }, // 0x5200 Bank of Nook, [island]
        { 84, new("Cardboard",          "npc_nookshopping",       31) }, // 0x5400 Nook Shopping
        { 85, new("PlaneTicket",        "npc_nookmileageprogram", 32) }, // 0x5500 Nook Mileage Program
        { 86, new("Post",               "npc_mom",                33) }, // 0x5600 Mom
        { 87, new("dod",                "npc_dodoairlines",       34) }, // 0x5700 Dodo Airlines
        { 88, new("owl",                "npc_thefarwaymuseum",    35) }, // 0x5800 The Farway Museum
        { 89, new("Leaf",               "npc_nooklinkadmins",     36) }  // 0x5900 NookLink Admins
    };

    public static readonly Dictionary<string, int> BCP47LanguageString = new()
    {
       { "en-US", 0 },
       { "en-GB", 1 },
       { "ja-JP", 2 },
       { "de-DE", 3 },
       { "es-ES", 4 },
       { "fr-FR", 5 },
       { "it-IT", 6 },
       { "ko-KR", 7 },
       { "zh-CN", 8 },
       { "zh-TW", 9 },
    };

    public static List<string> NPCTypeList = new List<string>
    {
        "Player",
        "Villager",
        "NPC"
    };

    public static List<string> MailTypeList = new List<string>
    {
        "Boxed Item",
        "Letter",
    };

    /// <summary>
    /// Maps stationery skin IDs to their corresponding <see cref="StationeryInfo"/> data, including the display name and mapping index.
    /// </summary>
    /// <remarks>
    /// The dictionary key represents the stationery skin code stored at offset <see cref="MailStationerySkin"/> in the mail data.
    /// Each entry contains the localized card name and an index value for various letter stationery designs
    /// such as holiday cards, event cards, and special NPC-branded stationery.
    /// </remarks>
    public record StationeryInfo(string name, int index);
    public static readonly Dictionary<int, StationeryInfo> LetterStationerySkin = new()
    {
        // Multiple sources on official total count of skins...
        // 68 total according to most wikis, 64 on others.
        // 75 according to datamine (including unused(?) T&T logo one)
        { 0,   new("mail00", 0) },
        { 356, new("mail01", 1) },
        { 357, new("mail02", 2) },
        { 358, new("mail03", 3) },
        { 359, new("mail04", 4) },
        { 360, new("mail05", 5) },
        { 361, new("mail06", 6) },
        { 362, new("mail07", 7) },
        { 363, new("mail08", 8) },
        { 364, new("mail09", 9) },
        { 365, new("mail10", 10) },
        { 366, new("mail11", 11) },
        { 367, new("mail12", 12) },
        { 368, new("mail13", 13) },
        { 370, new("mail14", 14) },
        { 371, new("mail15", 15) },
        { 372, new("mail16", 16) },
        { 373, new("mail17", 17) },
        { 374, new("mail18", 18) },
        { 375, new("mail19", 19) },
        { 376, new("mail20", 20) },
        { 377, new("mail21", 21) },
        { 378, new("mail22", 22) },
        { 379, new("mail23", 23) },
        { 380, new("mail24", 24) },
        { 381, new("mail25", 25) },
        { 382, new("mail26", 26) },
        { 383, new("mail27", 27) },
        { 384, new("mail28", 28) },
        { 385, new("mail29", 29) },
        { 386, new("mail30", 30) },
        { 387, new("mail31", 31) },
        { 388, new("mail32", 32) },
        { 389, new("mail33", 33) },
        { 390, new("mail34", 34) },
        { 391, new("mail35", 35) },
        { 392, new("mail36", 36) },
        { 393, new("mail37", 37) },
        { 394, new("mail38", 38) },
        { 395, new("mail39", 39) },
        { 396, new("mail40", 40) },
        { 397, new("mail41", 41) },
        { 398, new("mail42", 42) },
        { 399, new("mail43", 43) },
        { 402, new("mail44", 44) },
        { 403, new("mail45", 45) },
        { 404, new("mail46", 46) },
        { 405, new("mail47", 47) },
        { 406, new("mail48", 48) },
        { 407, new("mail49", 49) },
        { 408, new("mail50", 50) },
        { 409, new("mail51", 51) },
        { 410, new("mail52", 52) },
        { 411, new("mail53", 53) },
        { 412, new("mail54", 54) },
        { 413, new("mail55", 55) },
        { 414, new("mail56", 56) },
        { 416, new("mail57", 57) },
        { 427, new("mail58", 58) },
        { 428, new("mail59", 59) },
        { 429, new("mail60", 60) },
        { 430, new("mail61", 61) },
        { 431, new("mail62", 62) },
        { 432, new("mail63", 63) },
        { 433, new("mail64", 64) },
        { 434, new("mail65", 65) },
        { 435, new("mail66", 66) },
        { 437, new("mail67", 67) },
        { 438, new("mail68", 68) },
        { 439, new("mail69", 69) },
        { 440, new("mail70", 70) },
        { 443, new("mail71", 71) },
        { 444, new("mail72", 72) },
        { 445, new("mail73", 73) },
        { 448, new("mail74", 74) },
    };
}


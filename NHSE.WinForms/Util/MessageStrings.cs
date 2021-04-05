// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
namespace NHSE.WinForms
{
    public static class MessageStrings
    {
        public static string MsgBackupCreateLocation { get; set; } = "NHSE can perform automatic backups if you create a folder with the name '{0}' in the same folder as the executable.";
        public static string MsgBackupCreateQuestion { get; set; } = "Would you NHSE to automatically keep a backup of your save data?";

        public static string MsgDataSizeMismatchImport { get; set; } = "The size of the imported file (0x{0:X}) does not match the required size (0x{1:X}).";
        public static string MsgDataSizeMismatchRAM { get; set; } = "Read size (0x{0:X}) != Write size (0x{1:X}).";
        public static string MsgDataDidNotOriginateFromHost_0 { get; set; } = "Imported data did not originate from Villager0 ({0})'s data.";

        public static string MsgAskUpdateValues { get; set; } = "Update values?";
        public static string MsgAskContinue { get; set; } = "Continue?";
        public static string MsgAskWriteAnyway { get; set; } = "Write anyway?";
        public static string MsgAskExportResultToClipboard { get; set; } = "Export results to clipboard?";
        public static string MsgCanceling { get; set; } = "Canceling:";
        public static string MsgInvalidHexValue { get; set; } = "Bad hex value.";
        public static string MsgImportDirectoryDoesNotExist { get; set; } = "Directory does not exist!";
        public static string MsgNoPictureLoaded { get; set; } = "No picture loaded.";

        public static string MsgSaveDataImportFail { get; set; } = "Unable to open the folder that contains the save file.";
        public static string MsgSaveDataImportSuggest { get; set; } = "Try moving it to another location and opening from there.";
        public static string MsgSaveDataExportSuccess { get; set; } = "Saved all save data!";
        public static string MsgSaveDataExportFail { get; set; } = "Unable to save files to their original location.";
        public static string MsgSaveDataHashesValid { get; set; } = "Hashes are valid.";
        public static string MsgSaveDataSizeMismatch { get; set; } = "Save file sizes appear to be incorrect.";

        public static string MsgMoveOut { get; set; } = "Are you trying to make the Villager move out?";
        public static string MsgMoveOutSuggest { get; set; } = "If so, set the Event Flag (024 - ForceMoveOut) to 1 so that the Villager is removed by the game.";
        public static string MsgMoveOutAll { get; set; } = "This will check the 'Moving Out' box for all Villagers.";

        public static string MsgFieldItemRemoveAsk { get; set; } = "Are you sure you want to remove {0}?";
        public static string MsgFieldItemRemoveNone { get; set; } = "Nothing removed (none found).";
        public static string MsgFieldItemRemoveCount { get; set; } = "Removed {0} from the map.";
        public static string MsgFieldItemModifyAsk { get; set; } = "Are you sure you want to {0}?";
        public static string MsgFieldItemModifyNone { get; set; } = "Nothing modified (none found).";
        public static string MsgFieldItemModifyCount { get; set; } = "Modified {0} tiles on the map.";
        public static string MsgFieldItemUnsupportedLayer2Tile { get; set; } = "Unsupported Layer2 items detected.";
        public static string MsgFieldItemNoNHI { get; set; } = "No .nhi file selected to import!";

        public static string MsgSysBotInfo { get; set; } = "This SysBot reads and writes RAM directly to your game when called to Read/Write.";
        public static string MsgSysBotRequired { get; set; } = "Using this functionality requires the sys-botbase sysmodule running on the console. Your console must be on the same network as the PC running this program.";

        public static string MsgTerrainSetElevation0 { get; set; } = "Set the elevation of all tiles on the map to 0?";
        public static string MsgTerrainSetAll { get; set; } = "Set the tile from the Tile Editor to all tiles on the map?";
        public static string MsgTerrainSetAllSkipExterior { get; set; } = "Do you want to skip the tiles in exterior acres (beach/rocks)?";

        public static string MsgVillagerFriendshipMax { get; set; } = "Do you want to set all Villager Friendship memories to 255?";

        public static string MsgVillagerReplaceNoText { get; set; } = "Clipboard: No text found! Expected internal villager name.";
        public static string MsgVillagerReplaceOutdatedSaveFormat { get; set; } = "Save file is not up to date with latest villager format. Please update in-game.";
        public static string MsgVillagerReplaceUnknownName { get; set; } = "Clipboard: {0} is not a valid internal villager name.";
    }
}

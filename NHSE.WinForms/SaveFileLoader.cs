using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms;

public static class SaveFileLoader
{
    public const string BackupFolderName = "bak";
    private static string BackupPath => Path.Combine(Program.WorkingDirectory, BackupFolderName);

    public static bool TryGetSaveFile(string path, [NotNullWhen(true)] out HorizonSave? sav)
    {
#if !DEBUG
        try
#endif
        {
            return TryGetSaveFileInternal(path, out sav);
        }
#if !DEBUG
        catch (Exception ex)
        {
            sav = null;
            WinFormsUtil.Error(ex.Message);
            return false;
        }
#endif
    }

    private static bool TryGetSaveFileInternal(string path, [NotNullWhen(true)] out HorizonSave? sav)
    {
        if (Directory.Exists(path))
            return OpenSaveFile(path, out sav);

        // Load zip files differently
        var ext = Path.GetExtension(path);
        if (ext.Equals(".zip", StringComparison.OrdinalIgnoreCase) && new FileInfo(path).Length < 20 * 1024 * 1024) // less than 20MB
        {
            sav = HorizonSave.FromZip(path);
            return TryValidateSaveFile(sav);
        }

        // Try loading from the parent folder if it's the .dat file
        if (ext is not ".dat")
        {
            sav = null;
            return false;
        }

        var dir = Path.GetDirectoryName(path);
        if (dir is null || !Directory.Exists(dir)) // ya never know
        {
            WinFormsUtil.Error(MessageStrings.MsgSaveDataImportFail, MessageStrings.MsgSaveDataImportSuggest);
            sav = null;
            return false;
        }

        return OpenSaveFile(dir, out sav);
    }

    private static bool OpenSaveFile(string path, [NotNullWhen(true)] out HorizonSave? sav)
    {
        sav = HorizonSave.FromFolder(path);
        if (!TryValidateSaveFile(sav))
            return false;

        var settings = Program.Settings;
        settings.LastFilePath = path;
        CheckBackupPrompt(settings);

        if (settings.AutomaticBackup)
            BackupSaveFile(sav, path, BackupPath);

        return true;
    }

    private static void CheckBackupPrompt(ApplicationSettings settings)
    {
        if (settings.BackupPrompted)
            return;

        settings.BackupPrompted = true;
        if (Directory.Exists(BackupFolderName))
        {
            settings.AutomaticBackup = true; // previously enabled, settings reset?
            return;
        }

        // Prompt user to enable automatic backups
        settings.AutomaticBackup = PromptBackupEnable(BackupFolderName);
    }

    private static bool PromptBackupEnable(string destFolder)
    {
        var line1 = string.Format(MessageStrings.MsgBackupCreateLocation, destFolder);
        var line2 = MessageStrings.MsgBackupCreateQuestion;
        var prompt = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, line1, line2);
        return prompt == DialogResult.Yes;
    }

    private static bool TryValidateSaveFile(HorizonSave file)
    {
        bool sized = file.ValidateSizes();
        if (!sized)
        {
            var prompt = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, MessageStrings.MsgSaveDataSizeMismatch, MessageStrings.MsgAskContinue);
            if (prompt != DialogResult.Yes)
                return false;
        }
        var isAnyHashBad = file.GetInvalidHashes().Any();
        if (isAnyHashBad)
        {
            var prompt = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, MessageStrings.MsgSaveDataHashMismatch, MessageStrings.MsgAskContinue);
            if (prompt != DialogResult.Yes)
                return false;
        }
        return true;
    }

    private static void BackupSaveFile(HorizonSave file, string path, string bak)
    {
        Directory.CreateDirectory(bak);
        var dest = Path.Combine(bak, file.GetBackupFolderTitle());
        if (!Directory.Exists(dest))
            FileUtil.CopyFolder(path, dest);
    }
}
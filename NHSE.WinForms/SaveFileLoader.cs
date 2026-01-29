using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms;

/// <summary>
/// Loader for <see cref="HorizonSave"/> files.
/// </summary>
public static class SaveFileLoader
{
    private const string BackupFolderName = "bak";
    private static string BackupPath => Path.Combine(Program.WorkingDirectory, BackupFolderName);

    /// <summary>
    /// Attempts to load a <see cref="HorizonSave"/> file from the specified path.
    /// </summary>
    /// <param name="path">The file system path to the save file to load.</param>
    /// <param name="sav">When this method returns, contains the initialized save file if the operation succeeds.</param>
    /// <returns><see langword="true"/> if the save file was loaded successfully; otherwise, <see langword="false"/>.</returns>
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
        if (ext.Equals(".zip", StringComparison.OrdinalIgnoreCase))
        {
            var length = new FileInfo(path).Length;
            const int maxSize = 20 * 1024 * 1024;
            if (length < maxSize)
            {
                sav = HorizonSave.FromZip(path);
                return TryValidateSaveFile(sav);
            }
        }
        // Try loading from the parent folder if it's the .dat file
        else if (ext.Equals(".dat", StringComparison.OrdinalIgnoreCase))
        {
            var dir = Path.GetDirectoryName(path);
            if (Directory.Exists(dir))
                return OpenSaveFile(dir, out sav);
        }

        // Nice try, we failed.
        WinFormsUtil.Error(MessageStrings.MsgSaveDataImportFail, MessageStrings.MsgSaveDataImportSuggest);
        sav = null;
        return false;

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
        if (!file.ValidateSizes())
        {
            var prompt = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, MessageStrings.MsgSaveDataSizeMismatch, MessageStrings.MsgAskContinue);
            if (prompt != DialogResult.Yes)
                return false;
        }
        if (file.GetInvalidHashes().Any())
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
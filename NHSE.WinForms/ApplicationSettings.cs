using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace NHSE.WinForms;

/// <summary>
/// Application settings stored as JSON.
/// </summary>
public sealed class ApplicationSettings
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() },
    };

    /// <summary>
    /// Last opened save file path.
    /// </summary>
    public string LastFilePath { get; set; } = string.Empty;

    /// <summary>
    /// SysBot connection and RAM editing settings.
    /// </summary>
    public SysBotSettings SysBot { get; set; } = new();

    /// <summary>
    /// Whether to automatically backup save files.
    /// </summary>
    public bool AutomaticBackup { get; set; } = true;

    /// <summary>
    /// Whether the backup prompt has been shown.
    /// </summary>
    public bool BackupPrompted { get; set; }

    /// <summary>
    /// UI language code (e.g., "en", "de", "jp").
    /// </summary>
    public string Language { get; set; } = "en";

    /// <summary>
    /// Dark mode setting.
    /// </summary>
    public SystemColorMode DarkMode { get; set; } = SystemColorMode.System;

    /// <summary>
    /// Loads settings from disk, or creates default settings if the file doesn't exist.
    /// </summary>
    /// <param name="path">Full path to the settings file.</param>
    public static ApplicationSettings Load(string path)
    {
        if (!File.Exists(path))
            return new ApplicationSettings();

        try
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<ApplicationSettings>(json, JsonOptions) ?? new ApplicationSettings();
        }
        catch
        {
            // If deserialization fails, return defaults
            return new ApplicationSettings();
        }
    }

    /// <summary>
    /// Saves the current settings to disk.
    /// </summary>
    /// <param name="path">Full path to the settings file.</param>
    public void Save(string path)
    {
        try
        {
            var json = JsonSerializer.Serialize(this, JsonOptions);
            File.WriteAllText(path, json);
        }
        catch
        {
            // Silently fail if we can't save settings
        }
    }
}

/// <summary>
/// SysBot connection and RAM editing settings.
/// </summary>
public sealed class SysBotSettings
{
    /// <summary>
    /// SysBot IP address.
    /// </summary>
    public string IP { get; set; } = "192.168.0.1";

    /// <summary>
    /// SysBot port number.
    /// </summary>
    public int Port { get; set; } = 6000;

    /// <summary>
    /// Whether the SysBot prompt has been shown.
    /// </summary>
    public bool Prompted { get; set; }

    /// <summary>
    /// RAM offset for pouch editing.
    /// </summary>
    public uint PouchOffset { get; set; }

    /// <summary>
    /// RAM offset for generic editing.
    /// </summary>
    public uint GenericOffset { get; set; }
}

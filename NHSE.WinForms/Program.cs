using System;
using System.IO;
using System.Windows.Forms;

namespace NHSE.WinForms;

internal static class Program
{
    /// <summary>
    /// Directory where the executable is located.
    /// </summary>
    private static readonly string WorkingDirectory = Path.GetDirectoryName(Environment.ProcessPath) ?? "";

    /// <summary>
    /// Settings file name.
    /// </summary>
    private const string ConfigFileName = "settings.json";

    /// <summary>
    /// Full path to the settings file.
    /// </summary>
    private static string PathConfig => Path.Combine(WorkingDirectory, ConfigFileName);

    /// <summary>
    /// Application settings, loaded at startup.
    /// </summary>
    public static ApplicationSettings Settings { get; }

    /// <summary>
    /// Static constructor to load settings as early as possible.
    /// </summary>
    static Program()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Settings = ApplicationSettings.Load(PathConfig);
        WinFormsUtil.SetApplicationTheme(Settings.DarkMode);
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        var args = Environment.GetCommandLineArgs();
        if (args.Contains("-dark"))
            WinFormsUtil.SetApplicationTheme(SystemColorMode.Dark);
        Application.Run(new Main());
    }

    public static void SaveSettings() => Settings.Save(PathConfig);
}
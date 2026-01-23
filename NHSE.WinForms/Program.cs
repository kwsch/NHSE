using NHSE.WinForms.Properties;
using System;
using System.Windows.Forms;

namespace NHSE.WinForms;

internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var args = Environment.GetCommandLineArgs();
        if (args.Length > 1)
        {
            if (args.Contains("-dark"))
            {
                WinFormsUtil.SetApplicationTheme(2);
                Settings.Default.DarkMode = "2";
                Settings.Default.Save();
            }
        }

        Application.Run(new Main());
    }
}
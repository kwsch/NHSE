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
                Application.SetColorMode(SystemColorMode.Dark);
        }

        Application.Run(new Main());
    }
}
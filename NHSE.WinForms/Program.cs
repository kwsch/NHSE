using System;
using System.IO;
using System.Windows.Forms;

#if !DEBUG
using System.Diagnostics.CodeAnalysis;
using System.Threading;
#endif

namespace NHSE.WinForms;

internal static class Program
{
    /// <summary>
    /// Directory where the executable is located.
    /// </summary>
    public static readonly string WorkingDirectory = Path.GetDirectoryName(Environment.ProcessPath) ?? "";

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
#if !DEBUG
        Application.ThreadException += UIThreadException;
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
#endif
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Settings = ApplicationSettings.Load(PathConfig);
        Application.SetColorMode(Settings.DarkMode);
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main() => Application.Run(new Main());

    public static void SaveSettings() => Settings.Save(PathConfig);


#if !DEBUG
    private static void Error(string msg) => MessageBox.Show(msg, "NHSE Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

    private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
    {
        DialogResult result;
        try
        {
            var e = t.Exception;
            string errorMessage = GetErrorMessage(e);
            Error(errorMessage);
            result = DialogResult.OK;
        }
        catch (Exception reportingException)
        {
            HandleReportingException(t.Exception, reportingException);
            result = DialogResult.Abort;
        }

        if (result == DialogResult.Abort)
            Application.Exit();
    }

    private static string GetErrorMessage(Exception e)
    {
        Console.WriteLine(e);
        return e.StackTrace ?? e.Message;
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        var ex = e.ExceptionObject as Exception;
        try
        {
            if (IsCoreMissing(ex))
            {
                Error("You have installed NHSE incorrectly. Please ensure you have unzipped all files before running.");
            }
            else if (ex is not null)
            {
                Error(GetErrorMessage(ex));
            }
            else
            {
                Error("A fatal non-UI error has occurred in NHSE, and the details could not be displayed.  Please report this to the author.");
            }
        }
        catch (Exception reportingException)
        {
            HandleReportingException(ex, reportingException);
        }
    }

    private static void HandleReportingException(Exception? ex, Exception reportingException)
    {
        try
        {
            EmergencyErrorLog(ex, reportingException);
        }
        catch
        {
            // Ignore.
        }
        if (reportingException is FileNotFoundException x && x.FileName?.StartsWith("NHSE.Core") == true)
        {
            Error("Could not locate NHSE.Core.dll. Make sure you're running NHSE together with its code library. Usually caused when all files are not extracted.");
            return;
        }
        try
        {
            Error("A fatal non-UI error has occurred in NHSE, and there was a problem displaying the details.  Please report this to the author.");
        }
        finally
        {
            Application.Exit();
        }
    }

    private static bool EmergencyErrorLog(Exception? originalException, Exception errorHandlingException)
    {
        try
        {
            var message = (originalException?.ToString() ?? "null first exception") + Environment.NewLine + errorHandlingException;
            File.WriteAllText($"NHSE_Error_Report {DateTime.Now:yyyyMMddHHmmss}.txt", message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(errorHandlingException);
            Console.WriteLine(ex);
            return false;
        }
        return true;
    }

    private static bool IsCoreMissing([NotNullWhen(true)] Exception? ex)
    {
        return ex is FileNotFoundException { FileName: { } n } && n.Contains("NHSE.Core");
    }
#endif
}
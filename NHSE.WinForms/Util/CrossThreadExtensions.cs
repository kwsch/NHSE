using System;
using System.Windows.Forms;

namespace NHSE.WinForms;

public static class CrossThreadExtensions
{
    /// <summary>
    /// Helper function to perform an action on a Control's thread safely.
    /// </summary>
    public static void PerformSafely(this Control target, Action action)
    {
        if (target.InvokeRequired)
        {
            target.Invoke(action);
        }
        else
        {
            action();
        }
    }
}
using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NHSE.WinForms;

internal static class WinFormsUtil
{
    internal static void TranslateInterface(Control form, string lang) => form.TranslateInterface(lang);

    #region Message Displays
    /// <summary>
    /// Displays a dialog showing the details of an error.
    /// </summary>
    /// <param name="lines">User-friendly message about the error.</param>
    /// <returns>The <see cref="DialogResult"/> associated with the dialog.</returns>
    internal static DialogResult Error(params string[] lines)
    {
        System.Media.SystemSounds.Hand.Play();
        string msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
        return MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    internal static DialogResult Alert(params string[] lines) => Alert(true, lines);

    internal static DialogResult Alert(bool sound, params string[] lines)
    {
        if (sound)
            System.Media.SystemSounds.Asterisk.Play();
        string msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
        return MessageBox.Show(msg, "Alert", MessageBoxButtons.OK, sound ? MessageBoxIcon.Information : MessageBoxIcon.None);
    }

    internal static DialogResult Prompt(MessageBoxButtons btn, params string[] lines)
    {
        System.Media.SystemSounds.Asterisk.Play();
        string msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
        return MessageBox.Show(msg, "Prompt", btn, MessageBoxIcon.Question);
    }
    #endregion

    /// <summary>
    /// Searches upwards through the control hierarchy to find the first parent control of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="sender">Child control to start searching from.</param>
    /// <param name="result">The first parent control of type <typeparamref name="T"/>, or null if none found.</param>
    public static bool TryGetUnderlying<T>(object sender, [NotNullWhen(true)] out T? result) where T : class
    {
        while (true)
        {
            switch (sender)
            {
                case T p:
                    result = p;
                    return true;
                case ToolStripItem { Owner: { } o }:
                    sender = o;
                    continue;
                case ContextMenuStrip { SourceControl: { } s }:
                    sender = s;
                    continue;
                default:
                    result = null;
                    return false;
            }
        }
    }

    /// <summary>
    /// Gets the selected value of the input <see cref="cb"/>. If no value is selected, will return 0.
    /// </summary>
    /// <param name="cb">ComboBox to retrieve value for.</param>
    internal static int GetIndex(ListControl cb) => (int)(cb.SelectedValue ?? 0);

    public static T? FirstFormOfType<T>() where T : Form => (T?)Application.OpenForms.Cast<Form>().FirstOrDefault(form => form is T);

    public static void RemoveDropCB(object sender, KeyEventArgs e) => ((ComboBox)sender).DroppedDown = false;

    /// <summary>
    /// Centers the <see cref="child"/> horizontally and vertically so that its center is the same as the <see cref="parent"/>'s center.
    /// </summary>
    /// <param name="child"></param>
    /// <param name="parent"></param>
    internal static void CenterToForm(this Control child, Control parent) => child.Location = GetCenterLocation(child, parent);

    internal static Point GetCenterLocation(Control child, Control parent)
    {
        int x = parent.Location.X + ((parent.Width - child.Width) / 2);
        int y = parent.Location.Y + ((parent.Height - child.Height) / 2);
        var location = new Point(Math.Max(x, 0), Math.Max(y, 0));
        return location;
    }

    /// <summary>
    /// Sets the application color mode based on the <paramref name="theme"/> <typeparamref name="int"/> passed to it and stores it in the application <see cref="Settings"/>.
    /// </summary>
    /// <param name="theme"></param>
    public static void SetApplicationTheme(SystemColorMode theme)
    {
        Application.SetColorMode(theme);
        Program.Settings.DarkMode = theme;
    }
}
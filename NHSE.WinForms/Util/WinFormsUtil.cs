using System;
using System.Linq;
using System.Windows.Forms;

namespace NHSE.WinForms
{
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

        public static T? GetUnderlyingControl<T>(object sender) where T : Control
        {
            while (true)
            {
                switch (sender)
                {
                    case ToolStripItem t:
                        sender = t.Owner;
                        continue;
                    case ContextMenuStrip c:
                        sender = c.SourceControl;
                        continue;
                    case T p:
                        return p;
                    default:
                        return default;
                }
            }
        }

        /// <summary>
        /// Gets the selected value of the input <see cref="cb"/>. If no value is selected, will return 0.
        /// </summary>
        /// <param name="cb">ComboBox to retrieve value for.</param>
        internal static int GetIndex(ListControl cb) => (int)(cb?.SelectedValue ?? 0);

        public static T? FirstFormOfType<T>() where T : Form => (T?)Application.OpenForms.Cast<Form>().FirstOrDefault(form => form is T);
    }
}

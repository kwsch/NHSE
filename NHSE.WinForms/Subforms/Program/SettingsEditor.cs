using System.Windows.Forms;
using NHSE.WinForms.Properties;

namespace NHSE.WinForms
{
    public partial class SettingsEditor : Form
    {
        private readonly Settings obj;

        public SettingsEditor()
        {
            obj = Settings.Default;
            InitializeComponent();
            PG_Settings.SelectedObject = obj;
        }

        private void SettingsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            obj.Save();
        }

        private void SettingsEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && ModifierKeys == Keys.Control)
                Close();
        }
    }
}

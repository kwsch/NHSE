using System.Windows.Forms;

namespace NHSE.WinForms;

public partial class SettingsEditor : Form
{
    public SettingsEditor()
    {
        InitializeComponent();
        PG_Settings.SelectedObject = Program.Settings;
    }

    private void SettingsEditor_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Settings are saved when Main form closes
    }

    private void SettingsEditor_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.W && ModifierKeys == Keys.Control)
            Close();
    }
}
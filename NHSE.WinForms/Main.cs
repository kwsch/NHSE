using System;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    /// <summary>
    /// Simple launcher for opening a save file.
    /// </summary>
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // Flash to front
            BringToFront();
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private static void Open(HorizonSave file) => new Editor(file).Show();

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link)) // external file
                e.Effect = DragDropEffects.Copy;
            else if (e.Data != null) // within
                e.Effect = DragDropEffects.Move;
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files == null || files.Length == 0)
                return;
            Open(files[0]);
            e.Effect = DragDropEffects.Copy;
        }

        private void Menu_Open(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                Open(fbd.SelectedPath);
        }

        private static void Open(string path)
        {
            if ((ModifierKeys & Keys.Control) != 0)
            {
                // Detect save file from SD cards?
            }
            try
            {
                var file = new HorizonSave(path);
                Open(file);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message);
            }
        }
    }
}

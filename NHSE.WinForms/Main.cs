using System;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Injection;
using NHSE.Sprites;

namespace NHSE.WinForms;

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

        var args = Environment.GetCommandLineArgs();
        foreach (var arg in args)
        {
            if (Directory.Exists(arg) || File.Exists(arg))
                TryOpenSaveFile(arg);
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        Program.SaveSettings();
        base.OnFormClosing(e);
    }

    private void Main_DragEnter(object sender, DragEventArgs e)
    {
        if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link)) // external file
            e.Effect = DragDropEffects.Copy;
        else if (e.Data != null) // within
            e.Effect = DragDropEffects.Move;
    }

    private void Main_DragDrop(object sender, DragEventArgs e)
    {
        var files = (string[]?)e.Data?.GetData(DataFormats.FileDrop);
        if (files is not { Length: not 0 })
            return;
        TryOpenSaveFile(files[0]);
        e.Effect = DragDropEffects.Copy;
    }

    private void Menu_Open(object sender, EventArgs e)
    {
        if ((ModifierKeys & Keys.Control) != 0)
        {
            // Detect save file from SD cards?
        }
        else if ((ModifierKeys & Keys.Shift) != 0)
        {
            var path = Program.Settings.LastFilePath;
            if (Directory.Exists(path))
            {
                TryOpenSaveFile(path);
                return;
            }
        }

        using var ofd = new OpenFileDialog();
        ofd.Title = "Open main.dat ...";
        ofd.Filter = "New Horizons Save File (main.dat)|main.dat";
        ofd.FileName = "main.dat";
        if (ofd.ShowDialog() == DialogResult.OK)
            TryOpenSaveFile(ofd.FileName);
    }

    private void Main_KeyDown(object sender, KeyEventArgs e)
    {
        if (ModifierKeys != Keys.Control)
        {
#if DEBUG
            if (ModifierKeys == (Keys.Control | Keys.Alt) && e.KeyCode == Keys.D)
                DevUtil.UpdateAll();
#endif
            return;
        }

        switch (e.KeyCode)
        {
            case Keys.O:
            {
                Menu_Open(sender, e);
                break;
            }
            case Keys.I:
            {
                ItemSprite.Initialize(GameInfo.GetStrings("en").itemlist);
                var items = new Item[40];
                for (int i = 0; i < items.Length; i++)
                    items[i] = new Item(Item.NONE);
                using var editor = new PlayerItemEditor(items, 10, 4, true);
                editor.ShowDialog();
                break;
            }
            case Keys.H:
            {
                using var editor = new SysBotRAMEdit(InjectionType.Generic);
                editor.ShowDialog();
                break;
            }
            case Keys.P:
            {
                using var editor = new SettingsEditor();
                editor.ShowDialog();
                break;
            }
        }
    }

    private static bool TryOpenSaveFile(string path)
    {
        if (!SaveFileLoader.TryGetSaveFile(path, out var sav))
            return false;
        var editor = new Editor(sav);
        editor.Show();
        return true;
    }
}
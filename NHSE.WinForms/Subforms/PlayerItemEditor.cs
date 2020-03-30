using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class PlayerItemEditor<T> : Form where T : Item
    {
        private readonly IReadOnlyList<T> Items;
        private readonly Action LoadItems;

        public PlayerItemEditor(IReadOnlyList<T> array, int width, int height)
        {
            InitializeComponent();
            Items = array;

            var Editor = new ItemGridEditor(ItemEditor, Items) {Dock = DockStyle.Fill};
            Editor.InitializeGrid(width, height);
            PAN_Items.Controls.Add(Editor);

            ItemEditor.Initialize(GameInfo.Strings.ItemDataSource);
            Editor.LoadItems();
            DialogResult = DialogResult.Cancel;
            LoadItems = () => Editor.LoadItems();
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void B_Dump_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Inventory (*.nhi)|*.nhi|All files (*.*)|*.*",
                FileName = "items.nhi",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            var bytes = Items.SetArray(Items[0].ToBytesClass().Length);
            File.WriteAllBytes(sfd.FileName, bytes);
        }

        private void B_Load_Click(object sender, EventArgs e)
        {
            using var sfd = new OpenFileDialog
            {
                Filter = "New Horizons Inventory (*.nhi)|*.nhi|All files (*.*)|*.*",
                FileName = "items.nhi",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var data = File.ReadAllBytes(sfd.FileName);
            var import = data.GetArray<T>(Items[0].ToBytesClass().Length);
            for (int i = 0; i < Items.Count && i < import.Length ; i++)
                Items[i].CopyFrom(import[i]);

            LoadItems();
            System.Media.SystemSounds.Asterisk.Play();
        }
    }
}

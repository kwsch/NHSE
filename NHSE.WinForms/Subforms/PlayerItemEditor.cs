using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class PlayerItemEditor : Form
    {
        private readonly IReadOnlyList<Item> Items;
        private readonly Action LoadItems;

        public PlayerItemEditor(IReadOnlyList<Item> array, int width, int height)
        {
            InitializeComponent();
            Items = array;

            var items = GameInfo.Strings.itemlist.ToArray();

            var set = new HashSet<string>();
            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                if (string.IsNullOrEmpty(item))
                    items[i] = $"(Item #{i:000})";
                else if (set.Contains(item))
                    items[i] += $" (#{i:000})";
                else
                    set.Add(item);
            }

            var Editor = new ItemGridEditor(ItemEditor, Items, items) {Dock = DockStyle.Fill};
            Editor.InitializeGrid(width, height);
            PAN_Items.Controls.Add(Editor);

            ItemEditor.Initialize(items);
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
            var bytes = Item.SetArray(Items);
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
            var import = Item.GetArray(data);
            for (int i = 0; i < Items.Count && i < import.Length ; i++)
                Items[i].CopyFrom(import[i]);

            LoadItems();
            System.Media.SystemSounds.Asterisk.Play();
        }
    }
}

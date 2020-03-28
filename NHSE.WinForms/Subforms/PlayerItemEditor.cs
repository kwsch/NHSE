using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class PlayerItemEditor : Form
    {
        private readonly Player Player;
        private readonly InventorySet[] Inventory;
        private readonly string[] items;

        public PlayerItemEditor(Player player)
        {
            InitializeComponent();

            Player = player;
            Inventory = GetInventory(player);
            items = GameInfo.Strings.itemlist.ToArray(); // simple copy, we're gonna mutate

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

            ItemEditor.Initialize(items);
            CreateTabs();
        }

        private void CreateTabs()
        {
            var i = items;
            foreach (var p in Inventory)
            {
                var tab = new TabPage { Name = $"Tab_{p.Type}", Text = p.Type.ToString() };
                var grid = new ItemGridEditor(ItemEditor, p.Items, i) { Dock = DockStyle.Fill };
                grid.InitializeGrid(5, 4);
                tab.Controls.Add(grid);
                TC_Groups.TabPages.Add(tab);
                TC_Groups.ShowToolTips = true;
                tab.ToolTipText = p.Type.ToString();
            }
        }

        private static InventorySet[] GetInventory(Player player)
        {
            return new[]
            {
                new InventorySet(InventoryType.Pocket1, player.Personal.Pocket2),
                new InventorySet(InventoryType.Pocket2, player.Personal.Pocket1),
                new InventorySet(InventoryType.Storage, player.Personal.Storage),
            };
        }

        private void SetInventory(Player player)
        {
            player.Personal.Pocket2 = Inventory[0].Items;
            player.Personal.Pocket1 = Inventory[1].Items;
            player.Personal.Storage = Inventory[2].Items;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            SetInventory(Player);
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class InventoryEditor : Form
    {
        private readonly Player Player;
        private readonly InventorySet[] Inventory;
        private readonly string[] items;

        // assume that all pouches have the same amount of columns
        private int ColumnItem;
        private int ColumnCount;
        private int ColumnUse;
        private int ColumnFlag1;
        private int ColumnFlag2;
        private int ColumnFlag3;

        public InventoryEditor(Player player)
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

            CreateViews();
            LoadItems();
        }

        private static InventorySet[] GetInventory(Player player)
        {
            return new[]
            {
                new InventorySet(InventoryType.Pocket1, player.Personal.Pocket1),
                new InventorySet(InventoryType.Pocket2, player.Personal.Pocket2),
                new InventorySet(InventoryType.Storage, player.Personal.Storage),
            };
        }

        private void SetInventory(Player player)
        {
            player.Personal.Pocket1 = Inventory[0].Items;
            player.Personal.Pocket2 = Inventory[1].Items;
            player.Personal.Storage = Inventory[2].Items;
        }

        private void CreateViews()
        {
            foreach (var p in Inventory)
            {
                var tab = new TabPage {Name = $"Tab_{p.Type}", Text = p.Type.ToString()};
                var dgv = GetDGV(p);
                ControlGrids.Add(p.Type, dgv);
                tab.Controls.Add(dgv);
                TC_Groups.TabPages.Add(tab);
                TC_Groups.ShowToolTips = true;
                tab.ToolTipText = p.Type.ToString();
            }
        }

        private DataGridView GetDGV(InventorySet pouch)
        {
            // Add DataGrid
            var dgv = GetBaseDataGrid(pouch);

            // Get Columns
            var item = GetItemColumn(ColumnItem = 0);
            var count = GetCountColumn(ColumnCount = 1);
            var use = GetUseColumn(ColumnUse = 2);
            var flag1 = GetFlagColumn(ColumnFlag1 = 3, "Flags0");
            var flag2 = GetFlagColumn(ColumnFlag2 = 4, "Flags1");
            var flag3 = GetFlagColumn(ColumnFlag3 = 5, "Flags2");
            dgv.Columns.Add(item);
            dgv.Columns.Add(count);
            dgv.Columns.Add(use);
            dgv.Columns.Add(flag1);
            dgv.Columns.Add(flag2);
            dgv.Columns.Add(flag3);

            // Populate with rows
            var itemarr = items;
            item.Items.AddRange(itemarr);

            dgv.Rows.Add(pouch.Items.Count);
            dgv.CancelEdit();

            return dgv;
        }

        private static DataGridView GetBaseDataGrid(InventorySet pouch)
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                Text = pouch.Type.ToString(),
                Name = "DGV_" + pouch.Type,

                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                RowHeadersVisible = false,
                MultiSelect = false,
                ShowEditingIcon = false,

                EditMode = DataGridViewEditMode.EditOnEnter,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                SelectionMode = DataGridViewSelectionMode.CellSelect,
                CellBorderStyle = DataGridViewCellBorderStyle.None,
            };
        }

        private static DataGridViewComboBoxColumn GetItemColumn(int c)
        {
            return new DataGridViewComboBoxColumn
            {
                HeaderText = "Item",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DisplayIndex = c,
                Width = 135,
                FlatStyle = FlatStyle.Flat,
            };
        }

        private static DataGridViewColumn GetCountColumn(int c)
        {
            return new DataGridViewTextBoxColumn
            {
                HeaderText = "Count",
                DisplayIndex = c,
                Width = 45,
                DefaultCellStyle = {Alignment = DataGridViewContentAlignment.MiddleCenter},
                MaxInputLength = 3,
            };
        }

        private static DataGridViewColumn GetUseColumn(int c)
        {
            return new DataGridViewTextBoxColumn
            {
                HeaderText = "Uses",
                DisplayIndex = c,
                Width = 45,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
                MaxInputLength = 3,
            };
        }

        private static DataGridViewColumn GetFlagColumn(int c, string name)
        {
            return new DataGridViewTextBoxColumn
            {
                HeaderText = name,
                DisplayIndex = c,
                Width = 45,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
                MaxInputLength = 3,
            };
        }

        private void LoadItems()
        {
            foreach (var list in Inventory)
            {
                var dgv = GetGrid(list.Type);
                GetList(dgv, list);
            }
        }

        private readonly Dictionary<InventoryType, DataGridView> ControlGrids = new Dictionary<InventoryType, DataGridView>();
        private DataGridView GetGrid(InventoryType type) => ControlGrids[type];
        private DataGridView GetGrid(int group) => ControlGrids[Inventory[group].Type];

        private void SetInventory()
        {
            foreach (var pouch in Inventory)
            {
                var dgv = GetGrid(pouch.Type);
                SetList(dgv, pouch);
            }
        }

        private void GetList(DataGridView dgv, InventorySet pouch)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var cells = dgv.Rows[i].Cells;

                var item = pouch.Items[i];

                var id = item.ItemId;
                if (id == Item.NONE)
                    id = 0;
                cells[ColumnItem].Value = items[id];
                cells[ColumnCount].Value = item.Count;
                cells[ColumnUse].Value = item.UseCount;
                cells[ColumnFlag1].Value = item.Flags0;
                cells[ColumnFlag2].Value = item.Flags1;
                cells[ColumnFlag3].Value = item.Flags2;
            }
        }

        private void SetList(DataGridView dgv, InventorySet pouch)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var cells = dgv.Rows[i].Cells;
                var str = cells[ColumnItem].Value.ToString();
                var itemindex = Array.IndexOf(items, str);

                int.TryParse(cells[ColumnCount].Value?.ToString(), out int itemcnt);
                int.TryParse(cells[ColumnUse].Value?.ToString(), out int uses);
                int.TryParse(cells[ColumnFlag1].Value?.ToString(), out int flags1);
                int.TryParse(cells[ColumnFlag2].Value?.ToString(), out int flags2);
                int.TryParse(cells[ColumnFlag3].Value?.ToString(), out int flags3);

                var item = pouch.Items[i];

                if (itemindex <= 0)
                    itemindex = Item.NONE;

                item.ItemId = (ushort)itemindex;
                item.Count = (byte)itemcnt;
                item.UseCount = (ushort)uses;
                item.Flags0 = (byte)flags1;
                item.Flags1 = (byte)flags2;
                item.Flags1 = (byte)flags3;
            }
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            SetInventory();
            SetInventory(Player);
            Close();
        }

        private void B_Copy_Click(object sender, EventArgs e)
        {
            var dgv = GetGrid(TC_Groups.SelectedIndex);

            int max = (int)NUD_Copy.Value;
            var first = dgv.Rows[0].Cells;
            for (int i = 1; i < max; i++)
            {
                var cells = dgv.Rows[i].Cells;

                cells[ColumnItem].Value  = first[ColumnItem].Value;
                cells[ColumnCount].Value = first[ColumnCount].Value;
                cells[ColumnUse].Value   = first[ColumnUse].Value;
                cells[ColumnFlag1].Value = first[ColumnFlag1].Value;
                cells[ColumnFlag2].Value = first[ColumnFlag2].Value;
            }

            System.Media.SystemSounds.Asterisk.Play();
        }
    }
}

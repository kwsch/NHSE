using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class ItemReceivedEditor : Form
    {
        private readonly Player Player;

        public ItemReceivedEditor(Player player)
        {
            Player = player;
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            FillCheckBoxes();
            Initialize(GameInfo.Strings.ItemDataSource);
            CLB_Items.SelectedIndex = 0x50;
        }

        public void Initialize(List<ComboItem> items)
        {
            CB_Item.DisplayMember = nameof(ComboItem.Text);
            CB_Item.ValueMember = nameof(ComboItem.Value);
            CB_Item.DataSource = items;
        }

        private void FillCheckBoxes()
        {
            var items = GameInfo.Strings.itemlistdisplay;

            var ofs = Player.Personal.Offsets.ReceivedItems;
            var data = Player.Personal.Data;
            for (int i = 0; i < items.Length; i++)
            {
                var flag = FlagUtil.GetFlag(data, ofs, i);
                string value = items[i];
                string name = $"0x{i:X3} - {value}";
                CLB_Items.Items.Add(name, flag);
            }
        }

        public void GiveAll(IReadOnlyList<ushort> indexes, bool value = true)
        {
            foreach (var item in indexes)
                CLB_Items.SetItemChecked(item, value);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_GiveAll_Click(object sender, EventArgs e)
        {
            var items = GameInfo.Strings.itemlist;
            bool value = ModifierKeys != Keys.Alt;
            for (int i = 0x50; i < CLB_Items.Items.Count; i++)
            {
                if (string.IsNullOrEmpty(items[i]))
                    continue;
                CLB_Items.SetItemChecked(i, value);
            }
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_AllBugs_Click(object sender, EventArgs e) => GiveAll(GameLists.Bugs, ModifierKeys != Keys.Alt);
        private void B_AllFish_Click(object sender, EventArgs e) => GiveAll(GameLists.Fish, ModifierKeys != Keys.Alt);
        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            var ofs = Player.Personal.Offsets.ReceivedItems;
            var data = Player.Personal.Data;
            for (int i = 0; i < CLB_Items.Items.Count; i++)
                FlagUtil.SetFlag(data, ofs, i, CLB_Items.GetItemChecked(i));
            Close();
        }

        private void CB_Item_SelectedValueChanged(object sender, EventArgs e)
        {
            var index = WinFormsUtil.GetIndex(CB_Item);
            if (index >= CLB_Items.Items.Count)
                index = 0;
            CLB_Items.SelectedIndex = index;
        }

        private void CLB_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = CLB_Items.SelectedIndex;
            CB_Item.SelectedValue = index;
        }
    }
}

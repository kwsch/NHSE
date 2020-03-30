using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Core.Structures;

namespace NHSE.WinForms
{
    public partial class ItemReceivedEditor : Form
    {
        private readonly Player Player;

        public ItemReceivedEditor(Player player)
        {
            Player = player;
            InitializeComponent();
            FillCheckBoxes();
        }

        private void FillCheckBoxes()
        {
            var items = GameInfo.Strings.itemlist.ToArray();
            items[0] = string.Empty;
            var ofs = Player.Personal.Offsets.ReceivedItems;
            var data = Player.Personal.Data;
            for (int i = 0; i < items.Length; i++)
            {
                var flag = FlagUtil.GetFlag(data, ofs, i);
                string value = items[i];
                if (string.IsNullOrEmpty(value))
                    value = i.ToString();
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
    }
}

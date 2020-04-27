using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class PlayerHouseEditor : Form
    {
        private readonly PlayerHouse[] Houses;
        private readonly IReadOnlyList<Player> Players;

        private int Index;

        public PlayerHouseEditor(PlayerHouse[] houses, IReadOnlyList<Player> players, int index)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            Houses = houses;
            Players = players;
            DialogResult = DialogResult.Cancel;

            for (var i = 0; i < Houses.Length; i++)
            {
                var obj = Houses[i];
                LB_Items.Items.Add(GetHouseSummary(obj, i));
            }

            LB_Items.SelectedIndex = index;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LB_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Items.SelectedIndex < 0)
                return;
            PG_Item.SelectedObject = Houses[Index = LB_Items.SelectedIndex];
        }

        private void PG_Item_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            LB_Items.Items[Index] = GetHouseSummary(Houses[Index], Index);
        }

        private string GetHouseSummary(PlayerHouse house, int index)
        {
            var houseName = index >= Players.Count ? $"House {index}" : $"{Players[index].Personal.PlayerName}'s House";
            return $"{houseName} (lv {house.HouseLevel})";
        }

        private void B_DumpHouse_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Shift)
            {
                using var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                var dir = Path.GetDirectoryName(fbd.SelectedPath);
                if (dir == null || !Directory.Exists(dir))
                    return;
                Houses.DumpPlayerHouses(Players, fbd.SelectedPath);
                return;
            }

            var name = GetHouseSummary(Houses[Index], Index);
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Player House (*.nhph)|*.nhph|All files (*.*)|*.*",
                FileName = $"{name}.nhph",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var h = Houses[Index];
            var data = h.ToBytesClass();
            File.WriteAllBytes(sfd.FileName, data);
        }

        private void B_LoadHouse_Click(object sender, EventArgs e)
        {
            var name = GetHouseSummary(Houses[Index], Index);
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Player House (*.nhph)|*.nhph|All files (*.*)|*.*",
                FileName = $"{name}.nhph",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var file = ofd.FileName;
            var fi = new FileInfo(file);
            const int expectLength = VillagerHouse.SIZE;
            if (fi.Length != expectLength)
            {
                WinFormsUtil.Error(MessageStrings.MsgCanceling, string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength));
                return;
            }

            var data = File.ReadAllBytes(file);
            var h = data.ToClass<PlayerHouse>();
            PG_Item.SelectedObject = Houses[Index] = h;
        }
    }
}

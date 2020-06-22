using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class VillagerHouseEditor : Form
    {
        private readonly MainSave SAV;
        private readonly VillagerHouse[] Houses;
        private readonly IReadOnlyList<Villager> Villagers;

        private int Index;

        public VillagerHouseEditor(VillagerHouse[] houses, IReadOnlyList<Villager> villagers, MainSave sav, int index)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            SAV = sav;
            Houses = houses;
            Villagers = villagers;
            DialogResult = DialogResult.Cancel;

            foreach (var obj in Houses)
                LB_Items.Items.Add(GetHouseSummary(obj));

            var hIndex = Array.FindIndex(houses, z => z.NPC1 == index);
            if (hIndex < 0)
                hIndex = 0;
            LB_Items.SelectedIndex = hIndex;
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
            LB_Items.Items[Index] = GetHouseSummary(Houses[Index]);
        }

        private string GetHouseSummary(VillagerHouse house) => $"{GetVillagerName(house)}'s House";

        private string GetVillagerName(VillagerHouse house)
        {
            var villagerIndex = house.NPC1;
            var v = (uint) villagerIndex >= Villagers.Count ? "???" : Villagers[villagerIndex].InternalName;
            var name = GameInfo.Strings.GetVillager(v);
            return name;
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
                SAV.DumpVillagerHouses(fbd.SelectedPath);
                return;
            }

            var name = GetVillagerName(Houses[Index]);
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Villager House (*.nhvh)|*.nhvh|All files (*.*)|*.*",
                FileName = $"{name}.nhvh",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var h = Houses[Index];
            var data = h.Data;
            File.WriteAllBytes(sfd.FileName, data);
        }

        private void B_LoadHouse_Click(object sender, EventArgs e)
        {
            var name = GetVillagerName(Houses[Index]);
            if(name == "???")
            {
                name = "*";
            }
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Villager House (*.nhvh)|*.nhvh|All files (*.*)|*.*",
                FileName = $"{name}.nhvh",
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
            var h = new VillagerHouse(data);
            var current = Houses[Index];
            h.NPC1 = current.NPC1;
            Houses[Index] = h;
            PG_Item.SelectedObject = h;
        }
    }
}

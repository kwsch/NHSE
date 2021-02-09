using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;
using NHSE.Villagers;

namespace NHSE.WinForms
{
    public partial class VillagerEditor : UserControl
    {
        public IVillager[] Villagers;
        public IVillagerOrigin Origin;
        private readonly MainSave SAV;
        private int VillagerIndex = -1;
        private bool Loading;

        public VillagerEditor(IVillager[] villagers, IVillagerOrigin origin, MainSave sav, bool hasHouses)
        {
            InitializeComponent();
            Villagers = villagers;
            Origin = origin;
            SAV = sav;
            LoadVillagers();

            B_EditHouses.Visible = hasHouses;
        }

        public void Save() => SaveVillager(VillagerIndex);

        private void LoadVillagers()
        {
            CB_Personality.Items.Clear();
            var personalities = Enum.GetNames(typeof(VillagerPersonality));
            foreach (var p in personalities)
                CB_Personality.Items.Add(p);

            VillagerIndex = -1;
            LoadVillager(0);
        }

        private void LoadVillager(object sender, EventArgs e) => LoadVillager((int)NUD_Villager.Value);

        private void LoadVillager(int index)
        {
            if (VillagerIndex >= 0)
                SaveVillager(VillagerIndex);

            if (index < 0)
                return;

            LoadVillager(Villagers[index]);
            VillagerIndex = index;
        }

        private void LoadVillager(IVillager v)
        {
            Loading = true;
            NUD_Species.Value = v.Species;
            NUD_Variant.Value = v.Variant;
            CB_Personality.SelectedIndex = (int)v.Personality;
            TB_Catchphrase.Text = v.CatchPhrase;
            CHK_VillagerMovingOut.Checked = v.MovingOut;
            Loading = false;
        }

        private void SaveVillager(int index)
        {
            var v = Villagers[index];

            v.Species = (byte)NUD_Species.Value;
            v.Variant = (byte)NUD_Variant.Value;
            v.Personality = (VillagerPersonality)CB_Personality.SelectedIndex;
            v.CatchPhrase = TB_Catchphrase.Text;
            v.MovingOut = CHK_VillagerMovingOut.Checked;
        }

        private void CHK_VillagerMovingOut_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            if (!CHK_VillagerMovingOut.Checked)
                return;

            WinFormsUtil.Alert(MessageStrings.MsgMoveOut, MessageStrings.MsgMoveOutSuggest);
        }

        private void B_DumpVillager_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Shift)
            {
                using var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                var dir = Path.GetDirectoryName(fbd.SelectedPath);
                if (dir == null || !Directory.Exists(dir))
                    return;
                Villagers.Dump(fbd.SelectedPath);
                return;
            }

            var name = L_ExternalName.Text;
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Villager (*.nhv)|*.nhv|" +
                         "New Horizons Villager (*.nhv2)|*.nhv2|" +
                         "All files (*.*)|*.*",
                FileName = $"{name}.{Villagers[VillagerIndex].Extension}",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            SaveVillager(VillagerIndex);
            var v = Villagers[VillagerIndex];
            File.WriteAllBytes(sfd.FileName, v.Write());
        }

        private void B_LoadVillager_Click(object sender, EventArgs e)
        {
            var name = L_ExternalName.Text;
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Villager (*.nhv)|*.nhv|" +
                         "New Horizons Villager (*.nhv2)|*.nhv2|" +
                         "All files (*.*)|*.*",
                FileName = $"{name}.{Villagers[VillagerIndex].Extension}",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var path = ofd.FileName;
            var expectLength = SAV.Offsets.VillagerSize;
            var fi = new FileInfo(path);
            if (!VillagerConverter.IsCompatible((int)fi.Length, expectLength))
            {
                WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength), path);
                return;
            }

            var data = File.ReadAllBytes(ofd.FileName);
            data = VillagerConverter.GetCompatible(data, expectLength);
            if (data.Length != expectLength)
            {
                WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength), path);
                return;
            }

            var v = SAV.Offsets.ReadVillager(data);
            var player0 = Origin;
            if (!v.IsOriginatedFrom(player0))
            {
                string msg = string.Format(MessageStrings.MsgDataDidNotOriginateFromHost_0, player0.PlayerName);
                var result = WinFormsUtil.Prompt(MessageBoxButtons.YesNoCancel, msg, MessageStrings.MsgAskUpdateValues);
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    v.ChangeOrigins(player0, v.Write());
            }

            LoadVillager(Villagers[VillagerIndex] = v);
        }

        private void B_EditWear_Click(object sender, EventArgs e)
        {
            var v = Villagers[VillagerIndex];
            var items = v.WearStockList;
            using var editor = new PlayerItemEditor(items, 8, 3);
            if (editor.ShowDialog() == DialogResult.OK)
                v.WearStockList = items;
        }

        private void B_EditFurniture_Click(object sender, EventArgs e)
        {
            var v = Villagers[VillagerIndex];
            var items = v.FtrStockList;
            using var editor = new PlayerItemEditor(items, 8, 4);
            if (editor.ShowDialog() == DialogResult.OK)
                v.FtrStockList = items;
        }

        private void B_EditVillagerFlags_Click(object sender, EventArgs e)
        {
            var v = Villagers[VillagerIndex];
            var flags = v.GetEventFlagsSave();
            using var editor = new VillagerFlagEditor(flags);
            if (editor.ShowDialog() == DialogResult.OK)
                v.SetEventFlagsSave(flags);
        }

        private string GetCurrentVillagerInternalName() => VillagerUtil.GetInternalVillagerName((VillagerSpecies)NUD_Species.Value, (int)NUD_Variant.Value);
        private void ChangeVillager(object sender, EventArgs e) => ChangeVillager();
        private void ChangeVillager()
        {
            var name = GetCurrentVillagerInternalName();
            L_InternalName.Text = name;
            L_ExternalName.Text = GameInfo.Strings.GetVillager(name);
            PB_Villager.Image = VillagerSprite.GetVillagerSprite(name);
        }

        private void B_EditHouse_Click(object sender, EventArgs e)
        {
            SaveVillager(VillagerIndex);
            var villagers = SAV.GetVillagers();
            var houses = SAV.GetVillagerHouses();
            using var editor = new VillagerHouseEditor(houses, villagers, SAV, VillagerIndex);
            if (editor.ShowDialog() == DialogResult.OK)
                SAV.SetVillagerHouses(houses);
        }

        private static void ShowContextMenuBelow(ToolStripDropDown c, Control n) => c.Show(n.PointToScreen(new System.Drawing.Point(0, n.Height)));
        private void B_EditVillager_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_EditVillager, B_EditVillager);

        private void B_EditVillagerRoom_Click(object sender, EventArgs e)
        {
            var v = Villagers[VillagerIndex];
            using var editor = new SaveRoomFloorWallEditor(v.Room);
            if (editor.ShowDialog() == DialogResult.OK)
                v.Room = editor.Entity;
        }

        private void B_EditVillagerDesign_Click(object sender, EventArgs e)
        {
            var v = Villagers[VillagerIndex];
            var tmp = new[] {v.Design};
            using var editor = new PatternEditorPRO(tmp);
            if (editor.ShowDialog() == DialogResult.OK)
                v.Design = tmp[0];
        }

        private void B_EditVillagerPlayerMemories_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Shift)
            {
                var prompt = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, MessageStrings.MsgVillagerFriendshipMax);
                if (prompt != DialogResult.Yes)
                    return;
                foreach (var villager in Villagers)
                    villager.SetFriendshipAll();
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }

            var v = Villagers[VillagerIndex];
            using var editor = new VillagerMemoryEditor(v);
            if (editor.ShowDialog() == DialogResult.OK)
            { } // editor saves our changes
        }

        private void B_EditDIYTimer_Click(object sender, EventArgs e)
        {
            var v = Villagers[VillagerIndex];
            using var editor = new VillagerDIYTimerEditor(v);
            if (editor.ShowDialog() == DialogResult.OK)
            { } // editor saves our changes
        }

        private void B_MoveOutAllVillagers_Click(object sender, EventArgs e)
        {
            if (Loading)
                return;

            var prompt = WinFormsUtil.Prompt(MessageBoxButtons.OKCancel, MessageStrings.MsgMoveOutAll);
            if (prompt != DialogResult.OK)
                return;

            foreach (var villager in Villagers)
                villager.MovingOut = true;
            CHK_VillagerMovingOut.Checked = true;

            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_SetPhraseOriginal_Click(object sender, EventArgs e)
        {
            var internalName = GetCurrentVillagerInternalName();
            TB_Catchphrase.Text = GameInfo.Strings.GetVillagerDefaultPhrase(internalName);
        }

        private void B_ReplaceVillager_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsText())
            {
                WinFormsUtil.Error(MessageStrings.MsgVillagerReplaceNoText);
                return;
            }

            var internalName = Clipboard.GetText();
            if (!VillagerResources.IsVillagerDataKnown(internalName))
            {
                internalName = GameInfo.Strings.VillagerMap.FirstOrDefault(z => string.Equals(z.Value, internalName, StringComparison.InvariantCultureIgnoreCase)).Key;
                if (internalName == default)
                {
                    WinFormsUtil.Error(string.Format(MessageStrings.MsgVillagerReplaceUnknownName, internalName));
                    return;
                }
            }

            var index = VillagerIndex;
            var villager = Villagers[index];
            if (villager is not Villager2 v2)
            {
                WinFormsUtil.Error(MessageStrings.MsgVillagerReplaceOutdatedSaveFormat);
                return;
            }

            var houses = SAV.GetVillagerHouses();
            var houseIndex = Array.FindIndex(houses, z => z.NPC1 == index);
            var exist = new VillagerInfo(v2, houses[houseIndex]);
            var replace = VillagerSwap.GetReplacementVillager(exist, internalName);

            var nh = new VillagerHouse(replace.House);
            SAV.SetVillagerHouse(nh, houseIndex);
            var nv = new Villager2(replace.Villager);
            LoadVillager(Villagers[index] = nv);
            System.Media.SystemSounds.Asterisk.Play();
        }
    }
}

using System;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;

namespace NHSE.WinForms
{
    public partial class VillagerEditor : UserControl
    {
        public Villager[] Villagers;
        public IVillagerOrigin Origin;
        private int VillagerIndex = -1;

        public VillagerEditor(Villager[] villagers, IVillagerOrigin origin)
        {
            Villagers = villagers;
            Origin = origin;
            InitializeComponent();
            LoadVillagers();
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

        private void LoadVillager(object sender, EventArgs e) => LoadVillager((int)NUD_Villager.Value - 1);

        private void LoadVillager(int index)
        {
            if (VillagerIndex >= 0)
                SaveVillager(VillagerIndex);

            if (index < 0)
                return;

            LoadVillager(Villagers[index]);
            VillagerIndex = index;
        }

        private void LoadVillager(Villager v)
        {
            NUD_Species.Value = v.Species;
            NUD_Variant.Value = v.Variant;
            CB_Personality.SelectedIndex = (int)v.Personality;
            TB_Catchphrase.Text = v.CatchPhrase;
            CHK_VillagerMovingOut.Checked = v.MovingOut;
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
                Villagers.DumpVillagers(fbd.SelectedPath);
                return;
            }

            var name = L_ExternalName.Text;
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Villager (*.nhv)|*.nhv|All files (*.*)|*.*",
                FileName = $"{name}.nhv",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            SaveVillager(VillagerIndex);
            var v = Villagers[VillagerIndex];
            File.WriteAllBytes(sfd.FileName, v.Data);
        }

        private void B_LoadVillager_Click(object sender, EventArgs e)
        {
            var name = L_ExternalName.Text;
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Villager (*.nhv)|*.nhv|All files (*.*)|*.*",
                FileName = $"{name}.nhv",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var file = ofd.FileName;
            var original = Villagers[VillagerIndex];
            var expectLength = original.Data.Length;
            var fi = new FileInfo(file);
            if (fi.Length != expectLength)
            {
                var msg = $"Imported villager's data length (0x{fi.Length:X}) does not match the required length (0x{expectLength:X}).";
                WinFormsUtil.Error("Cancelling:", msg);
                return;
            }

            var data = File.ReadAllBytes(ofd.FileName);
            var v = new Villager(data);
            var player0 = Origin;
            if (!v.IsOriginatedFrom(player0))
            {
                var result = WinFormsUtil.Prompt(MessageBoxButtons.YesNoCancel,
                    $"Imported Villager did not originate from Resident Rep's data.", "Update values?");
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    v.ChangeOrigins(player0, v.Data);
            }

            LoadVillager(Villagers[VillagerIndex] = v);
        }

        private void B_EditFurniture_Click(object sender, EventArgs e)
        {
            var v = Villagers[VillagerIndex];
            var items = v.Furniture;
            using var editor = new PlayerItemEditor<VillagerItem>(items, 8, 2);
            if (editor.ShowDialog() == DialogResult.OK)
                v.Furniture = items;
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
    }
}

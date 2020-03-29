using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;

namespace NHSE.WinForms
{
    public partial class Editor : Form
    {
        private readonly HorizonSave SAV;

        public Editor(HorizonSave file)
        {
            InitializeComponent();
            SAV = file;
            LoadAll();
        }

        private void Menu_Open_Click(object sender, EventArgs e)
        {
            WinFormsUtil.Alert("I don't do anything yet!");
        }

        private void Menu_Save_Click(object sender, EventArgs e)
        {
            SaveAll();
            SAV.Save((uint)DateTime.Now.Ticks);
            WinFormsUtil.Alert("Saved all save data!");
        }

        private void Menu_DumpDecrypted_Click(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != DialogResult.OK)
                return;
            SAV.Dump(fbd.SelectedPath);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void Menu_VerifyHashes_Click(object sender, EventArgs e)
        {
            var result = SAV.GetInvalidHashes().ToArray();
            if (result.Length == 0)
            {
                WinFormsUtil.Alert("Hashes are valid.");
                return;
            }

            if (WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "Export results to clipboard?") != DialogResult.Yes)
                return;

            var lines = result.Select(z => z.ToString());
            Clipboard.SetText(string.Join(Environment.NewLine, lines));
        }

        private void LoadAll()
        {
            LoadPlayers();
            LoadVillagers();
        }

        private void SaveAll()
        {
            SavePlayer(PlayerIndex);
            SaveVillager(VillagerIndex);
        }

        #region Player Editing
        private void LoadPlayers()
        {
            var playerList = SAV.Players.Select(z => z.DirectoryName);
            foreach (var p in playerList)
                CB_Players.Items.Add(p);

            CB_Players.SelectedIndex = 0;
        }

        private void LoadVillagers()
        {
            var personalities = Enum.GetNames(typeof(VillagerPersonality));
            foreach (var p in personalities)
                CB_Personality.Items.Add(p);
            LoadVillager(0);
        }

        private int PlayerIndex = -1;
        private void LoadPlayer(object sender, EventArgs e) => LoadPlayer(CB_Players.SelectedIndex);
        private void LoadVillager(object sender, EventArgs e) => LoadVillager((int)NUD_Villager.Value - 1);

        private void B_EditPlayerItems_Click(object sender, EventArgs e)
        {
            var player = SAV.Players[PlayerIndex];
            if (ModifierKeys == Keys.Control)
            {
                using var editor = new InventoryEditor(player);
                editor.ShowDialog();
            }
            else
            {
                var pers = player.Personal;
                var p1 = pers.Pocket1;
                var p2 = pers.Pocket2;
                var items = p2.Concat(p1).ToArray();
                using var editor = new PlayerItemEditor(items, 10, 4);
                if (editor.ShowDialog() != DialogResult.OK)
                    return;

                pers.Pocket2 = items.Take(p2.Count).ToArray();
                pers.Pocket1 = items.Skip(p2.Count).Take(p1.Count).ToArray();
            }
        }

        private void B_Storage_Click(object sender, EventArgs e)
        {
            var player = SAV.Players[PlayerIndex];
            var pers = player.Personal;
            var p1 = pers.Storage;
            using var editor = new PlayerItemEditor(p1, 10, 5);
            if (editor.ShowDialog() == DialogResult.OK)
                pers.Storage = p1;
        }

        private void B_RecycleBin_Click(object sender, EventArgs e)
        {
            var items = SAV.Main.RecycleBin;
            using var editor = new PlayerItemEditor(items, 10, 4);
            if (editor.ShowDialog() == DialogResult.OK)
                SAV.Main.RecycleBin = items;
        }

        private void B_EditPlayerRecipes_Click(object sender, EventArgs e)
        {
            var player = SAV.Players[PlayerIndex];
            using var editor = new RecipeListEditor(player);
            editor.ShowDialog();
        }

        private void LoadPlayer(int index)
        {
            if (PlayerIndex >= 0)
                SavePlayer(PlayerIndex);

            if (index < 0)
                return;

            var player = SAV.Players[index];

            var pers = player.Personal;
            TB_Name.Text = pers.PlayerName;
            TB_TownName.Text = pers.TownName;
            NUD_BankBells.Value = pers.Bank.Value;
            NUD_NookMiles.Value = pers.NookMiles.Value;
            NUD_Wallet.Value = pers.Wallet.Value;

            var photo = pers.GetPhotoData();
            var bmp = new Bitmap(new MemoryStream(photo));
            PB_Player.Image = bmp;

            PlayerIndex = index;
        }

        private void SavePlayer(int index)
        {
            if (index < 0)
                return;

            var player = SAV.Players[index];
            var pers = player.Personal;

            if (pers.PlayerName != TB_Name.Text)
            {
                var orig = pers.GetPlayerIdentity();
                pers.PlayerName = TB_Name.Text;
                var updated = pers.GetPlayerIdentity();
                SAV.ChangeIdentity(orig, updated);
            }
            if (pers.TownName != TB_Name.Text)
            {
                var orig = pers.GetTownIdentity();
                pers.TownName = TB_TownName.Text;
                var updated = pers.GetTownIdentity();
                SAV.ChangeIdentity(orig, updated);
            }

            var bank = pers.Bank;
            bank.Value = (uint)NUD_BankBells.Value;
            pers.Bank = bank;

            var nook = pers.NookMiles;
            nook.Value = (uint)NUD_NookMiles.Value;
            pers.NookMiles = nook;

            var wallet = pers.Wallet;
            wallet.Value = (uint)NUD_Wallet.Value;
            pers.Wallet = wallet;
        }
        #endregion

        #region Villager Editing

        private int VillagerIndex = -1;

        private void LoadVillager(int index)
        {
            if (VillagerIndex >= 0)
                SaveVillager(VillagerIndex);

            if (index < 0)
                return;

            var v = SAV.Main.GetVillager(index);

            NUD_Species.Value = v.Species;
            NUD_Variant.Value = v.Variant;
            CB_Personality.SelectedIndex = (int) v.Personality;
            TB_Catchphrase.Text = v.CatchPhrase;

            VillagerIndex = index;
        }

        private void SaveVillager(int index)
        {
            var v = SAV.Main.GetVillager(index);
            if (v is null)
                return;

            v.Species = (byte)NUD_Species.Value;
            v.Variant = (byte)NUD_Variant.Value;
            v.Personality = (VillagerPersonality)CB_Personality.SelectedIndex;
            v.CatchPhrase = TB_Catchphrase.Text;

            SAV.Main.SetVillager(v, index);
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

        #endregion

        private void Menu_SavePNG_Click(object sender, EventArgs e)
        {
            var pb = WinFormsUtil.GetUnderlyingControl<PictureBox>(sender);
            if (pb?.Image == null)
            {
                WinFormsUtil.Alert("No picture loaded.");
                return;
            }

            string name;
            if (pb == PB_Player)
                name = SAV.Players[PlayerIndex].Personal.PlayerName;
            else if (pb == PB_Villager)
                name = L_ExternalName.Text;
            else
                name = "photo";

            var bmp = pb.Image;
            using var sfd = new SaveFileDialog
            {
                Filter = "png file (*.png)|*.png|All files (*.*)|*.*",
                FileName = $"{name}.png",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            bmp.Save(sfd.FileName, ImageFormat.Png);
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
                SAV.Main.DumpVillagers(dir);
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
            var data = SAV.Main.Offsets.ReadVillager(SAV.Main.Data, VillagerIndex).Data;
            File.WriteAllBytes(sfd.FileName, data);
        }
    }
}

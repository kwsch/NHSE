using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Injection;
using NHSE.Sprites;

namespace NHSE.WinForms
{
    public sealed partial class Editor : Form
    {
        private readonly HorizonSave SAV;
        private readonly VillagerEditor Villagers;

        public Editor(HorizonSave file)
        {
            InitializeComponent();

            Menu_Language.SelectedIndex = 0; // en -- triggers translation
            // this.TranslateInterface(GameInfo.CurrentLanguage);

            SAV = file;

            LoadPlayers();
            LoadMain();
            Villagers = LoadVillagers();

            Text = SAV.GetSaveTitle("NHSE");
        }

        private void Menu_Settings_Click(object sender, EventArgs e)
        {
            using var editor = new SettingsEditor();
            editor.ShowDialog();
        }

        private void Menu_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            Menu_Options.DropDown.Close();
            if ((uint)Menu_Language.SelectedIndex >= GameLanguage.LanguageCount)
                return;
            GameInfo.SetLanguage2Char(Menu_Language.SelectedIndex);
            this.TranslateInterface(GameInfo.CurrentLanguage);
        }

        private void Menu_Save_Click(object sender, EventArgs e)
        {
            SaveAll();
            try
            {
                SAV.Save((uint) DateTime.Now.Ticks);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(MessageStrings.MsgSaveDataExportFail, ex.Message);
                return;
            }
            WinFormsUtil.Alert(MessageStrings.MsgSaveDataExportSuccess);
        }

        private void Menu_DumpDecrypted_Click(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != DialogResult.OK)
                return;
            SAV.Dump(fbd.SelectedPath);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void Menu_LoadDecrypted_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Open main.dat ...",
                Filter = "New Horizons Save File (main.dat)|main.dat",
                FileName = "main.dat",
            };

            if (ofd.ShowDialog() == DialogResult.OK)
                LoadDecryptedFromPath(ofd.FileName);
        }

        private void LoadDecryptedFromPath(string main)
        {
            var dir = Path.GetDirectoryName(main);
            if (dir is null || !Directory.Exists(dir))
            {
                WinFormsUtil.Alert(MessageStrings.MsgImportDirectoryDoesNotExist);
                return;
            }

            SAV.Load(dir);
            ReloadAll(); // reload all fields
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void Menu_VerifyHashes_Click(object sender, EventArgs e)
        {
            var result = SAV.GetInvalidHashes().ToArray();
            if (result.Length == 0)
            {
                WinFormsUtil.Alert(MessageStrings.MsgSaveDataHashesValid);
                return;
            }

            if (WinFormsUtil.Prompt(MessageBoxButtons.YesNo, MessageStrings.MsgAskExportResultToClipboard) != DialogResult.Yes)
                return;

            var lines = result.Select(z => z.ToString());
            Clipboard.SetText(string.Join(Environment.NewLine, lines));
        }

        private void Menu_RAMEdit_Click(object sender, EventArgs e)
        {
            var exist = WinFormsUtil.FirstFormOfType<SysBotRAMEdit>();
            if (exist != null)
            {
                exist.Show();
                return;
            }

            var sysbot = new SysBotRAMEdit(InjectionType.Generic);
            sysbot.Show();
        }

        private void ReloadAll()
        {
            Villagers.Villagers = SAV.Main.GetVillagers();
            Villagers.Origin = SAV.Players[0].Personal;
            LoadPlayers();
            LoadMain();
        }

        private VillagerEditor LoadVillagers()
        {
            var p0 = SAV.Players[0].Personal;
            var villagers = SAV.Main.GetVillagers();
            var v = new VillagerEditor(villagers, p0, SAV.Main, true) {Dock = DockStyle.Fill};
            Tab_Villagers.Controls.Add(v);
            return v;
        }

        private void SaveAll()
        {
            SavePlayer(PlayerIndex);
            Villagers.Save();
            SAV.Main.SetVillagers(Villagers.Villagers);
        }

        #region Player Editing
        private void LoadPlayers()
        {
            CB_Players.Items.Clear();
            var playerList = SAV.Players.Select(z => z.DirectoryName);
            foreach (var p in playerList)
                CB_Players.Items.Add(p);

            PlayerIndex = -1;
            CB_Players.SelectedIndex = 0;
            NUD_PlayerHouse.Maximum = CB_Players.Items.Count;
        }

        private void LoadMain()
        {
            LoadPattern(0);
        }

        private int PlayerIndex = -1;
        private void LoadPlayer(object sender, EventArgs e) => LoadPlayer(CB_Players.SelectedIndex);
        private void LoadPattern(object sender, EventArgs e) => LoadPattern((int)NUD_PatternIndex.Value - 1);

        private void B_EditPlayerItems_Click(object sender, EventArgs e)
        {
            var player = SAV.Players[PlayerIndex];
            {
                var pers = player.Personal;
                var p1 = pers.Pocket1;
                var p2 = pers.Pocket2;
                var items = p2.Concat(p1).ToArray();
                using var editor = new PlayerItemEditor<Item>(items, 10, 4, sysbot: true);
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
            using var editor = new PlayerItemEditor<Item>(p1, 10, 5);
            if (editor.ShowDialog() == DialogResult.OK)
                pers.Storage = p1;
        }

        private void B_RecycleBin_Click(object sender, EventArgs e)
        {
            var items = SAV.Main.RecycleBin;
            using var editor = new PlayerItemEditor<Item>(items, 10, 4);
            if (editor.ShowDialog() == DialogResult.OK)
                SAV.Main.RecycleBin = items;
        }

        private void B_EditPlayerRecipes_Click(object sender, EventArgs e)
        {
            var player = SAV.Players[PlayerIndex];
            using var editor = new RecipeListEditor(player);
            editor.ShowDialog();
        }

        private void B_EditPlayerReceivedItems_Click(object sender, EventArgs e)
        {
            var player = SAV.Players[PlayerIndex];
            using var editor = new ItemReceivedEditor(player);
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
            NUD_BankBells.Value = Math.Min(int.MaxValue, pers.Bank.Value);
            NUD_NookMiles.Value = Math.Min(int.MaxValue, pers.NookMiles.Value);
            NUD_Wallet.Value = Math.Min(int.MaxValue, pers.Wallet.Value);

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
            if (pers.TownName != TB_TownName.Text)
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

        private void B_EditAchievements_Click(object sender, EventArgs e)
        {
            var pers = SAV.Players[PlayerIndex].Personal;
            var records = pers.GetActivities();
            using var editor = new AchievementEditor(records);
            if (editor.ShowDialog() == DialogResult.OK)
                pers.SetActivities(records);
        }

        private void B_EditPlayerFlags_Click(object sender, EventArgs e)
        {
            var pers = SAV.Players[PlayerIndex].Personal;
            var flags = pers.GetEventFlagsPlayer();
            using var editor = new FlagEditor(flags);
            if (editor.ShowDialog() == DialogResult.OK)
                pers.SetEventFlagsPlayer(flags);
        }

        #endregion

        #region Patterns

        private int PatternIndex = -1;

        private void LoadPattern(int index)
        {
            var pattern = SAV.Main.GetDesign(index);
            LoadPattern(pattern);
            PatternIndex = index;
        }

        private void LoadPattern(DesignPattern designPattern)
        {
            PB_Pattern.Image = ImageUtil.ResizeImage(designPattern.GetImage(), 128, 128);
            PB_Palette.Image = ImageUtil.ResizeImage(designPattern.GetPalette(), 150, 10);
            L_PatternName.Text = designPattern.DesignName + Environment.NewLine +
                                 designPattern.TownName + Environment.NewLine +
                                 designPattern.PlayerName;
        }

        #endregion

        private void Menu_SavePNG_Click(object sender, EventArgs e)
        {
            var pb = WinFormsUtil.GetUnderlyingControl<PictureBox>(sender);
            if (pb?.Image == null)
            {
                WinFormsUtil.Alert(MessageStrings.MsgNoPictureLoaded);
                return;
            }

            string name;
            if (pb == PB_Player)
                name = SAV.Players[PlayerIndex].Personal.PlayerName;
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

        private void B_DumpDesign_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Shift)
            {
                using var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                var dir = Path.GetDirectoryName(fbd.SelectedPath);
                if (dir == null || !Directory.Exists(dir))
                    return;
                SAV.Main.DumpDesigns(fbd.SelectedPath);
                return;
            }

            var original = SAV.Main.GetDesign(PatternIndex);
            var name = original.DesignName;
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Design Pattern (*.nhd)|*.nhd|All files (*.*)|*.*",
                FileName = $"{name}.nhd",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var d = SAV.Main.GetDesign(PatternIndex);
            File.WriteAllBytes(sfd.FileName, d.Data);
        }

        private void B_LoadDesign_Click(object sender, EventArgs e)
        {
            var original = SAV.Main.GetDesign(PatternIndex);
            var name = original.DesignName;
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Design Pattern (*.nhd)|*.nhd|All files (*.*)|*.*",
                FileName = $"{name}.nhd",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var file = ofd.FileName;
            var expectLength = original.Data.Length;
            var fi = new FileInfo(file);
            if (fi.Length != expectLength)
            {
                var msg = string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength);
                WinFormsUtil.Error(MessageStrings.MsgCanceling, msg);
                return;
            }

            var data = File.ReadAllBytes(ofd.FileName);
            var d = new DesignPattern(data);
            var player0 = SAV.Players[0].Personal;
            if (!d.IsOriginatedFrom(player0))
            {
                var notHost = string.Format(MessageStrings.MsgDataDidNotOriginateFromHost_0, player0.PlayerName);
                var result = WinFormsUtil.Prompt(MessageBoxButtons.YesNoCancel, notHost, MessageStrings.MsgAskUpdateValues);
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    d.ChangeOrigins(player0, d.Data);
            }

            SAV.Main.SetDesign(d, PatternIndex);
            LoadPattern(d);
        }

        private void PB_Pattern_MouseEnter(object sender, EventArgs e) => PB_Pattern.BackColor = Color.GreenYellow;
        private void PB_Pattern_MouseLeave(object sender, EventArgs e) => PB_Pattern.BackColor = Color.Transparent;

        private void B_EditBuildings_Click(object sender, EventArgs e)
        {
            var buildings = SAV.Main.Buildings;
            using var editor = new BuildingEditor(buildings, SAV.Main);
            if (editor.ShowDialog() == DialogResult.OK)
                SAV.Main.Buildings = buildings;
        }

        private void B_EditTurnipExchange_Click(object sender, EventArgs e)
        {
            var turnips = SAV.Main.Turnips;
            using var editor = new SingleObjectEditor<TurnipStonk>(turnips, PropertySort.NoSort);
            if (editor.ShowDialog() == DialogResult.OK)
                SAV.Main.Turnips = turnips;
        }

        private void B_EditAcres_Click(object sender, EventArgs e)
        {
            using var editor = new AcreEditor(SAV.Main);
            editor.ShowDialog();
        }

        private void B_EditTerrain_Click(object sender, EventArgs e)
        {
            using var editor = new TerrainEditor(SAV.Main);
            editor.ShowDialog();
        }

        private void B_EditFieldItems_Click(object sender, EventArgs e)
        {
            using var editor = new FieldItemEditor(SAV.Main);
            editor.ShowDialog();
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
                SAV.DumpPlayerHouses(fbd.SelectedPath);
                return;
            }

            var index = (int)(NUD_PlayerHouse.Value - 1);
            var name = CB_Players.Items[index].ToString();
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Player House (*.nhph)|*.nhph|All files (*.*)|*.*",
                FileName = $"{name}.nhph",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var h = SAV.Main.GetPlayerHouse(index);
            var data = h.ToBytesClass();
            File.WriteAllBytes(sfd.FileName, data);
        }

        private void B_LoadHouse_Click(object sender, EventArgs e)
        {
            var index = (int)(NUD_PlayerHouse.Value - 1);
            var name = CB_Players.Items[index].ToString();
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Player House (*.nhph)|*.nhph|All files (*.*)|*.*",
                FileName = $"{name}.nhph",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var file = ofd.FileName;
            var fi = new FileInfo(file);
            const int expectLength = PlayerHouse.SIZE;
            if (fi.Length != expectLength)
            {
                var msg = string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength);
                WinFormsUtil.Error(MessageStrings.MsgCanceling, msg);
                return;
            }

            var data = File.ReadAllBytes(file);
            var h = data.ToClass<PlayerHouse>();
            SAV.Main.SetPlayerHouse(h, index);
        }

        private void B_EditLandFlags_Click(object sender, EventArgs e)
        {
            var flags = SAV.Main.GetEventFlagLand();
            using var editor = new LandFlagEditor(flags);
            if (editor.ShowDialog() == DialogResult.OK)
                SAV.Main.SetEventFlagLand(flags);
        }
    }
}

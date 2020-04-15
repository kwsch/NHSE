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
            try
            {
                SAV.Save((uint) DateTime.Now.Ticks);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error("Unable to save files to their original location.", ex.Message);
                return;
            }
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
                WinFormsUtil.Alert("Directory does not exist!");
                return;
            }

            SAV.Load(dir);
            LoadAll(); // reload all fields
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

        private void LoadAll()
        {
            LoadPlayers();
            LoadVillagers();
            LoadMain();
        }

        private void SaveAll()
        {
            SavePlayer(PlayerIndex);
            SaveVillager(VillagerIndex);
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
        }

        private void LoadVillagers()
        {
            CB_Personality.Items.Clear();
            var personalities = Enum.GetNames(typeof(VillagerPersonality));
            foreach (var p in personalities)
                CB_Personality.Items.Add(p);

            VillagerIndex = -1;
            LoadVillager(0);
        }

        private void LoadMain()
        {
            LoadPattern(0);
        }

        private int PlayerIndex = -1;
        private void LoadPlayer(object sender, EventArgs e) => LoadPlayer(CB_Players.SelectedIndex);
        private void LoadVillager(object sender, EventArgs e) => LoadVillager((int)NUD_Villager.Value - 1);
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

        private void B_EditActivities_Click(object sender, EventArgs e)
        {
            var pers = SAV.Players[PlayerIndex].Personal;
            var records = pers.GetActivities();
            using var editor = new ActivityEditor(records);
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

        #region Villager Editing

        private int VillagerIndex = -1;

        private void LoadVillager(int index)
        {
            if (VillagerIndex >= 0)
                SaveVillager(VillagerIndex);

            if (index < 0)
                return;

            var v = SAV.Main.GetVillager(index);
            LoadVillager(v);
            VillagerIndex = index;
        }

        private void LoadVillager(Villager v)
        {
            NUD_Species.Value = v.Species;
            NUD_Variant.Value = v.Variant;
            CB_Personality.SelectedIndex = (int) v.Personality;
            TB_Catchphrase.Text = v.CatchPhrase;
        }

        private void SaveVillager(int index)
        {
            var v = SAV.Main.GetVillager(index);

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
                SAV.Main.DumpVillagers(fbd.SelectedPath);
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
            var v = SAV.Main.GetVillager(VillagerIndex);
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
            var original = SAV.Main.GetVillager(VillagerIndex);
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
            var player0 = SAV.Players[0].Personal;
            if (!v.IsOriginatedFrom(player0))
            {
                var result = WinFormsUtil.Prompt(MessageBoxButtons.YesNoCancel,
                    $"Imported Villager did not originate from Villager0 ({player0.PlayerName})'s data.", "Update values?");
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    v.ChangeOrigins(player0, v.Data);
            }

            SAV.Main.SetVillager(v, VillagerIndex);
            LoadVillager(v);
        }

        private void B_EditFurniture_Click(object sender, EventArgs e)
        {
            var v = SAV.Main.GetVillager(VillagerIndex);
            var items = v.Furniture;
            using var editor = new PlayerItemEditor<VillagerItem>(items, 8, 2);
            if (editor.ShowDialog() != DialogResult.OK)
                return;

            v.Furniture = items;
            SAV.Main.SetVillager(v, VillagerIndex);
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
                var msg = $"Imported Design Pattern's data length (0x{fi.Length:X}) does not match the required length (0x{expectLength:X}).";
                WinFormsUtil.Error("Cancelling:", msg);
                return;
            }

            var data = File.ReadAllBytes(ofd.FileName);
            var d = new DesignPattern(data);
            var player0 = SAV.Players[0].Personal;
            if (!d.IsOriginatedFrom(player0))
            {
                var result = WinFormsUtil.Prompt(MessageBoxButtons.YesNoCancel,
                    $"Imported Design Pattern did not originate from Villager0 ({player0.PlayerName})'s data.", "Update values?");
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
    }
}

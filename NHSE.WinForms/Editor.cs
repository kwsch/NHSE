using NHSE.Core;
using NHSE.Injection;
using NHSE.Sprites;
using NHSE.WinForms.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHSE.WinForms;

public sealed partial class Editor : Form
{
    private readonly HorizonSave SAV;
    private readonly VillagerEditor Villagers;

    /// <summary>
    /// Currently loaded player index.
    /// </summary>
    private int PlayerIndex = -1;

    public Editor(HorizonSave file)
    {
        WinFormsUtil.SetApplicationTheme(int.Parse(Settings.Default.DarkMode));

        InitializeComponent();

        SAV = file;

        LoadPlayers();
        Villagers = LoadVillagers();

        LoadMain();

        var lang = Settings.Default.Language;
        var index = GameLanguage.GetLanguageIndex(lang);
        Menu_Language.SelectedIndex = index; // triggers translation
        // this.TranslateInterface(GameInfo.CurrentLanguage);

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
        var lang = GameInfo.SetLanguage2Char(Menu_Language.SelectedIndex);

        this.TranslateInterface(lang);
        var settings = Settings.Default;
        settings.Language = lang;
        settings.Save();

        Task.Run(() =>
        {
            ItemSprite.Initialize(GameInfo.GetStrings("en").itemlist);
            TranslationUtil.SetLocalization(typeof(MessageStrings), lang);
            TranslationUtil.SetLocalization(GameInfo.Strings.InternalNameTranslation, lang);
        });
    }

    private void Menu_Save_Click(object sender, EventArgs e)
    {
        SaveAll();
        try
        {
            SAV.Save((uint)DateTime.Now.Ticks);
        }
        catch (Exception ex)
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
        using var ofd = new OpenFileDialog();
        ofd.Title = "Open main.dat ...";
        ofd.Filter = "New Horizons Save File (main.dat)|main.dat";
        ofd.FileName = "main.dat";

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

    private void Menu_Sync_Click(object sender, EventArgs e)
    {
        using var dialog = new SyncSaveDialog(SAV);
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            ReloadAll(); // Reload all fields after sync
            System.Media.SystemSounds.Asterisk.Play();
        }
    }

    private void Menu_ItemImages_Click(object sender, EventArgs e)
    {
        var exist = WinFormsUtil.FirstFormOfType<ImageFetcher>();
        if (exist != null)
        {
            exist.Show();
            return;
        }

        var imgfetcher = new ImageFetcher();
        imgfetcher.Show();
    }

    private void Menu_Theme_System_Click(object sender, EventArgs e)
    {
        Menu_Options.DropDown.Close();
        ThemeChangeDialog(1);
    }

    private void Menu_Theme_Classic_Click(object sender, EventArgs e)
    {
        Menu_Options.DropDown.Close();
        ThemeChangeDialog(0);
    }

    private void Menu_Theme_Dark_Click(object sender, EventArgs e)
    {
        Menu_Options.DropDown.Close();
        ThemeChangeDialog(2);
    }

    private void ThemeChangeDialog(int theme)
    {
        TaskDialogButton yesButton = new(MessageStrings.MsgDialogButtonYes) { Tag = DialogResult.Yes };
        TaskDialogButton noButton = new(MessageStrings.MsgDialogButtonNo) { Tag = DialogResult.No };
        TaskDialogButton cancelButton = new(MessageStrings.MsgDialogButtonCancel) { Tag = DialogResult.Cancel };
        var buttons = new TaskDialogButtonCollection
        {
            yesButton,
            noButton,
            cancelButton
        };

        TaskDialogPage page = new()
        {
            Caption = MessageStrings.MsgWarning,
            SizeToContent = true,
            Heading = MessageStrings.MsgAskSaveBeforeRestart,
            Icon = TaskDialogIcon.Warning,
            Buttons = buttons
        };

        TaskDialogButton resultButton = TaskDialog.ShowDialog(this, page);
        if (resultButton == yesButton)
        {
            SaveAll();
            try
            {
                SAV.Save((uint)DateTime.Now.Ticks);
            }
            catch (Exception ex)
            {
                WinFormsUtil.Error(MessageStrings.MsgSaveDataExportFail, ex.Message);
                return;
            }
            WinFormsUtil.Alert(MessageStrings.MsgSaveDataExportSuccess);
            WinFormsUtil.SetApplicationTheme(theme);
            Application.Restart();
        }
        else if (resultButton == noButton)
        {
            WinFormsUtil.SetApplicationTheme(theme);
            Application.Restart();
        }
    }

    private void ReloadAll()
    {
        Villagers.Villagers = SAV.Main.GetVillagers();
        Villagers.Origin = SAV.Players[0].Personal;
        LoadPlayers();
    }

    private VillagerEditor LoadVillagers()
    {
        var p0 = SAV.Players[0].Personal;
        var villagers = SAV.Main.GetVillagers();
        var v = new VillagerEditor(villagers, p0, SAV, true) { Dock = DockStyle.Fill };
        Tab_Villagers.Controls.Add(v);
        return v;
    }

    private void SaveAll()
    {
        SavePlayer(PlayerIndex);
        Villagers.Save();
        SAV.Main.SetVillagers(Villagers.Villagers);
        SaveMain();
    }

    private void LoadMain()
    {
        var m = SAV.Main;
        var names = Enum.GetNames<Hemisphere>();
        CB_Hemisphere.Items.AddRange(names);
        CB_Hemisphere.SelectedIndex = (int)m.Hemisphere;

        names = Enum.GetNames<AirportColor>();
        CB_AirportColor.Items.AddRange(names);
        CB_AirportColor.SelectedIndex = (int)m.AirportThemeColor;
        NUD_WeatherSeed.Value = m.WeatherSeed;
    }

    private void SaveMain()
    {
        var m = SAV.Main;
        m.Hemisphere = (Hemisphere)CB_Hemisphere.SelectedIndex;
        m.AirportThemeColor = (AirportColor)CB_AirportColor.SelectedIndex;
        m.WeatherSeed = (uint)NUD_WeatherSeed.Value;
    }

    #region Player Editing
    private void LoadPlayers()
    {
        // A valid save file has at least one player (main player).
        if (SAV.Players.Count == 0)
            throw new Exception("No players found in the loaded directory.");

        // Load the player names to the selection box.
        CB_Players.Items.Clear();
        var playerList = SAV.Players.Select(z => z.DirectoryName);
        foreach (var p in playerList)
            CB_Players.Items.Add(p);

        // Trigger a load.
        PlayerIndex = -1;
        CB_Players.SelectedIndex = 0;
    }
    private void LoadPlayer(object sender, EventArgs e) => LoadPlayer(CB_Players.SelectedIndex);

    private void B_EditPlayerItems_Click(object sender, EventArgs e)
    {
        var player = SAV.Players[PlayerIndex];
        {
            var pers = player.Personal;
            var bag = pers.Bag;
            var pocket = pers.Pocket;
            var items = pocket.Concat(bag).ToArray();
            using var editor = new PlayerItemEditor(items, 10, 4, sysbot: true);
            if (editor.ShowDialog() != DialogResult.OK)
                return;

            pers.Pocket = items.AsSpan(0, pocket.Count).ToArray();
            pers.Bag = items.AsSpan(pocket.Count, bag.Count).ToArray();
        }
    }

    private void B_Storage_Click(object sender, EventArgs e)
    {
        var player = SAV.Players[PlayerIndex];
        var pers = player.Personal;
        var p1 = pers.ItemChest;
        using var editor = new PlayerItemEditor(p1, 10, 5);
        if (editor.ShowDialog() == DialogResult.OK)
            pers.ItemChest = p1;
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

    private void B_EditPlayerReceivedItems_Click(object sender, EventArgs e)
    {
        var player = SAV.Players[PlayerIndex];
        using var editor = new ItemReceivedEditor(player);
        editor.ShowDialog();
    }

    private void B_EditPlayerReactions_Click(object sender, EventArgs e)
    {
        var player = SAV.Players[PlayerIndex];
        using var editor = new ReactionEditor(player.Personal);
        editor.ShowDialog();
    }

    private void B_EditPlayerMisc_Click(object sender, EventArgs e)
    {
        var player = SAV.Players[PlayerIndex];
        var save = SAV.Main;
        using var editor = new MiscPlayerEditor(player, save);
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
        NUD_BankBells.Value = Math.Min(int.MaxValue, pers.Bank);
        NUD_NookMiles.Value = Math.Min(int.MaxValue, pers.NookMiles);
        NUD_TotalNookMiles.Value = Math.Min(int.MaxValue, pers.TotalNookMiles);
        NUD_Wallet.Value = Math.Min(int.MaxValue, pers.Wallet);

        // swapped on purpose -- first count is the first two rows of items
        NUD_PocketCount1.Value = Math.Min(int.MaxValue, pers.PocketCount);
        NUD_PocketCount2.Value = Math.Min(int.MaxValue, pers.BagCount);
        NUD_StorageCount.Value = Math.Min(int.MaxValue, pers.ItemChestCount);

        if (pers.Data30 is { IsInitialized30: true } addition)
        {
            NUD_HotelTickets.Value = Math.Min(int.MaxValue, addition.HotelTickets);
        }
        else
        {
            L_HotelTickets.Visible = NUD_HotelTickets.Visible = false;
        }

        if (player.WhereAreN is not null)
        {
            NUD_Poki.Value = Math.Min(int.MaxValue, player.WhereAreN.Poki);
        }
        else
        {
            L_Poki.Visible = NUD_Poki.Visible = false;
        }

        try
        {
            var photo = pers.GetPhotoData();
            PB_Player.Image = new Bitmap(new MemoryStream(photo));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

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
            var orig = pers.GetPlayerIdentity().ToArray();
            pers.PlayerName = TB_Name.Text;
            var updated = pers.GetPlayerIdentity();
            SAV.ChangeIdentity(orig, updated);
        }
        if (pers.TownName != TB_TownName.Text)
        {
            var orig = pers.GetTownIdentity().ToArray();
            pers.TownName = TB_TownName.Text;
            var updated = pers.GetTownIdentity();
            SAV.ChangeIdentity(orig, updated);
        }

        pers.Bank = pers.Bank with { Value = (uint)NUD_BankBells.Value };
        pers.NookMiles = pers.NookMiles with { Value = (uint)NUD_NookMiles.Value };
        pers.TotalNookMiles = pers.TotalNookMiles with { Value = (uint)NUD_TotalNookMiles.Value };
        pers.Wallet = pers.Wallet with { Value = (uint)NUD_Wallet.Value };

        // swapped on purpose -- first count is the first two rows of items
        pers.PocketCount = (uint)NUD_PocketCount1.Value;
        pers.BagCount = (uint)NUD_PocketCount2.Value;

        pers.ItemChestCount = (uint)NUD_StorageCount.Value;

        if (player.Personal.Data30 is { IsInitialized30: true } addition)
        {
            addition.HotelTickets = addition.HotelTickets with { Value = (uint)NUD_HotelTickets.Value };
        }

        if (player.WhereAreN is { } x)
        {
            x.Poki = x.Poki with { Value = (uint)NUD_Poki.Value };
        }
    }

    private void B_EditAchievements_Click(object sender, EventArgs e)
    {
        var pers = SAV.Players[PlayerIndex].Personal;
        using var editor = new AchievementEditor(pers);
        editor.ShowDialog();
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

    private void Menu_SavePNG_Click(object sender, EventArgs e)
    {
        if (!WinFormsUtil.TryGetUnderlying<PictureBox>(sender, out var pb) || pb.Image is null)
        {
            WinFormsUtil.Alert(MessageStrings.MsgNoPictureLoaded);
            return;
        }

        string name = SAV.Players[PlayerIndex].Personal.PlayerName;
        var bmp = pb.Image;
        using var sfd = new SaveFileDialog();
        sfd.Filter = "png file (*.png)|*.png|All files (*.*)|*.*";
        sfd.FileName = $"{name}.png";
        if (sfd.ShowDialog() != DialogResult.OK)
            return;

        bmp.Save(sfd.FileName, ImageFormat.Png);
    }

    private void B_EditTurnipExchange_Click(object sender, EventArgs e)
    {
        var turnips = SAV.Main.Turnips;
        using var editor = new SingleObjectEditor<TurnipStonk>(turnips, PropertySort.Categorized, false);
        if (editor.ShowDialog() == DialogResult.OK)
            SAV.Main.Turnips = turnips;
    }

    private void B_EditFieldItems_Click(object sender, EventArgs e)
    {
        using var editor = new FieldItemEditor(SAV.Main);
        editor.ShowDialog();
    }

    private void B_EditLandFlags_Click(object sender, EventArgs e)
    {
        var flags = SAV.Main.EventFlagLand;
        var edit = flags.ToArray();
        using var editor = new LandFlagEditor(edit);
        if (editor.ShowDialog() == DialogResult.OK)
            edit.CopyTo(flags);
    }

    private void B_EditPatterns_Click(object sender, EventArgs e)
    {
        var playerID = SAV.Players[0].Personal.GetPlayerIdentity(); // fetch ID for overwrite ownership
        var townID = SAV.Players[0].Personal.GetTownIdentity(); // fetch ID for overwrite ownership
        var patterns = SAV.Main.GetDesigns();
        using var editor = new PatternEditor(patterns);
        if (editor.ShowDialog() == DialogResult.OK)
            SAV.Main.SetDesigns(patterns, playerID, townID);
    }

    private void B_EditPRODesigns_Click(object sender, EventArgs e)
    {
        var playerID = SAV.Players[0].Personal.GetPlayerIdentity(); // fetch ID for overwrite ownership
        var townID = SAV.Players[0].Personal.GetTownIdentity(); // fetch ID for overwrite ownership
        var patterns = SAV.Main.GetDesignsPRO();
        using var editor = new PatternEditorPRO(patterns);
        if (editor.ShowDialog() == DialogResult.OK)
            SAV.Main.SetDesignsPRO(patterns, playerID, townID);
    }

    private void B_EditPatternFlag_Click(object sender, EventArgs e)
    {
        var patterns = new[] { SAV.Main.FlagMyDesign };
        using var editor = new PatternEditor(patterns);
        if (editor.ShowDialog() == DialogResult.OK)
            SAV.Main.FlagMyDesign = patterns[0];
    }

    private void B_EditDesignsTailor_Click(object sender, EventArgs e)
    {
        var patterns = SAV.Main.GetDesignsTailor();
        using var editor = new PatternEditorPRO(patterns);
        if (editor.ShowDialog() == DialogResult.OK)
            SAV.Main.SetDesignsTailor(patterns);
    }

    private static void ShowContextMenuBelow(ToolStripDropDown c, Control n) => c.Show(n.PointToScreen(new Point(0, n.Height)));
    private void B_EditPlayer_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_EditPlayer, B_EditPlayer);
    private void B_EditMap_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_EditMap, B_EditMap);

    private void B_EditPlayerHouses_Click(object sender, EventArgs e)
    {
        var houses = SAV.Main.GetPlayerHouses();
        using var editor = new PlayerHouseEditor(houses, SAV.Players, SAV.Main, PlayerIndex);
        if (editor.ShowDialog() == DialogResult.OK)
            SAV.Main.SetPlayerHouses(houses);
    }

    private void B_EditCampsite_Click(object sender, EventArgs e)
    {
        using var editor = new CampsiteEditor(SAV);
        editor.ShowDialog();
    }

    private void B_EditFruitFlower_Click(object sender, EventArgs e)
    {
        var player = SAV.Players[PlayerIndex];
        var save = SAV.Main;
        using var editor = new FruitsFlowersEditor(player, save);
        editor.ShowDialog();
    }

    private void B_EditBulletin_Click(object sender, EventArgs e)
    {
        var boxed = SAV.Main.Bulletin;
        using var editor = new SingleObjectEditor<object>(boxed, PropertySort.NoSort, false);
        if (editor.ShowDialog() == DialogResult.OK)
            SAV.Main.Bulletin = boxed;
    }

    private void B_EditFieldGoods_Click(object sender, EventArgs e)
    {
        var boxed = SAV.Main.SaveFg;
        using var editor = new SingleObjectEditor<object>(boxed, PropertySort.NoSort, false);
        if (editor.ShowDialog() == DialogResult.OK)
            SAV.Main.SaveFg = boxed;
    }

    private void B_EditMuseum_Click_Click(object sender, EventArgs e)
    {
        var museum = SAV.Main.Museum;
        using var editor = new MuseumEditor(museum);
        if (editor.ShowDialog() == DialogResult.OK)
            SAV.Main.Museum = museum;
    }

    private void B_EditVisitors_Click(object sender, EventArgs e)
    {
        var boxed = SAV.Main.Visitor;
        using var editor = new SingleObjectEditor<object>(boxed, PropertySort.NoSort, false);
        if (editor.ShowDialog() == DialogResult.OK)
            SAV.Main.Visitor = boxed;
    }

    private void NUD_PocketCount_ValueChanged(object sender, EventArgs e) => ((NumericUpDown)sender).BackColor = (uint)((NumericUpDown)sender).Value > 20 ? Color.Red : NUD_BankBells.BackColor;
    private void NUD_Wallet_ValueChanged(object sender, EventArgs e) => NUD_Wallet.BackColor = (ulong)NUD_Wallet.Value > 99_999 ? Color.Red : NUD_BankBells.BackColor;
}
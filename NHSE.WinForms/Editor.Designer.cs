namespace NHSE.WinForms
{
    public partial class Editor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                Villagers.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Menu_Editor = new System.Windows.Forms.MenuStrip();
            Menu_File = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Save = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Tools = new System.Windows.Forms.ToolStripMenuItem();
            Menu_DumpDecrypted = new System.Windows.Forms.ToolStripMenuItem();
            Menu_VerifyHashes = new System.Windows.Forms.ToolStripMenuItem();
            Menu_LoadDecrypted = new System.Windows.Forms.ToolStripMenuItem();
            Menu_RAMEdit = new System.Windows.Forms.ToolStripMenuItem();
            Menu_ItemImages = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Options = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Language = new System.Windows.Forms.ToolStripComboBox();
            Menu_Theme = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Theme_System = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Theme_Classic = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Theme_Dark = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            CM_Picture = new System.Windows.Forms.ContextMenuStrip(components);
            Menu_SavePNG = new System.Windows.Forms.ToolStripMenuItem();
            Tab_Map = new System.Windows.Forms.TabPage();
            B_EditFruitFlower = new System.Windows.Forms.Button();
            B_EditCampsite = new System.Windows.Forms.Button();
            NUD_WeatherSeed = new System.Windows.Forms.NumericUpDown();
            L_WeatherSeed = new System.Windows.Forms.Label();
            B_EditDesignsTailor = new System.Windows.Forms.Button();
            B_EditPatternFlag = new System.Windows.Forms.Button();
            CB_AirportColor = new System.Windows.Forms.ComboBox();
            L_AirportColor = new System.Windows.Forms.Label();
            L_Hemisphere = new System.Windows.Forms.Label();
            CB_Hemisphere = new System.Windows.Forms.ComboBox();
            B_EditPlayerHouses = new System.Windows.Forms.Button();
            B_EditMap = new System.Windows.Forms.Button();
            CM_EditMap = new System.Windows.Forms.ContextMenuStrip(components);
            B_EditLandFlags = new System.Windows.Forms.ToolStripMenuItem();
            B_EditFieldItems = new System.Windows.Forms.ToolStripMenuItem();
            B_EditBulletin = new System.Windows.Forms.ToolStripMenuItem();
            B_EditMuseum_Click = new System.Windows.Forms.ToolStripMenuItem();
            B_EditVisitors = new System.Windows.Forms.ToolStripMenuItem();
            B_EditPRODesigns = new System.Windows.Forms.Button();
            B_EditPatterns = new System.Windows.Forms.Button();
            B_EditTurnipExchange = new System.Windows.Forms.Button();
            B_RecycleBin = new System.Windows.Forms.Button();
            Tab_Villagers = new System.Windows.Forms.TabPage();
            Tab_Players = new System.Windows.Forms.TabPage();
            L_HotelTickets = new System.Windows.Forms.Label();
            NUD_HotelTickets = new System.Windows.Forms.NumericUpDown();
            L_Poki = new System.Windows.Forms.Label();
            NUD_Poki = new System.Windows.Forms.NumericUpDown();
            L_EarnedMiles = new System.Windows.Forms.Label();
            NUD_TotalNookMiles = new System.Windows.Forms.NumericUpDown();
            L_StorageCount = new System.Windows.Forms.Label();
            NUD_StorageCount = new System.Windows.Forms.NumericUpDown();
            L_PocketCount2 = new System.Windows.Forms.Label();
            L_PocketCount1 = new System.Windows.Forms.Label();
            NUD_PocketCount2 = new System.Windows.Forms.NumericUpDown();
            NUD_PocketCount1 = new System.Windows.Forms.NumericUpDown();
            B_EditPlayer = new System.Windows.Forms.Button();
            CM_EditPlayer = new System.Windows.Forms.ContextMenuStrip(components);
            B_EditPlayerStorage = new System.Windows.Forms.ToolStripMenuItem();
            B_EditPlayerReceivedItems = new System.Windows.Forms.ToolStripMenuItem();
            B_EditAchievements = new System.Windows.Forms.ToolStripMenuItem();
            B_EditPlayerRecipes = new System.Windows.Forms.ToolStripMenuItem();
            B_EditPlayerFlags = new System.Windows.Forms.ToolStripMenuItem();
            B_EditPlayerReactions = new System.Windows.Forms.ToolStripMenuItem();
            B_EditPlayerMisc = new System.Windows.Forms.ToolStripMenuItem();
            B_EditPlayerItems = new System.Windows.Forms.Button();
            L_Wallet = new System.Windows.Forms.Label();
            NUD_Wallet = new System.Windows.Forms.NumericUpDown();
            L_NookMiles = new System.Windows.Forms.Label();
            NUD_NookMiles = new System.Windows.Forms.NumericUpDown();
            L_BankBells = new System.Windows.Forms.Label();
            NUD_BankBells = new System.Windows.Forms.NumericUpDown();
            TB_TownName = new System.Windows.Forms.TextBox();
            TB_Name = new System.Windows.Forms.TextBox();
            L_TownName = new System.Windows.Forms.Label();
            L_PlayerName = new System.Windows.Forms.Label();
            CB_Players = new System.Windows.Forms.ComboBox();
            PB_Player = new System.Windows.Forms.PictureBox();
            TC_Editors = new System.Windows.Forms.TabControl();
            Menu_Editor.SuspendLayout();
            CM_Picture.SuspendLayout();
            Tab_Map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_WeatherSeed).BeginInit();
            CM_EditMap.SuspendLayout();
            Tab_Players.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_HotelTickets).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Poki).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_TotalNookMiles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_StorageCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_PocketCount2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_PocketCount1).BeginInit();
            CM_EditPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_Wallet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_NookMiles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_BankBells).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Player).BeginInit();
            TC_Editors.SuspendLayout();
            SuspendLayout();
            // 
            // Menu_Editor
            // 
            Menu_Editor.BackColor = System.Drawing.SystemColors.Control;
            Menu_Editor.ImageScalingSize = new System.Drawing.Size(20, 20);
            Menu_Editor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { Menu_File, Menu_Tools, Menu_Options });
            Menu_Editor.Location = new System.Drawing.Point(0, 0);
            Menu_Editor.Name = "Menu_Editor";
            Menu_Editor.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            Menu_Editor.Size = new System.Drawing.Size(471, 24);
            Menu_Editor.TabIndex = 0;
            Menu_Editor.Text = "menuStrip1";
            // 
            // Menu_File
            // 
            Menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { Menu_Save });
            Menu_File.Name = "Menu_File";
            Menu_File.Size = new System.Drawing.Size(37, 20);
            Menu_File.Text = "File";
            // 
            // Menu_Save
            // 
            Menu_Save.Name = "Menu_Save";
            Menu_Save.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            Menu_Save.Size = new System.Drawing.Size(138, 22);
            Menu_Save.Text = "Save";
            Menu_Save.Click += Menu_Save_Click;
            // 
            // Menu_Tools
            // 
            Menu_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { Menu_DumpDecrypted, Menu_VerifyHashes, Menu_LoadDecrypted, Menu_RAMEdit, Menu_ItemImages });
            Menu_Tools.Name = "Menu_Tools";
            Menu_Tools.Size = new System.Drawing.Size(47, 20);
            Menu_Tools.Text = "Tools";
            // 
            // Menu_DumpDecrypted
            // 
            Menu_DumpDecrypted.Name = "Menu_DumpDecrypted";
            Menu_DumpDecrypted.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D;
            Menu_DumpDecrypted.Size = new System.Drawing.Size(206, 22);
            Menu_DumpDecrypted.Text = "Dump Decrypted";
            Menu_DumpDecrypted.Click += Menu_DumpDecrypted_Click;
            // 
            // Menu_VerifyHashes
            // 
            Menu_VerifyHashes.Name = "Menu_VerifyHashes";
            Menu_VerifyHashes.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H;
            Menu_VerifyHashes.Size = new System.Drawing.Size(206, 22);
            Menu_VerifyHashes.Text = "Verify Hashes";
            Menu_VerifyHashes.Click += Menu_VerifyHashes_Click;
            // 
            // Menu_LoadDecrypted
            // 
            Menu_LoadDecrypted.Name = "Menu_LoadDecrypted";
            Menu_LoadDecrypted.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L;
            Menu_LoadDecrypted.Size = new System.Drawing.Size(206, 22);
            Menu_LoadDecrypted.Text = "Load Decrypted";
            Menu_LoadDecrypted.Click += Menu_LoadDecrypted_Click;
            // 
            // Menu_RAMEdit
            // 
            Menu_RAMEdit.Name = "Menu_RAMEdit";
            Menu_RAMEdit.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R;
            Menu_RAMEdit.Size = new System.Drawing.Size(206, 22);
            Menu_RAMEdit.Text = "RAM Edit";
            Menu_RAMEdit.Click += Menu_RAMEdit_Click;
            // 
            // Menu_ItemImages
            // 
            Menu_ItemImages.Name = "Menu_ItemImages";
            Menu_ItemImages.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M;
            Menu_ItemImages.Size = new System.Drawing.Size(206, 22);
            Menu_ItemImages.Text = "Item Images";
            Menu_ItemImages.Click += Menu_ItemImages_Click;
            // 
            // Menu_Options
            // 
            Menu_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { Menu_Language, Menu_Theme, Menu_Settings });
            Menu_Options.Name = "Menu_Options";
            Menu_Options.Size = new System.Drawing.Size(61, 20);
            Menu_Options.Text = "Options";
            // 
            // Menu_Language
            // 
            Menu_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            Menu_Language.Items.AddRange(new object[] { "English", "日本語", "Deutsch", "Español", "Français", "Italiano", "한국어", "简体中文", "繁體中文" });
            Menu_Language.Name = "Menu_Language";
            Menu_Language.Size = new System.Drawing.Size(115, 23);
            Menu_Language.SelectedIndexChanged += Menu_Language_SelectedIndexChanged;
            // 
            // Menu_Theme
            // 
            Menu_Theme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { Menu_Theme_System, Menu_Theme_Classic, Menu_Theme_Dark });
            Menu_Theme.Name = "Menu_Theme";
            Menu_Theme.Size = new System.Drawing.Size(175, 22);
            Menu_Theme.Text = "Theme";
            // 
            // Menu_Theme_System
            // 
            Menu_Theme_System.Name = "Menu_Theme_System";
            Menu_Theme_System.Size = new System.Drawing.Size(152, 22);
            Menu_Theme_System.Text = "System Theme";
            Menu_Theme_System.Click += Menu_Theme_System_Click;
            // 
            // Menu_Theme_Classic
            // 
            Menu_Theme_Classic.Name = "Menu_Theme_Classic";
            Menu_Theme_Classic.Size = new System.Drawing.Size(152, 22);
            Menu_Theme_Classic.Text = "Light (Classic)";
            Menu_Theme_Classic.Click += Menu_Theme_Classic_Click;
            // 
            // Menu_Theme_Dark
            // 
            Menu_Theme_Dark.Name = "Menu_Theme_Dark";
            Menu_Theme_Dark.Size = new System.Drawing.Size(152, 22);
            Menu_Theme_Dark.Text = "Dark";
            Menu_Theme_Dark.Click += Menu_Theme_Dark_Click;
            // 
            // Menu_Settings
            // 
            Menu_Settings.Name = "Menu_Settings";
            Menu_Settings.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P;
            Menu_Settings.Size = new System.Drawing.Size(175, 22);
            Menu_Settings.Text = "Settings";
            Menu_Settings.Click += Menu_Settings_Click;
            // 
            // CM_Picture
            // 
            CM_Picture.ImageScalingSize = new System.Drawing.Size(20, 20);
            CM_Picture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { Menu_SavePNG });
            CM_Picture.Name = "CM_Picture";
            CM_Picture.ShowImageMargin = false;
            CM_Picture.Size = new System.Drawing.Size(101, 26);
            // 
            // Menu_SavePNG
            // 
            Menu_SavePNG.Name = "Menu_SavePNG";
            Menu_SavePNG.Size = new System.Drawing.Size(100, 22);
            Menu_SavePNG.Text = "Save .png";
            Menu_SavePNG.Click += Menu_SavePNG_Click;
            // 
            // Tab_Map
            // 
            Tab_Map.Controls.Add(B_EditFruitFlower);
            Tab_Map.Controls.Add(B_EditCampsite);
            Tab_Map.Controls.Add(NUD_WeatherSeed);
            Tab_Map.Controls.Add(L_WeatherSeed);
            Tab_Map.Controls.Add(B_EditDesignsTailor);
            Tab_Map.Controls.Add(B_EditPatternFlag);
            Tab_Map.Controls.Add(CB_AirportColor);
            Tab_Map.Controls.Add(L_AirportColor);
            Tab_Map.Controls.Add(L_Hemisphere);
            Tab_Map.Controls.Add(CB_Hemisphere);
            Tab_Map.Controls.Add(B_EditPlayerHouses);
            Tab_Map.Controls.Add(B_EditMap);
            Tab_Map.Controls.Add(B_EditPRODesigns);
            Tab_Map.Controls.Add(B_EditPatterns);
            Tab_Map.Controls.Add(B_EditTurnipExchange);
            Tab_Map.Controls.Add(B_RecycleBin);
            Tab_Map.Location = new System.Drawing.Point(4, 24);
            Tab_Map.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Tab_Map.Name = "Tab_Map";
            Tab_Map.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Tab_Map.Size = new System.Drawing.Size(463, 303);
            Tab_Map.TabIndex = 2;
            Tab_Map.Text = "Map";
            Tab_Map.UseVisualStyleBackColor = true;
            // 
            // B_EditFruitFlower
            // 
            B_EditFruitFlower.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_EditFruitFlower.Location = new System.Drawing.Point(236, 194);
            B_EditFruitFlower.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_EditFruitFlower.Name = "B_EditFruitFlower";
            B_EditFruitFlower.Size = new System.Drawing.Size(107, 46);
            B_EditFruitFlower.TabIndex = 67;
            B_EditFruitFlower.Text = "Edit Island Fruits + Flowers";
            B_EditFruitFlower.UseVisualStyleBackColor = true;
            B_EditFruitFlower.Click += B_EditFruitFlower_Click;
            // 
            // B_EditCampsite
            // 
            B_EditCampsite.Location = new System.Drawing.Point(121, 195);
            B_EditCampsite.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_EditCampsite.Name = "B_EditCampsite";
            B_EditCampsite.Size = new System.Drawing.Size(107, 46);
            B_EditCampsite.TabIndex = 66;
            B_EditCampsite.Text = "Edit Campsite";
            B_EditCampsite.UseVisualStyleBackColor = true;
            B_EditCampsite.Click += B_EditCampsite_Click;
            // 
            // NUD_WeatherSeed
            // 
            NUD_WeatherSeed.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            NUD_WeatherSeed.Location = new System.Drawing.Point(236, 68);
            NUD_WeatherSeed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_WeatherSeed.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            NUD_WeatherSeed.Name = "NUD_WeatherSeed";
            NUD_WeatherSeed.Size = new System.Drawing.Size(108, 20);
            NUD_WeatherSeed.TabIndex = 65;
            NUD_WeatherSeed.Value = new decimal(new int[] { 1234567890, 0, 0, 0 });
            // 
            // L_WeatherSeed
            // 
            L_WeatherSeed.AutoSize = true;
            L_WeatherSeed.Location = new System.Drawing.Point(351, 70);
            L_WeatherSeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_WeatherSeed.Name = "L_WeatherSeed";
            L_WeatherSeed.Size = new System.Drawing.Size(79, 15);
            L_WeatherSeed.TabIndex = 64;
            L_WeatherSeed.Text = "Weather Seed";
            // 
            // B_EditDesignsTailor
            // 
            B_EditDesignsTailor.Location = new System.Drawing.Point(350, 113);
            B_EditDesignsTailor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_EditDesignsTailor.Name = "B_EditDesignsTailor";
            B_EditDesignsTailor.Size = new System.Drawing.Size(107, 46);
            B_EditDesignsTailor.TabIndex = 63;
            B_EditDesignsTailor.Text = "Edit Tailor Designs";
            B_EditDesignsTailor.UseVisualStyleBackColor = true;
            B_EditDesignsTailor.Click += B_EditDesignsTailor_Click;
            // 
            // B_EditPatternFlag
            // 
            B_EditPatternFlag.Location = new System.Drawing.Point(236, 113);
            B_EditPatternFlag.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_EditPatternFlag.Name = "B_EditPatternFlag";
            B_EditPatternFlag.Size = new System.Drawing.Size(107, 46);
            B_EditPatternFlag.TabIndex = 62;
            B_EditPatternFlag.Text = "Edit Flag Design";
            B_EditPatternFlag.UseVisualStyleBackColor = true;
            B_EditPatternFlag.Click += B_EditPatternFlag_Click;
            // 
            // CB_AirportColor
            // 
            CB_AirportColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_AirportColor.FormattingEnabled = true;
            CB_AirportColor.Location = new System.Drawing.Point(236, 37);
            CB_AirportColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CB_AirportColor.Name = "CB_AirportColor";
            CB_AirportColor.Size = new System.Drawing.Size(107, 23);
            CB_AirportColor.TabIndex = 61;
            // 
            // L_AirportColor
            // 
            L_AirportColor.AutoSize = true;
            L_AirportColor.Location = new System.Drawing.Point(350, 40);
            L_AirportColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_AirportColor.Name = "L_AirportColor";
            L_AirportColor.Size = new System.Drawing.Size(76, 15);
            L_AirportColor.TabIndex = 60;
            L_AirportColor.Text = "Airport Color";
            // 
            // L_Hemisphere
            // 
            L_Hemisphere.AutoSize = true;
            L_Hemisphere.Location = new System.Drawing.Point(350, 10);
            L_Hemisphere.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Hemisphere.Name = "L_Hemisphere";
            L_Hemisphere.Size = new System.Drawing.Size(71, 15);
            L_Hemisphere.TabIndex = 58;
            L_Hemisphere.Text = "Hemisphere";
            // 
            // CB_Hemisphere
            // 
            CB_Hemisphere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_Hemisphere.FormattingEnabled = true;
            CB_Hemisphere.Location = new System.Drawing.Point(236, 7);
            CB_Hemisphere.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CB_Hemisphere.Name = "CB_Hemisphere";
            CB_Hemisphere.Size = new System.Drawing.Size(107, 23);
            CB_Hemisphere.TabIndex = 57;
            // 
            // B_EditPlayerHouses
            // 
            B_EditPlayerHouses.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            B_EditPlayerHouses.Location = new System.Drawing.Point(7, 195);
            B_EditPlayerHouses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_EditPlayerHouses.Name = "B_EditPlayerHouses";
            B_EditPlayerHouses.Size = new System.Drawing.Size(107, 46);
            B_EditPlayerHouses.TabIndex = 56;
            B_EditPlayerHouses.Text = "Edit Player Houses";
            B_EditPlayerHouses.UseVisualStyleBackColor = true;
            B_EditPlayerHouses.Click += B_EditPlayerHouses_Click;
            // 
            // B_EditMap
            // 
            B_EditMap.ContextMenuStrip = CM_EditMap;
            B_EditMap.Location = new System.Drawing.Point(350, 194);
            B_EditMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_EditMap.Name = "B_EditMap";
            B_EditMap.Size = new System.Drawing.Size(107, 46);
            B_EditMap.TabIndex = 2;
            B_EditMap.Text = "Edit Map...";
            B_EditMap.UseVisualStyleBackColor = true;
            B_EditMap.Click += B_EditMap_Click;
            // 
            // CM_EditMap
            // 
            CM_EditMap.ImageScalingSize = new System.Drawing.Size(20, 20);
            CM_EditMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { B_EditLandFlags, B_EditFieldItems, B_EditBulletin, B_EditMuseum_Click, B_EditVisitors });
            CM_EditMap.Name = "CM_EditMap";
            CM_EditMap.Size = new System.Drawing.Size(172, 114);
            // 
            // B_EditLandFlags
            // 
            B_EditLandFlags.Name = "B_EditLandFlags";
            B_EditLandFlags.Size = new System.Drawing.Size(171, 22);
            B_EditLandFlags.Text = "Edit Flags";
            B_EditLandFlags.Click += B_EditLandFlags_Click;
            // 
            // B_EditFieldItems
            // 
            B_EditFieldItems.Name = "B_EditFieldItems";
            B_EditFieldItems.Size = new System.Drawing.Size(171, 22);
            B_EditFieldItems.Text = "Edit Field Items";
            B_EditFieldItems.Click += B_EditFieldItems_Click;
            // 
            // B_EditBulletin
            // 
            B_EditBulletin.Name = "B_EditBulletin";
            B_EditBulletin.Size = new System.Drawing.Size(171, 22);
            B_EditBulletin.Text = "Edit Bulletin Board";
            B_EditBulletin.Click += B_EditBulletin_Click;
            // 
            // B_EditMuseum_Click
            // 
            B_EditMuseum_Click.Name = "B_EditMuseum_Click";
            B_EditMuseum_Click.Size = new System.Drawing.Size(171, 22);
            B_EditMuseum_Click.Text = "Edit Museum";
            B_EditMuseum_Click.Click += B_EditMuseum_Click_Click;
            // 
            // B_EditVisitors
            // 
            B_EditVisitors.Name = "B_EditVisitors";
            B_EditVisitors.Size = new System.Drawing.Size(171, 22);
            B_EditVisitors.Text = "Edit Visitors";
            B_EditVisitors.Click += B_EditVisitors_Click;
            // 
            // B_EditPRODesigns
            // 
            B_EditPRODesigns.Location = new System.Drawing.Point(121, 113);
            B_EditPRODesigns.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_EditPRODesigns.Name = "B_EditPRODesigns";
            B_EditPRODesigns.Size = new System.Drawing.Size(107, 46);
            B_EditPRODesigns.TabIndex = 55;
            B_EditPRODesigns.Text = "Edit PRO Designs";
            B_EditPRODesigns.UseVisualStyleBackColor = true;
            B_EditPRODesigns.Click += B_EditPRODesigns_Click;
            // 
            // B_EditPatterns
            // 
            B_EditPatterns.Location = new System.Drawing.Point(7, 113);
            B_EditPatterns.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_EditPatterns.Name = "B_EditPatterns";
            B_EditPatterns.Size = new System.Drawing.Size(107, 46);
            B_EditPatterns.TabIndex = 54;
            B_EditPatterns.Text = "Edit Patterns";
            B_EditPatterns.UseVisualStyleBackColor = true;
            B_EditPatterns.Click += B_EditPatterns_Click;
            // 
            // B_EditTurnipExchange
            // 
            B_EditTurnipExchange.Location = new System.Drawing.Point(7, 7);
            B_EditTurnipExchange.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_EditTurnipExchange.Name = "B_EditTurnipExchange";
            B_EditTurnipExchange.Size = new System.Drawing.Size(107, 46);
            B_EditTurnipExchange.TabIndex = 15;
            B_EditTurnipExchange.Text = "Edit Turnip Exchange";
            B_EditTurnipExchange.UseVisualStyleBackColor = true;
            B_EditTurnipExchange.Click += B_EditTurnipExchange_Click;
            // 
            // B_RecycleBin
            // 
            B_RecycleBin.Location = new System.Drawing.Point(7, 60);
            B_RecycleBin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_RecycleBin.Name = "B_RecycleBin";
            B_RecycleBin.Size = new System.Drawing.Size(107, 46);
            B_RecycleBin.TabIndex = 13;
            B_RecycleBin.Text = "Edit Recycle Bin";
            B_RecycleBin.UseVisualStyleBackColor = true;
            B_RecycleBin.Click += B_RecycleBin_Click;
            // 
            // Tab_Villagers
            // 
            Tab_Villagers.Location = new System.Drawing.Point(4, 24);
            Tab_Villagers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Tab_Villagers.Name = "Tab_Villagers";
            Tab_Villagers.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Tab_Villagers.Size = new System.Drawing.Size(463, 303);
            Tab_Villagers.TabIndex = 0;
            Tab_Villagers.Text = "Villagers";
            Tab_Villagers.UseVisualStyleBackColor = true;
            // 
            // Tab_Players
            // 
            Tab_Players.Controls.Add(L_HotelTickets);
            Tab_Players.Controls.Add(NUD_HotelTickets);
            Tab_Players.Controls.Add(L_Poki);
            Tab_Players.Controls.Add(NUD_Poki);
            Tab_Players.Controls.Add(L_EarnedMiles);
            Tab_Players.Controls.Add(NUD_TotalNookMiles);
            Tab_Players.Controls.Add(L_StorageCount);
            Tab_Players.Controls.Add(NUD_StorageCount);
            Tab_Players.Controls.Add(L_PocketCount2);
            Tab_Players.Controls.Add(L_PocketCount1);
            Tab_Players.Controls.Add(NUD_PocketCount2);
            Tab_Players.Controls.Add(NUD_PocketCount1);
            Tab_Players.Controls.Add(B_EditPlayer);
            Tab_Players.Controls.Add(B_EditPlayerItems);
            Tab_Players.Controls.Add(L_Wallet);
            Tab_Players.Controls.Add(NUD_Wallet);
            Tab_Players.Controls.Add(L_NookMiles);
            Tab_Players.Controls.Add(NUD_NookMiles);
            Tab_Players.Controls.Add(L_BankBells);
            Tab_Players.Controls.Add(NUD_BankBells);
            Tab_Players.Controls.Add(TB_TownName);
            Tab_Players.Controls.Add(TB_Name);
            Tab_Players.Controls.Add(L_TownName);
            Tab_Players.Controls.Add(L_PlayerName);
            Tab_Players.Controls.Add(CB_Players);
            Tab_Players.Controls.Add(PB_Player);
            Tab_Players.Location = new System.Drawing.Point(4, 24);
            Tab_Players.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Tab_Players.Name = "Tab_Players";
            Tab_Players.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Tab_Players.Size = new System.Drawing.Size(463, 303);
            Tab_Players.TabIndex = 1;
            Tab_Players.Text = "Players";
            Tab_Players.UseVisualStyleBackColor = true;
            // 
            // L_HotelTickets
            // 
            L_HotelTickets.Location = new System.Drawing.Point(166, 273);
            L_HotelTickets.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_HotelTickets.Name = "L_HotelTickets";
            L_HotelTickets.Size = new System.Drawing.Size(98, 23);
            L_HotelTickets.TabIndex = 30;
            L_HotelTickets.Text = "Hotel Tickets:";
            L_HotelTickets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_HotelTickets
            // 
            NUD_HotelTickets.Location = new System.Drawing.Point(271, 273);
            NUD_HotelTickets.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_HotelTickets.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            NUD_HotelTickets.Name = "NUD_HotelTickets";
            NUD_HotelTickets.Size = new System.Drawing.Size(117, 23);
            NUD_HotelTickets.TabIndex = 29;
            // 
            // L_Poki
            // 
            L_Poki.Location = new System.Drawing.Point(166, 245);
            L_Poki.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Poki.Name = "L_Poki";
            L_Poki.Size = new System.Drawing.Size(98, 23);
            L_Poki.TabIndex = 28;
            L_Poki.Text = "Poki:";
            L_Poki.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Poki
            // 
            NUD_Poki.Location = new System.Drawing.Point(271, 245);
            NUD_Poki.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_Poki.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            NUD_Poki.Name = "NUD_Poki";
            NUD_Poki.Size = new System.Drawing.Size(117, 23);
            NUD_Poki.TabIndex = 27;
            // 
            // L_EarnedMiles
            // 
            L_EarnedMiles.Location = new System.Drawing.Point(166, 135);
            L_EarnedMiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_EarnedMiles.Name = "L_EarnedMiles";
            L_EarnedMiles.Size = new System.Drawing.Size(98, 23);
            L_EarnedMiles.TabIndex = 26;
            L_EarnedMiles.Text = "Earned Miles:";
            L_EarnedMiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_TotalNookMiles
            // 
            NUD_TotalNookMiles.Location = new System.Drawing.Point(271, 135);
            NUD_TotalNookMiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_TotalNookMiles.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            NUD_TotalNookMiles.Name = "NUD_TotalNookMiles";
            NUD_TotalNookMiles.Size = new System.Drawing.Size(117, 23);
            NUD_TotalNookMiles.TabIndex = 25;
            // 
            // L_StorageCount
            // 
            L_StorageCount.AutoSize = true;
            L_StorageCount.Location = new System.Drawing.Point(233, 167);
            L_StorageCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_StorageCount.Name = "L_StorageCount";
            L_StorageCount.Size = new System.Drawing.Size(83, 15);
            L_StorageCount.TabIndex = 24;
            L_StorageCount.Text = "Storage Count";
            L_StorageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NUD_StorageCount
            // 
            NUD_StorageCount.Location = new System.Drawing.Point(176, 164);
            NUD_StorageCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_StorageCount.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            NUD_StorageCount.Name = "NUD_StorageCount";
            NUD_StorageCount.Size = new System.Drawing.Size(54, 23);
            NUD_StorageCount.TabIndex = 23;
            NUD_StorageCount.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // L_PocketCount2
            // 
            L_PocketCount2.AutoSize = true;
            L_PocketCount2.Location = new System.Drawing.Point(233, 222);
            L_PocketCount2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_PocketCount2.Name = "L_PocketCount2";
            L_PocketCount2.Size = new System.Drawing.Size(88, 15);
            L_PocketCount2.TabIndex = 22;
            L_PocketCount2.Text = "Pocket Count 2";
            L_PocketCount2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_PocketCount1
            // 
            L_PocketCount1.AutoSize = true;
            L_PocketCount1.Location = new System.Drawing.Point(233, 197);
            L_PocketCount1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_PocketCount1.Name = "L_PocketCount1";
            L_PocketCount1.Size = new System.Drawing.Size(88, 15);
            L_PocketCount1.TabIndex = 21;
            L_PocketCount1.Text = "Pocket Count 1";
            L_PocketCount1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NUD_PocketCount2
            // 
            NUD_PocketCount2.Location = new System.Drawing.Point(176, 218);
            NUD_PocketCount2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_PocketCount2.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            NUD_PocketCount2.Name = "NUD_PocketCount2";
            NUD_PocketCount2.Size = new System.Drawing.Size(54, 23);
            NUD_PocketCount2.TabIndex = 20;
            NUD_PocketCount2.Value = new decimal(new int[] { 20, 0, 0, 0 });
            NUD_PocketCount2.ValueChanged += NUD_PocketCount_ValueChanged;
            // 
            // NUD_PocketCount1
            // 
            NUD_PocketCount1.Location = new System.Drawing.Point(176, 194);
            NUD_PocketCount1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_PocketCount1.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            NUD_PocketCount1.Name = "NUD_PocketCount1";
            NUD_PocketCount1.Size = new System.Drawing.Size(54, 23);
            NUD_PocketCount1.TabIndex = 19;
            NUD_PocketCount1.Value = new decimal(new int[] { 20, 0, 0, 0 });
            NUD_PocketCount1.ValueChanged += NUD_PocketCount_ValueChanged;
            // 
            // B_EditPlayer
            // 
            B_EditPlayer.ContextMenuStrip = CM_EditPlayer;
            B_EditPlayer.Location = new System.Drawing.Point(7, 247);
            B_EditPlayer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_EditPlayer.Name = "B_EditPlayer";
            B_EditPlayer.Size = new System.Drawing.Size(152, 46);
            B_EditPlayer.TabIndex = 18;
            B_EditPlayer.Text = "Edit Player...";
            B_EditPlayer.UseVisualStyleBackColor = true;
            B_EditPlayer.Click += B_EditPlayer_Click;
            // 
            // CM_EditPlayer
            // 
            CM_EditPlayer.ImageScalingSize = new System.Drawing.Size(20, 20);
            CM_EditPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { B_EditPlayerStorage, B_EditPlayerReceivedItems, B_EditAchievements, B_EditPlayerRecipes, B_EditPlayerFlags, B_EditPlayerReactions, B_EditPlayerMisc });
            CM_EditPlayer.Name = "CM_EditPlayer";
            CM_EditPlayer.Size = new System.Drawing.Size(177, 158);
            // 
            // B_EditPlayerStorage
            // 
            B_EditPlayerStorage.Name = "B_EditPlayerStorage";
            B_EditPlayerStorage.Size = new System.Drawing.Size(176, 22);
            B_EditPlayerStorage.Text = "Edit Storage";
            B_EditPlayerStorage.Click += B_Storage_Click;
            // 
            // B_EditPlayerReceivedItems
            // 
            B_EditPlayerReceivedItems.Name = "B_EditPlayerReceivedItems";
            B_EditPlayerReceivedItems.Size = new System.Drawing.Size(176, 22);
            B_EditPlayerReceivedItems.Text = "Edit Received Items";
            B_EditPlayerReceivedItems.Click += B_EditPlayerReceivedItems_Click;
            // 
            // B_EditAchievements
            // 
            B_EditAchievements.Name = "B_EditAchievements";
            B_EditAchievements.Size = new System.Drawing.Size(176, 22);
            B_EditAchievements.Text = "Edit Achievements";
            B_EditAchievements.Click += B_EditAchievements_Click;
            // 
            // B_EditPlayerRecipes
            // 
            B_EditPlayerRecipes.Name = "B_EditPlayerRecipes";
            B_EditPlayerRecipes.Size = new System.Drawing.Size(176, 22);
            B_EditPlayerRecipes.Text = "Edit Recipes";
            B_EditPlayerRecipes.Click += B_EditPlayerRecipes_Click;
            // 
            // B_EditPlayerFlags
            // 
            B_EditPlayerFlags.Name = "B_EditPlayerFlags";
            B_EditPlayerFlags.Size = new System.Drawing.Size(176, 22);
            B_EditPlayerFlags.Text = "Edit Flags";
            B_EditPlayerFlags.Click += B_EditPlayerFlags_Click;
            // 
            // B_EditPlayerReactions
            // 
            B_EditPlayerReactions.Name = "B_EditPlayerReactions";
            B_EditPlayerReactions.Size = new System.Drawing.Size(176, 22);
            B_EditPlayerReactions.Text = "Edit Reactions";
            B_EditPlayerReactions.Click += B_EditPlayerReactions_Click;
            // 
            // B_EditPlayerMisc
            // 
            B_EditPlayerMisc.Name = "B_EditPlayerMisc";
            B_EditPlayerMisc.Size = new System.Drawing.Size(176, 22);
            B_EditPlayerMisc.Text = "Edit Misc";
            B_EditPlayerMisc.Click += B_EditPlayerMisc_Click;
            // 
            // B_EditPlayerItems
            // 
            B_EditPlayerItems.Location = new System.Drawing.Point(7, 194);
            B_EditPlayerItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_EditPlayerItems.Name = "B_EditPlayerItems";
            B_EditPlayerItems.Size = new System.Drawing.Size(152, 46);
            B_EditPlayerItems.TabIndex = 12;
            B_EditPlayerItems.Text = "Edit Items";
            B_EditPlayerItems.UseVisualStyleBackColor = true;
            B_EditPlayerItems.Click += B_EditPlayerItems_Click;
            // 
            // L_Wallet
            // 
            L_Wallet.Location = new System.Drawing.Point(166, 59);
            L_Wallet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Wallet.Name = "L_Wallet";
            L_Wallet.Size = new System.Drawing.Size(98, 23);
            L_Wallet.TabIndex = 11;
            L_Wallet.Text = "Wallet:";
            L_Wallet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Wallet
            // 
            NUD_Wallet.Location = new System.Drawing.Point(271, 59);
            NUD_Wallet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_Wallet.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            NUD_Wallet.Name = "NUD_Wallet";
            NUD_Wallet.Size = new System.Drawing.Size(117, 23);
            NUD_Wallet.TabIndex = 10;
            NUD_Wallet.ValueChanged += NUD_Wallet_ValueChanged;
            // 
            // L_NookMiles
            // 
            L_NookMiles.Location = new System.Drawing.Point(166, 110);
            L_NookMiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_NookMiles.Name = "L_NookMiles";
            L_NookMiles.Size = new System.Drawing.Size(98, 23);
            L_NookMiles.TabIndex = 9;
            L_NookMiles.Text = "Nook Miles:";
            L_NookMiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_NookMiles
            // 
            NUD_NookMiles.Location = new System.Drawing.Point(271, 110);
            NUD_NookMiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_NookMiles.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            NUD_NookMiles.Name = "NUD_NookMiles";
            NUD_NookMiles.Size = new System.Drawing.Size(117, 23);
            NUD_NookMiles.TabIndex = 8;
            // 
            // L_BankBells
            // 
            L_BankBells.Location = new System.Drawing.Point(166, 84);
            L_BankBells.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_BankBells.Name = "L_BankBells";
            L_BankBells.Size = new System.Drawing.Size(98, 23);
            L_BankBells.TabIndex = 7;
            L_BankBells.Text = "Bank Bells:";
            L_BankBells.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_BankBells
            // 
            NUD_BankBells.Location = new System.Drawing.Point(271, 84);
            NUD_BankBells.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_BankBells.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            NUD_BankBells.Name = "NUD_BankBells";
            NUD_BankBells.Size = new System.Drawing.Size(117, 23);
            NUD_BankBells.TabIndex = 6;
            // 
            // TB_TownName
            // 
            TB_TownName.Location = new System.Drawing.Point(271, 33);
            TB_TownName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TB_TownName.Name = "TB_TownName";
            TB_TownName.Size = new System.Drawing.Size(116, 23);
            TB_TownName.TabIndex = 5;
            // 
            // TB_Name
            // 
            TB_Name.Location = new System.Drawing.Point(271, 8);
            TB_Name.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TB_Name.Name = "TB_Name";
            TB_Name.Size = new System.Drawing.Size(116, 23);
            TB_Name.TabIndex = 3;
            // 
            // L_TownName
            // 
            L_TownName.Location = new System.Drawing.Point(166, 33);
            L_TownName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_TownName.Name = "L_TownName";
            L_TownName.Size = new System.Drawing.Size(98, 23);
            L_TownName.TabIndex = 4;
            L_TownName.Text = "Town Name:";
            L_TownName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_PlayerName
            // 
            L_PlayerName.Location = new System.Drawing.Point(166, 8);
            L_PlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_PlayerName.Name = "L_PlayerName";
            L_PlayerName.Size = new System.Drawing.Size(98, 23);
            L_PlayerName.TabIndex = 2;
            L_PlayerName.Text = "Player Name:";
            L_PlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Players
            // 
            CB_Players.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_Players.FormattingEnabled = true;
            CB_Players.Location = new System.Drawing.Point(7, 7);
            CB_Players.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CB_Players.Name = "CB_Players";
            CB_Players.Size = new System.Drawing.Size(151, 23);
            CB_Players.TabIndex = 1;
            CB_Players.SelectedIndexChanged += LoadPlayer;
            // 
            // PB_Player
            // 
            PB_Player.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PB_Player.ContextMenuStrip = CM_Picture;
            PB_Player.Location = new System.Drawing.Point(7, 38);
            PB_Player.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PB_Player.Name = "PB_Player";
            PB_Player.Size = new System.Drawing.Size(151, 150);
            PB_Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            PB_Player.TabIndex = 0;
            PB_Player.TabStop = false;
            // 
            // TC_Editors
            // 
            TC_Editors.Controls.Add(Tab_Players);
            TC_Editors.Controls.Add(Tab_Villagers);
            TC_Editors.Controls.Add(Tab_Map);
            TC_Editors.Location = new System.Drawing.Point(0, 28);
            TC_Editors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TC_Editors.Name = "TC_Editors";
            TC_Editors.SelectedIndex = 0;
            TC_Editors.Size = new System.Drawing.Size(471, 331);
            TC_Editors.TabIndex = 1;
            // 
            // Editor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(471, 359);
            Controls.Add(TC_Editors);
            Controls.Add(Menu_Editor);
            Icon = Properties.Resources.icon;
            MainMenuStrip = Menu_Editor;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Editor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "NHSE";
            Menu_Editor.ResumeLayout(false);
            Menu_Editor.PerformLayout();
            CM_Picture.ResumeLayout(false);
            Tab_Map.ResumeLayout(false);
            Tab_Map.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_WeatherSeed).EndInit();
            CM_EditMap.ResumeLayout(false);
            Tab_Players.ResumeLayout(false);
            Tab_Players.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_HotelTickets).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Poki).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_TotalNookMiles).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_StorageCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_PocketCount2).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_PocketCount1).EndInit();
            CM_EditPlayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NUD_Wallet).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_NookMiles).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_BankBells).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Player).EndInit();
            TC_Editors.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu_Editor;
        private System.Windows.Forms.ToolStripMenuItem Menu_File;
        private System.Windows.Forms.ToolStripMenuItem Menu_Save;
        private System.Windows.Forms.ToolStripMenuItem Menu_Tools;
        private System.Windows.Forms.ToolStripMenuItem Menu_DumpDecrypted;
        private System.Windows.Forms.ContextMenuStrip CM_Picture;
        private System.Windows.Forms.ToolStripMenuItem Menu_SavePNG;
        private System.Windows.Forms.ToolStripMenuItem Menu_VerifyHashes;
        private System.Windows.Forms.ToolStripMenuItem Menu_LoadDecrypted;
        private System.Windows.Forms.ToolStripMenuItem Menu_RAMEdit;
        private System.Windows.Forms.ToolStripMenuItem Menu_Options;
        private System.Windows.Forms.ToolStripComboBox Menu_Language;
        private System.Windows.Forms.ToolStripMenuItem Menu_Settings;
        private System.Windows.Forms.TabPage Tab_Map;
        private System.Windows.Forms.Button B_EditTurnipExchange;
        private System.Windows.Forms.Button B_RecycleBin;
        private System.Windows.Forms.TabPage Tab_Villagers;
        private System.Windows.Forms.TabPage Tab_Players;
        private System.Windows.Forms.Button B_EditPlayerItems;
        private System.Windows.Forms.Label L_Wallet;
        private System.Windows.Forms.NumericUpDown NUD_Wallet;
        private System.Windows.Forms.Label L_NookMiles;
        private System.Windows.Forms.NumericUpDown NUD_NookMiles;
        private System.Windows.Forms.Label L_BankBells;
        private System.Windows.Forms.NumericUpDown NUD_BankBells;
        private System.Windows.Forms.TextBox TB_TownName;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.Label L_TownName;
        private System.Windows.Forms.Label L_PlayerName;
        private System.Windows.Forms.ComboBox CB_Players;
        private System.Windows.Forms.PictureBox PB_Player;
        private System.Windows.Forms.TabControl TC_Editors;
        private System.Windows.Forms.Button B_EditPatterns;
        private System.Windows.Forms.Button B_EditPRODesigns;
        private System.Windows.Forms.Button B_EditMap;
        private System.Windows.Forms.ContextMenuStrip CM_EditMap;
        private System.Windows.Forms.ToolStripMenuItem B_EditFieldItems;
        private System.Windows.Forms.ContextMenuStrip CM_EditPlayer;
        private System.Windows.Forms.ToolStripMenuItem B_EditPlayerStorage;
        private System.Windows.Forms.ToolStripMenuItem B_EditPlayerReceivedItems;
        private System.Windows.Forms.ToolStripMenuItem B_EditAchievements;
        private System.Windows.Forms.ToolStripMenuItem B_EditPlayerRecipes;
        private System.Windows.Forms.Button B_EditPlayer;
        private System.Windows.Forms.Button B_EditPlayerHouses;
        private System.Windows.Forms.Label L_PocketCount2;
        private System.Windows.Forms.Label L_PocketCount1;
        private System.Windows.Forms.NumericUpDown NUD_PocketCount2;
        private System.Windows.Forms.NumericUpDown NUD_PocketCount1;
        private System.Windows.Forms.ToolStripMenuItem B_EditBulletin;
        private System.Windows.Forms.Label L_StorageCount;
        private System.Windows.Forms.NumericUpDown NUD_StorageCount;
        private System.Windows.Forms.ToolStripMenuItem B_EditPlayerFlags;
        private System.Windows.Forms.Label L_EarnedMiles;
        private System.Windows.Forms.NumericUpDown NUD_TotalNookMiles;
        private System.Windows.Forms.Label L_Hemisphere;
        private System.Windows.Forms.ComboBox CB_Hemisphere;
        private System.Windows.Forms.ToolStripMenuItem B_EditPlayerReactions;
        private System.Windows.Forms.ToolStripMenuItem B_EditLandFlags;
        private System.Windows.Forms.ToolStripMenuItem B_EditPlayerMisc;
        private System.Windows.Forms.Label L_AirportColor;
        private System.Windows.Forms.ComboBox CB_AirportColor;
        private System.Windows.Forms.Button B_EditDesignsTailor;
        private System.Windows.Forms.Button B_EditPatternFlag;
        private System.Windows.Forms.ToolStripMenuItem B_EditMuseum_Click;
        private System.Windows.Forms.ToolStripMenuItem B_EditVisitors;
        private System.Windows.Forms.Label L_WeatherSeed;
        private System.Windows.Forms.NumericUpDown NUD_WeatherSeed;
        private System.Windows.Forms.ToolStripMenuItem Menu_ItemImages;
        private System.Windows.Forms.Label L_Poki;
        private System.Windows.Forms.NumericUpDown NUD_Poki;
        private System.Windows.Forms.Label L_HotelTickets;
        private System.Windows.Forms.NumericUpDown NUD_HotelTickets;
        private System.Windows.Forms.Button B_EditCampsite;
        private System.Windows.Forms.ToolStripMenuItem Menu_Theme;
        private System.Windows.Forms.ToolStripMenuItem Menu_Theme_System;
        private System.Windows.Forms.ToolStripMenuItem Menu_Theme_Classic;
        private System.Windows.Forms.ToolStripMenuItem Menu_Theme_Dark;
        private System.Windows.Forms.Button B_EditFruitFlower;
    }
}


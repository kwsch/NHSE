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
            this.components = new System.ComponentModel.Container();
            this.Menu_Editor = new System.Windows.Forms.MenuStrip();
            this.Menu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_DumpDecrypted = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_VerifyHashes = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_LoadDecrypted = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_RAMEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Language = new System.Windows.Forms.ToolStripComboBox();
            this.Menu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Picture = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_SavePNG = new System.Windows.Forms.ToolStripMenuItem();
            this.Tab_Map = new System.Windows.Forms.TabPage();
            this.B_EditDesignsTailor = new System.Windows.Forms.Button();
            this.B_EditPatternFlag = new System.Windows.Forms.Button();
            this.CB_AirportColor = new System.Windows.Forms.ComboBox();
            this.L_AirportColor = new System.Windows.Forms.Label();
            this.L_Hemisphere = new System.Windows.Forms.Label();
            this.CB_Hemisphere = new System.Windows.Forms.ComboBox();
            this.B_EditPlayerHouses = new System.Windows.Forms.Button();
            this.B_EditMap = new System.Windows.Forms.Button();
            this.CM_EditMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.B_EditLandFlags = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditFieldItems = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditBulletin = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditFieldGoods = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditMuseum_Click = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditVisitors = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditPRODesigns = new System.Windows.Forms.Button();
            this.B_EditPatterns = new System.Windows.Forms.Button();
            this.B_EditTurnipExchange = new System.Windows.Forms.Button();
            this.B_RecycleBin = new System.Windows.Forms.Button();
            this.Tab_Villagers = new System.Windows.Forms.TabPage();
            this.Tab_Players = new System.Windows.Forms.TabPage();
            this.L_EarnedMiles = new System.Windows.Forms.Label();
            this.NUD_TotalNookMiles = new System.Windows.Forms.NumericUpDown();
            this.L_StorageCount = new System.Windows.Forms.Label();
            this.NUD_StorageCount = new System.Windows.Forms.NumericUpDown();
            this.L_PocketCount2 = new System.Windows.Forms.Label();
            this.L_PocketCount1 = new System.Windows.Forms.Label();
            this.NUD_PocketCount2 = new System.Windows.Forms.NumericUpDown();
            this.NUD_PocketCount1 = new System.Windows.Forms.NumericUpDown();
            this.B_EditPlayer = new System.Windows.Forms.Button();
            this.CM_EditPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.B_EditPlayerStorage = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditPlayerReceivedItems = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditAchievements = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditPlayerRecipes = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditPlayerFlags = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditPlayerReactions = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditPlayerMisc = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditPlayerItems = new System.Windows.Forms.Button();
            this.L_Wallet = new System.Windows.Forms.Label();
            this.NUD_Wallet = new System.Windows.Forms.NumericUpDown();
            this.L_NookMiles = new System.Windows.Forms.Label();
            this.NUD_NookMiles = new System.Windows.Forms.NumericUpDown();
            this.L_BankBells = new System.Windows.Forms.Label();
            this.NUD_BankBells = new System.Windows.Forms.NumericUpDown();
            this.TB_TownName = new System.Windows.Forms.TextBox();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.L_TownName = new System.Windows.Forms.Label();
            this.L_PlayerName = new System.Windows.Forms.Label();
            this.CB_Players = new System.Windows.Forms.ComboBox();
            this.PB_Player = new System.Windows.Forms.PictureBox();
            this.TC_Editors = new System.Windows.Forms.TabControl();
            this.L_WeatherSeed = new System.Windows.Forms.Label();
            this.NUD_WeatherSeed = new System.Windows.Forms.NumericUpDown();
            this.Menu_Editor.SuspendLayout();
            this.CM_Picture.SuspendLayout();
            this.Tab_Map.SuspendLayout();
            this.CM_EditMap.SuspendLayout();
            this.Tab_Players.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TotalNookMiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_StorageCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PocketCount2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PocketCount1)).BeginInit();
            this.CM_EditPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Wallet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NookMiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BankBells)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Player)).BeginInit();
            this.TC_Editors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_WeatherSeed)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu_Editor
            // 
            this.Menu_Editor.BackColor = System.Drawing.SystemColors.Control;
            this.Menu_Editor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File,
            this.Menu_Tools,
            this.Menu_Options});
            this.Menu_Editor.Location = new System.Drawing.Point(0, 0);
            this.Menu_Editor.Name = "Menu_Editor";
            this.Menu_Editor.Size = new System.Drawing.Size(404, 24);
            this.Menu_Editor.TabIndex = 0;
            this.Menu_Editor.Text = "menuStrip1";
            // 
            // Menu_File
            // 
            this.Menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Save});
            this.Menu_File.Name = "Menu_File";
            this.Menu_File.Size = new System.Drawing.Size(37, 20);
            this.Menu_File.Text = "File";
            // 
            // Menu_Save
            // 
            this.Menu_Save.Name = "Menu_Save";
            this.Menu_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Menu_Save.Size = new System.Drawing.Size(138, 22);
            this.Menu_Save.Text = "Save";
            this.Menu_Save.Click += new System.EventHandler(this.Menu_Save_Click);
            // 
            // Menu_Tools
            // 
            this.Menu_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_DumpDecrypted,
            this.Menu_VerifyHashes,
            this.Menu_LoadDecrypted,
            this.Menu_RAMEdit});
            this.Menu_Tools.Name = "Menu_Tools";
            this.Menu_Tools.Size = new System.Drawing.Size(46, 20);
            this.Menu_Tools.Text = "Tools";
            // 
            // Menu_DumpDecrypted
            // 
            this.Menu_DumpDecrypted.Name = "Menu_DumpDecrypted";
            this.Menu_DumpDecrypted.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.Menu_DumpDecrypted.Size = new System.Drawing.Size(206, 22);
            this.Menu_DumpDecrypted.Text = "Dump Decrypted";
            this.Menu_DumpDecrypted.Click += new System.EventHandler(this.Menu_DumpDecrypted_Click);
            // 
            // Menu_VerifyHashes
            // 
            this.Menu_VerifyHashes.Name = "Menu_VerifyHashes";
            this.Menu_VerifyHashes.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.Menu_VerifyHashes.Size = new System.Drawing.Size(206, 22);
            this.Menu_VerifyHashes.Text = "Verify Hashes";
            this.Menu_VerifyHashes.Click += new System.EventHandler(this.Menu_VerifyHashes_Click);
            // 
            // Menu_LoadDecrypted
            // 
            this.Menu_LoadDecrypted.Name = "Menu_LoadDecrypted";
            this.Menu_LoadDecrypted.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.Menu_LoadDecrypted.Size = new System.Drawing.Size(206, 22);
            this.Menu_LoadDecrypted.Text = "Load Decrypted";
            this.Menu_LoadDecrypted.Click += new System.EventHandler(this.Menu_LoadDecrypted_Click);
            // 
            // Menu_RAMEdit
            // 
            this.Menu_RAMEdit.Name = "Menu_RAMEdit";
            this.Menu_RAMEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.Menu_RAMEdit.Size = new System.Drawing.Size(206, 22);
            this.Menu_RAMEdit.Text = "RAM Edit";
            this.Menu_RAMEdit.Click += new System.EventHandler(this.Menu_RAMEdit_Click);
            // 
            // Menu_Options
            // 
            this.Menu_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Language,
            this.Menu_Settings});
            this.Menu_Options.Name = "Menu_Options";
            this.Menu_Options.Size = new System.Drawing.Size(61, 20);
            this.Menu_Options.Text = "Options";
            // 
            // Menu_Language
            // 
            this.Menu_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Menu_Language.Items.AddRange(new object[] {
            "English",
            "日本語",
            "Deutsch",
            "Español",
            "Français",
            "Italiano",
            "한국어",
            "简体中文",
            "繁體中文"});
            this.Menu_Language.Name = "Menu_Language";
            this.Menu_Language.Size = new System.Drawing.Size(115, 23);
            this.Menu_Language.SelectedIndexChanged += new System.EventHandler(this.Menu_Language_SelectedIndexChanged);
            // 
            // Menu_Settings
            // 
            this.Menu_Settings.Name = "Menu_Settings";
            this.Menu_Settings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.Menu_Settings.Size = new System.Drawing.Size(175, 22);
            this.Menu_Settings.Text = "Settings";
            this.Menu_Settings.Click += new System.EventHandler(this.Menu_Settings_Click);
            // 
            // CM_Picture
            // 
            this.CM_Picture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_SavePNG});
            this.CM_Picture.Name = "CM_Picture";
            this.CM_Picture.ShowImageMargin = false;
            this.CM_Picture.Size = new System.Drawing.Size(101, 26);
            // 
            // Menu_SavePNG
            // 
            this.Menu_SavePNG.Name = "Menu_SavePNG";
            this.Menu_SavePNG.Size = new System.Drawing.Size(100, 22);
            this.Menu_SavePNG.Text = "Save .png";
            this.Menu_SavePNG.Click += new System.EventHandler(this.Menu_SavePNG_Click);
            // 
            // Tab_Map
            // 
            this.Tab_Map.Controls.Add(this.NUD_WeatherSeed);
            this.Tab_Map.Controls.Add(this.L_WeatherSeed);
            this.Tab_Map.Controls.Add(this.B_EditDesignsTailor);
            this.Tab_Map.Controls.Add(this.B_EditPatternFlag);
            this.Tab_Map.Controls.Add(this.CB_AirportColor);
            this.Tab_Map.Controls.Add(this.L_AirportColor);
            this.Tab_Map.Controls.Add(this.L_Hemisphere);
            this.Tab_Map.Controls.Add(this.CB_Hemisphere);
            this.Tab_Map.Controls.Add(this.B_EditPlayerHouses);
            this.Tab_Map.Controls.Add(this.B_EditMap);
            this.Tab_Map.Controls.Add(this.B_EditPRODesigns);
            this.Tab_Map.Controls.Add(this.B_EditPatterns);
            this.Tab_Map.Controls.Add(this.B_EditTurnipExchange);
            this.Tab_Map.Controls.Add(this.B_RecycleBin);
            this.Tab_Map.Location = new System.Drawing.Point(4, 22);
            this.Tab_Map.Name = "Tab_Map";
            this.Tab_Map.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Map.Size = new System.Drawing.Size(396, 211);
            this.Tab_Map.TabIndex = 2;
            this.Tab_Map.Text = "Map";
            this.Tab_Map.UseVisualStyleBackColor = true;
            // 
            // B_EditDesignsTailor
            // 
            this.B_EditDesignsTailor.Location = new System.Drawing.Point(300, 98);
            this.B_EditDesignsTailor.Name = "B_EditDesignsTailor";
            this.B_EditDesignsTailor.Size = new System.Drawing.Size(92, 40);
            this.B_EditDesignsTailor.TabIndex = 63;
            this.B_EditDesignsTailor.Text = "Edit Tailor Designs";
            this.B_EditDesignsTailor.UseVisualStyleBackColor = true;
            this.B_EditDesignsTailor.Click += new System.EventHandler(this.B_EditDesignsTailor_Click);
            // 
            // B_EditPatternFlag
            // 
            this.B_EditPatternFlag.Location = new System.Drawing.Point(202, 98);
            this.B_EditPatternFlag.Name = "B_EditPatternFlag";
            this.B_EditPatternFlag.Size = new System.Drawing.Size(92, 40);
            this.B_EditPatternFlag.TabIndex = 62;
            this.B_EditPatternFlag.Text = "Edit Flag Design";
            this.B_EditPatternFlag.UseVisualStyleBackColor = true;
            this.B_EditPatternFlag.Click += new System.EventHandler(this.B_EditPatternFlag_Click);
            // 
            // CB_AirportColor
            // 
            this.CB_AirportColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_AirportColor.FormattingEnabled = true;
            this.CB_AirportColor.Location = new System.Drawing.Point(202, 32);
            this.CB_AirportColor.Name = "CB_AirportColor";
            this.CB_AirportColor.Size = new System.Drawing.Size(92, 21);
            this.CB_AirportColor.TabIndex = 61;
            // 
            // L_AirportColor
            // 
            this.L_AirportColor.AutoSize = true;
            this.L_AirportColor.Location = new System.Drawing.Point(300, 35);
            this.L_AirportColor.Name = "L_AirportColor";
            this.L_AirportColor.Size = new System.Drawing.Size(64, 13);
            this.L_AirportColor.TabIndex = 60;
            this.L_AirportColor.Text = "Airport Color";
            // 
            // L_Hemisphere
            // 
            this.L_Hemisphere.AutoSize = true;
            this.L_Hemisphere.Location = new System.Drawing.Point(300, 9);
            this.L_Hemisphere.Name = "L_Hemisphere";
            this.L_Hemisphere.Size = new System.Drawing.Size(63, 13);
            this.L_Hemisphere.TabIndex = 58;
            this.L_Hemisphere.Text = "Hemisphere";
            // 
            // CB_Hemisphere
            // 
            this.CB_Hemisphere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Hemisphere.FormattingEnabled = true;
            this.CB_Hemisphere.Location = new System.Drawing.Point(202, 6);
            this.CB_Hemisphere.Name = "CB_Hemisphere";
            this.CB_Hemisphere.Size = new System.Drawing.Size(92, 21);
            this.CB_Hemisphere.TabIndex = 57;
            // 
            // B_EditPlayerHouses
            // 
            this.B_EditPlayerHouses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_EditPlayerHouses.Location = new System.Drawing.Point(6, 168);
            this.B_EditPlayerHouses.Name = "B_EditPlayerHouses";
            this.B_EditPlayerHouses.Size = new System.Drawing.Size(92, 40);
            this.B_EditPlayerHouses.TabIndex = 56;
            this.B_EditPlayerHouses.Text = "Edit Player Houses";
            this.B_EditPlayerHouses.UseVisualStyleBackColor = true;
            this.B_EditPlayerHouses.Click += new System.EventHandler(this.B_EditPlayerHouses_Click);
            // 
            // B_EditMap
            // 
            this.B_EditMap.ContextMenuStrip = this.CM_EditMap;
            this.B_EditMap.Location = new System.Drawing.Point(300, 168);
            this.B_EditMap.Name = "B_EditMap";
            this.B_EditMap.Size = new System.Drawing.Size(92, 40);
            this.B_EditMap.TabIndex = 2;
            this.B_EditMap.Text = "Edit Map...";
            this.B_EditMap.UseVisualStyleBackColor = true;
            this.B_EditMap.Click += new System.EventHandler(this.B_EditMap_Click);
            // 
            // CM_EditMap
            // 
            this.CM_EditMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_EditLandFlags,
            this.B_EditFieldItems,
            this.B_EditBulletin,
            this.B_EditFieldGoods,
            this.B_EditMuseum_Click,
            this.B_EditVisitors});
            this.CM_EditMap.Name = "CM_EditMap";
            this.CM_EditMap.Size = new System.Drawing.Size(172, 136);
            // 
            // B_EditLandFlags
            // 
            this.B_EditLandFlags.Name = "B_EditLandFlags";
            this.B_EditLandFlags.Size = new System.Drawing.Size(171, 22);
            this.B_EditLandFlags.Text = "Edit Flags";
            this.B_EditLandFlags.Click += new System.EventHandler(this.B_EditLandFlags_Click);
            // 
            // B_EditFieldItems
            // 
            this.B_EditFieldItems.Name = "B_EditFieldItems";
            this.B_EditFieldItems.Size = new System.Drawing.Size(171, 22);
            this.B_EditFieldItems.Text = "Edit Field Items";
            this.B_EditFieldItems.Click += new System.EventHandler(this.B_EditFieldItems_Click);
            // 
            // B_EditBulletin
            // 
            this.B_EditBulletin.Name = "B_EditBulletin";
            this.B_EditBulletin.Size = new System.Drawing.Size(171, 22);
            this.B_EditBulletin.Text = "Edit Bulletin Board";
            this.B_EditBulletin.Click += new System.EventHandler(this.B_EditBulletin_Click);
            // 
            // B_EditFieldGoods
            // 
            this.B_EditFieldGoods.Name = "B_EditFieldGoods";
            this.B_EditFieldGoods.Size = new System.Drawing.Size(171, 22);
            this.B_EditFieldGoods.Text = "Edit Field Goods";
            this.B_EditFieldGoods.Click += new System.EventHandler(this.B_EditFieldGoods_Click);
            // 
            // B_EditMuseum_Click
            // 
            this.B_EditMuseum_Click.Name = "B_EditMuseum_Click";
            this.B_EditMuseum_Click.Size = new System.Drawing.Size(171, 22);
            this.B_EditMuseum_Click.Text = "Edit Museum";
            this.B_EditMuseum_Click.Click += new System.EventHandler(this.B_EditMuseum_Click_Click);
            // 
            // B_EditVisitors
            // 
            this.B_EditVisitors.Name = "B_EditVisitors";
            this.B_EditVisitors.Size = new System.Drawing.Size(171, 22);
            this.B_EditVisitors.Text = "Edit Visitors";
            this.B_EditVisitors.Click += new System.EventHandler(this.B_EditVisitors_Click);
            // 
            // B_EditPRODesigns
            // 
            this.B_EditPRODesigns.Location = new System.Drawing.Point(104, 98);
            this.B_EditPRODesigns.Name = "B_EditPRODesigns";
            this.B_EditPRODesigns.Size = new System.Drawing.Size(92, 40);
            this.B_EditPRODesigns.TabIndex = 55;
            this.B_EditPRODesigns.Text = "Edit PRO Designs";
            this.B_EditPRODesigns.UseVisualStyleBackColor = true;
            this.B_EditPRODesigns.Click += new System.EventHandler(this.B_EditPRODesigns_Click);
            // 
            // B_EditPatterns
            // 
            this.B_EditPatterns.Location = new System.Drawing.Point(6, 98);
            this.B_EditPatterns.Name = "B_EditPatterns";
            this.B_EditPatterns.Size = new System.Drawing.Size(92, 40);
            this.B_EditPatterns.TabIndex = 54;
            this.B_EditPatterns.Text = "Edit Patterns";
            this.B_EditPatterns.UseVisualStyleBackColor = true;
            this.B_EditPatterns.Click += new System.EventHandler(this.B_EditPatterns_Click);
            // 
            // B_EditTurnipExchange
            // 
            this.B_EditTurnipExchange.Location = new System.Drawing.Point(6, 6);
            this.B_EditTurnipExchange.Name = "B_EditTurnipExchange";
            this.B_EditTurnipExchange.Size = new System.Drawing.Size(92, 40);
            this.B_EditTurnipExchange.TabIndex = 15;
            this.B_EditTurnipExchange.Text = "Edit Turnip Exchange";
            this.B_EditTurnipExchange.UseVisualStyleBackColor = true;
            this.B_EditTurnipExchange.Click += new System.EventHandler(this.B_EditTurnipExchange_Click);
            // 
            // B_RecycleBin
            // 
            this.B_RecycleBin.Location = new System.Drawing.Point(6, 52);
            this.B_RecycleBin.Name = "B_RecycleBin";
            this.B_RecycleBin.Size = new System.Drawing.Size(92, 40);
            this.B_RecycleBin.TabIndex = 13;
            this.B_RecycleBin.Text = "Edit Recycle Bin";
            this.B_RecycleBin.UseVisualStyleBackColor = true;
            this.B_RecycleBin.Click += new System.EventHandler(this.B_RecycleBin_Click);
            // 
            // Tab_Villagers
            // 
            this.Tab_Villagers.Location = new System.Drawing.Point(4, 22);
            this.Tab_Villagers.Name = "Tab_Villagers";
            this.Tab_Villagers.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Villagers.Size = new System.Drawing.Size(396, 211);
            this.Tab_Villagers.TabIndex = 0;
            this.Tab_Villagers.Text = "Villagers";
            this.Tab_Villagers.UseVisualStyleBackColor = true;
            // 
            // Tab_Players
            // 
            this.Tab_Players.Controls.Add(this.L_EarnedMiles);
            this.Tab_Players.Controls.Add(this.NUD_TotalNookMiles);
            this.Tab_Players.Controls.Add(this.L_StorageCount);
            this.Tab_Players.Controls.Add(this.NUD_StorageCount);
            this.Tab_Players.Controls.Add(this.L_PocketCount2);
            this.Tab_Players.Controls.Add(this.L_PocketCount1);
            this.Tab_Players.Controls.Add(this.NUD_PocketCount2);
            this.Tab_Players.Controls.Add(this.NUD_PocketCount1);
            this.Tab_Players.Controls.Add(this.B_EditPlayer);
            this.Tab_Players.Controls.Add(this.B_EditPlayerItems);
            this.Tab_Players.Controls.Add(this.L_Wallet);
            this.Tab_Players.Controls.Add(this.NUD_Wallet);
            this.Tab_Players.Controls.Add(this.L_NookMiles);
            this.Tab_Players.Controls.Add(this.NUD_NookMiles);
            this.Tab_Players.Controls.Add(this.L_BankBells);
            this.Tab_Players.Controls.Add(this.NUD_BankBells);
            this.Tab_Players.Controls.Add(this.TB_TownName);
            this.Tab_Players.Controls.Add(this.TB_Name);
            this.Tab_Players.Controls.Add(this.L_TownName);
            this.Tab_Players.Controls.Add(this.L_PlayerName);
            this.Tab_Players.Controls.Add(this.CB_Players);
            this.Tab_Players.Controls.Add(this.PB_Player);
            this.Tab_Players.Location = new System.Drawing.Point(4, 22);
            this.Tab_Players.Name = "Tab_Players";
            this.Tab_Players.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Players.Size = new System.Drawing.Size(396, 211);
            this.Tab_Players.TabIndex = 1;
            this.Tab_Players.Text = "Players";
            this.Tab_Players.UseVisualStyleBackColor = true;
            // 
            // L_EarnedMiles
            // 
            this.L_EarnedMiles.Location = new System.Drawing.Point(142, 117);
            this.L_EarnedMiles.Name = "L_EarnedMiles";
            this.L_EarnedMiles.Size = new System.Drawing.Size(84, 20);
            this.L_EarnedMiles.TabIndex = 26;
            this.L_EarnedMiles.Text = "Earned Miles:";
            this.L_EarnedMiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_TotalNookMiles
            // 
            this.NUD_TotalNookMiles.Location = new System.Drawing.Point(232, 117);
            this.NUD_TotalNookMiles.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUD_TotalNookMiles.Name = "NUD_TotalNookMiles";
            this.NUD_TotalNookMiles.Size = new System.Drawing.Size(100, 20);
            this.NUD_TotalNookMiles.TabIndex = 25;
            // 
            // L_StorageCount
            // 
            this.L_StorageCount.AutoSize = true;
            this.L_StorageCount.Location = new System.Drawing.Point(200, 145);
            this.L_StorageCount.Name = "L_StorageCount";
            this.L_StorageCount.Size = new System.Drawing.Size(75, 13);
            this.L_StorageCount.TabIndex = 24;
            this.L_StorageCount.Text = "Storage Count";
            this.L_StorageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NUD_StorageCount
            // 
            this.NUD_StorageCount.Location = new System.Drawing.Point(151, 142);
            this.NUD_StorageCount.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUD_StorageCount.Name = "NUD_StorageCount";
            this.NUD_StorageCount.Size = new System.Drawing.Size(46, 20);
            this.NUD_StorageCount.TabIndex = 23;
            this.NUD_StorageCount.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // L_PocketCount2
            // 
            this.L_PocketCount2.AutoSize = true;
            this.L_PocketCount2.Location = new System.Drawing.Point(148, 191);
            this.L_PocketCount2.Name = "L_PocketCount2";
            this.L_PocketCount2.Size = new System.Drawing.Size(81, 13);
            this.L_PocketCount2.TabIndex = 22;
            this.L_PocketCount2.Text = "Pocket Count 2";
            this.L_PocketCount2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_PocketCount1
            // 
            this.L_PocketCount1.AutoSize = true;
            this.L_PocketCount1.Location = new System.Drawing.Point(148, 170);
            this.L_PocketCount1.Name = "L_PocketCount1";
            this.L_PocketCount1.Size = new System.Drawing.Size(81, 13);
            this.L_PocketCount1.TabIndex = 21;
            this.L_PocketCount1.Text = "Pocket Count 1";
            this.L_PocketCount1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NUD_PocketCount2
            // 
            this.NUD_PocketCount2.Location = new System.Drawing.Point(104, 188);
            this.NUD_PocketCount2.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUD_PocketCount2.Name = "NUD_PocketCount2";
            this.NUD_PocketCount2.Size = new System.Drawing.Size(41, 20);
            this.NUD_PocketCount2.TabIndex = 20;
            this.NUD_PocketCount2.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NUD_PocketCount2.ValueChanged += new System.EventHandler(this.NUD_PocketCount_ValueChanged);
            // 
            // NUD_PocketCount1
            // 
            this.NUD_PocketCount1.Location = new System.Drawing.Point(104, 167);
            this.NUD_PocketCount1.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUD_PocketCount1.Name = "NUD_PocketCount1";
            this.NUD_PocketCount1.Size = new System.Drawing.Size(41, 20);
            this.NUD_PocketCount1.TabIndex = 19;
            this.NUD_PocketCount1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NUD_PocketCount1.ValueChanged += new System.EventHandler(this.NUD_PocketCount_ValueChanged);
            // 
            // B_EditPlayer
            // 
            this.B_EditPlayer.ContextMenuStrip = this.CM_EditPlayer;
            this.B_EditPlayer.Location = new System.Drawing.Point(300, 168);
            this.B_EditPlayer.Name = "B_EditPlayer";
            this.B_EditPlayer.Size = new System.Drawing.Size(92, 40);
            this.B_EditPlayer.TabIndex = 18;
            this.B_EditPlayer.Text = "Edit Player...";
            this.B_EditPlayer.UseVisualStyleBackColor = true;
            this.B_EditPlayer.Click += new System.EventHandler(this.B_EditPlayer_Click);
            // 
            // CM_EditPlayer
            // 
            this.CM_EditPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_EditPlayerStorage,
            this.B_EditPlayerReceivedItems,
            this.B_EditAchievements,
            this.B_EditPlayerRecipes,
            this.B_EditPlayerFlags,
            this.B_EditPlayerReactions,
            this.B_EditPlayerMisc});
            this.CM_EditPlayer.Name = "CM_EditPlayer";
            this.CM_EditPlayer.Size = new System.Drawing.Size(177, 158);
            // 
            // B_EditPlayerStorage
            // 
            this.B_EditPlayerStorage.Name = "B_EditPlayerStorage";
            this.B_EditPlayerStorage.Size = new System.Drawing.Size(176, 22);
            this.B_EditPlayerStorage.Text = "Edit Storage";
            this.B_EditPlayerStorage.Click += new System.EventHandler(this.B_Storage_Click);
            // 
            // B_EditPlayerReceivedItems
            // 
            this.B_EditPlayerReceivedItems.Name = "B_EditPlayerReceivedItems";
            this.B_EditPlayerReceivedItems.Size = new System.Drawing.Size(176, 22);
            this.B_EditPlayerReceivedItems.Text = "Edit Received Items";
            this.B_EditPlayerReceivedItems.Click += new System.EventHandler(this.B_EditPlayerReceivedItems_Click);
            // 
            // B_EditAchievements
            // 
            this.B_EditAchievements.Name = "B_EditAchievements";
            this.B_EditAchievements.Size = new System.Drawing.Size(176, 22);
            this.B_EditAchievements.Text = "Edit Achievements";
            this.B_EditAchievements.Click += new System.EventHandler(this.B_EditAchievements_Click);
            // 
            // B_EditPlayerRecipes
            // 
            this.B_EditPlayerRecipes.Name = "B_EditPlayerRecipes";
            this.B_EditPlayerRecipes.Size = new System.Drawing.Size(176, 22);
            this.B_EditPlayerRecipes.Text = "Edit Recipes";
            this.B_EditPlayerRecipes.Click += new System.EventHandler(this.B_EditPlayerRecipes_Click);
            // 
            // B_EditPlayerFlags
            // 
            this.B_EditPlayerFlags.Name = "B_EditPlayerFlags";
            this.B_EditPlayerFlags.Size = new System.Drawing.Size(176, 22);
            this.B_EditPlayerFlags.Text = "Edit Flags";
            this.B_EditPlayerFlags.Click += new System.EventHandler(this.B_EditPlayerFlags_Click);
            // 
            // B_EditPlayerReactions
            // 
            this.B_EditPlayerReactions.Name = "B_EditPlayerReactions";
            this.B_EditPlayerReactions.Size = new System.Drawing.Size(176, 22);
            this.B_EditPlayerReactions.Text = "Edit Reactions";
            this.B_EditPlayerReactions.Click += new System.EventHandler(this.B_EditPlayerReactions_Click);
            // 
            // B_EditPlayerMisc
            // 
            this.B_EditPlayerMisc.Name = "B_EditPlayerMisc";
            this.B_EditPlayerMisc.Size = new System.Drawing.Size(176, 22);
            this.B_EditPlayerMisc.Text = "Edit Misc";
            this.B_EditPlayerMisc.Click += new System.EventHandler(this.B_EditPlayerMisc_Click);
            // 
            // B_EditPlayerItems
            // 
            this.B_EditPlayerItems.Location = new System.Drawing.Point(6, 168);
            this.B_EditPlayerItems.Name = "B_EditPlayerItems";
            this.B_EditPlayerItems.Size = new System.Drawing.Size(92, 40);
            this.B_EditPlayerItems.TabIndex = 12;
            this.B_EditPlayerItems.Text = "Edit Items";
            this.B_EditPlayerItems.UseVisualStyleBackColor = true;
            this.B_EditPlayerItems.Click += new System.EventHandler(this.B_EditPlayerItems_Click);
            // 
            // L_Wallet
            // 
            this.L_Wallet.Location = new System.Drawing.Point(142, 51);
            this.L_Wallet.Name = "L_Wallet";
            this.L_Wallet.Size = new System.Drawing.Size(84, 20);
            this.L_Wallet.TabIndex = 11;
            this.L_Wallet.Text = "Wallet:";
            this.L_Wallet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Wallet
            // 
            this.NUD_Wallet.Location = new System.Drawing.Point(232, 51);
            this.NUD_Wallet.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUD_Wallet.Name = "NUD_Wallet";
            this.NUD_Wallet.Size = new System.Drawing.Size(100, 20);
            this.NUD_Wallet.TabIndex = 10;
            this.NUD_Wallet.ValueChanged += new System.EventHandler(this.NUD_Wallet_ValueChanged);
            // 
            // L_NookMiles
            // 
            this.L_NookMiles.Location = new System.Drawing.Point(142, 95);
            this.L_NookMiles.Name = "L_NookMiles";
            this.L_NookMiles.Size = new System.Drawing.Size(84, 20);
            this.L_NookMiles.TabIndex = 9;
            this.L_NookMiles.Text = "Nook Miles:";
            this.L_NookMiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_NookMiles
            // 
            this.NUD_NookMiles.Location = new System.Drawing.Point(232, 95);
            this.NUD_NookMiles.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUD_NookMiles.Name = "NUD_NookMiles";
            this.NUD_NookMiles.Size = new System.Drawing.Size(100, 20);
            this.NUD_NookMiles.TabIndex = 8;
            // 
            // L_BankBells
            // 
            this.L_BankBells.Location = new System.Drawing.Point(142, 73);
            this.L_BankBells.Name = "L_BankBells";
            this.L_BankBells.Size = new System.Drawing.Size(84, 20);
            this.L_BankBells.TabIndex = 7;
            this.L_BankBells.Text = "Bank Bells:";
            this.L_BankBells.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_BankBells
            // 
            this.NUD_BankBells.Location = new System.Drawing.Point(232, 73);
            this.NUD_BankBells.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUD_BankBells.Name = "NUD_BankBells";
            this.NUD_BankBells.Size = new System.Drawing.Size(100, 20);
            this.NUD_BankBells.TabIndex = 6;
            // 
            // TB_TownName
            // 
            this.TB_TownName.Location = new System.Drawing.Point(232, 29);
            this.TB_TownName.Name = "TB_TownName";
            this.TB_TownName.Size = new System.Drawing.Size(100, 20);
            this.TB_TownName.TabIndex = 5;
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(232, 7);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(100, 20);
            this.TB_Name.TabIndex = 3;
            // 
            // L_TownName
            // 
            this.L_TownName.Location = new System.Drawing.Point(142, 29);
            this.L_TownName.Name = "L_TownName";
            this.L_TownName.Size = new System.Drawing.Size(84, 20);
            this.L_TownName.TabIndex = 4;
            this.L_TownName.Text = "Town Name:";
            this.L_TownName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_PlayerName
            // 
            this.L_PlayerName.Location = new System.Drawing.Point(142, 7);
            this.L_PlayerName.Name = "L_PlayerName";
            this.L_PlayerName.Size = new System.Drawing.Size(84, 20);
            this.L_PlayerName.TabIndex = 2;
            this.L_PlayerName.Text = "Player Name:";
            this.L_PlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Players
            // 
            this.CB_Players.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Players.FormattingEnabled = true;
            this.CB_Players.Location = new System.Drawing.Point(6, 6);
            this.CB_Players.Name = "CB_Players";
            this.CB_Players.Size = new System.Drawing.Size(130, 21);
            this.CB_Players.TabIndex = 1;
            this.CB_Players.SelectedIndexChanged += new System.EventHandler(this.LoadPlayer);
            // 
            // PB_Player
            // 
            this.PB_Player.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Player.ContextMenuStrip = this.CM_Picture;
            this.PB_Player.Location = new System.Drawing.Point(6, 33);
            this.PB_Player.Name = "PB_Player";
            this.PB_Player.Size = new System.Drawing.Size(130, 130);
            this.PB_Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Player.TabIndex = 0;
            this.PB_Player.TabStop = false;
            // 
            // TC_Editors
            // 
            this.TC_Editors.Controls.Add(this.Tab_Players);
            this.TC_Editors.Controls.Add(this.Tab_Villagers);
            this.TC_Editors.Controls.Add(this.Tab_Map);
            this.TC_Editors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC_Editors.Location = new System.Drawing.Point(0, 24);
            this.TC_Editors.Name = "TC_Editors";
            this.TC_Editors.SelectedIndex = 0;
            this.TC_Editors.Size = new System.Drawing.Size(404, 237);
            this.TC_Editors.TabIndex = 1;
            // 
            // L_WeatherSeed
            // 
            this.L_WeatherSeed.AutoSize = true;
            this.L_WeatherSeed.Location = new System.Drawing.Point(301, 66);
            this.L_WeatherSeed.Name = "L_WeatherSeed";
            this.L_WeatherSeed.Size = new System.Drawing.Size(63, 13);
            this.L_WeatherSeed.TabIndex = 64;
            this.L_WeatherSeed.Text = "Hemisphere";
            // 
            // NUD_WeatherSeed
            // 
            this.NUD_WeatherSeed.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_WeatherSeed.Location = new System.Drawing.Point(202, 59);
            this.NUD_WeatherSeed.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.NUD_WeatherSeed.Name = "NUD_WeatherSeed";
            this.NUD_WeatherSeed.Size = new System.Drawing.Size(93, 20);
            this.NUD_WeatherSeed.TabIndex = 65;
            this.NUD_WeatherSeed.Value = new decimal(new int[] {
            1234567890,
            0,
            0,
            0});
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 261);
            this.Controls.Add(this.TC_Editors);
            this.Controls.Add(this.Menu_Editor);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MainMenuStrip = this.Menu_Editor;
            this.MaximizeBox = false;
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHSE";
            this.Menu_Editor.ResumeLayout(false);
            this.Menu_Editor.PerformLayout();
            this.CM_Picture.ResumeLayout(false);
            this.Tab_Map.ResumeLayout(false);
            this.Tab_Map.PerformLayout();
            this.CM_EditMap.ResumeLayout(false);
            this.Tab_Players.ResumeLayout(false);
            this.Tab_Players.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TotalNookMiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_StorageCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PocketCount2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PocketCount1)).EndInit();
            this.CM_EditPlayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Wallet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NookMiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BankBells)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Player)).EndInit();
            this.TC_Editors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_WeatherSeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ToolStripMenuItem B_EditFieldGoods;
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
    }
}


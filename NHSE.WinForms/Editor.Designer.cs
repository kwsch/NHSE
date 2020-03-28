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
            this.Menu_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_DumpDecrypted = new System.Windows.Forms.ToolStripMenuItem();
            this.TC_Editors = new System.Windows.Forms.TabControl();
            this.Tab_Players = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.L_Wallet = new System.Windows.Forms.Label();
            this.NUD_Wallet = new System.Windows.Forms.NumericUpDown();
            this.L_NookMiles = new System.Windows.Forms.Label();
            this.NUD_NookMiles = new System.Windows.Forms.NumericUpDown();
            this.L_BankBells = new System.Windows.Forms.Label();
            this.NUD_BankBells = new System.Windows.Forms.NumericUpDown();
            this.TB_TownName = new System.Windows.Forms.TextBox();
            this.L_TownName = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.L_PlayerName = new System.Windows.Forms.Label();
            this.CB_Players = new System.Windows.Forms.ComboBox();
            this.PB_Player = new System.Windows.Forms.PictureBox();
            this.CM_Picture = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_SavePNG = new System.Windows.Forms.ToolStripMenuItem();
            this.Tab_Villagers = new System.Windows.Forms.TabPage();
            this.L_ExternalName = new System.Windows.Forms.Label();
            this.L_InternalName = new System.Windows.Forms.Label();
            this.TB_Catchphrase = new System.Windows.Forms.TextBox();
            this.L_Catchphrase = new System.Windows.Forms.Label();
            this.L_Personality = new System.Windows.Forms.Label();
            this.NUD_Variant = new System.Windows.Forms.NumericUpDown();
            this.L_Variant = new System.Windows.Forms.Label();
            this.NUD_Species = new System.Windows.Forms.NumericUpDown();
            this.L_Species = new System.Windows.Forms.Label();
            this.CB_Personality = new System.Windows.Forms.ComboBox();
            this.PB_Villager = new System.Windows.Forms.PictureBox();
            this.L_VillagerID = new System.Windows.Forms.Label();
            this.NUD_Villager = new System.Windows.Forms.NumericUpDown();
            this.Menu_Editor.SuspendLayout();
            this.TC_Editors.SuspendLayout();
            this.Tab_Players.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Wallet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NookMiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BankBells)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Player)).BeginInit();
            this.CM_Picture.SuspendLayout();
            this.Tab_Villagers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Variant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Species)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Villager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Villager)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu_Editor
            // 
            this.Menu_Editor.BackColor = System.Drawing.SystemColors.Control;
            this.Menu_Editor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File,
            this.Menu_Tools});
            this.Menu_Editor.Location = new System.Drawing.Point(0, 0);
            this.Menu_Editor.Name = "Menu_Editor";
            this.Menu_Editor.Size = new System.Drawing.Size(404, 24);
            this.Menu_Editor.TabIndex = 0;
            this.Menu_Editor.Text = "menuStrip1";
            // 
            // Menu_File
            // 
            this.Menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Open,
            this.Menu_Save});
            this.Menu_File.Name = "Menu_File";
            this.Menu_File.Size = new System.Drawing.Size(37, 20);
            this.Menu_File.Text = "File";
            // 
            // Menu_Open
            // 
            this.Menu_Open.Name = "Menu_Open";
            this.Menu_Open.Size = new System.Drawing.Size(103, 22);
            this.Menu_Open.Text = "Open";
            this.Menu_Open.Click += new System.EventHandler(this.Menu_Open_Click);
            // 
            // Menu_Save
            // 
            this.Menu_Save.Name = "Menu_Save";
            this.Menu_Save.Size = new System.Drawing.Size(103, 22);
            this.Menu_Save.Text = "Save";
            this.Menu_Save.Click += new System.EventHandler(this.Menu_Save_Click);
            // 
            // Menu_Tools
            // 
            this.Menu_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_DumpDecrypted});
            this.Menu_Tools.Name = "Menu_Tools";
            this.Menu_Tools.Size = new System.Drawing.Size(46, 20);
            this.Menu_Tools.Text = "Tools";
            // 
            // Menu_DumpDecrypted
            // 
            this.Menu_DumpDecrypted.Name = "Menu_DumpDecrypted";
            this.Menu_DumpDecrypted.Size = new System.Drawing.Size(164, 22);
            this.Menu_DumpDecrypted.Text = "Dump Decrypted";
            this.Menu_DumpDecrypted.Click += new System.EventHandler(this.Menu_DumpDecrypted_Click);
            // 
            // TC_Editors
            // 
            this.TC_Editors.Controls.Add(this.Tab_Players);
            this.TC_Editors.Controls.Add(this.Tab_Villagers);
            this.TC_Editors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC_Editors.Location = new System.Drawing.Point(0, 24);
            this.TC_Editors.Name = "TC_Editors";
            this.TC_Editors.SelectedIndex = 0;
            this.TC_Editors.Size = new System.Drawing.Size(404, 237);
            this.TC_Editors.TabIndex = 1;
            // 
            // Tab_Players
            // 
            this.Tab_Players.Controls.Add(this.button1);
            this.Tab_Players.Controls.Add(this.L_Wallet);
            this.Tab_Players.Controls.Add(this.NUD_Wallet);
            this.Tab_Players.Controls.Add(this.L_NookMiles);
            this.Tab_Players.Controls.Add(this.NUD_NookMiles);
            this.Tab_Players.Controls.Add(this.L_BankBells);
            this.Tab_Players.Controls.Add(this.NUD_BankBells);
            this.Tab_Players.Controls.Add(this.TB_TownName);
            this.Tab_Players.Controls.Add(this.L_TownName);
            this.Tab_Players.Controls.Add(this.TB_Name);
            this.Tab_Players.Controls.Add(this.L_PlayerName);
            this.Tab_Players.Controls.Add(this.CB_Players);
            this.Tab_Players.Controls.Add(this.PB_Player);
            this.Tab_Players.Location = new System.Drawing.Point(4, 22);
            this.Tab_Players.Name = "Tab_Players";
            this.Tab_Players.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Players.Size = new System.Drawing.Size(476, 211);
            this.Tab_Players.TabIndex = 1;
            this.Tab_Players.Text = "Players";
            this.Tab_Players.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 12;
            this.button1.Text = "Edit Items";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.B_EditPlayerItems_Click);
            // 
            // L_Wallet
            // 
            this.L_Wallet.Location = new System.Drawing.Point(142, 111);
            this.L_Wallet.Name = "L_Wallet";
            this.L_Wallet.Size = new System.Drawing.Size(84, 20);
            this.L_Wallet.TabIndex = 11;
            this.L_Wallet.Text = "Wallet:";
            this.L_Wallet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Wallet
            // 
            this.NUD_Wallet.Location = new System.Drawing.Point(232, 111);
            this.NUD_Wallet.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUD_Wallet.Name = "NUD_Wallet";
            this.NUD_Wallet.Size = new System.Drawing.Size(100, 20);
            this.NUD_Wallet.TabIndex = 10;
            // 
            // L_NookMiles
            // 
            this.L_NookMiles.Location = new System.Drawing.Point(142, 85);
            this.L_NookMiles.Name = "L_NookMiles";
            this.L_NookMiles.Size = new System.Drawing.Size(84, 20);
            this.L_NookMiles.TabIndex = 9;
            this.L_NookMiles.Text = "Nook Miles:";
            this.L_NookMiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_NookMiles
            // 
            this.NUD_NookMiles.Location = new System.Drawing.Point(232, 85);
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
            this.L_BankBells.Location = new System.Drawing.Point(142, 59);
            this.L_BankBells.Name = "L_BankBells";
            this.L_BankBells.Size = new System.Drawing.Size(84, 20);
            this.L_BankBells.TabIndex = 7;
            this.L_BankBells.Text = "Bank Bells:";
            this.L_BankBells.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_BankBells
            // 
            this.NUD_BankBells.Location = new System.Drawing.Point(232, 59);
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
            this.TB_TownName.Location = new System.Drawing.Point(232, 33);
            this.TB_TownName.Name = "TB_TownName";
            this.TB_TownName.Size = new System.Drawing.Size(100, 20);
            this.TB_TownName.TabIndex = 5;
            // 
            // L_TownName
            // 
            this.L_TownName.Location = new System.Drawing.Point(142, 33);
            this.L_TownName.Name = "L_TownName";
            this.L_TownName.Size = new System.Drawing.Size(84, 20);
            this.L_TownName.TabIndex = 4;
            this.L_TownName.Text = "Town Name:";
            this.L_TownName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(232, 7);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(100, 20);
            this.TB_Name.TabIndex = 3;
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
            // CM_Picture
            // 
            this.CM_Picture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_SavePNG});
            this.CM_Picture.Name = "CM_Picture";
            this.CM_Picture.Size = new System.Drawing.Size(126, 26);
            // 
            // Menu_SavePNG
            // 
            this.Menu_SavePNG.Name = "Menu_SavePNG";
            this.Menu_SavePNG.Size = new System.Drawing.Size(125, 22);
            this.Menu_SavePNG.Text = "Save .png";
            this.Menu_SavePNG.Click += new System.EventHandler(this.Menu_SavePNG_Click);
            // 
            // Tab_Villagers
            // 
            this.Tab_Villagers.Controls.Add(this.L_ExternalName);
            this.Tab_Villagers.Controls.Add(this.L_InternalName);
            this.Tab_Villagers.Controls.Add(this.TB_Catchphrase);
            this.Tab_Villagers.Controls.Add(this.L_Catchphrase);
            this.Tab_Villagers.Controls.Add(this.L_Personality);
            this.Tab_Villagers.Controls.Add(this.NUD_Variant);
            this.Tab_Villagers.Controls.Add(this.L_Variant);
            this.Tab_Villagers.Controls.Add(this.NUD_Species);
            this.Tab_Villagers.Controls.Add(this.L_Species);
            this.Tab_Villagers.Controls.Add(this.CB_Personality);
            this.Tab_Villagers.Controls.Add(this.PB_Villager);
            this.Tab_Villagers.Controls.Add(this.L_VillagerID);
            this.Tab_Villagers.Controls.Add(this.NUD_Villager);
            this.Tab_Villagers.Location = new System.Drawing.Point(4, 22);
            this.Tab_Villagers.Name = "Tab_Villagers";
            this.Tab_Villagers.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Villagers.Size = new System.Drawing.Size(396, 211);
            this.Tab_Villagers.TabIndex = 0;
            this.Tab_Villagers.Text = "Villagers";
            this.Tab_Villagers.UseVisualStyleBackColor = true;
            // 
            // L_ExternalName
            // 
            this.L_ExternalName.AutoSize = true;
            this.L_ExternalName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_ExternalName.Location = new System.Drawing.Point(275, 11);
            this.L_ExternalName.Name = "L_ExternalName";
            this.L_ExternalName.Size = new System.Drawing.Size(91, 14);
            this.L_ExternalName.TabIndex = 23;
            this.L_ExternalName.Text = "externalName";
            // 
            // L_InternalName
            // 
            this.L_InternalName.AutoSize = true;
            this.L_InternalName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_InternalName.Location = new System.Drawing.Point(275, 35);
            this.L_InternalName.Name = "L_InternalName";
            this.L_InternalName.Size = new System.Drawing.Size(91, 14);
            this.L_InternalName.TabIndex = 22;
            this.L_InternalName.Text = "internalName";
            // 
            // TB_Catchphrase
            // 
            this.TB_Catchphrase.Location = new System.Drawing.Point(232, 85);
            this.TB_Catchphrase.Name = "TB_Catchphrase";
            this.TB_Catchphrase.Size = new System.Drawing.Size(100, 20);
            this.TB_Catchphrase.TabIndex = 21;
            // 
            // L_Catchphrase
            // 
            this.L_Catchphrase.Location = new System.Drawing.Point(142, 85);
            this.L_Catchphrase.Name = "L_Catchphrase";
            this.L_Catchphrase.Size = new System.Drawing.Size(84, 20);
            this.L_Catchphrase.TabIndex = 20;
            this.L_Catchphrase.Text = "Catchphrase:";
            this.L_Catchphrase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Personality
            // 
            this.L_Personality.Location = new System.Drawing.Point(142, 59);
            this.L_Personality.Name = "L_Personality";
            this.L_Personality.Size = new System.Drawing.Size(84, 20);
            this.L_Personality.TabIndex = 19;
            this.L_Personality.Text = "Personality:";
            this.L_Personality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Variant
            // 
            this.NUD_Variant.Location = new System.Drawing.Point(232, 33);
            this.NUD_Variant.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_Variant.Name = "NUD_Variant";
            this.NUD_Variant.Size = new System.Drawing.Size(37, 20);
            this.NUD_Variant.TabIndex = 18;
            this.NUD_Variant.ValueChanged += new System.EventHandler(this.ChangeVillager);
            // 
            // L_Variant
            // 
            this.L_Variant.Location = new System.Drawing.Point(142, 33);
            this.L_Variant.Name = "L_Variant";
            this.L_Variant.Size = new System.Drawing.Size(84, 20);
            this.L_Variant.TabIndex = 17;
            this.L_Variant.Text = "Variant:";
            this.L_Variant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Species
            // 
            this.NUD_Species.Location = new System.Drawing.Point(232, 7);
            this.NUD_Species.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.NUD_Species.Name = "NUD_Species";
            this.NUD_Species.Size = new System.Drawing.Size(37, 20);
            this.NUD_Species.TabIndex = 16;
            this.NUD_Species.ValueChanged += new System.EventHandler(this.ChangeVillager);
            // 
            // L_Species
            // 
            this.L_Species.Location = new System.Drawing.Point(142, 7);
            this.L_Species.Name = "L_Species";
            this.L_Species.Size = new System.Drawing.Size(84, 20);
            this.L_Species.TabIndex = 15;
            this.L_Species.Text = "Species:";
            this.L_Species.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Personality
            // 
            this.CB_Personality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Personality.FormattingEnabled = true;
            this.CB_Personality.Location = new System.Drawing.Point(232, 59);
            this.CB_Personality.Name = "CB_Personality";
            this.CB_Personality.Size = new System.Drawing.Size(100, 21);
            this.CB_Personality.TabIndex = 14;
            // 
            // PB_Villager
            // 
            this.PB_Villager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Villager.ContextMenuStrip = this.CM_Picture;
            this.PB_Villager.Location = new System.Drawing.Point(6, 33);
            this.PB_Villager.Name = "PB_Villager";
            this.PB_Villager.Size = new System.Drawing.Size(130, 130);
            this.PB_Villager.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Villager.TabIndex = 13;
            this.PB_Villager.TabStop = false;
            // 
            // L_VillagerID
            // 
            this.L_VillagerID.Location = new System.Drawing.Point(6, 6);
            this.L_VillagerID.Name = "L_VillagerID";
            this.L_VillagerID.Size = new System.Drawing.Size(87, 20);
            this.L_VillagerID.TabIndex = 12;
            this.L_VillagerID.Text = "Villager Index:";
            this.L_VillagerID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Villager
            // 
            this.NUD_Villager.Location = new System.Drawing.Point(99, 6);
            this.NUD_Villager.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_Villager.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Villager.Name = "NUD_Villager";
            this.NUD_Villager.Size = new System.Drawing.Size(37, 20);
            this.NUD_Villager.TabIndex = 0;
            this.NUD_Villager.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Villager.ValueChanged += new System.EventHandler(this.LoadVillager);
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
            this.TC_Editors.ResumeLayout(false);
            this.Tab_Players.ResumeLayout(false);
            this.Tab_Players.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Wallet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NookMiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BankBells)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Player)).EndInit();
            this.CM_Picture.ResumeLayout(false);
            this.Tab_Villagers.ResumeLayout(false);
            this.Tab_Villagers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Variant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Species)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Villager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Villager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu_Editor;
        private System.Windows.Forms.ToolStripMenuItem Menu_File;
        private System.Windows.Forms.ToolStripMenuItem Menu_Open;
        private System.Windows.Forms.ToolStripMenuItem Menu_Save;
        private System.Windows.Forms.ToolStripMenuItem Menu_Tools;
        private System.Windows.Forms.TabControl TC_Editors;
        private System.Windows.Forms.TabPage Tab_Villagers;
        private System.Windows.Forms.TabPage Tab_Players;
        private System.Windows.Forms.PictureBox PB_Player;
        private System.Windows.Forms.ComboBox CB_Players;
        private System.Windows.Forms.Label L_PlayerName;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.TextBox TB_TownName;
        private System.Windows.Forms.Label L_TownName;
        private System.Windows.Forms.NumericUpDown NUD_BankBells;
        private System.Windows.Forms.Label L_BankBells;
        private System.Windows.Forms.Label L_NookMiles;
        private System.Windows.Forms.NumericUpDown NUD_NookMiles;
        private System.Windows.Forms.Label L_Wallet;
        private System.Windows.Forms.NumericUpDown NUD_Wallet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem Menu_DumpDecrypted;
        private System.Windows.Forms.Label L_VillagerID;
        private System.Windows.Forms.NumericUpDown NUD_Villager;
        private System.Windows.Forms.PictureBox PB_Villager;
        private System.Windows.Forms.Label L_Species;
        private System.Windows.Forms.ComboBox CB_Personality;
        private System.Windows.Forms.NumericUpDown NUD_Species;
        private System.Windows.Forms.NumericUpDown NUD_Variant;
        private System.Windows.Forms.Label L_Variant;
        private System.Windows.Forms.Label L_Personality;
        private System.Windows.Forms.TextBox TB_Catchphrase;
        private System.Windows.Forms.Label L_Catchphrase;
        private System.Windows.Forms.Label L_InternalName;
        private System.Windows.Forms.Label L_ExternalName;
        private System.Windows.Forms.ContextMenuStrip CM_Picture;
        private System.Windows.Forms.ToolStripMenuItem Menu_SavePNG;
    }
}


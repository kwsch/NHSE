namespace NHSE.WinForms
{
    partial class VillagerEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.B_EditVillagerFlags = new System.Windows.Forms.Button();
            this.CHK_VillagerMovingOut = new System.Windows.Forms.CheckBox();
            this.B_EditFurniture = new System.Windows.Forms.Button();
            this.B_LoadVillager = new System.Windows.Forms.Button();
            this.B_DumpVillager = new System.Windows.Forms.Button();
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
            this.B_EditHouses = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Variant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Species)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Villager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Villager)).BeginInit();
            this.SuspendLayout();
            // 
            // B_EditVillagerFlags
            // 
            this.B_EditVillagerFlags.Location = new System.Drawing.Point(297, 119);
            this.B_EditVillagerFlags.Name = "B_EditVillagerFlags";
            this.B_EditVillagerFlags.Size = new System.Drawing.Size(92, 40);
            this.B_EditVillagerFlags.TabIndex = 46;
            this.B_EditVillagerFlags.Text = "Edit Flags";
            this.B_EditVillagerFlags.UseVisualStyleBackColor = true;
            this.B_EditVillagerFlags.Click += new System.EventHandler(this.B_EditVillagerFlags_Click);
            // 
            // CHK_VillagerMovingOut
            // 
            this.CHK_VillagerMovingOut.AutoSize = true;
            this.CHK_VillagerMovingOut.Location = new System.Drawing.Point(229, 96);
            this.CHK_VillagerMovingOut.Name = "CHK_VillagerMovingOut";
            this.CHK_VillagerMovingOut.Size = new System.Drawing.Size(81, 17);
            this.CHK_VillagerMovingOut.TabIndex = 45;
            this.CHK_VillagerMovingOut.Text = "Moving Out";
            this.CHK_VillagerMovingOut.UseVisualStyleBackColor = true;
            this.CHK_VillagerMovingOut.CheckedChanged += new System.EventHandler(this.CHK_VillagerMovingOut_CheckedChanged);
            // 
            // B_EditFurniture
            // 
            this.B_EditFurniture.Location = new System.Drawing.Point(297, 165);
            this.B_EditFurniture.Name = "B_EditFurniture";
            this.B_EditFurniture.Size = new System.Drawing.Size(92, 40);
            this.B_EditFurniture.TabIndex = 44;
            this.B_EditFurniture.Text = "Edit Furniture";
            this.B_EditFurniture.UseVisualStyleBackColor = true;
            this.B_EditFurniture.Click += new System.EventHandler(this.B_EditFurniture_Click);
            // 
            // B_LoadVillager
            // 
            this.B_LoadVillager.Location = new System.Drawing.Point(101, 165);
            this.B_LoadVillager.Name = "B_LoadVillager";
            this.B_LoadVillager.Size = new System.Drawing.Size(92, 40);
            this.B_LoadVillager.TabIndex = 43;
            this.B_LoadVillager.Text = "Load Villager";
            this.B_LoadVillager.UseVisualStyleBackColor = true;
            this.B_LoadVillager.Click += new System.EventHandler(this.B_LoadVillager_Click);
            // 
            // B_DumpVillager
            // 
            this.B_DumpVillager.Location = new System.Drawing.Point(3, 165);
            this.B_DumpVillager.Name = "B_DumpVillager";
            this.B_DumpVillager.Size = new System.Drawing.Size(92, 40);
            this.B_DumpVillager.TabIndex = 42;
            this.B_DumpVillager.Text = "Dump Villager";
            this.B_DumpVillager.UseVisualStyleBackColor = true;
            this.B_DumpVillager.Click += new System.EventHandler(this.B_DumpVillager_Click);
            // 
            // L_ExternalName
            // 
            this.L_ExternalName.AutoSize = true;
            this.L_ExternalName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_ExternalName.Location = new System.Drawing.Point(272, 8);
            this.L_ExternalName.Name = "L_ExternalName";
            this.L_ExternalName.Size = new System.Drawing.Size(91, 14);
            this.L_ExternalName.TabIndex = 41;
            this.L_ExternalName.Text = "externalName";
            // 
            // L_InternalName
            // 
            this.L_InternalName.AutoSize = true;
            this.L_InternalName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_InternalName.Location = new System.Drawing.Point(272, 28);
            this.L_InternalName.Name = "L_InternalName";
            this.L_InternalName.Size = new System.Drawing.Size(91, 14);
            this.L_InternalName.TabIndex = 40;
            this.L_InternalName.Text = "internalName";
            // 
            // TB_Catchphrase
            // 
            this.TB_Catchphrase.Location = new System.Drawing.Point(229, 70);
            this.TB_Catchphrase.Name = "TB_Catchphrase";
            this.TB_Catchphrase.Size = new System.Drawing.Size(100, 20);
            this.TB_Catchphrase.TabIndex = 39;
            // 
            // L_Catchphrase
            // 
            this.L_Catchphrase.Location = new System.Drawing.Point(139, 70);
            this.L_Catchphrase.Name = "L_Catchphrase";
            this.L_Catchphrase.Size = new System.Drawing.Size(84, 20);
            this.L_Catchphrase.TabIndex = 38;
            this.L_Catchphrase.Text = "Catchphrase:";
            this.L_Catchphrase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Personality
            // 
            this.L_Personality.Location = new System.Drawing.Point(139, 48);
            this.L_Personality.Name = "L_Personality";
            this.L_Personality.Size = new System.Drawing.Size(84, 20);
            this.L_Personality.TabIndex = 37;
            this.L_Personality.Text = "Personality:";
            this.L_Personality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Variant
            // 
            this.NUD_Variant.Location = new System.Drawing.Point(229, 26);
            this.NUD_Variant.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_Variant.Name = "NUD_Variant";
            this.NUD_Variant.Size = new System.Drawing.Size(37, 20);
            this.NUD_Variant.TabIndex = 36;
            this.NUD_Variant.ValueChanged += new System.EventHandler(this.ChangeVillager);
            // 
            // L_Variant
            // 
            this.L_Variant.Location = new System.Drawing.Point(139, 26);
            this.L_Variant.Name = "L_Variant";
            this.L_Variant.Size = new System.Drawing.Size(84, 20);
            this.L_Variant.TabIndex = 35;
            this.L_Variant.Text = "Variant:";
            this.L_Variant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Species
            // 
            this.NUD_Species.Location = new System.Drawing.Point(229, 4);
            this.NUD_Species.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.NUD_Species.Name = "NUD_Species";
            this.NUD_Species.Size = new System.Drawing.Size(37, 20);
            this.NUD_Species.TabIndex = 34;
            this.NUD_Species.ValueChanged += new System.EventHandler(this.ChangeVillager);
            // 
            // L_Species
            // 
            this.L_Species.Location = new System.Drawing.Point(139, 4);
            this.L_Species.Name = "L_Species";
            this.L_Species.Size = new System.Drawing.Size(84, 20);
            this.L_Species.TabIndex = 33;
            this.L_Species.Text = "Species:";
            this.L_Species.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Personality
            // 
            this.CB_Personality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Personality.FormattingEnabled = true;
            this.CB_Personality.Location = new System.Drawing.Point(229, 48);
            this.CB_Personality.Name = "CB_Personality";
            this.CB_Personality.Size = new System.Drawing.Size(100, 21);
            this.CB_Personality.TabIndex = 32;
            // 
            // PB_Villager
            // 
            this.PB_Villager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Villager.Location = new System.Drawing.Point(3, 30);
            this.PB_Villager.Name = "PB_Villager";
            this.PB_Villager.Size = new System.Drawing.Size(130, 130);
            this.PB_Villager.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Villager.TabIndex = 31;
            this.PB_Villager.TabStop = false;
            // 
            // L_VillagerID
            // 
            this.L_VillagerID.Location = new System.Drawing.Point(3, 3);
            this.L_VillagerID.Name = "L_VillagerID";
            this.L_VillagerID.Size = new System.Drawing.Size(87, 20);
            this.L_VillagerID.TabIndex = 30;
            this.L_VillagerID.Text = "Villager Index:";
            this.L_VillagerID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Villager
            // 
            this.NUD_Villager.Location = new System.Drawing.Point(96, 3);
            this.NUD_Villager.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NUD_Villager.Name = "NUD_Villager";
            this.NUD_Villager.Size = new System.Drawing.Size(37, 20);
            this.NUD_Villager.TabIndex = 29;
            this.NUD_Villager.ValueChanged += new System.EventHandler(this.LoadVillager);
            // 
            // B_EditHouses
            // 
            this.B_EditHouses.Location = new System.Drawing.Point(199, 165);
            this.B_EditHouses.Name = "B_EditHouses";
            this.B_EditHouses.Size = new System.Drawing.Size(92, 40);
            this.B_EditHouses.TabIndex = 47;
            this.B_EditHouses.Text = "Edit House";
            this.B_EditHouses.UseVisualStyleBackColor = true;
            this.B_EditHouses.Click += new System.EventHandler(this.B_EditHouse_Click);
            // 
            // VillagerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.B_EditHouses);
            this.Controls.Add(this.B_EditVillagerFlags);
            this.Controls.Add(this.CHK_VillagerMovingOut);
            this.Controls.Add(this.B_EditFurniture);
            this.Controls.Add(this.B_LoadVillager);
            this.Controls.Add(this.B_DumpVillager);
            this.Controls.Add(this.L_ExternalName);
            this.Controls.Add(this.L_InternalName);
            this.Controls.Add(this.TB_Catchphrase);
            this.Controls.Add(this.L_Catchphrase);
            this.Controls.Add(this.L_Personality);
            this.Controls.Add(this.NUD_Variant);
            this.Controls.Add(this.L_Variant);
            this.Controls.Add(this.NUD_Species);
            this.Controls.Add(this.L_Species);
            this.Controls.Add(this.CB_Personality);
            this.Controls.Add(this.PB_Villager);
            this.Controls.Add(this.L_VillagerID);
            this.Controls.Add(this.NUD_Villager);
            this.Name = "VillagerEditor";
            this.Size = new System.Drawing.Size(397, 214);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Variant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Species)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Villager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Villager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_EditVillagerFlags;
        private System.Windows.Forms.CheckBox CHK_VillagerMovingOut;
        private System.Windows.Forms.Button B_EditFurniture;
        private System.Windows.Forms.Button B_LoadVillager;
        private System.Windows.Forms.Button B_DumpVillager;
        private System.Windows.Forms.Label L_ExternalName;
        private System.Windows.Forms.Label L_InternalName;
        private System.Windows.Forms.TextBox TB_Catchphrase;
        private System.Windows.Forms.Label L_Catchphrase;
        private System.Windows.Forms.Label L_Personality;
        private System.Windows.Forms.NumericUpDown NUD_Variant;
        private System.Windows.Forms.Label L_Variant;
        private System.Windows.Forms.NumericUpDown NUD_Species;
        private System.Windows.Forms.Label L_Species;
        private System.Windows.Forms.ComboBox CB_Personality;
        private System.Windows.Forms.PictureBox PB_Villager;
        private System.Windows.Forms.Label L_VillagerID;
        private System.Windows.Forms.NumericUpDown NUD_Villager;
        private System.Windows.Forms.Button B_EditHouses;
    }
}

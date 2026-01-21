namespace NHSE.WinForms
{
    partial class CampsiteEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PB_Villager = new System.Windows.Forms.PictureBox();
            L_ExternalName = new System.Windows.Forms.Label();
            L_InternalName = new System.Windows.Forms.Label();
            NUD_Variant = new System.Windows.Forms.NumericUpDown();
            L_Variant = new System.Windows.Forms.Label();
            NUD_Species = new System.Windows.Forms.NumericUpDown();
            L_Species = new System.Windows.Forms.Label();
            CB_CampsiteOccupied = new System.Windows.Forms.CheckBox();
            L_Camper_ExternalName = new System.Windows.Forms.Label();
            L_Camper_InternalName = new System.Windows.Forms.Label();
            L_Camper_Edit = new System.Windows.Forms.Label();
            L_CampsiteUnlockStatus = new System.Windows.Forms.Label();
            B_Cancel = new System.Windows.Forms.Button();
            B_Save = new System.Windows.Forms.Button();
            CAL_CampTimestamp = new System.Windows.Forms.DateTimePicker();
            L_CampDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)PB_Villager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Variant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Species).BeginInit();
            SuspendLayout();
            // 
            // PB_Villager
            // 
            PB_Villager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PB_Villager.Location = new System.Drawing.Point(17, 77);
            PB_Villager.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PB_Villager.Name = "PB_Villager";
            PB_Villager.Size = new System.Drawing.Size(151, 150);
            PB_Villager.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            PB_Villager.TabIndex = 59;
            PB_Villager.TabStop = false;
            // 
            // L_ExternalName
            // 
            L_ExternalName.AutoSize = true;
            L_ExternalName.Font = new System.Drawing.Font("Segoe UI", 9F);
            L_ExternalName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            L_ExternalName.Location = new System.Drawing.Point(98, 56);
            L_ExternalName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_ExternalName.Name = "L_ExternalName";
            L_ExternalName.Size = new System.Drawing.Size(57, 15);
            L_ExternalName.TabIndex = 65;
            L_ExternalName.Text = "unknown";
            L_ExternalName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_InternalName
            // 
            L_InternalName.AutoSize = true;
            L_InternalName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            L_InternalName.Location = new System.Drawing.Point(99, 235);
            L_InternalName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_InternalName.Name = "L_InternalName";
            L_InternalName.Size = new System.Drawing.Size(56, 14);
            L_InternalName.TabIndex = 64;
            L_InternalName.Text = "unknown";
            L_InternalName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NUD_Variant
            // 
            NUD_Variant.Location = new System.Drawing.Point(255, 104);
            NUD_Variant.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_Variant.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            NUD_Variant.Name = "NUD_Variant";
            NUD_Variant.Size = new System.Drawing.Size(37, 23);
            NUD_Variant.TabIndex = 63;
            NUD_Variant.ValueChanged += ChangeVillager;
            // 
            // L_Variant
            // 
            L_Variant.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            L_Variant.Location = new System.Drawing.Point(191, 104);
            L_Variant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Variant.Name = "L_Variant";
            L_Variant.Size = new System.Drawing.Size(56, 23);
            L_Variant.TabIndex = 62;
            L_Variant.Text = "Variant:";
            L_Variant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Species
            // 
            NUD_Species.Location = new System.Drawing.Point(255, 79);
            NUD_Species.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_Species.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            NUD_Species.Name = "NUD_Species";
            NUD_Species.Size = new System.Drawing.Size(37, 23);
            NUD_Species.TabIndex = 61;
            NUD_Species.ValueChanged += ChangeVillager;
            // 
            // L_Species
            // 
            L_Species.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            L_Species.Location = new System.Drawing.Point(191, 79);
            L_Species.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Species.Name = "L_Species";
            L_Species.Size = new System.Drawing.Size(56, 23);
            L_Species.TabIndex = 60;
            L_Species.Text = "Species:";
            L_Species.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_CampsiteOccupied
            // 
            CB_CampsiteOccupied.AutoSize = true;
            CB_CampsiteOccupied.Location = new System.Drawing.Point(17, 31);
            CB_CampsiteOccupied.Name = "CB_CampsiteOccupied";
            CB_CampsiteOccupied.Size = new System.Drawing.Size(135, 19);
            CB_CampsiteOccupied.TabIndex = 66;
            CB_CampsiteOccupied.Text = "Campsite Has Visitor";
            CB_CampsiteOccupied.UseVisualStyleBackColor = true;
            // 
            // L_Camper_ExternalName
            // 
            L_Camper_ExternalName.Location = new System.Drawing.Point(15, 52);
            L_Camper_ExternalName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Camper_ExternalName.Name = "L_Camper_ExternalName";
            L_Camper_ExternalName.Size = new System.Drawing.Size(80, 23);
            L_Camper_ExternalName.TabIndex = 67;
            L_Camper_ExternalName.Text = "Visitor Name:";
            L_Camper_ExternalName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Camper_InternalName
            // 
            L_Camper_InternalName.Location = new System.Drawing.Point(15, 230);
            L_Camper_InternalName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Camper_InternalName.Name = "L_Camper_InternalName";
            L_Camper_InternalName.Size = new System.Drawing.Size(80, 23);
            L_Camper_InternalName.TabIndex = 68;
            L_Camper_InternalName.Text = "Villager Code:";
            L_Camper_InternalName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Camper_Edit
            // 
            L_Camper_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            L_Camper_Edit.Location = new System.Drawing.Point(198, 54);
            L_Camper_Edit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Camper_Edit.Name = "L_Camper_Edit";
            L_Camper_Edit.Size = new System.Drawing.Size(68, 23);
            L_Camper_Edit.TabIndex = 69;
            L_Camper_Edit.Text = "Edit Visitor:";
            L_Camper_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_CampsiteUnlockStatus
            // 
            L_CampsiteUnlockStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            L_CampsiteUnlockStatus.ForeColor = System.Drawing.Color.Red;
            L_CampsiteUnlockStatus.Location = new System.Drawing.Point(61, 3);
            L_CampsiteUnlockStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_CampsiteUnlockStatus.Name = "L_CampsiteUnlockStatus";
            L_CampsiteUnlockStatus.Size = new System.Drawing.Size(313, 23);
            L_CampsiteUnlockStatus.TabIndex = 70;
            L_CampsiteUnlockStatus.Text = "Campsite is not currently unlocked on this save.";
            L_CampsiteUnlockStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // B_Cancel
            // 
            B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Cancel.Location = new System.Drawing.Point(215, 212);
            B_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Cancel.Name = "B_Cancel";
            B_Cancel.Size = new System.Drawing.Size(107, 46);
            B_Cancel.TabIndex = 72;
            B_Cancel.Text = "Cancel";
            B_Cancel.UseVisualStyleBackColor = true;
            B_Cancel.Click += B_Cancel_Click;
            // 
            // B_Save
            // 
            B_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Save.Location = new System.Drawing.Point(326, 212);
            B_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Save.Name = "B_Save";
            B_Save.Size = new System.Drawing.Size(107, 46);
            B_Save.TabIndex = 71;
            B_Save.Text = "Save";
            B_Save.UseVisualStyleBackColor = true;
            B_Save.Click += B_Save_Click;
            // 
            // CAL_CampTimestamp
            // 
            CAL_CampTimestamp.Location = new System.Drawing.Point(198, 165);
            CAL_CampTimestamp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CAL_CampTimestamp.Name = "CAL_CampTimestamp";
            CAL_CampTimestamp.Size = new System.Drawing.Size(233, 23);
            CAL_CampTimestamp.TabIndex = 73;
            // 
            // L_CampDate
            // 
            L_CampDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            L_CampDate.Location = new System.Drawing.Point(198, 140);
            L_CampDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_CampDate.Name = "L_CampDate";
            L_CampDate.Size = new System.Drawing.Size(124, 22);
            L_CampDate.TabIndex = 74;
            L_CampDate.Text = "Set Camp Visit Date:";
            L_CampDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CampsiteEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(441, 266);
            Controls.Add(L_CampDate);
            Controls.Add(CAL_CampTimestamp);
            Controls.Add(B_Cancel);
            Controls.Add(B_Save);
            Controls.Add(L_CampsiteUnlockStatus);
            Controls.Add(L_Camper_Edit);
            Controls.Add(L_Camper_InternalName);
            Controls.Add(L_Camper_ExternalName);
            Controls.Add(CB_CampsiteOccupied);
            Controls.Add(L_ExternalName);
            Controls.Add(L_InternalName);
            Controls.Add(NUD_Variant);
            Controls.Add(L_Variant);
            Controls.Add(NUD_Species);
            Controls.Add(L_Species);
            Controls.Add(PB_Villager);
            Icon = Properties.Resources.icon;
            Name = "CampsiteEditor";
            Text = "Campsite Editor";
            ((System.ComponentModel.ISupportInitialize)PB_Villager).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Variant).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Species).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.PictureBox PB_Villager;
        private System.Windows.Forms.Label L_ExternalName;
        private System.Windows.Forms.Label L_InternalName;
        private System.Windows.Forms.NumericUpDown NUD_Variant;
        private System.Windows.Forms.Label L_Variant;
        private System.Windows.Forms.NumericUpDown NUD_Species;
        private System.Windows.Forms.Label L_Species;
        private System.Windows.Forms.CheckBox CB_CampsiteOccupied;
        private System.Windows.Forms.Label L_Camper_ExternalName;
        private System.Windows.Forms.Label L_Camper_InternalName;
        private System.Windows.Forms.Label L_Camper_Edit;
        private System.Windows.Forms.Label L_CampsiteUnlockStatus;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.DateTimePicker CAL_CampTimestamp;
        private System.Windows.Forms.Label L_CampDate;
    }
}
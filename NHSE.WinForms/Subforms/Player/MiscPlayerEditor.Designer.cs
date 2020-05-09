namespace NHSE.WinForms
{
    partial class MiscPlayerEditor
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
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.L_Birthday = new System.Windows.Forms.Label();
            this.NUD_BirthMonth = new System.Windows.Forms.NumericUpDown();
            this.NUD_BirthDay = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Tab_Misc = new System.Windows.Forms.TabPage();
            this.Tab_Profile = new System.Windows.Forms.TabPage();
            this.ProfileFruit = new NHSE.WinForms.RestrictedItemSelect();
            this.CAL_ProfileTimestamp = new System.Windows.Forms.DateTimePicker();
            this.CHK_ProfileMadeVillage = new System.Windows.Forms.CheckBox();
            this.L_ProfileSpecialtyFruit = new System.Windows.Forms.Label();
            this.L_ProfileTimestamp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BirthMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BirthDay)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Tab_Misc.SuspendLayout();
            this.Tab_Profile.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(133, 181);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(72, 23);
            this.B_Cancel.TabIndex = 7;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.Location = new System.Drawing.Point(211, 181);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(72, 23);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // L_Birthday
            // 
            this.L_Birthday.Location = new System.Drawing.Point(6, 3);
            this.L_Birthday.Name = "L_Birthday";
            this.L_Birthday.Size = new System.Drawing.Size(104, 23);
            this.L_Birthday.TabIndex = 8;
            this.L_Birthday.Text = "Birthday (M/D):";
            this.L_Birthday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_BirthMonth
            // 
            this.NUD_BirthMonth.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_BirthMonth.Location = new System.Drawing.Point(116, 6);
            this.NUD_BirthMonth.Name = "NUD_BirthMonth";
            this.NUD_BirthMonth.Size = new System.Drawing.Size(37, 20);
            this.NUD_BirthMonth.TabIndex = 9;
            this.NUD_BirthMonth.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // NUD_BirthDay
            // 
            this.NUD_BirthDay.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_BirthDay.Location = new System.Drawing.Point(159, 6);
            this.NUD_BirthDay.Name = "NUD_BirthDay";
            this.NUD_BirthDay.Size = new System.Drawing.Size(37, 20);
            this.NUD_BirthDay.TabIndex = 10;
            this.NUD_BirthDay.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Tab_Misc);
            this.tabControl1.Controls.Add(this.Tab_Profile);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(271, 163);
            this.tabControl1.TabIndex = 12;
            // 
            // Tab_Misc
            // 
            this.Tab_Misc.Controls.Add(this.L_Birthday);
            this.Tab_Misc.Controls.Add(this.NUD_BirthDay);
            this.Tab_Misc.Controls.Add(this.NUD_BirthMonth);
            this.Tab_Misc.Location = new System.Drawing.Point(4, 22);
            this.Tab_Misc.Name = "Tab_Misc";
            this.Tab_Misc.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Misc.Size = new System.Drawing.Size(222, 112);
            this.Tab_Misc.TabIndex = 0;
            this.Tab_Misc.Text = "Misc";
            this.Tab_Misc.UseVisualStyleBackColor = true;
            // 
            // Tab_Profile
            // 
            this.Tab_Profile.Controls.Add(this.ProfileFruit);
            this.Tab_Profile.Controls.Add(this.CAL_ProfileTimestamp);
            this.Tab_Profile.Controls.Add(this.CHK_ProfileMadeVillage);
            this.Tab_Profile.Controls.Add(this.L_ProfileSpecialtyFruit);
            this.Tab_Profile.Controls.Add(this.L_ProfileTimestamp);
            this.Tab_Profile.Location = new System.Drawing.Point(4, 22);
            this.Tab_Profile.Name = "Tab_Profile";
            this.Tab_Profile.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Profile.Size = new System.Drawing.Size(263, 137);
            this.Tab_Profile.TabIndex = 1;
            this.Tab_Profile.Text = "Profile";
            this.Tab_Profile.UseVisualStyleBackColor = true;
            // 
            // restrictedItemSelect1
            // 
            this.ProfileFruit.Location = new System.Drawing.Point(9, 61);
            this.ProfileFruit.Name = "ProfileFruit";
            this.ProfileFruit.Size = new System.Drawing.Size(143, 48);
            this.ProfileFruit.TabIndex = 17;
            this.ProfileFruit.Value = ((ushort)(0));
            // 
            // CAL_ProfileTimestamp
            // 
            this.CAL_ProfileTimestamp.Location = new System.Drawing.Point(9, 22);
            this.CAL_ProfileTimestamp.Name = "CAL_ProfileTimestamp";
            this.CAL_ProfileTimestamp.Size = new System.Drawing.Size(200, 20);
            this.CAL_ProfileTimestamp.TabIndex = 16;
            // 
            // CHK_ProfileMadeVillage
            // 
            this.CHK_ProfileMadeVillage.AutoSize = true;
            this.CHK_ProfileMadeVillage.Location = new System.Drawing.Point(9, 115);
            this.CHK_ProfileMadeVillage.Name = "CHK_ProfileMadeVillage";
            this.CHK_ProfileMadeVillage.Size = new System.Drawing.Size(87, 17);
            this.CHK_ProfileMadeVillage.TabIndex = 15;
            this.CHK_ProfileMadeVillage.Text = "Made Village";
            this.CHK_ProfileMadeVillage.UseVisualStyleBackColor = true;
            // 
            // L_ProfileSpecialtyFruit
            // 
            this.L_ProfileSpecialtyFruit.AutoSize = true;
            this.L_ProfileSpecialtyFruit.Location = new System.Drawing.Point(6, 45);
            this.L_ProfileSpecialtyFruit.Name = "L_ProfileSpecialtyFruit";
            this.L_ProfileSpecialtyFruit.Size = new System.Drawing.Size(27, 13);
            this.L_ProfileSpecialtyFruit.TabIndex = 14;
            this.L_ProfileSpecialtyFruit.Text = "Fruit";
            // 
            // L_ProfileTimestamp
            // 
            this.L_ProfileTimestamp.AutoSize = true;
            this.L_ProfileTimestamp.Location = new System.Drawing.Point(6, 6);
            this.L_ProfileTimestamp.Name = "L_ProfileTimestamp";
            this.L_ProfileTimestamp.Size = new System.Drawing.Size(58, 13);
            this.L_ProfileTimestamp.TabIndex = 12;
            this.L_ProfileTimestamp.Text = "Timestamp";
            // 
            // MiscPlayerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 216);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MiscPlayerEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Misc Player Detail Editor";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BirthMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BirthDay)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Tab_Misc.ResumeLayout(false);
            this.Tab_Profile.ResumeLayout(false);
            this.Tab_Profile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Label L_Birthday;
        private System.Windows.Forms.NumericUpDown NUD_BirthMonth;
        private System.Windows.Forms.NumericUpDown NUD_BirthDay;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Tab_Misc;
        private System.Windows.Forms.TabPage Tab_Profile;
        private System.Windows.Forms.Label L_ProfileTimestamp;
        private System.Windows.Forms.Label L_ProfileSpecialtyFruit;
        private System.Windows.Forms.CheckBox CHK_ProfileMadeVillage;
        private System.Windows.Forms.DateTimePicker CAL_ProfileTimestamp;
        private RestrictedItemSelect ProfileFruit;
    }
}

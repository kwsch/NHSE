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
            B_Cancel = new System.Windows.Forms.Button();
            B_Save = new System.Windows.Forms.Button();
            L_Birthday = new System.Windows.Forms.Label();
            NUD_BirthMonth = new System.Windows.Forms.NumericUpDown();
            NUD_BirthDay = new System.Windows.Forms.NumericUpDown();
            tabControl1 = new System.Windows.Forms.TabControl();
            Tab_Misc = new System.Windows.Forms.TabPage();
            Tab_Profile = new System.Windows.Forms.TabPage();
            CB_SisterFlower = new System.Windows.Forms.ComboBox();
            CB_ProfileFlower = new System.Windows.Forms.ComboBox();
            L_ProfileSisterFlower = new System.Windows.Forms.Label();
            L_ProfileSpecialtyFlower = new System.Windows.Forms.Label();
            RIS_SisterFruit = new RestrictedItemSelect();
            L_ProfileSisterFruit = new System.Windows.Forms.Label();
            RIS_ProfileFruit = new RestrictedItemSelect();
            CAL_ProfileTimestamp = new System.Windows.Forms.DateTimePicker();
            CHK_ProfileMadeVillage = new System.Windows.Forms.CheckBox();
            L_ProfileSpecialtyFruit = new System.Windows.Forms.Label();
            L_ProfileTimestamp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)NUD_BirthMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_BirthDay).BeginInit();
            tabControl1.SuspendLayout();
            Tab_Misc.SuspendLayout();
            Tab_Profile.SuspendLayout();
            SuspendLayout();
            // 
            // B_Cancel
            // 
            B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Cancel.Location = new System.Drawing.Point(211, 279);
            B_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Cancel.Name = "B_Cancel";
            B_Cancel.Size = new System.Drawing.Size(84, 27);
            B_Cancel.TabIndex = 7;
            B_Cancel.Text = "Cancel";
            B_Cancel.UseVisualStyleBackColor = true;
            B_Cancel.Click += B_Cancel_Click;
            // 
            // B_Save
            // 
            B_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Save.Location = new System.Drawing.Point(302, 279);
            B_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Save.Name = "B_Save";
            B_Save.Size = new System.Drawing.Size(84, 27);
            B_Save.TabIndex = 6;
            B_Save.Text = "Save";
            B_Save.UseVisualStyleBackColor = true;
            B_Save.Click += B_Save_Click;
            // 
            // L_Birthday
            // 
            L_Birthday.Location = new System.Drawing.Point(7, 3);
            L_Birthday.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Birthday.Name = "L_Birthday";
            L_Birthday.Size = new System.Drawing.Size(121, 27);
            L_Birthday.TabIndex = 8;
            L_Birthday.Text = "Birthday (M/D):";
            L_Birthday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_BirthMonth
            // 
            NUD_BirthMonth.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            NUD_BirthMonth.Location = new System.Drawing.Point(135, 7);
            NUD_BirthMonth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_BirthMonth.Name = "NUD_BirthMonth";
            NUD_BirthMonth.Size = new System.Drawing.Size(43, 20);
            NUD_BirthMonth.TabIndex = 9;
            NUD_BirthMonth.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // NUD_BirthDay
            // 
            NUD_BirthDay.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            NUD_BirthDay.Location = new System.Drawing.Point(186, 7);
            NUD_BirthDay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_BirthDay.Name = "NUD_BirthDay";
            NUD_BirthDay.Size = new System.Drawing.Size(43, 20);
            NUD_BirthDay.TabIndex = 10;
            NUD_BirthDay.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // tabControl1
            // 
            tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl1.Controls.Add(Tab_Misc);
            tabControl1.Controls.Add(Tab_Profile);
            tabControl1.Location = new System.Drawing.Point(14, 14);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(372, 258);
            tabControl1.TabIndex = 12;
            // 
            // Tab_Misc
            // 
            Tab_Misc.Controls.Add(L_Birthday);
            Tab_Misc.Controls.Add(NUD_BirthDay);
            Tab_Misc.Controls.Add(NUD_BirthMonth);
            Tab_Misc.Location = new System.Drawing.Point(4, 24);
            Tab_Misc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Tab_Misc.Name = "Tab_Misc";
            Tab_Misc.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Tab_Misc.Size = new System.Drawing.Size(364, 230);
            Tab_Misc.TabIndex = 0;
            Tab_Misc.Text = "Misc";
            Tab_Misc.UseVisualStyleBackColor = true;
            // 
            // Tab_Profile
            // 
            Tab_Profile.Controls.Add(CB_SisterFlower);
            Tab_Profile.Controls.Add(CB_ProfileFlower);
            Tab_Profile.Controls.Add(L_ProfileSisterFlower);
            Tab_Profile.Controls.Add(L_ProfileSpecialtyFlower);
            Tab_Profile.Controls.Add(RIS_SisterFruit);
            Tab_Profile.Controls.Add(L_ProfileSisterFruit);
            Tab_Profile.Controls.Add(RIS_ProfileFruit);
            Tab_Profile.Controls.Add(CAL_ProfileTimestamp);
            Tab_Profile.Controls.Add(CHK_ProfileMadeVillage);
            Tab_Profile.Controls.Add(L_ProfileSpecialtyFruit);
            Tab_Profile.Controls.Add(L_ProfileTimestamp);
            Tab_Profile.Location = new System.Drawing.Point(4, 24);
            Tab_Profile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Tab_Profile.Name = "Tab_Profile";
            Tab_Profile.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Tab_Profile.Size = new System.Drawing.Size(364, 230);
            Tab_Profile.TabIndex = 1;
            Tab_Profile.Text = "Profile";
            Tab_Profile.UseVisualStyleBackColor = true;
            // 
            // CB_SisterFlower
            // 
            CB_SisterFlower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_SisterFlower.FormattingEnabled = true;
            CB_SisterFlower.Location = new System.Drawing.Point(187, 162);
            CB_SisterFlower.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CB_SisterFlower.Name = "CB_SisterFlower";
            CB_SisterFlower.Size = new System.Drawing.Size(162, 23);
            CB_SisterFlower.TabIndex = 63;
            // 
            // CB_ProfileFlower
            // 
            CB_ProfileFlower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_ProfileFlower.FormattingEnabled = true;
            CB_ProfileFlower.Location = new System.Drawing.Point(10, 162);
            CB_ProfileFlower.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CB_ProfileFlower.Name = "CB_ProfileFlower";
            CB_ProfileFlower.Size = new System.Drawing.Size(164, 23);
            CB_ProfileFlower.TabIndex = 62;
            // 
            // L_ProfileSisterFlower
            // 
            L_ProfileSisterFlower.AutoSize = true;
            L_ProfileSisterFlower.Location = new System.Drawing.Point(184, 144);
            L_ProfileSisterFlower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_ProfileSisterFlower.Name = "L_ProfileSisterFlower";
            L_ProfileSisterFlower.Size = new System.Drawing.Size(81, 15);
            L_ProfileSisterFlower.TabIndex = 21;
            L_ProfileSisterFlower.Text = "Flower (Sister)";
            // 
            // L_ProfileSpecialtyFlower
            // 
            L_ProfileSpecialtyFlower.AutoSize = true;
            L_ProfileSpecialtyFlower.Location = new System.Drawing.Point(7, 144);
            L_ProfileSpecialtyFlower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_ProfileSpecialtyFlower.Name = "L_ProfileSpecialtyFlower";
            L_ProfileSpecialtyFlower.Size = new System.Drawing.Size(42, 15);
            L_ProfileSpecialtyFlower.TabIndex = 20;
            L_ProfileSpecialtyFlower.Text = "Flower (Local)";
            // 
            // RIS_SisterFruit
            // 
            RIS_SisterFruit.Location = new System.Drawing.Point(187, 82);
            RIS_SisterFruit.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            RIS_SisterFruit.Name = "RIS_SisterFruit";
            RIS_SisterFruit.Size = new System.Drawing.Size(167, 55);
            RIS_SisterFruit.TabIndex = 19;
            // 
            // L_ProfileSisterFruit
            // 
            L_ProfileSisterFruit.AutoSize = true;
            L_ProfileSisterFruit.Location = new System.Drawing.Point(183, 64);
            L_ProfileSisterFruit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_ProfileSisterFruit.Name = "L_ProfileSisterFruit";
            L_ProfileSisterFruit.Size = new System.Drawing.Size(70, 15);
            L_ProfileSisterFruit.TabIndex = 18;
            L_ProfileSisterFruit.Text = "Fruit (Sister)";
            // 
            // RIS_ProfileFruit
            // 
            RIS_ProfileFruit.Location = new System.Drawing.Point(10, 82);
            RIS_ProfileFruit.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            RIS_ProfileFruit.Name = "RIS_ProfileFruit";
            RIS_ProfileFruit.Size = new System.Drawing.Size(167, 55);
            RIS_ProfileFruit.TabIndex = 17;
            // 
            // CAL_ProfileTimestamp
            // 
            CAL_ProfileTimestamp.Location = new System.Drawing.Point(10, 25);
            CAL_ProfileTimestamp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CAL_ProfileTimestamp.Name = "CAL_ProfileTimestamp";
            CAL_ProfileTimestamp.Size = new System.Drawing.Size(233, 23);
            CAL_ProfileTimestamp.TabIndex = 16;
            // 
            // CHK_ProfileMadeVillage
            // 
            CHK_ProfileMadeVillage.AutoSize = true;
            CHK_ProfileMadeVillage.Location = new System.Drawing.Point(10, 203);
            CHK_ProfileMadeVillage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CHK_ProfileMadeVillage.Name = "CHK_ProfileMadeVillage";
            CHK_ProfileMadeVillage.Size = new System.Drawing.Size(94, 19);
            CHK_ProfileMadeVillage.TabIndex = 15;
            CHK_ProfileMadeVillage.Text = "Made Village";
            CHK_ProfileMadeVillage.UseVisualStyleBackColor = true;
            // 
            // L_ProfileSpecialtyFruit
            // 
            L_ProfileSpecialtyFruit.AutoSize = true;
            L_ProfileSpecialtyFruit.Location = new System.Drawing.Point(7, 64);
            L_ProfileSpecialtyFruit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_ProfileSpecialtyFruit.Name = "L_ProfileSpecialtyFruit";
            L_ProfileSpecialtyFruit.Size = new System.Drawing.Size(89, 15);
            L_ProfileSpecialtyFruit.TabIndex = 14;
            L_ProfileSpecialtyFruit.Text = "Fruit (Local)";
            // 
            // L_ProfileTimestamp
            // 
            L_ProfileTimestamp.AutoSize = true;
            L_ProfileTimestamp.Location = new System.Drawing.Point(7, 7);
            L_ProfileTimestamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_ProfileTimestamp.Name = "L_ProfileTimestamp";
            L_ProfileTimestamp.Size = new System.Drawing.Size(67, 15);
            L_ProfileTimestamp.TabIndex = 12;
            L_ProfileTimestamp.Text = "Timestamp";
            // 
            // MiscPlayerEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 319);
            Controls.Add(tabControl1);
            Controls.Add(B_Cancel);
            Controls.Add(B_Save);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = Properties.Resources.icon;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MiscPlayerEditor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Misc Player Detail Editor";
            ((System.ComponentModel.ISupportInitialize)NUD_BirthMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_BirthDay).EndInit();
            tabControl1.ResumeLayout(false);
            Tab_Misc.ResumeLayout(false);
            Tab_Profile.ResumeLayout(false);
            Tab_Profile.PerformLayout();
            ResumeLayout(false);

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
        private System.Windows.Forms.CheckBox CHK_ProfileMadeVillage;
        private System.Windows.Forms.DateTimePicker CAL_ProfileTimestamp;
        private RestrictedItemSelect RIS_ProfileFruit;
        private RestrictedItemSelect RIS_SisterFruit;
        private System.Windows.Forms.Label L_ProfileSpecialtyFruit;
        private System.Windows.Forms.Label L_ProfileSisterFruit;
        private System.Windows.Forms.Label L_ProfileSisterFlower;
        private System.Windows.Forms.Label L_ProfileSpecialtyFlower;
        private System.Windows.Forms.ComboBox CB_SisterFlower;
        private System.Windows.Forms.ComboBox CB_ProfileFlower;
    }
}

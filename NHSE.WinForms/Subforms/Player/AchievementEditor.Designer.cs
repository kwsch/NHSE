namespace NHSE.WinForms
{
    partial class AchievementEditor
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
            this.LB_Counts = new System.Windows.Forms.ListBox();
            this.NUD_Count = new System.Windows.Forms.NumericUpDown();
            this.L_Count = new System.Windows.Forms.Label();
            this.NUD_Unk = new System.Windows.Forms.NumericUpDown();
            this.B_GiveAll = new System.Windows.Forms.Button();
            this.B_Clear = new System.Windows.Forms.Button();
            this.B_ClearAll = new System.Windows.Forms.Button();
            this.AR_6 = new NHSE.WinForms.AchievementRow();
            this.AR_5 = new NHSE.WinForms.AchievementRow();
            this.AR_4 = new NHSE.WinForms.AchievementRow();
            this.AR_3 = new NHSE.WinForms.AchievementRow();
            this.AR_2 = new NHSE.WinForms.AchievementRow();
            this.AR_1 = new NHSE.WinForms.AchievementRow();
            this.B_Max = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Unk)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(505, 226);
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
            this.B_Save.Location = new System.Drawing.Point(505, 197);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(72, 23);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // LB_Counts
            // 
            this.LB_Counts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_Counts.FormattingEnabled = true;
            this.LB_Counts.Location = new System.Drawing.Point(12, 12);
            this.LB_Counts.Name = "LB_Counts";
            this.LB_Counts.Size = new System.Drawing.Size(206, 238);
            this.LB_Counts.TabIndex = 8;
            this.LB_Counts.SelectedIndexChanged += new System.EventHandler(this.LB_Counts_SelectedIndexChanged);
            // 
            // NUD_Count
            // 
            this.NUD_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_Count.Location = new System.Drawing.Point(227, 33);
            this.NUD_Count.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUD_Count.Name = "NUD_Count";
            this.NUD_Count.Size = new System.Drawing.Size(72, 20);
            this.NUD_Count.TabIndex = 9;
            this.NUD_Count.ValueChanged += new System.EventHandler(this.NUD_Count_ValueChanged);
            // 
            // L_Count
            // 
            this.L_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Count.AutoSize = true;
            this.L_Count.Location = new System.Drawing.Point(224, 17);
            this.L_Count.Name = "L_Count";
            this.L_Count.Size = new System.Drawing.Size(38, 13);
            this.L_Count.TabIndex = 10;
            this.L_Count.Text = "Count:";
            // 
            // NUD_Unk
            // 
            this.NUD_Unk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_Unk.Location = new System.Drawing.Point(227, 200);
            this.NUD_Unk.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_Unk.Name = "NUD_Unk";
            this.NUD_Unk.Size = new System.Drawing.Size(51, 20);
            this.NUD_Unk.TabIndex = 17;
            // 
            // B_GiveAll
            // 
            this.B_GiveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_GiveAll.Location = new System.Drawing.Point(227, 226);
            this.B_GiveAll.Name = "B_GiveAll";
            this.B_GiveAll.Size = new System.Drawing.Size(100, 23);
            this.B_GiveAll.TabIndex = 18;
            this.B_GiveAll.Text = "Give All";
            this.B_GiveAll.UseVisualStyleBackColor = true;
            this.B_GiveAll.Click += new System.EventHandler(this.B_GiveAll_Click);
            // 
            // B_Clear
            // 
            this.B_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Clear.Location = new System.Drawing.Point(383, 30);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(72, 23);
            this.B_Clear.TabIndex = 19;
            this.B_Clear.Text = "Clear";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // B_ClearAll
            // 
            this.B_ClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_ClearAll.Location = new System.Drawing.Point(333, 226);
            this.B_ClearAll.Name = "B_ClearAll";
            this.B_ClearAll.Size = new System.Drawing.Size(100, 23);
            this.B_ClearAll.TabIndex = 20;
            this.B_ClearAll.Text = "Clear All";
            this.B_ClearAll.UseVisualStyleBackColor = true;
            this.B_ClearAll.Click += new System.EventHandler(this.B_ClearAll_Click);
            // 
            // AR_6
            // 
            this.AR_6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AR_6.AutoSize = true;
            this.AR_6.Location = new System.Drawing.Point(227, 171);
            this.AR_6.Margin = new System.Windows.Forms.Padding(0);
            this.AR_6.Name = "AR_6";
            this.AR_6.Size = new System.Drawing.Size(350, 23);
            this.AR_6.TabIndex = 16;
            // 
            // AR_5
            // 
            this.AR_5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AR_5.AutoSize = true;
            this.AR_5.Location = new System.Drawing.Point(227, 148);
            this.AR_5.Margin = new System.Windows.Forms.Padding(0);
            this.AR_5.Name = "AR_5";
            this.AR_5.Size = new System.Drawing.Size(350, 23);
            this.AR_5.TabIndex = 15;
            // 
            // AR_4
            // 
            this.AR_4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AR_4.AutoSize = true;
            this.AR_4.Location = new System.Drawing.Point(227, 125);
            this.AR_4.Margin = new System.Windows.Forms.Padding(0);
            this.AR_4.Name = "AR_4";
            this.AR_4.Size = new System.Drawing.Size(350, 23);
            this.AR_4.TabIndex = 14;
            // 
            // AR_3
            // 
            this.AR_3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AR_3.AutoSize = true;
            this.AR_3.Location = new System.Drawing.Point(227, 102);
            this.AR_3.Margin = new System.Windows.Forms.Padding(0);
            this.AR_3.Name = "AR_3";
            this.AR_3.Size = new System.Drawing.Size(350, 23);
            this.AR_3.TabIndex = 13;
            // 
            // AR_2
            // 
            this.AR_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AR_2.AutoSize = true;
            this.AR_2.Location = new System.Drawing.Point(227, 79);
            this.AR_2.Margin = new System.Windows.Forms.Padding(0);
            this.AR_2.Name = "AR_2";
            this.AR_2.Size = new System.Drawing.Size(350, 23);
            this.AR_2.TabIndex = 12;
            // 
            // AR_1
            // 
            this.AR_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AR_1.AutoSize = true;
            this.AR_1.Location = new System.Drawing.Point(227, 56);
            this.AR_1.Margin = new System.Windows.Forms.Padding(0);
            this.AR_1.Name = "AR_1";
            this.AR_1.Size = new System.Drawing.Size(350, 23);
            this.AR_1.TabIndex = 11;
            // 
            // B_Max
            // 
            this.B_Max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Max.Location = new System.Drawing.Point(305, 30);
            this.B_Max.Name = "B_Max";
            this.B_Max.Size = new System.Drawing.Size(72, 23);
            this.B_Max.TabIndex = 21;
            this.B_Max.Text = "Max";
            this.B_Max.UseVisualStyleBackColor = true;
            this.B_Max.Click += new System.EventHandler(this.B_Max_Click);
            // 
            // AchievementEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 261);
            this.Controls.Add(this.B_Max);
            this.Controls.Add(this.B_ClearAll);
            this.Controls.Add(this.B_Clear);
            this.Controls.Add(this.B_GiveAll);
            this.Controls.Add(this.NUD_Unk);
            this.Controls.Add(this.AR_6);
            this.Controls.Add(this.AR_5);
            this.Controls.Add(this.AR_4);
            this.Controls.Add(this.AR_3);
            this.Controls.Add(this.AR_2);
            this.Controls.Add(this.AR_1);
            this.Controls.Add(this.L_Count);
            this.Controls.Add(this.NUD_Count);
            this.Controls.Add(this.LB_Counts);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AchievementEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Record Editor";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Unk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.ListBox LB_Counts;
        private System.Windows.Forms.NumericUpDown NUD_Count;
        private System.Windows.Forms.Label L_Count;
        private AchievementRow AR_1;
        private AchievementRow AR_2;
        private AchievementRow AR_3;
        private AchievementRow AR_4;
        private AchievementRow AR_5;
        private AchievementRow AR_6;
        private System.Windows.Forms.NumericUpDown NUD_Unk;
        private System.Windows.Forms.Button B_GiveAll;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.Button B_ClearAll;
        private System.Windows.Forms.Button B_Max;
    }
}
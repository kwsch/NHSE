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
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BirthMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BirthDay)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(272, 11);
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
            this.B_Save.Location = new System.Drawing.Point(350, 11);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(72, 23);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // L_Birthday
            // 
            this.L_Birthday.Location = new System.Drawing.Point(12, 9);
            this.L_Birthday.Name = "L_Birthday";
            this.L_Birthday.Size = new System.Drawing.Size(104, 23);
            this.L_Birthday.TabIndex = 8;
            this.L_Birthday.Text = "Birthday (M/D):";
            this.L_Birthday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_BirthMonth
            // 
            this.NUD_BirthMonth.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_BirthMonth.Location = new System.Drawing.Point(122, 12);
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
            this.NUD_BirthDay.Location = new System.Drawing.Point(165, 12);
            this.NUD_BirthDay.Name = "NUD_BirthDay";
            this.NUD_BirthDay.Size = new System.Drawing.Size(37, 20);
            this.NUD_BirthDay.TabIndex = 10;
            this.NUD_BirthDay.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // MiscPlayerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 46);
            this.Controls.Add(this.NUD_BirthDay);
            this.Controls.Add(this.NUD_BirthMonth);
            this.Controls.Add(this.L_Birthday);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MiscPlayerEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Misc Player Detail Editor";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BirthMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BirthDay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Label L_Birthday;
        private System.Windows.Forms.NumericUpDown NUD_BirthMonth;
        private System.Windows.Forms.NumericUpDown NUD_BirthDay;
    }
}
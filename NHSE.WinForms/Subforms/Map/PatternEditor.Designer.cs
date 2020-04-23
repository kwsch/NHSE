namespace NHSE.WinForms
{
    partial class PatternEditor
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
            this.components = new System.ComponentModel.Container();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.LB_Items = new System.Windows.Forms.ListBox();
            this.PB_Palette = new System.Windows.Forms.PictureBox();
            this.L_PatternName = new System.Windows.Forms.Label();
            this.B_LoadDesign = new System.Windows.Forms.Button();
            this.B_DumpDesign = new System.Windows.Forms.Button();
            this.PB_Pattern = new System.Windows.Forms.PictureBox();
            this.CM_Picture = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_SavePNG = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Palette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Pattern)).BeginInit();
            this.CM_Picture.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.Location = new System.Drawing.Point(488, 276);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(92, 40);
            this.B_Save.TabIndex = 1;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(390, 276);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(92, 40);
            this.B_Cancel.TabIndex = 2;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // LB_Items
            // 
            this.LB_Items.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LB_Items.FormattingEnabled = true;
            this.LB_Items.Location = new System.Drawing.Point(12, 12);
            this.LB_Items.Name = "LB_Items";
            this.LB_Items.Size = new System.Drawing.Size(149, 303);
            this.LB_Items.TabIndex = 3;
            this.LB_Items.SelectedIndexChanged += new System.EventHandler(this.LB_Items_SelectedIndexChanged);
            // 
            // PB_Palette
            // 
            this.PB_Palette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Palette.Location = new System.Drawing.Point(432, 12);
            this.PB_Palette.Name = "PB_Palette";
            this.PB_Palette.Size = new System.Drawing.Size(152, 12);
            this.PB_Palette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Palette.TabIndex = 34;
            this.PB_Palette.TabStop = false;
            // 
            // L_PatternName
            // 
            this.L_PatternName.AutoSize = true;
            this.L_PatternName.Location = new System.Drawing.Point(429, 28);
            this.L_PatternName.Name = "L_PatternName";
            this.L_PatternName.Size = new System.Drawing.Size(73, 13);
            this.L_PatternName.TabIndex = 33;
            this.L_PatternName.Text = "*PatternName";
            // 
            // B_LoadDesign
            // 
            this.B_LoadDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_LoadDesign.Location = new System.Drawing.Point(266, 276);
            this.B_LoadDesign.Name = "B_LoadDesign";
            this.B_LoadDesign.Size = new System.Drawing.Size(92, 40);
            this.B_LoadDesign.TabIndex = 32;
            this.B_LoadDesign.Text = "Load Design";
            this.B_LoadDesign.UseVisualStyleBackColor = true;
            this.B_LoadDesign.Click += new System.EventHandler(this.B_LoadDesign_Click);
            // 
            // B_DumpDesign
            // 
            this.B_DumpDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_DumpDesign.Location = new System.Drawing.Point(168, 276);
            this.B_DumpDesign.Name = "B_DumpDesign";
            this.B_DumpDesign.Size = new System.Drawing.Size(92, 40);
            this.B_DumpDesign.TabIndex = 31;
            this.B_DumpDesign.Text = "Dump Design";
            this.B_DumpDesign.UseVisualStyleBackColor = true;
            this.B_DumpDesign.Click += new System.EventHandler(this.B_DumpDesign_Click);
            // 
            // PB_Pattern
            // 
            this.PB_Pattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Pattern.ContextMenuStrip = this.CM_Picture;
            this.PB_Pattern.Location = new System.Drawing.Point(168, 12);
            this.PB_Pattern.Name = "PB_Pattern";
            this.PB_Pattern.Size = new System.Drawing.Size(258, 258);
            this.PB_Pattern.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Pattern.TabIndex = 30;
            this.PB_Pattern.TabStop = false;
            this.PB_Pattern.MouseEnter += new System.EventHandler(this.PB_Pattern_MouseEnter);
            this.PB_Pattern.MouseLeave += new System.EventHandler(this.PB_Pattern_MouseLeave);
            // 
            // CM_Picture
            // 
            this.CM_Picture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_SavePNG});
            this.CM_Picture.Name = "CM_Picture";
            this.CM_Picture.ShowImageMargin = false;
            this.CM_Picture.Size = new System.Drawing.Size(156, 48);
            // 
            // Menu_SavePNG
            // 
            this.Menu_SavePNG.Name = "Menu_SavePNG";
            this.Menu_SavePNG.Size = new System.Drawing.Size(155, 22);
            this.Menu_SavePNG.Text = "Save .png";
            this.Menu_SavePNG.Click += new System.EventHandler(this.Menu_SavePNG_Click);
            // 
            // PatternEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 328);
            this.Controls.Add(this.PB_Palette);
            this.Controls.Add(this.L_PatternName);
            this.Controls.Add(this.B_LoadDesign);
            this.Controls.Add(this.B_DumpDesign);
            this.Controls.Add(this.PB_Pattern);
            this.Controls.Add(this.LB_Items);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatternEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pattern Editor";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Palette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Pattern)).EndInit();
            this.CM_Picture.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.ListBox LB_Items;
        private System.Windows.Forms.PictureBox PB_Palette;
        private System.Windows.Forms.Label L_PatternName;
        private System.Windows.Forms.Button B_LoadDesign;
        private System.Windows.Forms.Button B_DumpDesign;
        private System.Windows.Forms.PictureBox PB_Pattern;
        private System.Windows.Forms.ContextMenuStrip CM_Picture;
        private System.Windows.Forms.ToolStripMenuItem Menu_SavePNG;
    }
}
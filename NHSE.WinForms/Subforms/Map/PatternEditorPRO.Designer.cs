namespace NHSE.WinForms
{
    partial class PatternEditorPRO
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
            this.B_DumpLoadDesign = new System.Windows.Forms.Button();
            this.CM_DLDesign = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.B_DumpDesign = new System.Windows.Forms.ToolStripMenuItem();
            this.B_DumpDesignAll = new System.Windows.Forms.ToolStripMenuItem();
            this.B_LoadDesign = new System.Windows.Forms.ToolStripMenuItem();
            this.B_LoadDesignAll = new System.Windows.Forms.ToolStripMenuItem();
            this.PB_Sheet0 = new System.Windows.Forms.PictureBox();
            this.CM_Picture = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_SavePNG = new System.Windows.Forms.ToolStripMenuItem();
            this.PB_Sheet1 = new System.Windows.Forms.PictureBox();
            this.PB_Sheet3 = new System.Windows.Forms.PictureBox();
            this.PB_Sheet2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Palette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Sheet0)).BeginInit();
            this.CM_Picture.SuspendLayout();
            this.CM_DLDesign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Sheet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Sheet2)).BeginInit();
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
            // B_DumpLoadDesign
            // 
            this.B_DumpLoadDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_DumpLoadDesign.ContextMenuStrip = this.CM_DLDesign;
            this.B_DumpLoadDesign.Location = new System.Drawing.Point(168, 276);
            this.B_DumpLoadDesign.Name = "B_DumpLoadDesign";
            this.B_DumpLoadDesign.Size = new System.Drawing.Size(92, 40);
            this.B_DumpLoadDesign.TabIndex = 31;
            this.B_DumpLoadDesign.Text = "Dump/Import";
            this.B_DumpLoadDesign.UseVisualStyleBackColor = true;
            this.B_DumpLoadDesign.Click += new System.EventHandler(this.B_DumpLoadDesign_Click);
            // 
            // CM_DLDesign
            // 
            this.CM_DLDesign.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CM_DLDesign.Name = "CM_DLDesign";
            this.CM_DLDesign.ShowImageMargin = false;
            this.CM_DLDesign.Size = new System.Drawing.Size(93, 92);
            // 
            // B_DumpDesign
            // 
            this.B_DumpDesign.Name = "B_DumpDesign";
            this.B_DumpDesign.Size = new System.Drawing.Size(92, 22);
            this.B_DumpDesign.Text = "Dump Design";
            this.B_DumpDesign.Click += new System.EventHandler(this.B_DumpDesign_Click);
            // 
            // B_DumpDesignAll
            // 
            this.B_DumpDesignAll.Name = "B_DumpDesignAll";
            this.B_DumpDesignAll.Size = new System.Drawing.Size(92, 22);
            this.B_DumpDesignAll.Text = "Dump All Designs";
            this.B_DumpDesignAll.Click += new System.EventHandler(this.B_DumpDesign_Click);
            // 
            // B_LoadDesign
            // 
            this.B_LoadDesign.Name = "B_LoadDesign";
            this.B_LoadDesign.Size = new System.Drawing.Size(92, 22);
            this.B_LoadDesign.Text = "Load Design";
            this.B_LoadDesign.Click += new System.EventHandler(this.B_LoadDesign_Click);
            // 
            // B_LoadDesignAll
            // 
            this.B_LoadDesignAll.Name = "B_LoadDesignAll";
            this.B_LoadDesignAll.Size = new System.Drawing.Size(92, 22);
            this.B_LoadDesignAll.Text = "Load All Designs";
            this.B_LoadDesignAll.Click += new System.EventHandler(this.B_LoadDesign_Click);
            // 
            // PB_Sheet0
            // 
            this.PB_Sheet0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Sheet0.ContextMenuStrip = this.CM_Picture;
            this.PB_Sheet0.Location = new System.Drawing.Point(168, 12);
            this.PB_Sheet0.Name = "PB_Sheet0";
            this.PB_Sheet0.Size = new System.Drawing.Size(130, 130);
            this.PB_Sheet0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Sheet0.TabIndex = 30;
            this.PB_Sheet0.TabStop = false;
            this.PB_Sheet0.MouseEnter += new System.EventHandler(this.PB_Pattern_MouseEnter);
            this.PB_Sheet0.MouseLeave += new System.EventHandler(this.PB_Pattern_MouseLeave);
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
            // PB_Sheet1
            // 
            this.PB_Sheet1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Sheet1.ContextMenuStrip = this.CM_Picture;
            this.PB_Sheet1.Location = new System.Drawing.Point(298, 12);
            this.PB_Sheet1.Name = "PB_Sheet1";
            this.PB_Sheet1.Size = new System.Drawing.Size(130, 130);
            this.PB_Sheet1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Sheet1.TabIndex = 35;
            this.PB_Sheet1.TabStop = false;
            // 
            // PB_Sheet3
            // 
            this.PB_Sheet3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Sheet3.ContextMenuStrip = this.CM_Picture;
            this.PB_Sheet3.Location = new System.Drawing.Point(298, 142);
            this.PB_Sheet3.Name = "PB_Sheet3";
            this.PB_Sheet3.Size = new System.Drawing.Size(130, 130);
            this.PB_Sheet3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Sheet3.TabIndex = 37;
            this.PB_Sheet3.TabStop = false;
            // 
            // PB_Sheet2
            // 
            this.PB_Sheet2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Sheet2.ContextMenuStrip = this.CM_Picture;
            this.PB_Sheet2.Location = new System.Drawing.Point(168, 142);
            this.PB_Sheet2.Name = "PB_Sheet2";
            this.PB_Sheet2.Size = new System.Drawing.Size(130, 130);
            this.PB_Sheet2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Sheet2.TabIndex = 36;
            this.PB_Sheet2.TabStop = false;
            // 
            // PatternEditorPRO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 328);
            this.Controls.Add(this.PB_Sheet3);
            this.Controls.Add(this.PB_Sheet2);
            this.Controls.Add(this.PB_Sheet1);
            this.Controls.Add(this.PB_Palette);
            this.Controls.Add(this.L_PatternName);
            this.Controls.Add(this.B_DumpLoadDesign);
            this.Controls.Add(this.PB_Sheet0);
            this.Controls.Add(this.LB_Items);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatternEditorPRO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pro Design Editor";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Palette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Sheet0)).EndInit();
            this.CM_Picture.ResumeLayout(false);
            this.CM_DLDesign.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Sheet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Sheet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SetCM_DLDesign()
        {
            if (LB_Items.Items.Count == 0)
            {
                this.CM_DLDesign.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.B_DumpDesign,
                this.B_LoadDesign});
            }
            else
            {
                this.CM_DLDesign.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.B_DumpDesign,
                this.B_DumpDesignAll,
                this.B_LoadDesign,
                this.B_LoadDesignAll});
            }
        }

        #endregion
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.ListBox LB_Items;
        private System.Windows.Forms.PictureBox PB_Palette;
        private System.Windows.Forms.Label L_PatternName;
        private System.Windows.Forms.Button B_DumpLoadDesign;
        private System.Windows.Forms.ContextMenuStrip CM_DLDesign;
        private System.Windows.Forms.ToolStripMenuItem B_DumpDesign;
        private System.Windows.Forms.ToolStripMenuItem B_DumpDesignAll;
        private System.Windows.Forms.ToolStripMenuItem B_LoadDesign;
        private System.Windows.Forms.ToolStripMenuItem B_LoadDesignAll;
        private System.Windows.Forms.PictureBox PB_Sheet0;
        private System.Windows.Forms.ContextMenuStrip CM_Picture;
        private System.Windows.Forms.ToolStripMenuItem Menu_SavePNG;
        private System.Windows.Forms.PictureBox PB_Sheet1;
        private System.Windows.Forms.PictureBox PB_Sheet3;
        private System.Windows.Forms.PictureBox PB_Sheet2;
    }
}
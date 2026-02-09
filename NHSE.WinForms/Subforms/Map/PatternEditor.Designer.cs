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
            components = new System.ComponentModel.Container();
            B_Save = new System.Windows.Forms.Button();
            B_Cancel = new System.Windows.Forms.Button();
            LB_Items = new System.Windows.Forms.ListBox();
            PB_Palette = new System.Windows.Forms.PictureBox();
            L_PatternName = new System.Windows.Forms.Label();
            B_DumpLoadDesign = new System.Windows.Forms.Button();
            CM_DLDesign = new System.Windows.Forms.ContextMenuStrip(components);
            B_DumpDesign = new System.Windows.Forms.ToolStripMenuItem();
            B_DumpDesignAll = new System.Windows.Forms.ToolStripMenuItem();
            B_LoadDesign = new System.Windows.Forms.ToolStripMenuItem();
            B_LoadDesignAll = new System.Windows.Forms.ToolStripMenuItem();
            PB_Pattern = new System.Windows.Forms.PictureBox();
            CM_Picture = new System.Windows.Forms.ContextMenuStrip(components);
            Menu_SavePNG = new System.Windows.Forms.ToolStripMenuItem();
            CB_Pattern_OverwriteDesigner = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)PB_Palette).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Pattern).BeginInit();
            CM_Picture.SuspendLayout();
            SuspendLayout();
            // 
            // B_Save
            // 
            B_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Save.Location = new System.Drawing.Point(490, 276);
            B_Save.Name = "B_Save";
            B_Save.Size = new System.Drawing.Size(92, 40);
            B_Save.TabIndex = 1;
            B_Save.Text = "Save";
            B_Save.UseVisualStyleBackColor = true;
            B_Save.Click += B_Save_Click;
            // 
            // B_Cancel
            // 
            B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Cancel.Location = new System.Drawing.Point(392, 276);
            B_Cancel.Name = "B_Cancel";
            B_Cancel.Size = new System.Drawing.Size(92, 40);
            B_Cancel.TabIndex = 2;
            B_Cancel.Text = "Cancel";
            B_Cancel.UseVisualStyleBackColor = true;
            B_Cancel.Click += B_Cancel_Click;
            // 
            // LB_Items
            // 
            LB_Items.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            LB_Items.FormattingEnabled = true;
            LB_Items.Location = new System.Drawing.Point(12, 12);
            LB_Items.Name = "LB_Items";
            LB_Items.Size = new System.Drawing.Size(149, 289);
            LB_Items.TabIndex = 3;
            LB_Items.SelectedIndexChanged += LB_Items_SelectedIndexChanged;
            // 
            // PB_Palette
            // 
            PB_Palette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PB_Palette.Location = new System.Drawing.Point(432, 12);
            PB_Palette.Name = "PB_Palette";
            PB_Palette.Size = new System.Drawing.Size(152, 12);
            PB_Palette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            PB_Palette.TabIndex = 34;
            PB_Palette.TabStop = false;
            // 
            // L_PatternName
            // 
            L_PatternName.AutoSize = true;
            L_PatternName.Location = new System.Drawing.Point(429, 28);
            L_PatternName.Name = "L_PatternName";
            L_PatternName.Size = new System.Drawing.Size(82, 15);
            L_PatternName.TabIndex = 33;
            L_PatternName.Text = "*PatternName";
            // 
            // B_DumpLoadDesign
            // 
            B_DumpLoadDesign.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            B_DumpLoadDesign.ContextMenuStrip = CM_DLDesign;
            B_DumpLoadDesign.Location = new System.Drawing.Point(168, 276);
            B_DumpLoadDesign.Name = "B_DumpLoadDesign";
            B_DumpLoadDesign.Size = new System.Drawing.Size(92, 40);
            B_DumpLoadDesign.TabIndex = 31;
            B_DumpLoadDesign.Text = "Dump/Import";
            B_DumpLoadDesign.UseVisualStyleBackColor = true;
            B_DumpLoadDesign.Click += B_DumpLoadDesign_Click;
            // 
            // CM_DLDesign
            // 
            CM_DLDesign.ImageScalingSize = new System.Drawing.Size(20, 20);
            CM_DLDesign.Name = "CM_DLDesign";
            CM_DLDesign.ShowImageMargin = false;
            CM_DLDesign.Size = new System.Drawing.Size(36, 4);
            // 
            // B_DumpDesign
            // 
            B_DumpDesign.Name = "B_DumpDesign";
            B_DumpDesign.Size = new System.Drawing.Size(92, 22);
            B_DumpDesign.Text = "Dump Design";
            B_DumpDesign.Click += B_DumpDesign_Click;
            // 
            // B_DumpDesignAll
            // 
            B_DumpDesignAll.Name = "B_DumpDesignAll";
            B_DumpDesignAll.Size = new System.Drawing.Size(92, 22);
            B_DumpDesignAll.Text = "Dump All Designs";
            B_DumpDesignAll.Click += B_DumpDesign_Click;
            // 
            // B_LoadDesign
            // 
            B_LoadDesign.Name = "B_LoadDesign";
            B_LoadDesign.Size = new System.Drawing.Size(92, 22);
            B_LoadDesign.Text = "Load Design";
            B_LoadDesign.Click += B_LoadDesign_Click;
            // 
            // B_LoadDesignAll
            // 
            B_LoadDesignAll.Name = "B_LoadDesignAll";
            B_LoadDesignAll.Size = new System.Drawing.Size(92, 22);
            B_LoadDesignAll.Text = "Load All Designs";
            B_LoadDesignAll.Click += B_LoadDesign_Click;
            // 
            // PB_Pattern
            // 
            PB_Pattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PB_Pattern.ContextMenuStrip = CM_Picture;
            PB_Pattern.Location = new System.Drawing.Point(168, 12);
            PB_Pattern.Name = "PB_Pattern";
            PB_Pattern.Size = new System.Drawing.Size(258, 258);
            PB_Pattern.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            PB_Pattern.TabIndex = 30;
            PB_Pattern.TabStop = false;
            PB_Pattern.MouseEnter += PB_Pattern_MouseEnter;
            PB_Pattern.MouseLeave += PB_Pattern_MouseLeave;
            // 
            // CM_Picture
            // 
            CM_Picture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { Menu_SavePNG });
            CM_Picture.Name = "CM_Picture";
            CM_Picture.ShowImageMargin = false;
            CM_Picture.Size = new System.Drawing.Size(101, 26);
            // 
            // Menu_SavePNG
            // 
            Menu_SavePNG.Name = "Menu_SavePNG";
            Menu_SavePNG.Size = new System.Drawing.Size(100, 22);
            Menu_SavePNG.Text = "Save .png";
            Menu_SavePNG.Click += Menu_SavePNG_Click;
            // 
            // CB_Pattern_OverwriteDesigner
            // 
            CB_Pattern_OverwriteDesigner.AutoSize = true;
            CB_Pattern_OverwriteDesigner.Location = new System.Drawing.Point(263, 288);
            CB_Pattern_OverwriteDesigner.Name = "CB_Pattern_OverwriteDesigner";
            CB_Pattern_OverwriteDesigner.Size = new System.Drawing.Size(126, 19);
            CB_Pattern_OverwriteDesigner.TabIndex = 35;
            CB_Pattern_OverwriteDesigner.Text = "Overwrite Designer";
            CB_Pattern_OverwriteDesigner.UseVisualStyleBackColor = true;
            // 
            // PatternEditor
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            ClientSize = new System.Drawing.Size(592, 328);
            Controls.Add(CB_Pattern_OverwriteDesigner);
            Controls.Add(PB_Palette);
            Controls.Add(L_PatternName);
            Controls.Add(B_DumpLoadDesign);
            Controls.Add(PB_Pattern);
            Controls.Add(LB_Items);
            Controls.Add(B_Cancel);
            Controls.Add(B_Save);
            Icon = Properties.Resources.icon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PatternEditor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Pattern Editor";
            ((System.ComponentModel.ISupportInitialize)PB_Palette).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Pattern).EndInit();
            CM_Picture.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.PictureBox PB_Pattern;
        private System.Windows.Forms.ContextMenuStrip CM_Picture;
        private System.Windows.Forms.ToolStripMenuItem Menu_SavePNG;
        private System.Windows.Forms.CheckBox CB_Pattern_OverwriteDesigner;
    }
}
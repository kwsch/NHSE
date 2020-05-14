namespace NHSE.WinForms
{
    partial class VillagerMemoryEditor
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
            this.LB_Players = new System.Windows.Forms.ListBox();
            this.B_Dump = new System.Windows.Forms.Button();
            this.B_Load = new System.Windows.Forms.Button();
            this.GB_Flags = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Count)).BeginInit();
            this.GB_Flags.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(321, 268);
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
            this.B_Save.Location = new System.Drawing.Point(399, 268);
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
            this.LB_Counts.Location = new System.Drawing.Point(6, 39);
            this.LB_Counts.Name = "LB_Counts";
            this.LB_Counts.Size = new System.Drawing.Size(278, 199);
            this.LB_Counts.TabIndex = 8;
            this.LB_Counts.SelectedIndexChanged += new System.EventHandler(this.LB_Counts_SelectedIndexChanged);
            // 
            // NUD_Count
            // 
            this.NUD_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_Count.Location = new System.Drawing.Point(212, 13);
            this.NUD_Count.Maximum = new decimal(new int[] {
            255,
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
            this.L_Count.Location = new System.Drawing.Point(126, 13);
            this.L_Count.Name = "L_Count";
            this.L_Count.Size = new System.Drawing.Size(80, 20);
            this.L_Count.TabIndex = 10;
            this.L_Count.Text = "Value:";
            this.L_Count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LB_Players
            // 
            this.LB_Players.FormattingEnabled = true;
            this.LB_Players.Location = new System.Drawing.Point(12, 12);
            this.LB_Players.Name = "LB_Players";
            this.LB_Players.Size = new System.Drawing.Size(163, 108);
            this.LB_Players.TabIndex = 11;
            this.LB_Players.SelectedIndexChanged += new System.EventHandler(this.LB_Players_SelectedIndexChanged);
            // 
            // B_Dump
            // 
            this.B_Dump.Location = new System.Drawing.Point(12, 126);
            this.B_Dump.Name = "B_Dump";
            this.B_Dump.Size = new System.Drawing.Size(79, 23);
            this.B_Dump.TabIndex = 13;
            this.B_Dump.Text = "Dump";
            this.B_Dump.UseVisualStyleBackColor = true;
            this.B_Dump.Click += new System.EventHandler(this.B_Dump_Click);
            // 
            // B_Load
            // 
            this.B_Load.Location = new System.Drawing.Point(96, 126);
            this.B_Load.Name = "B_Load";
            this.B_Load.Size = new System.Drawing.Size(79, 23);
            this.B_Load.TabIndex = 12;
            this.B_Load.Text = "Load";
            this.B_Load.UseVisualStyleBackColor = true;
            this.B_Load.Click += new System.EventHandler(this.B_Load_Click);
            // 
            // GB_Flags
            // 
            this.GB_Flags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_Flags.Controls.Add(this.LB_Counts);
            this.GB_Flags.Controls.Add(this.L_Count);
            this.GB_Flags.Controls.Add(this.NUD_Count);
            this.GB_Flags.Location = new System.Drawing.Point(181, 12);
            this.GB_Flags.Name = "GB_Flags";
            this.GB_Flags.Size = new System.Drawing.Size(290, 245);
            this.GB_Flags.TabIndex = 14;
            this.GB_Flags.TabStop = false;
            this.GB_Flags.Text = "Flags";
            // 
            // VillagerMemoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 303);
            this.Controls.Add(this.GB_Flags);
            this.Controls.Add(this.B_Dump);
            this.Controls.Add(this.B_Load);
            this.Controls.Add(this.LB_Players);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VillagerMemoryEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Villager Player Memory Editor";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Count)).EndInit();
            this.GB_Flags.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.ListBox LB_Counts;
        private System.Windows.Forms.NumericUpDown NUD_Count;
        private System.Windows.Forms.Label L_Count;
        private System.Windows.Forms.ListBox LB_Players;
        private System.Windows.Forms.Button B_Dump;
        private System.Windows.Forms.Button B_Load;
        private System.Windows.Forms.GroupBox GB_Flags;
    }
}
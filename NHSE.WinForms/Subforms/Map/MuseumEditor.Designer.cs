namespace NHSE.WinForms
{
    partial class MuseumEditor
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
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.LB_Donations = new System.Windows.Forms.ListBox();
            this.NUD_Player = new System.Windows.Forms.NumericUpDown();
            this.L_Player = new System.Windows.Forms.Label();
            this.CAL_Date = new System.Windows.Forms.DateTimePicker();
            this.ItemEdit = new NHSE.WinForms.ItemEditor();
            this.B_Tools = new System.Windows.Forms.Button();
            this.CM_Tools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.B_Dump = new System.Windows.Forms.ToolStripMenuItem();
            this.B_Load = new System.Windows.Forms.ToolStripMenuItem();
            this.B_GiveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.B_SortDate = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Player)).BeginInit();
            this.CM_Tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(282, 382);
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
            this.B_Save.Location = new System.Drawing.Point(360, 382);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(72, 23);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // LB_Donations
            // 
            this.LB_Donations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_Donations.FormattingEnabled = true;
            this.LB_Donations.Location = new System.Drawing.Point(12, 12);
            this.LB_Donations.Name = "LB_Donations";
            this.LB_Donations.Size = new System.Drawing.Size(264, 394);
            this.LB_Donations.TabIndex = 8;
            this.LB_Donations.SelectedIndexChanged += new System.EventHandler(this.LB_Counts_SelectedIndexChanged);
            // 
            // NUD_Player
            // 
            this.NUD_Player.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_Player.Location = new System.Drawing.Point(360, 38);
            this.NUD_Player.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_Player.Name = "NUD_Player";
            this.NUD_Player.Size = new System.Drawing.Size(72, 20);
            this.NUD_Player.TabIndex = 9;
            // 
            // L_Player
            // 
            this.L_Player.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Player.Location = new System.Drawing.Point(277, 38);
            this.L_Player.Name = "L_Player";
            this.L_Player.Size = new System.Drawing.Size(83, 20);
            this.L_Player.TabIndex = 10;
            this.L_Player.Text = "Player Index:";
            this.L_Player.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CAL_Date
            // 
            this.CAL_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CAL_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CAL_Date.Location = new System.Drawing.Point(282, 12);
            this.CAL_Date.Name = "CAL_Date";
            this.CAL_Date.Size = new System.Drawing.Size(150, 20);
            this.CAL_Date.TabIndex = 11;
            // 
            // ItemEdit
            // 
            this.ItemEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemEdit.Location = new System.Drawing.Point(282, 64);
            this.ItemEdit.Name = "ItemEdit";
            this.ItemEdit.Size = new System.Drawing.Size(150, 282);
            this.ItemEdit.TabIndex = 12;
            // 
            // B_Tools
            // 
            this.B_Tools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Tools.Location = new System.Drawing.Point(282, 353);
            this.B_Tools.Name = "B_Tools";
            this.B_Tools.Size = new System.Drawing.Size(72, 23);
            this.B_Tools.TabIndex = 14;
            this.B_Tools.Text = "Tools...";
            this.B_Tools.UseVisualStyleBackColor = true;
            this.B_Tools.Click += new System.EventHandler(this.B_Tools_Click);
            // 
            // CM_Tools
            // 
            this.CM_Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_Dump,
            this.B_Load,
            this.B_GiveAll,
            this.B_SortDate});
            this.CM_Tools.Name = "CM_Tools";
            this.CM_Tools.Size = new System.Drawing.Size(139, 92);
            // 
            // B_Dump
            // 
            this.B_Dump.Name = "B_Dump";
            this.B_Dump.Size = new System.Drawing.Size(138, 22);
            this.B_Dump.Text = "Dump";
            this.B_Dump.Click += new System.EventHandler(this.B_Dump_Click);
            // 
            // B_Load
            // 
            this.B_Load.Name = "B_Load";
            this.B_Load.Size = new System.Drawing.Size(138, 22);
            this.B_Load.Text = "Load";
            this.B_Load.Click += new System.EventHandler(this.B_Load_Click);
            // 
            // B_GiveAll
            // 
            this.B_GiveAll.Name = "B_GiveAll";
            this.B_GiveAll.Size = new System.Drawing.Size(138, 22);
            this.B_GiveAll.Text = "Give All";
            this.B_GiveAll.Click += new System.EventHandler(this.B_GiveAll_Click);
            // 
            // B_SortDate
            // 
            this.B_SortDate.Name = "B_SortDate";
            this.B_SortDate.Size = new System.Drawing.Size(138, 22);
            this.B_SortDate.Text = "Sort By Date";
            this.B_SortDate.Click += new System.EventHandler(this.B_SortDate_Click);
            // 
            // MuseumEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 417);
            this.Controls.Add(this.B_Tools);
            this.Controls.Add(this.ItemEdit);
            this.Controls.Add(this.CAL_Date);
            this.Controls.Add(this.L_Player);
            this.Controls.Add(this.NUD_Player);
            this.Controls.Add(this.LB_Donations);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MuseumEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flag Editor";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Player)).EndInit();
            this.CM_Tools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.ListBox LB_Donations;
        private System.Windows.Forms.NumericUpDown NUD_Player;
        private System.Windows.Forms.Label L_Player;
        private System.Windows.Forms.DateTimePicker CAL_Date;
        private ItemEditor ItemEdit;
        private System.Windows.Forms.Button B_Tools;
        private System.Windows.Forms.ContextMenuStrip CM_Tools;
        private System.Windows.Forms.ToolStripMenuItem B_Dump;
        private System.Windows.Forms.ToolStripMenuItem B_Load;
        private System.Windows.Forms.ToolStripMenuItem B_GiveAll;
        private System.Windows.Forms.ToolStripMenuItem B_SortDate;
    }
}
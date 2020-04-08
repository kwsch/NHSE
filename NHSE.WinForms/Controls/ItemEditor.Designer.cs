namespace NHSE.WinForms
{
    partial class ItemEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CB_ItemID = new System.Windows.Forms.ComboBox();
            this.NUD_Count = new System.Windows.Forms.NumericUpDown();
            this.L_Count = new System.Windows.Forms.Label();
            this.L_Uses = new System.Windows.Forms.Label();
            this.NUD_Uses = new System.Windows.Forms.NumericUpDown();
            this.L_Flag0 = new System.Windows.Forms.Label();
            this.NUD_Flag0 = new System.Windows.Forms.NumericUpDown();
            this.L_Flag1 = new System.Windows.Forms.Label();
            this.NUD_Flag1 = new System.Windows.Forms.NumericUpDown();
            this.CM_Hand = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.CB_NamedItemArgument = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.FLP_Count = new System.Windows.Forms.FlowLayoutPanel();
            this.FLP_Uses = new System.Windows.Forms.FlowLayoutPanel();
            this.FLP_Flag0 = new System.Windows.Forms.FlowLayoutPanel();
            this.FLP_Flag1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Uses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Flag0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Flag1)).BeginInit();
            this.CM_Hand.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.FLP_Count.SuspendLayout();
            this.FLP_Uses.SuspendLayout();
            this.FLP_Flag0.SuspendLayout();
            this.FLP_Flag1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CB_ItemID
            // 
            this.CB_ItemID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_ItemID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_ItemID.DropDownWidth = 322;
            this.CB_ItemID.FormattingEnabled = true;
            this.CB_ItemID.Location = new System.Drawing.Point(3, 1);
            this.CB_ItemID.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.CB_ItemID.Name = "CB_ItemID";
            this.CB_ItemID.Size = new System.Drawing.Size(141, 21);
            this.CB_ItemID.TabIndex = 1;
            this.CB_ItemID.SelectedValueChanged += new System.EventHandler(this.CB_ItemID_SelectedValueChanged);
            // 
            // NUD_Count
            // 
            this.NUD_Count.Location = new System.Drawing.Point(88, 3);
            this.NUD_Count.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_Count.Name = "NUD_Count";
            this.NUD_Count.Size = new System.Drawing.Size(56, 20);
            this.NUD_Count.TabIndex = 2;
            this.NUD_Count.ValueChanged += new System.EventHandler(this.NUD_Count_ValueChanged);
            // 
            // L_Count
            // 
            this.L_Count.AutoSize = true;
            this.L_Count.Location = new System.Drawing.Point(44, 6);
            this.L_Count.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.L_Count.Name = "L_Count";
            this.L_Count.Size = new System.Drawing.Size(38, 13);
            this.L_Count.TabIndex = 7;
            this.L_Count.Text = "Count:";
            this.L_Count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Uses
            // 
            this.L_Uses.AutoSize = true;
            this.L_Uses.Location = new System.Drawing.Point(48, 6);
            this.L_Uses.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.L_Uses.Name = "L_Uses";
            this.L_Uses.Size = new System.Drawing.Size(34, 13);
            this.L_Uses.TabIndex = 9;
            this.L_Uses.Text = "Uses:";
            this.L_Uses.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Uses
            // 
            this.NUD_Uses.Location = new System.Drawing.Point(88, 3);
            this.NUD_Uses.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_Uses.Name = "NUD_Uses";
            this.NUD_Uses.Size = new System.Drawing.Size(56, 20);
            this.NUD_Uses.TabIndex = 8;
            // 
            // L_Flag0
            // 
            this.L_Flag0.AutoSize = true;
            this.L_Flag0.Location = new System.Drawing.Point(46, 6);
            this.L_Flag0.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.L_Flag0.Name = "L_Flag0";
            this.L_Flag0.Size = new System.Drawing.Size(36, 13);
            this.L_Flag0.TabIndex = 11;
            this.L_Flag0.Text = "Flag0:";
            this.L_Flag0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Flag0
            // 
            this.NUD_Flag0.Hexadecimal = true;
            this.NUD_Flag0.Location = new System.Drawing.Point(88, 3);
            this.NUD_Flag0.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_Flag0.Name = "NUD_Flag0";
            this.NUD_Flag0.Size = new System.Drawing.Size(56, 20);
            this.NUD_Flag0.TabIndex = 10;
            // 
            // L_Flag1
            // 
            this.L_Flag1.AutoSize = true;
            this.L_Flag1.Location = new System.Drawing.Point(46, 6);
            this.L_Flag1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.L_Flag1.Name = "L_Flag1";
            this.L_Flag1.Size = new System.Drawing.Size(36, 13);
            this.L_Flag1.TabIndex = 13;
            this.L_Flag1.Text = "Flag1:";
            this.L_Flag1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Flag1
            // 
            this.NUD_Flag1.Hexadecimal = true;
            this.NUD_Flag1.Location = new System.Drawing.Point(88, 3);
            this.NUD_Flag1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_Flag1.Name = "NUD_Flag1";
            this.NUD_Flag1.Size = new System.Drawing.Size(56, 20);
            this.NUD_Flag1.TabIndex = 12;
            // 
            // CM_Hand
            // 
            this.CM_Hand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_View,
            this.Menu_Set,
            this.Menu_Delete});
            this.CM_Hand.Name = "CM_Hand";
            this.CM_Hand.Size = new System.Drawing.Size(108, 70);
            // 
            // Menu_View
            // 
            this.Menu_View.Name = "Menu_View";
            this.Menu_View.Size = new System.Drawing.Size(107, 22);
            this.Menu_View.Text = "View";
            // 
            // Menu_Set
            // 
            this.Menu_Set.Name = "Menu_Set";
            this.Menu_Set.Size = new System.Drawing.Size(107, 22);
            this.Menu_Set.Text = "Set";
            // 
            // Menu_Delete
            // 
            this.Menu_Delete.Name = "Menu_Delete";
            this.Menu_Delete.Size = new System.Drawing.Size(107, 22);
            this.Menu_Delete.Text = "Delete";
            // 
            // CB_NamedItemArgument
            // 
            this.CB_NamedItemArgument.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_NamedItemArgument.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_NamedItemArgument.DropDownWidth = 322;
            this.CB_NamedItemArgument.FormattingEnabled = true;
            this.CB_NamedItemArgument.Location = new System.Drawing.Point(3, 24);
            this.CB_NamedItemArgument.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.CB_NamedItemArgument.Name = "CB_NamedItemArgument";
            this.CB_NamedItemArgument.Size = new System.Drawing.Size(141, 21);
            this.CB_NamedItemArgument.TabIndex = 14;
            this.CB_NamedItemArgument.Visible = false;
            this.CB_NamedItemArgument.SelectedValueChanged += new System.EventHandler(this.CB_NamedItemArgument_SelectedValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.CB_ItemID);
            this.flowLayoutPanel1.Controls.Add(this.CB_NamedItemArgument);
            this.flowLayoutPanel1.Controls.Add(this.FLP_Count);
            this.flowLayoutPanel1.Controls.Add(this.FLP_Uses);
            this.flowLayoutPanel1.Controls.Add(this.FLP_Flag0);
            this.flowLayoutPanel1.Controls.Add(this.FLP_Flag1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(228, 208);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // FLP_Count
            // 
            this.FLP_Count.Controls.Add(this.NUD_Count);
            this.FLP_Count.Controls.Add(this.L_Count);
            this.FLP_Count.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FLP_Count.Location = new System.Drawing.Point(0, 46);
            this.FLP_Count.Margin = new System.Windows.Forms.Padding(0);
            this.FLP_Count.Name = "FLP_Count";
            this.FLP_Count.Size = new System.Drawing.Size(147, 26);
            this.FLP_Count.TabIndex = 16;
            // 
            // FLP_Uses
            // 
            this.FLP_Uses.Controls.Add(this.NUD_Uses);
            this.FLP_Uses.Controls.Add(this.L_Uses);
            this.FLP_Uses.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FLP_Uses.Location = new System.Drawing.Point(0, 72);
            this.FLP_Uses.Margin = new System.Windows.Forms.Padding(0);
            this.FLP_Uses.Name = "FLP_Uses";
            this.FLP_Uses.Size = new System.Drawing.Size(147, 26);
            this.FLP_Uses.TabIndex = 17;
            // 
            // FLP_Flag0
            // 
            this.FLP_Flag0.Controls.Add(this.NUD_Flag0);
            this.FLP_Flag0.Controls.Add(this.L_Flag0);
            this.FLP_Flag0.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FLP_Flag0.Location = new System.Drawing.Point(0, 98);
            this.FLP_Flag0.Margin = new System.Windows.Forms.Padding(0);
            this.FLP_Flag0.Name = "FLP_Flag0";
            this.FLP_Flag0.Size = new System.Drawing.Size(147, 26);
            this.FLP_Flag0.TabIndex = 17;
            // 
            // FLP_Flag1
            // 
            this.FLP_Flag1.Controls.Add(this.NUD_Flag1);
            this.FLP_Flag1.Controls.Add(this.L_Flag1);
            this.FLP_Flag1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FLP_Flag1.Location = new System.Drawing.Point(0, 124);
            this.FLP_Flag1.Margin = new System.Windows.Forms.Padding(0);
            this.FLP_Flag1.Name = "FLP_Flag1";
            this.FLP_Flag1.Size = new System.Drawing.Size(147, 26);
            this.FLP_Flag1.TabIndex = 17;
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ItemEditor";
            this.Size = new System.Drawing.Size(228, 208);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Uses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Flag0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Flag1)).EndInit();
            this.CM_Hand.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.FLP_Count.ResumeLayout(false);
            this.FLP_Count.PerformLayout();
            this.FLP_Uses.ResumeLayout(false);
            this.FLP_Uses.PerformLayout();
            this.FLP_Flag0.ResumeLayout(false);
            this.FLP_Flag0.PerformLayout();
            this.FLP_Flag1.ResumeLayout(false);
            this.FLP_Flag1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox CB_ItemID;
        private System.Windows.Forms.NumericUpDown NUD_Count;
        private System.Windows.Forms.Label L_Count;
        private System.Windows.Forms.Label L_Uses;
        private System.Windows.Forms.NumericUpDown NUD_Uses;
        private System.Windows.Forms.Label L_Flag0;
        private System.Windows.Forms.NumericUpDown NUD_Flag0;
        private System.Windows.Forms.Label L_Flag1;
        private System.Windows.Forms.NumericUpDown NUD_Flag1;
        private System.Windows.Forms.ContextMenuStrip CM_Hand;
        private System.Windows.Forms.ToolStripMenuItem Menu_View;
        private System.Windows.Forms.ToolStripMenuItem Menu_Set;
        private System.Windows.Forms.ToolStripMenuItem Menu_Delete;
        private System.Windows.Forms.ComboBox CB_NamedItemArgument;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel FLP_Count;
        private System.Windows.Forms.FlowLayoutPanel FLP_Uses;
        private System.Windows.Forms.FlowLayoutPanel FLP_Flag0;
        private System.Windows.Forms.FlowLayoutPanel FLP_Flag1;
    }
}

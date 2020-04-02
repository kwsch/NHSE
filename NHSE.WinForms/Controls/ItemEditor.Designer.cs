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
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Uses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Flag0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Flag1)).BeginInit();
            this.CM_Hand.SuspendLayout();
            this.SuspendLayout();
            // 
            // CB_ItemID
            // 
            this.CB_ItemID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_ItemID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_ItemID.DropDownWidth = 322;
            this.CB_ItemID.FormattingEnabled = true;
            this.CB_ItemID.Location = new System.Drawing.Point(3, 3);
            this.CB_ItemID.Name = "CB_ItemID";
            this.CB_ItemID.Size = new System.Drawing.Size(141, 21);
            this.CB_ItemID.TabIndex = 1;
            // 
            // NUD_Count
            // 
            this.NUD_Count.Location = new System.Drawing.Point(88, 28);
            this.NUD_Count.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_Count.Name = "NUD_Count";
            this.NUD_Count.Size = new System.Drawing.Size(56, 20);
            this.NUD_Count.TabIndex = 2;
            // 
            // L_Count
            // 
            this.L_Count.Location = new System.Drawing.Point(3, 27);
            this.L_Count.Name = "L_Count";
            this.L_Count.Size = new System.Drawing.Size(79, 20);
            this.L_Count.TabIndex = 7;
            this.L_Count.Text = "Count:";
            this.L_Count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Uses
            // 
            this.L_Uses.Location = new System.Drawing.Point(3, 50);
            this.L_Uses.Name = "L_Uses";
            this.L_Uses.Size = new System.Drawing.Size(79, 20);
            this.L_Uses.TabIndex = 9;
            this.L_Uses.Text = "Uses:";
            this.L_Uses.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Uses
            // 
            this.NUD_Uses.Location = new System.Drawing.Point(88, 51);
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
            this.L_Flag0.Location = new System.Drawing.Point(3, 73);
            this.L_Flag0.Name = "L_Flag0";
            this.L_Flag0.Size = new System.Drawing.Size(79, 20);
            this.L_Flag0.TabIndex = 11;
            this.L_Flag0.Text = "Flag0:";
            this.L_Flag0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Flag0
            // 
            this.NUD_Flag0.Hexadecimal = true;
            this.NUD_Flag0.Location = new System.Drawing.Point(88, 74);
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
            this.L_Flag1.Location = new System.Drawing.Point(3, 96);
            this.L_Flag1.Name = "L_Flag1";
            this.L_Flag1.Size = new System.Drawing.Size(79, 20);
            this.L_Flag1.TabIndex = 13;
            this.L_Flag1.Text = "Flag1:";
            this.L_Flag1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Flag1
            // 
            this.NUD_Flag1.Hexadecimal = true;
            this.NUD_Flag1.Location = new System.Drawing.Point(88, 97);
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
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.L_Flag1);
            this.Controls.Add(this.NUD_Flag1);
            this.Controls.Add(this.L_Flag0);
            this.Controls.Add(this.NUD_Flag0);
            this.Controls.Add(this.L_Uses);
            this.Controls.Add(this.NUD_Uses);
            this.Controls.Add(this.L_Count);
            this.Controls.Add(this.NUD_Count);
            this.Controls.Add(this.CB_ItemID);
            this.Name = "ItemEditor";
            this.Size = new System.Drawing.Size(148, 144);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Uses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Flag0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Flag1)).EndInit();
            this.CM_Hand.ResumeLayout(false);
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
    }
}

namespace NHSE.WinForms
{
    partial class ItemGridEditor
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
            this.itemGrid1 = new NHSE.WinForms.ItemGrid();
            this.B_Up = new System.Windows.Forms.Button();
            this.B_Down = new System.Windows.Forms.Button();
            this.L_Page = new System.Windows.Forms.Label();
            this.L_ItemName = new System.Windows.Forms.Label();
            this.CM_Hand = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Hand.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemGrid1
            // 
            this.itemGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemGrid1.Location = new System.Drawing.Point(1, 27);
            this.itemGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.itemGrid1.Name = "itemGrid1";
            this.itemGrid1.Size = new System.Drawing.Size(170, 142);
            this.itemGrid1.TabIndex = 0;
            // 
            // B_Up
            // 
            this.B_Up.Location = new System.Drawing.Point(176, 53);
            this.B_Up.Name = "B_Up";
            this.B_Up.Size = new System.Drawing.Size(41, 30);
            this.B_Up.TabIndex = 3;
            this.B_Up.Text = "↑\t";
            this.B_Up.UseVisualStyleBackColor = true;
            this.B_Up.Visible = false;
            this.B_Up.Click += new System.EventHandler(this.B_Up_Click);
            // 
            // B_Down
            // 
            this.B_Down.Location = new System.Drawing.Point(176, 106);
            this.B_Down.Name = "B_Down";
            this.B_Down.Size = new System.Drawing.Size(42, 29);
            this.B_Down.TabIndex = 4;
            this.B_Down.Text = "↓";
            this.B_Down.UseVisualStyleBackColor = true;
            this.B_Down.Visible = false;
            this.B_Down.Click += new System.EventHandler(this.B_Down_Click);
            // 
            // L_Page
            // 
            this.L_Page.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Page.Location = new System.Drawing.Point(169, 84);
            this.L_Page.Name = "L_Page";
            this.L_Page.Size = new System.Drawing.Size(56, 20);
            this.L_Page.TabIndex = 5;
            this.L_Page.Text = "250/250";
            this.L_Page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_ItemName
            // 
            this.L_ItemName.AutoSize = true;
            this.L_ItemName.Location = new System.Drawing.Point(3, 9);
            this.L_ItemName.Name = "L_ItemName";
            this.L_ItemName.Size = new System.Drawing.Size(39, 13);
            this.L_ItemName.TabIndex = 6;
            this.L_ItemName.Text = "(None)";
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
            this.Menu_View.Click += new System.EventHandler(this.ClickView);
            // 
            // Menu_Set
            // 
            this.Menu_Set.Name = "Menu_Set";
            this.Menu_Set.Size = new System.Drawing.Size(107, 22);
            this.Menu_Set.Text = "Set";
            this.Menu_Set.Click += new System.EventHandler(this.ClickSet);
            // 
            // Menu_Delete
            // 
            this.Menu_Delete.Name = "Menu_Delete";
            this.Menu_Delete.Size = new System.Drawing.Size(107, 22);
            this.Menu_Delete.Text = "Delete";
            this.Menu_Delete.Click += new System.EventHandler(this.ClickDelete);
            // 
            // ItemGridEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.L_ItemName);
            this.Controls.Add(this.B_Down);
            this.Controls.Add(this.B_Up);
            this.Controls.Add(this.itemGrid1);
            this.Controls.Add(this.L_Page);
            this.Name = "ItemGridEditor";
            this.Size = new System.Drawing.Size(224, 170);
            this.CM_Hand.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ItemGrid itemGrid1;
        private System.Windows.Forms.Button B_Up;
        private System.Windows.Forms.Button B_Down;
        private System.Windows.Forms.Label L_Page;
        private System.Windows.Forms.Label L_ItemName;
        private System.Windows.Forms.ContextMenuStrip CM_Hand;
        private System.Windows.Forms.ToolStripMenuItem Menu_View;
        private System.Windows.Forms.ToolStripMenuItem Menu_Set;
        private System.Windows.Forms.ToolStripMenuItem Menu_Delete;
    }
}

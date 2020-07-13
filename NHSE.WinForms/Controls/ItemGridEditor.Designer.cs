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
            this.ItemGrid = new NHSE.WinForms.ItemGrid();
            this.B_Up = new System.Windows.Forms.Button();
            this.B_Down = new System.Windows.Forms.Button();
            this.L_Page = new System.Windows.Forms.Label();
            this.L_ItemName = new System.Windows.Forms.Label();
            this.CM_Hand = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.B_Clear = new System.Windows.Forms.Button();
            this.CM_Remove = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.B_ClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ClearClothing = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ClearCrafting = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ClearBugs = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ClearFish = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ClearFurniture = new System.Windows.Forms.ToolStripMenuItem();
            this.FLP_Controls = new System.Windows.Forms.FlowLayoutPanel();
            this.PAN_Navigation = new System.Windows.Forms.Panel();
            this.HoverTip = new System.Windows.Forms.ToolTip(this.components);
            this.B_ClearDive = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Hand.SuspendLayout();
            this.CM_Remove.SuspendLayout();
            this.FLP_Controls.SuspendLayout();
            this.PAN_Navigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemGrid
            // 
            this.ItemGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemGrid.Location = new System.Drawing.Point(0, 30);
            this.ItemGrid.Margin = new System.Windows.Forms.Padding(0);
            this.ItemGrid.Name = "ItemGrid";
            this.ItemGrid.Size = new System.Drawing.Size(217, 174);
            this.ItemGrid.TabIndex = 0;
            // 
            // B_Up
            // 
            this.B_Up.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Up.Location = new System.Drawing.Point(4, 4);
            this.B_Up.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Up.Name = "B_Up";
            this.B_Up.Size = new System.Drawing.Size(85, 37);
            this.B_Up.TabIndex = 3;
            this.B_Up.Text = "↑\t";
            this.B_Up.UseVisualStyleBackColor = true;
            this.B_Up.Visible = false;
            this.B_Up.Click += new System.EventHandler(this.B_Up_Click);
            // 
            // B_Down
            // 
            this.B_Down.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Down.Location = new System.Drawing.Point(4, 73);
            this.B_Down.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Down.Name = "B_Down";
            this.B_Down.Size = new System.Drawing.Size(85, 36);
            this.B_Down.TabIndex = 4;
            this.B_Down.Text = "↓";
            this.B_Down.UseVisualStyleBackColor = true;
            this.B_Down.Visible = false;
            this.B_Down.Click += new System.EventHandler(this.B_Down_Click);
            // 
            // L_Page
            // 
            this.L_Page.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Page.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Page.Location = new System.Drawing.Point(4, 44);
            this.L_Page.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_Page.Name = "L_Page";
            this.L_Page.Size = new System.Drawing.Size(85, 25);
            this.L_Page.TabIndex = 5;
            this.L_Page.Text = "250/250";
            this.L_Page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_ItemName
            // 
            this.L_ItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.L_ItemName.Location = new System.Drawing.Point(4, 0);
            this.L_ItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_ItemName.Name = "L_ItemName";
            this.L_ItemName.Size = new System.Drawing.Size(311, 30);
            this.L_ItemName.TabIndex = 6;
            this.L_ItemName.Text = "(None)";
            this.L_ItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CM_Hand
            // 
            this.CM_Hand.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CM_Hand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_View,
            this.Menu_Set,
            this.Menu_Delete});
            this.CM_Hand.Name = "CM_Hand";
            this.CM_Hand.ShowImageMargin = false;
            this.CM_Hand.Size = new System.Drawing.Size(98, 76);
            // 
            // Menu_View
            // 
            this.Menu_View.Name = "Menu_View";
            this.Menu_View.Size = new System.Drawing.Size(97, 24);
            this.Menu_View.Text = "View";
            this.Menu_View.Click += new System.EventHandler(this.ClickView);
            // 
            // Menu_Set
            // 
            this.Menu_Set.Name = "Menu_Set";
            this.Menu_Set.Size = new System.Drawing.Size(97, 24);
            this.Menu_Set.Text = "Set";
            this.Menu_Set.Click += new System.EventHandler(this.ClickSet);
            // 
            // Menu_Delete
            // 
            this.Menu_Delete.Name = "Menu_Delete";
            this.Menu_Delete.Size = new System.Drawing.Size(97, 24);
            this.Menu_Delete.Text = "Delete";
            this.Menu_Delete.Click += new System.EventHandler(this.ClickDelete);
            // 
            // B_Clear
            // 
            this.B_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Clear.ContextMenuStrip = this.CM_Remove;
            this.B_Clear.Location = new System.Drawing.Point(4, 135);
            this.B_Clear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(85, 36);
            this.B_Clear.TabIndex = 7;
            this.B_Clear.Text = "Clear";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // CM_Remove
            // 
            this.CM_Remove.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CM_Remove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_ClearAll,
            this.B_ClearClothing,
            this.B_ClearCrafting,
            this.B_ClearBugs,
            this.B_ClearFish,
            this.B_ClearDive,
            this.B_ClearFurniture});
            this.CM_Remove.Name = "CM_Picture";
            this.CM_Remove.ShowImageMargin = false;
            this.CM_Remove.Size = new System.Drawing.Size(186, 200);
            // 
            // B_ClearAll
            // 
            this.B_ClearAll.Name = "B_ClearAll";
            this.B_ClearAll.Size = new System.Drawing.Size(185, 24);
            this.B_ClearAll.Text = "All";
            this.B_ClearAll.Click += new System.EventHandler(this.B_ClearAll_Click);
            // 
            // B_ClearClothing
            // 
            this.B_ClearClothing.Name = "B_ClearClothing";
            this.B_ClearClothing.Size = new System.Drawing.Size(185, 24);
            this.B_ClearClothing.Text = "Clothing";
            this.B_ClearClothing.Click += new System.EventHandler(this.B_ClearClothing_Click);
            // 
            // B_ClearCrafting
            // 
            this.B_ClearCrafting.Name = "B_ClearCrafting";
            this.B_ClearCrafting.Size = new System.Drawing.Size(185, 24);
            this.B_ClearCrafting.Text = "Crafting Materials";
            this.B_ClearCrafting.Click += new System.EventHandler(this.B_ClearCrafting_Click);
            // 
            // B_ClearBugs
            // 
            this.B_ClearBugs.Name = "B_ClearBugs";
            this.B_ClearBugs.Size = new System.Drawing.Size(185, 24);
            this.B_ClearBugs.Text = "Bugs";
            this.B_ClearBugs.Click += new System.EventHandler(this.B_ClearBugs_Click);
            // 
            // B_ClearFish
            // 
            this.B_ClearFish.Name = "B_ClearFish";
            this.B_ClearFish.Size = new System.Drawing.Size(185, 24);
            this.B_ClearFish.Text = "Fish";
            this.B_ClearFish.Click += new System.EventHandler(this.B_ClearFish_Click);
            // 
            // B_ClearFurniture
            // 
            this.B_ClearFurniture.Name = "B_ClearFurniture";
            this.B_ClearFurniture.Size = new System.Drawing.Size(185, 24);
            this.B_ClearFurniture.Text = "Furniture";
            this.B_ClearFurniture.Click += new System.EventHandler(this.B_ClearFurniture_Click);
            // 
            // FLP_Controls
            // 
            this.FLP_Controls.Controls.Add(this.L_ItemName);
            this.FLP_Controls.Controls.Add(this.ItemGrid);
            this.FLP_Controls.Controls.Add(this.PAN_Navigation);
            this.FLP_Controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLP_Controls.Location = new System.Drawing.Point(0, 0);
            this.FLP_Controls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FLP_Controls.Name = "FLP_Controls";
            this.FLP_Controls.Size = new System.Drawing.Size(321, 242);
            this.FLP_Controls.TabIndex = 8;
            // 
            // PAN_Navigation
            // 
            this.PAN_Navigation.Controls.Add(this.B_Up);
            this.PAN_Navigation.Controls.Add(this.L_Page);
            this.PAN_Navigation.Controls.Add(this.B_Down);
            this.PAN_Navigation.Controls.Add(this.B_Clear);
            this.PAN_Navigation.Location = new System.Drawing.Point(217, 30);
            this.PAN_Navigation.Margin = new System.Windows.Forms.Padding(0);
            this.PAN_Navigation.Name = "PAN_Navigation";
            this.PAN_Navigation.Size = new System.Drawing.Size(93, 175);
            this.PAN_Navigation.TabIndex = 9;
            // 
            // HoverTip
            // 
            this.HoverTip.AutomaticDelay = 100;
            // 
            // B_ClearDive
            // 
            this.B_ClearDive.Name = "B_ClearDive";
            this.B_ClearDive.Size = new System.Drawing.Size(185, 24);
            this.B_ClearDive.Text = "Dive";
            this.B_ClearDive.Click += new System.EventHandler(this.B_ClearDive_Click);
            // 
            // ItemGridEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FLP_Controls);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ItemGridEditor";
            this.Size = new System.Drawing.Size(321, 242);
            this.CM_Hand.ResumeLayout(false);
            this.CM_Remove.ResumeLayout(false);
            this.FLP_Controls.ResumeLayout(false);
            this.PAN_Navigation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ItemGrid ItemGrid;
        private System.Windows.Forms.Button B_Up;
        private System.Windows.Forms.Button B_Down;
        private System.Windows.Forms.Label L_Page;
        private System.Windows.Forms.Label L_ItemName;
        private System.Windows.Forms.ContextMenuStrip CM_Hand;
        private System.Windows.Forms.ToolStripMenuItem Menu_View;
        private System.Windows.Forms.ToolStripMenuItem Menu_Set;
        private System.Windows.Forms.ToolStripMenuItem Menu_Delete;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.FlowLayoutPanel FLP_Controls;
        private System.Windows.Forms.Panel PAN_Navigation;
        private System.Windows.Forms.ToolTip HoverTip;
        private System.Windows.Forms.ContextMenuStrip CM_Remove;
        private System.Windows.Forms.ToolStripMenuItem B_ClearAll;
        private System.Windows.Forms.ToolStripMenuItem B_ClearClothing;
        private System.Windows.Forms.ToolStripMenuItem B_ClearCrafting;
        private System.Windows.Forms.ToolStripMenuItem B_ClearBugs;
        private System.Windows.Forms.ToolStripMenuItem B_ClearFish;
        private System.Windows.Forms.ToolStripMenuItem B_ClearFurniture;
        private System.Windows.Forms.ToolStripMenuItem B_ClearDive;
    }
}

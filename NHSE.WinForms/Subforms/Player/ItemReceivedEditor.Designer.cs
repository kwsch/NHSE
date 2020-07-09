namespace NHSE.WinForms
{
    partial class ItemReceivedEditor
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
            this.CLB_Items = new System.Windows.Forms.CheckedListBox();
            this.CB_Item = new System.Windows.Forms.ComboBox();
            this.B_GiveAll = new System.Windows.Forms.Button();
            this.CM_Buttons = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.B_AllFish = new System.Windows.Forms.ToolStripMenuItem();
            this.B_AllBugs = new System.Windows.Forms.ToolStripMenuItem();
            this.B_AllArt = new System.Windows.Forms.ToolStripMenuItem();
            this.B_GiveEverything = new System.Windows.Forms.ToolStripMenuItem();
            this.L_Received = new System.Windows.Forms.Label();
            this.L_VariantBody = new System.Windows.Forms.Label();
            this.CLB_Remake = new System.Windows.Forms.CheckedListBox();
            this.B_AllDive = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(599, 430);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(96, 28);
            this.B_Cancel.TabIndex = 7;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.Location = new System.Drawing.Point(703, 430);
            this.B_Save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(96, 28);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // CLB_Items
            // 
            this.CLB_Items.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CLB_Items.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLB_Items.FormattingEnabled = true;
            this.CLB_Items.Location = new System.Drawing.Point(16, 33);
            this.CLB_Items.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CLB_Items.Name = "CLB_Items";
            this.CLB_Items.Size = new System.Drawing.Size(307, 346);
            this.CLB_Items.TabIndex = 8;
            this.CLB_Items.SelectedIndexChanged += new System.EventHandler(this.CLB_Items_SelectedIndexChanged);
            // 
            // CB_Item
            // 
            this.CB_Item.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CB_Item.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_Item.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Item.DropDownWidth = 322;
            this.CB_Item.FormattingEnabled = true;
            this.CB_Item.Location = new System.Drawing.Point(16, 396);
            this.CB_Item.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_Item.Name = "CB_Item";
            this.CB_Item.Size = new System.Drawing.Size(307, 24);
            this.CB_Item.TabIndex = 13;
            this.CB_Item.SelectedValueChanged += new System.EventHandler(this.CB_Item_SelectedValueChanged);
            // 
            // B_GiveAll
            // 
            this.B_GiveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_GiveAll.ContextMenuStrip = this.CM_Buttons;
            this.B_GiveAll.Location = new System.Drawing.Point(16, 430);
            this.B_GiveAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_GiveAll.Name = "B_GiveAll";
            this.B_GiveAll.Size = new System.Drawing.Size(109, 28);
            this.B_GiveAll.TabIndex = 14;
            this.B_GiveAll.Text = "Give All";
            this.B_GiveAll.UseVisualStyleBackColor = true;
            this.B_GiveAll.Click += new System.EventHandler(this.B_GiveAll_Click);
            // 
            // CM_Buttons
            // 
            this.CM_Buttons.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CM_Buttons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_AllFish,
            this.B_AllBugs,
            this.B_AllDive,
            this.B_AllArt,
            this.B_GiveEverything});
            this.CM_Buttons.Name = "CM_Buttons";
            this.CM_Buttons.Size = new System.Drawing.Size(166, 124);
            // 
            // B_AllFish
            // 
            this.B_AllFish.Name = "B_AllFish";
            this.B_AllFish.Size = new System.Drawing.Size(165, 24);
            this.B_AllFish.Text = "Give All Fish";
            this.B_AllFish.Click += new System.EventHandler(this.B_AllFish_Click);
            // 
            // B_AllBugs
            // 
            this.B_AllBugs.Name = "B_AllBugs";
            this.B_AllBugs.Size = new System.Drawing.Size(165, 24);
            this.B_AllBugs.Text = "Give All Bugs";
            this.B_AllBugs.Click += new System.EventHandler(this.B_AllBugs_Click);
            // 
            // B_AllArt
            // 
            this.B_AllArt.Name = "B_AllArt";
            this.B_AllArt.Size = new System.Drawing.Size(165, 24);
            this.B_AllArt.Text = "Give All Art";
            this.B_AllArt.Click += new System.EventHandler(this.B_AllArt_Click);
            // 
            // B_GiveEverything
            // 
            this.B_GiveEverything.Name = "B_GiveEverything";
            this.B_GiveEverything.Size = new System.Drawing.Size(165, 24);
            this.B_GiveEverything.Text = "Everything";
            this.B_GiveEverything.Click += new System.EventHandler(this.B_GiveEverything_Click);
            // 
            // L_Received
            // 
            this.L_Received.AutoSize = true;
            this.L_Received.Location = new System.Drawing.Point(16, 11);
            this.L_Received.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_Received.Name = "L_Received";
            this.L_Received.Size = new System.Drawing.Size(67, 17);
            this.L_Received.TabIndex = 15;
            this.L_Received.Text = "Received";
            // 
            // L_VariantBody
            // 
            this.L_VariantBody.AutoSize = true;
            this.L_VariantBody.Location = new System.Drawing.Point(328, 11);
            this.L_VariantBody.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_VariantBody.Name = "L_VariantBody";
            this.L_VariantBody.Size = new System.Drawing.Size(89, 17);
            this.L_VariantBody.TabIndex = 16;
            this.L_VariantBody.Text = "Variant Body";
            // 
            // CLB_Remake
            // 
            this.CLB_Remake.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CLB_Remake.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLB_Remake.FormattingEnabled = true;
            this.CLB_Remake.Location = new System.Drawing.Point(332, 33);
            this.CLB_Remake.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CLB_Remake.Name = "CLB_Remake";
            this.CLB_Remake.Size = new System.Drawing.Size(465, 346);
            this.CLB_Remake.TabIndex = 17;
            // 
            // B_AllDive
            // 
            this.B_AllDive.Name = "B_AllDive";
            this.B_AllDive.Size = new System.Drawing.Size(165, 24);
            this.B_AllDive.Text = "Give All Dive";
            this.B_AllDive.Click += new System.EventHandler(this.B_AllDive_Click);
            // 
            // ItemReceivedEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 473);
            this.Controls.Add(this.CLB_Remake);
            this.Controls.Add(this.L_VariantBody);
            this.Controls.Add(this.L_Received);
            this.Controls.Add(this.B_GiveAll);
            this.Controls.Add(this.CB_Item);
            this.Controls.Add(this.CLB_Items);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemReceivedEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Received Item List Editor";
            this.CM_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.CheckedListBox CLB_Items;
        private System.Windows.Forms.ComboBox CB_Item;
        private System.Windows.Forms.Button B_GiveAll;
        private System.Windows.Forms.ContextMenuStrip CM_Buttons;
        private System.Windows.Forms.ToolStripMenuItem B_GiveEverything;
        private System.Windows.Forms.ToolStripMenuItem B_AllFish;
        private System.Windows.Forms.ToolStripMenuItem B_AllBugs;
        private System.Windows.Forms.ToolStripMenuItem B_AllArt;
        private System.Windows.Forms.Label L_Received;
        private System.Windows.Forms.Label L_VariantBody;
        private System.Windows.Forms.CheckedListBox CLB_Remake;
        private System.Windows.Forms.ToolStripMenuItem B_AllDive;
    }
}
namespace NHSE.WinForms
{
    partial class VillagerHouseEditor
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
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.LB_Items = new System.Windows.Forms.ListBox();
            this.PG_Item = new System.Windows.Forms.PropertyGrid();
            this.B_DumpHouse = new System.Windows.Forms.Button();
            this.B_LoadHouse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.Location = new System.Drawing.Point(397, 240);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(75, 31);
            this.B_Save.TabIndex = 1;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(316, 240);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(75, 31);
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
            this.LB_Items.Size = new System.Drawing.Size(149, 251);
            this.LB_Items.TabIndex = 3;
            this.LB_Items.SelectedIndexChanged += new System.EventHandler(this.LB_Items_SelectedIndexChanged);
            // 
            // PG_Item
            // 
            this.PG_Item.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PG_Item.HelpVisible = false;
            this.PG_Item.Location = new System.Drawing.Point(167, 12);
            this.PG_Item.Name = "PG_Item";
            this.PG_Item.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.PG_Item.Size = new System.Drawing.Size(305, 221);
            this.PG_Item.TabIndex = 4;
            this.PG_Item.ToolbarVisible = false;
            this.PG_Item.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PG_Item_PropertyValueChanged);
            // 
            // B_DumpHouse
            // 
            this.B_DumpHouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_DumpHouse.Location = new System.Drawing.Point(168, 239);
            this.B_DumpHouse.Name = "B_DumpHouse";
            this.B_DumpHouse.Size = new System.Drawing.Size(65, 31);
            this.B_DumpHouse.TabIndex = 5;
            this.B_DumpHouse.Text = "Dump";
            this.B_DumpHouse.UseVisualStyleBackColor = true;
            this.B_DumpHouse.Click += new System.EventHandler(this.B_DumpHouse_Click);
            // 
            // B_LoadHouse
            // 
            this.B_LoadHouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_LoadHouse.Location = new System.Drawing.Point(238, 240);
            this.B_LoadHouse.Name = "B_LoadHouse";
            this.B_LoadHouse.Size = new System.Drawing.Size(65, 31);
            this.B_LoadHouse.TabIndex = 6;
            this.B_LoadHouse.Text = "Load";
            this.B_LoadHouse.UseVisualStyleBackColor = true;
            this.B_LoadHouse.Click += new System.EventHandler(this.B_LoadHouse_Click);
            // 
            // VillagerHouseEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 283);
            this.Controls.Add(this.B_LoadHouse);
            this.Controls.Add(this.B_DumpHouse);
            this.Controls.Add(this.PG_Item);
            this.Controls.Add(this.LB_Items);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VillagerHouseEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Villager House Editor";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.ListBox LB_Items;
        private System.Windows.Forms.PropertyGrid PG_Item;
        private System.Windows.Forms.Button B_DumpHouse;
        private System.Windows.Forms.Button B_LoadHouse;
    }
}
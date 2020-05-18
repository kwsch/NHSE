namespace NHSE.WinForms
{
    partial class PlayerHouseEditor
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
            this.PG_Item = new System.Windows.Forms.PropertyGrid();
            this.B_DumpHouse = new System.Windows.Forms.Button();
            this.B_LoadHouse = new System.Windows.Forms.Button();
            this.PB_Room = new System.Windows.Forms.PictureBox();
            this.CM_Click = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.B_EditFlags = new System.Windows.Forms.Button();
            this.L_Coordinates = new System.Windows.Forms.Label();
            this.TT_Hover = new System.Windows.Forms.ToolTip(this.components);
            this.NUD_Room = new System.Windows.Forms.NumericUpDown();
            this.L_Room = new System.Windows.Forms.Label();
            this.L_Layer = new System.Windows.Forms.Label();
            this.NUD_Layer = new System.Windows.Forms.NumericUpDown();
            this.CHK_RedirectExtensionLoad = new System.Windows.Forms.CheckBox();
            this.CHK_AutoExtension = new System.Windows.Forms.CheckBox();
            this.CHK_NoOverwrite = new System.Windows.Forms.CheckBox();
            this.B_LoadRoom = new System.Windows.Forms.Button();
            this.B_DumpRoom = new System.Windows.Forms.Button();
            this.ItemEdit = new NHSE.WinForms.ItemEditor();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Room)).BeginInit();
            this.CM_Click.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Room)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Layer)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.Location = new System.Drawing.Point(964, 542);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(75, 23);
            this.B_Save.TabIndex = 1;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(883, 542);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(75, 23);
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
            this.LB_Items.Location = new System.Drawing.Point(16, 382);
            this.LB_Items.Name = "LB_Items";
            this.LB_Items.Size = new System.Drawing.Size(149, 186);
            this.LB_Items.TabIndex = 3;
            this.LB_Items.SelectedIndexChanged += new System.EventHandler(this.LB_Items_SelectedIndexChanged);
            // 
            // PG_Item
            // 
            this.PG_Item.HelpVisible = false;
            this.PG_Item.Location = new System.Drawing.Point(12, 12);
            this.PG_Item.Name = "PG_Item";
            this.PG_Item.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.PG_Item.Size = new System.Drawing.Size(315, 364);
            this.PG_Item.TabIndex = 4;
            this.PG_Item.ToolbarVisible = false;
            this.PG_Item.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PG_Item_PropertyValueChanged);
            // 
            // B_DumpHouse
            // 
            this.B_DumpHouse.Location = new System.Drawing.Point(171, 382);
            this.B_DumpHouse.Name = "B_DumpHouse";
            this.B_DumpHouse.Size = new System.Drawing.Size(75, 31);
            this.B_DumpHouse.TabIndex = 5;
            this.B_DumpHouse.Text = "Dump";
            this.B_DumpHouse.UseVisualStyleBackColor = true;
            this.B_DumpHouse.Click += new System.EventHandler(this.B_DumpHouse_Click);
            // 
            // B_LoadHouse
            // 
            this.B_LoadHouse.Location = new System.Drawing.Point(252, 382);
            this.B_LoadHouse.Name = "B_LoadHouse";
            this.B_LoadHouse.Size = new System.Drawing.Size(75, 31);
            this.B_LoadHouse.TabIndex = 6;
            this.B_LoadHouse.Text = "Load";
            this.B_LoadHouse.UseVisualStyleBackColor = true;
            this.B_LoadHouse.Click += new System.EventHandler(this.B_LoadHouse_Click);
            // 
            // PB_Room
            // 
            this.PB_Room.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.PB_Room.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Room.ContextMenuStrip = this.CM_Click;
            this.PB_Room.Location = new System.Drawing.Point(333, 30);
            this.PB_Room.Name = "PB_Room";
            this.PB_Room.Size = new System.Drawing.Size(482, 482);
            this.PB_Room.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PB_Room.TabIndex = 7;
            this.PB_Room.TabStop = false;
            this.PB_Room.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlayerHouseEditor_Click);
            this.PB_Room.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_Room_MouseMove);
            // 
            // CM_Click
            // 
            this.CM_Click.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_View,
            this.Menu_Set,
            this.Menu_Reset});
            this.CM_Click.Name = "CM_Click";
            this.CM_Click.Size = new System.Drawing.Size(103, 70);
            // 
            // Menu_View
            // 
            this.Menu_View.Name = "Menu_View";
            this.Menu_View.Size = new System.Drawing.Size(102, 22);
            this.Menu_View.Text = "View";
            this.Menu_View.Click += new System.EventHandler(this.Menu_View_Click);
            // 
            // Menu_Set
            // 
            this.Menu_Set.Name = "Menu_Set";
            this.Menu_Set.Size = new System.Drawing.Size(102, 22);
            this.Menu_Set.Text = "Set";
            this.Menu_Set.Click += new System.EventHandler(this.Menu_Set_Click);
            // 
            // Menu_Reset
            // 
            this.Menu_Reset.Name = "Menu_Reset";
            this.Menu_Reset.Size = new System.Drawing.Size(102, 22);
            this.Menu_Reset.Text = "Reset";
            this.Menu_Reset.Click += new System.EventHandler(this.Menu_Reset_Click);
            // 
            // B_EditFlags
            // 
            this.B_EditFlags.Location = new System.Drawing.Point(194, 419);
            this.B_EditFlags.Name = "B_EditFlags";
            this.B_EditFlags.Size = new System.Drawing.Size(106, 31);
            this.B_EditFlags.TabIndex = 8;
            this.B_EditFlags.Text = "Edit Flags";
            this.B_EditFlags.UseVisualStyleBackColor = true;
            this.B_EditFlags.Click += new System.EventHandler(this.B_EditFlags_Click);
            // 
            // L_Coordinates
            // 
            this.L_Coordinates.AutoSize = true;
            this.L_Coordinates.Location = new System.Drawing.Point(333, 12);
            this.L_Coordinates.Name = "L_Coordinates";
            this.L_Coordinates.Size = new System.Drawing.Size(63, 13);
            this.L_Coordinates.TabIndex = 9;
            this.L_Coordinates.Text = "Coordinates";
            // 
            // TT_Hover
            // 
            this.TT_Hover.AutomaticDelay = 100;
            // 
            // NUD_Room
            // 
            this.NUD_Room.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_Room.Location = new System.Drawing.Point(296, 518);
            this.NUD_Room.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.NUD_Room.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Room.Name = "NUD_Room";
            this.NUD_Room.Size = new System.Drawing.Size(31, 20);
            this.NUD_Room.TabIndex = 10;
            this.NUD_Room.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Room.ValueChanged += new System.EventHandler(this.NUD_Room_ValueChanged);
            // 
            // L_Room
            // 
            this.L_Room.Location = new System.Drawing.Point(194, 518);
            this.L_Room.Name = "L_Room";
            this.L_Room.Size = new System.Drawing.Size(96, 20);
            this.L_Room.TabIndex = 11;
            this.L_Room.Text = "Room:";
            this.L_Room.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Layer
            // 
            this.L_Layer.Location = new System.Drawing.Point(194, 538);
            this.L_Layer.Name = "L_Layer";
            this.L_Layer.Size = new System.Drawing.Size(96, 20);
            this.L_Layer.TabIndex = 13;
            this.L_Layer.Text = "Layer:";
            this.L_Layer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Layer
            // 
            this.NUD_Layer.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_Layer.Location = new System.Drawing.Point(296, 538);
            this.NUD_Layer.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NUD_Layer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Layer.Name = "NUD_Layer";
            this.NUD_Layer.Size = new System.Drawing.Size(31, 20);
            this.NUD_Layer.TabIndex = 12;
            this.NUD_Layer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Layer.ValueChanged += new System.EventHandler(this.NUD_Layer_ValueChanged);
            // 
            // CHK_RedirectExtensionLoad
            // 
            this.CHK_RedirectExtensionLoad.AutoSize = true;
            this.CHK_RedirectExtensionLoad.Checked = true;
            this.CHK_RedirectExtensionLoad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_RedirectExtensionLoad.Location = new System.Drawing.Point(333, 518);
            this.CHK_RedirectExtensionLoad.Name = "CHK_RedirectExtensionLoad";
            this.CHK_RedirectExtensionLoad.Size = new System.Drawing.Size(173, 17);
            this.CHK_RedirectExtensionLoad.TabIndex = 49;
            this.CHK_RedirectExtensionLoad.Text = "View Root instead of Extension";
            this.CHK_RedirectExtensionLoad.UseVisualStyleBackColor = true;
            // 
            // CHK_AutoExtension
            // 
            this.CHK_AutoExtension.AutoSize = true;
            this.CHK_AutoExtension.Checked = true;
            this.CHK_AutoExtension.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_AutoExtension.Location = new System.Drawing.Point(333, 537);
            this.CHK_AutoExtension.Name = "CHK_AutoExtension";
            this.CHK_AutoExtension.Size = new System.Drawing.Size(202, 17);
            this.CHK_AutoExtension.TabIndex = 48;
            this.CHK_AutoExtension.Text = "Handle Item Extensions Automatically";
            this.CHK_AutoExtension.UseVisualStyleBackColor = true;
            // 
            // CHK_NoOverwrite
            // 
            this.CHK_NoOverwrite.AutoSize = true;
            this.CHK_NoOverwrite.Checked = true;
            this.CHK_NoOverwrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_NoOverwrite.Location = new System.Drawing.Point(333, 555);
            this.CHK_NoOverwrite.Name = "CHK_NoOverwrite";
            this.CHK_NoOverwrite.Size = new System.Drawing.Size(196, 17);
            this.CHK_NoOverwrite.TabIndex = 47;
            this.CHK_NoOverwrite.Text = "Prevent Writing Occupied Item Tiles";
            this.CHK_NoOverwrite.UseVisualStyleBackColor = true;
            // 
            // B_LoadRoom
            // 
            this.B_LoadRoom.Location = new System.Drawing.Point(740, 518);
            this.B_LoadRoom.Name = "B_LoadRoom";
            this.B_LoadRoom.Size = new System.Drawing.Size(75, 31);
            this.B_LoadRoom.TabIndex = 51;
            this.B_LoadRoom.Text = "Load";
            this.B_LoadRoom.UseVisualStyleBackColor = true;
            this.B_LoadRoom.Click += new System.EventHandler(this.B_LoadRoom_Click);
            // 
            // B_DumpRoom
            // 
            this.B_DumpRoom.Location = new System.Drawing.Point(659, 518);
            this.B_DumpRoom.Name = "B_DumpRoom";
            this.B_DumpRoom.Size = new System.Drawing.Size(75, 31);
            this.B_DumpRoom.TabIndex = 50;
            this.B_DumpRoom.Text = "Dump";
            this.B_DumpRoom.UseVisualStyleBackColor = true;
            this.B_DumpRoom.Click += new System.EventHandler(this.B_DumpRoom_Click);
            // 
            // ItemEdit
            // 
            this.ItemEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemEdit.Location = new System.Drawing.Point(821, 12);
            this.ItemEdit.Name = "ItemEdit";
            this.ItemEdit.Size = new System.Drawing.Size(222, 523);
            this.ItemEdit.TabIndex = 14;
            // 
            // PlayerHouseEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 577);
            this.Controls.Add(this.B_LoadRoom);
            this.Controls.Add(this.B_DumpRoom);
            this.Controls.Add(this.CHK_RedirectExtensionLoad);
            this.Controls.Add(this.CHK_AutoExtension);
            this.Controls.Add(this.CHK_NoOverwrite);
            this.Controls.Add(this.ItemEdit);
            this.Controls.Add(this.L_Layer);
            this.Controls.Add(this.NUD_Layer);
            this.Controls.Add(this.L_Room);
            this.Controls.Add(this.NUD_Room);
            this.Controls.Add(this.L_Coordinates);
            this.Controls.Add(this.B_EditFlags);
            this.Controls.Add(this.PB_Room);
            this.Controls.Add(this.B_LoadHouse);
            this.Controls.Add(this.B_DumpHouse);
            this.Controls.Add(this.PG_Item);
            this.Controls.Add(this.LB_Items);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayerHouseEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player House Editor";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Room)).EndInit();
            this.CM_Click.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Room)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Layer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.ListBox LB_Items;
        private System.Windows.Forms.PropertyGrid PG_Item;
        private System.Windows.Forms.Button B_DumpHouse;
        private System.Windows.Forms.Button B_LoadHouse;
        private System.Windows.Forms.PictureBox PB_Room;
        private System.Windows.Forms.Button B_EditFlags;
        private System.Windows.Forms.Label L_Coordinates;
        private System.Windows.Forms.ToolTip TT_Hover;
        private System.Windows.Forms.NumericUpDown NUD_Room;
        private System.Windows.Forms.Label L_Room;
        private System.Windows.Forms.Label L_Layer;
        private System.Windows.Forms.NumericUpDown NUD_Layer;
        private ItemEditor ItemEdit;
        private System.Windows.Forms.ContextMenuStrip CM_Click;
        private System.Windows.Forms.ToolStripMenuItem Menu_View;
        private System.Windows.Forms.ToolStripMenuItem Menu_Set;
        private System.Windows.Forms.ToolStripMenuItem Menu_Reset;
        private System.Windows.Forms.CheckBox CHK_RedirectExtensionLoad;
        private System.Windows.Forms.CheckBox CHK_AutoExtension;
        private System.Windows.Forms.CheckBox CHK_NoOverwrite;
        private System.Windows.Forms.Button B_LoadRoom;
        private System.Windows.Forms.Button B_DumpRoom;
    }
}
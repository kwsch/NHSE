namespace NHSE.WinForms
{
    partial class FieldItemEditor
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
                ScaleAcre.Dispose();
                MapReticle.Dispose();
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
            this.PG_Tile = new System.Windows.Forms.PropertyGrid();
            this.CB_Acre = new System.Windows.Forms.ComboBox();
            this.L_Acre = new System.Windows.Forms.Label();
            this.B_DumpAcre = new System.Windows.Forms.Button();
            this.B_DumpAllAcres = new System.Windows.Forms.Button();
            this.B_ImportAllAcres = new System.Windows.Forms.Button();
            this.B_ImportAcre = new System.Windows.Forms.Button();
            this.CM_Click = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.B_Up = new System.Windows.Forms.Button();
            this.B_Left = new System.Windows.Forms.Button();
            this.B_Right = new System.Windows.Forms.Button();
            this.B_Down = new System.Windows.Forms.Button();
            this.PB_Map = new System.Windows.Forms.PictureBox();
            this.CM_Picture = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_SavePNG = new System.Windows.Forms.ToolStripMenuItem();
            this.CHK_SnapToAcre = new System.Windows.Forms.CheckBox();
            this.L_Coordinates = new System.Windows.Forms.Label();
            this.NUD_Layer = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.TT_Hover = new System.Windows.Forms.ToolTip(this.components);
            this.PB_Acre = new System.Windows.Forms.PictureBox();
            this.B_RemoveAllWeeds = new System.Windows.Forms.Button();
            this.B_FillHoles = new System.Windows.Forms.Button();
            this.B_RemovePlants = new System.Windows.Forms.Button();
            this.B_RemoveAll = new System.Windows.Forms.Button();
            this.B_RemoveFences = new System.Windows.Forms.Button();
            this.B_RemoveObjects = new System.Windows.Forms.Button();
            this.GB_Remove = new System.Windows.Forms.GroupBox();
            this.B_RemovePlacedItems = new System.Windows.Forms.Button();
            this.CM_Click.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Map)).BeginInit();
            this.CM_Picture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Layer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Acre)).BeginInit();
            this.GB_Remove.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(820, 502);
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
            this.B_Save.Location = new System.Drawing.Point(898, 502);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(72, 23);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // PG_Tile
            // 
            this.PG_Tile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PG_Tile.HelpVisible = false;
            this.PG_Tile.Location = new System.Drawing.Point(767, 12);
            this.PG_Tile.Name = "PG_Tile";
            this.PG_Tile.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.PG_Tile.Size = new System.Drawing.Size(202, 372);
            this.PG_Tile.TabIndex = 9;
            this.PG_Tile.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PG_Tile_PropertyValueChanged);
            // 
            // CB_Acre
            // 
            this.CB_Acre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Acre.FormattingEnabled = true;
            this.CB_Acre.Location = new System.Drawing.Point(691, 337);
            this.CB_Acre.Name = "CB_Acre";
            this.CB_Acre.Size = new System.Drawing.Size(49, 21);
            this.CB_Acre.TabIndex = 10;
            this.CB_Acre.SelectedIndexChanged += new System.EventHandler(this.ChangeAcre);
            // 
            // L_Acre
            // 
            this.L_Acre.AutoSize = true;
            this.L_Acre.Location = new System.Drawing.Point(653, 340);
            this.L_Acre.Name = "L_Acre";
            this.L_Acre.Size = new System.Drawing.Size(32, 13);
            this.L_Acre.TabIndex = 11;
            this.L_Acre.Text = "Acre:";
            // 
            // B_DumpAcre
            // 
            this.B_DumpAcre.Location = new System.Drawing.Point(532, 439);
            this.B_DumpAcre.Name = "B_DumpAcre";
            this.B_DumpAcre.Size = new System.Drawing.Size(112, 40);
            this.B_DumpAcre.TabIndex = 14;
            this.B_DumpAcre.Text = "Dump Acre";
            this.B_DumpAcre.UseVisualStyleBackColor = true;
            this.B_DumpAcre.Click += new System.EventHandler(this.B_DumpAcre_Click);
            // 
            // B_DumpAllAcres
            // 
            this.B_DumpAllAcres.Location = new System.Drawing.Point(532, 485);
            this.B_DumpAllAcres.Name = "B_DumpAllAcres";
            this.B_DumpAllAcres.Size = new System.Drawing.Size(112, 40);
            this.B_DumpAllAcres.TabIndex = 15;
            this.B_DumpAllAcres.Text = "Dump All Acres";
            this.B_DumpAllAcres.UseVisualStyleBackColor = true;
            this.B_DumpAllAcres.Click += new System.EventHandler(this.B_DumpAllAcres_Click);
            // 
            // B_ImportAllAcres
            // 
            this.B_ImportAllAcres.Location = new System.Drawing.Point(649, 485);
            this.B_ImportAllAcres.Name = "B_ImportAllAcres";
            this.B_ImportAllAcres.Size = new System.Drawing.Size(112, 40);
            this.B_ImportAllAcres.TabIndex = 17;
            this.B_ImportAllAcres.Text = "Import All Acres";
            this.B_ImportAllAcres.UseVisualStyleBackColor = true;
            this.B_ImportAllAcres.Click += new System.EventHandler(this.B_ImportAllAcres_Click);
            // 
            // B_ImportAcre
            // 
            this.B_ImportAcre.Location = new System.Drawing.Point(649, 439);
            this.B_ImportAcre.Name = "B_ImportAcre";
            this.B_ImportAcre.Size = new System.Drawing.Size(112, 40);
            this.B_ImportAcre.TabIndex = 16;
            this.B_ImportAcre.Text = "Import Acre";
            this.B_ImportAcre.UseVisualStyleBackColor = true;
            this.B_ImportAcre.Click += new System.EventHandler(this.B_ImportAcre_Click);
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
            // B_Up
            // 
            this.B_Up.Location = new System.Drawing.Point(581, 300);
            this.B_Up.Name = "B_Up";
            this.B_Up.Size = new System.Drawing.Size(32, 32);
            this.B_Up.TabIndex = 18;
            this.B_Up.Text = "↑";
            this.B_Up.UseVisualStyleBackColor = true;
            this.B_Up.Click += new System.EventHandler(this.B_Up_Click);
            // 
            // B_Left
            // 
            this.B_Left.Location = new System.Drawing.Point(551, 330);
            this.B_Left.Name = "B_Left";
            this.B_Left.Size = new System.Drawing.Size(32, 32);
            this.B_Left.TabIndex = 19;
            this.B_Left.Text = "←";
            this.B_Left.UseVisualStyleBackColor = true;
            this.B_Left.Click += new System.EventHandler(this.B_Left_Click);
            // 
            // B_Right
            // 
            this.B_Right.Location = new System.Drawing.Point(611, 330);
            this.B_Right.Name = "B_Right";
            this.B_Right.Size = new System.Drawing.Size(32, 32);
            this.B_Right.TabIndex = 20;
            this.B_Right.Text = "→";
            this.B_Right.UseVisualStyleBackColor = true;
            this.B_Right.Click += new System.EventHandler(this.B_Right_Click);
            // 
            // B_Down
            // 
            this.B_Down.Location = new System.Drawing.Point(581, 360);
            this.B_Down.Name = "B_Down";
            this.B_Down.Size = new System.Drawing.Size(32, 32);
            this.B_Down.TabIndex = 22;
            this.B_Down.Text = "↓";
            this.B_Down.UseVisualStyleBackColor = true;
            this.B_Down.Click += new System.EventHandler(this.B_Down_Click);
            // 
            // PB_Map
            // 
            this.PB_Map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Map.ContextMenuStrip = this.CM_Picture;
            this.PB_Map.Location = new System.Drawing.Point(535, 35);
            this.PB_Map.Name = "PB_Map";
            this.PB_Map.Size = new System.Drawing.Size(226, 194);
            this.PB_Map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Map.TabIndex = 23;
            this.PB_Map.TabStop = false;
            this.PB_Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_Map_MouseDown);
            this.PB_Map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_Map_MouseMove);
            // 
            // CM_Picture
            // 
            this.CM_Picture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_SavePNG});
            this.CM_Picture.Name = "CM_Picture";
            this.CM_Picture.ShowImageMargin = false;
            this.CM_Picture.Size = new System.Drawing.Size(101, 26);
            // 
            // Menu_SavePNG
            // 
            this.Menu_SavePNG.Name = "Menu_SavePNG";
            this.Menu_SavePNG.Size = new System.Drawing.Size(100, 22);
            this.Menu_SavePNG.Text = "Save .png";
            this.Menu_SavePNG.Click += new System.EventHandler(this.Menu_SavePNG_Click);
            // 
            // CHK_SnapToAcre
            // 
            this.CHK_SnapToAcre.AutoSize = true;
            this.CHK_SnapToAcre.Checked = true;
            this.CHK_SnapToAcre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_SnapToAcre.Location = new System.Drawing.Point(534, 12);
            this.CHK_SnapToAcre.Name = "CHK_SnapToAcre";
            this.CHK_SnapToAcre.Size = new System.Drawing.Size(167, 17);
            this.CHK_SnapToAcre.TabIndex = 24;
            this.CHK_SnapToAcre.Text = "Snap to nearest Acre on Click";
            this.CHK_SnapToAcre.UseVisualStyleBackColor = true;
            // 
            // L_Coordinates
            // 
            this.L_Coordinates.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Coordinates.Location = new System.Drawing.Point(590, 232);
            this.L_Coordinates.Name = "L_Coordinates";
            this.L_Coordinates.Size = new System.Drawing.Size(173, 15);
            this.L_Coordinates.TabIndex = 25;
            this.L_Coordinates.Text = "(000,000) = (0x00,0x00)";
            this.L_Coordinates.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NUD_Layer
            // 
            this.NUD_Layer.Location = new System.Drawing.Point(691, 364);
            this.NUD_Layer.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NUD_Layer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Layer.Name = "NUD_Layer";
            this.NUD_Layer.Size = new System.Drawing.Size(49, 20);
            this.NUD_Layer.TabIndex = 26;
            this.NUD_Layer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Layer.ValueChanged += new System.EventHandler(this.NUD_Layer_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(632, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 27;
            this.label1.Text = "Layer:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TT_Hover
            // 
            this.TT_Hover.AutomaticDelay = 100;
            // 
            // PB_Acre
            // 
            this.PB_Acre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Acre.ContextMenuStrip = this.CM_Click;
            this.PB_Acre.Location = new System.Drawing.Point(12, 12);
            this.PB_Acre.Name = "PB_Acre";
            this.PB_Acre.Size = new System.Drawing.Size(514, 514);
            this.PB_Acre.TabIndex = 28;
            this.PB_Acre.TabStop = false;
            this.PB_Acre.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PB_Acre_MouseClick);
            this.PB_Acre.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_Acre_MouseMove);
            // 
            // B_RemoveAllWeeds
            // 
            this.B_RemoveAllWeeds.Location = new System.Drawing.Point(6, 17);
            this.B_RemoveAllWeeds.Name = "B_RemoveAllWeeds";
            this.B_RemoveAllWeeds.Size = new System.Drawing.Size(92, 23);
            this.B_RemoveAllWeeds.TabIndex = 29;
            this.B_RemoveAllWeeds.Text = "Weeds";
            this.B_RemoveAllWeeds.UseVisualStyleBackColor = true;
            this.B_RemoveAllWeeds.Click += new System.EventHandler(this.B_RemoveAllWeeds_Click);
            // 
            // B_FillHoles
            // 
            this.B_FillHoles.Location = new System.Drawing.Point(105, 39);
            this.B_FillHoles.Name = "B_FillHoles";
            this.B_FillHoles.Size = new System.Drawing.Size(91, 23);
            this.B_FillHoles.TabIndex = 30;
            this.B_FillHoles.Text = "Holes";
            this.B_FillHoles.UseVisualStyleBackColor = true;
            this.B_FillHoles.Click += new System.EventHandler(this.B_FillHoles_Click);
            // 
            // B_RemovePlants
            // 
            this.B_RemovePlants.Location = new System.Drawing.Point(6, 39);
            this.B_RemovePlants.Name = "B_RemovePlants";
            this.B_RemovePlants.Size = new System.Drawing.Size(92, 23);
            this.B_RemovePlants.TabIndex = 31;
            this.B_RemovePlants.Text = "Plants";
            this.B_RemovePlants.UseVisualStyleBackColor = true;
            this.B_RemovePlants.Click += new System.EventHandler(this.B_RemovePlants_Click);
            // 
            // B_RemoveAll
            // 
            this.B_RemoveAll.Location = new System.Drawing.Point(104, 83);
            this.B_RemoveAll.Name = "B_RemoveAll";
            this.B_RemoveAll.Size = new System.Drawing.Size(91, 23);
            this.B_RemoveAll.TabIndex = 32;
            this.B_RemoveAll.Text = "All";
            this.B_RemoveAll.UseVisualStyleBackColor = true;
            this.B_RemoveAll.Click += new System.EventHandler(this.B_RemoveAll_Click);
            // 
            // B_RemoveFences
            // 
            this.B_RemoveFences.Location = new System.Drawing.Point(105, 17);
            this.B_RemoveFences.Name = "B_RemoveFences";
            this.B_RemoveFences.Size = new System.Drawing.Size(91, 23);
            this.B_RemoveFences.TabIndex = 33;
            this.B_RemoveFences.Text = "Fences";
            this.B_RemoveFences.UseVisualStyleBackColor = true;
            this.B_RemoveFences.Click += new System.EventHandler(this.B_RemoveFences_Click);
            // 
            // B_RemoveObjects
            // 
            this.B_RemoveObjects.Location = new System.Drawing.Point(6, 61);
            this.B_RemoveObjects.Name = "B_RemoveObjects";
            this.B_RemoveObjects.Size = new System.Drawing.Size(92, 23);
            this.B_RemoveObjects.TabIndex = 34;
            this.B_RemoveObjects.Text = "Non-Items";
            this.B_RemoveObjects.UseVisualStyleBackColor = true;
            this.B_RemoveObjects.Click += new System.EventHandler(this.B_RemoveObjects_Click);
            // 
            // GB_Remove
            // 
            this.GB_Remove.Controls.Add(this.B_RemovePlacedItems);
            this.GB_Remove.Controls.Add(this.B_RemoveFences);
            this.GB_Remove.Controls.Add(this.B_RemoveObjects);
            this.GB_Remove.Controls.Add(this.B_RemoveAllWeeds);
            this.GB_Remove.Controls.Add(this.B_FillHoles);
            this.GB_Remove.Controls.Add(this.B_RemovePlants);
            this.GB_Remove.Controls.Add(this.B_RemoveAll);
            this.GB_Remove.Location = new System.Drawing.Point(767, 385);
            this.GB_Remove.Name = "GB_Remove";
            this.GB_Remove.Size = new System.Drawing.Size(202, 113);
            this.GB_Remove.TabIndex = 35;
            this.GB_Remove.TabStop = false;
            this.GB_Remove.Text = "Remove from View (Hold Shift=Map)";
            // 
            // B_RemovePlacedItems
            // 
            this.B_RemovePlacedItems.Location = new System.Drawing.Point(6, 83);
            this.B_RemovePlacedItems.Name = "B_RemovePlacedItems";
            this.B_RemovePlacedItems.Size = new System.Drawing.Size(92, 23);
            this.B_RemovePlacedItems.TabIndex = 36;
            this.B_RemovePlacedItems.Text = "Placed Items";
            this.B_RemovePlacedItems.UseVisualStyleBackColor = true;
            this.B_RemovePlacedItems.Click += new System.EventHandler(this.B_RemovePlacedItems_Click);
            // 
            // FieldItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 537);
            this.Controls.Add(this.GB_Remove);
            this.Controls.Add(this.PB_Acre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NUD_Layer);
            this.Controls.Add(this.L_Coordinates);
            this.Controls.Add(this.CHK_SnapToAcre);
            this.Controls.Add(this.PB_Map);
            this.Controls.Add(this.B_Down);
            this.Controls.Add(this.B_Right);
            this.Controls.Add(this.B_Left);
            this.Controls.Add(this.B_Up);
            this.Controls.Add(this.B_ImportAllAcres);
            this.Controls.Add(this.B_ImportAcre);
            this.Controls.Add(this.B_DumpAllAcres);
            this.Controls.Add(this.B_DumpAcre);
            this.Controls.Add(this.L_Acre);
            this.Controls.Add(this.CB_Acre);
            this.Controls.Add(this.PG_Tile);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FieldItemEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Field Item Editor";
            this.CM_Click.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Map)).EndInit();
            this.CM_Picture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Layer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Acre)).EndInit();
            this.GB_Remove.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.PropertyGrid PG_Tile;
        private System.Windows.Forms.ComboBox CB_Acre;
        private System.Windows.Forms.Label L_Acre;
        private System.Windows.Forms.Button B_DumpAcre;
        private System.Windows.Forms.Button B_DumpAllAcres;
        private System.Windows.Forms.Button B_ImportAllAcres;
        private System.Windows.Forms.Button B_ImportAcre;
        private System.Windows.Forms.ContextMenuStrip CM_Click;
        private System.Windows.Forms.ToolStripMenuItem Menu_View;
        private System.Windows.Forms.ToolStripMenuItem Menu_Set;
        private System.Windows.Forms.ToolStripMenuItem Menu_Reset;
        private System.Windows.Forms.Button B_Up;
        private System.Windows.Forms.Button B_Left;
        private System.Windows.Forms.Button B_Right;
        private System.Windows.Forms.Button B_Down;
        private System.Windows.Forms.PictureBox PB_Map;
        private System.Windows.Forms.ContextMenuStrip CM_Picture;
        private System.Windows.Forms.ToolStripMenuItem Menu_SavePNG;
        private System.Windows.Forms.CheckBox CHK_SnapToAcre;
        private System.Windows.Forms.Label L_Coordinates;
        private System.Windows.Forms.NumericUpDown NUD_Layer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip TT_Hover;
        private System.Windows.Forms.PictureBox PB_Acre;
        private System.Windows.Forms.Button B_RemoveAllWeeds;
        private System.Windows.Forms.Button B_FillHoles;
        private System.Windows.Forms.Button B_RemovePlants;
        private System.Windows.Forms.Button B_RemoveAll;
        private System.Windows.Forms.Button B_RemoveFences;
        private System.Windows.Forms.Button B_RemoveObjects;
        private System.Windows.Forms.GroupBox GB_Remove;
        private System.Windows.Forms.Button B_RemovePlacedItems;
    }
}
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
                View.Dispose();
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
            this.CB_Acre = new System.Windows.Forms.ComboBox();
            this.L_Acre = new System.Windows.Forms.Label();
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
            this.Menu_SavePNGItems = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_SavePNGTerrain = new System.Windows.Forms.ToolStripMenuItem();
            this.CHK_SnapToAcre = new System.Windows.Forms.CheckBox();
            this.L_Coordinates = new System.Windows.Forms.Label();
            this.NUD_Layer = new System.Windows.Forms.NumericUpDown();
            this.L_Layer = new System.Windows.Forms.Label();
            this.TT_Hover = new System.Windows.Forms.ToolTip(this.components);
            this.PB_Acre = new System.Windows.Forms.PictureBox();
            this.TR_Transparency = new System.Windows.Forms.TrackBar();
            this.CHK_NoOverwrite = new System.Windows.Forms.CheckBox();
            this.CHK_AutoExtension = new System.Windows.Forms.CheckBox();
            this.B_RemoveItemDropDown = new System.Windows.Forms.Button();
            this.CM_Remove = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.B_RemoveAllWeeds = new System.Windows.Forms.ToolStripMenuItem();
            this.B_RemoveAllTrees = new System.Windows.Forms.ToolStripMenuItem();
            this.B_RemovePlants = new System.Windows.Forms.ToolStripMenuItem();
            this.B_RemoveObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.B_RemovePlacedItems = new System.Windows.Forms.ToolStripMenuItem();
            this.B_RemoveFences = new System.Windows.Forms.ToolStripMenuItem();
            this.B_RemoveBranches = new System.Windows.Forms.ToolStripMenuItem();
            this.B_RemoveShells = new System.Windows.Forms.ToolStripMenuItem();
            this.B_RemoveFlowers = new System.Windows.Forms.ToolStripMenuItem();
            this.B_FillHoles = new System.Windows.Forms.ToolStripMenuItem();
            this.B_RemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.B_WaterFlowers = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Spawn = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Batch = new System.Windows.Forms.ToolStripMenuItem();
            this.GB_Remove = new System.Windows.Forms.Label();
            this.TC_Editor = new System.Windows.Forms.TabControl();
            this.Tab_Item = new System.Windows.Forms.TabPage();
            this.ItemEdit = new NHSE.WinForms.ItemEditor();
            this.B_DumpLoadField = new System.Windows.Forms.Button();
            this.CM_DLField = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.B_DumpAcre = new System.Windows.Forms.ToolStripMenuItem();
            this.B_DumpAllAcres = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ImportAcre = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ImportAllAcres = new System.Windows.Forms.ToolStripMenuItem();
            this.Tab_Building = new System.Windows.Forms.TabPage();
            this.B_DumpLoadBuildings = new System.Windows.Forms.Button();
            this.CM_DLBuilding = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.B_DumpBuildings = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ImportBuildings = new System.Windows.Forms.ToolStripMenuItem();
            this.L_Bit = new System.Windows.Forms.Label();
            this.NUD_Bit = new System.Windows.Forms.NumericUpDown();
            this.L_BuildingType = new System.Windows.Forms.Label();
            this.NUD_BuildingType = new System.Windows.Forms.NumericUpDown();
            this.NUD_UniqueID = new System.Windows.Forms.NumericUpDown();
            this.L_BuildingX = new System.Windows.Forms.Label();
            this.L_BuildingUniqueID = new System.Windows.Forms.Label();
            this.NUD_X = new System.Windows.Forms.NumericUpDown();
            this.NUD_TypeArg = new System.Windows.Forms.NumericUpDown();
            this.L_BuildingY = new System.Windows.Forms.Label();
            this.L_BuildingStructureArg = new System.Windows.Forms.Label();
            this.NUD_Y = new System.Windows.Forms.NumericUpDown();
            this.NUD_Type = new System.Windows.Forms.NumericUpDown();
            this.L_BuildingRotation = new System.Windows.Forms.Label();
            this.L_BuildingStructureType = new System.Windows.Forms.Label();
            this.NUD_Angle = new System.Windows.Forms.NumericUpDown();
            this.L_PlazaX = new System.Windows.Forms.Label();
            this.NUD_PlazaX = new System.Windows.Forms.NumericUpDown();
            this.L_PlazaY = new System.Windows.Forms.Label();
            this.NUD_PlazaY = new System.Windows.Forms.NumericUpDown();
            this.B_Help = new System.Windows.Forms.Button();
            this.LB_Items = new System.Windows.Forms.ListBox();
            this.Tab_Terrain = new System.Windows.Forms.TabPage();
            this.L_TerrainTileLabelTransparency = new System.Windows.Forms.Label();
            this.TR_Terrain = new System.Windows.Forms.TrackBar();
            this.TR_BuildingTransparency = new System.Windows.Forms.TrackBar();
            this.L_BuildingTransparency = new System.Windows.Forms.Label();
            this.PG_TerrainTile = new System.Windows.Forms.PropertyGrid();
            this.L_FieldItemTransparency = new System.Windows.Forms.Label();
            this.B_DumpLoadTerrain = new System.Windows.Forms.Button();
            this.B_ModifyAllTerrain = new System.Windows.Forms.Button();
            this.Tab_Acres = new System.Windows.Forms.TabPage();
            this.NUD_MapAcreTemplateField = new System.Windows.Forms.NumericUpDown();
            this.L_MapAcreTemplateField = new System.Windows.Forms.Label();
            this.L_MapAcreTemplateOutside = new System.Windows.Forms.Label();
            this.NUD_MapAcreTemplateOutside = new System.Windows.Forms.NumericUpDown();
            this.CB_MapAcreSelect = new System.Windows.Forms.ComboBox();
            this.B_DumpLoadAcres = new System.Windows.Forms.Button();
            this.CM_DLMapAcres = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.B_DumpMapAcres = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ImportMapAcres = new System.Windows.Forms.ToolStripMenuItem();
            this.L_MapAcre = new System.Windows.Forms.Label();
            this.CB_MapAcre = new System.Windows.Forms.ComboBox();
            this.CM_DLTerrain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.B_DumpTerrainAcre = new System.Windows.Forms.ToolStripMenuItem();
            this.B_DumpTerrainAll = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ImportTerrainAcre = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ImportTerrainAll = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Terrain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.B_ZeroElevation = new System.Windows.Forms.ToolStripMenuItem();
            this.B_SetAllTerrain = new System.Windows.Forms.ToolStripMenuItem();
            this.B_SetAllRoadTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ClearPlacedDesigns = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ImportPlacedDesigns = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ExportPlacedDesigns = new System.Windows.Forms.ToolStripMenuItem();
            this.RB_Item = new System.Windows.Forms.RadioButton();
            this.RB_Terrain = new System.Windows.Forms.RadioButton();
            this.L_TileMode = new System.Windows.Forms.Label();
            this.CHK_RedirectExtensionLoad = new System.Windows.Forms.CheckBox();
            this.CHK_MoveOnDrag = new System.Windows.Forms.CheckBox();
            this.CHK_FieldItemSnap = new System.Windows.Forms.CheckBox();
            this.B_RemoveBushes = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Click.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Map)).BeginInit();
            this.CM_Picture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Layer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Acre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TR_Transparency)).BeginInit();
            this.CM_Remove.SuspendLayout();
            this.TC_Editor.SuspendLayout();
            this.Tab_Item.SuspendLayout();
            this.CM_DLField.SuspendLayout();
            this.Tab_Building.SuspendLayout();
            this.CM_DLBuilding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Bit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BuildingType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_UniqueID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TypeArg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PlazaX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PlazaY)).BeginInit();
            this.Tab_Terrain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TR_Terrain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TR_BuildingTransparency)).BeginInit();
            this.Tab_Acres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MapAcreTemplateField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MapAcreTemplateOutside)).BeginInit();
            this.CM_DLMapAcres.SuspendLayout();
            this.CM_DLTerrain.SuspendLayout();
            this.CM_Terrain.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(866, 502);
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
            this.B_Save.Location = new System.Drawing.Point(944, 502);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(72, 23);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // CB_Acre
            // 
            this.CB_Acre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Acre.FormattingEnabled = true;
            this.CB_Acre.Location = new System.Drawing.Point(712, 358);
            this.CB_Acre.Name = "CB_Acre";
            this.CB_Acre.Size = new System.Drawing.Size(49, 21);
            this.CB_Acre.TabIndex = 10;
            this.CB_Acre.SelectedIndexChanged += new System.EventHandler(this.ChangeAcre);
            // 
            // L_Acre
            // 
            this.L_Acre.Location = new System.Drawing.Point(619, 360);
            this.L_Acre.Name = "L_Acre";
            this.L_Acre.Size = new System.Drawing.Size(87, 19);
            this.L_Acre.TabIndex = 11;
            this.L_Acre.Text = "Acre:";
            this.L_Acre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.B_Up.Location = new System.Drawing.Point(578, 287);
            this.B_Up.Name = "B_Up";
            this.B_Up.Size = new System.Drawing.Size(32, 32);
            this.B_Up.TabIndex = 18;
            this.B_Up.Text = "↑";
            this.B_Up.UseVisualStyleBackColor = true;
            this.B_Up.Click += new System.EventHandler(this.B_Up_Click);
            // 
            // B_Left
            // 
            this.B_Left.Location = new System.Drawing.Point(548, 317);
            this.B_Left.Name = "B_Left";
            this.B_Left.Size = new System.Drawing.Size(32, 32);
            this.B_Left.TabIndex = 19;
            this.B_Left.Text = "←";
            this.B_Left.UseVisualStyleBackColor = true;
            this.B_Left.Click += new System.EventHandler(this.B_Left_Click);
            // 
            // B_Right
            // 
            this.B_Right.Location = new System.Drawing.Point(608, 317);
            this.B_Right.Name = "B_Right";
            this.B_Right.Size = new System.Drawing.Size(32, 32);
            this.B_Right.TabIndex = 20;
            this.B_Right.Text = "→";
            this.B_Right.UseVisualStyleBackColor = true;
            this.B_Right.Click += new System.EventHandler(this.B_Right_Click);
            // 
            // B_Down
            // 
            this.B_Down.Location = new System.Drawing.Point(578, 347);
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
            this.PB_Map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PB_Map.TabIndex = 23;
            this.PB_Map.TabStop = false;
            this.PB_Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_Map_MouseDown);
            this.PB_Map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_Map_MouseMove);
            // 
            // CM_Picture
            // 
            this.CM_Picture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_SavePNG,
            this.Menu_SavePNGItems,
            this.Menu_SavePNGTerrain});
            this.CM_Picture.Name = "CM_Picture";
            this.CM_Picture.Size = new System.Drawing.Size(152, 70);
            this.CM_Picture.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.CM_Picture_Closing);
            // 
            // Menu_SavePNG
            // 
            this.Menu_SavePNG.Name = "Menu_SavePNG";
            this.Menu_SavePNG.Size = new System.Drawing.Size(151, 22);
            this.Menu_SavePNG.Text = "Save .png";
            this.Menu_SavePNG.Click += new System.EventHandler(this.Menu_SavePNG_Click);
            // 
            // Menu_SavePNGItems
            // 
            this.Menu_SavePNGItems.Checked = true;
            this.Menu_SavePNGItems.CheckOnClick = true;
            this.Menu_SavePNGItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menu_SavePNGItems.Name = "Menu_SavePNGItems";
            this.Menu_SavePNGItems.Size = new System.Drawing.Size(151, 22);
            this.Menu_SavePNGItems.Text = "Include Items";
            // 
            // Menu_SavePNGTerrain
            // 
            this.Menu_SavePNGTerrain.Checked = true;
            this.Menu_SavePNGTerrain.CheckOnClick = true;
            this.Menu_SavePNGTerrain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menu_SavePNGTerrain.Name = "Menu_SavePNGTerrain";
            this.Menu_SavePNGTerrain.Size = new System.Drawing.Size(151, 22);
            this.Menu_SavePNGTerrain.Text = "Include Terrain";
            // 
            // CHK_SnapToAcre
            // 
            this.CHK_SnapToAcre.AutoSize = true;
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
            this.NUD_Layer.Location = new System.Drawing.Point(712, 385);
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
            // L_Layer
            // 
            this.L_Layer.Location = new System.Drawing.Point(619, 385);
            this.L_Layer.Name = "L_Layer";
            this.L_Layer.Size = new System.Drawing.Size(87, 19);
            this.L_Layer.TabIndex = 27;
            this.L_Layer.Text = "Item Layer:";
            this.L_Layer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.PB_Acre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PB_Acre.TabIndex = 28;
            this.PB_Acre.TabStop = false;
            this.PB_Acre.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PB_Acre_MouseClick);
            this.PB_Acre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_Acre_MouseDown);
            this.PB_Acre.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_Acre_MouseMove);
            // 
            // TR_Transparency
            // 
            this.TR_Transparency.AutoSize = false;
            this.TR_Transparency.Location = new System.Drawing.Point(3, 332);
            this.TR_Transparency.Maximum = 100;
            this.TR_Transparency.Name = "TR_Transparency";
            this.TR_Transparency.Size = new System.Drawing.Size(237, 28);
            this.TR_Transparency.TabIndex = 36;
            this.TR_Transparency.TickFrequency = 10;
            this.TR_Transparency.Value = 90;
            this.TR_Transparency.Scroll += new System.EventHandler(this.TR_Transparency_Scroll);
            // 
            // CHK_NoOverwrite
            // 
            this.CHK_NoOverwrite.AutoSize = true;
            this.CHK_NoOverwrite.Checked = true;
            this.CHK_NoOverwrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_NoOverwrite.Location = new System.Drawing.Point(535, 478);
            this.CHK_NoOverwrite.Name = "CHK_NoOverwrite";
            this.CHK_NoOverwrite.Size = new System.Drawing.Size(196, 17);
            this.CHK_NoOverwrite.TabIndex = 37;
            this.CHK_NoOverwrite.Text = "Prevent Writing Occupied Item Tiles";
            this.CHK_NoOverwrite.UseVisualStyleBackColor = true;
            // 
            // CHK_AutoExtension
            // 
            this.CHK_AutoExtension.AutoSize = true;
            this.CHK_AutoExtension.Checked = true;
            this.CHK_AutoExtension.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_AutoExtension.Location = new System.Drawing.Point(535, 460);
            this.CHK_AutoExtension.Name = "CHK_AutoExtension";
            this.CHK_AutoExtension.Size = new System.Drawing.Size(202, 17);
            this.CHK_AutoExtension.TabIndex = 38;
            this.CHK_AutoExtension.Text = "Handle Item Extensions Automatically";
            this.CHK_AutoExtension.UseVisualStyleBackColor = true;
            // 
            // B_RemoveItemDropDown
            // 
            this.B_RemoveItemDropDown.ContextMenuStrip = this.CM_Remove;
            this.B_RemoveItemDropDown.Location = new System.Drawing.Point(126, 413);
            this.B_RemoveItemDropDown.Name = "B_RemoveItemDropDown";
            this.B_RemoveItemDropDown.Size = new System.Drawing.Size(112, 40);
            this.B_RemoveItemDropDown.TabIndex = 37;
            this.B_RemoveItemDropDown.Text = "Remove Items...";
            this.B_RemoveItemDropDown.UseVisualStyleBackColor = true;
            this.B_RemoveItemDropDown.Click += new System.EventHandler(this.B_RemoveItemDropDown_Click);
            // 
            // CM_Remove
            // 
            this.CM_Remove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_RemoveAllWeeds,
            this.B_RemoveAllTrees,
            this.B_RemovePlants,
            this.B_RemoveObjects,
            this.B_RemovePlacedItems,
            this.B_RemoveFences,
            this.B_RemoveBranches,
            this.B_RemoveShells,
            this.B_RemoveFlowers,
            this.B_RemoveBushes,
            this.B_FillHoles,
            this.B_RemoveAll,
            this.toolStripSeparator1,
            this.B_WaterFlowers,
            this.Menu_Spawn,
            this.Menu_Batch});
            this.CM_Remove.Name = "CM_Picture";
            this.CM_Remove.ShowImageMargin = false;
            this.CM_Remove.Size = new System.Drawing.Size(156, 362);
            // 
            // B_RemoveAllWeeds
            // 
            this.B_RemoveAllWeeds.Name = "B_RemoveAllWeeds";
            this.B_RemoveAllWeeds.Size = new System.Drawing.Size(155, 22);
            this.B_RemoveAllWeeds.Text = "Weeds";
            this.B_RemoveAllWeeds.Click += new System.EventHandler(this.B_RemoveAllWeeds_Click);
            // 
            // B_RemoveAllTrees
            // 
            this.B_RemoveAllTrees.Name = "B_RemoveAllTrees";
            this.B_RemoveAllTrees.Size = new System.Drawing.Size(155, 22);
            this.B_RemoveAllTrees.Text = "Trees";
            this.B_RemoveAllTrees.Click += new System.EventHandler(this.B_RemoveAllTrees_Click);
            // 
            // B_RemovePlants
            // 
            this.B_RemovePlants.Name = "B_RemovePlants";
            this.B_RemovePlants.Size = new System.Drawing.Size(155, 22);
            this.B_RemovePlants.Text = "Plants";
            this.B_RemovePlants.Click += new System.EventHandler(this.B_RemovePlants_Click);
            // 
            // B_RemoveObjects
            // 
            this.B_RemoveObjects.Name = "B_RemoveObjects";
            this.B_RemoveObjects.Size = new System.Drawing.Size(155, 22);
            this.B_RemoveObjects.Text = "Objects";
            this.B_RemoveObjects.Click += new System.EventHandler(this.B_RemoveObjects_Click);
            // 
            // B_RemovePlacedItems
            // 
            this.B_RemovePlacedItems.Name = "B_RemovePlacedItems";
            this.B_RemovePlacedItems.Size = new System.Drawing.Size(155, 22);
            this.B_RemovePlacedItems.Text = "Placed Items";
            this.B_RemovePlacedItems.Click += new System.EventHandler(this.B_RemovePlacedItems_Click);
            // 
            // B_RemoveFences
            // 
            this.B_RemoveFences.Name = "B_RemoveFences";
            this.B_RemoveFences.Size = new System.Drawing.Size(155, 22);
            this.B_RemoveFences.Text = "Fences";
            this.B_RemoveFences.Click += new System.EventHandler(this.B_RemoveFences_Click);
            // 
            // B_RemoveBranches
            // 
            this.B_RemoveBranches.Name = "B_RemoveBranches";
            this.B_RemoveBranches.Size = new System.Drawing.Size(155, 22);
            this.B_RemoveBranches.Text = "Branches";
            this.B_RemoveBranches.Click += new System.EventHandler(this.B_RemoveBranches_Click);
            // 
            // B_RemoveShells
            // 
            this.B_RemoveShells.Name = "B_RemoveShells";
            this.B_RemoveShells.Size = new System.Drawing.Size(155, 22);
            this.B_RemoveShells.Text = "Shells";
            this.B_RemoveShells.Click += new System.EventHandler(this.B_RemoveShells_Click);
            // 
            // B_RemoveFlowers
            // 
            this.B_RemoveFlowers.Name = "B_RemoveFlowers";
            this.B_RemoveFlowers.Size = new System.Drawing.Size(155, 22);
            this.B_RemoveFlowers.Text = "Flowers";
            this.B_RemoveFlowers.Click += new System.EventHandler(this.B_RemoveFlowers_Click);
            // 
            // B_FillHoles
            // 
            this.B_FillHoles.Name = "B_FillHoles";
            this.B_FillHoles.Size = new System.Drawing.Size(155, 22);
            this.B_FillHoles.Text = "Holes";
            this.B_FillHoles.Click += new System.EventHandler(this.B_FillHoles_Click);
            // 
            // B_RemoveAll
            // 
            this.B_RemoveAll.Name = "B_RemoveAll";
            this.B_RemoveAll.Size = new System.Drawing.Size(155, 22);
            this.B_RemoveAll.Text = "All";
            this.B_RemoveAll.Click += new System.EventHandler(this.B_RemoveAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // B_WaterFlowers
            // 
            this.B_WaterFlowers.Name = "B_WaterFlowers";
            this.B_WaterFlowers.Size = new System.Drawing.Size(155, 22);
            this.B_WaterFlowers.Text = "Water Flowers";
            this.B_WaterFlowers.Click += new System.EventHandler(this.B_WaterFlowers_Click);
            // 
            // Menu_Spawn
            // 
            this.Menu_Spawn.Name = "Menu_Spawn";
            this.Menu_Spawn.Size = new System.Drawing.Size(155, 22);
            this.Menu_Spawn.Text = "Spawn...";
            this.Menu_Spawn.Click += new System.EventHandler(this.Menu_Spawn_Click);
            // 
            // Menu_Batch
            // 
            this.Menu_Batch.Name = "Menu_Batch";
            this.Menu_Batch.Size = new System.Drawing.Size(155, 22);
            this.Menu_Batch.Text = "Batch Editor";
            this.Menu_Batch.Click += new System.EventHandler(this.Menu_Bulk_Click);
            // 
            // GB_Remove
            // 
            this.GB_Remove.AutoSize = true;
            this.GB_Remove.Location = new System.Drawing.Point(60, 396);
            this.GB_Remove.Name = "GB_Remove";
            this.GB_Remove.Size = new System.Drawing.Size(178, 13);
            this.GB_Remove.TabIndex = 39;
            this.GB_Remove.Text = "Remove from View (Hold Shift=Map)";
            // 
            // TC_Editor
            // 
            this.TC_Editor.Controls.Add(this.Tab_Item);
            this.TC_Editor.Controls.Add(this.Tab_Building);
            this.TC_Editor.Controls.Add(this.Tab_Terrain);
            this.TC_Editor.Controls.Add(this.Tab_Acres);
            this.TC_Editor.Location = new System.Drawing.Point(767, 12);
            this.TC_Editor.Name = "TC_Editor";
            this.TC_Editor.SelectedIndex = 0;
            this.TC_Editor.Size = new System.Drawing.Size(252, 484);
            this.TC_Editor.TabIndex = 40;
            // 
            // Tab_Item
            // 
            this.Tab_Item.Controls.Add(this.ItemEdit);
            this.Tab_Item.Controls.Add(this.B_DumpLoadField);
            this.Tab_Item.Controls.Add(this.B_RemoveItemDropDown);
            this.Tab_Item.Controls.Add(this.GB_Remove);
            this.Tab_Item.Location = new System.Drawing.Point(4, 22);
            this.Tab_Item.Name = "Tab_Item";
            this.Tab_Item.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Item.Size = new System.Drawing.Size(244, 458);
            this.Tab_Item.TabIndex = 0;
            this.Tab_Item.Text = "Items";
            this.Tab_Item.UseVisualStyleBackColor = true;
            // 
            // ItemEdit
            // 
            this.ItemEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemEdit.Location = new System.Drawing.Point(3, 3);
            this.ItemEdit.Name = "ItemEdit";
            this.ItemEdit.Size = new System.Drawing.Size(238, 390);
            this.ItemEdit.TabIndex = 40;
            // 
            // B_DumpLoadField
            // 
            this.B_DumpLoadField.ContextMenuStrip = this.CM_DLField;
            this.B_DumpLoadField.Location = new System.Drawing.Point(6, 413);
            this.B_DumpLoadField.Name = "B_DumpLoadField";
            this.B_DumpLoadField.Size = new System.Drawing.Size(112, 40);
            this.B_DumpLoadField.TabIndex = 38;
            this.B_DumpLoadField.Text = "Dump/Import";
            this.B_DumpLoadField.UseVisualStyleBackColor = true;
            this.B_DumpLoadField.Click += new System.EventHandler(this.B_DumpLoadField_Click);
            // 
            // CM_DLField
            // 
            this.CM_DLField.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_DumpAcre,
            this.B_DumpAllAcres,
            this.B_ImportAcre,
            this.B_ImportAllAcres});
            this.CM_DLField.Name = "CM_Picture";
            this.CM_DLField.ShowImageMargin = false;
            this.CM_DLField.Size = new System.Drawing.Size(135, 92);
            // 
            // B_DumpAcre
            // 
            this.B_DumpAcre.Name = "B_DumpAcre";
            this.B_DumpAcre.Size = new System.Drawing.Size(134, 22);
            this.B_DumpAcre.Text = "Dump Acre";
            this.B_DumpAcre.Click += new System.EventHandler(this.B_DumpAcre_Click);
            // 
            // B_DumpAllAcres
            // 
            this.B_DumpAllAcres.Name = "B_DumpAllAcres";
            this.B_DumpAllAcres.Size = new System.Drawing.Size(134, 22);
            this.B_DumpAllAcres.Text = "Dump All Acres";
            this.B_DumpAllAcres.Click += new System.EventHandler(this.B_DumpAllAcres_Click);
            // 
            // B_ImportAcre
            // 
            this.B_ImportAcre.Name = "B_ImportAcre";
            this.B_ImportAcre.Size = new System.Drawing.Size(134, 22);
            this.B_ImportAcre.Text = "Import Acre";
            this.B_ImportAcre.Click += new System.EventHandler(this.B_ImportAcre_Click);
            // 
            // B_ImportAllAcres
            // 
            this.B_ImportAllAcres.Name = "B_ImportAllAcres";
            this.B_ImportAllAcres.Size = new System.Drawing.Size(134, 22);
            this.B_ImportAllAcres.Text = "Import All Acres";
            this.B_ImportAllAcres.Click += new System.EventHandler(this.B_ImportAllAcres_Click);
            // 
            // Tab_Building
            // 
            this.Tab_Building.Controls.Add(this.B_DumpLoadBuildings);
            this.Tab_Building.Controls.Add(this.L_Bit);
            this.Tab_Building.Controls.Add(this.NUD_Bit);
            this.Tab_Building.Controls.Add(this.L_BuildingType);
            this.Tab_Building.Controls.Add(this.NUD_BuildingType);
            this.Tab_Building.Controls.Add(this.NUD_UniqueID);
            this.Tab_Building.Controls.Add(this.L_BuildingX);
            this.Tab_Building.Controls.Add(this.L_BuildingUniqueID);
            this.Tab_Building.Controls.Add(this.NUD_X);
            this.Tab_Building.Controls.Add(this.NUD_TypeArg);
            this.Tab_Building.Controls.Add(this.L_BuildingY);
            this.Tab_Building.Controls.Add(this.L_BuildingStructureArg);
            this.Tab_Building.Controls.Add(this.NUD_Y);
            this.Tab_Building.Controls.Add(this.NUD_Type);
            this.Tab_Building.Controls.Add(this.L_BuildingRotation);
            this.Tab_Building.Controls.Add(this.L_BuildingStructureType);
            this.Tab_Building.Controls.Add(this.NUD_Angle);
            this.Tab_Building.Controls.Add(this.L_PlazaX);
            this.Tab_Building.Controls.Add(this.NUD_PlazaX);
            this.Tab_Building.Controls.Add(this.L_PlazaY);
            this.Tab_Building.Controls.Add(this.NUD_PlazaY);
            this.Tab_Building.Controls.Add(this.B_Help);
            this.Tab_Building.Controls.Add(this.LB_Items);
            this.Tab_Building.Location = new System.Drawing.Point(4, 22);
            this.Tab_Building.Name = "Tab_Building";
            this.Tab_Building.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Building.Size = new System.Drawing.Size(244, 458);
            this.Tab_Building.TabIndex = 1;
            this.Tab_Building.Text = "Buildings";
            this.Tab_Building.UseVisualStyleBackColor = true;
            // 
            // B_DumpLoadBuildings
            // 
            this.B_DumpLoadBuildings.ContextMenuStrip = this.CM_DLBuilding;
            this.B_DumpLoadBuildings.Location = new System.Drawing.Point(6, 413);
            this.B_DumpLoadBuildings.Name = "B_DumpLoadBuildings";
            this.B_DumpLoadBuildings.Size = new System.Drawing.Size(112, 40);
            this.B_DumpLoadBuildings.TabIndex = 132;
            this.B_DumpLoadBuildings.Text = "Dump/Import";
            this.B_DumpLoadBuildings.UseVisualStyleBackColor = true;
            this.B_DumpLoadBuildings.Click += new System.EventHandler(this.B_DumpLoadBuildings_Click);
            // 
            // CM_DLBuilding
            // 
            this.CM_DLBuilding.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_DumpBuildings,
            this.B_ImportBuildings});
            this.CM_DLBuilding.Name = "CM_Picture";
            this.CM_DLBuilding.ShowImageMargin = false;
            this.CM_DLBuilding.Size = new System.Drawing.Size(138, 48);
            // 
            // B_DumpBuildings
            // 
            this.B_DumpBuildings.Name = "B_DumpBuildings";
            this.B_DumpBuildings.Size = new System.Drawing.Size(137, 22);
            this.B_DumpBuildings.Text = "Dump Buildings";
            this.B_DumpBuildings.Click += new System.EventHandler(this.B_DumpBuildings_Click);
            // 
            // B_ImportBuildings
            // 
            this.B_ImportBuildings.Name = "B_ImportBuildings";
            this.B_ImportBuildings.Size = new System.Drawing.Size(137, 22);
            this.B_ImportBuildings.Text = "Import Buildings";
            this.B_ImportBuildings.Click += new System.EventHandler(this.B_ImportBuildings_Click);
            // 
            // L_Bit
            // 
            this.L_Bit.Location = new System.Drawing.Point(36, 303);
            this.L_Bit.Name = "L_Bit";
            this.L_Bit.Size = new System.Drawing.Size(100, 18);
            this.L_Bit.TabIndex = 130;
            this.L_Bit.Text = "Bit:";
            this.L_Bit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Bit
            // 
            this.NUD_Bit.Location = new System.Drawing.Point(142, 304);
            this.NUD_Bit.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.NUD_Bit.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.NUD_Bit.Name = "NUD_Bit";
            this.NUD_Bit.Size = new System.Drawing.Size(69, 20);
            this.NUD_Bit.TabIndex = 131;
            this.NUD_Bit.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // L_BuildingType
            // 
            this.L_BuildingType.Location = new System.Drawing.Point(36, 236);
            this.L_BuildingType.Name = "L_BuildingType";
            this.L_BuildingType.Size = new System.Drawing.Size(100, 18);
            this.L_BuildingType.TabIndex = 116;
            this.L_BuildingType.Text = "Building Type:";
            this.L_BuildingType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_BuildingType
            // 
            this.NUD_BuildingType.Location = new System.Drawing.Point(142, 237);
            this.NUD_BuildingType.Name = "NUD_BuildingType";
            this.NUD_BuildingType.Size = new System.Drawing.Size(69, 20);
            this.NUD_BuildingType.TabIndex = 117;
            this.NUD_BuildingType.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // NUD_UniqueID
            // 
            this.NUD_UniqueID.Location = new System.Drawing.Point(142, 371);
            this.NUD_UniqueID.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_UniqueID.Name = "NUD_UniqueID";
            this.NUD_UniqueID.Size = new System.Drawing.Size(69, 20);
            this.NUD_UniqueID.TabIndex = 129;
            this.NUD_UniqueID.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // L_BuildingX
            // 
            this.L_BuildingX.Location = new System.Drawing.Point(65, 257);
            this.L_BuildingX.Name = "L_BuildingX";
            this.L_BuildingX.Size = new System.Drawing.Size(20, 18);
            this.L_BuildingX.TabIndex = 118;
            this.L_BuildingX.Text = "X:";
            this.L_BuildingX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_BuildingUniqueID
            // 
            this.L_BuildingUniqueID.Location = new System.Drawing.Point(36, 370);
            this.L_BuildingUniqueID.Name = "L_BuildingUniqueID";
            this.L_BuildingUniqueID.Size = new System.Drawing.Size(100, 18);
            this.L_BuildingUniqueID.TabIndex = 128;
            this.L_BuildingUniqueID.Text = "UniqueID:";
            this.L_BuildingUniqueID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_X
            // 
            this.NUD_X.Location = new System.Drawing.Point(91, 258);
            this.NUD_X.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_X.Name = "NUD_X";
            this.NUD_X.Size = new System.Drawing.Size(45, 20);
            this.NUD_X.TabIndex = 119;
            this.NUD_X.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // NUD_TypeArg
            // 
            this.NUD_TypeArg.Location = new System.Drawing.Point(142, 350);
            this.NUD_TypeArg.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_TypeArg.Name = "NUD_TypeArg";
            this.NUD_TypeArg.Size = new System.Drawing.Size(69, 20);
            this.NUD_TypeArg.TabIndex = 127;
            this.NUD_TypeArg.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // L_BuildingY
            // 
            this.L_BuildingY.Location = new System.Drawing.Point(137, 257);
            this.L_BuildingY.Name = "L_BuildingY";
            this.L_BuildingY.Size = new System.Drawing.Size(23, 18);
            this.L_BuildingY.TabIndex = 120;
            this.L_BuildingY.Text = "Y:";
            this.L_BuildingY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_BuildingStructureArg
            // 
            this.L_BuildingStructureArg.Location = new System.Drawing.Point(36, 349);
            this.L_BuildingStructureArg.Name = "L_BuildingStructureArg";
            this.L_BuildingStructureArg.Size = new System.Drawing.Size(100, 18);
            this.L_BuildingStructureArg.TabIndex = 126;
            this.L_BuildingStructureArg.Text = "TypeArg:";
            this.L_BuildingStructureArg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Y
            // 
            this.NUD_Y.Location = new System.Drawing.Point(166, 258);
            this.NUD_Y.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_Y.Name = "NUD_Y";
            this.NUD_Y.Size = new System.Drawing.Size(45, 20);
            this.NUD_Y.TabIndex = 121;
            this.NUD_Y.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // NUD_Type
            // 
            this.NUD_Type.Location = new System.Drawing.Point(142, 329);
            this.NUD_Type.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_Type.Name = "NUD_Type";
            this.NUD_Type.Size = new System.Drawing.Size(69, 20);
            this.NUD_Type.TabIndex = 125;
            this.NUD_Type.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // L_BuildingRotation
            // 
            this.L_BuildingRotation.Location = new System.Drawing.Point(36, 282);
            this.L_BuildingRotation.Name = "L_BuildingRotation";
            this.L_BuildingRotation.Size = new System.Drawing.Size(100, 18);
            this.L_BuildingRotation.TabIndex = 122;
            this.L_BuildingRotation.Text = "Angle:";
            this.L_BuildingRotation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_BuildingStructureType
            // 
            this.L_BuildingStructureType.Location = new System.Drawing.Point(36, 328);
            this.L_BuildingStructureType.Name = "L_BuildingStructureType";
            this.L_BuildingStructureType.Size = new System.Drawing.Size(100, 18);
            this.L_BuildingStructureType.TabIndex = 124;
            this.L_BuildingStructureType.Text = "Type:";
            this.L_BuildingStructureType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Angle
            // 
            this.NUD_Angle.Location = new System.Drawing.Point(142, 283);
            this.NUD_Angle.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_Angle.Name = "NUD_Angle";
            this.NUD_Angle.Size = new System.Drawing.Size(69, 20);
            this.NUD_Angle.TabIndex = 123;
            this.NUD_Angle.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // L_PlazaX
            // 
            this.L_PlazaX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.L_PlazaX.Location = new System.Drawing.Point(65, 2);
            this.L_PlazaX.Name = "L_PlazaX";
            this.L_PlazaX.Size = new System.Drawing.Size(62, 20);
            this.L_PlazaX.TabIndex = 115;
            this.L_PlazaX.Text = "Plaza X:";
            this.L_PlazaX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_PlazaX
            // 
            this.NUD_PlazaX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_PlazaX.Location = new System.Drawing.Point(128, 3);
            this.NUD_PlazaX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NUD_PlazaX.Name = "NUD_PlazaX";
            this.NUD_PlazaX.Size = new System.Drawing.Size(39, 20);
            this.NUD_PlazaX.TabIndex = 114;
            this.NUD_PlazaX.Value = new decimal(new int[] {
            555,
            0,
            0,
            0});
            this.NUD_PlazaX.ValueChanged += new System.EventHandler(this.NUD_PlazaX_ValueChanged);
            // 
            // L_PlazaY
            // 
            this.L_PlazaY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.L_PlazaY.Location = new System.Drawing.Point(65, 23);
            this.L_PlazaY.Name = "L_PlazaY";
            this.L_PlazaY.Size = new System.Drawing.Size(62, 20);
            this.L_PlazaY.TabIndex = 113;
            this.L_PlazaY.Text = "Plaza Y:";
            this.L_PlazaY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_PlazaY
            // 
            this.NUD_PlazaY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_PlazaY.Location = new System.Drawing.Point(128, 24);
            this.NUD_PlazaY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NUD_PlazaY.Name = "NUD_PlazaY";
            this.NUD_PlazaY.Size = new System.Drawing.Size(39, 20);
            this.NUD_PlazaY.TabIndex = 112;
            this.NUD_PlazaY.Value = new decimal(new int[] {
            555,
            0,
            0,
            0});
            this.NUD_PlazaY.ValueChanged += new System.EventHandler(this.NUD_PlazaY_ValueChanged);
            // 
            // B_Help
            // 
            this.B_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Help.Location = new System.Drawing.Point(126, 413);
            this.B_Help.Name = "B_Help";
            this.B_Help.Size = new System.Drawing.Size(112, 40);
            this.B_Help.TabIndex = 111;
            this.B_Help.Text = "Help";
            this.B_Help.UseVisualStyleBackColor = true;
            this.B_Help.Click += new System.EventHandler(this.B_Help_Click);
            // 
            // LB_Items
            // 
            this.LB_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_Items.FormattingEnabled = true;
            this.LB_Items.Location = new System.Drawing.Point(6, 45);
            this.LB_Items.Name = "LB_Items";
            this.LB_Items.Size = new System.Drawing.Size(232, 186);
            this.LB_Items.TabIndex = 109;
            this.LB_Items.SelectedIndexChanged += new System.EventHandler(this.LB_Items_SelectedIndexChanged);
            // 
            // Tab_Terrain
            // 
            this.Tab_Terrain.Controls.Add(this.L_TerrainTileLabelTransparency);
            this.Tab_Terrain.Controls.Add(this.TR_Terrain);
            this.Tab_Terrain.Controls.Add(this.TR_BuildingTransparency);
            this.Tab_Terrain.Controls.Add(this.L_BuildingTransparency);
            this.Tab_Terrain.Controls.Add(this.PG_TerrainTile);
            this.Tab_Terrain.Controls.Add(this.L_FieldItemTransparency);
            this.Tab_Terrain.Controls.Add(this.TR_Transparency);
            this.Tab_Terrain.Controls.Add(this.B_DumpLoadTerrain);
            this.Tab_Terrain.Controls.Add(this.B_ModifyAllTerrain);
            this.Tab_Terrain.Location = new System.Drawing.Point(4, 22);
            this.Tab_Terrain.Name = "Tab_Terrain";
            this.Tab_Terrain.Size = new System.Drawing.Size(244, 458);
            this.Tab_Terrain.TabIndex = 2;
            this.Tab_Terrain.Text = "Terrain";
            this.Tab_Terrain.UseVisualStyleBackColor = true;
            // 
            // L_TerrainTileLabelTransparency
            // 
            this.L_TerrainTileLabelTransparency.AutoSize = true;
            this.L_TerrainTileLabelTransparency.Location = new System.Drawing.Point(8, 272);
            this.L_TerrainTileLabelTransparency.Name = "L_TerrainTileLabelTransparency";
            this.L_TerrainTileLabelTransparency.Size = new System.Drawing.Size(157, 13);
            this.L_TerrainTileLabelTransparency.TabIndex = 46;
            this.L_TerrainTileLabelTransparency.Text = "Terrain Tile Label Transparency";
            // 
            // TR_Terrain
            // 
            this.TR_Terrain.AutoSize = false;
            this.TR_Terrain.Location = new System.Drawing.Point(3, 285);
            this.TR_Terrain.Maximum = 255;
            this.TR_Terrain.Name = "TR_Terrain";
            this.TR_Terrain.Size = new System.Drawing.Size(237, 28);
            this.TR_Terrain.TabIndex = 45;
            this.TR_Terrain.TickFrequency = 32;
            this.TR_Terrain.Scroll += new System.EventHandler(this.TR_Terrain_Scroll);
            // 
            // TR_BuildingTransparency
            // 
            this.TR_BuildingTransparency.AutoSize = false;
            this.TR_BuildingTransparency.Location = new System.Drawing.Point(3, 381);
            this.TR_BuildingTransparency.Maximum = 255;
            this.TR_BuildingTransparency.Name = "TR_BuildingTransparency";
            this.TR_BuildingTransparency.Size = new System.Drawing.Size(237, 28);
            this.TR_BuildingTransparency.TabIndex = 43;
            this.TR_BuildingTransparency.TickFrequency = 16;
            this.TR_BuildingTransparency.Value = 255;
            this.TR_BuildingTransparency.Scroll += new System.EventHandler(this.TR_BuildingTransparency_Scroll);
            // 
            // L_BuildingTransparency
            // 
            this.L_BuildingTransparency.AutoSize = true;
            this.L_BuildingTransparency.Location = new System.Drawing.Point(8, 365);
            this.L_BuildingTransparency.Name = "L_BuildingTransparency";
            this.L_BuildingTransparency.Size = new System.Drawing.Size(112, 13);
            this.L_BuildingTransparency.TabIndex = 44;
            this.L_BuildingTransparency.Text = "Building Transparency";
            // 
            // PG_TerrainTile
            // 
            this.PG_TerrainTile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PG_TerrainTile.Location = new System.Drawing.Point(3, 3);
            this.PG_TerrainTile.Name = "PG_TerrainTile";
            this.PG_TerrainTile.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.PG_TerrainTile.Size = new System.Drawing.Size(238, 266);
            this.PG_TerrainTile.TabIndex = 41;
            this.PG_TerrainTile.ToolbarVisible = false;
            // 
            // L_FieldItemTransparency
            // 
            this.L_FieldItemTransparency.AutoSize = true;
            this.L_FieldItemTransparency.Location = new System.Drawing.Point(8, 316);
            this.L_FieldItemTransparency.Name = "L_FieldItemTransparency";
            this.L_FieldItemTransparency.Size = new System.Drawing.Size(120, 13);
            this.L_FieldItemTransparency.TabIndex = 42;
            this.L_FieldItemTransparency.Text = "Field Item Transparency";
            // 
            // B_DumpLoadTerrain
            // 
            this.B_DumpLoadTerrain.Location = new System.Drawing.Point(6, 413);
            this.B_DumpLoadTerrain.Name = "B_DumpLoadTerrain";
            this.B_DumpLoadTerrain.Size = new System.Drawing.Size(112, 40);
            this.B_DumpLoadTerrain.TabIndex = 40;
            this.B_DumpLoadTerrain.Text = "Dump/Import";
            this.B_DumpLoadTerrain.UseVisualStyleBackColor = true;
            this.B_DumpLoadTerrain.Click += new System.EventHandler(this.B_DumpLoadTerrain_Click);
            // 
            // B_ModifyAllTerrain
            // 
            this.B_ModifyAllTerrain.Location = new System.Drawing.Point(126, 413);
            this.B_ModifyAllTerrain.Name = "B_ModifyAllTerrain";
            this.B_ModifyAllTerrain.Size = new System.Drawing.Size(112, 40);
            this.B_ModifyAllTerrain.TabIndex = 39;
            this.B_ModifyAllTerrain.Text = "Modify All...";
            this.B_ModifyAllTerrain.UseVisualStyleBackColor = true;
            this.B_ModifyAllTerrain.Click += new System.EventHandler(this.B_ModifyAllTerrain_Click);
            // 
            // Tab_Acres
            // 
            this.Tab_Acres.Controls.Add(this.NUD_MapAcreTemplateField);
            this.Tab_Acres.Controls.Add(this.L_MapAcreTemplateField);
            this.Tab_Acres.Controls.Add(this.L_MapAcreTemplateOutside);
            this.Tab_Acres.Controls.Add(this.NUD_MapAcreTemplateOutside);
            this.Tab_Acres.Controls.Add(this.CB_MapAcreSelect);
            this.Tab_Acres.Controls.Add(this.B_DumpLoadAcres);
            this.Tab_Acres.Controls.Add(this.L_MapAcre);
            this.Tab_Acres.Controls.Add(this.CB_MapAcre);
            this.Tab_Acres.Location = new System.Drawing.Point(4, 22);
            this.Tab_Acres.Name = "Tab_Acres";
            this.Tab_Acres.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Acres.Size = new System.Drawing.Size(244, 458);
            this.Tab_Acres.TabIndex = 3;
            this.Tab_Acres.Text = "Acres";
            this.Tab_Acres.UseVisualStyleBackColor = true;
            // 
            // NUD_MapAcreTemplateField
            // 
            this.NUD_MapAcreTemplateField.Location = new System.Drawing.Point(169, 352);
            this.NUD_MapAcreTemplateField.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_MapAcreTemplateField.Name = "NUD_MapAcreTemplateField";
            this.NUD_MapAcreTemplateField.Size = new System.Drawing.Size(69, 20);
            this.NUD_MapAcreTemplateField.TabIndex = 127;
            // 
            // L_MapAcreTemplateField
            // 
            this.L_MapAcreTemplateField.Location = new System.Drawing.Point(10, 351);
            this.L_MapAcreTemplateField.Name = "L_MapAcreTemplateField";
            this.L_MapAcreTemplateField.Size = new System.Drawing.Size(154, 19);
            this.L_MapAcreTemplateField.TabIndex = 126;
            this.L_MapAcreTemplateField.Text = "Field Acre Template:";
            this.L_MapAcreTemplateField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_MapAcreTemplateOutside
            // 
            this.L_MapAcreTemplateOutside.Location = new System.Drawing.Point(10, 325);
            this.L_MapAcreTemplateOutside.Name = "L_MapAcreTemplateOutside";
            this.L_MapAcreTemplateOutside.Size = new System.Drawing.Size(154, 19);
            this.L_MapAcreTemplateOutside.TabIndex = 125;
            this.L_MapAcreTemplateOutside.Text = "Outside Acre Template:";
            this.L_MapAcreTemplateOutside.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_MapAcreTemplateOutside
            // 
            this.NUD_MapAcreTemplateOutside.Location = new System.Drawing.Point(169, 327);
            this.NUD_MapAcreTemplateOutside.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_MapAcreTemplateOutside.Name = "NUD_MapAcreTemplateOutside";
            this.NUD_MapAcreTemplateOutside.Size = new System.Drawing.Size(69, 20);
            this.NUD_MapAcreTemplateOutside.TabIndex = 124;
            // 
            // CB_MapAcreSelect
            // 
            this.CB_MapAcreSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_MapAcreSelect.FormattingEnabled = true;
            this.CB_MapAcreSelect.Location = new System.Drawing.Point(9, 33);
            this.CB_MapAcreSelect.Name = "CB_MapAcreSelect";
            this.CB_MapAcreSelect.Size = new System.Drawing.Size(213, 21);
            this.CB_MapAcreSelect.TabIndex = 102;
            this.CB_MapAcreSelect.SelectedValueChanged += new System.EventHandler(this.CB_MapAcreSelect_SelectedValueChanged);
            // 
            // B_DumpLoadAcres
            // 
            this.B_DumpLoadAcres.ContextMenuStrip = this.CM_DLMapAcres;
            this.B_DumpLoadAcres.Location = new System.Drawing.Point(6, 413);
            this.B_DumpLoadAcres.Name = "B_DumpLoadAcres";
            this.B_DumpLoadAcres.Size = new System.Drawing.Size(112, 40);
            this.B_DumpLoadAcres.TabIndex = 101;
            this.B_DumpLoadAcres.Text = "Dump/Import";
            this.B_DumpLoadAcres.UseVisualStyleBackColor = true;
            this.B_DumpLoadAcres.Click += new System.EventHandler(this.B_DumpLoadAcres_Click);
            // 
            // CM_DLMapAcres
            // 
            this.CM_DLMapAcres.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_DumpMapAcres,
            this.B_ImportMapAcres});
            this.CM_DLMapAcres.Name = "CM_Picture";
            this.CM_DLMapAcres.ShowImageMargin = false;
            this.CM_DLMapAcres.Size = new System.Drawing.Size(145, 48);
            // 
            // B_DumpMapAcres
            // 
            this.B_DumpMapAcres.Name = "B_DumpMapAcres";
            this.B_DumpMapAcres.Size = new System.Drawing.Size(144, 22);
            this.B_DumpMapAcres.Text = "Dump Map Acres";
            this.B_DumpMapAcres.Click += new System.EventHandler(this.B_DumpMapAcres_Click);
            // 
            // B_ImportMapAcres
            // 
            this.B_ImportMapAcres.Name = "B_ImportMapAcres";
            this.B_ImportMapAcres.Size = new System.Drawing.Size(144, 22);
            this.B_ImportMapAcres.Text = "Import Map Acres";
            this.B_ImportMapAcres.Click += new System.EventHandler(this.B_ImportMapAcres_Click);
            // 
            // L_MapAcre
            // 
            this.L_MapAcre.Location = new System.Drawing.Point(6, 6);
            this.L_MapAcre.Name = "L_MapAcre";
            this.L_MapAcre.Size = new System.Drawing.Size(89, 19);
            this.L_MapAcre.TabIndex = 99;
            this.L_MapAcre.Text = "Acre:";
            this.L_MapAcre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_MapAcre
            // 
            this.CB_MapAcre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_MapAcre.FormattingEnabled = true;
            this.CB_MapAcre.Location = new System.Drawing.Point(101, 6);
            this.CB_MapAcre.Name = "CB_MapAcre";
            this.CB_MapAcre.Size = new System.Drawing.Size(49, 21);
            this.CB_MapAcre.TabIndex = 98;
            this.CB_MapAcre.SelectedIndexChanged += new System.EventHandler(this.CB_MapAcre_SelectedIndexChanged);
            // 
            // CM_DLTerrain
            // 
            this.CM_DLTerrain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_DumpTerrainAcre,
            this.B_DumpTerrainAll,
            this.B_ImportTerrainAcre,
            this.B_ImportTerrainAll});
            this.CM_DLTerrain.Name = "CM_Picture";
            this.CM_DLTerrain.ShowImageMargin = false;
            this.CM_DLTerrain.Size = new System.Drawing.Size(135, 92);
            // 
            // B_DumpTerrainAcre
            // 
            this.B_DumpTerrainAcre.Name = "B_DumpTerrainAcre";
            this.B_DumpTerrainAcre.Size = new System.Drawing.Size(134, 22);
            this.B_DumpTerrainAcre.Text = "Dump Acre";
            this.B_DumpTerrainAcre.Click += new System.EventHandler(this.B_DumpTerrainAcre_Click);
            // 
            // B_DumpTerrainAll
            // 
            this.B_DumpTerrainAll.Name = "B_DumpTerrainAll";
            this.B_DumpTerrainAll.Size = new System.Drawing.Size(134, 22);
            this.B_DumpTerrainAll.Text = "Dump All Acres";
            this.B_DumpTerrainAll.Click += new System.EventHandler(this.B_DumpTerrainAll_Click);
            // 
            // B_ImportTerrainAcre
            // 
            this.B_ImportTerrainAcre.Name = "B_ImportTerrainAcre";
            this.B_ImportTerrainAcre.Size = new System.Drawing.Size(134, 22);
            this.B_ImportTerrainAcre.Text = "Import Acre";
            this.B_ImportTerrainAcre.Click += new System.EventHandler(this.B_ImportTerrainAcre_Click);
            // 
            // B_ImportTerrainAll
            // 
            this.B_ImportTerrainAll.Name = "B_ImportTerrainAll";
            this.B_ImportTerrainAll.Size = new System.Drawing.Size(134, 22);
            this.B_ImportTerrainAll.Text = "Import All Acres";
            this.B_ImportTerrainAll.Click += new System.EventHandler(this.B_ImportTerrainAll_Click);
            // 
            // CM_Terrain
            // 
            this.CM_Terrain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_ZeroElevation,
            this.B_SetAllTerrain,
            this.B_SetAllRoadTiles,
            this.B_ClearPlacedDesigns,
            this.B_ImportPlacedDesigns,
            this.B_ExportPlacedDesigns});
            this.CM_Terrain.Name = "CM_Picture";
            this.CM_Terrain.ShowImageMargin = false;
            this.CM_Terrain.Size = new System.Drawing.Size(225, 136);
            // 
            // B_ZeroElevation
            // 
            this.B_ZeroElevation.Name = "B_ZeroElevation";
            this.B_ZeroElevation.Size = new System.Drawing.Size(224, 22);
            this.B_ZeroElevation.Text = "Zero Elevation";
            this.B_ZeroElevation.Click += new System.EventHandler(this.B_ZeroElevation_Click);
            // 
            // B_SetAllTerrain
            // 
            this.B_SetAllTerrain.Name = "B_SetAllTerrain";
            this.B_SetAllTerrain.Size = new System.Drawing.Size(224, 22);
            this.B_SetAllTerrain.Text = "Set All Tiles using Tile from Editor";
            this.B_SetAllTerrain.Click += new System.EventHandler(this.B_SetAllTerrain_Click);
            // 
            // B_SetAllRoadTiles
            // 
            this.B_SetAllRoadTiles.Name = "B_SetAllRoadTiles";
            this.B_SetAllRoadTiles.Size = new System.Drawing.Size(224, 22);
            this.B_SetAllRoadTiles.Text = "Set All Road Tiles from Editor";
            this.B_SetAllRoadTiles.Click += new System.EventHandler(this.B_SetAllRoadTiles_Click);
            // 
            // B_ClearPlacedDesigns
            // 
            this.B_ClearPlacedDesigns.Name = "B_ClearPlacedDesigns";
            this.B_ClearPlacedDesigns.Size = new System.Drawing.Size(224, 22);
            this.B_ClearPlacedDesigns.Text = "Clear all Placed Designs";
            this.B_ClearPlacedDesigns.Click += new System.EventHandler(this.B_ClearPlacedDesigns_Click);
            // 
            // B_ImportPlacedDesigns
            // 
            this.B_ImportPlacedDesigns.Name = "B_ImportPlacedDesigns";
            this.B_ImportPlacedDesigns.Size = new System.Drawing.Size(224, 22);
            this.B_ImportPlacedDesigns.Text = "Import all Placed Design Choices";
            this.B_ImportPlacedDesigns.Click += new System.EventHandler(this.B_ImportPlacedDesigns_Click);
            // 
            // B_ExportPlacedDesigns
            // 
            this.B_ExportPlacedDesigns.Name = "B_ExportPlacedDesigns";
            this.B_ExportPlacedDesigns.Size = new System.Drawing.Size(224, 22);
            this.B_ExportPlacedDesigns.Text = "Export all Placed Design Choices";
            this.B_ExportPlacedDesigns.Click += new System.EventHandler(this.B_ExportPlacedDesigns_Click);
            // 
            // RB_Item
            // 
            this.RB_Item.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RB_Item.Checked = true;
            this.RB_Item.Location = new System.Drawing.Point(641, 299);
            this.RB_Item.Name = "RB_Item";
            this.RB_Item.Size = new System.Drawing.Size(120, 20);
            this.RB_Item.TabIndex = 43;
            this.RB_Item.TabStop = true;
            this.RB_Item.Text = "Items";
            this.RB_Item.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RB_Item.UseVisualStyleBackColor = true;
            // 
            // RB_Terrain
            // 
            this.RB_Terrain.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RB_Terrain.Location = new System.Drawing.Point(641, 282);
            this.RB_Terrain.Name = "RB_Terrain";
            this.RB_Terrain.Size = new System.Drawing.Size(120, 20);
            this.RB_Terrain.TabIndex = 44;
            this.RB_Terrain.Text = "Terrain";
            this.RB_Terrain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RB_Terrain.UseVisualStyleBackColor = true;
            // 
            // L_TileMode
            // 
            this.L_TileMode.Location = new System.Drawing.Point(641, 259);
            this.L_TileMode.Name = "L_TileMode";
            this.L_TileMode.Size = new System.Drawing.Size(120, 20);
            this.L_TileMode.TabIndex = 45;
            this.L_TileMode.Text = "Tile Editor Mode";
            this.L_TileMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CHK_RedirectExtensionLoad
            // 
            this.CHK_RedirectExtensionLoad.AutoSize = true;
            this.CHK_RedirectExtensionLoad.Checked = true;
            this.CHK_RedirectExtensionLoad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_RedirectExtensionLoad.Location = new System.Drawing.Point(535, 441);
            this.CHK_RedirectExtensionLoad.Name = "CHK_RedirectExtensionLoad";
            this.CHK_RedirectExtensionLoad.Size = new System.Drawing.Size(173, 17);
            this.CHK_RedirectExtensionLoad.TabIndex = 46;
            this.CHK_RedirectExtensionLoad.Text = "View Root instead of Extension";
            this.CHK_RedirectExtensionLoad.UseVisualStyleBackColor = true;
            // 
            // CHK_MoveOnDrag
            // 
            this.CHK_MoveOnDrag.AutoSize = true;
            this.CHK_MoveOnDrag.Checked = true;
            this.CHK_MoveOnDrag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_MoveOnDrag.Location = new System.Drawing.Point(535, 423);
            this.CHK_MoveOnDrag.Name = "CHK_MoveOnDrag";
            this.CHK_MoveOnDrag.Size = new System.Drawing.Size(204, 17);
            this.CHK_MoveOnDrag.TabIndex = 46;
            this.CHK_MoveOnDrag.Text = "Move Field Item Editor on mouse drag";
            this.CHK_MoveOnDrag.UseVisualStyleBackColor = true;
            // 
            // CHK_FieldItemSnap
            // 
            this.CHK_FieldItemSnap.AutoSize = true;
            this.CHK_FieldItemSnap.Checked = true;
            this.CHK_FieldItemSnap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_FieldItemSnap.Location = new System.Drawing.Point(535, 496);
            this.CHK_FieldItemSnap.Name = "CHK_FieldItemSnap";
            this.CHK_FieldItemSnap.Size = new System.Drawing.Size(172, 17);
            this.CHK_FieldItemSnap.TabIndex = 47;
            this.CHK_FieldItemSnap.Text = "Snap Field Items to Grid on Set";
            this.CHK_FieldItemSnap.UseVisualStyleBackColor = true;
            // 
            // B_RemoveBushes
            // 
            this.B_RemoveBushes.Name = "B_RemoveBushes";
            this.B_RemoveBushes.Size = new System.Drawing.Size(155, 22);
            this.B_RemoveBushes.Text = "Bushes";
            this.B_RemoveBushes.Click += new System.EventHandler(this.B_RemoveBushes_Click);
            // 
            // FieldItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 537);
            this.Controls.Add(this.CHK_FieldItemSnap);
            this.Controls.Add(this.CHK_RedirectExtensionLoad);
            this.Controls.Add(this.CHK_MoveOnDrag);
            this.Controls.Add(this.L_TileMode);
            this.Controls.Add(this.RB_Terrain);
            this.Controls.Add(this.RB_Item);
            this.Controls.Add(this.TC_Editor);
            this.Controls.Add(this.CHK_AutoExtension);
            this.Controls.Add(this.CHK_NoOverwrite);
            this.Controls.Add(this.PB_Acre);
            this.Controls.Add(this.L_Layer);
            this.Controls.Add(this.NUD_Layer);
            this.Controls.Add(this.L_Coordinates);
            this.Controls.Add(this.CHK_SnapToAcre);
            this.Controls.Add(this.PB_Map);
            this.Controls.Add(this.B_Down);
            this.Controls.Add(this.B_Right);
            this.Controls.Add(this.B_Left);
            this.Controls.Add(this.B_Up);
            this.Controls.Add(this.L_Acre);
            this.Controls.Add(this.CB_Acre);
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
            ((System.ComponentModel.ISupportInitialize)(this.TR_Transparency)).EndInit();
            this.CM_Remove.ResumeLayout(false);
            this.TC_Editor.ResumeLayout(false);
            this.Tab_Item.ResumeLayout(false);
            this.Tab_Item.PerformLayout();
            this.CM_DLField.ResumeLayout(false);
            this.Tab_Building.ResumeLayout(false);
            this.CM_DLBuilding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Bit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BuildingType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_UniqueID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TypeArg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PlazaX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PlazaY)).EndInit();
            this.Tab_Terrain.ResumeLayout(false);
            this.Tab_Terrain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TR_Terrain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TR_BuildingTransparency)).EndInit();
            this.Tab_Acres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MapAcreTemplateField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MapAcreTemplateOutside)).EndInit();
            this.CM_DLMapAcres.ResumeLayout(false);
            this.CM_DLTerrain.ResumeLayout(false);
            this.CM_Terrain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.ComboBox CB_Acre;
        private System.Windows.Forms.Label L_Acre;
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
        private System.Windows.Forms.Label L_Layer;
        private System.Windows.Forms.ToolTip TT_Hover;
        private System.Windows.Forms.PictureBox PB_Acre;
        private System.Windows.Forms.TrackBar TR_Transparency;
        private System.Windows.Forms.CheckBox CHK_NoOverwrite;
        private System.Windows.Forms.CheckBox CHK_AutoExtension;
        private System.Windows.Forms.Button B_RemoveItemDropDown;
        private System.Windows.Forms.ContextMenuStrip CM_Remove;
        private System.Windows.Forms.ToolStripMenuItem B_RemoveAllWeeds;
        private System.Windows.Forms.ToolStripMenuItem B_RemovePlants;
        private System.Windows.Forms.ToolStripMenuItem B_RemoveObjects;
        private System.Windows.Forms.ToolStripMenuItem B_RemovePlacedItems;
        private System.Windows.Forms.ToolStripMenuItem B_RemoveFences;
        private System.Windows.Forms.ToolStripMenuItem B_FillHoles;
        private System.Windows.Forms.ToolStripMenuItem B_RemoveAll;
        private System.Windows.Forms.Label GB_Remove;
        private System.Windows.Forms.TabControl TC_Editor;
        private System.Windows.Forms.TabPage Tab_Item;
        private System.Windows.Forms.Button B_DumpLoadField;
        private System.Windows.Forms.TabPage Tab_Building;
        private System.Windows.Forms.ContextMenuStrip CM_DLField;
        private System.Windows.Forms.ToolStripMenuItem B_DumpAcre;
        private System.Windows.Forms.ToolStripMenuItem B_DumpAllAcres;
        private System.Windows.Forms.ToolStripMenuItem B_ImportAcre;
        private System.Windows.Forms.ToolStripMenuItem B_ImportAllAcres;
        private System.Windows.Forms.Label L_FieldItemTransparency;
        private System.Windows.Forms.TabPage Tab_Terrain;
        private System.Windows.Forms.ListBox LB_Items;
        private System.Windows.Forms.Button B_Help;
        private System.Windows.Forms.Label L_PlazaX;
        private System.Windows.Forms.NumericUpDown NUD_PlazaX;
        private System.Windows.Forms.Label L_PlazaY;
        private System.Windows.Forms.NumericUpDown NUD_PlazaY;
        private System.Windows.Forms.Button B_DumpLoadTerrain;
        private System.Windows.Forms.Button B_ModifyAllTerrain;
        private System.Windows.Forms.ContextMenuStrip CM_DLTerrain;
        private System.Windows.Forms.ToolStripMenuItem B_DumpTerrainAcre;
        private System.Windows.Forms.ToolStripMenuItem B_DumpTerrainAll;
        private System.Windows.Forms.ToolStripMenuItem B_ImportTerrainAcre;
        private System.Windows.Forms.ToolStripMenuItem B_ImportTerrainAll;
        private System.Windows.Forms.Label L_Bit;
        private System.Windows.Forms.NumericUpDown NUD_Bit;
        private System.Windows.Forms.Label L_BuildingType;
        private System.Windows.Forms.NumericUpDown NUD_BuildingType;
        private System.Windows.Forms.NumericUpDown NUD_UniqueID;
        private System.Windows.Forms.Label L_BuildingX;
        private System.Windows.Forms.Label L_BuildingUniqueID;
        private System.Windows.Forms.NumericUpDown NUD_X;
        private System.Windows.Forms.NumericUpDown NUD_TypeArg;
        private System.Windows.Forms.Label L_BuildingY;
        private System.Windows.Forms.Label L_BuildingStructureArg;
        private System.Windows.Forms.NumericUpDown NUD_Y;
        private System.Windows.Forms.NumericUpDown NUD_Type;
        private System.Windows.Forms.Label L_BuildingRotation;
        private System.Windows.Forms.Label L_BuildingStructureType;
        private System.Windows.Forms.NumericUpDown NUD_Angle;
        private System.Windows.Forms.Button B_DumpLoadBuildings;
        private System.Windows.Forms.ContextMenuStrip CM_DLBuilding;
        private System.Windows.Forms.ToolStripMenuItem B_DumpBuildings;
        private System.Windows.Forms.ToolStripMenuItem B_ImportBuildings;
        private System.Windows.Forms.ContextMenuStrip CM_Terrain;
        private System.Windows.Forms.ToolStripMenuItem B_ZeroElevation;
        private System.Windows.Forms.ToolStripMenuItem B_SetAllTerrain;
        private System.Windows.Forms.PropertyGrid PG_TerrainTile;
        private System.Windows.Forms.RadioButton RB_Item;
        private System.Windows.Forms.RadioButton RB_Terrain;
        private System.Windows.Forms.Label L_TileMode;
        private System.Windows.Forms.TrackBar TR_BuildingTransparency;
        private System.Windows.Forms.Label L_BuildingTransparency;
        private System.Windows.Forms.Label L_TerrainTileLabelTransparency;
        private System.Windows.Forms.TrackBar TR_Terrain;
        private System.Windows.Forms.ToolStripMenuItem B_RemoveBranches;
        private System.Windows.Forms.ToolStripMenuItem B_RemoveShells;
        private System.Windows.Forms.ToolStripMenuItem B_RemoveFlowers;
        private ItemEditor ItemEdit;
        private System.Windows.Forms.TabPage Tab_Acres;
        private System.Windows.Forms.Label L_MapAcre;
        private System.Windows.Forms.ComboBox CB_MapAcre;
        private System.Windows.Forms.Button B_DumpLoadAcres;
        private System.Windows.Forms.ContextMenuStrip CM_DLMapAcres;
        private System.Windows.Forms.ToolStripMenuItem B_DumpMapAcres;
        private System.Windows.Forms.ToolStripMenuItem B_ImportMapAcres;
        private System.Windows.Forms.ComboBox CB_MapAcreSelect;
        private System.Windows.Forms.Label L_MapAcreTemplateOutside;
        private System.Windows.Forms.NumericUpDown NUD_MapAcreTemplateOutside;
        private System.Windows.Forms.NumericUpDown NUD_MapAcreTemplateField;
        private System.Windows.Forms.Label L_MapAcreTemplateField;
        private System.Windows.Forms.ToolStripMenuItem Menu_SavePNGItems;
        private System.Windows.Forms.ToolStripMenuItem Menu_SavePNGTerrain;
        private System.Windows.Forms.CheckBox CHK_RedirectExtensionLoad;
        private System.Windows.Forms.CheckBox CHK_MoveOnDrag;
        private System.Windows.Forms.ToolStripMenuItem B_SetAllRoadTiles;
        private System.Windows.Forms.ToolStripMenuItem B_ClearPlacedDesigns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem B_WaterFlowers;
        private System.Windows.Forms.CheckBox CHK_FieldItemSnap;
        private System.Windows.Forms.ToolStripMenuItem Menu_Spawn;
        private System.Windows.Forms.ToolStripMenuItem B_RemoveAllTrees;
        private System.Windows.Forms.ToolStripMenuItem B_ImportPlacedDesigns;
        private System.Windows.Forms.ToolStripMenuItem B_ExportPlacedDesigns;
        private System.Windows.Forms.ToolStripMenuItem Menu_Batch;
        private System.Windows.Forms.ToolStripMenuItem B_RemoveBushes;
    }
}
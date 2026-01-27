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
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            B_Cancel = new System.Windows.Forms.Button();
            B_Save = new System.Windows.Forms.Button();
            CM_Click = new System.Windows.Forms.ContextMenuStrip(components);
            Menu_View = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Set = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Reset = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Activate = new System.Windows.Forms.ToolStripMenuItem();
            B_Up = new System.Windows.Forms.Button();
            B_Left = new System.Windows.Forms.Button();
            B_Right = new System.Windows.Forms.Button();
            B_Down = new System.Windows.Forms.Button();
            PB_Map = new System.Windows.Forms.PictureBox();
            CM_Picture = new System.Windows.Forms.ContextMenuStrip(components);
            Menu_SavePNG = new System.Windows.Forms.ToolStripMenuItem();
            Menu_SavePNGItems = new System.Windows.Forms.ToolStripMenuItem();
            Menu_SavePNGTerrain = new System.Windows.Forms.ToolStripMenuItem();
            CHK_SnapToAcre = new System.Windows.Forms.CheckBox();
            L_Coordinates = new System.Windows.Forms.Label();
            NUD_Layer = new System.Windows.Forms.NumericUpDown();
            L_Layer = new System.Windows.Forms.Label();
            TT_Hover = new System.Windows.Forms.ToolTip(components);
            PB_Viewport = new System.Windows.Forms.PictureBox();
            TR_Transparency = new System.Windows.Forms.TrackBar();
            CHK_NoOverwrite = new System.Windows.Forms.CheckBox();
            CHK_AutoExtension = new System.Windows.Forms.CheckBox();
            B_RemoveItemDropDown = new System.Windows.Forms.Button();
            CM_Remove = new System.Windows.Forms.ContextMenuStrip(components);
            B_RemoveAllWeeds = new System.Windows.Forms.ToolStripMenuItem();
            B_RemoveAllTrees = new System.Windows.Forms.ToolStripMenuItem();
            B_RemovePlants = new System.Windows.Forms.ToolStripMenuItem();
            B_RemoveObjects = new System.Windows.Forms.ToolStripMenuItem();
            B_RemovePlacedItems = new System.Windows.Forms.ToolStripMenuItem();
            B_RemoveFences = new System.Windows.Forms.ToolStripMenuItem();
            B_RemoveBranches = new System.Windows.Forms.ToolStripMenuItem();
            B_RemoveShells = new System.Windows.Forms.ToolStripMenuItem();
            B_RemoveFlowers = new System.Windows.Forms.ToolStripMenuItem();
            B_RemoveBushes = new System.Windows.Forms.ToolStripMenuItem();
            B_FillHoles = new System.Windows.Forms.ToolStripMenuItem();
            B_RemoveEditor = new System.Windows.Forms.ToolStripMenuItem();
            B_RemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            B_WaterFlowers = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Spawn = new System.Windows.Forms.ToolStripMenuItem();
            Menu_Batch = new System.Windows.Forms.ToolStripMenuItem();
            GB_Remove = new System.Windows.Forms.Label();
            TC_Editor = new System.Windows.Forms.TabControl();
            Tab_Item = new System.Windows.Forms.TabPage();
            ItemEdit = new ItemEditor();
            B_DumpLoadField = new System.Windows.Forms.Button();
            CM_DLField = new System.Windows.Forms.ContextMenuStrip(components);
            B_DumpAcre = new System.Windows.Forms.ToolStripMenuItem();
            B_DumpAllAcres = new System.Windows.Forms.ToolStripMenuItem();
            B_ImportAcre = new System.Windows.Forms.ToolStripMenuItem();
            B_ImportAllAcres = new System.Windows.Forms.ToolStripMenuItem();
            Tab_Building = new System.Windows.Forms.TabPage();
            B_DumpLoadBuildings = new System.Windows.Forms.Button();
            CM_DLBuilding = new System.Windows.Forms.ContextMenuStrip(components);
            B_DumpBuildings = new System.Windows.Forms.ToolStripMenuItem();
            B_ImportBuildings = new System.Windows.Forms.ToolStripMenuItem();
            L_Bit = new System.Windows.Forms.Label();
            NUD_Bit = new System.Windows.Forms.NumericUpDown();
            L_BuildingType = new System.Windows.Forms.Label();
            NUD_BuildingType = new System.Windows.Forms.NumericUpDown();
            NUD_UniqueID = new System.Windows.Forms.NumericUpDown();
            L_BuildingX = new System.Windows.Forms.Label();
            L_BuildingUniqueID = new System.Windows.Forms.Label();
            NUD_X = new System.Windows.Forms.NumericUpDown();
            NUD_TypeArg = new System.Windows.Forms.NumericUpDown();
            L_BuildingY = new System.Windows.Forms.Label();
            L_BuildingStructureArg = new System.Windows.Forms.Label();
            NUD_Y = new System.Windows.Forms.NumericUpDown();
            NUD_Type = new System.Windows.Forms.NumericUpDown();
            L_BuildingRotation = new System.Windows.Forms.Label();
            L_BuildingStructureType = new System.Windows.Forms.Label();
            NUD_Angle = new System.Windows.Forms.NumericUpDown();
            L_PlazaX = new System.Windows.Forms.Label();
            NUD_PlazaX = new System.Windows.Forms.NumericUpDown();
            L_PlazaY = new System.Windows.Forms.Label();
            NUD_PlazaY = new System.Windows.Forms.NumericUpDown();
            B_Help = new System.Windows.Forms.Button();
            LB_Items = new System.Windows.Forms.ListBox();
            Tab_Terrain = new System.Windows.Forms.TabPage();
            B_TerrainBrush = new System.Windows.Forms.Button();
            L_TerrainTileLabelTransparency = new System.Windows.Forms.Label();
            TR_Terrain = new System.Windows.Forms.TrackBar();
            TR_BuildingTransparency = new System.Windows.Forms.TrackBar();
            L_BuildingTransparency = new System.Windows.Forms.Label();
            PG_TerrainTile = new System.Windows.Forms.PropertyGrid();
            L_FieldItemTransparency = new System.Windows.Forms.Label();
            B_DumpLoadTerrain = new System.Windows.Forms.Button();
            B_ModifyAllTerrain = new System.Windows.Forms.Button();
            Tab_Acres = new System.Windows.Forms.TabPage();
            NUD_MapAcreTemplateField = new System.Windows.Forms.NumericUpDown();
            L_MapAcreTemplateField = new System.Windows.Forms.Label();
            L_MapAcreTemplateOutside = new System.Windows.Forms.Label();
            NUD_MapAcreTemplateOutside = new System.Windows.Forms.NumericUpDown();
            CB_MapAcreSelect = new System.Windows.Forms.ComboBox();
            B_DumpLoadAcres = new System.Windows.Forms.Button();
            CM_DLMapAcres = new System.Windows.Forms.ContextMenuStrip(components);
            B_DumpMapAcres = new System.Windows.Forms.ToolStripMenuItem();
            B_ImportMapAcres = new System.Windows.Forms.ToolStripMenuItem();
            L_MapAcre = new System.Windows.Forms.Label();
            CB_MapAcre = new System.Windows.Forms.ComboBox();
            CM_DLTerrain = new System.Windows.Forms.ContextMenuStrip(components);
            B_DumpTerrainAcre = new System.Windows.Forms.ToolStripMenuItem();
            B_DumpTerrainAll = new System.Windows.Forms.ToolStripMenuItem();
            B_ImportTerrainAcre = new System.Windows.Forms.ToolStripMenuItem();
            B_ImportTerrainAll = new System.Windows.Forms.ToolStripMenuItem();
            CM_Terrain = new System.Windows.Forms.ContextMenuStrip(components);
            B_ZeroElevation = new System.Windows.Forms.ToolStripMenuItem();
            B_SetAllTerrain = new System.Windows.Forms.ToolStripMenuItem();
            B_SetAllRoadTiles = new System.Windows.Forms.ToolStripMenuItem();
            B_ClearPlacedDesigns = new System.Windows.Forms.ToolStripMenuItem();
            B_ImportPlacedDesigns = new System.Windows.Forms.ToolStripMenuItem();
            B_ExportPlacedDesigns = new System.Windows.Forms.ToolStripMenuItem();
            RB_Item = new System.Windows.Forms.RadioButton();
            RB_Terrain = new System.Windows.Forms.RadioButton();
            L_TileMode = new System.Windows.Forms.Label();
            CHK_RedirectExtensionLoad = new System.Windows.Forms.CheckBox();
            CHK_MoveOnDrag = new System.Windows.Forms.CheckBox();
            CHK_FieldItemSnap = new System.Windows.Forms.CheckBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            L_Acre = new System.Windows.Forms.Label();
            CB_Acre = new System.Windows.Forms.ComboBox();
            B_DumpAllAcresFlag = new System.Windows.Forms.ToolStripMenuItem();
            B_ImportAllAcresFlag = new System.Windows.Forms.ToolStripMenuItem();
            CM_Click.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_Map).BeginInit();
            CM_Picture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_Layer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Viewport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TR_Transparency).BeginInit();
            CM_Remove.SuspendLayout();
            TC_Editor.SuspendLayout();
            Tab_Item.SuspendLayout();
            CM_DLField.SuspendLayout();
            Tab_Building.SuspendLayout();
            CM_DLBuilding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_Bit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_BuildingType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_UniqueID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_X).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_TypeArg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Y).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Type).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Angle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_PlazaX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_PlazaY).BeginInit();
            Tab_Terrain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TR_Terrain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TR_BuildingTransparency).BeginInit();
            Tab_Acres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_MapAcreTemplateField).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_MapAcreTemplateOutside).BeginInit();
            CM_DLMapAcres.SuspendLayout();
            CM_DLTerrain.SuspendLayout();
            CM_Terrain.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // B_Cancel
            // 
            B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Cancel.Location = new System.Drawing.Point(950, 656);
            B_Cancel.Margin = new System.Windows.Forms.Padding(4);
            B_Cancel.Name = "B_Cancel";
            B_Cancel.Size = new System.Drawing.Size(84, 30);
            B_Cancel.TabIndex = 7;
            B_Cancel.Text = "Cancel";
            B_Cancel.UseVisualStyleBackColor = true;
            B_Cancel.Click += B_Cancel_Click;
            // 
            // B_Save
            // 
            B_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Save.Location = new System.Drawing.Point(1041, 656);
            B_Save.Margin = new System.Windows.Forms.Padding(4);
            B_Save.Name = "B_Save";
            B_Save.Size = new System.Drawing.Size(84, 30);
            B_Save.TabIndex = 6;
            B_Save.Text = "Save";
            B_Save.UseVisualStyleBackColor = true;
            B_Save.Click += B_Save_Click;
            // 
            // CM_Click
            // 
            CM_Click.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { Menu_View, Menu_Set, Menu_Reset, Menu_Activate });
            CM_Click.Name = "CM_Click";
            CM_Click.Size = new System.Drawing.Size(122, 92);
            CM_Click.Opening += CM_Click_Opening;
            // 
            // Menu_View
            // 
            Menu_View.Name = "Menu_View";
            Menu_View.Size = new System.Drawing.Size(121, 22);
            Menu_View.Text = "View";
            Menu_View.Click += Menu_View_Click;
            // 
            // Menu_Set
            // 
            Menu_Set.Name = "Menu_Set";
            Menu_Set.Size = new System.Drawing.Size(121, 22);
            Menu_Set.Text = "Set";
            Menu_Set.Click += Menu_Set_Click;
            // 
            // Menu_Reset
            // 
            Menu_Reset.Name = "Menu_Reset";
            Menu_Reset.Size = new System.Drawing.Size(121, 22);
            Menu_Reset.Text = "Reset";
            Menu_Reset.Click += Menu_Reset_Click;
            // 
            // Menu_Activate
            // 
            Menu_Activate.Name = "Menu_Activate";
            Menu_Activate.Size = new System.Drawing.Size(121, 22);
            Menu_Activate.Text = "Activate";
            Menu_Activate.Click += Menu_Activate_Click;
            // 
            // B_Up
            // 
            B_Up.Location = new System.Drawing.Point(575, 307);
            B_Up.Margin = new System.Windows.Forms.Padding(4);
            B_Up.Name = "B_Up";
            B_Up.Size = new System.Drawing.Size(40, 40);
            B_Up.TabIndex = 18;
            B_Up.Text = "↑";
            B_Up.UseVisualStyleBackColor = true;
            B_Up.Click += B_Up_Click;
            // 
            // B_Left
            // 
            B_Left.Location = new System.Drawing.Point(536, 347);
            B_Left.Margin = new System.Windows.Forms.Padding(4);
            B_Left.Name = "B_Left";
            B_Left.Size = new System.Drawing.Size(40, 40);
            B_Left.TabIndex = 19;
            B_Left.Text = "←";
            B_Left.UseVisualStyleBackColor = true;
            B_Left.Click += B_Left_Click;
            // 
            // B_Right
            // 
            B_Right.Location = new System.Drawing.Point(614, 347);
            B_Right.Margin = new System.Windows.Forms.Padding(4);
            B_Right.Name = "B_Right";
            B_Right.Size = new System.Drawing.Size(40, 40);
            B_Right.TabIndex = 20;
            B_Right.Text = "→";
            B_Right.UseVisualStyleBackColor = true;
            B_Right.Click += B_Right_Click;
            // 
            // B_Down
            // 
            B_Down.Location = new System.Drawing.Point(575, 386);
            B_Down.Margin = new System.Windows.Forms.Padding(4);
            B_Down.Name = "B_Down";
            B_Down.Size = new System.Drawing.Size(40, 40);
            B_Down.TabIndex = 22;
            B_Down.Text = "↓";
            B_Down.UseVisualStyleBackColor = true;
            B_Down.Click += B_Down_Click;
            // 
            // PB_Map
            // 
            PB_Map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PB_Map.ContextMenuStrip = CM_Picture;
            PB_Map.Location = new System.Drawing.Point(536, 43);
            PB_Map.Margin = new System.Windows.Forms.Padding(4);
            PB_Map.Name = "PB_Map";
            PB_Map.Size = new System.Drawing.Size(288, 256);
            PB_Map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            PB_Map.TabIndex = 23;
            PB_Map.TabStop = false;
            PB_Map.MouseDown += PB_Map_MouseDown;
            PB_Map.MouseMove += PB_Map_MouseMove;
            // 
            // CM_Picture
            // 
            CM_Picture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { Menu_SavePNG, Menu_SavePNGItems, Menu_SavePNGTerrain });
            CM_Picture.Name = "CM_Picture";
            CM_Picture.Size = new System.Drawing.Size(162, 70);
            CM_Picture.Closing += CM_Picture_Closing;
            // 
            // Menu_SavePNG
            // 
            Menu_SavePNG.Name = "Menu_SavePNG";
            Menu_SavePNG.Size = new System.Drawing.Size(161, 22);
            Menu_SavePNG.Text = "Save .png";
            Menu_SavePNG.Click += Menu_SavePNG_Click;
            // 
            // Menu_SavePNGItems
            // 
            Menu_SavePNGItems.Checked = true;
            Menu_SavePNGItems.CheckOnClick = true;
            Menu_SavePNGItems.CheckState = System.Windows.Forms.CheckState.Checked;
            Menu_SavePNGItems.Name = "Menu_SavePNGItems";
            Menu_SavePNGItems.Size = new System.Drawing.Size(161, 22);
            Menu_SavePNGItems.Text = "Include Items";
            // 
            // Menu_SavePNGTerrain
            // 
            Menu_SavePNGTerrain.Checked = true;
            Menu_SavePNGTerrain.CheckOnClick = true;
            Menu_SavePNGTerrain.CheckState = System.Windows.Forms.CheckState.Checked;
            Menu_SavePNGTerrain.Name = "Menu_SavePNGTerrain";
            Menu_SavePNGTerrain.Size = new System.Drawing.Size(161, 22);
            Menu_SavePNGTerrain.Text = "Include Terrain";
            // 
            // CHK_SnapToAcre
            // 
            CHK_SnapToAcre.AutoSize = true;
            CHK_SnapToAcre.Location = new System.Drawing.Point(536, 13);
            CHK_SnapToAcre.Margin = new System.Windows.Forms.Padding(4);
            CHK_SnapToAcre.Name = "CHK_SnapToAcre";
            CHK_SnapToAcre.Size = new System.Drawing.Size(198, 21);
            CHK_SnapToAcre.TabIndex = 24;
            CHK_SnapToAcre.Text = "Snap to nearest Acre on Click";
            CHK_SnapToAcre.UseVisualStyleBackColor = true;
            // 
            // L_Coordinates
            // 
            L_Coordinates.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            L_Coordinates.Location = new System.Drawing.Point(622, 303);
            L_Coordinates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Coordinates.Name = "L_Coordinates";
            L_Coordinates.Size = new System.Drawing.Size(202, 20);
            L_Coordinates.TabIndex = 25;
            L_Coordinates.Text = "(000,000) = (0x00,0x00)";
            L_Coordinates.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NUD_Layer
            // 
            NUD_Layer.Location = new System.Drawing.Point(767, 409);
            NUD_Layer.Margin = new System.Windows.Forms.Padding(4);
            NUD_Layer.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            NUD_Layer.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_Layer.Name = "NUD_Layer";
            NUD_Layer.Size = new System.Drawing.Size(57, 25);
            NUD_Layer.TabIndex = 26;
            NUD_Layer.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_Layer.ValueChanged += NUD_Layer_ValueChanged;
            // 
            // L_Layer
            // 
            L_Layer.Location = new System.Drawing.Point(658, 409);
            L_Layer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Layer.Name = "L_Layer";
            L_Layer.Size = new System.Drawing.Size(102, 25);
            L_Layer.TabIndex = 27;
            L_Layer.Text = "Item Layer:";
            L_Layer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TT_Hover
            // 
            TT_Hover.AutomaticDelay = 100;
            // 
            // PB_Viewport
            // 
            PB_Viewport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PB_Viewport.ContextMenuStrip = CM_Click;
            PB_Viewport.Location = new System.Drawing.Point(14, 16);
            PB_Viewport.Margin = new System.Windows.Forms.Padding(4);
            PB_Viewport.Name = "PB_Viewport";
            PB_Viewport.Size = new System.Drawing.Size(514, 514);
            PB_Viewport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            PB_Viewport.TabIndex = 28;
            PB_Viewport.TabStop = false;
            PB_Viewport.MouseClick += ViewportMouseClick;
            PB_Viewport.MouseDown += ViewportMouseDown;
            PB_Viewport.MouseMove += ViewportMouseMove;
            // 
            // TR_Transparency
            // 
            TR_Transparency.AutoSize = false;
            TR_Transparency.Location = new System.Drawing.Point(4, 434);
            TR_Transparency.Margin = new System.Windows.Forms.Padding(4);
            TR_Transparency.Maximum = 100;
            TR_Transparency.Name = "TR_Transparency";
            TR_Transparency.Size = new System.Drawing.Size(276, 37);
            TR_Transparency.TabIndex = 36;
            TR_Transparency.TickFrequency = 10;
            TR_Transparency.Value = 90;
            TR_Transparency.Scroll += TR_Transparency_Scroll;
            // 
            // CHK_NoOverwrite
            // 
            CHK_NoOverwrite.AutoSize = true;
            CHK_NoOverwrite.Checked = true;
            CHK_NoOverwrite.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_NoOverwrite.Location = new System.Drawing.Point(0, 21);
            CHK_NoOverwrite.Margin = new System.Windows.Forms.Padding(0);
            CHK_NoOverwrite.Name = "CHK_NoOverwrite";
            CHK_NoOverwrite.Size = new System.Drawing.Size(234, 21);
            CHK_NoOverwrite.TabIndex = 37;
            CHK_NoOverwrite.Text = "Prevent Writing Occupied Item Tiles";
            CHK_NoOverwrite.UseVisualStyleBackColor = true;
            // 
            // CHK_AutoExtension
            // 
            CHK_AutoExtension.AutoSize = true;
            CHK_AutoExtension.Checked = true;
            CHK_AutoExtension.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_AutoExtension.Location = new System.Drawing.Point(0, 42);
            CHK_AutoExtension.Margin = new System.Windows.Forms.Padding(0);
            CHK_AutoExtension.Name = "CHK_AutoExtension";
            CHK_AutoExtension.Size = new System.Drawing.Size(243, 21);
            CHK_AutoExtension.TabIndex = 38;
            CHK_AutoExtension.Text = "Handle Item Extensions Automatically";
            CHK_AutoExtension.UseVisualStyleBackColor = true;
            // 
            // B_RemoveItemDropDown
            // 
            B_RemoveItemDropDown.ContextMenuStrip = CM_Remove;
            B_RemoveItemDropDown.Location = new System.Drawing.Point(147, 540);
            B_RemoveItemDropDown.Margin = new System.Windows.Forms.Padding(4);
            B_RemoveItemDropDown.Name = "B_RemoveItemDropDown";
            B_RemoveItemDropDown.Size = new System.Drawing.Size(131, 52);
            B_RemoveItemDropDown.TabIndex = 37;
            B_RemoveItemDropDown.Text = "Remove Items...";
            B_RemoveItemDropDown.UseVisualStyleBackColor = true;
            B_RemoveItemDropDown.Click += B_RemoveItemDropDown_Click;
            // 
            // CM_Remove
            // 
            CM_Remove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { B_RemoveAllWeeds, B_RemoveAllTrees, B_RemovePlants, B_RemoveObjects, B_RemovePlacedItems, B_RemoveFences, B_RemoveBranches, B_RemoveShells, B_RemoveFlowers, B_RemoveBushes, B_FillHoles, B_RemoveEditor, B_RemoveAll, toolStripSeparator1, B_WaterFlowers, Menu_Spawn, Menu_Batch });
            CM_Remove.Name = "CM_Picture";
            CM_Remove.ShowImageMargin = false;
            CM_Remove.Size = new System.Drawing.Size(134, 362);
            // 
            // B_RemoveAllWeeds
            // 
            B_RemoveAllWeeds.Name = "B_RemoveAllWeeds";
            B_RemoveAllWeeds.Size = new System.Drawing.Size(133, 22);
            B_RemoveAllWeeds.Text = "Weeds";
            B_RemoveAllWeeds.Click += B_RemoveAllWeeds_Click;
            // 
            // B_RemoveAllTrees
            // 
            B_RemoveAllTrees.Name = "B_RemoveAllTrees";
            B_RemoveAllTrees.Size = new System.Drawing.Size(133, 22);
            B_RemoveAllTrees.Text = "Trees";
            B_RemoveAllTrees.Click += B_RemoveAllTrees_Click;
            // 
            // B_RemovePlants
            // 
            B_RemovePlants.Name = "B_RemovePlants";
            B_RemovePlants.Size = new System.Drawing.Size(133, 22);
            B_RemovePlants.Text = "Plants";
            B_RemovePlants.Click += B_RemovePlants_Click;
            // 
            // B_RemoveObjects
            // 
            B_RemoveObjects.Name = "B_RemoveObjects";
            B_RemoveObjects.Size = new System.Drawing.Size(133, 22);
            B_RemoveObjects.Text = "Objects";
            B_RemoveObjects.Click += B_RemoveObjects_Click;
            // 
            // B_RemovePlacedItems
            // 
            B_RemovePlacedItems.Name = "B_RemovePlacedItems";
            B_RemovePlacedItems.Size = new System.Drawing.Size(133, 22);
            B_RemovePlacedItems.Text = "Placed Items";
            B_RemovePlacedItems.Click += B_RemovePlacedItems_Click;
            // 
            // B_RemoveFences
            // 
            B_RemoveFences.Name = "B_RemoveFences";
            B_RemoveFences.Size = new System.Drawing.Size(133, 22);
            B_RemoveFences.Text = "Fences";
            B_RemoveFences.Click += B_RemoveFences_Click;
            // 
            // B_RemoveBranches
            // 
            B_RemoveBranches.Name = "B_RemoveBranches";
            B_RemoveBranches.Size = new System.Drawing.Size(133, 22);
            B_RemoveBranches.Text = "Branches";
            B_RemoveBranches.Click += B_RemoveBranches_Click;
            // 
            // B_RemoveShells
            // 
            B_RemoveShells.Name = "B_RemoveShells";
            B_RemoveShells.Size = new System.Drawing.Size(133, 22);
            B_RemoveShells.Text = "Shells";
            B_RemoveShells.Click += B_RemoveShells_Click;
            // 
            // B_RemoveFlowers
            // 
            B_RemoveFlowers.Name = "B_RemoveFlowers";
            B_RemoveFlowers.Size = new System.Drawing.Size(133, 22);
            B_RemoveFlowers.Text = "Flowers";
            B_RemoveFlowers.Click += B_RemoveFlowers_Click;
            // 
            // B_RemoveBushes
            // 
            B_RemoveBushes.Name = "B_RemoveBushes";
            B_RemoveBushes.Size = new System.Drawing.Size(133, 22);
            B_RemoveBushes.Text = "Bushes";
            B_RemoveBushes.Click += B_RemoveBushes_Click;
            // 
            // B_FillHoles
            // 
            B_FillHoles.Name = "B_FillHoles";
            B_FillHoles.Size = new System.Drawing.Size(133, 22);
            B_FillHoles.Text = "Holes";
            B_FillHoles.Click += B_FillHoles_Click;
            // 
            // B_RemoveEditor
            // 
            B_RemoveEditor.Name = "B_RemoveEditor";
            B_RemoveEditor.Size = new System.Drawing.Size(133, 22);
            B_RemoveEditor.Text = "Editor Item";
            B_RemoveEditor.Click += B_RemoveEditor_Click;
            // 
            // B_RemoveAll
            // 
            B_RemoveAll.Name = "B_RemoveAll";
            B_RemoveAll.Size = new System.Drawing.Size(133, 22);
            B_RemoveAll.Text = "All";
            B_RemoveAll.Click += B_RemoveAll_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // B_WaterFlowers
            // 
            B_WaterFlowers.Name = "B_WaterFlowers";
            B_WaterFlowers.Size = new System.Drawing.Size(133, 22);
            B_WaterFlowers.Text = "Water Flowers";
            B_WaterFlowers.Click += B_WaterFlowers_Click;
            // 
            // Menu_Spawn
            // 
            Menu_Spawn.Name = "Menu_Spawn";
            Menu_Spawn.Size = new System.Drawing.Size(133, 22);
            Menu_Spawn.Text = "Spawn...";
            Menu_Spawn.Click += Menu_Spawn_Click;
            // 
            // Menu_Batch
            // 
            Menu_Batch.Name = "Menu_Batch";
            Menu_Batch.Size = new System.Drawing.Size(133, 22);
            Menu_Batch.Text = "Batch Editor";
            Menu_Batch.Click += Menu_Bulk_Click;
            // 
            // GB_Remove
            // 
            GB_Remove.AutoSize = true;
            GB_Remove.Location = new System.Drawing.Point(8, 499);
            GB_Remove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            GB_Remove.Name = "GB_Remove";
            GB_Remove.Size = new System.Drawing.Size(223, 17);
            GB_Remove.TabIndex = 39;
            GB_Remove.Text = "Remove from View (Hold Shift=Map)";
            // 
            // TC_Editor
            // 
            TC_Editor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            TC_Editor.Controls.Add(Tab_Item);
            TC_Editor.Controls.Add(Tab_Building);
            TC_Editor.Controls.Add(Tab_Terrain);
            TC_Editor.Controls.Add(Tab_Acres);
            TC_Editor.Location = new System.Drawing.Point(835, 16);
            TC_Editor.Margin = new System.Windows.Forms.Padding(4);
            TC_Editor.Name = "TC_Editor";
            TC_Editor.SelectedIndex = 0;
            TC_Editor.Size = new System.Drawing.Size(294, 633);
            TC_Editor.TabIndex = 40;
            // 
            // Tab_Item
            // 
            Tab_Item.Controls.Add(ItemEdit);
            Tab_Item.Controls.Add(B_DumpLoadField);
            Tab_Item.Controls.Add(B_RemoveItemDropDown);
            Tab_Item.Controls.Add(GB_Remove);
            Tab_Item.Location = new System.Drawing.Point(4, 26);
            Tab_Item.Margin = new System.Windows.Forms.Padding(4);
            Tab_Item.Name = "Tab_Item";
            Tab_Item.Padding = new System.Windows.Forms.Padding(4);
            Tab_Item.Size = new System.Drawing.Size(286, 603);
            Tab_Item.TabIndex = 0;
            Tab_Item.Text = "Items";
            Tab_Item.UseVisualStyleBackColor = true;
            // 
            // ItemEdit
            // 
            ItemEdit.Dock = System.Windows.Forms.DockStyle.Top;
            ItemEdit.Location = new System.Drawing.Point(4, 4);
            ItemEdit.Margin = new System.Windows.Forms.Padding(5);
            ItemEdit.Name = "ItemEdit";
            ItemEdit.Size = new System.Drawing.Size(278, 437);
            ItemEdit.TabIndex = 40;
            // 
            // B_DumpLoadField
            // 
            B_DumpLoadField.ContextMenuStrip = CM_DLField;
            B_DumpLoadField.Location = new System.Drawing.Point(7, 540);
            B_DumpLoadField.Margin = new System.Windows.Forms.Padding(4);
            B_DumpLoadField.Name = "B_DumpLoadField";
            B_DumpLoadField.Size = new System.Drawing.Size(131, 52);
            B_DumpLoadField.TabIndex = 38;
            B_DumpLoadField.Text = "Dump/Import";
            B_DumpLoadField.UseVisualStyleBackColor = true;
            B_DumpLoadField.Click += B_DumpLoadField_Click;
            // 
            // CM_DLField
            // 
            CM_DLField.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { B_DumpAcre, B_DumpAllAcres, B_ImportAcre, B_ImportAllAcres, B_DumpAllAcresFlag, B_ImportAllAcresFlag });
            CM_DLField.Name = "CM_Picture";
            CM_DLField.ShowImageMargin = false;
            CM_DLField.Size = new System.Drawing.Size(156, 158);
            // 
            // B_DumpAcre
            // 
            B_DumpAcre.Name = "B_DumpAcre";
            B_DumpAcre.Size = new System.Drawing.Size(155, 22);
            B_DumpAcre.Text = "Dump Acre";
            B_DumpAcre.Click += B_DumpAcreItem_Click;
            // 
            // B_DumpAllAcres
            // 
            B_DumpAllAcres.Name = "B_DumpAllAcres";
            B_DumpAllAcres.Size = new System.Drawing.Size(155, 22);
            B_DumpAllAcres.Text = "Dump All Acres";
            B_DumpAllAcres.Click += B_DumpAllAcres_Click;
            // 
            // B_ImportAcre
            // 
            B_ImportAcre.Name = "B_ImportAcre";
            B_ImportAcre.Size = new System.Drawing.Size(155, 22);
            B_ImportAcre.Text = "Import Acre";
            B_ImportAcre.Click += B_ImportAcreItem_Click;
            // 
            // B_ImportAllAcres
            // 
            B_ImportAllAcres.Name = "B_ImportAllAcres";
            B_ImportAllAcres.Size = new System.Drawing.Size(155, 22);
            B_ImportAllAcres.Text = "Import All Acres";
            B_ImportAllAcres.Click += B_ImportAllAcres_Click;
            // 
            // Tab_Building
            // 
            Tab_Building.Controls.Add(B_DumpLoadBuildings);
            Tab_Building.Controls.Add(L_Bit);
            Tab_Building.Controls.Add(NUD_Bit);
            Tab_Building.Controls.Add(L_BuildingType);
            Tab_Building.Controls.Add(NUD_BuildingType);
            Tab_Building.Controls.Add(NUD_UniqueID);
            Tab_Building.Controls.Add(L_BuildingX);
            Tab_Building.Controls.Add(L_BuildingUniqueID);
            Tab_Building.Controls.Add(NUD_X);
            Tab_Building.Controls.Add(NUD_TypeArg);
            Tab_Building.Controls.Add(L_BuildingY);
            Tab_Building.Controls.Add(L_BuildingStructureArg);
            Tab_Building.Controls.Add(NUD_Y);
            Tab_Building.Controls.Add(NUD_Type);
            Tab_Building.Controls.Add(L_BuildingRotation);
            Tab_Building.Controls.Add(L_BuildingStructureType);
            Tab_Building.Controls.Add(NUD_Angle);
            Tab_Building.Controls.Add(L_PlazaX);
            Tab_Building.Controls.Add(NUD_PlazaX);
            Tab_Building.Controls.Add(L_PlazaY);
            Tab_Building.Controls.Add(NUD_PlazaY);
            Tab_Building.Controls.Add(B_Help);
            Tab_Building.Controls.Add(LB_Items);
            Tab_Building.Location = new System.Drawing.Point(4, 26);
            Tab_Building.Margin = new System.Windows.Forms.Padding(4);
            Tab_Building.Name = "Tab_Building";
            Tab_Building.Padding = new System.Windows.Forms.Padding(4);
            Tab_Building.Size = new System.Drawing.Size(286, 603);
            Tab_Building.TabIndex = 1;
            Tab_Building.Text = "Buildings";
            Tab_Building.UseVisualStyleBackColor = true;
            // 
            // B_DumpLoadBuildings
            // 
            B_DumpLoadBuildings.ContextMenuStrip = CM_DLBuilding;
            B_DumpLoadBuildings.Location = new System.Drawing.Point(7, 540);
            B_DumpLoadBuildings.Margin = new System.Windows.Forms.Padding(4);
            B_DumpLoadBuildings.Name = "B_DumpLoadBuildings";
            B_DumpLoadBuildings.Size = new System.Drawing.Size(131, 52);
            B_DumpLoadBuildings.TabIndex = 132;
            B_DumpLoadBuildings.Text = "Dump/Import";
            B_DumpLoadBuildings.UseVisualStyleBackColor = true;
            B_DumpLoadBuildings.Click += B_DumpLoadBuildings_Click;
            // 
            // CM_DLBuilding
            // 
            CM_DLBuilding.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { B_DumpBuildings, B_ImportBuildings });
            CM_DLBuilding.Name = "CM_Picture";
            CM_DLBuilding.ShowImageMargin = false;
            CM_DLBuilding.Size = new System.Drawing.Size(147, 48);
            // 
            // B_DumpBuildings
            // 
            B_DumpBuildings.Name = "B_DumpBuildings";
            B_DumpBuildings.Size = new System.Drawing.Size(146, 22);
            B_DumpBuildings.Text = "Dump Buildings";
            B_DumpBuildings.Click += B_DumpBuildings_Click;
            // 
            // B_ImportBuildings
            // 
            B_ImportBuildings.Name = "B_ImportBuildings";
            B_ImportBuildings.Size = new System.Drawing.Size(146, 22);
            B_ImportBuildings.Text = "Import Buildings";
            B_ImportBuildings.Click += B_ImportBuildings_Click;
            // 
            // L_Bit
            // 
            L_Bit.Location = new System.Drawing.Point(42, 396);
            L_Bit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Bit.Name = "L_Bit";
            L_Bit.Size = new System.Drawing.Size(117, 24);
            L_Bit.TabIndex = 130;
            L_Bit.Text = "Bit:";
            L_Bit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Bit
            // 
            NUD_Bit.Location = new System.Drawing.Point(166, 398);
            NUD_Bit.Margin = new System.Windows.Forms.Padding(4);
            NUD_Bit.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            NUD_Bit.Minimum = new decimal(new int[] { 200, 0, 0, int.MinValue });
            NUD_Bit.Name = "NUD_Bit";
            NUD_Bit.Size = new System.Drawing.Size(80, 25);
            NUD_Bit.TabIndex = 131;
            NUD_Bit.ValueChanged += NUD_BuildingType_ValueChanged;
            // 
            // L_BuildingType
            // 
            L_BuildingType.Location = new System.Drawing.Point(42, 309);
            L_BuildingType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_BuildingType.Name = "L_BuildingType";
            L_BuildingType.Size = new System.Drawing.Size(117, 24);
            L_BuildingType.TabIndex = 116;
            L_BuildingType.Text = "Building Type:";
            L_BuildingType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_BuildingType
            // 
            NUD_BuildingType.Location = new System.Drawing.Point(166, 310);
            NUD_BuildingType.Margin = new System.Windows.Forms.Padding(4);
            NUD_BuildingType.Name = "NUD_BuildingType";
            NUD_BuildingType.Size = new System.Drawing.Size(80, 25);
            NUD_BuildingType.TabIndex = 117;
            NUD_BuildingType.ValueChanged += NUD_BuildingType_ValueChanged;
            // 
            // NUD_UniqueID
            // 
            NUD_UniqueID.Location = new System.Drawing.Point(166, 485);
            NUD_UniqueID.Margin = new System.Windows.Forms.Padding(4);
            NUD_UniqueID.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NUD_UniqueID.Name = "NUD_UniqueID";
            NUD_UniqueID.Size = new System.Drawing.Size(80, 25);
            NUD_UniqueID.TabIndex = 129;
            NUD_UniqueID.ValueChanged += NUD_BuildingType_ValueChanged;
            // 
            // L_BuildingX
            // 
            L_BuildingX.Location = new System.Drawing.Point(76, 336);
            L_BuildingX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_BuildingX.Name = "L_BuildingX";
            L_BuildingX.Size = new System.Drawing.Size(23, 24);
            L_BuildingX.TabIndex = 118;
            L_BuildingX.Text = "X:";
            L_BuildingX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_BuildingUniqueID
            // 
            L_BuildingUniqueID.Location = new System.Drawing.Point(42, 484);
            L_BuildingUniqueID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_BuildingUniqueID.Name = "L_BuildingUniqueID";
            L_BuildingUniqueID.Size = new System.Drawing.Size(117, 24);
            L_BuildingUniqueID.TabIndex = 128;
            L_BuildingUniqueID.Text = "UniqueID:";
            L_BuildingUniqueID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_X
            // 
            NUD_X.Location = new System.Drawing.Point(106, 337);
            NUD_X.Margin = new System.Windows.Forms.Padding(4);
            NUD_X.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            NUD_X.Name = "NUD_X";
            NUD_X.Size = new System.Drawing.Size(52, 25);
            NUD_X.TabIndex = 119;
            NUD_X.ValueChanged += NUD_BuildingType_ValueChanged;
            // 
            // NUD_TypeArg
            // 
            NUD_TypeArg.Location = new System.Drawing.Point(166, 458);
            NUD_TypeArg.Margin = new System.Windows.Forms.Padding(4);
            NUD_TypeArg.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NUD_TypeArg.Name = "NUD_TypeArg";
            NUD_TypeArg.Size = new System.Drawing.Size(80, 25);
            NUD_TypeArg.TabIndex = 127;
            NUD_TypeArg.ValueChanged += NUD_BuildingType_ValueChanged;
            // 
            // L_BuildingY
            // 
            L_BuildingY.Location = new System.Drawing.Point(160, 336);
            L_BuildingY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_BuildingY.Name = "L_BuildingY";
            L_BuildingY.Size = new System.Drawing.Size(27, 24);
            L_BuildingY.TabIndex = 120;
            L_BuildingY.Text = "Y:";
            L_BuildingY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_BuildingStructureArg
            // 
            L_BuildingStructureArg.Location = new System.Drawing.Point(42, 456);
            L_BuildingStructureArg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_BuildingStructureArg.Name = "L_BuildingStructureArg";
            L_BuildingStructureArg.Size = new System.Drawing.Size(117, 24);
            L_BuildingStructureArg.TabIndex = 126;
            L_BuildingStructureArg.Text = "TypeArg:";
            L_BuildingStructureArg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Y
            // 
            NUD_Y.Location = new System.Drawing.Point(194, 337);
            NUD_Y.Margin = new System.Windows.Forms.Padding(4);
            NUD_Y.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            NUD_Y.Name = "NUD_Y";
            NUD_Y.Size = new System.Drawing.Size(52, 25);
            NUD_Y.TabIndex = 121;
            NUD_Y.ValueChanged += NUD_BuildingType_ValueChanged;
            // 
            // NUD_Type
            // 
            NUD_Type.Location = new System.Drawing.Point(166, 430);
            NUD_Type.Margin = new System.Windows.Forms.Padding(4);
            NUD_Type.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NUD_Type.Name = "NUD_Type";
            NUD_Type.Size = new System.Drawing.Size(80, 25);
            NUD_Type.TabIndex = 125;
            NUD_Type.ValueChanged += NUD_BuildingType_ValueChanged;
            // 
            // L_BuildingRotation
            // 
            L_BuildingRotation.Location = new System.Drawing.Point(42, 369);
            L_BuildingRotation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_BuildingRotation.Name = "L_BuildingRotation";
            L_BuildingRotation.Size = new System.Drawing.Size(117, 24);
            L_BuildingRotation.TabIndex = 122;
            L_BuildingRotation.Text = "Angle:";
            L_BuildingRotation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_BuildingStructureType
            // 
            L_BuildingStructureType.Location = new System.Drawing.Point(42, 429);
            L_BuildingStructureType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_BuildingStructureType.Name = "L_BuildingStructureType";
            L_BuildingStructureType.Size = new System.Drawing.Size(117, 24);
            L_BuildingStructureType.TabIndex = 124;
            L_BuildingStructureType.Text = "Type:";
            L_BuildingStructureType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Angle
            // 
            NUD_Angle.Location = new System.Drawing.Point(166, 370);
            NUD_Angle.Margin = new System.Windows.Forms.Padding(4);
            NUD_Angle.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NUD_Angle.Name = "NUD_Angle";
            NUD_Angle.Size = new System.Drawing.Size(80, 25);
            NUD_Angle.TabIndex = 123;
            NUD_Angle.ValueChanged += NUD_BuildingType_ValueChanged;
            // 
            // L_PlazaX
            // 
            L_PlazaX.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            L_PlazaX.Location = new System.Drawing.Point(76, 3);
            L_PlazaX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_PlazaX.Name = "L_PlazaX";
            L_PlazaX.Size = new System.Drawing.Size(72, 26);
            L_PlazaX.TabIndex = 115;
            L_PlazaX.Text = "Plaza X:";
            L_PlazaX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_PlazaX
            // 
            NUD_PlazaX.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            NUD_PlazaX.Location = new System.Drawing.Point(149, 4);
            NUD_PlazaX.Margin = new System.Windows.Forms.Padding(4);
            NUD_PlazaX.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            NUD_PlazaX.Name = "NUD_PlazaX";
            NUD_PlazaX.Size = new System.Drawing.Size(46, 25);
            NUD_PlazaX.TabIndex = 114;
            NUD_PlazaX.Value = new decimal(new int[] { 555, 0, 0, 0 });
            NUD_PlazaX.ValueChanged += NUD_PlazaX_ValueChanged;
            // 
            // L_PlazaY
            // 
            L_PlazaY.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            L_PlazaY.Location = new System.Drawing.Point(76, 30);
            L_PlazaY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_PlazaY.Name = "L_PlazaY";
            L_PlazaY.Size = new System.Drawing.Size(72, 26);
            L_PlazaY.TabIndex = 113;
            L_PlazaY.Text = "Plaza Y:";
            L_PlazaY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_PlazaY
            // 
            NUD_PlazaY.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            NUD_PlazaY.Location = new System.Drawing.Point(149, 31);
            NUD_PlazaY.Margin = new System.Windows.Forms.Padding(4);
            NUD_PlazaY.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            NUD_PlazaY.Name = "NUD_PlazaY";
            NUD_PlazaY.Size = new System.Drawing.Size(46, 25);
            NUD_PlazaY.TabIndex = 112;
            NUD_PlazaY.Value = new decimal(new int[] { 555, 0, 0, 0 });
            NUD_PlazaY.ValueChanged += NUD_PlazaY_ValueChanged;
            // 
            // B_Help
            // 
            B_Help.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Help.Location = new System.Drawing.Point(147, 540);
            B_Help.Margin = new System.Windows.Forms.Padding(4);
            B_Help.Name = "B_Help";
            B_Help.Size = new System.Drawing.Size(131, 52);
            B_Help.TabIndex = 111;
            B_Help.Text = "Help";
            B_Help.UseVisualStyleBackColor = true;
            B_Help.Click += B_Help_Click;
            // 
            // LB_Items
            // 
            LB_Items.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            LB_Items.FormattingEnabled = true;
            LB_Items.Location = new System.Drawing.Point(7, 59);
            LB_Items.Margin = new System.Windows.Forms.Padding(4);
            LB_Items.Name = "LB_Items";
            LB_Items.Size = new System.Drawing.Size(270, 242);
            LB_Items.TabIndex = 109;
            LB_Items.SelectedIndexChanged += LB_Items_SelectedIndexChanged;
            // 
            // Tab_Terrain
            // 
            Tab_Terrain.Controls.Add(B_TerrainBrush);
            Tab_Terrain.Controls.Add(L_TerrainTileLabelTransparency);
            Tab_Terrain.Controls.Add(TR_Terrain);
            Tab_Terrain.Controls.Add(TR_BuildingTransparency);
            Tab_Terrain.Controls.Add(L_BuildingTransparency);
            Tab_Terrain.Controls.Add(PG_TerrainTile);
            Tab_Terrain.Controls.Add(L_FieldItemTransparency);
            Tab_Terrain.Controls.Add(TR_Transparency);
            Tab_Terrain.Controls.Add(B_DumpLoadTerrain);
            Tab_Terrain.Controls.Add(B_ModifyAllTerrain);
            Tab_Terrain.Location = new System.Drawing.Point(4, 26);
            Tab_Terrain.Margin = new System.Windows.Forms.Padding(4);
            Tab_Terrain.Name = "Tab_Terrain";
            Tab_Terrain.Size = new System.Drawing.Size(286, 603);
            Tab_Terrain.TabIndex = 2;
            Tab_Terrain.Text = "Terrain";
            Tab_Terrain.UseVisualStyleBackColor = true;
            // 
            // B_TerrainBrush
            // 
            B_TerrainBrush.Location = new System.Drawing.Point(181, 540);
            B_TerrainBrush.Margin = new System.Windows.Forms.Padding(4);
            B_TerrainBrush.Name = "B_TerrainBrush";
            B_TerrainBrush.Size = new System.Drawing.Size(97, 52);
            B_TerrainBrush.TabIndex = 48;
            B_TerrainBrush.Text = "Terrain brushes";
            B_TerrainBrush.UseVisualStyleBackColor = true;
            B_TerrainBrush.Click += B_TerrainBrush_Click;
            // 
            // L_TerrainTileLabelTransparency
            // 
            L_TerrainTileLabelTransparency.AutoSize = true;
            L_TerrainTileLabelTransparency.Location = new System.Drawing.Point(9, 356);
            L_TerrainTileLabelTransparency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_TerrainTileLabelTransparency.Name = "L_TerrainTileLabelTransparency";
            L_TerrainTileLabelTransparency.Size = new System.Drawing.Size(188, 17);
            L_TerrainTileLabelTransparency.TabIndex = 46;
            L_TerrainTileLabelTransparency.Text = "Terrain Tile Label Transparency";
            // 
            // TR_Terrain
            // 
            TR_Terrain.AutoSize = false;
            TR_Terrain.Location = new System.Drawing.Point(4, 373);
            TR_Terrain.Margin = new System.Windows.Forms.Padding(4);
            TR_Terrain.Maximum = 255;
            TR_Terrain.Name = "TR_Terrain";
            TR_Terrain.Size = new System.Drawing.Size(276, 37);
            TR_Terrain.TabIndex = 45;
            TR_Terrain.TickFrequency = 32;
            TR_Terrain.Scroll += TR_Terrain_Scroll;
            // 
            // TR_BuildingTransparency
            // 
            TR_BuildingTransparency.AutoSize = false;
            TR_BuildingTransparency.Location = new System.Drawing.Point(4, 498);
            TR_BuildingTransparency.Margin = new System.Windows.Forms.Padding(4);
            TR_BuildingTransparency.Maximum = 255;
            TR_BuildingTransparency.Name = "TR_BuildingTransparency";
            TR_BuildingTransparency.Size = new System.Drawing.Size(276, 37);
            TR_BuildingTransparency.TabIndex = 43;
            TR_BuildingTransparency.TickFrequency = 16;
            TR_BuildingTransparency.Value = 255;
            TR_BuildingTransparency.Scroll += TR_BuildingTransparency_Scroll;
            // 
            // L_BuildingTransparency
            // 
            L_BuildingTransparency.AutoSize = true;
            L_BuildingTransparency.Location = new System.Drawing.Point(9, 477);
            L_BuildingTransparency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_BuildingTransparency.Name = "L_BuildingTransparency";
            L_BuildingTransparency.Size = new System.Drawing.Size(135, 17);
            L_BuildingTransparency.TabIndex = 44;
            L_BuildingTransparency.Text = "Building Transparency";
            // 
            // PG_TerrainTile
            // 
            PG_TerrainTile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            PG_TerrainTile.BackColor = System.Drawing.SystemColors.Control;
            PG_TerrainTile.Location = new System.Drawing.Point(4, 4);
            PG_TerrainTile.Margin = new System.Windows.Forms.Padding(4);
            PG_TerrainTile.Name = "PG_TerrainTile";
            PG_TerrainTile.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            PG_TerrainTile.Size = new System.Drawing.Size(278, 348);
            PG_TerrainTile.TabIndex = 41;
            PG_TerrainTile.ToolbarVisible = false;
            // 
            // L_FieldItemTransparency
            // 
            L_FieldItemTransparency.AutoSize = true;
            L_FieldItemTransparency.Location = new System.Drawing.Point(9, 413);
            L_FieldItemTransparency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_FieldItemTransparency.Name = "L_FieldItemTransparency";
            L_FieldItemTransparency.Size = new System.Drawing.Size(145, 17);
            L_FieldItemTransparency.TabIndex = 42;
            L_FieldItemTransparency.Text = "Field Item Transparency";
            // 
            // B_DumpLoadTerrain
            // 
            B_DumpLoadTerrain.Location = new System.Drawing.Point(7, 540);
            B_DumpLoadTerrain.Margin = new System.Windows.Forms.Padding(4);
            B_DumpLoadTerrain.Name = "B_DumpLoadTerrain";
            B_DumpLoadTerrain.Size = new System.Drawing.Size(57, 52);
            B_DumpLoadTerrain.TabIndex = 40;
            B_DumpLoadTerrain.Text = "Dump/Import";
            B_DumpLoadTerrain.UseVisualStyleBackColor = true;
            B_DumpLoadTerrain.Click += B_DumpLoadTerrain_Click;
            // 
            // B_ModifyAllTerrain
            // 
            B_ModifyAllTerrain.Location = new System.Drawing.Point(70, 540);
            B_ModifyAllTerrain.Margin = new System.Windows.Forms.Padding(4);
            B_ModifyAllTerrain.Name = "B_ModifyAllTerrain";
            B_ModifyAllTerrain.Size = new System.Drawing.Size(104, 52);
            B_ModifyAllTerrain.TabIndex = 39;
            B_ModifyAllTerrain.Text = "Modify All...";
            B_ModifyAllTerrain.UseVisualStyleBackColor = true;
            B_ModifyAllTerrain.Click += B_ModifyAllTerrain_Click;
            // 
            // Tab_Acres
            // 
            Tab_Acres.Controls.Add(NUD_MapAcreTemplateField);
            Tab_Acres.Controls.Add(L_MapAcreTemplateField);
            Tab_Acres.Controls.Add(L_MapAcreTemplateOutside);
            Tab_Acres.Controls.Add(NUD_MapAcreTemplateOutside);
            Tab_Acres.Controls.Add(CB_MapAcreSelect);
            Tab_Acres.Controls.Add(B_DumpLoadAcres);
            Tab_Acres.Controls.Add(L_MapAcre);
            Tab_Acres.Controls.Add(CB_MapAcre);
            Tab_Acres.Location = new System.Drawing.Point(4, 26);
            Tab_Acres.Margin = new System.Windows.Forms.Padding(4);
            Tab_Acres.Name = "Tab_Acres";
            Tab_Acres.Padding = new System.Windows.Forms.Padding(4);
            Tab_Acres.Size = new System.Drawing.Size(286, 603);
            Tab_Acres.TabIndex = 3;
            Tab_Acres.Text = "Acres";
            Tab_Acres.UseVisualStyleBackColor = true;
            // 
            // NUD_MapAcreTemplateField
            // 
            NUD_MapAcreTemplateField.Location = new System.Drawing.Point(197, 460);
            NUD_MapAcreTemplateField.Margin = new System.Windows.Forms.Padding(4);
            NUD_MapAcreTemplateField.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NUD_MapAcreTemplateField.Name = "NUD_MapAcreTemplateField";
            NUD_MapAcreTemplateField.Size = new System.Drawing.Size(80, 25);
            NUD_MapAcreTemplateField.TabIndex = 127;
            // 
            // L_MapAcreTemplateField
            // 
            L_MapAcreTemplateField.Location = new System.Drawing.Point(12, 459);
            L_MapAcreTemplateField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_MapAcreTemplateField.Name = "L_MapAcreTemplateField";
            L_MapAcreTemplateField.Size = new System.Drawing.Size(180, 25);
            L_MapAcreTemplateField.TabIndex = 126;
            L_MapAcreTemplateField.Text = "Field Acre Template:";
            L_MapAcreTemplateField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_MapAcreTemplateOutside
            // 
            L_MapAcreTemplateOutside.Location = new System.Drawing.Point(12, 425);
            L_MapAcreTemplateOutside.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_MapAcreTemplateOutside.Name = "L_MapAcreTemplateOutside";
            L_MapAcreTemplateOutside.Size = new System.Drawing.Size(180, 25);
            L_MapAcreTemplateOutside.TabIndex = 125;
            L_MapAcreTemplateOutside.Text = "Outside Acre Template:";
            L_MapAcreTemplateOutside.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_MapAcreTemplateOutside
            // 
            NUD_MapAcreTemplateOutside.Location = new System.Drawing.Point(197, 428);
            NUD_MapAcreTemplateOutside.Margin = new System.Windows.Forms.Padding(4);
            NUD_MapAcreTemplateOutside.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NUD_MapAcreTemplateOutside.Name = "NUD_MapAcreTemplateOutside";
            NUD_MapAcreTemplateOutside.Size = new System.Drawing.Size(80, 25);
            NUD_MapAcreTemplateOutside.TabIndex = 124;
            // 
            // CB_MapAcreSelect
            // 
            CB_MapAcreSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_MapAcreSelect.FormattingEnabled = true;
            CB_MapAcreSelect.Location = new System.Drawing.Point(10, 43);
            CB_MapAcreSelect.Margin = new System.Windows.Forms.Padding(4);
            CB_MapAcreSelect.Name = "CB_MapAcreSelect";
            CB_MapAcreSelect.Size = new System.Drawing.Size(248, 25);
            CB_MapAcreSelect.TabIndex = 102;
            CB_MapAcreSelect.SelectedValueChanged += CB_MapAcreSelect_SelectedValueChanged;
            // 
            // B_DumpLoadAcres
            // 
            B_DumpLoadAcres.ContextMenuStrip = CM_DLMapAcres;
            B_DumpLoadAcres.Location = new System.Drawing.Point(7, 540);
            B_DumpLoadAcres.Margin = new System.Windows.Forms.Padding(4);
            B_DumpLoadAcres.Name = "B_DumpLoadAcres";
            B_DumpLoadAcres.Size = new System.Drawing.Size(131, 52);
            B_DumpLoadAcres.TabIndex = 101;
            B_DumpLoadAcres.Text = "Dump/Import";
            B_DumpLoadAcres.UseVisualStyleBackColor = true;
            B_DumpLoadAcres.Click += B_DumpLoadAcres_Click;
            // 
            // CM_DLMapAcres
            // 
            CM_DLMapAcres.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { B_DumpMapAcres, B_ImportMapAcres });
            CM_DLMapAcres.Name = "CM_Picture";
            CM_DLMapAcres.ShowImageMargin = false;
            CM_DLMapAcres.Size = new System.Drawing.Size(158, 48);
            // 
            // B_DumpMapAcres
            // 
            B_DumpMapAcres.Name = "B_DumpMapAcres";
            B_DumpMapAcres.Size = new System.Drawing.Size(157, 22);
            B_DumpMapAcres.Text = "Dump Map Acres";
            B_DumpMapAcres.Click += B_DumpMapAcres_Click;
            // 
            // B_ImportMapAcres
            // 
            B_ImportMapAcres.Name = "B_ImportMapAcres";
            B_ImportMapAcres.Size = new System.Drawing.Size(157, 22);
            B_ImportMapAcres.Text = "Import Map Acres";
            B_ImportMapAcres.Click += B_ImportMapAcres_Click;
            // 
            // L_MapAcre
            // 
            L_MapAcre.Location = new System.Drawing.Point(7, 8);
            L_MapAcre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_MapAcre.Name = "L_MapAcre";
            L_MapAcre.Size = new System.Drawing.Size(104, 25);
            L_MapAcre.TabIndex = 99;
            L_MapAcre.Text = "Acre:";
            L_MapAcre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_MapAcre
            // 
            CB_MapAcre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_MapAcre.FormattingEnabled = true;
            CB_MapAcre.Location = new System.Drawing.Point(118, 8);
            CB_MapAcre.Margin = new System.Windows.Forms.Padding(4);
            CB_MapAcre.Name = "CB_MapAcre";
            CB_MapAcre.Size = new System.Drawing.Size(56, 25);
            CB_MapAcre.TabIndex = 98;
            CB_MapAcre.SelectedIndexChanged += CB_MapAcre_SelectedIndexChanged;
            // 
            // CM_DLTerrain
            // 
            CM_DLTerrain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { B_DumpTerrainAcre, B_DumpTerrainAll, B_ImportTerrainAcre, B_ImportTerrainAll });
            CM_DLTerrain.Name = "CM_Picture";
            CM_DLTerrain.ShowImageMargin = false;
            CM_DLTerrain.Size = new System.Drawing.Size(145, 92);
            // 
            // B_DumpTerrainAcre
            // 
            B_DumpTerrainAcre.Name = "B_DumpTerrainAcre";
            B_DumpTerrainAcre.Size = new System.Drawing.Size(144, 22);
            B_DumpTerrainAcre.Text = "Dump Acre";
            B_DumpTerrainAcre.Click += B_DumpTerrainAcre_Click;
            // 
            // B_DumpTerrainAll
            // 
            B_DumpTerrainAll.Name = "B_DumpTerrainAll";
            B_DumpTerrainAll.Size = new System.Drawing.Size(144, 22);
            B_DumpTerrainAll.Text = "Dump All Acres";
            B_DumpTerrainAll.Click += B_DumpTerrainAll_Click;
            // 
            // B_ImportTerrainAcre
            // 
            B_ImportTerrainAcre.Name = "B_ImportTerrainAcre";
            B_ImportTerrainAcre.Size = new System.Drawing.Size(144, 22);
            B_ImportTerrainAcre.Text = "Import Acre";
            B_ImportTerrainAcre.Click += B_ImportTerrainAcre_Click;
            // 
            // B_ImportTerrainAll
            // 
            B_ImportTerrainAll.Name = "B_ImportTerrainAll";
            B_ImportTerrainAll.Size = new System.Drawing.Size(144, 22);
            B_ImportTerrainAll.Text = "Import All Acres";
            B_ImportTerrainAll.Click += B_ImportTerrainAll_Click;
            // 
            // CM_Terrain
            // 
            CM_Terrain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { B_ZeroElevation, B_SetAllTerrain, B_SetAllRoadTiles, B_ClearPlacedDesigns, B_ImportPlacedDesigns, B_ExportPlacedDesigns });
            CM_Terrain.Name = "CM_Picture";
            CM_Terrain.ShowImageMargin = false;
            CM_Terrain.Size = new System.Drawing.Size(248, 136);
            // 
            // B_ZeroElevation
            // 
            B_ZeroElevation.Name = "B_ZeroElevation";
            B_ZeroElevation.Size = new System.Drawing.Size(247, 22);
            B_ZeroElevation.Text = "Zero Elevation";
            B_ZeroElevation.Click += B_ZeroElevation_Click;
            // 
            // B_SetAllTerrain
            // 
            B_SetAllTerrain.Name = "B_SetAllTerrain";
            B_SetAllTerrain.Size = new System.Drawing.Size(247, 22);
            B_SetAllTerrain.Text = "Set All Tiles using Tile from Editor";
            B_SetAllTerrain.Click += B_SetAllTerrain_Click;
            // 
            // B_SetAllRoadTiles
            // 
            B_SetAllRoadTiles.Name = "B_SetAllRoadTiles";
            B_SetAllRoadTiles.Size = new System.Drawing.Size(247, 22);
            B_SetAllRoadTiles.Text = "Set All Road Tiles from Editor";
            B_SetAllRoadTiles.Click += B_SetAllRoadTiles_Click;
            // 
            // B_ClearPlacedDesigns
            // 
            B_ClearPlacedDesigns.Name = "B_ClearPlacedDesigns";
            B_ClearPlacedDesigns.Size = new System.Drawing.Size(247, 22);
            B_ClearPlacedDesigns.Text = "Clear all Placed Designs";
            B_ClearPlacedDesigns.Click += B_ClearPlacedDesigns_Click;
            // 
            // B_ImportPlacedDesigns
            // 
            B_ImportPlacedDesigns.Name = "B_ImportPlacedDesigns";
            B_ImportPlacedDesigns.Size = new System.Drawing.Size(247, 22);
            B_ImportPlacedDesigns.Text = "Import all Placed Design Choices";
            B_ImportPlacedDesigns.Click += B_ImportPlacedDesigns_Click;
            // 
            // B_ExportPlacedDesigns
            // 
            B_ExportPlacedDesigns.Name = "B_ExportPlacedDesigns";
            B_ExportPlacedDesigns.Size = new System.Drawing.Size(247, 22);
            B_ExportPlacedDesigns.Text = "Export all Placed Design Choices";
            B_ExportPlacedDesigns.Click += B_ExportPlacedDesigns_Click;
            // 
            // RB_Item
            // 
            RB_Item.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            RB_Item.Checked = true;
            RB_Item.Location = new System.Drawing.Point(684, 375);
            RB_Item.Margin = new System.Windows.Forms.Padding(4);
            RB_Item.Name = "RB_Item";
            RB_Item.Size = new System.Drawing.Size(140, 26);
            RB_Item.TabIndex = 43;
            RB_Item.TabStop = true;
            RB_Item.Text = "Items";
            RB_Item.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            RB_Item.UseVisualStyleBackColor = true;
            // 
            // RB_Terrain
            // 
            RB_Terrain.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            RB_Terrain.Location = new System.Drawing.Point(684, 353);
            RB_Terrain.Margin = new System.Windows.Forms.Padding(4);
            RB_Terrain.Name = "RB_Terrain";
            RB_Terrain.Size = new System.Drawing.Size(140, 26);
            RB_Terrain.TabIndex = 44;
            RB_Terrain.Text = "Terrain";
            RB_Terrain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            RB_Terrain.UseVisualStyleBackColor = true;
            // 
            // L_TileMode
            // 
            L_TileMode.Location = new System.Drawing.Point(684, 323);
            L_TileMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_TileMode.Name = "L_TileMode";
            L_TileMode.Size = new System.Drawing.Size(140, 26);
            L_TileMode.TabIndex = 45;
            L_TileMode.Text = "Tile Editor Mode";
            L_TileMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CHK_RedirectExtensionLoad
            // 
            CHK_RedirectExtensionLoad.AutoSize = true;
            CHK_RedirectExtensionLoad.Checked = true;
            CHK_RedirectExtensionLoad.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_RedirectExtensionLoad.Location = new System.Drawing.Point(0, 63);
            CHK_RedirectExtensionLoad.Margin = new System.Windows.Forms.Padding(0);
            CHK_RedirectExtensionLoad.Name = "CHK_RedirectExtensionLoad";
            CHK_RedirectExtensionLoad.Size = new System.Drawing.Size(207, 21);
            CHK_RedirectExtensionLoad.TabIndex = 46;
            CHK_RedirectExtensionLoad.Text = "View Root instead of Extension";
            CHK_RedirectExtensionLoad.UseVisualStyleBackColor = true;
            // 
            // CHK_MoveOnDrag
            // 
            CHK_MoveOnDrag.AutoSize = true;
            CHK_MoveOnDrag.Checked = true;
            CHK_MoveOnDrag.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_MoveOnDrag.Location = new System.Drawing.Point(0, 0);
            CHK_MoveOnDrag.Margin = new System.Windows.Forms.Padding(0);
            CHK_MoveOnDrag.Name = "CHK_MoveOnDrag";
            CHK_MoveOnDrag.Size = new System.Drawing.Size(253, 21);
            CHK_MoveOnDrag.TabIndex = 46;
            CHK_MoveOnDrag.Text = "Move Field Item Editor on mouse drag";
            CHK_MoveOnDrag.UseVisualStyleBackColor = true;
            // 
            // CHK_FieldItemSnap
            // 
            CHK_FieldItemSnap.AutoSize = true;
            CHK_FieldItemSnap.Checked = true;
            CHK_FieldItemSnap.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_FieldItemSnap.Location = new System.Drawing.Point(0, 84);
            CHK_FieldItemSnap.Margin = new System.Windows.Forms.Padding(0);
            CHK_FieldItemSnap.Name = "CHK_FieldItemSnap";
            CHK_FieldItemSnap.Size = new System.Drawing.Size(208, 21);
            CHK_FieldItemSnap.TabIndex = 47;
            CHK_FieldItemSnap.Text = "Snap Field Items to Grid on Set";
            CHK_FieldItemSnap.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(CHK_MoveOnDrag);
            flowLayoutPanel1.Controls.Add(CHK_NoOverwrite);
            flowLayoutPanel1.Controls.Add(CHK_AutoExtension);
            flowLayoutPanel1.Controls.Add(CHK_RedirectExtensionLoad);
            flowLayoutPanel1.Controls.Add(CHK_FieldItemSnap);
            flowLayoutPanel1.Location = new System.Drawing.Point(14, 537);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(269, 112);
            flowLayoutPanel1.TabIndex = 48;
            // 
            // L_Acre
            // 
            L_Acre.Location = new System.Drawing.Point(657, 442);
            L_Acre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Acre.Name = "L_Acre";
            L_Acre.Size = new System.Drawing.Size(104, 25);
            L_Acre.TabIndex = 101;
            L_Acre.Text = "Acre:";
            L_Acre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Acre
            // 
            CB_Acre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_Acre.FormattingEnabled = true;
            CB_Acre.Location = new System.Drawing.Point(768, 442);
            CB_Acre.Margin = new System.Windows.Forms.Padding(4);
            CB_Acre.Name = "CB_Acre";
            CB_Acre.Size = new System.Drawing.Size(56, 25);
            CB_Acre.TabIndex = 100;
            CB_Acre.SelectedIndexChanged += ChangeAcre;
            // 
            // B_DumpAllAcresFlag
            // 
            B_DumpAllAcresFlag.Name = "B_DumpAllAcresFlag";
            B_DumpAllAcresFlag.Size = new System.Drawing.Size(155, 22);
            B_DumpAllAcresFlag.Text = "Dump All Flags";
            B_DumpAllAcresFlag.Click += B_DumpAllAcresFlag_Click;
            // 
            // B_ImportAllAcresFlag
            // 
            B_ImportAllAcresFlag.Name = "B_ImportAllAcresFlag";
            B_ImportAllAcresFlag.Size = new System.Drawing.Size(155, 22);
            B_ImportAllAcresFlag.Text = "Import All Flags";
            B_ImportAllAcresFlag.Click += B_ImportAllAcresFlag_Click;
            // 
            // FieldItemEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1138, 702);
            Controls.Add(L_Acre);
            Controls.Add(CB_Acre);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(L_TileMode);
            Controls.Add(RB_Terrain);
            Controls.Add(RB_Item);
            Controls.Add(TC_Editor);
            Controls.Add(PB_Viewport);
            Controls.Add(L_Layer);
            Controls.Add(NUD_Layer);
            Controls.Add(L_Coordinates);
            Controls.Add(CHK_SnapToAcre);
            Controls.Add(PB_Map);
            Controls.Add(B_Down);
            Controls.Add(B_Right);
            Controls.Add(B_Left);
            Controls.Add(B_Up);
            Controls.Add(B_Cancel);
            Controls.Add(B_Save);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = Properties.Resources.icon;
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FieldItemEditor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Field Item Editor";
            FormClosed += FieldItemEditor_FormClosed;
            CM_Click.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PB_Map).EndInit();
            CM_Picture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NUD_Layer).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Viewport).EndInit();
            ((System.ComponentModel.ISupportInitialize)TR_Transparency).EndInit();
            CM_Remove.ResumeLayout(false);
            TC_Editor.ResumeLayout(false);
            Tab_Item.ResumeLayout(false);
            Tab_Item.PerformLayout();
            CM_DLField.ResumeLayout(false);
            Tab_Building.ResumeLayout(false);
            CM_DLBuilding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NUD_Bit).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_BuildingType).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_UniqueID).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_X).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_TypeArg).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Y).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Type).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Angle).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_PlazaX).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_PlazaY).EndInit();
            Tab_Terrain.ResumeLayout(false);
            Tab_Terrain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TR_Terrain).EndInit();
            ((System.ComponentModel.ISupportInitialize)TR_BuildingTransparency).EndInit();
            Tab_Acres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NUD_MapAcreTemplateField).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_MapAcreTemplateOutside).EndInit();
            CM_DLMapAcres.ResumeLayout(false);
            CM_DLTerrain.ResumeLayout(false);
            CM_Terrain.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
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
        private System.Windows.Forms.PictureBox PB_Viewport;
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
        private System.Windows.Forms.Button B_TerrainBrush;
        private System.Windows.Forms.ToolStripMenuItem B_RemoveEditor;
        private System.Windows.Forms.ToolStripMenuItem Menu_Activate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label L_Acre;
        private System.Windows.Forms.ComboBox CB_Acre;
        private System.Windows.Forms.ToolStripMenuItem B_DumpAllAcresFlag;
        private System.Windows.Forms.ToolStripMenuItem B_ImportAllAcresFlag;
    }
}
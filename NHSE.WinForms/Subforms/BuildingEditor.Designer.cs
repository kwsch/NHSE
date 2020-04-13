namespace NHSE.WinForms
{
    partial class BuildingEditor
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
            this.PB_Map = new System.Windows.Forms.PictureBox();
            this.L_BuildingType = new System.Windows.Forms.Label();
            this.NUD_BuildingType = new System.Windows.Forms.NumericUpDown();
            this.NUD_X = new System.Windows.Forms.NumericUpDown();
            this.L_BuildingX = new System.Windows.Forms.Label();
            this.NUD_Y = new System.Windows.Forms.NumericUpDown();
            this.L_BuildingY = new System.Windows.Forms.Label();
            this.NUD_Rot = new System.Windows.Forms.NumericUpDown();
            this.L_BuildingRotation = new System.Windows.Forms.Label();
            this.NUD_08 = new System.Windows.Forms.NumericUpDown();
            this.L_Building08 = new System.Windows.Forms.Label();
            this.NUD_0C = new System.Windows.Forms.NumericUpDown();
            this.L_Building0C = new System.Windows.Forms.Label();
            this.NUD_10 = new System.Windows.Forms.NumericUpDown();
            this.L_Building10 = new System.Windows.Forms.Label();
            this.GB_Building = new System.Windows.Forms.GroupBox();
            this.GB_Info = new System.Windows.Forms.GroupBox();
            this.L_StructureValues = new System.Windows.Forms.Label();
            this.CB_StructureValues = new System.Windows.Forms.ComboBox();
            this.L_StructureType = new System.Windows.Forms.Label();
            this.CB_StructureType = new System.Windows.Forms.ComboBox();
            this.L_PlazaX = new System.Windows.Forms.Label();
            this.NUD_PlazaX = new System.Windows.Forms.NumericUpDown();
            this.L_PlazaY = new System.Windows.Forms.Label();
            this.NUD_PlazaY = new System.Windows.Forms.NumericUpDown();
            this.B_Import = new System.Windows.Forms.Button();
            this.B_Dump = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BuildingType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Rot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_0C)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_10)).BeginInit();
            this.GB_Building.SuspendLayout();
            this.GB_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PlazaX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PlazaY)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.Location = new System.Drawing.Point(609, 501);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(65, 23);
            this.B_Save.TabIndex = 1;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(609, 527);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(65, 23);
            this.B_Cancel.TabIndex = 2;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // LB_Items
            // 
            this.LB_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_Items.FormattingEnabled = true;
            this.LB_Items.Location = new System.Drawing.Point(12, 12);
            this.LB_Items.Name = "LB_Items";
            this.LB_Items.Size = new System.Drawing.Size(206, 537);
            this.LB_Items.TabIndex = 3;
            this.LB_Items.SelectedIndexChanged += new System.EventHandler(this.LB_Items_SelectedIndexChanged);
            // 
            // PB_Map
            // 
            this.PB_Map.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_Map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Map.Location = new System.Drawing.Point(224, 12);
            this.PB_Map.Name = "PB_Map";
            this.PB_Map.Size = new System.Drawing.Size(450, 386);
            this.PB_Map.TabIndex = 5;
            this.PB_Map.TabStop = false;
            // 
            // L_BuildingType
            // 
            this.L_BuildingType.Location = new System.Drawing.Point(6, 12);
            this.L_BuildingType.Name = "L_BuildingType";
            this.L_BuildingType.Size = new System.Drawing.Size(100, 18);
            this.L_BuildingType.TabIndex = 6;
            this.L_BuildingType.Text = "Building Type:";
            this.L_BuildingType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_BuildingType
            // 
            this.NUD_BuildingType.Location = new System.Drawing.Point(112, 13);
            this.NUD_BuildingType.Name = "NUD_BuildingType";
            this.NUD_BuildingType.Size = new System.Drawing.Size(69, 20);
            this.NUD_BuildingType.TabIndex = 7;
            this.NUD_BuildingType.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // NUD_X
            // 
            this.NUD_X.Location = new System.Drawing.Point(61, 35);
            this.NUD_X.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_X.Name = "NUD_X";
            this.NUD_X.Size = new System.Drawing.Size(45, 20);
            this.NUD_X.TabIndex = 9;
            this.NUD_X.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // L_BuildingX
            // 
            this.L_BuildingX.Location = new System.Drawing.Point(35, 34);
            this.L_BuildingX.Name = "L_BuildingX";
            this.L_BuildingX.Size = new System.Drawing.Size(20, 18);
            this.L_BuildingX.TabIndex = 8;
            this.L_BuildingX.Text = "X:";
            this.L_BuildingX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Y
            // 
            this.NUD_Y.Location = new System.Drawing.Point(136, 35);
            this.NUD_Y.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_Y.Name = "NUD_Y";
            this.NUD_Y.Size = new System.Drawing.Size(45, 20);
            this.NUD_Y.TabIndex = 11;
            this.NUD_Y.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // L_BuildingY
            // 
            this.L_BuildingY.Location = new System.Drawing.Point(107, 34);
            this.L_BuildingY.Name = "L_BuildingY";
            this.L_BuildingY.Size = new System.Drawing.Size(23, 18);
            this.L_BuildingY.TabIndex = 10;
            this.L_BuildingY.Text = "Y:";
            this.L_BuildingY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Rot
            // 
            this.NUD_Rot.Location = new System.Drawing.Point(112, 60);
            this.NUD_Rot.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_Rot.Name = "NUD_Rot";
            this.NUD_Rot.Size = new System.Drawing.Size(69, 20);
            this.NUD_Rot.TabIndex = 13;
            this.NUD_Rot.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // L_BuildingRotation
            // 
            this.L_BuildingRotation.Location = new System.Drawing.Point(6, 59);
            this.L_BuildingRotation.Name = "L_BuildingRotation";
            this.L_BuildingRotation.Size = new System.Drawing.Size(100, 18);
            this.L_BuildingRotation.TabIndex = 12;
            this.L_BuildingRotation.Text = "Rotation:";
            this.L_BuildingRotation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_08
            // 
            this.NUD_08.Location = new System.Drawing.Point(112, 80);
            this.NUD_08.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_08.Name = "NUD_08";
            this.NUD_08.Size = new System.Drawing.Size(69, 20);
            this.NUD_08.TabIndex = 15;
            this.NUD_08.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // L_Building08
            // 
            this.L_Building08.Location = new System.Drawing.Point(6, 79);
            this.L_Building08.Name = "L_Building08";
            this.L_Building08.Size = new System.Drawing.Size(100, 18);
            this.L_Building08.TabIndex = 14;
            this.L_Building08.Text = "Unknown 0x08:";
            this.L_Building08.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_0C
            // 
            this.NUD_0C.Location = new System.Drawing.Point(112, 100);
            this.NUD_0C.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_0C.Name = "NUD_0C";
            this.NUD_0C.Size = new System.Drawing.Size(69, 20);
            this.NUD_0C.TabIndex = 17;
            this.NUD_0C.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // L_Building0C
            // 
            this.L_Building0C.Location = new System.Drawing.Point(6, 99);
            this.L_Building0C.Name = "L_Building0C";
            this.L_Building0C.Size = new System.Drawing.Size(100, 18);
            this.L_Building0C.TabIndex = 16;
            this.L_Building0C.Text = "Unknown 0x0A:";
            this.L_Building0C.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_10
            // 
            this.NUD_10.Location = new System.Drawing.Point(112, 120);
            this.NUD_10.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_10.Name = "NUD_10";
            this.NUD_10.Size = new System.Drawing.Size(69, 20);
            this.NUD_10.TabIndex = 19;
            this.NUD_10.ValueChanged += new System.EventHandler(this.NUD_BuildingType_ValueChanged);
            // 
            // L_Building10
            // 
            this.L_Building10.Location = new System.Drawing.Point(6, 119);
            this.L_Building10.Name = "L_Building10";
            this.L_Building10.Size = new System.Drawing.Size(100, 18);
            this.L_Building10.TabIndex = 18;
            this.L_Building10.Text = "Unknown 0x0C:";
            this.L_Building10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GB_Building
            // 
            this.GB_Building.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_Building.Controls.Add(this.L_BuildingType);
            this.GB_Building.Controls.Add(this.NUD_BuildingType);
            this.GB_Building.Controls.Add(this.NUD_10);
            this.GB_Building.Controls.Add(this.L_BuildingX);
            this.GB_Building.Controls.Add(this.L_Building10);
            this.GB_Building.Controls.Add(this.NUD_X);
            this.GB_Building.Controls.Add(this.NUD_0C);
            this.GB_Building.Controls.Add(this.L_BuildingY);
            this.GB_Building.Controls.Add(this.L_Building0C);
            this.GB_Building.Controls.Add(this.NUD_Y);
            this.GB_Building.Controls.Add(this.NUD_08);
            this.GB_Building.Controls.Add(this.L_BuildingRotation);
            this.GB_Building.Controls.Add(this.L_Building08);
            this.GB_Building.Controls.Add(this.NUD_Rot);
            this.GB_Building.Location = new System.Drawing.Point(224, 404);
            this.GB_Building.Name = "GB_Building";
            this.GB_Building.Size = new System.Drawing.Size(194, 147);
            this.GB_Building.TabIndex = 21;
            this.GB_Building.TabStop = false;
            this.GB_Building.Text = "Editor";
            // 
            // GB_Info
            // 
            this.GB_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_Info.Controls.Add(this.L_StructureValues);
            this.GB_Info.Controls.Add(this.CB_StructureValues);
            this.GB_Info.Controls.Add(this.L_StructureType);
            this.GB_Info.Controls.Add(this.CB_StructureType);
            this.GB_Info.Location = new System.Drawing.Point(424, 404);
            this.GB_Info.Name = "GB_Info";
            this.GB_Info.Size = new System.Drawing.Size(250, 94);
            this.GB_Info.TabIndex = 22;
            this.GB_Info.TabStop = false;
            this.GB_Info.Text = "Info";
            // 
            // L_StructureValues
            // 
            this.L_StructureValues.AutoSize = true;
            this.L_StructureValues.Location = new System.Drawing.Point(17, 51);
            this.L_StructureValues.Name = "L_StructureValues";
            this.L_StructureValues.Size = new System.Drawing.Size(42, 13);
            this.L_StructureValues.TabIndex = 22;
            this.L_StructureValues.Text = "Values:";
            this.L_StructureValues.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_StructureValues
            // 
            this.CB_StructureValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_StructureValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_StructureValues.DropDownWidth = 322;
            this.CB_StructureValues.FormattingEnabled = true;
            this.CB_StructureValues.Location = new System.Drawing.Point(20, 64);
            this.CB_StructureValues.Name = "CB_StructureValues";
            this.CB_StructureValues.Size = new System.Drawing.Size(221, 21);
            this.CB_StructureValues.TabIndex = 21;
            // 
            // L_StructureType
            // 
            this.L_StructureType.AutoSize = true;
            this.L_StructureType.Location = new System.Drawing.Point(17, 12);
            this.L_StructureType.Name = "L_StructureType";
            this.L_StructureType.Size = new System.Drawing.Size(80, 13);
            this.L_StructureType.TabIndex = 20;
            this.L_StructureType.Text = "Structure Type:";
            this.L_StructureType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_StructureType
            // 
            this.CB_StructureType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_StructureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_StructureType.FormattingEnabled = true;
            this.CB_StructureType.Location = new System.Drawing.Point(20, 26);
            this.CB_StructureType.Name = "CB_StructureType";
            this.CB_StructureType.Size = new System.Drawing.Size(221, 21);
            this.CB_StructureType.TabIndex = 0;
            this.CB_StructureType.SelectedIndexChanged += new System.EventHandler(this.CB_StructureType_SelectedIndexChanged);
            // 
            // L_PlazaX
            // 
            this.L_PlazaX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.L_PlazaX.Location = new System.Drawing.Point(497, 503);
            this.L_PlazaX.Name = "L_PlazaX";
            this.L_PlazaX.Size = new System.Drawing.Size(62, 20);
            this.L_PlazaX.TabIndex = 104;
            this.L_PlazaX.Text = "Plaza X:";
            this.L_PlazaX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_PlazaX
            // 
            this.NUD_PlazaX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_PlazaX.Location = new System.Drawing.Point(560, 504);
            this.NUD_PlazaX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NUD_PlazaX.Name = "NUD_PlazaX";
            this.NUD_PlazaX.Size = new System.Drawing.Size(39, 20);
            this.NUD_PlazaX.TabIndex = 103;
            this.NUD_PlazaX.Value = new decimal(new int[] {
            555,
            0,
            0,
            0});
            this.NUD_PlazaX.ValueChanged += new System.EventHandler(this.NUD_PlazaCoordinate_ValueChanged);
            // 
            // L_PlazaY
            // 
            this.L_PlazaY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.L_PlazaY.Location = new System.Drawing.Point(497, 526);
            this.L_PlazaY.Name = "L_PlazaY";
            this.L_PlazaY.Size = new System.Drawing.Size(62, 20);
            this.L_PlazaY.TabIndex = 102;
            this.L_PlazaY.Text = "Plaza Y:";
            this.L_PlazaY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_PlazaY
            // 
            this.NUD_PlazaY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_PlazaY.Location = new System.Drawing.Point(560, 527);
            this.NUD_PlazaY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NUD_PlazaY.Name = "NUD_PlazaY";
            this.NUD_PlazaY.Size = new System.Drawing.Size(39, 20);
            this.NUD_PlazaY.TabIndex = 101;
            this.NUD_PlazaY.Value = new decimal(new int[] {
            555,
            0,
            0,
            0});
            this.NUD_PlazaY.ValueChanged += new System.EventHandler(this.NUD_PlazaCoordinate_ValueChanged);
            // 
            // B_Import
            // 
            this.B_Import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Import.Location = new System.Drawing.Point(424, 527);
            this.B_Import.Name = "B_Import";
            this.B_Import.Size = new System.Drawing.Size(65, 23);
            this.B_Import.TabIndex = 106;
            this.B_Import.Text = "Import";
            this.B_Import.UseVisualStyleBackColor = true;
            this.B_Import.Click += new System.EventHandler(this.B_ImportAll_Click);
            // 
            // B_Dump
            // 
            this.B_Dump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Dump.Location = new System.Drawing.Point(424, 501);
            this.B_Dump.Name = "B_Dump";
            this.B_Dump.Size = new System.Drawing.Size(65, 23);
            this.B_Dump.TabIndex = 105;
            this.B_Dump.Text = "Dump";
            this.B_Dump.UseVisualStyleBackColor = true;
            this.B_Dump.Click += new System.EventHandler(this.B_DumpAll_Click);
            // 
            // BuildingEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.B_Import);
            this.Controls.Add(this.B_Dump);
            this.Controls.Add(this.L_PlazaX);
            this.Controls.Add(this.NUD_PlazaX);
            this.Controls.Add(this.L_PlazaY);
            this.Controls.Add(this.NUD_PlazaY);
            this.Controls.Add(this.GB_Info);
            this.Controls.Add(this.GB_Building);
            this.Controls.Add(this.PB_Map);
            this.Controls.Add(this.LB_Items);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuildingEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Building Editor";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_BuildingType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Rot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_0C)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_10)).EndInit();
            this.GB_Building.ResumeLayout(false);
            this.GB_Info.ResumeLayout(false);
            this.GB_Info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PlazaX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PlazaY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.ListBox LB_Items;
        private System.Windows.Forms.PictureBox PB_Map;
        private System.Windows.Forms.Label L_BuildingType;
        private System.Windows.Forms.NumericUpDown NUD_BuildingType;
        private System.Windows.Forms.NumericUpDown NUD_X;
        private System.Windows.Forms.Label L_BuildingX;
        private System.Windows.Forms.NumericUpDown NUD_Y;
        private System.Windows.Forms.Label L_BuildingY;
        private System.Windows.Forms.NumericUpDown NUD_Rot;
        private System.Windows.Forms.Label L_BuildingRotation;
        private System.Windows.Forms.NumericUpDown NUD_08;
        private System.Windows.Forms.Label L_Building08;
        private System.Windows.Forms.NumericUpDown NUD_0C;
        private System.Windows.Forms.Label L_Building0C;
        private System.Windows.Forms.NumericUpDown NUD_10;
        private System.Windows.Forms.Label L_Building10;
        private System.Windows.Forms.GroupBox GB_Building;
        private System.Windows.Forms.GroupBox GB_Info;
        private System.Windows.Forms.Label L_StructureValues;
        private System.Windows.Forms.ComboBox CB_StructureValues;
        private System.Windows.Forms.Label L_StructureType;
        private System.Windows.Forms.ComboBox CB_StructureType;
        private System.Windows.Forms.Label L_PlazaX;
        private System.Windows.Forms.NumericUpDown NUD_PlazaX;
        private System.Windows.Forms.Label L_PlazaY;
        private System.Windows.Forms.NumericUpDown NUD_PlazaY;
        private System.Windows.Forms.Button B_Import;
        private System.Windows.Forms.Button B_Dump;
    }
}
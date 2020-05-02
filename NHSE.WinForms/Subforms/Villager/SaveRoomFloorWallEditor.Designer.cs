namespace NHSE.WinForms
{
    partial class SaveRoomFloorWallEditor
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
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_AccentWall = new System.Windows.Forms.Button();
            this.B_Wall = new System.Windows.Forms.Button();
            this.B_Floor = new System.Windows.Forms.Button();
            this.L_AccentDesign = new System.Windows.Forms.Label();
            this.NUD_DesignAccent = new System.Windows.Forms.NumericUpDown();
            this.NUD_DirAccent = new System.Windows.Forms.NumericUpDown();
            this.L_AccentDirection = new System.Windows.Forms.Label();
            this.NUD_InfoBit = new System.Windows.Forms.NumericUpDown();
            this.NUD_DesignWall = new System.Windows.Forms.NumericUpDown();
            this.L_InfoBit = new System.Windows.Forms.Label();
            this.L_WallDesign = new System.Windows.Forms.Label();
            this.L_FloorDirection = new System.Windows.Forms.Label();
            this.L_FloorDesign = new System.Windows.Forms.Label();
            this.NUD_DirFloor = new System.Windows.Forms.NumericUpDown();
            this.NUD_DesignFloor = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DesignAccent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DirAccent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_InfoBit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DesignWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DirFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DesignFloor)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(95, 159);
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
            this.B_Save.Location = new System.Drawing.Point(173, 159);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(72, 23);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_AccentWall
            // 
            this.B_AccentWall.Location = new System.Drawing.Point(12, 12);
            this.B_AccentWall.Name = "B_AccentWall";
            this.B_AccentWall.Size = new System.Drawing.Size(100, 40);
            this.B_AccentWall.TabIndex = 8;
            this.B_AccentWall.Text = "Accent Wall";
            this.B_AccentWall.UseVisualStyleBackColor = true;
            this.B_AccentWall.Click += new System.EventHandler(this.B_AccentWall_Click);
            // 
            // B_Wall
            // 
            this.B_Wall.Location = new System.Drawing.Point(12, 58);
            this.B_Wall.Name = "B_Wall";
            this.B_Wall.Size = new System.Drawing.Size(100, 40);
            this.B_Wall.TabIndex = 9;
            this.B_Wall.Text = "Wall";
            this.B_Wall.UseVisualStyleBackColor = true;
            this.B_Wall.Click += new System.EventHandler(this.B_Wall_Click);
            // 
            // B_Floor
            // 
            this.B_Floor.Location = new System.Drawing.Point(12, 104);
            this.B_Floor.Name = "B_Floor";
            this.B_Floor.Size = new System.Drawing.Size(100, 40);
            this.B_Floor.TabIndex = 10;
            this.B_Floor.Text = "Floor";
            this.B_Floor.UseVisualStyleBackColor = true;
            this.B_Floor.Click += new System.EventHandler(this.B_Floor_Click);
            // 
            // L_AccentDesign
            // 
            this.L_AccentDesign.AutoSize = true;
            this.L_AccentDesign.Location = new System.Drawing.Point(122, 16);
            this.L_AccentDesign.Name = "L_AccentDesign";
            this.L_AccentDesign.Size = new System.Drawing.Size(51, 13);
            this.L_AccentDesign.TabIndex = 11;
            this.L_AccentDesign.Text = "DesignID";
            this.L_AccentDesign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NUD_DesignAccent
            // 
            this.NUD_DesignAccent.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_DesignAccent.Location = new System.Drawing.Point(125, 32);
            this.NUD_DesignAccent.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_DesignAccent.Name = "NUD_DesignAccent";
            this.NUD_DesignAccent.Size = new System.Drawing.Size(55, 20);
            this.NUD_DesignAccent.TabIndex = 12;
            this.NUD_DesignAccent.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // NUD_DirAccent
            // 
            this.NUD_DirAccent.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_DirAccent.Location = new System.Drawing.Point(203, 32);
            this.NUD_DirAccent.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_DirAccent.Name = "NUD_DirAccent";
            this.NUD_DirAccent.Size = new System.Drawing.Size(41, 20);
            this.NUD_DirAccent.TabIndex = 13;
            this.NUD_DirAccent.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // L_AccentDirection
            // 
            this.L_AccentDirection.AutoSize = true;
            this.L_AccentDirection.Location = new System.Drawing.Point(200, 17);
            this.L_AccentDirection.Name = "L_AccentDirection";
            this.L_AccentDirection.Size = new System.Drawing.Size(49, 13);
            this.L_AccentDirection.TabIndex = 14;
            this.L_AccentDirection.Text = "Direction";
            this.L_AccentDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NUD_InfoBit
            // 
            this.NUD_InfoBit.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_InfoBit.Location = new System.Drawing.Point(203, 78);
            this.NUD_InfoBit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_InfoBit.Name = "NUD_InfoBit";
            this.NUD_InfoBit.Size = new System.Drawing.Size(41, 20);
            this.NUD_InfoBit.TabIndex = 16;
            this.NUD_InfoBit.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // NUD_DesignWall
            // 
            this.NUD_DesignWall.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_DesignWall.Location = new System.Drawing.Point(125, 78);
            this.NUD_DesignWall.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_DesignWall.Name = "NUD_DesignWall";
            this.NUD_DesignWall.Size = new System.Drawing.Size(55, 20);
            this.NUD_DesignWall.TabIndex = 15;
            this.NUD_DesignWall.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // L_InfoBit
            // 
            this.L_InfoBit.AutoSize = true;
            this.L_InfoBit.Location = new System.Drawing.Point(200, 63);
            this.L_InfoBit.Name = "L_InfoBit";
            this.L_InfoBit.Size = new System.Drawing.Size(37, 13);
            this.L_InfoBit.TabIndex = 18;
            this.L_InfoBit.Text = "InfoBit";
            this.L_InfoBit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_WallDesign
            // 
            this.L_WallDesign.AutoSize = true;
            this.L_WallDesign.Location = new System.Drawing.Point(122, 62);
            this.L_WallDesign.Name = "L_WallDesign";
            this.L_WallDesign.Size = new System.Drawing.Size(51, 13);
            this.L_WallDesign.TabIndex = 17;
            this.L_WallDesign.Text = "DesignID";
            this.L_WallDesign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_FloorDirection
            // 
            this.L_FloorDirection.AutoSize = true;
            this.L_FloorDirection.Location = new System.Drawing.Point(200, 109);
            this.L_FloorDirection.Name = "L_FloorDirection";
            this.L_FloorDirection.Size = new System.Drawing.Size(49, 13);
            this.L_FloorDirection.TabIndex = 22;
            this.L_FloorDirection.Text = "Direction";
            this.L_FloorDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_FloorDesign
            // 
            this.L_FloorDesign.AutoSize = true;
            this.L_FloorDesign.Location = new System.Drawing.Point(122, 108);
            this.L_FloorDesign.Name = "L_FloorDesign";
            this.L_FloorDesign.Size = new System.Drawing.Size(51, 13);
            this.L_FloorDesign.TabIndex = 21;
            this.L_FloorDesign.Text = "DesignID";
            this.L_FloorDesign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NUD_DirFloor
            // 
            this.NUD_DirFloor.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_DirFloor.Location = new System.Drawing.Point(203, 124);
            this.NUD_DirFloor.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_DirFloor.Name = "NUD_DirFloor";
            this.NUD_DirFloor.Size = new System.Drawing.Size(41, 20);
            this.NUD_DirFloor.TabIndex = 20;
            this.NUD_DirFloor.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // NUD_DesignFloor
            // 
            this.NUD_DesignFloor.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_DesignFloor.Location = new System.Drawing.Point(125, 124);
            this.NUD_DesignFloor.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_DesignFloor.Name = "NUD_DesignFloor";
            this.NUD_DesignFloor.Size = new System.Drawing.Size(55, 20);
            this.NUD_DesignFloor.TabIndex = 19;
            this.NUD_DesignFloor.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // SaveRoomFloorWallEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 194);
            this.Controls.Add(this.L_FloorDirection);
            this.Controls.Add(this.L_FloorDesign);
            this.Controls.Add(this.NUD_DirFloor);
            this.Controls.Add(this.NUD_DesignFloor);
            this.Controls.Add(this.L_InfoBit);
            this.Controls.Add(this.L_WallDesign);
            this.Controls.Add(this.NUD_InfoBit);
            this.Controls.Add(this.NUD_DesignWall);
            this.Controls.Add(this.L_AccentDirection);
            this.Controls.Add(this.NUD_DirAccent);
            this.Controls.Add(this.NUD_DesignAccent);
            this.Controls.Add(this.L_AccentDesign);
            this.Controls.Add(this.B_Floor);
            this.Controls.Add(this.B_Wall);
            this.Controls.Add(this.B_AccentWall);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveRoomFloorWallEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room Editor";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DesignAccent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DirAccent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_InfoBit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DesignWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DirFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DesignFloor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_AccentWall;
        private System.Windows.Forms.Button B_Wall;
        private System.Windows.Forms.Button B_Floor;
        private System.Windows.Forms.Label L_AccentDesign;
        private System.Windows.Forms.NumericUpDown NUD_DesignAccent;
        private System.Windows.Forms.NumericUpDown NUD_DirAccent;
        private System.Windows.Forms.Label L_AccentDirection;
        private System.Windows.Forms.NumericUpDown NUD_InfoBit;
        private System.Windows.Forms.NumericUpDown NUD_DesignWall;
        private System.Windows.Forms.Label L_InfoBit;
        private System.Windows.Forms.Label L_WallDesign;
        private System.Windows.Forms.Label L_FloorDirection;
        private System.Windows.Forms.Label L_FloorDesign;
        private System.Windows.Forms.NumericUpDown NUD_DirFloor;
        private System.Windows.Forms.NumericUpDown NUD_DesignFloor;
    }
}
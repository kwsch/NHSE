namespace NHSE.WinForms
{
    partial class BulkSpawn
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
            this.B_Apply = new System.Windows.Forms.Button();
            this.NUD_SpawnX = new System.Windows.Forms.NumericUpDown();
            this.NUD_SpawnY = new System.Windows.Forms.NumericUpDown();
            this.L_X = new System.Windows.Forms.Label();
            this.L_Y = new System.Windows.Forms.Label();
            this.CB_SpawnType = new System.Windows.Forms.ComboBox();
            this.L_SpawnCount = new System.Windows.Forms.Label();
            this.NUD_SpawnCount = new System.Windows.Forms.NumericUpDown();
            this.L_DIYStart = new System.Windows.Forms.Label();
            this.NUD_DIYStart = new System.Windows.Forms.NumericUpDown();
            this.L_DIYStop = new System.Windows.Forms.Label();
            this.NUD_DIYStop = new System.Windows.Forms.NumericUpDown();
            this.CB_SpawnArrange = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SpawnX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SpawnY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SpawnCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DIYStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DIYStop)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Apply
            // 
            this.B_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Apply.Location = new System.Drawing.Point(12, 200);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(112, 23);
            this.B_Apply.TabIndex = 6;
            this.B_Apply.Text = "Spawn";
            this.B_Apply.UseVisualStyleBackColor = true;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // NUD_SpawnX
            // 
            this.NUD_SpawnX.Location = new System.Drawing.Point(61, 63);
            this.NUD_SpawnX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUD_SpawnX.Name = "NUD_SpawnX";
            this.NUD_SpawnX.Size = new System.Drawing.Size(45, 20);
            this.NUD_SpawnX.TabIndex = 12;
            // 
            // NUD_SpawnY
            // 
            this.NUD_SpawnY.Location = new System.Drawing.Point(61, 89);
            this.NUD_SpawnY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUD_SpawnY.Name = "NUD_SpawnY";
            this.NUD_SpawnY.Size = new System.Drawing.Size(45, 20);
            this.NUD_SpawnY.TabIndex = 13;
            // 
            // L_X
            // 
            this.L_X.Location = new System.Drawing.Point(14, 63);
            this.L_X.Name = "L_X";
            this.L_X.Size = new System.Drawing.Size(41, 20);
            this.L_X.TabIndex = 14;
            this.L_X.Text = "X:";
            this.L_X.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Y
            // 
            this.L_Y.Location = new System.Drawing.Point(14, 89);
            this.L_Y.Name = "L_Y";
            this.L_Y.Size = new System.Drawing.Size(41, 20);
            this.L_Y.TabIndex = 15;
            this.L_Y.Text = "Y:";
            this.L_Y.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_SpawnType
            // 
            this.CB_SpawnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SpawnType.FormattingEnabled = true;
            this.CB_SpawnType.Location = new System.Drawing.Point(15, 9);
            this.CB_SpawnType.Name = "CB_SpawnType";
            this.CB_SpawnType.Size = new System.Drawing.Size(108, 21);
            this.CB_SpawnType.TabIndex = 16;
            this.CB_SpawnType.SelectedIndexChanged += new System.EventHandler(this.CB_SpawnType_SelectedIndexChanged);
            // 
            // L_SpawnCount
            // 
            this.L_SpawnCount.Location = new System.Drawing.Point(14, 115);
            this.L_SpawnCount.Name = "L_SpawnCount";
            this.L_SpawnCount.Size = new System.Drawing.Size(51, 20);
            this.L_SpawnCount.TabIndex = 18;
            this.L_SpawnCount.Text = "Count:";
            this.L_SpawnCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_SpawnCount
            // 
            this.NUD_SpawnCount.Location = new System.Drawing.Point(71, 117);
            this.NUD_SpawnCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUD_SpawnCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_SpawnCount.Name = "NUD_SpawnCount";
            this.NUD_SpawnCount.Size = new System.Drawing.Size(45, 20);
            this.NUD_SpawnCount.TabIndex = 17;
            this.NUD_SpawnCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // L_DIYStart
            // 
            this.L_DIYStart.Location = new System.Drawing.Point(14, 141);
            this.L_DIYStart.Name = "L_DIYStart";
            this.L_DIYStart.Size = new System.Drawing.Size(51, 20);
            this.L_DIYStart.TabIndex = 20;
            this.L_DIYStart.Text = "Start:";
            this.L_DIYStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_DIYStart
            // 
            this.NUD_DIYStart.Location = new System.Drawing.Point(71, 143);
            this.NUD_DIYStart.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUD_DIYStart.Name = "NUD_DIYStart";
            this.NUD_DIYStart.Size = new System.Drawing.Size(45, 20);
            this.NUD_DIYStart.TabIndex = 19;
            // 
            // L_DIYStop
            // 
            this.L_DIYStop.Location = new System.Drawing.Point(14, 167);
            this.L_DIYStop.Name = "L_DIYStop";
            this.L_DIYStop.Size = new System.Drawing.Size(51, 20);
            this.L_DIYStop.TabIndex = 22;
            this.L_DIYStop.Text = "Stop:";
            this.L_DIYStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_DIYStop
            // 
            this.NUD_DIYStop.Location = new System.Drawing.Point(71, 169);
            this.NUD_DIYStop.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUD_DIYStop.Name = "NUD_DIYStop";
            this.NUD_DIYStop.Size = new System.Drawing.Size(45, 20);
            this.NUD_DIYStop.TabIndex = 21;
            this.NUD_DIYStop.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // CB_SpawnArrange
            // 
            this.CB_SpawnArrange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SpawnArrange.FormattingEnabled = true;
            this.CB_SpawnArrange.Location = new System.Drawing.Point(16, 36);
            this.CB_SpawnArrange.Name = "CB_SpawnArrange";
            this.CB_SpawnArrange.Size = new System.Drawing.Size(108, 21);
            this.CB_SpawnArrange.TabIndex = 23;
            // 
            // BulkSpawn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(136, 235);
            this.Controls.Add(this.CB_SpawnArrange);
            this.Controls.Add(this.L_DIYStop);
            this.Controls.Add(this.NUD_DIYStop);
            this.Controls.Add(this.L_DIYStart);
            this.Controls.Add(this.NUD_DIYStart);
            this.Controls.Add(this.L_SpawnCount);
            this.Controls.Add(this.NUD_SpawnCount);
            this.Controls.Add(this.CB_SpawnType);
            this.Controls.Add(this.L_Y);
            this.Controls.Add(this.L_X);
            this.Controls.Add(this.NUD_SpawnY);
            this.Controls.Add(this.NUD_SpawnX);
            this.Controls.Add(this.B_Apply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BulkSpawn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulk Spawn";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SpawnX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SpawnY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SpawnCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DIYStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DIYStop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.NumericUpDown NUD_SpawnX;
        private System.Windows.Forms.NumericUpDown NUD_SpawnY;
        private System.Windows.Forms.Label L_X;
        private System.Windows.Forms.Label L_Y;
        private System.Windows.Forms.ComboBox CB_SpawnType;
        private System.Windows.Forms.Label L_SpawnCount;
        private System.Windows.Forms.NumericUpDown NUD_SpawnCount;
        private System.Windows.Forms.Label L_DIYStart;
        private System.Windows.Forms.NumericUpDown NUD_DIYStart;
        private System.Windows.Forms.Label L_DIYStop;
        private System.Windows.Forms.NumericUpDown NUD_DIYStop;
        private System.Windows.Forms.ComboBox CB_SpawnArrange;
    }
}
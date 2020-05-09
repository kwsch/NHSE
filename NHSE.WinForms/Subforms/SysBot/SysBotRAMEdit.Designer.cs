namespace NHSE.WinForms
{
    partial class SysBotRAMEdit
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
            this.B_Connect = new System.Windows.Forms.Button();
            this.L_Port = new System.Windows.Forms.Label();
            this.TB_Port = new System.Windows.Forms.TextBox();
            this.L_IP = new System.Windows.Forms.Label();
            this.TB_IP = new System.Windows.Forms.TextBox();
            this.GB_Inject = new System.Windows.Forms.GroupBox();
            this.NUD_Offset = new System.Windows.Forms.NumericUpDown();
            this.L_Length = new System.Windows.Forms.Label();
            this.RamOffset = new System.Windows.Forms.TextBox();
            this.L_Offset = new System.Windows.Forms.Label();
            this.B_Edit = new System.Windows.Forms.Button();
            this.GB_Inject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Offset)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Connect
            // 
            this.B_Connect.Location = new System.Drawing.Point(102, 37);
            this.B_Connect.Name = "B_Connect";
            this.B_Connect.Size = new System.Drawing.Size(63, 23);
            this.B_Connect.TabIndex = 12;
            this.B_Connect.Text = "Connect";
            this.B_Connect.UseVisualStyleBackColor = true;
            this.B_Connect.Click += new System.EventHandler(this.B_Connect_Click);
            // 
            // L_Port
            // 
            this.L_Port.Location = new System.Drawing.Point(13, 38);
            this.L_Port.Name = "L_Port";
            this.L_Port.Size = new System.Drawing.Size(40, 20);
            this.L_Port.TabIndex = 11;
            this.L_Port.Text = "Port:";
            this.L_Port.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Port
            // 
            this.TB_Port.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Port.Location = new System.Drawing.Point(54, 38);
            this.TB_Port.Name = "TB_Port";
            this.TB_Port.Size = new System.Drawing.Size(42, 20);
            this.TB_Port.TabIndex = 10;
            this.TB_Port.Text = "6000";
            // 
            // L_IP
            // 
            this.L_IP.Location = new System.Drawing.Point(13, 12);
            this.L_IP.Name = "L_IP";
            this.L_IP.Size = new System.Drawing.Size(40, 20);
            this.L_IP.TabIndex = 9;
            this.L_IP.Text = "IP:";
            this.L_IP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_IP
            // 
            this.TB_IP.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_IP.Location = new System.Drawing.Point(54, 12);
            this.TB_IP.Name = "TB_IP";
            this.TB_IP.Size = new System.Drawing.Size(111, 20);
            this.TB_IP.TabIndex = 8;
            this.TB_IP.Text = "111.111.111.111";
            // 
            // GB_Inject
            // 
            this.GB_Inject.Controls.Add(this.NUD_Offset);
            this.GB_Inject.Controls.Add(this.L_Length);
            this.GB_Inject.Controls.Add(this.RamOffset);
            this.GB_Inject.Controls.Add(this.L_Offset);
            this.GB_Inject.Controls.Add(this.B_Edit);
            this.GB_Inject.Enabled = false;
            this.GB_Inject.Location = new System.Drawing.Point(16, 66);
            this.GB_Inject.Name = "GB_Inject";
            this.GB_Inject.Size = new System.Drawing.Size(210, 67);
            this.GB_Inject.TabIndex = 13;
            this.GB_Inject.TabStop = false;
            this.GB_Inject.Text = "Injector";
            // 
            // NUD_Offset
            // 
            this.NUD_Offset.Location = new System.Drawing.Point(73, 39);
            this.NUD_Offset.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.NUD_Offset.Name = "NUD_Offset";
            this.NUD_Offset.Size = new System.Drawing.Size(63, 20);
            this.NUD_Offset.TabIndex = 22;
            this.NUD_Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUD_Offset.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // L_Length
            // 
            this.L_Length.Location = new System.Drawing.Point(5, 37);
            this.L_Length.Name = "L_Length";
            this.L_Length.Size = new System.Drawing.Size(63, 20);
            this.L_Length.TabIndex = 21;
            this.L_Length.Text = "Length:";
            this.L_Length.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RamOffset
            // 
            this.RamOffset.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RamOffset.Location = new System.Drawing.Point(73, 15);
            this.RamOffset.MaxLength = 8;
            this.RamOffset.Name = "RamOffset";
            this.RamOffset.Size = new System.Drawing.Size(63, 20);
            this.RamOffset.TabIndex = 20;
            this.RamOffset.Text = "AC4723D0";
            // 
            // L_Offset
            // 
            this.L_Offset.Location = new System.Drawing.Point(4, 14);
            this.L_Offset.Name = "L_Offset";
            this.L_Offset.Size = new System.Drawing.Size(63, 20);
            this.L_Offset.TabIndex = 19;
            this.L_Offset.Text = "Offset:";
            this.L_Offset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // B_Edit
            // 
            this.B_Edit.Location = new System.Drawing.Point(142, 15);
            this.B_Edit.Name = "B_Edit";
            this.B_Edit.Size = new System.Drawing.Size(56, 44);
            this.B_Edit.TabIndex = 0;
            this.B_Edit.Text = "Edit";
            this.B_Edit.UseVisualStyleBackColor = true;
            this.B_Edit.Click += new System.EventHandler(this.B_Edit_Click);
            // 
            // SysBotRAMEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 140);
            this.Controls.Add(this.GB_Inject);
            this.Controls.Add(this.B_Connect);
            this.Controls.Add(this.L_Port);
            this.Controls.Add(this.TB_Port);
            this.Controls.Add(this.L_IP);
            this.Controls.Add(this.TB_IP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SysBotRAMEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SysBotUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SysBotRAMEdit_FormClosing);
            this.GB_Inject.ResumeLayout(false);
            this.GB_Inject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Offset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Connect;
        private System.Windows.Forms.Label L_Port;
        private System.Windows.Forms.TextBox TB_Port;
        private System.Windows.Forms.Label L_IP;
        private System.Windows.Forms.TextBox TB_IP;
        private System.Windows.Forms.GroupBox GB_Inject;
        private System.Windows.Forms.Button B_Edit;
        private System.Windows.Forms.TextBox RamOffset;
        private System.Windows.Forms.Label L_Offset;
        private System.Windows.Forms.Label L_Length;
        private System.Windows.Forms.NumericUpDown NUD_Offset;
    }
}
﻿namespace NHSE.WinForms
{
    partial class SysBotUI
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
            this.B_Connect = new System.Windows.Forms.Button();
            this.L_Port = new System.Windows.Forms.Label();
            this.TB_Port = new System.Windows.Forms.TextBox();
            this.L_IP = new System.Windows.Forms.Label();
            this.TB_IP = new System.Windows.Forms.TextBox();
            this.GB_Inject = new System.Windows.Forms.GroupBox();
            this.CHK_Validate = new System.Windows.Forms.CheckBox();
            this.CHK_AutoRead = new System.Windows.Forms.CheckBox();
            this.CHK_AutoWrite = new System.Windows.Forms.CheckBox();
            this.RamOffset = new System.Windows.Forms.TextBox();
            this.L_Offset = new System.Windows.Forms.Label();
            this.B_ReadCurrent = new System.Windows.Forms.Button();
            this.B_WriteCurrent = new System.Windows.Forms.Button();
            this.TIM_Interval = new System.Windows.Forms.Timer(this.components);
            this.GB_USB = new System.Windows.Forms.GroupBox();
            this.RamOffsetUSB = new System.Windows.Forms.TextBox();
            this.L_OffsetUSB = new System.Windows.Forms.Label();
            this.WriteUSB = new System.Windows.Forms.Button();
            this.ReadUSB = new System.Windows.Forms.Button();
            this.GB_Inject.SuspendLayout();
            this.GB_USB.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_Connect
            // 
            this.B_Connect.Location = new System.Drawing.Point(136, 46);
            this.B_Connect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Connect.Name = "B_Connect";
            this.B_Connect.Size = new System.Drawing.Size(84, 28);
            this.B_Connect.TabIndex = 12;
            this.B_Connect.Text = "Connect";
            this.B_Connect.UseVisualStyleBackColor = true;
            this.B_Connect.Click += new System.EventHandler(this.B_Connect_Click);
            // 
            // L_Port
            // 
            this.L_Port.Location = new System.Drawing.Point(17, 47);
            this.L_Port.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_Port.Name = "L_Port";
            this.L_Port.Size = new System.Drawing.Size(53, 25);
            this.L_Port.TabIndex = 11;
            this.L_Port.Text = "Port:";
            this.L_Port.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Port
            // 
            this.TB_Port.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Port.Location = new System.Drawing.Point(72, 47);
            this.TB_Port.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Port.Name = "TB_Port";
            this.TB_Port.Size = new System.Drawing.Size(55, 23);
            this.TB_Port.TabIndex = 10;
            this.TB_Port.Text = "6000";
            // 
            // L_IP
            // 
            this.L_IP.Location = new System.Drawing.Point(17, 15);
            this.L_IP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_IP.Name = "L_IP";
            this.L_IP.Size = new System.Drawing.Size(53, 25);
            this.L_IP.TabIndex = 9;
            this.L_IP.Text = "IP:";
            this.L_IP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_IP
            // 
            this.TB_IP.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_IP.Location = new System.Drawing.Point(72, 15);
            this.TB_IP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_IP.Name = "TB_IP";
            this.TB_IP.Size = new System.Drawing.Size(147, 23);
            this.TB_IP.TabIndex = 8;
            this.TB_IP.Text = "111.111.111.111";
            // 
            // GB_Inject
            // 
            this.GB_Inject.Controls.Add(this.CHK_Validate);
            this.GB_Inject.Controls.Add(this.CHK_AutoRead);
            this.GB_Inject.Controls.Add(this.CHK_AutoWrite);
            this.GB_Inject.Controls.Add(this.RamOffset);
            this.GB_Inject.Controls.Add(this.L_Offset);
            this.GB_Inject.Controls.Add(this.B_ReadCurrent);
            this.GB_Inject.Controls.Add(this.B_WriteCurrent);
            this.GB_Inject.Enabled = false;
            this.GB_Inject.Location = new System.Drawing.Point(21, 81);
            this.GB_Inject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_Inject.Name = "GB_Inject";
            this.GB_Inject.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_Inject.Size = new System.Drawing.Size(199, 146);
            this.GB_Inject.TabIndex = 13;
            this.GB_Inject.TabStop = false;
            this.GB_Inject.Text = "Injector";
            // 
            // CHK_Validate
            // 
            this.CHK_Validate.AutoSize = true;
            this.CHK_Validate.Checked = true;
            this.CHK_Validate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_Validate.Location = new System.Drawing.Point(24, 123);
            this.CHK_Validate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CHK_Validate.Name = "CHK_Validate";
            this.CHK_Validate.Size = new System.Drawing.Size(115, 21);
            this.CHK_Validate.TabIndex = 23;
            this.CHK_Validate.Text = "Validate Data";
            this.CHK_Validate.UseVisualStyleBackColor = true;
            this.CHK_Validate.CheckedChanged += new System.EventHandler(this.CHK_Validate_CheckedChanged);
            // 
            // CHK_AutoRead
            // 
            this.CHK_AutoRead.AutoSize = true;
            this.CHK_AutoRead.Location = new System.Drawing.Point(24, 105);
            this.CHK_AutoRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CHK_AutoRead.Name = "CHK_AutoRead";
            this.CHK_AutoRead.Size = new System.Drawing.Size(93, 21);
            this.CHK_AutoRead.TabIndex = 22;
            this.CHK_AutoRead.Text = "AutoRead";
            this.CHK_AutoRead.UseVisualStyleBackColor = true;
            this.CHK_AutoRead.CheckedChanged += new System.EventHandler(this.CHK_AutoRead_CheckedChanged);
            // 
            // CHK_AutoWrite
            // 
            this.CHK_AutoWrite.AutoSize = true;
            this.CHK_AutoWrite.Location = new System.Drawing.Point(24, 86);
            this.CHK_AutoWrite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CHK_AutoWrite.Name = "CHK_AutoWrite";
            this.CHK_AutoWrite.Size = new System.Drawing.Size(92, 21);
            this.CHK_AutoWrite.TabIndex = 21;
            this.CHK_AutoWrite.Text = "AutoWrite";
            this.CHK_AutoWrite.UseVisualStyleBackColor = true;
            this.CHK_AutoWrite.CheckedChanged += new System.EventHandler(this.CHK_AutoWrite_CheckedChanged);
            // 
            // RamOffset
            // 
            this.RamOffset.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RamOffset.Location = new System.Drawing.Point(96, 23);
            this.RamOffset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RamOffset.MaxLength = 8;
            this.RamOffset.Name = "RamOffset";
            this.RamOffset.Size = new System.Drawing.Size(83, 23);
            this.RamOffset.TabIndex = 20;
            this.RamOffset.Text = "ABC25840";
            this.RamOffset.TextChanged += new System.EventHandler(this.RamOffset_TextChanged);
            // 
            // L_Offset
            // 
            this.L_Offset.Location = new System.Drawing.Point(4, 22);
            this.L_Offset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_Offset.Name = "L_Offset";
            this.L_Offset.Size = new System.Drawing.Size(84, 25);
            this.L_Offset.TabIndex = 19;
            this.L_Offset.Text = "Offset:";
            this.L_Offset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // B_ReadCurrent
            // 
            this.B_ReadCurrent.Location = new System.Drawing.Point(24, 50);
            this.B_ReadCurrent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_ReadCurrent.Name = "B_ReadCurrent";
            this.B_ReadCurrent.Size = new System.Drawing.Size(75, 28);
            this.B_ReadCurrent.TabIndex = 0;
            this.B_ReadCurrent.Text = "Read";
            this.B_ReadCurrent.UseVisualStyleBackColor = true;
            this.B_ReadCurrent.Click += new System.EventHandler(this.B_ReadCurrent_Click);
            // 
            // B_WriteCurrent
            // 
            this.B_WriteCurrent.Location = new System.Drawing.Point(107, 50);
            this.B_WriteCurrent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_WriteCurrent.Name = "B_WriteCurrent";
            this.B_WriteCurrent.Size = new System.Drawing.Size(75, 28);
            this.B_WriteCurrent.TabIndex = 1;
            this.B_WriteCurrent.Text = "Write";
            this.B_WriteCurrent.UseVisualStyleBackColor = true;
            this.B_WriteCurrent.Click += new System.EventHandler(this.B_WriteCurrent_Click);
            // 
            // TIM_Interval
            // 
            this.TIM_Interval.Interval = 5000;
            // 
            // GB_USB
            // 
            this.GB_USB.Controls.Add(this.RamOffsetUSB);
            this.GB_USB.Controls.Add(this.L_OffsetUSB);
            this.GB_USB.Controls.Add(this.WriteUSB);
            this.GB_USB.Controls.Add(this.ReadUSB);
            this.GB_USB.Location = new System.Drawing.Point(21, 235);
            this.GB_USB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_USB.Name = "GB_USB";
            this.GB_USB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GB_USB.Size = new System.Drawing.Size(199, 92);
            this.GB_USB.TabIndex = 14;
            this.GB_USB.TabStop = false;
            this.GB_USB.Text = "USB";
            // 
            // RamOffsetUSB
            // 
            this.RamOffsetUSB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RamOffsetUSB.Location = new System.Drawing.Point(96, 30);
            this.RamOffsetUSB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RamOffsetUSB.MaxLength = 8;
            this.RamOffsetUSB.Name = "RamOffsetUSB";
            this.RamOffsetUSB.Size = new System.Drawing.Size(83, 23);
            this.RamOffsetUSB.TabIndex = 24;
            this.RamOffsetUSB.Text = "ABC25840";
            this.RamOffsetUSB.TextChanged += new System.EventHandler(this.RamOffsetUSB_TextChanged);
            // 
            // L_OffsetUSB
            // 
            this.L_OffsetUSB.Location = new System.Drawing.Point(4, 30);
            this.L_OffsetUSB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_OffsetUSB.Name = "L_OffsetUSB";
            this.L_OffsetUSB.Size = new System.Drawing.Size(84, 25);
            this.L_OffsetUSB.TabIndex = 20;
            this.L_OffsetUSB.Text = "Offset:";
            this.L_OffsetUSB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WriteUSB
            // 
            this.WriteUSB.Location = new System.Drawing.Point(99, 57);
            this.WriteUSB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WriteUSB.Name = "WriteUSB";
            this.WriteUSB.Size = new System.Drawing.Size(92, 28);
            this.WriteUSB.TabIndex = 1;
            this.WriteUSB.Text = "Write USB";
            this.WriteUSB.UseVisualStyleBackColor = true;
            this.WriteUSB.Click += new System.EventHandler(this.WriteUSB_Click);
            // 
            // ReadUSB
            // 
            this.ReadUSB.Location = new System.Drawing.Point(8, 57);
            this.ReadUSB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReadUSB.Name = "ReadUSB";
            this.ReadUSB.Size = new System.Drawing.Size(91, 28);
            this.ReadUSB.TabIndex = 0;
            this.ReadUSB.Text = "Read USB";
            this.ReadUSB.UseVisualStyleBackColor = true;
            this.ReadUSB.Click += new System.EventHandler(this.ReadUSB_Click);
            // 
            // SysBotUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 342);
            this.Controls.Add(this.GB_USB);
            this.Controls.Add(this.GB_Inject);
            this.Controls.Add(this.B_Connect);
            this.Controls.Add(this.L_Port);
            this.Controls.Add(this.TB_Port);
            this.Controls.Add(this.L_IP);
            this.Controls.Add(this.TB_IP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SysBotUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SysBotUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SysBotUI_FormClosing);
            this.GB_Inject.ResumeLayout(false);
            this.GB_Inject.PerformLayout();
            this.GB_USB.ResumeLayout(false);
            this.GB_USB.PerformLayout();
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
        private System.Windows.Forms.Button B_ReadCurrent;
        private System.Windows.Forms.Button B_WriteCurrent;
        private System.Windows.Forms.TextBox RamOffset;
        private System.Windows.Forms.Label L_Offset;
        private System.Windows.Forms.CheckBox CHK_AutoWrite;
        private System.Windows.Forms.CheckBox CHK_AutoRead;
        private System.Windows.Forms.Timer TIM_Interval;
        private System.Windows.Forms.CheckBox CHK_Validate;
        private System.Windows.Forms.GroupBox GB_USB;
        private System.Windows.Forms.Button ReadUSB;
        private System.Windows.Forms.Button WriteUSB;
        private System.Windows.Forms.TextBox RamOffsetUSB;
        private System.Windows.Forms.Label L_OffsetUSB;
    }
}
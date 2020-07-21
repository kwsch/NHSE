namespace NHSE.WinForms
{
    partial class ImageFetcher
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
            this.PBar_MultiUse = new System.Windows.Forms.ProgressBar();
            this.B_Download = new System.Windows.Forms.Button();
            this.CB_HostSelect = new System.Windows.Forms.ComboBox();
            this.L_Warning = new System.Windows.Forms.Label();
            this.L_Host = new System.Windows.Forms.Label();
            this.L_Status = new System.Windows.Forms.Label();
            this.L_ImgStatus = new System.Windows.Forms.Label();
            this.L_FileSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PBar_MultiUse
            // 
            this.PBar_MultiUse.Location = new System.Drawing.Point(37, 178);
            this.PBar_MultiUse.Name = "PBar_MultiUse";
            this.PBar_MultiUse.Size = new System.Drawing.Size(330, 23);
            this.PBar_MultiUse.TabIndex = 0;
            // 
            // B_Download
            // 
            this.B_Download.Location = new System.Drawing.Point(125, 149);
            this.B_Download.Name = "B_Download";
            this.B_Download.Size = new System.Drawing.Size(156, 23);
            this.B_Download.TabIndex = 1;
            this.B_Download.Text = "Download Images";
            this.B_Download.UseVisualStyleBackColor = true;
            this.B_Download.Click += new System.EventHandler(this.B_Download_Click);
            // 
            // CB_HostSelect
            // 
            this.CB_HostSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_HostSelect.FormattingEnabled = true;
            this.CB_HostSelect.Location = new System.Drawing.Point(37, 93);
            this.CB_HostSelect.Name = "CB_HostSelect";
            this.CB_HostSelect.Size = new System.Drawing.Size(330, 21);
            this.CB_HostSelect.TabIndex = 2;
            this.CB_HostSelect.SelectedIndexChanged += new System.EventHandler(this.CB_HostSelect_SelectedIndexChanged);
            // 
            // L_Warning
            // 
            this.L_Warning.Location = new System.Drawing.Point(37, 22);
            this.L_Warning.Name = "L_Warning";
            this.L_Warning.Size = new System.Drawing.Size(330, 44);
            this.L_Warning.TabIndex = 3;
            this.L_Warning.Text = "The developers of this application are not responsible for curating item images. " +
    "Images are hosted by third parties and while every effort is made to ensure comp" +
    "leteness, this is not guaranteed.";
            this.L_Warning.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // L_Host
            // 
            this.L_Host.AutoSize = true;
            this.L_Host.Location = new System.Drawing.Point(162, 77);
            this.L_Host.Name = "L_Host";
            this.L_Host.Size = new System.Drawing.Size(83, 13);
            this.L_Host.TabIndex = 4;
            this.L_Host.Text = "Download Host:";
            this.L_Host.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // L_Status
            // 
            this.L_Status.Location = new System.Drawing.Point(37, 204);
            this.L_Status.Name = "L_Status";
            this.L_Status.Size = new System.Drawing.Size(330, 22);
            this.L_Status.TabIndex = 5;
            this.L_Status.Text = "Downloading...";
            this.L_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_ImgStatus
            // 
            this.L_ImgStatus.ForeColor = System.Drawing.Color.Red;
            this.L_ImgStatus.Location = new System.Drawing.Point(45, 117);
            this.L_ImgStatus.Name = "L_ImgStatus";
            this.L_ImgStatus.Size = new System.Drawing.Size(317, 29);
            this.L_ImgStatus.TabIndex = 6;
            this.L_ImgStatus.Text = "Images now exist. Only repair images if absolutely necessary. Images do NOT need " +
    "to be redownloaded when NHSE updates.";
            this.L_ImgStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_FileSize
            // 
            this.L_FileSize.Location = new System.Drawing.Point(287, 72);
            this.L_FileSize.Name = "L_FileSize";
            this.L_FileSize.Size = new System.Drawing.Size(80, 18);
            this.L_FileSize.TabIndex = 7;
            this.L_FileSize.Text = "00.0MB";
            this.L_FileSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ImageFetcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 235);
            this.Controls.Add(this.L_FileSize);
            this.Controls.Add(this.L_ImgStatus);
            this.Controls.Add(this.L_Status);
            this.Controls.Add(this.L_Host);
            this.Controls.Add(this.L_Warning);
            this.Controls.Add(this.CB_HostSelect);
            this.Controls.Add(this.B_Download);
            this.Controls.Add(this.PBar_MultiUse);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageFetcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Images";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar PBar_MultiUse;
        private System.Windows.Forms.Button B_Download;
        private System.Windows.Forms.ComboBox CB_HostSelect;
        private System.Windows.Forms.Label L_Warning;
        private System.Windows.Forms.Label L_Host;
        private System.Windows.Forms.Label L_Status;
        private System.Windows.Forms.Label L_ImgStatus;
        private System.Windows.Forms.Label L_FileSize;
    }
}
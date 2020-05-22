namespace NHSE.WinForms
{
    partial class AchievementRow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.L_Threshold = new System.Windows.Forms.Label();
            this.CHK_Read = new System.Windows.Forms.CheckBox();
            this.CAL_Date = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // L_Threshold
            // 
            this.L_Threshold.Location = new System.Drawing.Point(3, 0);
            this.L_Threshold.Name = "L_Threshold";
            this.L_Threshold.Size = new System.Drawing.Size(80, 20);
            this.L_Threshold.TabIndex = 32;
            this.L_Threshold.Text = "1";
            this.L_Threshold.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CHK_Read
            // 
            this.CHK_Read.AutoSize = true;
            this.CHK_Read.Location = new System.Drawing.Point(295, 3);
            this.CHK_Read.Name = "CHK_Read";
            this.CHK_Read.Size = new System.Drawing.Size(52, 17);
            this.CHK_Read.TabIndex = 31;
            this.CHK_Read.Text = "Read";
            this.CHK_Read.UseVisualStyleBackColor = true;
            // 
            // CAL_Date
            // 
            this.CAL_Date.Location = new System.Drawing.Point(89, 0);
            this.CAL_Date.Name = "CAL_Date";
            this.CAL_Date.Size = new System.Drawing.Size(200, 20);
            this.CAL_Date.TabIndex = 30;
            this.CAL_Date.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CAL_Date_MouseDown);
            // 
            // AchievementRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.L_Threshold);
            this.Controls.Add(this.CHK_Read);
            this.Controls.Add(this.CAL_Date);
            this.Name = "AchievementRow";
            this.Size = new System.Drawing.Size(366, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Threshold;
        private System.Windows.Forms.CheckBox CHK_Read;
        private System.Windows.Forms.DateTimePicker CAL_Date;
    }
}

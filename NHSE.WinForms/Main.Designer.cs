namespace NHSE.WinForms
{
    public partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            B_Open = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // B_Open
            // 
            B_Open.Dock = System.Windows.Forms.DockStyle.Fill;
            B_Open.Location = new System.Drawing.Point(0, 0);
            B_Open.Name = "B_Open";
            B_Open.Size = new System.Drawing.Size(306, 121);
            B_Open.TabIndex = 0;
            B_Open.Text = "Open main.dat\r\n\r\nOr...\r\n\r\nDrag && Drop folder here!";
            B_Open.UseVisualStyleBackColor = true;
            B_Open.Click += Menu_Open;
            // 
            // Main
            // 
            AllowDrop = true;
            ClientSize = new System.Drawing.Size(306, 121);
            Controls.Add(B_Open);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = Properties.Resources.icon;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "NHSE";
            DragDrop += Main_DragDrop;
            DragEnter += Main_DragEnter;
            KeyDown += Main_KeyDown;
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_Open;
    }
}


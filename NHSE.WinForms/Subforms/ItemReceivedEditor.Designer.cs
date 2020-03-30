namespace NHSE.WinForms
{
    partial class ItemReceivedEditor
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
            this.CLB_Items = new System.Windows.Forms.CheckedListBox();
            this.B_AllBugs = new System.Windows.Forms.Button();
            this.B_AllFish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(130, 280);
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
            this.B_Save.Location = new System.Drawing.Point(208, 280);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(72, 23);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // CLB_Items
            // 
            this.CLB_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CLB_Items.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLB_Items.FormattingEnabled = true;
            this.CLB_Items.Location = new System.Drawing.Point(12, 12);
            this.CLB_Items.Name = "CLB_Items";
            this.CLB_Items.Size = new System.Drawing.Size(268, 229);
            this.CLB_Items.TabIndex = 8;
            // 
            // B_AllBugs
            // 
            this.B_AllBugs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_AllBugs.Location = new System.Drawing.Point(12, 252);
            this.B_AllBugs.Name = "B_AllBugs";
            this.B_AllBugs.Size = new System.Drawing.Size(82, 23);
            this.B_AllBugs.TabIndex = 11;
            this.B_AllBugs.Text = "Give All Bugs";
            this.B_AllBugs.UseVisualStyleBackColor = true;
            this.B_AllBugs.Click += new System.EventHandler(this.B_AllBugs_Click);
            // 
            // B_AllFish
            // 
            this.B_AllFish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_AllFish.Location = new System.Drawing.Point(12, 280);
            this.B_AllFish.Name = "B_AllFish";
            this.B_AllFish.Size = new System.Drawing.Size(82, 23);
            this.B_AllFish.TabIndex = 12;
            this.B_AllFish.Text = "Give All Fish";
            this.B_AllFish.UseVisualStyleBackColor = true;
            this.B_AllFish.Click += new System.EventHandler(this.B_AllFish_Click);
            // 
            // ItemReceivedEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 315);
            this.Controls.Add(this.B_AllFish);
            this.Controls.Add(this.B_AllBugs);
            this.Controls.Add(this.CLB_Items);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemReceivedEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Received Item List Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.CheckedListBox CLB_Items;
        private System.Windows.Forms.Button B_AllBugs;
        private System.Windows.Forms.Button B_AllFish;
    }
}
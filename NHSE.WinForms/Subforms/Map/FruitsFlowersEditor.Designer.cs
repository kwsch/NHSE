namespace NHSE.WinForms
{
    partial class FruitsFlowersEditor
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
            CB_SisterFlower = new System.Windows.Forms.ComboBox();
            CB_ProfileFlower = new System.Windows.Forms.ComboBox();
            L_ProfileSisterFlower = new System.Windows.Forms.Label();
            L_ProfileSpecialtyFlower = new System.Windows.Forms.Label();
            RIS_SisterFruit = new RestrictedItemSelect();
            L_ProfileSisterFruit = new System.Windows.Forms.Label();
            RIS_ProfileFruit = new RestrictedItemSelect();
            L_ProfileSpecialtyFruit = new System.Windows.Forms.Label();
            B_Cancel = new System.Windows.Forms.Button();
            B_Save = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // CB_SisterFlower
            // 
            CB_SisterFlower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_SisterFlower.FormattingEnabled = true;
            CB_SisterFlower.Location = new System.Drawing.Point(186, 106);
            CB_SisterFlower.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CB_SisterFlower.Name = "CB_SisterFlower";
            CB_SisterFlower.Size = new System.Drawing.Size(162, 23);
            CB_SisterFlower.TabIndex = 71;
            // 
            // CB_ProfileFlower
            // 
            CB_ProfileFlower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_ProfileFlower.FormattingEnabled = true;
            CB_ProfileFlower.Location = new System.Drawing.Point(9, 106);
            CB_ProfileFlower.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CB_ProfileFlower.Name = "CB_ProfileFlower";
            CB_ProfileFlower.Size = new System.Drawing.Size(164, 23);
            CB_ProfileFlower.TabIndex = 70;
            // 
            // L_ProfileSisterFlower
            // 
            L_ProfileSisterFlower.AutoSize = true;
            L_ProfileSisterFlower.Location = new System.Drawing.Point(183, 88);
            L_ProfileSisterFlower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_ProfileSisterFlower.Name = "L_ProfileSisterFlower";
            L_ProfileSisterFlower.Size = new System.Drawing.Size(81, 15);
            L_ProfileSisterFlower.TabIndex = 69;
            L_ProfileSisterFlower.Text = "Flower (Sister)";
            // 
            // L_ProfileSpecialtyFlower
            // 
            L_ProfileSpecialtyFlower.AutoSize = true;
            L_ProfileSpecialtyFlower.Location = new System.Drawing.Point(6, 88);
            L_ProfileSpecialtyFlower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_ProfileSpecialtyFlower.Name = "L_ProfileSpecialtyFlower";
            L_ProfileSpecialtyFlower.Size = new System.Drawing.Size(81, 15);
            L_ProfileSpecialtyFlower.TabIndex = 68;
            L_ProfileSpecialtyFlower.Text = "Flower (Local)";
            // 
            // RIS_SisterFruit
            // 
            RIS_SisterFruit.Location = new System.Drawing.Point(186, 26);
            RIS_SisterFruit.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            RIS_SisterFruit.Name = "RIS_SisterFruit";
            RIS_SisterFruit.Size = new System.Drawing.Size(167, 55);
            RIS_SisterFruit.TabIndex = 67;
            // 
            // L_ProfileSisterFruit
            // 
            L_ProfileSisterFruit.AutoSize = true;
            L_ProfileSisterFruit.Location = new System.Drawing.Point(182, 8);
            L_ProfileSisterFruit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_ProfileSisterFruit.Name = "L_ProfileSisterFruit";
            L_ProfileSisterFruit.Size = new System.Drawing.Size(70, 15);
            L_ProfileSisterFruit.TabIndex = 66;
            L_ProfileSisterFruit.Text = "Fruit (Sister)";
            // 
            // RIS_ProfileFruit
            // 
            RIS_ProfileFruit.Location = new System.Drawing.Point(9, 26);
            RIS_ProfileFruit.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            RIS_ProfileFruit.Name = "RIS_ProfileFruit";
            RIS_ProfileFruit.Size = new System.Drawing.Size(167, 55);
            RIS_ProfileFruit.TabIndex = 65;
            // 
            // L_ProfileSpecialtyFruit
            // 
            L_ProfileSpecialtyFruit.AutoSize = true;
            L_ProfileSpecialtyFruit.Location = new System.Drawing.Point(6, 8);
            L_ProfileSpecialtyFruit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_ProfileSpecialtyFruit.Name = "L_ProfileSpecialtyFruit";
            L_ProfileSpecialtyFruit.Size = new System.Drawing.Size(70, 15);
            L_ProfileSpecialtyFruit.TabIndex = 64;
            L_ProfileSpecialtyFruit.Text = "Fruit (Local)";
            // 
            // B_Cancel
            // 
            B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Cancel.Location = new System.Drawing.Point(173, 157);
            B_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Cancel.Name = "B_Cancel";
            B_Cancel.Size = new System.Drawing.Size(84, 27);
            B_Cancel.TabIndex = 73;
            B_Cancel.Text = "Cancel";
            B_Cancel.UseVisualStyleBackColor = true;
            B_Cancel.Click += B_Cancel_Click;
            // 
            // B_Save
            // 
            B_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Save.Location = new System.Drawing.Point(264, 157);
            B_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Save.Name = "B_Save";
            B_Save.Size = new System.Drawing.Size(84, 27);
            B_Save.TabIndex = 72;
            B_Save.Text = "Save";
            B_Save.UseVisualStyleBackColor = true;
            B_Save.Click += B_Save_Click;
            // 
            // FruitsFlowersEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(361, 196);
            Controls.Add(B_Cancel);
            Controls.Add(B_Save);
            Controls.Add(CB_SisterFlower);
            Controls.Add(CB_ProfileFlower);
            Controls.Add(L_ProfileSisterFlower);
            Controls.Add(L_ProfileSpecialtyFlower);
            Controls.Add(RIS_SisterFruit);
            Controls.Add(L_ProfileSisterFruit);
            Controls.Add(RIS_ProfileFruit);
            Controls.Add(L_ProfileSpecialtyFruit);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = Properties.Resources.icon;
            MaximizeBox = false;
            Name = "FruitsFlowersEditor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Fruits Flowers Editor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox CB_SisterFlower;
        private System.Windows.Forms.ComboBox CB_ProfileFlower;
        private System.Windows.Forms.Label L_ProfileSisterFlower;
        private System.Windows.Forms.Label L_ProfileSpecialtyFlower;
        private RestrictedItemSelect RIS_SisterFruit;
        private System.Windows.Forms.Label L_ProfileSisterFruit;
        private RestrictedItemSelect RIS_ProfileFruit;
        private System.Windows.Forms.Label L_ProfileSpecialtyFruit;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
    }
}
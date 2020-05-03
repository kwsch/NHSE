namespace NHSE.WinForms
{
    partial class BuildingHelp
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
            this.L_StructureValues = new System.Windows.Forms.Label();
            this.CB_StructureValues = new System.Windows.Forms.ComboBox();
            this.L_StructureType = new System.Windows.Forms.Label();
            this.CB_StructureType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // L_StructureValues
            // 
            this.L_StructureValues.AutoSize = true;
            this.L_StructureValues.Location = new System.Drawing.Point(12, 55);
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
            this.CB_StructureValues.Location = new System.Drawing.Point(15, 71);
            this.CB_StructureValues.Name = "CB_StructureValues";
            this.CB_StructureValues.Size = new System.Drawing.Size(221, 21);
            this.CB_StructureValues.TabIndex = 21;
            // 
            // L_StructureType
            // 
            this.L_StructureType.AutoSize = true;
            this.L_StructureType.Location = new System.Drawing.Point(12, 9);
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
            this.CB_StructureType.Location = new System.Drawing.Point(15, 26);
            this.CB_StructureType.Name = "CB_StructureType";
            this.CB_StructureType.Size = new System.Drawing.Size(221, 21);
            this.CB_StructureType.TabIndex = 0;
            this.CB_StructureType.SelectedIndexChanged += new System.EventHandler(this.CB_StructureType_SelectedIndexChanged);
            // 
            // BuildingHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 107);
            this.Controls.Add(this.L_StructureValues);
            this.Controls.Add(this.CB_StructureValues);
            this.Controls.Add(this.CB_StructureType);
            this.Controls.Add(this.L_StructureType);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuildingHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Building Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label L_StructureValues;
        private System.Windows.Forms.ComboBox CB_StructureValues;
        private System.Windows.Forms.Label L_StructureType;
        private System.Windows.Forms.ComboBox CB_StructureType;
    }
}
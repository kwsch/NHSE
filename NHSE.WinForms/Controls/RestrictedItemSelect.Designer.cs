namespace NHSE.WinForms
{
    partial class RestrictedItemSelect
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
            this.CB_ItemID = new System.Windows.Forms.ComboBox();
            this.NUD_CustomItem = new System.Windows.Forms.NumericUpDown();
            this.CHK_CustomItem = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CustomItem)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_ItemID
            // 
            this.CB_ItemID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_ItemID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_ItemID.DropDownWidth = 322;
            this.CB_ItemID.FormattingEnabled = true;
            this.CB_ItemID.Location = new System.Drawing.Point(0, 0);
            this.CB_ItemID.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.CB_ItemID.Name = "CB_ItemID";
            this.CB_ItemID.Size = new System.Drawing.Size(141, 21);
            this.CB_ItemID.TabIndex = 2;
            this.CB_ItemID.SelectedValueChanged += new System.EventHandler(this.CB_ItemID_SelectedValueChanged);
            // 
            // numericUpDown1
            // 
            this.NUD_CustomItem.Location = new System.Drawing.Point(91, 25);
            this.NUD_CustomItem.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NUD_CustomItem.Name = "NUD_CustomItem";
            this.NUD_CustomItem.Size = new System.Drawing.Size(50, 20);
            this.NUD_CustomItem.TabIndex = 3;
            this.NUD_CustomItem.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // CHK_Custom
            // 
            this.CHK_CustomItem.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHK_CustomItem.Location = new System.Drawing.Point(5, 25);
            this.CHK_CustomItem.Name = "CHK_CustomItem";
            this.CHK_CustomItem.Size = new System.Drawing.Size(80, 20);
            this.CHK_CustomItem.TabIndex = 4;
            this.CHK_CustomItem.Text = "Custom";
            this.CHK_CustomItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHK_CustomItem.UseVisualStyleBackColor = true;
            this.CHK_CustomItem.CheckedChanged += new System.EventHandler(this.CHK_Custom_CheckedChanged);
            // 
            // RestrictedItemSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CHK_CustomItem);
            this.Controls.Add(this.NUD_CustomItem);
            this.Controls.Add(this.CB_ItemID);
            this.Name = "RestrictedItemSelect";
            this.Size = new System.Drawing.Size(143, 48);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CustomItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_ItemID;
        private System.Windows.Forms.NumericUpDown NUD_CustomItem;
        private System.Windows.Forms.CheckBox CHK_CustomItem;
    }
}

namespace NHSE.WinForms
{
    partial class BatchEditor
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
            this.L_PropValue = new System.Windows.Forms.Label();
            this.L_PropType = new System.Windows.Forms.Label();
            this.B_Add = new System.Windows.Forms.Button();
            this.CB_Require = new System.Windows.Forms.ComboBox();
            this.CB_Property = new System.Windows.Forms.ComboBox();
            this.CB_Format = new System.Windows.Forms.ComboBox();
            this.PB_Show = new System.Windows.Forms.ProgressBar();
            this.B_Go = new System.Windows.Forms.Button();
            this.RTB_Instructions = new System.Windows.Forms.RichTextBox();
            this.b = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // L_PropValue
            // 
            this.L_PropValue.AutoSize = true;
            this.L_PropValue.Location = new System.Drawing.Point(205, 36);
            this.L_PropValue.Name = "L_PropValue";
            this.L_PropValue.Size = new System.Drawing.Size(73, 13);
            this.L_PropValue.TabIndex = 22;
            this.L_PropValue.Text = "PropertyValue";
            // 
            // L_PropType
            // 
            this.L_PropType.AutoSize = true;
            this.L_PropType.Location = new System.Drawing.Point(59, 36);
            this.L_PropType.Name = "L_PropType";
            this.L_PropType.Size = new System.Drawing.Size(70, 13);
            this.L_PropType.TabIndex = 21;
            this.L_PropType.Text = "PropertyType";
            // 
            // B_Add
            // 
            this.B_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Add.Location = new System.Drawing.Point(325, 11);
            this.B_Add.Name = "B_Add";
            this.B_Add.Size = new System.Drawing.Size(57, 23);
            this.B_Add.TabIndex = 20;
            this.B_Add.Text = "Add";
            this.B_Add.UseVisualStyleBackColor = true;
            this.B_Add.Click += new System.EventHandler(this.B_Add_Click);
            // 
            // CB_Require
            // 
            this.CB_Require.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Require.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Require.FormattingEnabled = true;
            this.CB_Require.Items.AddRange(new object[] {
            "Set Equal To",
            "Require Equals",
            "Require Not Equals"});
            this.CB_Require.Location = new System.Drawing.Point(208, 12);
            this.CB_Require.Name = "CB_Require";
            this.CB_Require.Size = new System.Drawing.Size(111, 21);
            this.CB_Require.TabIndex = 19;
            // 
            // CB_Property
            // 
            this.CB_Property.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Property.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_Property.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Property.DropDownWidth = 200;
            this.CB_Property.FormattingEnabled = true;
            this.CB_Property.Location = new System.Drawing.Point(62, 12);
            this.CB_Property.Name = "CB_Property";
            this.CB_Property.Size = new System.Drawing.Size(140, 21);
            this.CB_Property.TabIndex = 18;
            this.CB_Property.SelectedIndexChanged += new System.EventHandler(this.CB_Property_SelectedIndexChanged);
            // 
            // CB_Format
            // 
            this.CB_Format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Format.FormattingEnabled = true;
            this.CB_Format.Location = new System.Drawing.Point(12, 12);
            this.CB_Format.Name = "CB_Format";
            this.CB_Format.Size = new System.Drawing.Size(44, 21);
            this.CB_Format.TabIndex = 17;
            this.CB_Format.SelectedIndexChanged += new System.EventHandler(this.CB_Format_SelectedIndexChanged);
            // 
            // PB_Show
            // 
            this.PB_Show.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_Show.Location = new System.Drawing.Point(13, 220);
            this.PB_Show.Name = "PB_Show";
            this.PB_Show.Size = new System.Drawing.Size(307, 21);
            this.PB_Show.TabIndex = 16;
            // 
            // B_Go
            // 
            this.B_Go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Go.Location = new System.Drawing.Point(326, 219);
            this.B_Go.Name = "B_Go";
            this.B_Go.Size = new System.Drawing.Size(57, 23);
            this.B_Go.TabIndex = 15;
            this.B_Go.Text = "Run";
            this.B_Go.UseVisualStyleBackColor = true;
            this.B_Go.Click += new System.EventHandler(this.B_Go_Click);
            // 
            // RTB_Instructions
            // 
            this.RTB_Instructions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB_Instructions.Location = new System.Drawing.Point(13, 56);
            this.RTB_Instructions.Name = "RTB_Instructions";
            this.RTB_Instructions.Size = new System.Drawing.Size(370, 158);
            this.RTB_Instructions.TabIndex = 14;
            this.RTB_Instructions.Text = "";
            // 
            // b
            // 
            this.b.WorkerReportsProgress = true;
            // 
            // BatchEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 254);
            this.Controls.Add(this.L_PropValue);
            this.Controls.Add(this.L_PropType);
            this.Controls.Add(this.B_Add);
            this.Controls.Add(this.CB_Require);
            this.Controls.Add(this.CB_Property);
            this.Controls.Add(this.CB_Format);
            this.Controls.Add(this.PB_Show);
            this.Controls.Add(this.B_Go);
            this.Controls.Add(this.RTB_Instructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SysBotRAMEdit_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_PropValue;
        private System.Windows.Forms.Label L_PropType;
        private System.Windows.Forms.Button B_Add;
        private System.Windows.Forms.ComboBox CB_Require;
        private System.Windows.Forms.ComboBox CB_Property;
        private System.Windows.Forms.ComboBox CB_Format;
        private System.Windows.Forms.ProgressBar PB_Show;
        private System.Windows.Forms.Button B_Go;
        private System.Windows.Forms.RichTextBox RTB_Instructions;
        private System.ComponentModel.BackgroundWorker b;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
    }
}
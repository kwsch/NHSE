namespace NHSE.WinForms
{
    partial class RecipeListEditor
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
            this.CLB_Recipes = new System.Windows.Forms.CheckedListBox();
            this.B_All = new System.Windows.Forms.Button();
            this.CB_Goto = new System.Windows.Forms.ComboBox();
            this.L_Goto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(130, 326);
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
            this.B_Save.Location = new System.Drawing.Point(208, 326);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(72, 23);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // CLB_Recipes
            // 
            this.CLB_Recipes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CLB_Recipes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLB_Recipes.FormattingEnabled = true;
            this.CLB_Recipes.Location = new System.Drawing.Point(12, 39);
            this.CLB_Recipes.Name = "CLB_Recipes";
            this.CLB_Recipes.Size = new System.Drawing.Size(268, 274);
            this.CLB_Recipes.TabIndex = 8;
            // 
            // B_All
            // 
            this.B_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_All.Location = new System.Drawing.Point(12, 327);
            this.B_All.Name = "B_All";
            this.B_All.Size = new System.Drawing.Size(82, 23);
            this.B_All.TabIndex = 10;
            this.B_All.Text = "Give All";
            this.B_All.UseVisualStyleBackColor = true;
            this.B_All.Click += new System.EventHandler(this.B_All_Click);
            // 
            // CB_Goto
            // 
            this.CB_Goto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Goto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_Goto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Goto.FormattingEnabled = true;
            this.CB_Goto.Location = new System.Drawing.Point(78, 12);
            this.CB_Goto.Name = "CB_Goto";
            this.CB_Goto.Size = new System.Drawing.Size(202, 21);
            this.CB_Goto.TabIndex = 11;
            this.CB_Goto.SelectedValueChanged += new System.EventHandler(this.CB_Goto_SelectedValueChanged);
            // 
            // L_Goto
            // 
            this.L_Goto.Location = new System.Drawing.Point(12, 12);
            this.L_Goto.Name = "L_Goto";
            this.L_Goto.Size = new System.Drawing.Size(60, 21);
            this.L_Goto.TabIndex = 12;
            this.L_Goto.Text = "goto:";
            this.L_Goto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RecipeListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 361);
            this.Controls.Add(this.L_Goto);
            this.Controls.Add(this.CB_Goto);
            this.Controls.Add(this.B_All);
            this.Controls.Add(this.CLB_Recipes);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecipeListEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recipe List Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.CheckedListBox CLB_Recipes;
        private System.Windows.Forms.Button B_All;
        private System.Windows.Forms.ComboBox CB_Goto;
        private System.Windows.Forms.Label L_Goto;
    }
}
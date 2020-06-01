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
            this.B_All = new System.Windows.Forms.Button();
            this.CB_Goto = new System.Windows.Forms.ComboBox();
            this.L_Goto = new System.Windows.Forms.Label();
            this.LB_Recipes = new System.Windows.Forms.ListBox();
            this.CHK_Known = new System.Windows.Forms.CheckBox();
            this.CHK_Made = new System.Windows.Forms.CheckBox();
            this.CHK_Favorite = new System.Windows.Forms.CheckBox();
            this.CHK_New = new System.Windows.Forms.CheckBox();
            this.B_ClearAll = new System.Windows.Forms.Button();
            this.B_CraftAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(242, 346);
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
            this.B_Save.Location = new System.Drawing.Point(320, 346);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(72, 23);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_All
            // 
            this.B_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_All.Location = new System.Drawing.Point(290, 200);
            this.B_All.Name = "B_All";
            this.B_All.Size = new System.Drawing.Size(82, 23);
            this.B_All.TabIndex = 10;
            this.B_All.Text = "Learn All";
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
            this.CB_Goto.Size = new System.Drawing.Size(206, 21);
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
            // LB_Recipes
            // 
            this.LB_Recipes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_Recipes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Recipes.FormattingEnabled = true;
            this.LB_Recipes.ItemHeight = 14;
            this.LB_Recipes.Location = new System.Drawing.Point(12, 39);
            this.LB_Recipes.Name = "LB_Recipes";
            this.LB_Recipes.Size = new System.Drawing.Size(272, 298);
            this.LB_Recipes.TabIndex = 13;
            this.LB_Recipes.SelectedIndexChanged += new System.EventHandler(this.LB_Recipes_SelectedIndexChanged);
            // 
            // CHK_Known
            // 
            this.CHK_Known.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CHK_Known.Location = new System.Drawing.Point(290, 39);
            this.CHK_Known.Name = "CHK_Known";
            this.CHK_Known.Size = new System.Drawing.Size(102, 17);
            this.CHK_Known.TabIndex = 14;
            this.CHK_Known.Text = "Known";
            this.CHK_Known.UseVisualStyleBackColor = true;
            this.CHK_Known.CheckedChanged += new System.EventHandler(this.CHK_Known_CheckedChanged);
            // 
            // CHK_Made
            // 
            this.CHK_Made.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CHK_Made.Location = new System.Drawing.Point(290, 62);
            this.CHK_Made.Name = "CHK_Made";
            this.CHK_Made.Size = new System.Drawing.Size(102, 17);
            this.CHK_Made.TabIndex = 15;
            this.CHK_Made.Text = "Crafted";
            this.CHK_Made.UseVisualStyleBackColor = true;
            // 
            // CHK_Favorite
            // 
            this.CHK_Favorite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CHK_Favorite.Location = new System.Drawing.Point(290, 85);
            this.CHK_Favorite.Name = "CHK_Favorite";
            this.CHK_Favorite.Size = new System.Drawing.Size(102, 17);
            this.CHK_Favorite.TabIndex = 16;
            this.CHK_Favorite.Text = "Favorite";
            this.CHK_Favorite.UseVisualStyleBackColor = true;
            // 
            // CHK_New
            // 
            this.CHK_New.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CHK_New.Location = new System.Drawing.Point(290, 108);
            this.CHK_New.Name = "CHK_New";
            this.CHK_New.Size = new System.Drawing.Size(102, 17);
            this.CHK_New.TabIndex = 17;
            this.CHK_New.Text = "New";
            this.CHK_New.UseVisualStyleBackColor = true;
            // 
            // B_ClearAll
            // 
            this.B_ClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_ClearAll.Location = new System.Drawing.Point(290, 275);
            this.B_ClearAll.Name = "B_ClearAll";
            this.B_ClearAll.Size = new System.Drawing.Size(82, 23);
            this.B_ClearAll.TabIndex = 18;
            this.B_ClearAll.Text = "Clear All";
            this.B_ClearAll.UseVisualStyleBackColor = true;
            this.B_ClearAll.Click += new System.EventHandler(this.B_ClearAll_Click);
            // 
            // B_CraftAll
            // 
            this.B_CraftAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_CraftAll.Location = new System.Drawing.Point(290, 229);
            this.B_CraftAll.Name = "B_CraftAll";
            this.B_CraftAll.Size = new System.Drawing.Size(82, 23);
            this.B_CraftAll.TabIndex = 19;
            this.B_CraftAll.Text = "Craft All";
            this.B_CraftAll.UseVisualStyleBackColor = true;
            this.B_CraftAll.Click += new System.EventHandler(this.B_CraftAll_Click);
            // 
            // RecipeListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 381);
            this.Controls.Add(this.B_CraftAll);
            this.Controls.Add(this.B_ClearAll);
            this.Controls.Add(this.CHK_New);
            this.Controls.Add(this.CHK_Favorite);
            this.Controls.Add(this.CHK_Made);
            this.Controls.Add(this.CHK_Known);
            this.Controls.Add(this.LB_Recipes);
            this.Controls.Add(this.L_Goto);
            this.Controls.Add(this.CB_Goto);
            this.Controls.Add(this.B_All);
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
        private System.Windows.Forms.Button B_All;
        private System.Windows.Forms.ComboBox CB_Goto;
        private System.Windows.Forms.Label L_Goto;
        private System.Windows.Forms.ListBox LB_Recipes;
        private System.Windows.Forms.CheckBox CHK_Known;
        private System.Windows.Forms.CheckBox CHK_Made;
        private System.Windows.Forms.CheckBox CHK_Favorite;
        private System.Windows.Forms.CheckBox CHK_New;
        private System.Windows.Forms.Button B_ClearAll;
        private System.Windows.Forms.Button B_CraftAll;
    }
}

namespace NHSE.WinForms
{
    partial class VillagerDIYTimerEditor
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
            this.CHK_Crafting = new System.Windows.Forms.CheckBox();
            this.DT_Time = new System.Windows.Forms.DateTimePicker();
            this.L_EndTime = new System.Windows.Forms.Label();
            this.L_Recipe = new System.Windows.Forms.Label();
            this.CB_Recipe = new System.Windows.Forms.ComboBox();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CHK_Crafting
            // 
            this.CHK_Crafting.AutoSize = true;
            this.CHK_Crafting.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHK_Crafting.Location = new System.Drawing.Point(21, 13);
            this.CHK_Crafting.Name = "CHK_Crafting";
            this.CHK_Crafting.Size = new System.Drawing.Size(78, 17);
            this.CHK_Crafting.TabIndex = 1;
            this.CHK_Crafting.Text = "Is crafting?";
            this.CHK_Crafting.UseVisualStyleBackColor = true;
            this.CHK_Crafting.CheckedChanged += new System.EventHandler(this.CHK_Crafting_CheckedChanged);
            // 
            // DT_Time
            // 
            this.DT_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DT_Time.Location = new System.Drawing.Point(91, 38);
            this.DT_Time.Name = "DT_Time";
            this.DT_Time.ShowUpDown = true;
            this.DT_Time.Size = new System.Drawing.Size(78, 20);
            this.DT_Time.TabIndex = 2;
            this.DT_Time.ValueChanged += new System.EventHandler(this.DT_Time_ValueChanged);
            // 
            // L_EndTime
            // 
            this.L_EndTime.AutoSize = true;
            this.L_EndTime.Location = new System.Drawing.Point(21, 41);
            this.L_EndTime.Name = "L_EndTime";
            this.L_EndTime.Size = new System.Drawing.Size(68, 13);
            this.L_EndTime.TabIndex = 3;
            this.L_EndTime.Text = "Crafting until:";
            // 
            // L_Recipe
            // 
            this.L_Recipe.AutoSize = true;
            this.L_Recipe.Location = new System.Drawing.Point(20, 68);
            this.L_Recipe.Name = "L_Recipe";
            this.L_Recipe.Size = new System.Drawing.Size(44, 13);
            this.L_Recipe.TabIndex = 4;
            this.L_Recipe.Text = "Recipe:";
            // 
            // CB_Recipe
            // 
            this.CB_Recipe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_Recipe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Recipe.DropDownWidth = 322;
            this.CB_Recipe.FormattingEnabled = true;
            this.CB_Recipe.Location = new System.Drawing.Point(65, 66);
            this.CB_Recipe.Name = "CB_Recipe";
            this.CB_Recipe.Size = new System.Drawing.Size(160, 21);
            this.CB_Recipe.TabIndex = 5;
            this.CB_Recipe.SelectedIndexChanged += new System.EventHandler(this.CB_Recipe_SelectedIndexChanged);
            // 
            // B_Save
            // 
            this.B_Save.Location = new System.Drawing.Point(21, 100);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(92, 23);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(133, 100);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(92, 23);
            this.B_Cancel.TabIndex = 7;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // VillagerDIYTimerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 142);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Controls.Add(this.CB_Recipe);
            this.Controls.Add(this.L_Recipe);
            this.Controls.Add(this.L_EndTime);
            this.Controls.Add(this.DT_Time);
            this.Controls.Add(this.CHK_Crafting);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.Name = "VillagerDIYTimerEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Villager DIY Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CHK_Crafting;
        private System.Windows.Forms.DateTimePicker DT_Time;
        private System.Windows.Forms.Label L_EndTime;
        private System.Windows.Forms.Label L_Recipe;
        private System.Windows.Forms.ComboBox CB_Recipe;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
    }
}
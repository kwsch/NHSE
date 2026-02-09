namespace NHSE.WinForms
{
    partial class SingleItemEditor
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
            B_Save = new System.Windows.Forms.Button();
            B_Cancel = new System.Windows.Forms.Button();
            ItemEditor = new ItemEditor();
            SuspendLayout();
            // 
            // B_Save
            // 
            B_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Save.Location = new System.Drawing.Point(94, 339);
            B_Save.Name = "B_Save";
            B_Save.Size = new System.Drawing.Size(75, 31);
            B_Save.TabIndex = 1;
            B_Save.Text = "Save";
            B_Save.UseVisualStyleBackColor = true;
            B_Save.Click += B_Save_Click;
            // 
            // B_Cancel
            // 
            B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Cancel.Location = new System.Drawing.Point(13, 339);
            B_Cancel.Name = "B_Cancel";
            B_Cancel.Size = new System.Drawing.Size(75, 31);
            B_Cancel.TabIndex = 2;
            B_Cancel.Text = "Cancel";
            B_Cancel.UseVisualStyleBackColor = true;
            B_Cancel.Click += B_Cancel_Click;
            // 
            // ItemEditor
            // 
            ItemEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ItemEditor.Location = new System.Drawing.Point(12, 12);
            ItemEditor.Name = "ItemEditor";
            ItemEditor.Size = new System.Drawing.Size(157, 316);
            ItemEditor.TabIndex = 3;
            // 
            // SingleItemEditor
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            ClientSize = new System.Drawing.Size(181, 382);
            Controls.Add(ItemEditor);
            Controls.Add(B_Cancel);
            Controls.Add(B_Save);
            Icon = Properties.Resources.icon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SingleItemEditor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Item Editor";
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private ItemEditor ItemEditor;
    }
}
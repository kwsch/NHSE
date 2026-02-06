namespace NHSE.WinForms
{
    partial class PlayerItemEditor
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
            ItemGrid.Dispose();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            B_Cancel = new System.Windows.Forms.Button();
            B_Save = new System.Windows.Forms.Button();
            B_Dump = new System.Windows.Forms.Button();
            B_Load = new System.Windows.Forms.Button();
            PAN_Items = new System.Windows.Forms.Panel();
            B_Inject = new System.Windows.Forms.Button();
            ItemEditor = new ItemEditor();
            SuspendLayout();
            // 
            // B_Cancel
            // 
            B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Cancel.Location = new System.Drawing.Point(840, 398);
            B_Cancel.Name = "B_Cancel";
            B_Cancel.Size = new System.Drawing.Size(72, 23);
            B_Cancel.TabIndex = 5;
            B_Cancel.Text = "Cancel";
            B_Cancel.UseVisualStyleBackColor = true;
            B_Cancel.Click += B_Cancel_Click;
            // 
            // B_Save
            // 
            B_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Save.Location = new System.Drawing.Point(918, 398);
            B_Save.Name = "B_Save";
            B_Save.Size = new System.Drawing.Size(72, 23);
            B_Save.TabIndex = 4;
            B_Save.Text = "Save";
            B_Save.UseVisualStyleBackColor = true;
            B_Save.Click += B_Save_Click;
            // 
            // B_Dump
            // 
            B_Dump.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            B_Dump.Location = new System.Drawing.Point(9, 398);
            B_Dump.Name = "B_Dump";
            B_Dump.Size = new System.Drawing.Size(90, 23);
            B_Dump.TabIndex = 7;
            B_Dump.Text = "Dump";
            B_Dump.UseVisualStyleBackColor = true;
            B_Dump.Click += B_Dump_Click;
            // 
            // B_Load
            // 
            B_Load.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            B_Load.Location = new System.Drawing.Point(105, 398);
            B_Load.Name = "B_Load";
            B_Load.Size = new System.Drawing.Size(90, 23);
            B_Load.TabIndex = 8;
            B_Load.Text = "Load";
            B_Load.UseVisualStyleBackColor = true;
            B_Load.Click += B_Load_Click;
            // 
            // PAN_Items
            // 
            PAN_Items.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            PAN_Items.Location = new System.Drawing.Point(9, 12);
            PAN_Items.Name = "PAN_Items";
            PAN_Items.Size = new System.Drawing.Size(795, 380);
            PAN_Items.TabIndex = 9;
            // 
            // B_Inject
            // 
            B_Inject.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            B_Inject.Location = new System.Drawing.Point(420, 398);
            B_Inject.Name = "B_Inject";
            B_Inject.Size = new System.Drawing.Size(90, 23);
            B_Inject.TabIndex = 10;
            B_Inject.Text = "Inject";
            B_Inject.UseVisualStyleBackColor = true;
            B_Inject.Click += B_Inject_Click;
            // 
            // ItemEditor
            // 
            ItemEditor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ItemEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ItemEditor.Location = new System.Drawing.Point(810, 12);
            ItemEditor.Name = "ItemEditor";
            ItemEditor.Size = new System.Drawing.Size(180, 380);
            ItemEditor.TabIndex = 6;
            // 
            // PlayerItemEditor
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            ClientSize = new System.Drawing.Size(1002, 431);
            Controls.Add(B_Inject);
            Controls.Add(B_Load);
            Controls.Add(B_Dump);
            Controls.Add(ItemEditor);
            Controls.Add(B_Cancel);
            Controls.Add(B_Save);
            Controls.Add(PAN_Items);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = Properties.Resources.icon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PlayerItemEditor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Inventory Editor";
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private ItemEditor ItemEditor;
        private System.Windows.Forms.Button B_Dump;
        private System.Windows.Forms.Button B_Load;
        private System.Windows.Forms.Panel PAN_Items;
        private System.Windows.Forms.Button B_Inject;
    }
}
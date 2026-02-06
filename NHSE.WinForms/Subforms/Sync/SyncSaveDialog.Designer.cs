namespace NHSE.WinForms;

partial class SyncSaveDialog
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
        B_SelectSource = new System.Windows.Forms.Button();
        L_SourceInfo = new System.Windows.Forms.Label();
        GB_Categories = new System.Windows.Forms.GroupBox();
        CLB_Categories = new System.Windows.Forms.CheckedListBox();
        B_SelectAll = new System.Windows.Forms.Button();
        B_SelectNone = new System.Windows.Forms.Button();
        B_Sync = new System.Windows.Forms.Button();
        B_Cancel = new System.Windows.Forms.Button();
        L_Preview = new System.Windows.Forms.Label();
        RTB_Preview = new System.Windows.Forms.RichTextBox();
        GB_Categories.SuspendLayout();
        SuspendLayout();
        // 
        // B_SelectSource
        // 
        B_SelectSource.Location = new System.Drawing.Point(12, 12);
        B_SelectSource.Name = "B_SelectSource";
        B_SelectSource.Size = new System.Drawing.Size(150, 28);
        B_SelectSource.TabIndex = 0;
        B_SelectSource.Text = "Select Source Save...";
        B_SelectSource.UseVisualStyleBackColor = true;
        B_SelectSource.Click += B_SelectSource_Click;
        // 
        // L_SourceInfo
        // 
        L_SourceInfo.AutoSize = true;
        L_SourceInfo.Location = new System.Drawing.Point(168, 19);
        L_SourceInfo.Name = "L_SourceInfo";
        L_SourceInfo.Size = new System.Drawing.Size(100, 15);
        L_SourceInfo.TabIndex = 1;
        L_SourceInfo.Text = "No source selected";
        // 
        // GB_Categories
        // 
        GB_Categories.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        GB_Categories.Controls.Add(CLB_Categories);
        GB_Categories.Controls.Add(B_SelectAll);
        GB_Categories.Controls.Add(B_SelectNone);
        GB_Categories.Location = new System.Drawing.Point(12, 46);
        GB_Categories.Name = "GB_Categories";
        GB_Categories.Size = new System.Drawing.Size(220, 340);
        GB_Categories.TabIndex = 2;
        GB_Categories.TabStop = false;
        GB_Categories.Text = "Sync Categories";
        // 
        // CLB_Categories
        // 
        CLB_Categories.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        CLB_Categories.CheckOnClick = true;
        CLB_Categories.FormattingEnabled = true;
        CLB_Categories.Location = new System.Drawing.Point(6, 22);
        CLB_Categories.Name = "CLB_Categories";
        CLB_Categories.Size = new System.Drawing.Size(208, 274);
        CLB_Categories.TabIndex = 0;
        CLB_Categories.SelectedIndexChanged += CLB_Categories_SelectedIndexChanged;
        // 
        // B_SelectAll
        // 
        B_SelectAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        B_SelectAll.Location = new System.Drawing.Point(6, 305);
        B_SelectAll.Name = "B_SelectAll";
        B_SelectAll.Size = new System.Drawing.Size(100, 28);
        B_SelectAll.TabIndex = 1;
        B_SelectAll.Text = "Select All";
        B_SelectAll.UseVisualStyleBackColor = true;
        B_SelectAll.Click += B_SelectAll_Click;
        // 
        // B_SelectNone
        // 
        B_SelectNone.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        B_SelectNone.Location = new System.Drawing.Point(114, 305);
        B_SelectNone.Name = "B_SelectNone";
        B_SelectNone.Size = new System.Drawing.Size(100, 28);
        B_SelectNone.TabIndex = 2;
        B_SelectNone.Text = "Select None";
        B_SelectNone.UseVisualStyleBackColor = true;
        B_SelectNone.Click += B_SelectNone_Click;
        // 
        // B_Sync
        // 
        B_Sync.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        B_Sync.Enabled = false;
        B_Sync.Location = new System.Drawing.Point(497, 392);
        B_Sync.Name = "B_Sync";
        B_Sync.Size = new System.Drawing.Size(100, 32);
        B_Sync.TabIndex = 3;
        B_Sync.Text = "Sync";
        B_Sync.UseVisualStyleBackColor = true;
        B_Sync.Click += B_Sync_Click;
        // 
        // B_Cancel
        // 
        B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        B_Cancel.Location = new System.Drawing.Point(391, 392);
        B_Cancel.Name = "B_Cancel";
        B_Cancel.Size = new System.Drawing.Size(100, 32);
        B_Cancel.TabIndex = 4;
        B_Cancel.Text = "Cancel";
        B_Cancel.UseVisualStyleBackColor = true;
        B_Cancel.Click += B_Cancel_Click;
        // 
        // L_Preview
        // 
        L_Preview.AutoSize = true;
        L_Preview.Location = new System.Drawing.Point(238, 49);
        L_Preview.Name = "L_Preview";
        L_Preview.Size = new System.Drawing.Size(51, 15);
        L_Preview.TabIndex = 5;
        L_Preview.Text = "Preview:";
        // 
        // RTB_Preview
        // 
        RTB_Preview.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        RTB_Preview.Location = new System.Drawing.Point(238, 67);
        RTB_Preview.Name = "RTB_Preview";
        RTB_Preview.ReadOnly = true;
        RTB_Preview.Size = new System.Drawing.Size(359, 319);
        RTB_Preview.TabIndex = 6;
        RTB_Preview.Text = "";
        // 
        // SyncSaveDialog
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(609, 436);
        Controls.Add(RTB_Preview);
        Controls.Add(L_Preview);
        Controls.Add(B_Cancel);
        Controls.Add(B_Sync);
        Controls.Add(GB_Categories);
        Controls.Add(L_SourceInfo);
        Controls.Add(B_SelectSource);
        MinimizeBox = false;
        MinimumSize = new System.Drawing.Size(500, 400);
        Name = "SyncSaveDialog";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Sync Save Data";
        GB_Categories.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Button B_SelectSource;
    private System.Windows.Forms.Label L_SourceInfo;
    private System.Windows.Forms.GroupBox GB_Categories;
    private System.Windows.Forms.CheckedListBox CLB_Categories;
    private System.Windows.Forms.Button B_SelectAll;
    private System.Windows.Forms.Button B_SelectNone;
    private System.Windows.Forms.Button B_Sync;
    private System.Windows.Forms.Button B_Cancel;
    private System.Windows.Forms.Label L_Preview;
    private System.Windows.Forms.RichTextBox RTB_Preview;
}


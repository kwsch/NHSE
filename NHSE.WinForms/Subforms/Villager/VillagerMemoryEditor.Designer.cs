namespace NHSE.WinForms
{
    partial class VillagerMemoryEditor
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
            this.LB_Counts = new System.Windows.Forms.ListBox();
            this.NUD_Count = new System.Windows.Forms.NumericUpDown();
            this.L_Count = new System.Windows.Forms.Label();
            this.LB_Players = new System.Windows.Forms.ListBox();
            this.B_Dump = new System.Windows.Forms.Button();
            this.B_Load = new System.Windows.Forms.Button();
            this.TC_Memory = new System.Windows.Forms.TabControl();
            this.Tab_Flags = new System.Windows.Forms.TabPage();
            this.Tab_Misc = new System.Windows.Forms.TabPage();
            this.TB_NickName = new System.Windows.Forms.TextBox();
            this.L_NickName = new System.Windows.Forms.Label();
            this.Tab_Greet = new System.Windows.Forms.TabPage();
            this.TB_Greeting10 = new System.Windows.Forms.TextBox();
            this.L_Greeting10 = new System.Windows.Forms.Label();
            this.TB_Greeting9 = new System.Windows.Forms.TextBox();
            this.L_Greeting9 = new System.Windows.Forms.Label();
            this.TB_Greeting8 = new System.Windows.Forms.TextBox();
            this.L_Greeting8 = new System.Windows.Forms.Label();
            this.TB_Greeting7 = new System.Windows.Forms.TextBox();
            this.L_Greeting7 = new System.Windows.Forms.Label();
            this.TB_Greeting6 = new System.Windows.Forms.TextBox();
            this.L_Greeting6 = new System.Windows.Forms.Label();
            this.TB_Greeting5 = new System.Windows.Forms.TextBox();
            this.L_Greeting5 = new System.Windows.Forms.Label();
            this.TB_Greeting4 = new System.Windows.Forms.TextBox();
            this.L_Greeting4 = new System.Windows.Forms.Label();
            this.TB_Greeting3 = new System.Windows.Forms.TextBox();
            this.L_Greeting3 = new System.Windows.Forms.Label();
            this.TB_Greeting2 = new System.Windows.Forms.TextBox();
            this.L_Greeting2 = new System.Windows.Forms.Label();
            this.TB_Greeting1 = new System.Windows.Forms.TextBox();
            this.L_Greeting1 = new System.Windows.Forms.Label();
            this.CAL_GreetDate = new System.Windows.Forms.DateTimePicker();
            this.TB_Greeting = new System.Windows.Forms.TextBox();
            this.L_Greeting = new System.Windows.Forms.Label();
            this.LBL_Name = new System.Windows.Forms.Label();
            this.TB_NamePlayer = new System.Windows.Forms.TextBox();
            this.LBL_IslandName = new System.Windows.Forms.Label();
            this.TB_Island = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Count)).BeginInit();
            this.TC_Memory.SuspendLayout();
            this.Tab_Flags.SuspendLayout();
            this.Tab_Misc.SuspendLayout();
            this.Tab_Greet.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(344, 324);
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
            this.B_Save.Location = new System.Drawing.Point(422, 324);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(72, 23);
            this.B_Save.TabIndex = 6;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // LB_Counts
            // 
            this.LB_Counts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_Counts.FormattingEnabled = true;
            this.LB_Counts.Location = new System.Drawing.Point(3, 26);
            this.LB_Counts.Name = "LB_Counts";
            this.LB_Counts.Size = new System.Drawing.Size(299, 251);
            this.LB_Counts.TabIndex = 8;
            this.LB_Counts.SelectedIndexChanged += new System.EventHandler(this.LB_Counts_SelectedIndexChanged);
            // 
            // NUD_Count
            // 
            this.NUD_Count.Location = new System.Drawing.Point(92, 3);
            this.NUD_Count.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NUD_Count.Name = "NUD_Count";
            this.NUD_Count.Size = new System.Drawing.Size(72, 20);
            this.NUD_Count.TabIndex = 9;
            this.NUD_Count.ValueChanged += new System.EventHandler(this.NUD_Count_ValueChanged);
            // 
            // L_Count
            // 
            this.L_Count.Location = new System.Drawing.Point(6, 3);
            this.L_Count.Name = "L_Count";
            this.L_Count.Size = new System.Drawing.Size(80, 20);
            this.L_Count.TabIndex = 10;
            this.L_Count.Text = "Value:";
            this.L_Count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LB_Players
            // 
            this.LB_Players.FormattingEnabled = true;
            this.LB_Players.Location = new System.Drawing.Point(12, 12);
            this.LB_Players.Name = "LB_Players";
            this.LB_Players.Size = new System.Drawing.Size(163, 108);
            this.LB_Players.TabIndex = 11;
            this.LB_Players.SelectedIndexChanged += new System.EventHandler(this.LB_Players_SelectedIndexChanged);
            // 
            // B_Dump
            // 
            this.B_Dump.Location = new System.Drawing.Point(12, 126);
            this.B_Dump.Name = "B_Dump";
            this.B_Dump.Size = new System.Drawing.Size(79, 23);
            this.B_Dump.TabIndex = 13;
            this.B_Dump.Text = "Dump";
            this.B_Dump.UseVisualStyleBackColor = true;
            this.B_Dump.Click += new System.EventHandler(this.B_Dump_Click);
            // 
            // B_Load
            // 
            this.B_Load.Location = new System.Drawing.Point(96, 126);
            this.B_Load.Name = "B_Load";
            this.B_Load.Size = new System.Drawing.Size(79, 23);
            this.B_Load.TabIndex = 12;
            this.B_Load.Text = "Load";
            this.B_Load.UseVisualStyleBackColor = true;
            this.B_Load.Click += new System.EventHandler(this.B_Load_Click);
            // 
            // TC_Memory
            // 
            this.TC_Memory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TC_Memory.Controls.Add(this.Tab_Flags);
            this.TC_Memory.Controls.Add(this.Tab_Misc);
            this.TC_Memory.Controls.Add(this.Tab_Greet);
            this.TC_Memory.Location = new System.Drawing.Point(181, 12);
            this.TC_Memory.Name = "TC_Memory";
            this.TC_Memory.SelectedIndex = 0;
            this.TC_Memory.Size = new System.Drawing.Size(313, 306);
            this.TC_Memory.TabIndex = 15;
            // 
            // Tab_Flags
            // 
            this.Tab_Flags.Controls.Add(this.L_Count);
            this.Tab_Flags.Controls.Add(this.LB_Counts);
            this.Tab_Flags.Controls.Add(this.NUD_Count);
            this.Tab_Flags.Location = new System.Drawing.Point(4, 22);
            this.Tab_Flags.Name = "Tab_Flags";
            this.Tab_Flags.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Flags.Size = new System.Drawing.Size(305, 280);
            this.Tab_Flags.TabIndex = 0;
            this.Tab_Flags.Text = "Flags";
            this.Tab_Flags.UseVisualStyleBackColor = true;
            // 
            // Tab_Misc
            // 
            this.Tab_Misc.Controls.Add(this.TB_NickName);
            this.Tab_Misc.Controls.Add(this.L_NickName);
            this.Tab_Misc.Location = new System.Drawing.Point(4, 22);
            this.Tab_Misc.Name = "Tab_Misc";
            this.Tab_Misc.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Misc.Size = new System.Drawing.Size(305, 280);
            this.Tab_Misc.TabIndex = 1;
            this.Tab_Misc.Text = "Misc";
            this.Tab_Misc.UseVisualStyleBackColor = true;
            // 
            // TB_NickName
            // 
            this.TB_NickName.Location = new System.Drawing.Point(106, 5);
            this.TB_NickName.Name = "TB_NickName";
            this.TB_NickName.Size = new System.Drawing.Size(100, 20);
            this.TB_NickName.TabIndex = 41;
            // 
            // L_NickName
            // 
            this.L_NickName.Location = new System.Drawing.Point(16, 5);
            this.L_NickName.Name = "L_NickName";
            this.L_NickName.Size = new System.Drawing.Size(84, 20);
            this.L_NickName.TabIndex = 40;
            this.L_NickName.Text = "Nickname:";
            this.L_NickName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Tab_Greet
            // 
            this.Tab_Greet.Controls.Add(this.TB_Greeting10);
            this.Tab_Greet.Controls.Add(this.L_Greeting10);
            this.Tab_Greet.Controls.Add(this.TB_Greeting9);
            this.Tab_Greet.Controls.Add(this.L_Greeting9);
            this.Tab_Greet.Controls.Add(this.TB_Greeting8);
            this.Tab_Greet.Controls.Add(this.L_Greeting8);
            this.Tab_Greet.Controls.Add(this.TB_Greeting7);
            this.Tab_Greet.Controls.Add(this.L_Greeting7);
            this.Tab_Greet.Controls.Add(this.TB_Greeting6);
            this.Tab_Greet.Controls.Add(this.L_Greeting6);
            this.Tab_Greet.Controls.Add(this.TB_Greeting5);
            this.Tab_Greet.Controls.Add(this.L_Greeting5);
            this.Tab_Greet.Controls.Add(this.TB_Greeting4);
            this.Tab_Greet.Controls.Add(this.L_Greeting4);
            this.Tab_Greet.Controls.Add(this.TB_Greeting3);
            this.Tab_Greet.Controls.Add(this.L_Greeting3);
            this.Tab_Greet.Controls.Add(this.TB_Greeting2);
            this.Tab_Greet.Controls.Add(this.L_Greeting2);
            this.Tab_Greet.Controls.Add(this.TB_Greeting1);
            this.Tab_Greet.Controls.Add(this.L_Greeting1);
            this.Tab_Greet.Controls.Add(this.CAL_GreetDate);
            this.Tab_Greet.Controls.Add(this.TB_Greeting);
            this.Tab_Greet.Controls.Add(this.L_Greeting);
            this.Tab_Greet.Location = new System.Drawing.Point(4, 22);
            this.Tab_Greet.Name = "Tab_Greet";
            this.Tab_Greet.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Greet.Size = new System.Drawing.Size(305, 280);
            this.Tab_Greet.TabIndex = 2;
            this.Tab_Greet.Text = "Greet";
            this.Tab_Greet.UseVisualStyleBackColor = true;
            // 
            // TB_Greeting10
            // 
            this.TB_Greeting10.Location = new System.Drawing.Point(152, 253);
            this.TB_Greeting10.Name = "TB_Greeting10";
            this.TB_Greeting10.Size = new System.Drawing.Size(100, 20);
            this.TB_Greeting10.TabIndex = 85;
            // 
            // L_Greeting10
            // 
            this.L_Greeting10.Location = new System.Drawing.Point(62, 253);
            this.L_Greeting10.Name = "L_Greeting10";
            this.L_Greeting10.Size = new System.Drawing.Size(84, 20);
            this.L_Greeting10.TabIndex = 84;
            this.L_Greeting10.Text = "Greeting 10:";
            this.L_Greeting10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Greeting9
            // 
            this.TB_Greeting9.Location = new System.Drawing.Point(152, 233);
            this.TB_Greeting9.Name = "TB_Greeting9";
            this.TB_Greeting9.Size = new System.Drawing.Size(100, 20);
            this.TB_Greeting9.TabIndex = 83;
            // 
            // L_Greeting9
            // 
            this.L_Greeting9.Location = new System.Drawing.Point(62, 233);
            this.L_Greeting9.Name = "L_Greeting9";
            this.L_Greeting9.Size = new System.Drawing.Size(84, 20);
            this.L_Greeting9.TabIndex = 82;
            this.L_Greeting9.Text = "Greeting 9:";
            this.L_Greeting9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Greeting8
            // 
            this.TB_Greeting8.Location = new System.Drawing.Point(152, 213);
            this.TB_Greeting8.Name = "TB_Greeting8";
            this.TB_Greeting8.Size = new System.Drawing.Size(100, 20);
            this.TB_Greeting8.TabIndex = 81;
            // 
            // L_Greeting8
            // 
            this.L_Greeting8.Location = new System.Drawing.Point(62, 213);
            this.L_Greeting8.Name = "L_Greeting8";
            this.L_Greeting8.Size = new System.Drawing.Size(84, 20);
            this.L_Greeting8.TabIndex = 80;
            this.L_Greeting8.Text = "Greeting 8:";
            this.L_Greeting8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Greeting7
            // 
            this.TB_Greeting7.Location = new System.Drawing.Point(152, 193);
            this.TB_Greeting7.Name = "TB_Greeting7";
            this.TB_Greeting7.Size = new System.Drawing.Size(100, 20);
            this.TB_Greeting7.TabIndex = 79;
            // 
            // L_Greeting7
            // 
            this.L_Greeting7.Location = new System.Drawing.Point(62, 193);
            this.L_Greeting7.Name = "L_Greeting7";
            this.L_Greeting7.Size = new System.Drawing.Size(84, 20);
            this.L_Greeting7.TabIndex = 78;
            this.L_Greeting7.Text = "Greeting 7:";
            this.L_Greeting7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Greeting6
            // 
            this.TB_Greeting6.Location = new System.Drawing.Point(152, 173);
            this.TB_Greeting6.Name = "TB_Greeting6";
            this.TB_Greeting6.Size = new System.Drawing.Size(100, 20);
            this.TB_Greeting6.TabIndex = 77;
            // 
            // L_Greeting6
            // 
            this.L_Greeting6.Location = new System.Drawing.Point(62, 173);
            this.L_Greeting6.Name = "L_Greeting6";
            this.L_Greeting6.Size = new System.Drawing.Size(84, 20);
            this.L_Greeting6.TabIndex = 76;
            this.L_Greeting6.Text = "Greeting 6:";
            this.L_Greeting6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Greeting5
            // 
            this.TB_Greeting5.Location = new System.Drawing.Point(152, 153);
            this.TB_Greeting5.Name = "TB_Greeting5";
            this.TB_Greeting5.Size = new System.Drawing.Size(100, 20);
            this.TB_Greeting5.TabIndex = 75;
            // 
            // L_Greeting5
            // 
            this.L_Greeting5.Location = new System.Drawing.Point(62, 153);
            this.L_Greeting5.Name = "L_Greeting5";
            this.L_Greeting5.Size = new System.Drawing.Size(84, 20);
            this.L_Greeting5.TabIndex = 74;
            this.L_Greeting5.Text = "Greeting 5:";
            this.L_Greeting5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Greeting4
            // 
            this.TB_Greeting4.Location = new System.Drawing.Point(152, 133);
            this.TB_Greeting4.Name = "TB_Greeting4";
            this.TB_Greeting4.Size = new System.Drawing.Size(100, 20);
            this.TB_Greeting4.TabIndex = 73;
            // 
            // L_Greeting4
            // 
            this.L_Greeting4.Location = new System.Drawing.Point(62, 133);
            this.L_Greeting4.Name = "L_Greeting4";
            this.L_Greeting4.Size = new System.Drawing.Size(84, 20);
            this.L_Greeting4.TabIndex = 72;
            this.L_Greeting4.Text = "Greeting 4:";
            this.L_Greeting4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Greeting3
            // 
            this.TB_Greeting3.Location = new System.Drawing.Point(152, 113);
            this.TB_Greeting3.Name = "TB_Greeting3";
            this.TB_Greeting3.Size = new System.Drawing.Size(100, 20);
            this.TB_Greeting3.TabIndex = 71;
            // 
            // L_Greeting3
            // 
            this.L_Greeting3.Location = new System.Drawing.Point(62, 113);
            this.L_Greeting3.Name = "L_Greeting3";
            this.L_Greeting3.Size = new System.Drawing.Size(84, 20);
            this.L_Greeting3.TabIndex = 70;
            this.L_Greeting3.Text = "Greeting 3:";
            this.L_Greeting3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Greeting2
            // 
            this.TB_Greeting2.Location = new System.Drawing.Point(152, 93);
            this.TB_Greeting2.Name = "TB_Greeting2";
            this.TB_Greeting2.Size = new System.Drawing.Size(100, 20);
            this.TB_Greeting2.TabIndex = 69;
            // 
            // L_Greeting2
            // 
            this.L_Greeting2.Location = new System.Drawing.Point(62, 93);
            this.L_Greeting2.Name = "L_Greeting2";
            this.L_Greeting2.Size = new System.Drawing.Size(84, 20);
            this.L_Greeting2.TabIndex = 68;
            this.L_Greeting2.Text = "Greeting 2:";
            this.L_Greeting2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_Greeting1
            // 
            this.TB_Greeting1.Location = new System.Drawing.Point(152, 73);
            this.TB_Greeting1.Name = "TB_Greeting1";
            this.TB_Greeting1.Size = new System.Drawing.Size(100, 20);
            this.TB_Greeting1.TabIndex = 67;
            // 
            // L_Greeting1
            // 
            this.L_Greeting1.Location = new System.Drawing.Point(62, 73);
            this.L_Greeting1.Name = "L_Greeting1";
            this.L_Greeting1.Size = new System.Drawing.Size(84, 20);
            this.L_Greeting1.TabIndex = 66;
            this.L_Greeting1.Text = "Greeting 1:";
            this.L_Greeting1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CAL_GreetDate
            // 
            this.CAL_GreetDate.Location = new System.Drawing.Point(52, 6);
            this.CAL_GreetDate.Name = "CAL_GreetDate";
            this.CAL_GreetDate.Size = new System.Drawing.Size(200, 20);
            this.CAL_GreetDate.TabIndex = 65;
            // 
            // TB_Greeting
            // 
            this.TB_Greeting.Location = new System.Drawing.Point(152, 32);
            this.TB_Greeting.Name = "TB_Greeting";
            this.TB_Greeting.Size = new System.Drawing.Size(100, 20);
            this.TB_Greeting.TabIndex = 64;
            // 
            // L_Greeting
            // 
            this.L_Greeting.Location = new System.Drawing.Point(62, 32);
            this.L_Greeting.Name = "L_Greeting";
            this.L_Greeting.Size = new System.Drawing.Size(84, 20);
            this.L_Greeting.TabIndex = 63;
            this.L_Greeting.Text = "Greeting:";
            this.L_Greeting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBL_Name
            // 
            this.LBL_Name.AutoSize = true;
            this.LBL_Name.Location = new System.Drawing.Point(12, 159);
            this.LBL_Name.Name = "LBL_Name";
            this.LBL_Name.Size = new System.Drawing.Size(38, 13);
            this.LBL_Name.TabIndex = 16;
            this.LBL_Name.Text = "Name:";
            // 
            // TB_NamePlayer
            // 
            this.TB_NamePlayer.Location = new System.Drawing.Point(58, 156);
            this.TB_NamePlayer.Name = "TB_NamePlayer";
            this.TB_NamePlayer.Size = new System.Drawing.Size(100, 20);
            this.TB_NamePlayer.TabIndex = 17;
            this.TB_NamePlayer.TextChanged += new System.EventHandler(this.TB_NamePlayer_TextChanged);
            // 
            // LBL_IslandName
            // 
            this.LBL_IslandName.AutoSize = true;
            this.LBL_IslandName.Location = new System.Drawing.Point(13, 186);
            this.LBL_IslandName.Name = "LBL_IslandName";
            this.LBL_IslandName.Size = new System.Drawing.Size(38, 13);
            this.LBL_IslandName.TabIndex = 16;
            this.LBL_IslandName.Text = "Island:";
            // 
            // TB_Island
            // 
            this.TB_Island.Location = new System.Drawing.Point(58, 182);
            this.TB_Island.Name = "TB_Island";
            this.TB_Island.Size = new System.Drawing.Size(100, 20);
            this.TB_Island.TabIndex = 17;
            this.TB_Island.TextChanged += new System.EventHandler(this.TB_Island_TextChanged);
            // 
            // VillagerMemoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 359);
            this.Controls.Add(this.TB_Island);
            this.Controls.Add(this.LBL_IslandName);
            this.Controls.Add(this.TB_NamePlayer);
            this.Controls.Add(this.LBL_Name);
            this.Controls.Add(this.TC_Memory);
            this.Controls.Add(this.B_Dump);
            this.Controls.Add(this.B_Load);
            this.Controls.Add(this.LB_Players);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Icon = global::NHSE.WinForms.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VillagerMemoryEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Villager Player Memory Editor";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Count)).EndInit();
            this.TC_Memory.ResumeLayout(false);
            this.Tab_Flags.ResumeLayout(false);
            this.Tab_Misc.ResumeLayout(false);
            this.Tab_Misc.PerformLayout();
            this.Tab_Greet.ResumeLayout(false);
            this.Tab_Greet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.ListBox LB_Counts;
        private System.Windows.Forms.NumericUpDown NUD_Count;
        private System.Windows.Forms.Label L_Count;
        private System.Windows.Forms.ListBox LB_Players;
        private System.Windows.Forms.Button B_Dump;
        private System.Windows.Forms.Button B_Load;
        private System.Windows.Forms.TabControl TC_Memory;
        private System.Windows.Forms.TabPage Tab_Flags;
        private System.Windows.Forms.TabPage Tab_Misc;
        private System.Windows.Forms.TextBox TB_NickName;
        private System.Windows.Forms.Label L_NickName;
        private System.Windows.Forms.TabPage Tab_Greet;
        private System.Windows.Forms.TextBox TB_Greeting10;
        private System.Windows.Forms.Label L_Greeting10;
        private System.Windows.Forms.TextBox TB_Greeting9;
        private System.Windows.Forms.Label L_Greeting9;
        private System.Windows.Forms.TextBox TB_Greeting8;
        private System.Windows.Forms.Label L_Greeting8;
        private System.Windows.Forms.TextBox TB_Greeting7;
        private System.Windows.Forms.Label L_Greeting7;
        private System.Windows.Forms.TextBox TB_Greeting6;
        private System.Windows.Forms.Label L_Greeting6;
        private System.Windows.Forms.TextBox TB_Greeting5;
        private System.Windows.Forms.Label L_Greeting5;
        private System.Windows.Forms.TextBox TB_Greeting4;
        private System.Windows.Forms.Label L_Greeting4;
        private System.Windows.Forms.TextBox TB_Greeting3;
        private System.Windows.Forms.Label L_Greeting3;
        private System.Windows.Forms.TextBox TB_Greeting2;
        private System.Windows.Forms.Label L_Greeting2;
        private System.Windows.Forms.TextBox TB_Greeting1;
        private System.Windows.Forms.Label L_Greeting1;
        private System.Windows.Forms.DateTimePicker CAL_GreetDate;
        private System.Windows.Forms.TextBox TB_Greeting;
        private System.Windows.Forms.Label L_Greeting;
        private System.Windows.Forms.Label LBL_Name;
        private System.Windows.Forms.TextBox TB_NamePlayer;
        private System.Windows.Forms.Label LBL_IslandName;
        private System.Windows.Forms.TextBox TB_Island;
    }
}
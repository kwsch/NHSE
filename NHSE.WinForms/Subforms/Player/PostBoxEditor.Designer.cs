using NHSE.Core;

namespace NHSE.WinForms
{
    partial class PostBoxEditor
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
            components = new System.ComponentModel.Container();
            CAL_PostTimestamp = new System.Windows.Forms.DateTimePicker();
            B_Cancel = new System.Windows.Forms.Button();
            B_Save = new System.Windows.Forms.Button();
            L_Sender_Edit = new System.Windows.Forms.Label();
            L_Sender_ExternalName = new System.Windows.Forms.Label();
            L_ExternalName = new System.Windows.Forms.Label();
            L_InternalName = new System.Windows.Forms.Label();
            NUD_Variant = new System.Windows.Forms.NumericUpDown();
            L_Variant = new System.Windows.Forms.Label();
            NUD_Species = new System.Windows.Forms.NumericUpDown();
            L_Species = new System.Windows.Forms.Label();
            PB_Villager = new System.Windows.Forms.PictureBox();
            TB_Post_Message = new System.Windows.Forms.TextBox();
            TB_Post_FromLine = new System.Windows.Forms.TextBox();
            TB_Post_ToLine = new System.Windows.Forms.TextBox();
            L_Post_To = new System.Windows.Forms.Label();
            L_Post_Message = new System.Windows.Forms.Label();
            L_Post_From = new System.Windows.Forms.Label();
            CB_Post_Language = new System.Windows.Forms.ComboBox();
            L_Post_UsedSlots = new System.Windows.Forms.Label();
            L_Post_UsedSlots_Value = new System.Windows.Forms.Label();
            L_Post_SelectedSlot = new System.Windows.Forms.Label();
            B_Delete = new System.Windows.Forms.Button();
            CK_Post_Read = new System.Windows.Forms.CheckBox();
            CK_Post_Faved = new System.Windows.Forms.CheckBox();
            CB_Post_SenderType = new System.Windows.Forms.ComboBox();
            L_SenderType = new System.Windows.Forms.Label();
            GB_Post_Villager = new System.Windows.Forms.GroupBox();
            GB_Post_Player = new System.Windows.Forms.GroupBox();
            TB_Post_PlayerName = new System.Windows.Forms.TextBox();
            L_Post_TimeStamp = new System.Windows.Forms.Label();
            L_Post_Language = new System.Windows.Forms.Label();
            L_Post_CountTo = new System.Windows.Forms.Label();
            L_Post_CountMsg = new System.Windows.Forms.Label();
            L_Post_CountFrom = new System.Windows.Forms.Label();
            GB_Post_NPC = new System.Windows.Forms.GroupBox();
            CB_Post_NPC = new System.Windows.Forms.ComboBox();
            TC_Post_SR = new System.Windows.Forms.TabControl();
            TP_Post_SR = new System.Windows.Forms.TabPage();
            GB_Post_ReceiverIsland = new System.Windows.Forms.GroupBox();
            TB_Post_ReceiverIsland = new System.Windows.Forms.TextBox();
            GB_Post_Stationery = new System.Windows.Forms.GroupBox();
            CB_Post_Stationery = new System.Windows.Forms.ComboBox();
            GB_Post_ReceiverPlayer = new System.Windows.Forms.GroupBox();
            TB_Post_ReceiverPlayer = new System.Windows.Forms.TextBox();
            TP_Post_Items = new System.Windows.Forms.TabPage();
            GB_Post_AttachedInfo = new System.Windows.Forms.GroupBox();
            ItemEditor = new ItemEditor();
            L_Post_AttachmentSkin = new System.Windows.Forms.Label();
            CB_Post_AttachmentSkin = new System.Windows.Forms.ComboBox();
            CB_Post_MailType = new System.Windows.Forms.ComboBox();
            L_Post_MailType = new System.Windows.Forms.Label();
            B_Import = new System.Windows.Forms.Button();
            B_Dump = new System.Windows.Forms.Button();
            B_Post_DumpAll = new System.Windows.Forms.Button();
            NUD_Post_Slots = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)NUD_Variant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Species).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Villager).BeginInit();
            GB_Post_Villager.SuspendLayout();
            GB_Post_Player.SuspendLayout();
            GB_Post_NPC.SuspendLayout();
            TC_Post_SR.SuspendLayout();
            TP_Post_SR.SuspendLayout();
            GB_Post_ReceiverIsland.SuspendLayout();
            GB_Post_Stationery.SuspendLayout();
            GB_Post_ReceiverPlayer.SuspendLayout();
            TP_Post_Items.SuspendLayout();
            GB_Post_AttachedInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_Post_Slots).BeginInit();
            SuspendLayout();
            // 
            // CAL_PostTimestamp
            // 
            CAL_PostTimestamp.Location = new System.Drawing.Point(9, 446);
            CAL_PostTimestamp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CAL_PostTimestamp.Name = "CAL_PostTimestamp";
            CAL_PostTimestamp.Size = new System.Drawing.Size(233, 23);
            CAL_PostTimestamp.TabIndex = 76;
            // 
            // B_Cancel
            // 
            B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Cancel.Location = new System.Drawing.Point(385, 544);
            B_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Cancel.Name = "B_Cancel";
            B_Cancel.Size = new System.Drawing.Size(107, 46);
            B_Cancel.TabIndex = 75;
            B_Cancel.Text = "Cancel";
            B_Cancel.UseVisualStyleBackColor = true;
            B_Cancel.Click += B_Cancel_Click;
            // 
            // B_Save
            // 
            B_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_Save.Location = new System.Drawing.Point(496, 544);
            B_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Save.Name = "B_Save";
            B_Save.Size = new System.Drawing.Size(107, 46);
            B_Save.TabIndex = 74;
            B_Save.Text = "Save Slot";
            B_Save.UseVisualStyleBackColor = true;
            B_Save.Click += B_Save_Click;
            // 
            // L_Sender_Edit
            // 
            L_Sender_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            L_Sender_Edit.Location = new System.Drawing.Point(123, 16);
            L_Sender_Edit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Sender_Edit.Name = "L_Sender_Edit";
            L_Sender_Edit.Size = new System.Drawing.Size(72, 23);
            L_Sender_Edit.TabIndex = 86;
            L_Sender_Edit.Text = "Edit Sender:";
            L_Sender_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Sender_ExternalName
            // 
            L_Sender_ExternalName.Location = new System.Drawing.Point(126, 94);
            L_Sender_ExternalName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Sender_ExternalName.Name = "L_Sender_ExternalName";
            L_Sender_ExternalName.Size = new System.Drawing.Size(86, 23);
            L_Sender_ExternalName.TabIndex = 84;
            L_Sender_ExternalName.Text = "Sender Name:";
            L_Sender_ExternalName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_ExternalName
            // 
            L_ExternalName.AutoSize = true;
            L_ExternalName.Font = new System.Drawing.Font("Segoe UI", 9F);
            L_ExternalName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            L_ExternalName.Location = new System.Drawing.Point(126, 114);
            L_ExternalName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_ExternalName.Name = "L_ExternalName";
            L_ExternalName.Size = new System.Drawing.Size(57, 15);
            L_ExternalName.TabIndex = 83;
            L_ExternalName.Text = "unknown";
            L_ExternalName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_InternalName
            // 
            L_InternalName.AutoSize = true;
            L_InternalName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            L_InternalName.Location = new System.Drawing.Point(8, 137);
            L_InternalName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_InternalName.Name = "L_InternalName";
            L_InternalName.Size = new System.Drawing.Size(56, 14);
            L_InternalName.TabIndex = 82;
            L_InternalName.Text = "unknown";
            L_InternalName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NUD_Variant
            // 
            NUD_Variant.Location = new System.Drawing.Point(128, 65);
            NUD_Variant.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_Variant.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            NUD_Variant.Name = "NUD_Variant";
            NUD_Variant.Size = new System.Drawing.Size(46, 23);
            NUD_Variant.TabIndex = 81;
            NUD_Variant.ValueChanged += ChangeVillager;
            // 
            // L_Variant
            // 
            L_Variant.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            L_Variant.Location = new System.Drawing.Point(177, 64);
            L_Variant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Variant.Name = "L_Variant";
            L_Variant.Size = new System.Drawing.Size(56, 23);
            L_Variant.TabIndex = 80;
            L_Variant.Text = "Variant";
            L_Variant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NUD_Species
            // 
            NUD_Species.Location = new System.Drawing.Point(128, 40);
            NUD_Species.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NUD_Species.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            NUD_Species.Name = "NUD_Species";
            NUD_Species.Size = new System.Drawing.Size(46, 23);
            NUD_Species.TabIndex = 79;
            NUD_Species.ValueChanged += ChangeVillager;
            // 
            // L_Species
            // 
            L_Species.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            L_Species.Location = new System.Drawing.Point(177, 39);
            L_Species.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Species.Name = "L_Species";
            L_Species.Size = new System.Drawing.Size(56, 23);
            L_Species.TabIndex = 78;
            L_Species.Text = "Species";
            L_Species.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PB_Villager
            // 
            PB_Villager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PB_Villager.Location = new System.Drawing.Point(9, 21);
            PB_Villager.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PB_Villager.Name = "PB_Villager";
            PB_Villager.Size = new System.Drawing.Size(114, 114);
            PB_Villager.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            PB_Villager.TabIndex = 77;
            PB_Villager.TabStop = false;
            // 
            // TB_Post_Message
            // 
            TB_Post_Message.Location = new System.Drawing.Point(7, 138);
            TB_Post_Message.Multiline = true;
            TB_Post_Message.Name = "TB_Post_Message";
            TB_Post_Message.Size = new System.Drawing.Size(220, 218);
            TB_Post_Message.TabIndex = 87;
            TB_Post_Message.TextChanged += UpdateMailCounters;
            // 
            // TB_Post_FromLine
            // 
            TB_Post_FromLine.Location = new System.Drawing.Point(7, 383);
            TB_Post_FromLine.Name = "TB_Post_FromLine";
            TB_Post_FromLine.Size = new System.Drawing.Size(220, 23);
            TB_Post_FromLine.TabIndex = 88;
            TB_Post_FromLine.TextChanged += UpdateMailCounters;
            // 
            // TB_Post_ToLine
            // 
            TB_Post_ToLine.Location = new System.Drawing.Point(7, 88);
            TB_Post_ToLine.Name = "TB_Post_ToLine";
            TB_Post_ToLine.Size = new System.Drawing.Size(220, 23);
            TB_Post_ToLine.TabIndex = 89;
            TB_Post_ToLine.TextChanged += UpdateMailCounters;
            // 
            // L_Post_To
            // 
            L_Post_To.Location = new System.Drawing.Point(3, 64);
            L_Post_To.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_To.Name = "L_Post_To";
            L_Post_To.Size = new System.Drawing.Size(52, 23);
            L_Post_To.TabIndex = 90;
            L_Post_To.Text = "To Line:";
            L_Post_To.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Post_Message
            // 
            L_Post_Message.Location = new System.Drawing.Point(5, 113);
            L_Post_Message.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_Message.Name = "L_Post_Message";
            L_Post_Message.Size = new System.Drawing.Size(58, 23);
            L_Post_Message.TabIndex = 91;
            L_Post_Message.Text = "Message:";
            L_Post_Message.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Post_From
            // 
            L_Post_From.Location = new System.Drawing.Point(5, 358);
            L_Post_From.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_From.Name = "L_Post_From";
            L_Post_From.Size = new System.Drawing.Size(64, 23);
            L_Post_From.TabIndex = 92;
            L_Post_From.Text = "From Line:";
            L_Post_From.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Post_Language
            // 
            CB_Post_Language.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            CB_Post_Language.FormattingEnabled = true;
            CB_Post_Language.Location = new System.Drawing.Point(7, 477);
            CB_Post_Language.Name = "CB_Post_Language";
            CB_Post_Language.Size = new System.Drawing.Size(115, 23);
            CB_Post_Language.TabIndex = 93;
            // 
            // L_Post_UsedSlots
            // 
            L_Post_UsedSlots.Location = new System.Drawing.Point(8, 7);
            L_Post_UsedSlots.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_UsedSlots.Name = "L_Post_UsedSlots";
            L_Post_UsedSlots.Size = new System.Drawing.Size(74, 23);
            L_Post_UsedSlots.TabIndex = 94;
            L_Post_UsedSlots.Text = "Used Slots:";
            L_Post_UsedSlots.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Post_UsedSlots_Value
            // 
            L_Post_UsedSlots_Value.AutoSize = true;
            L_Post_UsedSlots_Value.Font = new System.Drawing.Font("Segoe UI", 9F);
            L_Post_UsedSlots_Value.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            L_Post_UsedSlots_Value.Location = new System.Drawing.Point(90, 11);
            L_Post_UsedSlots_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_UsedSlots_Value.Name = "L_Post_UsedSlots_Value";
            L_Post_UsedSlots_Value.Size = new System.Drawing.Size(57, 15);
            L_Post_UsedSlots_Value.TabIndex = 95;
            L_Post_UsedSlots_Value.Text = "unknown";
            L_Post_UsedSlots_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Post_SelectedSlot
            // 
            L_Post_SelectedSlot.Location = new System.Drawing.Point(8, 33);
            L_Post_SelectedSlot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_SelectedSlot.Name = "L_Post_SelectedSlot";
            L_Post_SelectedSlot.Size = new System.Drawing.Size(81, 23);
            L_Post_SelectedSlot.TabIndex = 96;
            L_Post_SelectedSlot.Text = "Selected Slot:";
            L_Post_SelectedSlot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // B_Delete
            // 
            B_Delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            B_Delete.Location = new System.Drawing.Point(134, 551);
            B_Delete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Delete.Name = "B_Delete";
            B_Delete.Size = new System.Drawing.Size(92, 32);
            B_Delete.TabIndex = 99;
            B_Delete.Text = "Delete Mail";
            B_Delete.UseVisualStyleBackColor = true;
            B_Delete.Click += B_Delete_Click;
            // 
            // CK_Post_Read
            // 
            CK_Post_Read.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            CK_Post_Read.AutoSize = true;
            CK_Post_Read.Location = new System.Drawing.Point(7, 412);
            CK_Post_Read.Name = "CK_Post_Read";
            CK_Post_Read.Size = new System.Drawing.Size(82, 19);
            CK_Post_Read.TabIndex = 100;
            CK_Post_Read.Text = "Mark Read";
            CK_Post_Read.UseVisualStyleBackColor = true;
            // 
            // CK_Post_Faved
            // 
            CK_Post_Faved.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            CK_Post_Faved.AutoSize = true;
            CK_Post_Faved.Location = new System.Drawing.Point(7, 435);
            CK_Post_Faved.Name = "CK_Post_Faved";
            CK_Post_Faved.Size = new System.Drawing.Size(82, 19);
            CK_Post_Faved.TabIndex = 101;
            CK_Post_Faved.Text = "Favourited";
            CK_Post_Faved.UseVisualStyleBackColor = true;
            // 
            // CB_Post_SenderType
            // 
            CB_Post_SenderType.FormattingEnabled = true;
            CB_Post_SenderType.Location = new System.Drawing.Point(6, 26);
            CB_Post_SenderType.Name = "CB_Post_SenderType";
            CB_Post_SenderType.Size = new System.Drawing.Size(114, 23);
            CB_Post_SenderType.TabIndex = 103;
            CB_Post_SenderType.SelectedIndexChanged += UpdateSenderType;
            // 
            // L_SenderType
            // 
            L_SenderType.Location = new System.Drawing.Point(5, 3);
            L_SenderType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_SenderType.Name = "L_SenderType";
            L_SenderType.Size = new System.Drawing.Size(106, 22);
            L_SenderType.TabIndex = 104;
            L_SenderType.Text = "Sender Type";
            L_SenderType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GB_Post_Villager
            // 
            GB_Post_Villager.Controls.Add(PB_Villager);
            GB_Post_Villager.Controls.Add(L_Species);
            GB_Post_Villager.Controls.Add(NUD_Species);
            GB_Post_Villager.Controls.Add(L_Variant);
            GB_Post_Villager.Controls.Add(NUD_Variant);
            GB_Post_Villager.Controls.Add(L_InternalName);
            GB_Post_Villager.Controls.Add(L_ExternalName);
            GB_Post_Villager.Controls.Add(L_Sender_ExternalName);
            GB_Post_Villager.Controls.Add(L_Sender_Edit);
            GB_Post_Villager.Location = new System.Drawing.Point(6, 104);
            GB_Post_Villager.Name = "GB_Post_Villager";
            GB_Post_Villager.Size = new System.Drawing.Size(283, 161);
            GB_Post_Villager.TabIndex = 105;
            GB_Post_Villager.TabStop = false;
            GB_Post_Villager.Text = "Villager";
            // 
            // GB_Post_Player
            // 
            GB_Post_Player.Controls.Add(TB_Post_PlayerName);
            GB_Post_Player.Location = new System.Drawing.Point(130, 6);
            GB_Post_Player.Name = "GB_Post_Player";
            GB_Post_Player.Size = new System.Drawing.Size(159, 48);
            GB_Post_Player.TabIndex = 106;
            GB_Post_Player.TabStop = false;
            GB_Post_Player.Text = "Player";
            // 
            // TB_Post_PlayerName
            // 
            TB_Post_PlayerName.Location = new System.Drawing.Point(6, 19);
            TB_Post_PlayerName.Name = "TB_Post_PlayerName";
            TB_Post_PlayerName.Size = new System.Drawing.Size(147, 23);
            TB_Post_PlayerName.TabIndex = 113;
            // 
            // L_Post_TimeStamp
            // 
            L_Post_TimeStamp.Location = new System.Drawing.Point(7, 422);
            L_Post_TimeStamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_TimeStamp.Name = "L_Post_TimeStamp";
            L_Post_TimeStamp.Size = new System.Drawing.Size(70, 23);
            L_Post_TimeStamp.TabIndex = 107;
            L_Post_TimeStamp.Text = "Timestamp:";
            L_Post_TimeStamp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Post_Language
            // 
            L_Post_Language.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            L_Post_Language.Location = new System.Drawing.Point(5, 454);
            L_Post_Language.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_Language.Name = "L_Post_Language";
            L_Post_Language.Size = new System.Drawing.Size(67, 23);
            L_Post_Language.TabIndex = 108;
            L_Post_Language.Text = "Language:";
            L_Post_Language.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Post_CountTo
            // 
            L_Post_CountTo.AutoSize = true;
            L_Post_CountTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            L_Post_CountTo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            L_Post_CountTo.Location = new System.Drawing.Point(231, 92);
            L_Post_CountTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_CountTo.Name = "L_Post_CountTo";
            L_Post_CountTo.Size = new System.Drawing.Size(38, 15);
            L_Post_CountTo.TabIndex = 109;
            L_Post_CountTo.Text = "count";
            L_Post_CountTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Post_CountMsg
            // 
            L_Post_CountMsg.AutoSize = true;
            L_Post_CountMsg.Font = new System.Drawing.Font("Segoe UI", 9F);
            L_Post_CountMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            L_Post_CountMsg.Location = new System.Drawing.Point(231, 138);
            L_Post_CountMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_CountMsg.Name = "L_Post_CountMsg";
            L_Post_CountMsg.Size = new System.Drawing.Size(38, 15);
            L_Post_CountMsg.TabIndex = 110;
            L_Post_CountMsg.Text = "count";
            L_Post_CountMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Post_CountFrom
            // 
            L_Post_CountFrom.AutoSize = true;
            L_Post_CountFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            L_Post_CountFrom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            L_Post_CountFrom.Location = new System.Drawing.Point(231, 387);
            L_Post_CountFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_CountFrom.Name = "L_Post_CountFrom";
            L_Post_CountFrom.Size = new System.Drawing.Size(38, 15);
            L_Post_CountFrom.TabIndex = 111;
            L_Post_CountFrom.Text = "count";
            L_Post_CountFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GB_Post_NPC
            // 
            GB_Post_NPC.Controls.Add(CB_Post_NPC);
            GB_Post_NPC.Location = new System.Drawing.Point(6, 55);
            GB_Post_NPC.Name = "GB_Post_NPC";
            GB_Post_NPC.Size = new System.Drawing.Size(283, 48);
            GB_Post_NPC.TabIndex = 108;
            GB_Post_NPC.TabStop = false;
            GB_Post_NPC.Text = "NPC";
            // 
            // CB_Post_NPC
            // 
            CB_Post_NPC.FormattingEnabled = true;
            CB_Post_NPC.Location = new System.Drawing.Point(6, 18);
            CB_Post_NPC.Name = "CB_Post_NPC";
            CB_Post_NPC.Size = new System.Drawing.Size(206, 23);
            CB_Post_NPC.TabIndex = 107;
            CB_Post_NPC.SelectedIndexChanged += UpdateSenderNPC;
            // 
            // TC_Post_SR
            // 
            TC_Post_SR.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            TC_Post_SR.Controls.Add(TP_Post_SR);
            TC_Post_SR.Controls.Add(TP_Post_Items);
            TC_Post_SR.Location = new System.Drawing.Point(300, 32);
            TC_Post_SR.Name = "TC_Post_SR";
            TC_Post_SR.SelectedIndex = 0;
            TC_Post_SR.Size = new System.Drawing.Size(304, 507);
            TC_Post_SR.TabIndex = 112;
            // 
            // TP_Post_SR
            // 
            TP_Post_SR.Controls.Add(GB_Post_ReceiverIsland);
            TP_Post_SR.Controls.Add(GB_Post_Stationery);
            TP_Post_SR.Controls.Add(GB_Post_ReceiverPlayer);
            TP_Post_SR.Controls.Add(L_SenderType);
            TP_Post_SR.Controls.Add(GB_Post_NPC);
            TP_Post_SR.Controls.Add(CB_Post_SenderType);
            TP_Post_SR.Controls.Add(GB_Post_Villager);
            TP_Post_SR.Controls.Add(L_Post_TimeStamp);
            TP_Post_SR.Controls.Add(GB_Post_Player);
            TP_Post_SR.Controls.Add(CAL_PostTimestamp);
            TP_Post_SR.Location = new System.Drawing.Point(4, 24);
            TP_Post_SR.Name = "TP_Post_SR";
            TP_Post_SR.Padding = new System.Windows.Forms.Padding(3);
            TP_Post_SR.Size = new System.Drawing.Size(296, 479);
            TP_Post_SR.TabIndex = 0;
            TP_Post_SR.Text = "Details";
            TP_Post_SR.UseVisualStyleBackColor = true;
            // 
            // GB_Post_ReceiverIsland
            // 
            GB_Post_ReceiverIsland.Controls.Add(TB_Post_ReceiverIsland);
            GB_Post_ReceiverIsland.Location = new System.Drawing.Point(6, 370);
            GB_Post_ReceiverIsland.Name = "GB_Post_ReceiverIsland";
            GB_Post_ReceiverIsland.Size = new System.Drawing.Size(283, 48);
            GB_Post_ReceiverIsland.TabIndex = 117;
            GB_Post_ReceiverIsland.TabStop = false;
            GB_Post_ReceiverIsland.Text = "Receiver Island";
            // 
            // TB_Post_ReceiverIsland
            // 
            TB_Post_ReceiverIsland.Location = new System.Drawing.Point(8, 19);
            TB_Post_ReceiverIsland.Name = "TB_Post_ReceiverIsland";
            TB_Post_ReceiverIsland.Size = new System.Drawing.Size(157, 23);
            TB_Post_ReceiverIsland.TabIndex = 115;
            // 
            // GB_Post_Stationery
            // 
            GB_Post_Stationery.Controls.Add(CB_Post_Stationery);
            GB_Post_Stationery.Location = new System.Drawing.Point(6, 268);
            GB_Post_Stationery.Name = "GB_Post_Stationery";
            GB_Post_Stationery.Size = new System.Drawing.Size(283, 48);
            GB_Post_Stationery.TabIndex = 114;
            GB_Post_Stationery.TabStop = false;
            GB_Post_Stationery.Text = "Stationery Type";
            // 
            // CB_Post_Stationery
            // 
            CB_Post_Stationery.FormattingEnabled = true;
            CB_Post_Stationery.Location = new System.Drawing.Point(6, 18);
            CB_Post_Stationery.Name = "CB_Post_Stationery";
            CB_Post_Stationery.Size = new System.Drawing.Size(271, 23);
            CB_Post_Stationery.TabIndex = 107;
            // 
            // GB_Post_ReceiverPlayer
            // 
            GB_Post_ReceiverPlayer.Controls.Add(TB_Post_ReceiverPlayer);
            GB_Post_ReceiverPlayer.Location = new System.Drawing.Point(6, 319);
            GB_Post_ReceiverPlayer.Name = "GB_Post_ReceiverPlayer";
            GB_Post_ReceiverPlayer.Size = new System.Drawing.Size(283, 48);
            GB_Post_ReceiverPlayer.TabIndex = 113;
            GB_Post_ReceiverPlayer.TabStop = false;
            GB_Post_ReceiverPlayer.Text = "Receiver Player";
            // 
            // TB_Post_ReceiverPlayer
            // 
            TB_Post_ReceiverPlayer.Location = new System.Drawing.Point(8, 19);
            TB_Post_ReceiverPlayer.Name = "TB_Post_ReceiverPlayer";
            TB_Post_ReceiverPlayer.Size = new System.Drawing.Size(157, 23);
            TB_Post_ReceiverPlayer.TabIndex = 115;
            // 
            // TP_Post_Items
            // 
            TP_Post_Items.Controls.Add(GB_Post_AttachedInfo);
            TP_Post_Items.Controls.Add(CB_Post_MailType);
            TP_Post_Items.Controls.Add(L_Post_MailType);
            TP_Post_Items.Location = new System.Drawing.Point(4, 24);
            TP_Post_Items.Name = "TP_Post_Items";
            TP_Post_Items.Padding = new System.Windows.Forms.Padding(3);
            TP_Post_Items.Size = new System.Drawing.Size(296, 479);
            TP_Post_Items.TabIndex = 1;
            TP_Post_Items.Text = "Attachments";
            TP_Post_Items.UseVisualStyleBackColor = true;
            // 
            // GB_Post_AttachedInfo
            // 
            GB_Post_AttachedInfo.Controls.Add(ItemEditor);
            GB_Post_AttachedInfo.Controls.Add(L_Post_AttachmentSkin);
            GB_Post_AttachedInfo.Controls.Add(CB_Post_AttachmentSkin);
            GB_Post_AttachedInfo.Location = new System.Drawing.Point(5, 32);
            GB_Post_AttachedInfo.Name = "GB_Post_AttachedInfo";
            GB_Post_AttachedInfo.Size = new System.Drawing.Size(288, 443);
            GB_Post_AttachedInfo.TabIndex = 114;
            GB_Post_AttachedInfo.TabStop = false;
            GB_Post_AttachedInfo.Text = "Attachment Info";
            // 
            // ItemEditor
            // 
            ItemEditor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ItemEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ItemEditor.Location = new System.Drawing.Point(7, 65);
            ItemEditor.Name = "ItemEditor";
            ItemEditor.Size = new System.Drawing.Size(275, 371);
            ItemEditor.TabIndex = 113;
            // 
            // L_Post_AttachmentSkin
            // 
            L_Post_AttachmentSkin.Location = new System.Drawing.Point(7, 14);
            L_Post_AttachmentSkin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_AttachmentSkin.Name = "L_Post_AttachmentSkin";
            L_Post_AttachmentSkin.Size = new System.Drawing.Size(201, 23);
            L_Post_AttachmentSkin.TabIndex = 114;
            L_Post_AttachmentSkin.Text = "Attachment Skin:";
            L_Post_AttachmentSkin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_Post_AttachmentSkin
            // 
            CB_Post_AttachmentSkin.FormattingEnabled = true;
            CB_Post_AttachmentSkin.Location = new System.Drawing.Point(7, 37);
            CB_Post_AttachmentSkin.Name = "CB_Post_AttachmentSkin";
            CB_Post_AttachmentSkin.Size = new System.Drawing.Size(240, 23);
            CB_Post_AttachmentSkin.TabIndex = 115;
            // 
            // CB_Post_MailType
            // 
            CB_Post_MailType.FormattingEnabled = true;
            CB_Post_MailType.Location = new System.Drawing.Point(123, 7);
            CB_Post_MailType.Name = "CB_Post_MailType";
            CB_Post_MailType.Size = new System.Drawing.Size(129, 23);
            CB_Post_MailType.TabIndex = 113;
            CB_Post_MailType.SelectedIndexChanged += UpdateMailType;
            // 
            // L_Post_MailType
            // 
            L_Post_MailType.Location = new System.Drawing.Point(11, 6);
            L_Post_MailType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_Post_MailType.Name = "L_Post_MailType";
            L_Post_MailType.Size = new System.Drawing.Size(68, 23);
            L_Post_MailType.TabIndex = 113;
            L_Post_MailType.Text = "Mail Type:";
            L_Post_MailType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // B_Import
            // 
            B_Import.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            B_Import.Location = new System.Drawing.Point(134, 472);
            B_Import.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Import.Name = "B_Import";
            B_Import.Size = new System.Drawing.Size(92, 31);
            B_Import.TabIndex = 113;
            B_Import.Text = "Import Mail";
            B_Import.UseVisualStyleBackColor = true;
            B_Import.Click += B_Import_Click;
            // 
            // B_Dump
            // 
            B_Dump.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            B_Dump.Location = new System.Drawing.Point(134, 436);
            B_Dump.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Dump.Name = "B_Dump";
            B_Dump.Size = new System.Drawing.Size(92, 31);
            B_Dump.TabIndex = 114;
            B_Dump.Text = "Dump Mail";
            B_Dump.UseVisualStyleBackColor = true;
            B_Dump.Click += B_Dump_Click;
            // 
            // B_Post_DumpAll
            // 
            B_Post_DumpAll.Location = new System.Drawing.Point(191, 29);
            B_Post_DumpAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Post_DumpAll.Name = "B_Post_DumpAll";
            B_Post_DumpAll.Size = new System.Drawing.Size(88, 32);
            B_Post_DumpAll.TabIndex = 115;
            B_Post_DumpAll.Text = "Dump All";
            B_Post_DumpAll.UseVisualStyleBackColor = true;
            B_Post_DumpAll.Click += B_Dump_Click;
            // 
            // NUD_Post_Slots
            // 
            NUD_Post_Slots.Location = new System.Drawing.Point(88, 34);
            NUD_Post_Slots.Name = "NUD_Post_Slots";
            NUD_Post_Slots.Size = new System.Drawing.Size(60, 23);
            NUD_Post_Slots.TabIndex = 116;
            NUD_Post_Slots.ValueChanged += LoadMailItem;
            // 
            // PostBoxEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(614, 601);
            Controls.Add(NUD_Post_Slots);
            Controls.Add(B_Post_DumpAll);
            Controls.Add(B_Dump);
            Controls.Add(B_Import);
            Controls.Add(TC_Post_SR);
            Controls.Add(L_Post_CountFrom);
            Controls.Add(L_Post_CountMsg);
            Controls.Add(L_Post_CountTo);
            Controls.Add(L_Post_Language);
            Controls.Add(CK_Post_Faved);
            Controls.Add(CK_Post_Read);
            Controls.Add(B_Delete);
            Controls.Add(L_Post_SelectedSlot);
            Controls.Add(L_Post_UsedSlots_Value);
            Controls.Add(L_Post_UsedSlots);
            Controls.Add(CB_Post_Language);
            Controls.Add(L_Post_From);
            Controls.Add(L_Post_Message);
            Controls.Add(L_Post_To);
            Controls.Add(TB_Post_ToLine);
            Controls.Add(TB_Post_FromLine);
            Controls.Add(TB_Post_Message);
            Controls.Add(B_Cancel);
            Controls.Add(B_Save);
            Icon = Properties.Resources.icon;
            Name = "PostBoxEditor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Post Box Editor";
            ((System.ComponentModel.ISupportInitialize)NUD_Variant).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Species).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Villager).EndInit();
            GB_Post_Villager.ResumeLayout(false);
            GB_Post_Villager.PerformLayout();
            GB_Post_Player.ResumeLayout(false);
            GB_Post_Player.PerformLayout();
            GB_Post_NPC.ResumeLayout(false);
            TC_Post_SR.ResumeLayout(false);
            TP_Post_SR.ResumeLayout(false);
            GB_Post_ReceiverIsland.ResumeLayout(false);
            GB_Post_ReceiverIsland.PerformLayout();
            GB_Post_Stationery.ResumeLayout(false);
            GB_Post_ReceiverPlayer.ResumeLayout(false);
            GB_Post_ReceiverPlayer.PerformLayout();
            TP_Post_Items.ResumeLayout(false);
            GB_Post_AttachedInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NUD_Post_Slots).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker CAL_PostTimestamp;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Label L_Sender_Edit;
        private System.Windows.Forms.Label L_Sender_ExternalName;
        private System.Windows.Forms.Label L_ExternalName;
        private System.Windows.Forms.Label L_InternalName;
        private System.Windows.Forms.NumericUpDown NUD_Variant;
        private System.Windows.Forms.Label L_Variant;
        private System.Windows.Forms.NumericUpDown NUD_Species;
        private System.Windows.Forms.Label L_Species;
        private System.Windows.Forms.PictureBox PB_Villager;
        private System.Windows.Forms.TextBox TB_Post_Message;
        private System.Windows.Forms.TextBox TB_Post_FromLine;
        private System.Windows.Forms.TextBox TB_Post_ToLine;
        private System.Windows.Forms.Label L_Post_To;
        private System.Windows.Forms.Label L_Post_Message;
        private System.Windows.Forms.Label L_Post_From;
        private System.Windows.Forms.ComboBox CB_Post_Language;
        private System.Windows.Forms.Label L_Post_UsedSlots;
        private System.Windows.Forms.Label L_Post_UsedSlots_Value;
        private System.Windows.Forms.Label L_Post_SelectedSlot;
        private System.Windows.Forms.Button B_Delete;
        private System.Windows.Forms.CheckBox CK_Post_Read;
        private System.Windows.Forms.CheckBox CK_Post_Faved;
        private System.Windows.Forms.ComboBox CB_Post_SenderType;
        private System.Windows.Forms.Label L_SenderType;
        private System.Windows.Forms.GroupBox GB_Post_Villager;
        private System.Windows.Forms.GroupBox GB_Post_Player;
        private System.Windows.Forms.Label L_Post_TimeStamp;
        private System.Windows.Forms.Label L_Post_Language;
        private System.Windows.Forms.Label L_Post_CountTo;
        private System.Windows.Forms.Label L_Post_CountMsg;
        private System.Windows.Forms.Label L_Post_CountFrom;
        private System.Windows.Forms.GroupBox GB_Post_NPC;
        private System.Windows.Forms.ComboBox CB_Post_NPC;
        private System.Windows.Forms.TabControl TC_Post_SR;
        private System.Windows.Forms.TabPage TP_Post_SR;
        private System.Windows.Forms.TabPage TP_Post_Items;
        private System.Windows.Forms.GroupBox GB_Post_ReceiverPlayer;
        private System.Windows.Forms.GroupBox GB_Post_Stationery;
        private System.Windows.Forms.ComboBox CB_Post_Stationery;
        private System.Windows.Forms.Label L_Post_MailType;
        private System.Windows.Forms.ComboBox CB_Post_MailType;
        private System.Windows.Forms.GroupBox GB_Post_AttachedInfo;
        private System.Windows.Forms.Label L_Post_AttachmentSkin;
        private System.Windows.Forms.ComboBox CB_Post_AttachmentSkin;
        private ItemEditor ItemEditor;
        private System.Windows.Forms.TextBox TB_Post_PlayerName;
        private System.Windows.Forms.Button B_Import;
        private System.Windows.Forms.Button B_Dump;
        private System.Windows.Forms.Button B_Post_DumpAll;
        private System.Windows.Forms.GroupBox GB_Post_ReceiverIsland;
        private System.Windows.Forms.TextBox TB_Post_ReceiverIsland;
        private System.Windows.Forms.TextBox TB_Post_ReceiverPlayer;
        private System.Windows.Forms.NumericUpDown NUD_Post_Slots;
    }
}
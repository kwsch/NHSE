using NHSE.Core;
using NHSE.Sprites;
using NHSE.WinForms.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using static NHSE.Core.Mail;

namespace NHSE.WinForms;

public partial class PostBoxEditor : Form
{
    private readonly Player Player;
    private readonly PostBox PostBox;

    private readonly string[] Wrap;
    private readonly string[] Box;
    private Item Attachment;
    private List<int> PostSlots;

    private string GetUpdatedVillagerInternalName() => VillagerUtil.GetInternalVillagerName((VillagerSpecies)NUD_Species.Value, (int)NUD_Variant.Value);

    public PostBoxEditor(Player p, PostBox pb)
    {
        InitializeComponent();
        this.TranslateInterface(GameInfo.CurrentLanguage);

        Player = p;
        PostBox = pb;
        Attachment = new Item();

        PostSlots = PostBox.GetUsedPostBoxSlots();

        NUD_Post_Slots.Maximum = MaxSlots;

        L_Post_UsedSlots_Value.Text = PostSlots.Count + " / 300";

        CB_Post_SenderType.Items.AddRange(NPCTypeList.ToArray());
        var senderNPC = SenderNPCData.Values.Select(npc => GameInfo.Strings.GetVillager(npc.NameConversion));
        CB_Post_NPC.Items.AddRange(senderNPC.ToArray());
        CB_Post_Language.Items.AddRange(BCP47LanguageString.Keys.ToArray());

        CB_Post_Stationery.Items.AddRange(LetterStationerySkin.Values.Select(skin => GameInfo.Strings.GetMail(skin.name)).ToArray());

        TB_Post_ToLine.MaxLength = LetterToTextLength;
        TB_Post_Message.MaxLength = LetterMessageTextLength;
        TB_Post_FromLine.MaxLength = LetterFromTextLength;

        ItemEditor.Initialize(GameInfo.Strings.ItemDataSource, true, true);

        CB_Post_MailType.Items.AddRange(MailTypeList.ToArray());

        Wrap = ItemWrappingExtended.ItemWrappingSkin.Values.Select(skin => GameInfo.Strings.GetMail(skin.name)).ToArray();
        Box = ItemWrappingExtended.ItemBoxSkin.Values.Select(skin => GameInfo.Strings.GetMail(skin.name)).ToArray();

        LoadMailItem();

        DialogResult = DialogResult.Cancel;
    }

    private void ChangeVillager(object sender, EventArgs e) => ChangeVillager();
    private void ChangeVillager()
    {
        var index = (int)NUD_Post_Slots.Value;

        if (PostBox.GetMailCheck((int)NUD_Post_Slots.Value) == false)
        {
            return;
        }

        if (CB_Post_SenderType.SelectedIndex != 0)
        {
            var spVal = (int)NUD_Species.Value;
            var vaVal = (int)NUD_Variant.Value;

            if (spVal >= 35 || (spVal == 25 && vaVal == 0) || (spVal == 22 && vaVal == 0))
            {
                CB_Post_SenderType.SelectedIndex = 2;
            }
            else
            {
                CB_Post_SenderType.SelectedIndex = 1;
            }
        }

        var name = GetUpdatedVillagerInternalName();
        L_InternalName.Text = name;
        L_ExternalName.Text = GameInfo.Strings.GetVillager(name);

        var sprite = VillagerSprite.GetVillagerSprite(name);

        if (CB_Post_SenderType.SelectedIndex == 1) // Villager
        {
            GB_Post_NPC.Enabled = false;
            GB_Post_Player.Enabled = false;

            PB_Villager.Image = sprite;

            CB_Post_SenderType.SelectedIndex = 1;
            CB_Post_NPC.SelectedIndex = -1;
        }
        else if (CB_Post_SenderType.SelectedIndex == 2) // NPC
        {
            GB_Post_NPC.Enabled = true;
            GB_Post_Player.Enabled = false;


            var speciesValue = (int)NUD_Species.Value;
            if (!SenderNPCData.TryGetValue(speciesValue, out var npcData))
            {
                PB_Villager.Image = sprite;
                CB_Post_SenderType.SelectedIndex = 2;
                CB_Post_NPC.SelectedIndex = -1;
                return;
            }
            name = npcData.Image;

            sprite = VillagerSprite.GetVillagerSprite(name);
            var nameNPC = SenderNPCData[(int)NUD_Species.Value].NameConversion;
            L_InternalName.Text = nameNPC;
            L_ExternalName.Text = GameInfo.Strings.GetVillager(nameNPC);

            PB_Villager.Image = sprite;

            CB_Post_SenderType.SelectedIndex = 2;
            CB_Post_NPC.SelectedIndex = npcData.MappingIndex;
        }
        else if (CB_Post_SenderType.SelectedIndex == 0) // Player
        {
            GB_Post_NPC.Enabled = false;
            GB_Post_Player.Enabled = true;

            sprite = VillagerSprite.GetVillagerSprite("Leaf");
            L_InternalName.Text = PostBox.GetSenderName(index);
            L_ExternalName.Text = PostBox.GetSenderName(index);

            PB_Villager.Image = sprite;

            CB_Post_SenderType.SelectedIndex = 0;
            CB_Post_NPC.SelectedIndex = -1;
        }
        else
        {
            var senderType = PostBox.GetSenderType(index);
            throw new NotSupportedException($"Unknown sender type: 0x{senderType:X2}");
        }
    }

    private void UpdateSenderNPC(object sender, EventArgs e)
    {
        var index = (int)NUD_Post_Slots.Value;

        var npcSelected = SenderNPCData.FirstOrDefault(x => x.Value.MappingIndex == CB_Post_NPC.SelectedIndex).Key;
        NUD_Species.Value = npcSelected;
    }

    private void UpdateMailType(object sender, EventArgs e)
    {
        if (CB_Post_MailType.SelectedIndex == 1) // Letter
        {
            CB_Post_Stationery.Enabled = true;
            CB_Post_AttachmentSkin.Items.Clear();
            CB_Post_AttachmentSkin.Items.AddRange(Wrap);
            CB_Post_AttachmentSkin.SelectedIndex = 0;
        }
        else if (CB_Post_MailType.SelectedIndex == 0) // Package
        {
            CB_Post_Stationery.Enabled = false;
            CB_Post_AttachmentSkin.Items.Clear();
            CB_Post_AttachmentSkin.Items.AddRange(Box);
            CB_Post_AttachmentSkin.SelectedIndex = 0;
            CB_Post_Stationery.SelectedIndex = -1;
        }
    }

    private void UpdateSenderType(object sender, EventArgs e)
    {
        if (CB_Post_SenderType.SelectedIndex == 0) // Player
        {
            GB_Post_NPC.Enabled = false;
            GB_Post_Player.Enabled = true;
            L_InternalName.Text = "player";
            L_ExternalName.Text = "Player";
            PB_Villager.Image = null;
        }
        else if (CB_Post_SenderType.SelectedIndex == 1) // Villager
        {
            GB_Post_NPC.Enabled = false;
            GB_Post_Player.Enabled = false;
        }
        else
        {
            GB_Post_NPC.Enabled = true;
            GB_Post_Player.Enabled = false;
        }
    }

    private void UpdateMailCounters(object sender, EventArgs e) => UpdateMailCounters();
    private void UpdateMailCounters()
    {
        void UpdateCounter(Label label, TextBox textBox, int maxLength)
        {
            var currentLength = textBox.Text.Replace("\r\n", "\n").Length;
            label.Text = currentLength + " / " + maxLength;
            label.ForeColor = currentLength > maxLength
                ? System.Drawing.Color.Red
                : System.Drawing.SystemColors.WindowText;
        }

        UpdateCounter(L_Post_CountTo, TB_Post_ToLine, LetterToTextLength);
        UpdateCounter(L_Post_CountMsg, TB_Post_Message, LetterMessageTextLength);
        UpdateCounter(L_Post_CountFrom, TB_Post_FromLine, LetterFromTextLength);
    }

    private void ResetInterface()
    {
        L_InternalName.Text = "";
        L_ExternalName.Text = "";
        PB_Villager.Image = null;
        TB_Post_ToLine.Text = "";
        TB_Post_Message.Text = "";
        TB_Post_FromLine.Text = "";
        CK_Post_Read.Checked = false;
        CK_Post_Faved.Checked = false;
        CAL_PostTimestamp.Value = DateTime.Now;
        CB_Post_SenderType.SelectedIndex = -1;
        CB_Post_NPC.SelectedIndex = -1;
        TB_Post_PlayerName.Text = "";
        TB_Post_ReceiverPlayer.Text = "";
        TB_Post_ReceiverIsland.Text = "";
        CB_Post_Language.SelectedIndex = -1;
        CB_Post_Stationery.SelectedIndex = -1;
        CB_Post_MailType.SelectedIndex = -1;
        CB_Post_AttachmentSkin.Items.Clear();
    }


    private void LoadMailItem(object sender, EventArgs e) => LoadMailItem();
    private void LoadMailItem()
    {
        ResetInterface();

        if (PostBox.GetUsedPostBoxSlots().Count == 0)
        {
            MessageBox.Show("No mail items found in the post box.");
            return;
        }

        if(PostBox.GetMailCheck((int)NUD_Post_Slots.Value) == false)
        {
            return;
        }

        LoadVillagerFromMail();
        LoadMailText();
        LoadMailProperties();
        LoadMailAttachment();
    }

    private void LoadVillagerFromMail()
    {
        var index = (int)NUD_Post_Slots.Value;
        NUD_Species.Value = PostBox.GetVillagerSenderSpeciesId(index);
        NUD_Variant.Value = PostBox.GetVillagerSenderVariantId(index);

        CB_Post_SenderType.SelectedIndex = PostBox.GetSenderType(index);

        ChangeVillager();
    }

    private void LoadMailText()
    {
        var index = (int)NUD_Post_Slots.Value;

        var toText = PostBox.GetLetterToLineText(index);
        TB_Post_ToLine.Text = toText;
        var msgText = PostBox.GetLetterMessageText(index);
        TB_Post_Message.Text = msgText.Replace("\n", "\r\n");
        var fromText = PostBox.GetLetterFromLineText(index);
        TB_Post_FromLine.Text = fromText;

        UpdateMailCounters();
    }

    private void LoadMailProperties()
    {
        var index = (int)NUD_Post_Slots.Value;

        CK_Post_Read.Checked = PostBox.GetMailReadStatus(index);
        CK_Post_Faved.Checked = PostBox.GetMailFavStatus(index);
        CAL_PostTimestamp.Value = PostBox.GetTimestamp(index);
        CB_Post_SenderType.SelectedIndex = PostBox.GetSenderType(index);

        SenderNPCData.TryGetValue((int)NUD_Species.Value, out var npcData);

        if (CB_Post_SenderType.SelectedIndex == 2 && npcData != null) // NPC
            CB_Post_NPC.SelectedIndex = npcData.MappingIndex;

        if (CB_Post_SenderType.SelectedIndex == 0) // Player
            TB_Post_PlayerName.Text = PostBox.GetSenderName(index);

        TB_Post_ReceiverPlayer.Text = PostBox.GetReceiverPlayerName(index);
        TB_Post_ReceiverIsland.Text = PostBox.GetReceiverIslandName(index);

        var lang = PostBox.GetMailLanguageString(index);
        if (lang != null && BCP47LanguageString.ContainsKey(lang))
        {
            CB_Post_Language.SelectedIndex = BCP47LanguageString[lang];
        }
        else
        {
            CB_Post_Language.SelectedIndex = -1;
        }

        var stationerySkin = PostBox.GetMailStationerySkin(index);
        if (LetterStationerySkin.ContainsKey(stationerySkin))
        {
            CB_Post_Stationery.SelectedIndex = LetterStationerySkin[stationerySkin].index;
        }
        else
        {
            CB_Post_Stationery.SelectedIndex = -1;
        }
    }

    private void LoadMailAttachment()
    {
        var index = (int)NUD_Post_Slots.Value;

        var attachedItemId = PostBox.GetAttachedItem(index);
        Attachment = ItemEditor.LoadItem(attachedItemId);

        var wrap = PostBox.GetItemWrappingType(index);
        var letterType = PostBox.GetMailType(index);

        CB_Post_MailType.SelectedIndex = Convert.ToInt32(letterType);

        if (CB_Post_MailType.SelectedIndex == 1)
        {
            CB_Post_Stationery.Enabled = true;
            CB_Post_AttachmentSkin.Items.Clear();
            CB_Post_AttachmentSkin.Items.AddRange(Wrap);
            CB_Post_AttachmentSkin.SelectedIndex = ItemWrappingExtended.ItemWrappingSkin[wrap].index;
        }
        if (CB_Post_MailType.SelectedIndex == 0)
        {
            CB_Post_Stationery.Enabled = false;
            CB_Post_AttachmentSkin.Items.Clear();
            CB_Post_AttachmentSkin.Items.AddRange(Box);
            CB_Post_AttachmentSkin.SelectedIndex = ItemWrappingExtended.ItemBoxSkin[wrap].index;
            CB_Post_Stationery.SelectedIndex = -1;
        }
    }

    private void UpdateMailSlotIndex(int index)
    {
        if (!PostBox.GetMailCheck(index) || PostBox.GetPostBoxSortIndex(index) == 0x00)
        {
            var nextSlot = PostBox.GetLatestUniqueId();
            PostBox.SetPostBoxSortIndex(index, (byte)nextSlot);
            PostBox.SetLatestUniqueId(nextSlot + 1);
        }
    }

    private void UpdateMailSenderInfo(int index)
    {
        PostBox.SetSenderType(index, (byte)CB_Post_SenderType.SelectedIndex);
        if (CB_Post_SenderType.SelectedIndex == 0x00) // Player
        {
            PostBox.SetPlayerSenderIslandId(index, Player.Personal.TownID);
            PostBox.SetPlayerSenderIslandName(index, Player.Personal.TownName);
            PostBox.SetSenderId(index, Player.Personal.PlayerID);
            PostBox.SetSenderName(index, TB_Post_PlayerName.Text);
        }

        if (CB_Post_SenderType.SelectedIndex == 0x01) // Villager
        {
            PostBox.SetVillagerSenderSpeciesId(index, (int)NUD_Species.Value);
            PostBox.SetVillagerSenderVariantId(index, (int)NUD_Variant.Value);
            PostBox.SetNPCSenderIslandId(index, Player.Personal.TownID);
            PostBox.SetNPCSenderIslandName(index, Player.Personal.TownName);
            PostBox.SetSenderId(index, 0x02);
            // Don't set a sender nameNPC, this is blank for villagers.
        }

        if (CB_Post_SenderType.SelectedIndex == 0x02) // NPC
        {
            PostBox.SetVillagerSenderSpeciesId(index, (int)NUD_Species.Value);
            PostBox.SetVillagerSenderVariantId(index, (int)NUD_Variant.Value);
            // Don't set a sender island ID or nameNPC, this is blank for NPCs.
            PostBox.SetSenderId(index, 0x00);
            // Don't set a sender nameNPC, this is blank for NPCs.
        }
    }

    private void UpdateMailAttachment(int index)
    {
        PostBox.SetAttachedItem(index, ItemEditor.SetItem(Attachment));

        var selectedSkinIndex = CB_Post_AttachmentSkin.SelectedIndex;
        if (CB_Post_MailType.SelectedIndex == 1)
        {
            PostBox.SetMailType(index, true);
            var attachmentSkin = ItemWrappingExtended.ItemWrappingSkin.FirstOrDefault(x => x.Value.index == selectedSkinIndex);
            if (attachmentSkin.Value != null)
            {
                PostBox.SetItemWrappingType(index, (byte)attachmentSkin.Key);
            }

            var letterSkinIndex = CB_Post_Stationery.SelectedIndex;
            var letterSkin = (ushort)LetterStationerySkin.FirstOrDefault(skin => skin.Value.index == letterSkinIndex).Key;
            PostBox.SetMailStationerySkin(index, letterSkin);
        }
        else if (CB_Post_MailType.SelectedIndex == 0)
        {
            PostBox.SetMailType(index, false);
            var attachmentSkin = ItemWrappingExtended.ItemBoxSkin.FirstOrDefault(x => x.Value.index == selectedSkinIndex);
            if (attachmentSkin.Value != null)
            {
                PostBox.SetItemWrappingType(index, (byte)attachmentSkin.Key);
            }

            PostBox.SetMailStationerySkin(index, 0);
        }
    }

    private void UpdateMailReceiverInfo(int index)
    {
        PostBox.SetReceiverPlayerName(index, TB_Post_ReceiverPlayer.Text);
        PostBox.SetReceiverPlayerId(index, Player.Personal.PlayerID);
        PostBox.SetReceiverIslandName(index, TB_Post_ReceiverIsland.Text);
        PostBox.SetReceiverIslandId(index, Player.Personal.TownID);
    }

    private void UpdateMailText(int index)
    {
        var langString = BCP47LanguageString.FirstOrDefault(x => x.Value == CB_Post_Language.SelectedIndex).Key;
        PostBox.SetMailLanguageString(index, langString, CB_Post_SenderType.SelectedIndex == 0);
        PostBox.SetLetterToLineText(index, TB_Post_ToLine.Text.Replace("\r\n", "\n").Replace("\n", ""));
        PostBox.SetLetterMessageText(index, TB_Post_Message.Text.Replace("\r\n", "\n"));
        PostBox.SetLetterFromLineText(index, TB_Post_FromLine.Text.Replace("\r\n", "\n").Replace("\n", ""));
    }

    private void UpdateMailItem(object sender, EventArgs e)
    {
        var index = (int)NUD_Post_Slots.Value;

        UpdateMailSlotIndex(index);

        PostBox.WipeTxRxSection(index);

        PostBox.SetMailReadStatus(index, CK_Post_Read.Checked);
        PostBox.SetMailFavStatus(index, CK_Post_Faved.Checked);

        UpdateMailSenderInfo(index);

        UpdateMailReceiverInfo(index);

        UpdateMailAttachment(index);

        UpdateMailText(index);

        PostBox.SetTimeStamp(index, CAL_PostTimestamp.Value);
    }

    private void ImportPostItem(int index)
    {
        var currentIndex = PostBox.GetPostBoxSortIndex(index);
        int currentUniqueId = PostBox.GetLatestUniqueId();

        currentUniqueId = Math.Min(currentUniqueId, 299); // Cap unique ID to prevent overflow and ensure it stays within the 300 mail item limit.

        if(currentIndex != 0x00 || PostBox.GetMailCheck(index))
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "New Horizons Post (*.nhpb)|*.nhpb|All files (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            var d = File.ReadAllBytes(ofd.FileName);
            PostBox.SetIndividualLetter(index, d);
            PostBox.SetPostBoxSortIndex(index, (byte)currentIndex);
        }
        else
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "New Horizons Post (*.nhpb)|*.nhpb|All files (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            var d = File.ReadAllBytes(ofd.FileName);
            PostBox.SetIndividualLetter(index, d);
            PostBox.SetPostBoxSortIndex(index, (byte)currentUniqueId);
            PostBox.SetLatestUniqueId(Math.Min(currentUniqueId + 1, 299));
        }
        LoadMailItem();
    }
    private void DumpPostItem(int index)
    {
        var name = Player.Personal.PlayerName + "_Post_Slot" + index + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
        using var sfd = new SaveFileDialog();
        sfd.Filter = "New Horizons Post (*.nhpb)|*.nhpb|All files (*.*)|*.*";
        sfd.FileName = $"{name}.nhpb";
        if (sfd.ShowDialog() != DialogResult.OK)
            return;

        var d = PostBox.GetIndividualLetter(index);
        File.WriteAllBytes(sfd.FileName, d);
    }

    private void DumpAllPostItems()
    {
        using var fbd = new FolderBrowserDialog();
        if (fbd.ShowDialog() != DialogResult.OK)
            return;
        var postSlots = PostBox.GetUsedPostBoxSlots();
        postSlots.ForEach(i =>
        {
            var name = Player.Personal.PlayerName + "_Post_Slot" + i + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            var path = Path.Combine(fbd.SelectedPath, $"{name}.nhpb");
            var d = PostBox.GetIndividualLetter(i);
            File.WriteAllBytes(path, d);
        });
    }

    private void B_Dump_Click(object sender, EventArgs e)
    {
        var index = (int)NUD_Post_Slots.Value;

        if (sender == B_Post_DumpAll)
        {
            DumpAllPostItems();
            SystemSounds.Asterisk.Play();
        }
        else
        {
            DumpPostItem(index);
            SystemSounds.Asterisk.Play();
        }
    }

    private void B_Import_Click(object sender, EventArgs e)
    {
        var index = (int)NUD_Post_Slots.Value;
        ImportPostItem(index);
        SystemSounds.Asterisk.Play();
    }

    private void B_Delete_Click(object sender, EventArgs e)
    {
        var index = (int)NUD_Post_Slots.Value;

        var arr = new byte[Mail.SIZE];
        arr[AttachedItemID] = 0xFE;
        arr[AttachedItemID + 1] = 0xFF;
        arr[PostBoxSortIndex - 4] = 0xFE;
        arr[PostBoxSortIndex - 3] = 0xFF;
        Span<byte> bytes = arr;
        PostBox.SetIndividualLetter(index, bytes);

        SystemSounds.Asterisk.Play();
    }

    private void B_Save_Click(object sender, EventArgs e)
    {
        UpdateMailItem(sender, e);
        SystemSounds.Asterisk.Play();
    }

    private void B_Cancel_Click(object sender, EventArgs e) => Close();
}

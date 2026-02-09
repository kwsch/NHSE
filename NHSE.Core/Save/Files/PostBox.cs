using System;
using System.Collections.Generic;
using System.Text;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// Data structures stored for the players Post Box (postbox.dat)
/// </summary>
public sealed class PostBox : EncryptedFilePair
{
    public const string FileName = "postbox";
    public readonly PostBoxOffsets Offsets;
    public PostBox(ISaveFileProvider provider) : base(provider, FileName) => Offsets = PostBoxOffsets.GetOffsets(Info);

    public readonly int MailLength = Mail.SIZE;
    public readonly int MailListLength = 0x46E60;
    public readonly int MaxMailItems = Mail.MaxSlots;

    public Span<byte> Get_s_7b602b39() => Data.Slice(Offsets.s_7b602b39, 4);

    public Span<byte> MailListWholeRegion
    {
        get => Data.Slice(Offsets.MailList, MailListLength);
        set => value.CopyTo(Data[Offsets.MailList..]);
    }

    public Span<byte> GetIndividualLetter(int index) => Data.Slice(Offsets.MailList + (MailLength * index), MailLength);
    public void SetIndividualLetter(int index, Span<byte> value)
    {
        value.CopyTo(Data[(Offsets.MailList + (MailLength * index))..]);
    }

    public List<int> GetUsedPostBoxSlots()
    {
        var usedSlots = new List<int>();
        for (int i = 0; i < MaxMailItems; i++)
        {
            var readStatus = MailListWholeRegion[(MailLength * i) + Mail.ReadUnread];
            if (readStatus == 0x03 || readStatus == 0x04)
                usedSlots.Add(i);
        }
        return usedSlots;
    }

    public int GetLatestUniqueId()
    {
        return ReadInt32LittleEndian(Data.Slice(Offsets.LatestUniqueId, 4));
    }
    public void SetLatestUniqueId(int uniqueId)
    {
        WriteInt32LittleEndian(Data.Slice(Offsets.LatestUniqueId, 4), uniqueId);
    }

    #region Mail

    public void WipeTxRxSection(int index)
    {
        var arr = new byte[0x60];
        Span<byte> bytes = arr;
        bytes.CopyTo(Data[(Offsets.MailList + (MailLength * index) + Mail.ReadUnread)..]);
    }

    public bool GetMailCheck(int index)
    {
        return Data[Offsets.MailList + (MailLength * index) + Mail.ReadUnread] != 0x00;
    }
    public bool GetMailReadStatus(int index)
    {
        return Data[Offsets.MailList + (MailLength * index) + Mail.ReadUnread] != 0x03;
    }
    public void SetMailReadStatus(int index, bool isRead)
    {
        Data[Offsets.MailList + (MailLength * index) + Mail.ReadUnread] = isRead ? (byte)0x04 : (byte)0x03;
    }

    public bool GetMailFavStatus(int index)
    {
        return Data[Offsets.MailList + (MailLength * index) + Mail.LetterFavourited] != 0x00;
    }
    public void SetMailFavStatus(int index, bool isFavourite)
    {
        Data[Offsets.MailList + (MailLength * index) + Mail.LetterFavourited] = isFavourite ? (byte)0x01 : (byte)0x00;
    }

    public uint GetPlayerSenderIslandId(int index)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.PlayerSenderIslandID;
        return ReadUInt32LittleEndian(Data.Slice(offset, 4));
    }
    public void SetPlayerSenderIslandId(int index, uint islandId)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.PlayerSenderIslandID;
        WriteUInt32LittleEndian(Data.Slice(offset, 4), islandId);
    }

    public string GetPlayerSenderIslandName(int index)
    {
        return GetString(Offsets.MailList + (MailLength * index) + Mail.PlayerSenderIslandName, 10);
    }
    public void SetPlayerSenderIslandName(int index, string islandName)
    {
        var nameBytes = GetBytes(islandName, 10);
        nameBytes.CopyTo(Data[(Offsets.MailList + (MailLength * index) + Mail.PlayerSenderIslandName)..]);
    }

    public byte GetVillagerSenderSpeciesId(int index)
    {
        return Data[Offsets.MailList + (MailLength * index) + Mail.NPCSenderSpeciesID];
    }
    public void SetVillagerSenderSpeciesId(int index, int speciesId)
    {
        Data[Offsets.MailList + (MailLength * index) + Mail.NPCSenderSpeciesID] = (byte)speciesId;
    }
    public byte GetVillagerSenderVariantId(int index)
    {
        return Data[Offsets.MailList + (MailLength * index) + Mail.NPCSenderVariantID];
    }
    public void SetVillagerSenderVariantId(int index, int variantId)
    {
        Data[Offsets.MailList + (MailLength * index) + Mail.NPCSenderVariantID] = (byte)variantId;
    }

    public uint GetNPCSenderIslandId(int index)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.NPCSenderIslandID;
        return ReadUInt32LittleEndian(Data.Slice(offset, 4));
    }
    public void SetNPCSenderIslandId(int index, uint islandId)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.NPCSenderIslandID;
        WriteUInt32LittleEndian(Data.Slice(offset, 4), islandId);
    }
    public string GetNPCSenderIslandName(int index)
    {
        return GetString(Offsets.MailList + (MailLength * index) + Mail.NPCSenderIslandName, 10);
    }
    public void SetNPCSenderIslandName(int index, string islandName)
    {
        var nameBytes = GetBytes(islandName, 20);
        nameBytes.CopyTo(Data[(Offsets.MailList + (MailLength * index) + Mail.NPCSenderIslandName)..]);
    }

    public uint GetSenderId(int index)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.SenderID;
        return ReadUInt32LittleEndian(Data.Slice(offset, 4));
    }
    public void SetSenderId(int index, uint senderId)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.SenderID;
        WriteUInt32LittleEndian(Data.Slice(offset, 4), senderId);
    }
    public string GetSenderName(int index)
    {
        return GetString(Offsets.MailList + (MailLength * index) + Mail.SenderName, 10);
    }
    public void SetSenderName(int index, string senderName)
    {
        var nameBytes = GetBytes(senderName, 10);
        nameBytes.CopyTo(Data[(Offsets.MailList + (MailLength * index) + Mail.SenderName)..]);
    }
    public byte GetSenderType(int index)
    {
        return Data[Offsets.MailList + (MailLength * index) + Mail.SenderType];
    }
    public void SetSenderType(int index, byte senderType)
    {
        Data[Offsets.MailList + (MailLength * index) + Mail.SenderType] = senderType;
    }

    public uint GetReceiverIslandId(int index)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.ReceiverIslandID;
        return ReadUInt32LittleEndian(Data.Slice(offset, 4));
    }
    public void SetReceiverIslandId(int index, uint islandId)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.ReceiverIslandID;
        WriteUInt32LittleEndian(Data.Slice(offset, 4), islandId);
    }
    public string GetReceiverIslandName(int index)
    {
        return GetString(Offsets.MailList + (MailLength * index) + Mail.ReceiverIslandName, 10);
    }
    public void SetReceiverIslandName(int index, string islandName)
    {
        var nameBytes = GetBytes(islandName, 10);
        nameBytes.CopyTo(Data[(Offsets.MailList + (MailLength * index) + Mail.ReceiverIslandName)..]);
    }

    public uint GetReceiverPlayerId(int index)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.ReceiverPlayerID;
        return ReadUInt32LittleEndian(Data.Slice(offset, 4));
    }
    public void SetReceiverPlayerId(int index, uint playerId)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.ReceiverPlayerID;
        WriteUInt32LittleEndian(Data.Slice(offset, 4), playerId);
    }
    public string GetReceiverPlayerName(int index)
    {
        return GetString(Offsets.MailList + (MailLength * index) + Mail.ReceiverPlayerName, 10);
    }
    public void SetReceiverPlayerName(int index, string playerName)
    {
        var nameBytes = GetBytes(playerName, 10);
        nameBytes.CopyTo(Data[(Offsets.MailList + (MailLength * index) + Mail.ReceiverPlayerName)..]);
    }

    public GSaveDate GetTimestamp(int index)
    {
        return Data.ToStructure<GSaveDate>(Offsets.MailList + (MailLength * index) + Mail.TimeStamp, GSaveDate.SIZE);
    }
    public void SetTimeStamp(int index, GSaveDate timestamp)
    {
        timestamp.ToBytes().CopyTo(Data[(Offsets.MailList + (MailLength * index) + Mail.TimeStamp)..]);
    }

    public Item GetAttachedItem(int index)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.AttachedItemID;
        return Item.GetArray(Data.Slice(offset, Item.SIZE))[0];
    }
    public void SetAttachedItem(int index, Item item)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.AttachedItemID;
        var itemBytes = Item.SetArray(new[] { item });
        itemBytes.CopyTo(Data[offset..]);
    }

    public byte GetItemWrappingType(int index)
    {
        return Data[Offsets.MailList + (MailLength * index) + Mail.MailItemWrappingType];
    }
    public void SetItemWrappingType(int index, byte wrappingType)
    {
        Data[Offsets.MailList + (MailLength * index) + Mail.MailItemWrappingType] = wrappingType;
    }

    public bool GetMailType(int index)
    {
        var offset = Offsets.MailList + (MailLength * index);
        return Data[offset + Mail.MailType01] == 0x00 && Data[offset + Mail.MailType02] == 0x01; // Letter or boxed type
    }
    public void SetMailType(int index, bool letter)
    {
        var offset = Offsets.MailList + (MailLength * index);
        if (letter) { Data[offset + Mail.MailType01] = 0x00; Data[offset + Mail.MailType02] = 0x01; } // Letter type
        else { Data[offset + Mail.MailType01] = 0x01; Data[offset + Mail.MailType02] = 0x00; } // Boxed item type
    }

    public string GetLetterToLineText(int index)
    {
        return GetString(Offsets.MailList + (MailLength * index) + Mail.LetterToLineText, Mail.LetterToTextLength);
    }
    public void SetLetterToLineText(int index, string toLineText)
    {
        var textBytes = GetBytes(toLineText, Mail.LetterToTextLength);
        textBytes.CopyTo(Data[(Offsets.MailList + (MailLength * index) + Mail.LetterToLineText)..]);
    }
    public string GetLetterMessageText(int index)
    {
        return GetString(Offsets.MailList + (MailLength * index) + Mail.LetterMessageText, Mail.LetterMessageTextLength);
    }
    public void SetLetterMessageText(int index, string messageText)
    {
        var textBytes = GetBytes(messageText, Mail.LetterMessageTextLength);
        textBytes.CopyTo(Data[(Offsets.MailList + (MailLength * index) + Mail.LetterMessageText)..]);
    }
    public string GetLetterFromLineText(int index)
    {
        return GetString(Offsets.MailList + (MailLength * index) + Mail.LetterFromLineText, Mail.LetterFromTextLength);
    }
    public void SetLetterFromLineText(int index, string fromLineText)
    {
        var textBytes = GetBytes(fromLineText, Mail.LetterFromTextLength);
        textBytes.CopyTo(Data[(Offsets.MailList + (MailLength * index) + Mail.LetterFromLineText)..]);
    }
    public ushort GetMailStationerySkin(int index)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.MailStationerySkin;
        return ReadUInt16LittleEndian(Data.Slice(offset, 2));
    }
    public void SetMailStationerySkin(int index, ushort skinCode)
    {
        var offset = Offsets.MailList + (MailLength * index) + Mail.MailStationerySkin;
        WriteUInt16LittleEndian(Data.Slice(offset, 2), skinCode);
    }

    public byte GetPostBoxSortIndex(int index)
    {
        return Data[Offsets.MailList + (MailLength * index) + Mail.PostBoxSortIndex];
    }
    public void SetPostBoxSortIndex(int index, byte sortIndex)
    {
        Data[Offsets.MailList + (MailLength * index) + Mail.PostBoxSortIndex] = sortIndex;
    }

    public string GetMailLanguageString(int index)
    {
        return Encoding.UTF8.GetString(Data.Slice(Offsets.MailList + (MailLength * index) + Mail.LanguageString, 5));
    }

    /// <summary>
    /// Sets or clears the language string for a mail item at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the mail item in the postbox.</param>
    /// <param name="languageString">The  IETF BCP 47 language tag string to set (e.g., "en-US", "ja-JP").</param>
    /// <param name="player">If <c>true</c>, sets the language string; if <c>false</c>, clears the language data.</param>
    public void SetMailLanguageString(int index, string languageString, bool player)
    {
        var langOffset = Offsets.MailList + (MailLength * index) + Mail.LanguageString;
        if (player) { GetBytes(languageString, 5).CopyTo(Data[langOffset..]); }
        else { Data.Slice(langOffset, 5).Clear(); }
    }

    #endregion
}
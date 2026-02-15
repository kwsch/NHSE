using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// personal.dat
/// </summary>
public sealed class Personal : EncryptedFilePair, IVillagerOrigin
{
    public readonly PersonalOffsets Offsets;
    public Personal(ISaveFileProvider provider) : base(provider, "personal") => Offsets = PersonalOffsets.GetOffsets(Info);
    public override string ToString() => PlayerName;

    public uint TownID
    {
        get => ReadUInt32LittleEndian(Data[(Offsets.PersonalId + 0x00)..]);
        set => WriteUInt32LittleEndian(Data[(Offsets.PersonalId + 0x00)..], value);
    }

    public string TownName
    {
        get => GetString(Offsets.PersonalId + 0x04, 10);
        set => GetBytes(value, 10).CopyTo(Data[(Offsets.PersonalId + 0x04)..]);
    }

    public Span<byte> GetTownIdentity() => Data.Slice(Offsets.PersonalId + 0x00, 4 + 20);

    public uint PlayerID
    {
        get => ReadUInt32LittleEndian(Data[(Offsets.PersonalId + 0x1C)..]);
        set => WriteUInt32LittleEndian(Data[(Offsets.PersonalId + 0x1C)..], value);
    }

    public string PlayerName
    {
        get => GetString(Offsets.PersonalId + 0x20, 10);
        set => GetBytes(value, 10).CopyTo(Data[(Offsets.PersonalId + 0x20)..]);
    }

    public Span<byte> GetPlayerIdentity() => Data.Slice(Offsets.PersonalId + 0x1C, 4 + 20);

    public EncryptedInt32 Wallet
    {
        get => EncryptedInt32.ReadVerify(Data, Offsets.Wallet);
        set => value.Write(Data[Offsets.Wallet..]);
    }

    public EncryptedInt32 Bank
    {
        get => EncryptedInt32.ReadVerify(Data, Offsets.Bank);
        set => value.Write(Data[Offsets.Bank..]);
    }

    public EncryptedInt32 NookMiles
    {
        get => EncryptedInt32.ReadVerify(Data, Offsets.NowPoint);
        set => value.Write(Data[Offsets.NowPoint..]);
    }

    public EncryptedInt32 TotalNookMiles
    {
        get => EncryptedInt32.ReadVerify(Data, Offsets.TotalPoint);
        set => value.Write(Data[Offsets.TotalPoint..]);
    }

    public IReadOnlyList<Item> Bag // Slots 21-40
    {
        get => Item.GetArray(Data.Slice(Offsets.Pockets1, Offsets.Pockets1Count * Item.SIZE));
        set => Item.SetArray(value).CopyTo(Data[Offsets.Pockets1..]);
    }

    public uint BagCount // Count of the Bag Slots that are available for use
    {
        get => ReadUInt32LittleEndian(Data[(Offsets.Pockets1 + (Offsets.Pockets1Count * Item.SIZE))..]);
        set => WriteUInt32LittleEndian(Data[(Offsets.Pockets1 + (Offsets.Pockets1Count * Item.SIZE))..], value);
    }

    public IReadOnlyList<Item> Pocket // Slots 1-20
    {
        get => Item.GetArray(Data.Slice(Offsets.Pockets2, Offsets.Pockets2Count * Item.SIZE));
        set => Item.SetArray(value).CopyTo(Data[Offsets.Pockets2..]);
    }

    public uint PocketCount // Count of the Pocket Slots that are available for use
    {
        get => ReadUInt32LittleEndian(Data[(Offsets.Pockets2 + (Offsets.Pockets2Count * Item.SIZE))..]);
        set => WriteUInt32LittleEndian(Data[(Offsets.Pockets2 + (Offsets.Pockets2Count * Item.SIZE))..], value);
    }

    public IReadOnlyList<Item> ItemChest
    {
        get => Item.GetArray(Data.Slice(Offsets.ItemChest, Offsets.ItemChestCount * Item.SIZE));
        set => Item.SetArray(value).CopyTo(Data[Offsets.ItemChest..]);
    }

    public uint ItemChestCount // Count of the Item Chest Slots that are available for use
    {
        get => ReadUInt32LittleEndian(Data[(Offsets.ItemChest + (Offsets.ItemChestCount * Item.SIZE))..]);
        set => WriteUInt32LittleEndian(Data[(Offsets.ItemChest + (Offsets.ItemChestCount * Item.SIZE))..], value);
    }

    public IReactionStore Reactions
    {
        get => Offsets.ReadReactions(Data);
        set => Offsets.SetReactions(Data, value);
    }

    public AchievementList Achievements
    {
        get => Data.Slice(Offsets.CountAchievement, AchievementList.SIZE).ToStructure<AchievementList>();
        set => value.ToBytes().CopyTo(Data[Offsets.CountAchievement..]);
    }

    public RecipeBook GetRecipeBook() => new(Data.Slice(Offsets.Recipes, RecipeBook.SIZE).ToArray());
    public void SetRecipeBook(RecipeBook book) => book.Save(Data[Offsets.Recipes..]);

    public short[] GetEventFlagsPlayer()
    {
        var slice = Data.Slice(Offsets.EventFlagsPlayer, Offsets.EventFlagsPlayerLength);
        return MemoryMarshal.Cast<byte, short>(slice).ToArray();
    }

    public void SetEventFlagsPlayer(Span<short> value)
    {
        var slice = Data.Slice(Offsets.EventFlagsPlayer, Offsets.EventFlagsPlayerLength);
        var cast = MemoryMarshal.Cast<byte, short>(slice);
        value.CopyTo(cast);
    }

    public GSaveDateMD Birthday
    {
        get => Data.ToStructure<GSaveDateMD>(Offsets.Birthday, GSaveDateMD.SIZE);
        set => value.ToBytes().CopyTo(Data[Offsets.Birthday..]);
    }

    #region Profile

    public byte[] GetPhotoData()
    {
        var offset = Offsets.ProfilePhoto;

        // Expect jpeg marker
        if (ReadUInt16LittleEndian(Data[offset..]) != 0xD8FF)
            return [];
        var len = ReadInt32LittleEndian(Data[(offset - 4)..]);
        return Data.Slice(offset, len).ToArray();
    }

    public GSaveDateMD ProfileBirthday
    {
        get => Data.ToStructure<GSaveDateMD>(Offsets.ProfileBirthday, GSaveDateMD.SIZE);
        set => value.ToBytes().CopyTo(Data[Offsets.ProfileBirthday..]);
    }

    public ushort ProfileFruit
    {
        get => ReadUInt16LittleEndian(Data[Offsets.ProfileFruit..]);
        set => WriteUInt16LittleEndian(Data[Offsets.ProfileFruit..], value);
    }

    public GSaveDate ProfileTimestamp
    {
        get => Data.ToStructure<GSaveDate>(Offsets.ProfileTimestamp, GSaveDate.SIZE);
        set => value.ToBytes().CopyTo(Data[Offsets.ProfileTimestamp..]);
    }

    public bool ProfileIsMakeVillage
    {
        get => Data[Offsets.ProfileIsMakeVillage] != 0;
        set => Data[Offsets.ProfileIsMakeVillage] = (byte)(value ? 1 : 0);
    }

    /// <summary>
    /// Appended structure added in 3.0.0 for Hotel data.
    /// </summary>
    public Personal30? Data30 => (Offsets as IPersonal30)?.Get30s_064c1881(Raw);

    #endregion
}
using System;
using System.Collections.Generic;

namespace NHSE.Core
{
    /// <summary>
    /// personal.dat
    /// </summary>
    public sealed class Personal : EncryptedFilePair, IVillagerOrigin
    {
        public readonly PersonalOffsets Offsets;
        public Personal(string folder) : base(folder, "personal") => Offsets = PersonalOffsets.GetOffsets(Info);
        public override string ToString() => PlayerName;

        public uint TownID
        {
            get => BitConverter.ToUInt32(Data, Offsets.PersonalId + 0x00);
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.PersonalId + 0x00);
        }

        public string TownName
        {
            get => GetString(Offsets.PersonalId + 0x04, 10);
            set => GetBytes(value, 10).CopyTo(Data, Offsets.PersonalId + 0x04);
        }

        public byte[] GetTownIdentity() => Data.Slice(Offsets.PersonalId + 0x00, 4 + 20);

        public uint PlayerID
        {
            get => BitConverter.ToUInt32(Data, Offsets.PersonalId + 0x1C);
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.PersonalId + 0x1C);
        }

        public string PlayerName
        {
            get => GetString(Offsets.PersonalId + 0x20, 10);
            set => GetBytes(value, 10).CopyTo(Data, Offsets.PersonalId + 0x20);
        }

        public byte[] GetPlayerIdentity() => Data.Slice(Offsets.PersonalId + 0x1C, 4 + 20);

        public EncryptedInt32 Wallet
        {
            get => EncryptedInt32.ReadVerify(Data, Offsets.Wallet);
            set => value.Write(Data, Offsets.Wallet);
        }

        public EncryptedInt32 Bank
        {
            get => EncryptedInt32.ReadVerify(Data, Offsets.Bank);
            set => value.Write(Data, Offsets.Bank);
        }

        public EncryptedInt32 NookMiles
        {
            get => EncryptedInt32.ReadVerify(Data, Offsets.NowPoint);
            set => value.Write(Data, Offsets.NowPoint);
        }

        public EncryptedInt32 TotalNookMiles
        {
            get => EncryptedInt32.ReadVerify(Data, Offsets.TotalPoint);
            set => value.Write(Data, Offsets.TotalPoint);
        }

        public IReadOnlyList<Item> Bag // Slots 21-40
        {
            get => Item.GetArray(Data.Slice(Offsets.Pockets1, Offsets.Pockets1Count * Item.SIZE));
            set => Item.SetArray(value).CopyTo(Data, Offsets.Pockets1);
        }

        public uint BagCount // Count of the Bag Slots that are available for use
        {
            get => BitConverter.ToUInt32(Data, Offsets.Pockets1 + (Offsets.Pockets1Count * Item.SIZE));
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.Pockets1 + (Offsets.Pockets1Count * Item.SIZE));
        }

        public IReadOnlyList<Item> Pocket // Slots 1-20
        {
            get => Item.GetArray(Data.Slice(Offsets.Pockets2, Offsets.Pockets2Count * Item.SIZE));
            set => Item.SetArray(value).CopyTo(Data, Offsets.Pockets2);
        }

        public uint PocketCount // Count of the Pocket Slots that are available for use
        {
            get => BitConverter.ToUInt32(Data, Offsets.Pockets2 + (Offsets.Pockets2Count * Item.SIZE));
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.Pockets2 + (Offsets.Pockets2Count * Item.SIZE));
        }

        public IReadOnlyList<Item> ItemChest
        {
            get => Item.GetArray(Data.Slice(Offsets.ItemChest, Offsets.ItemChestCount * Item.SIZE));
            set => Item.SetArray(value).CopyTo(Data, Offsets.ItemChest);
        }

        public uint ItemChestCount // Count of the Item Chest Slots that are available for use
        {
            get => BitConverter.ToUInt32(Data, Offsets.ItemChest + (Offsets.ItemChestCount * Item.SIZE));
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.ItemChest + (Offsets.ItemChestCount * Item.SIZE));
        }

        public IReactionStore Reactions
        {
            get => Offsets.ReadReactions(Data);
            set => Offsets.SetReactions(Data, value);
        }

        public AchievementList Achievements
        {
            get => Data.Slice(Offsets.CountAchievement, AchievementList.SIZE).ToStructure<AchievementList>();
            set => value.ToBytes().CopyTo(Data, Offsets.CountAchievement);
        }

        public RecipeBook GetRecipeBook() => new(Data.Slice(Offsets.Recipes, RecipeBook.SIZE));
        public void SetRecipeBook(RecipeBook book) => book.Save(Data, Offsets.Recipes);

        public short[] GetEventFlagsPlayer()
        {
            var result = new short[0xE00/2];
            Buffer.BlockCopy(Data, Offsets.EventFlagsPlayer, result, 0, result.Length * sizeof(short));
            return result;
        }

        public void SetEventFlagsPlayer(short[] value) => Buffer.BlockCopy(value, 0, Data, Offsets.EventFlagsPlayer, value.Length * sizeof(short));

        public GSaveDateMD Birthday
        {
            get => Data.ToStructure<GSaveDateMD>(Offsets.Birthday, GSaveDateMD.SIZE);
            set => value.ToBytes().CopyTo(Data, Offsets.Birthday);
        }

        #region Profile

        public byte[] GetPhotoData()
        {
            var offset = Offsets.ProfilePhoto;

            // Expect jpeg marker
            if (BitConverter.ToUInt16(Data, offset) != 0xD8FF)
                return Array.Empty<byte>();
            var len = BitConverter.ToInt32(Data, offset - 4);
            return Data.Slice(offset, len);
        }

        public GSaveDateMD ProfileBirthday
        {
            get => Data.ToStructure<GSaveDateMD>(Offsets.ProfileBirthday, GSaveDateMD.SIZE);
            set => value.ToBytes().CopyTo(Data, Offsets.ProfileBirthday);
        }

        public ushort ProfileFruit
        {
            get => BitConverter.ToUInt16(Data, Offsets.ProfileFruit);
            set => BitConverter.GetBytes(value).CopyTo(Data, Offsets.ProfileFruit);
        }

        public GSaveDate ProfileTimestamp
        {
            get => Data.ToStructure<GSaveDate>(Offsets.ProfileTimestamp, GSaveDate.SIZE);
            set => value.ToBytes().CopyTo(Data, Offsets.ProfileTimestamp);
        }

        public bool ProfileIsMakeVillage
        {
            get => Data[Offsets.ProfileIsMakeVillage] != 0;
            set => Data[Offsets.ProfileIsMakeVillage] = (byte)(value ? 1 : 0);
        }

        #endregion
    }
}
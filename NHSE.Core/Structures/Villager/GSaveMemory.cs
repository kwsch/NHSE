using System;

namespace NHSE.Core
{
    public class GSaveMemory : IVillagerOrigin
    {
        public const int SIZE = 0x5F0;

        public readonly byte[] Data;

        public GSaveMemory(byte[] data) => Data = data;

        public GSavePlayerId PlayerId
        {
            get => Data.Slice(0, GSavePlayerId.SIZE).ToStructure<GSavePlayerId>();
            set => value.ToBytes().CopyTo(Data, 0);
        }

        public uint TownID
        {
            get => BitConverter.ToUInt32(Data, 0x00);
            set => BitConverter.GetBytes(value).CopyTo(Data, 0x00);
        }

        public string TownName
        {
            get => StringUtil.GetString(Data, 0x04, 10);
            set => StringUtil.GetBytes(value, 10).CopyTo(Data, 0x04);
        }
        public byte[] GetTownIdentity() => Data.Slice(0x00, 4 + 20);

        public uint PlayerID
        {
            get => BitConverter.ToUInt32(Data, 0x1C);
            set => BitConverter.GetBytes(value).CopyTo(Data, 0x1C);
        }

        public string PlayerName
        {
            get => StringUtil.GetString(Data, 0x20, 10);
            set => StringUtil.GetBytes(value, 10).CopyTo(Data, 0x20);
        }

        public byte[] GetPlayerIdentity() => Data.Slice(0x1C, 4 + 20);

        public byte[] GetEventFlags() => Data.Slice(0x38, 0x100);
        public void SetEventFlags(byte[] value) => value.CopyTo(Data, 0x38);

        public byte Friendship { get => Data[0x38 + 10]; set => Data[0x38 + 10] = value; }

        public string NickName
        {
            get => StringUtil.GetString(Data, 0x138, 10);
            set => StringUtil.GetBytes(value, 10).CopyTo(Data, 0x138);
        }

        private const int GreetingCount = 11;
        public string GetGreeting(in int index)
        {
            var offset = GetGreetingOffset(index);
            return StringUtil.GetString(Data, offset, 22); // s_f6bf402b char16[48]. Render limit in-game is 22 char16s
        }

        private static int GetGreetingOffset(in int index)
        {
            if ((uint)index >= GreetingCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            return 0x14C + (0x60 * index);
        }

        public void SetGreeting(string value, int index)
        {
            var offset = GetGreetingOffset(index);
            StringUtil.GetBytes(value, 47).CopyTo(Data, offset);
        }

        public GSaveDate GreetingSetDate { get => Data.Slice(0x56C, GSaveDate.SIZE).ToStructure<GSaveDate>(); set => value.ToBytes().CopyTo(Data, 0x56C); }
    };
}

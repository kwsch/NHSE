using System;

namespace NHSE.Core
{
    public class GSaveMemory : IVillagerOrigin
    {
        public const int SIZE = 0x5F0;

        public readonly byte[] Data;

        public GSaveMemory(byte[] data) => Data = data;

        public GSavePlayerId PlayerId => Data.Slice(0, GSavePlayerId.SIZE).ToStructure<GSavePlayerId>();

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
        public byte[] GetTownIdentity() => Data.Slice(0x00, 20);

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

        public byte[] GetPlayerIdentity() => Data.Slice(0x1C, 20);

        public byte[] GetEventFlags() => Data.Slice(0x38, 0x100);
        public void SetEventFlags(byte[] value) => value.CopyTo(Data, 0x38);

        public byte Friendship { get => Data[0x38 + 10]; set => Data[0x38 + 10] = value; }
    };
}

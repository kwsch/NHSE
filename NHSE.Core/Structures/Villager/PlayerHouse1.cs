using System;

namespace NHSE.Core
{
    public class PlayerHouse1 : IPlayerHouse
    {
        public const int SIZE = 0x26400;
        public virtual string Extension => "nhph";

        public readonly byte[] Data;
        public PlayerHouse1(byte[] data) => Data = data;

        public byte[] Write() => Data;

        public uint HouseLevel { get => BitConverter.ToUInt32(Data, 0x00); set => BitConverter.GetBytes(value).CopyTo(Data, 0x00); }
        public WallType WallUniqueID { get => (WallType)BitConverter.ToUInt16(Data, 0x04); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x04); }
        public RoofType RoofUniqueID { get => (RoofType)BitConverter.ToUInt16(Data, 0x06); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x06); }
        public DoorKind DoorUniqueID { get => (DoorKind)BitConverter.ToUInt16(Data, 0x08); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x08); }
        public WallType OrderWallUniqueID { get => (WallType)BitConverter.ToUInt16(Data, 0x0A); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x0A); }
        public RoofType OrderRoofUniqueID { get => (RoofType)BitConverter.ToUInt16(Data, 0x0C); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x0C); }
        public DoorKind OrderDoorUniqueID { get => (DoorKind)BitConverter.ToUInt16(Data, 0x0E); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x0E); }

        public EncryptedInt32 Loan
        {
            get => EncryptedInt32.Read(Data, 0x10);
            set => value.Write(Data, 0x10);
        }

        public EncryptedInt32 Unknown
        {
            get => EncryptedInt32.Read(Data, 0x18);
            set => value.Write(Data, 0x18);
        }

        public short[] GetEventFlags()
        {
            var result = new short[0x100 / 2];
            Buffer.BlockCopy(Data, 0x20, result, 0, result.Length * sizeof(short));
            return result;
        }

        public void SetEventFlags(short[] value) => Buffer.BlockCopy(value, 0, Data, 0x20, value.Length * sizeof(short));

        public const int MaxRoom = 6;
        public const int RoomStart = 0x120;

        public virtual IPlayerRoom GetRoom(int roomIndex)
        {
            if ((uint)roomIndex >= MaxRoom)
                throw new ArgumentOutOfRangeException(nameof(roomIndex));

            var data = Data.Slice(RoomStart + (roomIndex * PlayerRoom1.SIZE), PlayerRoom1.SIZE);
            return new PlayerRoom1(data);
        }

        public virtual void SetRoom(int roomIndex, IPlayerRoom room)
        {
            if ((uint)roomIndex >= MaxRoom)
                throw new ArgumentOutOfRangeException(nameof(roomIndex));

            room.Write().CopyTo(Data, RoomStart + (roomIndex * PlayerRoom1.SIZE));
        }

        public sbyte NPC1 { get => (sbyte)Data[0x263D0]; set => Data[0x263D0] = (byte)value; }
        public sbyte NPC2 { get => (sbyte)Data[0x263D1]; set => Data[0x263D1] = (byte)value; }

        // 2 bytes padding

        public Item DoorDecoItemName
        {
            get => Data.Slice(0x263D4, 8).ToClass<Item>();
            set => value.ToBytesClass().CopyTo(Data, 0x263D4);
        }

        public bool PlayerHouseFlag { get => Data[0x263DC] != 0; set => Data[0x263DC] = (byte)(value ? 1 : 0); }

        public Item PostItemName
        {
            get => Data.Slice(0x263E0, 8).ToClass<Item>();
            set => value.ToBytesClass().CopyTo(Data, 0x263E0);
        }

        public Item OrderPostItemName
        {
            get => Data.Slice(0x263E8, 8).ToClass<Item>();
            set => value.ToBytesClass().CopyTo(Data, 0x263E8);
        }

        // cockroach @ 0x263f0 -- meh
        public PlayerHouse2 Upgrade()
        {
            var data = new byte[PlayerHouse2.SIZE];
            Data.Slice(0x0, 0x120).CopyTo(data, 0); // HouseLevel -> EventFlag
            for (int i = 0; i < MaxRoom; i++)
                ((PlayerRoom1)GetRoom(i)).Upgrade().Write().CopyTo(data, 0x120 + (i * PlayerRoom2.SIZE)); // RoomList
            Data.Slice(0x263D0, 0x30).CopyTo(data, 0x289F8); // PlayerList -> Cockroach
            return new PlayerHouse2(data);
        }
    }
}

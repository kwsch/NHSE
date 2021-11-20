using System;

namespace NHSE.Core
{
    public class PlayerHouse2 : PlayerHouse1
    {
        public new const int SIZE = 0x28A28;
        public override string Extension => "nhph2";

        public PlayerHouse2(byte[] data) : base(data) { }

        public new PlayerRoom2 GetRoom(int roomIndex)
        {
            if ((uint)roomIndex >= MaxRoom)
                throw new ArgumentOutOfRangeException(nameof(roomIndex));

            var data = Data.Slice(RoomStart + (roomIndex * PlayerRoom2.SIZE), PlayerRoom2.SIZE);
            return new PlayerRoom2(data);
        }

        public void SetRoom(int roomIndex, PlayerRoom2 room)
        {
            if ((uint)roomIndex >= MaxRoom)
                throw new ArgumentOutOfRangeException(nameof(roomIndex));

            room.Data.CopyTo(Data, RoomStart + (roomIndex * PlayerRoom2.SIZE));
        }

        public new sbyte NPC1 { get => (sbyte)Data[0x289F8]; set => Data[0x289F8] = (byte)value; }
        public new sbyte NPC2 { get => (sbyte)Data[0x289F9]; set => Data[0x289F9] = (byte)value; }

        // 2 bytes padding

        public new Item DoorDecoItemName
        {
            get => Data.Slice(0x289FC, 8).ToClass<Item>();
            set => value.ToBytesClass().CopyTo(Data, 0x289FC);
        }

        public new bool PlayerHouseFlag { get => Data[0x28A04] != 0; set => Data[0x28A04] = (byte)(value ? 1 : 0); }

        public new Item PostItemName
        {
            get => Data.Slice(0x28A08, 8).ToClass<Item>();
            set => value.ToBytesClass().CopyTo(Data, 0x28A08);
        }

        public new Item OrderPostItemName
        {
            get => Data.Slice(0x28A10, 8).ToClass<Item>();
            set => value.ToBytesClass().CopyTo(Data, 0x28A10);
        }

        // cockroach @ 0x28A18 -- meh

        public PlayerHouse1 Downgrade()
        {
            var data = new byte[PlayerHouse1.SIZE];
            Data.Slice(0x0, 0x120).CopyTo(data, 0); // HouseLevel -> EventFlag
            for (int i = 0; i < MaxRoom; i++)
                GetRoom(i).Downgrade().Data.CopyTo(data, 0x120 + i * PlayerRoom2.SIZE); // RoomList
            Data.Slice(0x289F8, 0x30).CopyTo(data, 0x263D0); // PlayerList -> Cockroach
            return new PlayerHouse1(data);
        }
    }
}

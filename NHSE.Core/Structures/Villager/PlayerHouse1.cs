using System;
using System.Runtime.InteropServices;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core
{
    public class PlayerHouse1 : IPlayerHouse
    {
        public const int SIZE = 0x26400;
        public virtual string Extension => "nhph";

        public readonly Memory<byte> Raw;
        public Span<byte> Data => Raw.Span;

        public PlayerHouse1(Memory<byte> data) => Raw = data;

        public byte[] Write() => Data.ToArray();

        public uint HouseLevel { get => ReadUInt32LittleEndian(Data); set => WriteUInt32LittleEndian(Data, value); }
        public WallType WallUniqueID { get => (WallType)ReadUInt16LittleEndian(Data[0x04..]); set => WriteUInt16LittleEndian(Data[0x04..], (ushort)value); }
        public RoofType RoofUniqueID { get => (RoofType)ReadUInt16LittleEndian(Data[0x06..]); set => WriteUInt16LittleEndian(Data[0x06..], (ushort)value); }
        public DoorKind DoorUniqueID { get => (DoorKind)ReadUInt16LittleEndian(Data[0x08..]); set => WriteUInt16LittleEndian(Data[0x08..], (ushort)value); }
        public WallType OrderWallUniqueID { get => (WallType)ReadUInt16LittleEndian(Data[0x0A..]); set => WriteUInt16LittleEndian(Data[0x0A..], (ushort)value); }
        public RoofType OrderRoofUniqueID { get => (RoofType)ReadUInt16LittleEndian(Data[0x0C..]); set => WriteUInt16LittleEndian(Data[0x0C..], (ushort)value); }
        public DoorKind OrderDoorUniqueID { get => (DoorKind)ReadUInt16LittleEndian(Data[0x0E..]); set => WriteUInt16LittleEndian(Data[0x0E..], (ushort)value); }

        public EncryptedInt32 Loan
        {
            get => EncryptedInt32.Read(Data[0x10..]);
            set => value.Write(Data[0x10..]);
        }

        public EncryptedInt32 Unknown
        {
            get => EncryptedInt32.Read(Data[0x18..]);
            set => value.Write(Data[0x18..]);
        }

        public Span<short> EventFlags => MemoryMarshal.Cast<byte, short>(Data.Slice(0x20, 0x100));

        public const int MaxRoom = 6;
        public const int RoomStart = 0x120;

        public virtual IPlayerRoom GetRoom(int roomIndex)
        {
            if ((uint)roomIndex >= MaxRoom)
                throw new ArgumentOutOfRangeException(nameof(roomIndex));

            var data = Data.Slice(RoomStart + (roomIndex * PlayerRoom1.SIZE), PlayerRoom1.SIZE);
            return new PlayerRoom1(data.ToArray());
        }

        public virtual void SetRoom(int roomIndex, IPlayerRoom room)
        {
            if ((uint)roomIndex >= MaxRoom)
                throw new ArgumentOutOfRangeException(nameof(roomIndex));

            var dest = Data.Slice(RoomStart + (roomIndex * PlayerRoom1.SIZE), PlayerRoom1.SIZE);
            room.Write().CopyTo(dest);
        }

        public sbyte NPC1 { get => (sbyte)Data[0x263D0]; set => Data[0x263D0] = (byte)value; }
        public sbyte NPC2 { get => (sbyte)Data[0x263D1]; set => Data[0x263D1] = (byte)value; }

        // 2 bytes padding

        public Item DoorDecoItemName
        {
            get => Data.Slice(0x263D4, 8).ToArray().ToClass<Item>();
            set => value.ToBytesClass().CopyTo(Data[0x263D4..]);
        }

        public bool PlayerHouseFlag { get => Data[0x263DC] != 0; set => Data[0x263DC] = (byte)(value ? 1 : 0); }

        public Item PostItemName
        {
            get => Data.Slice(0x263E0, 8).ToArray().ToClass<Item>();
            set => value.ToBytesClass().CopyTo(Data[0x263E0..]);
        }

        public Item OrderPostItemName
        {
            get => Data.Slice(0x263E8, 8).ToArray().ToClass<Item>();
            set => value.ToBytesClass().CopyTo(Data[0x263E8..]);
        }

        // cockroach @ 0x263f0 -- meh
        public PlayerHouse2 Upgrade()
        {
            var data = new byte[PlayerHouse2.SIZE];
            Data[..0x120].CopyTo(data.AsSpan(0)); // HouseLevel -> EventFlag
            for (int i = 0; i < MaxRoom; i++)
                ((PlayerRoom1)GetRoom(i)).Upgrade().Write().CopyTo(data.AsSpan(0x120 + (i * PlayerRoom2.SIZE))); // RoomList
            Data.Slice(0x263D0, 0x30).CopyTo(data.AsSpan(0x289F8)); // PlayerList -> Cockroach
            return new PlayerHouse2(data);
        }
    }
}

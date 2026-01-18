using System;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

public class VillagerHouse1(Memory<byte> raw) : IVillagerHouse
{
    public const int SIZE = 0x1D4;
    public const int ItemCount = 36;
    public virtual string Extension => "nhvh";

    public Span<byte> Data => raw.Span;

    public byte[] Write() => Data.ToArray();

    public uint HouseLevel { get => ReadUInt32LittleEndian(Data); set => WriteUInt32LittleEndian(Data, value); }
    public uint HouseStatus { get => ReadUInt32LittleEndian(Data[0x04..]); set => WriteUInt32LittleEndian(Data[0x04..], value); }
    public WallType WallUniqueID { get => (WallType)ReadUInt16LittleEndian(Data[0x08..]); set => WriteUInt16LittleEndian(Data[0x08..], (ushort)value); }
    public RoofType RoofUniqueID { get => (RoofType)ReadUInt16LittleEndian(Data[0x0A..]); set => WriteUInt16LittleEndian(Data[0x0A..], (ushort)value); }
    public DoorKind DoorUniqueID { get => (DoorKind)ReadUInt16LittleEndian(Data[0x0C..]); set => WriteUInt16LittleEndian(Data[0x0C..], (ushort)value); }
    public WallType OrderWallUniqueID { get => (WallType)ReadUInt16LittleEndian(Data[0x0E..]); set => WriteUInt16LittleEndian(Data[0x0E..], (ushort)value); }
    public RoofType OrderRoofUniqueID { get => (RoofType)ReadUInt16LittleEndian(Data[0x10..]); set => WriteUInt16LittleEndian(Data[0x10..], (ushort)value); }
    public DoorKind OrderDoorUniqueID { get => (DoorKind)ReadUInt16LittleEndian(Data[0x12..]); set => WriteUInt16LittleEndian(Data[0x12..], (ushort)value); }

    public Item DoorDecoItemName
    {
        get => Data.Slice(0x1C8, 8).ToArray().ToClass<Item>();
        set => value.ToBytesClass().CopyTo(Data[0x1C8..]);
    }

    public sbyte NPC1 { get => (sbyte)Data[0x1C4]; set => Data[0x1C4] = (byte)value; }
    public sbyte NPC2 { get => (sbyte)Data[0x1C5]; set => Data[0x1C5] = (byte)value; }

    public sbyte BuildPlayer { get => (sbyte)Data[0x1D0]; set => Data[0x1D0] = (byte)value; }

    public VillagerHouse2 Upgrade()
    {
        var data = new byte[VillagerHouse2.SIZE];
        var empty = Item.NONE.ToBytes();
        Data.CopyTo(data);
        for (int i = 0; i < 236; i++)
            empty.CopyTo(data, 0x1D8 + (i * 0xC));
        VillagerHouse2.Footer.CopyTo(data.AsSpan(0x1270));
        return new VillagerHouse2(data);
    }
}
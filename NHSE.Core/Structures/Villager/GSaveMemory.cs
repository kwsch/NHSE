using System;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

public class GSaveMemory : IVillagerOrigin
{
    public const int SIZE = 0x5F0;

    public readonly Memory<byte> Raw;
    public Span<byte> Data => Raw.Span;

    public GSaveMemory(Memory<byte> data) => Raw = data;

    public GSavePlayerId PlayerId
    {
        get => Data[..GSavePlayerId.SIZE].ToStructure<GSavePlayerId>();
        set => value.ToBytes().CopyTo(Data);
    }

    public uint TownID
    {
        get => ReadUInt32LittleEndian(Data);
        set => WriteUInt32LittleEndian(Data, value);
    }

    public string TownName
    {
        get => StringUtil.GetString(Data, 0x04, 10);
        set => StringUtil.GetBytes(value, 10).CopyTo(Data[0x04..]);
    }
    public Span<byte> GetTownIdentity() => Data[..(4 + 20)];

    public uint PlayerID
    {
        get => ReadUInt32LittleEndian(Data[0x1C..]);
        set => WriteUInt32LittleEndian(Data[0x1C..], value);
    }

    public string PlayerName
    {
        get => StringUtil.GetString(Data, 0x20, 10);
        set => StringUtil.GetBytes(value, 10).CopyTo(Data[0x20..]);
    }

    public Span<byte> GetPlayerIdentity() => Data.Slice(0x1C, 4 + 20);

    public byte[] GetEventFlags() => Data.Slice(0x38, 0x100).ToArray();
    public void SetEventFlags(byte[] value) => value.CopyTo(Data[0x38..]);

    public byte Friendship { get => Data[0x38 + 10]; set => Data[0x38 + 10] = value; }

    public string NickName
    {
        get => StringUtil.GetString(Data, 0x138, 10);
        set => StringUtil.GetBytes(value, 10).CopyTo(Data[0x138..]);
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
        StringUtil.GetBytes(value, 47).CopyTo(Data[offset..]);
    }

    public GSaveDate GreetingSetDate { get => Data.Slice(0x56C, GSaveDate.SIZE).ToStructure<GSaveDate>(); set => value.ToBytes().CopyTo(Data[0x56C..]); }
};
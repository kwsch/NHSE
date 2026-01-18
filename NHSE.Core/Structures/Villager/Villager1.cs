using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// Villager object format from 1.0 to update 1.4
/// </summary>
public sealed class Villager1(Memory<byte> raw) : IVillager
{
    public const int SIZE = 0x12AB0;
    public string Extension => "nhv";

    public Span<byte> Data => raw.Span;
    public byte[] Write() => Data.ToArray();

    public byte Species { get => Data[0]; set => Data[0] = value; }
    public byte Variant { get => Data[1]; set => Data[1] = value; }
    public VillagerPersonality Personality {  get => (VillagerPersonality)Data[2];  set => Data[2] = (byte)value; }

    public string TownName => GetMemory(0).TownName;
    public Span<byte> GetTownIdentity() => GetMemory(0).GetTownIdentity();
    public string PlayerName => GetMemory(0).PlayerName;
    public Span<byte> GetPlayerIdentity() => GetMemory(0).GetPlayerIdentity();

    public const int PlayerMemoryCount = 8;

    public GSaveMemory GetMemory(int index)
    {
        if ((uint) index >= PlayerMemoryCount)
            throw new ArgumentOutOfRangeException(nameof(index));

        var bytes = raw.Slice(0x4 + (index * GSaveMemory.SIZE), GSaveMemory.SIZE);
        return new GSaveMemory(bytes);
    }

    public GSaveMemory[] GetMemories()
    {
        var memories = new GSaveMemory[PlayerMemoryCount];
        for (int i = 0; i < memories.Length; i++)
            memories[i] = GetMemory(i);
        return memories;
    }

    public void SetMemory(GSaveMemory memory, int index)
    {
        if ((uint)index >= PlayerMemoryCount)
            throw new ArgumentOutOfRangeException(nameof(index));

        memory.Data.CopyTo(Data[(0x4 + (index * GSaveMemory.SIZE))..]);
    }

    public void SetMemories(IReadOnlyList<GSaveMemory> memories)
    {
        for (int i = 0; i < memories.Count; i++)
            SetMemory(memories[i], i);
    }

    public string CatchPhrase
    {
        get => StringUtil.GetString(Data, 0xFFE8 + 0x2C, 2 * 12);
        set => StringUtil.GetBytes(value, 2 * 12).CopyTo(Data[(0xFFE8 + 0x2C)..]);
    }

    private const int WearCount = 24;

    public IReadOnlyList<VillagerItem> WearStockList
    {
        get => VillagerItem.GetArray(Data.Slice(0x101CC, WearCount * VillagerItem.SIZE));
        set => VillagerItem.SetArray(value).CopyTo(Data[0x101CC..]);
    }

    private const int FurnitureCount = 32;

    public IReadOnlyList<VillagerItem> FtrStockList
    {
        get => VillagerItem.GetArray(Data.Slice(0x105EC, FurnitureCount * VillagerItem.SIZE));
        set => VillagerItem.SetArray(value).CopyTo(Data[0x105EC..]);
    }

    // State Flags
    public byte BirthType { get => Data[0x11EF8]; set => Data[0x11EF8] = value; }
    public byte InducementType { get => Data[0x11EF9]; set => Data[0x11EF9] = value; }
    public byte MoveType { get => Data[0x11EFA]; set => Data[0x11EFA] = value; }
    public bool MovingOut { get => (MoveType & 2) == 2; set => MoveType = (byte)((MoveType & ~2) | (value ? 2 : 0)); }

    // EventFlagsNPCSaveParam
    private const int EventFlagsSaveCount = 0x100; // Future-proof allocation! Release version used <20% of the amount allocated.

    public ushort[] GetEventFlagsSave()
    {
        var value = new ushort[EventFlagsSaveCount];
        MemoryMarshal.Cast<byte, ushort>(Data.Slice(0x11EFC, EventFlagsSaveCount * sizeof(ushort))).CopyTo(value);
        return value;
    }

    public void SetEventFlagsSave(ReadOnlySpan<ushort> value)
    {
        MemoryMarshal.Cast<ushort, byte>(value).CopyTo(Data[0x11EFC..]);
    }

    public override string ToString() => InternalName;
    public string InternalName => VillagerUtil.GetInternalVillagerName((VillagerSpecies) Species, Variant);
    public int Gender => ((int)Personality / 4) & 1; // 0 = M, 1 = F

    public GSaveRoomFloorWall Room
    {
        get => Data.Slice(0x12100, GSaveRoomFloorWall.SIZE).ToStructure<GSaveRoomFloorWall>();
        set => value.ToBytes().CopyTo(Data[0x12100..]);
    }

    public DesignPatternPRO Design
    {
        get => new(raw.Slice(0x12128, DesignPatternPRO.SIZE));
        set => value.Data.CopyTo(Data[0x12128..]);
    }

    public byte DIYEndHour { get => Data[0x129D1]; set => Data[0x129D1] = value; }
    public byte DIYEndMinute { get => Data[0x129D2]; set => Data[0x129D2] = value; }
    public byte DIYEndSecond { get => Data[0x129D3]; set => Data[0x129D3] = value; }

    public ushort DIYRecipeIndex
    {
        get => ReadUInt16LittleEndian(Data[0x129D4..]);
        set => WriteUInt16LittleEndian(Data[0x129D4..], value);
    }

    public void SetFriendshipAll(byte value = byte.MaxValue)
    {
        for (int i = 0; i < PlayerMemoryCount; i++)
        {
            var m = GetMemory(i);
            if (string.IsNullOrEmpty(m.PlayerName))
                continue;
            m.Friendship = value;
            SetMemory(m, i);
        }
    }
}
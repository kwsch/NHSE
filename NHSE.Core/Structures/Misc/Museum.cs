using System;
using System.Collections.Generic;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

public class Museum
{
    public const int SIZE = 0x3404;
    public const int EntryCount = 1024;

    public readonly Memory<byte> Raw;
    public Span<byte> Data => Raw.Span;

    public Museum(Memory<byte> data) => Raw = data;

    public int MuseumLevel
    {
        get => ReadInt32LittleEndian(Data);
        set => WriteInt32LittleEndian(Data, value);
    }

    public GSaveDate[] GetDates() => Data.Slice(0x0004, 0x1000).GetArrayStructure<GSaveDate>(GSaveDate.SIZE);
    public void SetDates(ReadOnlySpan<GSaveDate> value) => value.SetArrayStructure(GSaveDate.SIZE).CopyTo(Data[4..]);

    public Item[] GetItems() => Data.Slice(0x1004, 0x2000).GetArray<Item>(Item.SIZE);
    public void SetItems(IReadOnlyList<Item> value) => Item.SetArray(value).CopyTo(Data[0x1004..]);

    public byte[] GetPlayers() => Data.Slice(0x3004, 0x400).ToArray();
    public void SetPlayers(ReadOnlySpan<byte> value) => value.CopyTo(Data[0x3004..]);
}
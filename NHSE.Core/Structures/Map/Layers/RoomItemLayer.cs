using System;
using System.Collections.Generic;

namespace NHSE.Core;

public sealed record RoomItemLayer : ItemLayer
{
    public const int SIZE = Width * Height * Item.SIZE;
    private const byte Width = 20;
    private const byte Height = 20;

    public RoomItemLayer(ReadOnlySpan<byte> data) : this(Item.GetArray(data)) { }
    public RoomItemLayer(Item[] tiles) : base(tiles, Width, Height) { }

    public static RoomItemLayer[] GetArray(ReadOnlySpan<byte> data)
    {
        var result = new RoomItemLayer[data.Length / SIZE];
        for (int i = 0; i < result.Length; i++)
        {
            var slice = data.Slice(i * SIZE, SIZE);
            result[i] = new RoomItemLayer(slice);
        }
        return result;
    }

    public static byte[] SetArray(IReadOnlyList<RoomItemLayer> data)
    {
        var result = new byte[data.Count * SIZE];
        for (int i = 0; i < data.Count; i++)
            data[i].DumpAll().CopyTo(result, i * SIZE);
        return result;
    }
}
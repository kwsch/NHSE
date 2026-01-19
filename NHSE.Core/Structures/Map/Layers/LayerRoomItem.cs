using System;
using System.Collections.Generic;

namespace NHSE.Core;

public sealed record LayerRoomItem : LayerItem
{
    public const int SIZE = Width * Height * Item.SIZE;
    private const byte Width = 20;
    private const byte Height = 20;

    public LayerRoomItem(ReadOnlySpan<byte> data) : this(Item.GetArray(data)) { }
    public LayerRoomItem(Item[] tiles) : base(tiles, Width, Height) { }

    public static LayerRoomItem[] GetArray(ReadOnlySpan<byte> data)
    {
        var result = new LayerRoomItem[data.Length / SIZE];
        for (int i = 0; i < result.Length; i++)
        {
            var slice = data.Slice(i * SIZE, SIZE);
            result[i] = new LayerRoomItem(slice);
        }
        return result;
    }

    public static byte[] SetArray(IReadOnlyList<LayerRoomItem> data)
    {
        var result = new byte[data.Count * SIZE];
        for (int i = 0; i < data.Count; i++)
            data[i].DumpAll().CopyTo(result, i * SIZE);
        return result;
    }
}
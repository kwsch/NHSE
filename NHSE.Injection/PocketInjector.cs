using System.Collections.Generic;
using System.Linq;
using NHSE.Core;

namespace NHSE.Injection;

public sealed class PocketInjector(IReadOnlyList<Item> items, IRAMReadWriter bot) : IDataInjector
{
    public bool Connected => bot.Connected;

    private byte[]? LastData { get; set; }
    public uint WriteOffset { private get; set; }
    public bool ValidateEnabled { get; set; } = true;
    public bool SpoofInventoryWrite { get; set; }

    private static readonly Item DroppableOnlyItem = new(0x9C9); // Gold nugget

    public bool ReadValidate(out byte[] data)
    {
        PlayerItemSet.GetOffsetLength(WriteOffset, out var offset, out var size);
        data = bot.ReadBytes(offset, size);
        return Validate(data);
    }

    public InjectionResult Read()
    {
        if (!ReadValidate(out var data))
            return InjectionResult.FailValidate;

        if (LastData?.SequenceEqual(data) == true)
            return InjectionResult.Same;

        PlayerItemSet.ReadPlayerInventory(data, items);

        LastData = data;

        return InjectionResult.Success;
    }

    public InjectionResult Write()
    {
        if (!ReadValidate(out var data))
            return InjectionResult.FailValidate;

        var orig = (byte[])data.Clone();

        var items1 = !SpoofInventoryWrite ? items : Enumerable.Repeat(DroppableOnlyItem, items.Count).ToArray();

        PlayerItemSet.WritePlayerInventory(data, items1);

        if (data.SequenceEqual(orig))
            return InjectionResult.Same;

        PlayerItemSet.GetOffsetLength(WriteOffset, out var offset, out var size);
        if (size != data.Length)
            return InjectionResult.FailBadSize;

        bot.WriteBytes(data, offset);

        LastData = data;

        return InjectionResult.Success;
    }

    public bool Validate() => ReadValidate(out _);

    public bool Validate(System.ReadOnlySpan<byte> data)
    {
        if (!ValidateEnabled)
            return true;

        return PlayerItemSet.ValidateItemBinary(data);
    }
}
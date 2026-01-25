using System;
using System.Collections.Generic;

namespace NHSE.Core;

public sealed record ItemArrayEditor<T>(IReadOnlyList<T> Items)
    where T : Item, ICopyableItem<T>
{
    public int ItemSize => Items[0].Size;
    public int TotalSize => Items.Count * ItemSize;

    public byte[] Write() => Items.SetArray(ItemSize);

    public void ImportItemDataX(ReadOnlySpan<byte> data, bool skipOccupiedSlots, int start = 0)
    {
        int expect = ItemSize;
        var import = data.GetArray<T>(expect);
        ImportItems(import, start, skipOccupiedSlots);
    }

    private void ImportItems(IReadOnlyList<T> import, int start, bool skipOccupiedSlots)
    {
        if (skipOccupiedSlots)
            ImportItemsSkip(import, start);
        else
            ImportItemsOverwrite(import, start);
    }

    private void ImportItemsOverwrite(IReadOnlyList<T> import, int destIndex, int importIndex = 0)
    {
        while (importIndex < import.Count && destIndex < Items.Count)
        {
            Items[destIndex].CopyFrom(import[importIndex]);
            destIndex++; importIndex++;
        }
    }

    private void ImportItemsSkip(IReadOnlyList<T> import, int destIndex, int importIndex = 0)
    {
        while (importIndex < import.Count && destIndex < Items.Count)
        {
            var importItem = import[importIndex];
            if (importItem.ItemId == Item.NONE)
            {
                importIndex++;
                continue;
            }

            var destItem = Items[destIndex];
            if (destItem.ItemId != Item.NONE)
            {
                destIndex++;
                continue;
            }

            destItem.CopyFrom(importItem);
            importIndex++;
            destIndex++;
        }
    }
}
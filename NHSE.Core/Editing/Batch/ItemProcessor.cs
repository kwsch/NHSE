using System;
using System.Collections.Generic;
using System.Linq;

namespace NHSE.Core;

public sealed class ItemProcessor(BatchMutator<Item> mut) : BatchProcessor<Item>(mut)
{
    protected override bool CanModify(Item item) => true;
    protected override bool Finalize(Item item) => true;

    /// <summary>
    /// Initializes the <see cref="StringInstruction"/> list with a context-sensitive value. If the provided value is a string, it will attempt to convert that string to its corresponding index.
    /// </summary>
    /// <param name="il">Instructions to initialize.</param>
    public static void ScreenStrings(IEnumerable<StringInstruction> il)
    {
        foreach (var i in il.Where(i => !i.PropertyValue.All(char.IsDigit)))
        {
            string pv = i.PropertyValue;
            if (pv.StartsWith('$') && pv.Contains(','))
                i.SetRandomRange(pv);

            SetInstructionScreenedValue(i);
        }
    }

    /// <summary>
    /// Initializes the <see cref="StringInstruction"/> with a context-sensitive value. If the provided value is a string, it will attempt to convert that string to its corresponding index.
    /// </summary>
    /// <param name="i">Instruction to initialize.</param>
    private static void SetInstructionScreenedValue(StringInstruction i)
    {
        switch (i.PropertyName)
        {
            case nameof(Item.ItemId) or nameof(Item.ExtensionItemId): i.SetScreenedValue(GameInfo.Strings.itemlistdisplay); return;
        }
    }

    protected override void Initialize(ReadOnlySpan<StringInstructionSet> sets)
    {
        foreach (var set in sets)
        {
            ScreenStrings(set.Filters);
            ScreenStrings(set.Instructions);
        }
    }
}
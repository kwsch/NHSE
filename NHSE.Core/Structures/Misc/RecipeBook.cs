using System;
using System.Collections.Generic;

namespace NHSE.Core;

public class RecipeBook
{
    private const int BitFlagArraySize = 0x100;
    private const int BitFlagArrayCount = 4;
    public const int SIZE = BitFlagArraySize * BitFlagArrayCount;
    public const ushort RecipeCount = BitFlagArraySize * 8;

    private readonly Memory<byte> Raw;
    private Span<byte> Data => Raw.Span;
    public RecipeBook(Memory<byte> raw) => Raw = raw;

    public void Save(Span<byte> data) => Data.CopyTo(data);

    public bool GetIsKnown(int recipe) => FlagUtil.GetFlag(Data, 0 * BitFlagArraySize, recipe);
    public void SetIsKnown(int recipe, bool value = true) => FlagUtil.SetFlag(Data, 0 * BitFlagArraySize, recipe, value);

    public bool GetIsMade(int recipe) => FlagUtil.GetFlag(Data, 1 * BitFlagArraySize, recipe);
    public void SetIsMade(int recipe, bool value = true) => FlagUtil.SetFlag(Data, 1 * BitFlagArraySize, recipe, value);

    public bool GetIsNew(int recipe) => FlagUtil.GetFlag(Data, 2 * BitFlagArraySize, recipe);
    public void SetIsNew(int recipe, bool value = true) => FlagUtil.SetFlag(Data, 2 * BitFlagArraySize, recipe, value);

    public bool GetIsFavorite(int recipe) => FlagUtil.GetFlag(Data, 3 * BitFlagArraySize, recipe);
    public void SetIsFavorite(int recipe, bool value = true) => FlagUtil.SetFlag(Data, 3 * BitFlagArraySize, recipe, value);

    public void GiveAll(IReadOnlyDictionary<ushort,ushort> recipes, bool isNew = true)
    {
        foreach (var entry in recipes)
        {
            var index = entry.Key;
            if (index is RecipeList.BridgeConstructionKit or RecipeList.CampsiteConstructionKit)
                continue;

            bool alreadyHave = GetIsKnown(index);
            if (alreadyHave)
                continue;

            SetIsKnown(index);
            SetIsNew(index, isNew);
        }
    }

    public void ClearAll()
    {
        for (int i = 0; i < RecipeCount; i++)
        {
            SetIsKnown(i, false);
            SetIsNew(i, false);
            SetIsMade(i, false);
            SetIsFavorite(i, false);
        }
    }

    public void CraftAll()
    {
        for (int i = 0; i < RecipeCount; i++)
        {
            bool alreadyHave = GetIsKnown(i);
            if (!alreadyHave)
                continue;
            SetIsMade(i);
            SetIsNew(i, false);
        }
    }
}
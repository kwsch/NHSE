using System;
using System.Diagnostics;

namespace NHSE.Core;

/// <summary>
/// Logic for managing field item flags within a layer.
/// </summary>
public sealed class LayerFieldItemFlag(Memory<byte> raw, int width, int height) : ILayerFieldItemFlag
{
    public Span<byte> Data => raw.Span;

    public bool GetIsActive(int relX, int relY)
        => FlagUtil.GetFlag(Data, GetLayerFlagIndex(relX, relY));
    public void SetIsActive(int relX, int relY, bool value)
        => FlagUtil.SetFlag(Data, GetLayerFlagIndex(relX, relY), value);

    public bool this[int relX, int relY]
    {
        get => GetIsActive(relX, relY);
        set => SetIsActive(relX, relY, value);
    }

    /// <summary>
    /// Although the Field Item Tiles are arranged y-column (y-x) based, the 'IsActive' flags are arranged x-row (x-y) based.
    /// </summary>
    private int GetLayerFlagIndex(int x, int y) => (y * width) + x;

    public void DeactivateAll() => Data.Clear();

    public void Save(Span<byte> dest) => Data.CopyTo(dest);

    public void Import(Span<byte> src) => src.CopyTo(Data);

    /// <summary>
    /// Diagnostic check of the active flags against the tiles.
    /// </summary>
    /// <param name="tiles">Tiles to check against.</param>
    public void DebugCheckTileActiveFlags(LayerItem tiles)
    {
        // this doesn't set anything; just diagnostic

        // Although the Tiles are arranged y-column (y-x) based, the 'isActive' flags are arranged x-row (x-y) based.
        // We can turn the isActive flag off if the item is not a root or the item cannot be animated.
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var tile = tiles.GetTile(x, y);
                var isActive = GetIsActive(x, y);
                if (!isActive)
                    continue;

                bool empty = tile.IsNone;
                if (empty)
                    Debug.WriteLine($"Flag at ({x},{y}) is not a root object.");
            }
        }
    }
}
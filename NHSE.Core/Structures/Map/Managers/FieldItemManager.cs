using System.Collections.Generic;
using System.Diagnostics;

namespace NHSE.Core;

/// <summary>
/// Manages the <see cref="Item"/> data for the player's outside overworld.
/// </summary>
public sealed class FieldItemManager
{
    /// <summary>
    /// Base layer of items
    /// </summary>
    public readonly FieldItemLayer Layer1;

    /// <summary>
    /// Layer of items that are supported by <see cref="Layer1"/>
    /// </summary>
    public readonly FieldItemLayer Layer2;

    /// <summary>
    /// Reference to the save file that will be updated when <see cref="Save"/> is called.
    /// </summary>
    public readonly MainSave SAV;

    public readonly int FieldAcreWidth;
    public readonly int FieldAcreHeight;
    public readonly int FieldItemWidth;
    public readonly int FieldItemHeight;

    public FieldItemManager(MainSave sav)
    {
        var (aWidth, aHeight) = (sav.FieldItemAcreWidth, sav.FieldItemAcreHeight);
        Layer1 = new FieldItemLayer(sav.GetFieldItemLayer1(), aWidth, aHeight);
        Layer2 = new FieldItemLayer(sav.GetFieldItemLayer2(), aWidth, aHeight);
        SAV = sav;

        FieldAcreWidth = aWidth;
        FieldAcreHeight = aHeight;
        FieldItemWidth = Layer1.TileInfo.TotalWidth;
        FieldItemHeight = Layer1.TileInfo.TotalHeight;
    }

    /// <summary>
    /// Stores all values for the <see cref="FieldItemManager"/> back to the <see cref="SAV"/>.
    /// </summary>
    public void Save()
    {
        SAV.SetFieldItemLayer1(Layer1.Tiles);
        SAV.SetFieldItemLayer2(Layer2.Tiles);

        SetTileActiveFlags(Layer1, SAV.FieldItemFlag1);
        SetTileActiveFlags(Layer2, SAV.FieldItemFlag2);
    }

    /// <summary>
    /// Lists out all coordinates of tiles present in <see cref="Layer2"/> that don't have anything underneath in <see cref="Layer1"/> to support them.
    /// </summary>
    public List<string> GetUnsupportedTiles(int totalWidth, int totalHeight)
    {
        var result = new List<string>();
        for (int x = 0; x < totalWidth; x++)
        {
            for (int y = 0; y < totalHeight; y++)
            {
                var tile = Layer2.GetTile(x, y);
                if (tile.IsNone)
                    continue;

                var support = Layer1.GetTile(x, y);
                if (!support.IsNone)
                    continue; // dunno how to check if the tile can actually have an item put on top of it...

                result.Add($"{x:000},{y:000}");
            }
        }
        return result;
    }

    private void SetTileActiveFlags(ItemLayer tiles, int ofs)
    {
        // this doesn't set anything; just diagnostic

        // Although the Tiles are arranged y-column (y-x) based, the 'isActive' flags are arranged x-row (x-y) based.
        // We can turn the isActive flag off if the item is not a root or the item cannot be animated.
        for (int x = 0; x < FieldItemWidth; x++)
        {
            for (int y = 0; y < FieldItemHeight; y++)
            {
                var tile = tiles.GetTile(x, y);
                var isActive = GetIsActive(ofs, x, y);
                if (!isActive)
                    continue;

                bool empty = tile.IsNone;
                if (empty)
                    Debug.WriteLine($"Flag at ({x},{y}) is not a root object.");
            }
        }
    }

    public bool GetIsActive(bool baseLayer, int x, int y)             => GetIsActive(baseLayer ? SAV.FieldItemFlag1 : SAV.FieldItemFlag2, x, y);
    public void SetIsActive(bool baseLayer, int x, int y, bool value) => SetIsActive(baseLayer ? SAV.FieldItemFlag1 : SAV.FieldItemFlag2, x, y, value);

    private bool GetIsActive(int ofs, int x, int y)             => FlagUtil.GetFlag(SAV.Data, ofs, (y * FieldItemWidth) + x);
    private void SetIsActive(int ofs, int x, int y, bool value) => FlagUtil.SetFlag(SAV.Data, ofs, (y * FieldItemWidth) + x, value);

    public bool IsOccupied(int x, int y) => !Layer1.GetTile(x, y).IsNone || !Layer2.GetTile(x, y).IsNone;
}
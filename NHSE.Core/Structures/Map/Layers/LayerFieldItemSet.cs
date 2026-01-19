using System.Collections.Generic;

namespace NHSE.Core;

/// <summary>
/// Manages the <see cref="Item"/> data for the player's outside overworld.
/// </summary>
public sealed class LayerFieldItemSet : ILayerFieldItemSet
{
    /// <summary>
    /// Base layer of items
    /// </summary>
    public required LayerFieldItem Layer0 { get; init; }

    /// <summary>
    /// Layer of items that are supported by <see cref="Layer0"/>
    /// </summary>
    public required LayerFieldItem Layer1 { get; init; }

    /// <summary>
    /// Lists out all coordinates of tiles present in <see cref="Layer1"/> that don't have anything underneath in <see cref="Layer0"/> to support them.
    /// </summary>
    public List<string> GetUnsupportedTiles(int totalWidth, int totalHeight)
    {
        var result = new List<string>();
        for (int x = 0; x < totalWidth; x++)
        {
            for (int y = 0; y < totalHeight; y++)
            {
                // If there is an item on this layer...
                var tile = Layer1.GetTile(x, y);
                if (tile.IsNone)
                    continue;

                // Then there must be something underneath it.
                var support = Layer0.GetTile(x, y);
                if (!support.IsNone)
                    continue; // dunno how to check if the tile can actually have an item put on top of it...

                result.Add($"{x:000},{y:000}");
            }
        }
        return result;
    }

    public bool IsOccupied(int relX, int relY) => !Layer0.GetTile(relX, relY).IsNone || !Layer1.GetTile(relX, relY).IsNone;

    public Item GetItem(int relX, int relY, bool baseLayer)
    {
        var layer = baseLayer ? Layer0 : Layer1;
        return layer.GetTile(relX, relY);
    }

    public void SetItem(int relX, int relY, bool baseLayer, Item value)
    {
        var layer = baseLayer ? Layer0 : Layer1;
        layer[relX, relY] = value;
    }
}
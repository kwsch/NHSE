using System.Collections.Generic;

namespace NHSE.Core;

public interface ILayerFieldItemSet
{
    LayerFieldItem Layer0 { get; }
    LayerFieldItem Layer1 { get; }

    bool IsOccupied(int relX, int relY);

    Item GetItem(int relX, int relY, bool baseLayer);
    void SetItem(int relX, int relY, bool baseLayer, Item value);

    Item this[int relX, int relY, bool baseLayer]
    {
        get => GetItem(relX, relY, baseLayer);
        set => SetItem(relX, relY, baseLayer, value);
    }

    /// <summary>
    /// Lists out all coordinates of tiles present in <see cref="Layer1"/> that don't have anything underneath in <see cref="Layer0"/> to support them.
    /// </summary>
    List<string> GetUnsupportedTiles(int totalWidth, int totalHeight);

    List<string> GetUnsupportedTiles() => GetUnsupportedTiles(Layer0.TileInfo.TotalWidth, Layer0.TileInfo.TotalHeight);
}
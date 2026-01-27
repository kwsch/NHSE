using System;

namespace NHSE.Core;

public sealed record MapMutator
{
    public MapViewState View { get; init; } = new();
    public required MapTileManager Manager { get; init; }

    // Mutability State Tracking
    public uint ItemLayerIndex { get; set => field = value & 1; }

    public LayerFieldItem CurrentLayer => ItemLayerIndex == 0 ? Manager.FieldItems.Layer0 : Manager.FieldItems.Layer1;
    public ILayerFieldItemFlag CurrentLayerFlags => ItemLayerIndex == 0 ? Manager.LayerItemFlag0 : Manager.LayerItemFlag1;

    /// <inheritdoc cref="ModifyFieldItems(Func{int,int,int,int,int},in bool,LayerFieldItem)"/>
    public int ModifyFieldItems(Func<int, int, int, int, int> action, in bool wholeMap)
        => ModifyFieldItems(action, wholeMap, CurrentLayer);

    /// <inheritdoc cref="ReplaceFieldItems(Item,Item,bool,LayerFieldItem)"/>
    public int ReplaceFieldItems(Item oldItem, Item newItem, in bool wholeMap)
        => ReplaceFieldItems(oldItem, newItem, wholeMap, CurrentLayer);

    /// <summary>
    /// Modifies field items in the specified <paramref name="layerField"/> using the provided <paramref name="action"/> function.
    /// </summary>
    /// <param name="action">Range selector (xmin, ymin, width, height) to use.</param>
    /// <param name="wholeMap">If true, the modification is applied across the entire map; otherwise, only within the current view.</param>
    /// <param name="layerField">The layer field item to perform the modification on.</param>
    /// <returns>The number of items modified.</returns>
    public int ModifyFieldItems(Func<int, int, int, int, int> action, in bool wholeMap, LayerFieldItem layerField)
    {
        int xMin, yMin, width, height;
        if (wholeMap)
        {
            (xMin, yMin) = (0, 0);
            var info = layerField.TileInfo;
            (width, height) = info.DimTotal;
        }
        else
        {
            // Convert absolute to relative coordinates
            (xMin, yMin) = Manager.ConfigItems.GetCoordinatesRelative(View.X, View.Y);
            if (!Manager.ConfigItems.IsCoordinateValidRelative(xMin, yMin))
                return 0;

            var info = layerField.TileInfo;
            (width, height) = info.DimAcre;
        }
        return action(xMin, yMin, width, height);
    }

    /// <summary>
    /// Replaces all instances of <paramref name="oldItem"/> with <paramref name="newItem"/> in the specified <paramref name="layerField"/>.
    /// </summary>
    /// <param name="oldItem">Item to be replaced.</param>
    /// <param name="newItem">Item to replace with.</param>
    /// <param name="wholeMap">If true, the replacement is done across the entire map; otherwise, only within the current view.</param>
    /// <param name="layerField">The layer field item to perform the replacement on.</param>
    /// <returns>The number of items replaced.</returns>
    private int ReplaceFieldItems(Item oldItem, Item newItem, bool wholeMap, LayerFieldItem layerField)
    {
        int xMin, yMin, width, height;
        if (wholeMap)
        {
            (xMin, yMin) = (0, 0);
            var info = layerField.TileInfo;
            (width, height) = info.DimTotal;
        }
        else
        {
            // Convert absolute to relative coordinates
            (xMin, yMin) = Manager.ConfigItems.GetCoordinatesRelative(View.X, View.Y);
            if (!Manager.ConfigItems.IsCoordinateValidRelative(xMin, yMin))
                return 0;

            var info = layerField.TileInfo;
            (width, height) = info.DimAcre;
        }

        return layerField.ReplaceAll(oldItem, newItem, xMin, yMin, width, height);
    }

    /// <summary>
    /// Creates a <see cref="MapMutator"/> from the provided <see cref="MainSave"/> file.
    /// </summary>
    /// <param name="sav">The save file containing the data used to initialize the MapMutator. Cannot be null.</param>
    /// <returns>A MapMutator instance populated with data from the provided save file.</returns>
    public static MapMutator FromSaveFile(MainSave sav)
        => new() { Manager = MapTileManagerUtil.FromSaveFile(sav) };

    /// <summary>
    /// Creates a separate view-mutator with shared map objects.
    /// </summary>
    public MapMutator CreateCopy() => this with
    {
        View = View with { },
    };
}
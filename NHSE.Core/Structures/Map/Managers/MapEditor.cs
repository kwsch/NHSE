namespace NHSE.Core;

public sealed class MapEditor
{
    /// <summary>
    /// Master interactor for mutating the map.
    /// </summary>
    public required MapMutator Mutator { get; init; }

    /// <summary>
    /// Amount of pixel upscaling compared to a 1px = 1 tile map.
    /// </summary>
    public int MapScale { get; set; } = 1;

    /// <summary>
    /// Amount of pixel upscaling compared to a 1px = 1 tile map.
    /// </summary>
    public int ViewScale { get; set; } = 16;

    /// <summary>
    /// Converts an upscaled coordinate to a tile coordinate.
    /// </summary>
    /// <param name="mX">X coordinate (mouse on upscaled image).</param>
    /// <param name="mY">Y coordinate (mouse on upscaled image).</param>
    /// <param name="x">Absolute tile X coordinate.</param>
    /// <param name="y">Absolute tile Y coordinate.</param>
    public void GetCursorCoordinates(in int mX, in int mY, out int x, out int y)
    {
        x = mX / MapScale;
        y = mY / MapScale;
    }

    /// <summary>
    /// Creates a new instance of the MapEditor class initialized from the specified save file.
    /// </summary>
    /// <param name="sav">The save file containing the data used to initialize the MapEditor. Cannot be null.</param>
    /// <returns>A MapEditor instance populated with data from the provided save file.</returns>
    public static MapEditor FromSaveFile(MainSave sav)
        => new() { Mutator = MapMutator.FromSaveFile(sav) };


    public int X => Mutator.View.X;
    public int Y => Mutator.View.Y;
    public LayerTerrain Terrain => Mutator.Manager.LayerTerrain;
    public ILayerBuilding Buildings => Mutator.Manager.LayerBuildings;
    public ILayerFieldItemSet Items => Mutator.Manager.FieldItems;

    /// <summary>
    /// Converts building map coordinates to view pixel coordinates.
    /// </summary>
    /// <param name="relX">Building map X coordinate.</param>
    /// <param name="relY">Building map Y coordinate.</param>
    /// <returns>View coordinates.</returns>
    public (int X, int Y) GetViewCoordinatesBuilding(uint relX, uint relY)
        => GetViewCoordinates((int)relX, (int)relY, Mutator.Manager.ConfigBuildings);

    public (int X, int Y) GetViewCoordinatesTerrain(int relX, int relY)
        => GetViewCoordinates(relX, relY, Mutator.Manager.ConfigTerrain);

    public (int X, int Y) GetViewCoordinatesFieldItem(int relX, int relY)
        => GetViewCoordinates(relX, relY, Mutator.Manager.ConfigItems);

    public (int X, int Y) GetViewCoordinates(int posX, int posY, LayerPositionConfig shifter)
    {
        // Get absolute coordinates from the layer.
        var (x, y) = shifter.GetCoordinatesAbsolute(posX, posY);

        // Shift to view coordinates
        x -= X;
        y -= Y;
        // Scale to pixel coordinates
        x *= ViewScale;
        y *= ViewScale;
        return (x, y);
    }

    /// <summary>
    /// From a map pixel coordinate (<see cref="MapScale"/>), get the clamped map tile coordinate.
    /// </summary>
    /// <param name="x">Upscaled Map pixel X coordinate.</param>
    /// <param name="y">Upscaled Map pixel Y coordinate.</param>
    /// <param name="type">Option to adjust the coordinates to a desired type.</param>
    /// <returns></returns>
    public (int X, int Y) GetMapCoordinates(int x, int y, MapViewCoordinateRequest type)
    {
        x /= MapScale;
        y /= MapScale;

        if (x < 0) x = 0;
        if (y < 0) y = 0;

        // Adjust the view coordinate
        if (type == MapViewCoordinateRequest.Centered)
        {
            // Reticle size is GridWidth, center = /2
            var shift = (LayerFieldItem.TilesPerAcreDim * MapScale) / 2;
            x -= shift;
            y -= shift;
        }
        else if (type == MapViewCoordinateRequest.SnapAcre)
        {
            // Snap to the nearest acre
            x -= x % LayerFieldItem.TilesPerAcreDim;
            y -= y % LayerFieldItem.TilesPerAcreDim;
        }

        var view = Mutator.View;
        // Clamp to viewport dimensions, and center to nearest acre if desired.
        // Clamp to boundaries so that we always have a full grid to view.
        return view.EnforceEdgeBuffer(x, y);
    }
}

public enum MapViewCoordinateRequest
{
    /// <summary>
    /// No adjustment to the coordinates.
    /// </summary>
    None = 0,

    /// <summary>
    /// Snap the coordinates to the nearest acre boundary.
    /// </summary>
    SnapAcre,

    /// <summary>
    /// Center the view around the requested (x,y).
    /// </summary>
    Centered,
}
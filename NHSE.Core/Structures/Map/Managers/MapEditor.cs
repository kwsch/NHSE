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
    public int MapScale { get; set; } = 2;

    /// <summary>
    /// Amount of pixel upscaling compared to a 1px = 1 tile map.
    /// </summary>
    public int AcreScale { get; set; } = 8;

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
}
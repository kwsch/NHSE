namespace NHSE.Core;

/// <summary>
/// Basic logic implementation for interacting with the manipulatable map grid.
/// </summary>
public abstract record AcreSelectionGrid(TileGridViewport TileInfo)
{
    /// <summary>
    /// Checks if the specified relative x/y coordinates are within the bounds of this layer.
    /// </summary>
    /// <param name="relX">The requested tile's X-coordinate, relative to the layer origin.</param>
    /// <param name="relY">The requested tile's Y-coordinate, relative to the layer origin.</param>
    public bool Contains(int relX, int relY) => TileInfo.Contains(relX, relY);
}
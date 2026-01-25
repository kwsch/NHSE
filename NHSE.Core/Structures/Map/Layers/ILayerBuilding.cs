using System.Collections.Generic;

namespace NHSE.Core;

/// <summary>
/// Logic for interacting with a map's building layer.
/// </summary>
public interface ILayerBuilding
{
    /// <summary>
    /// Instantiated list of all buildings on the map.
    /// </summary>
    IReadOnlyList<Building> Buildings { get; init; }

    /// <summary>
    /// Converts relative building coordinates to absolute coordinates in the map grid.
    /// </summary>
    /// <param name="relX">Relative building X coordinate</param>
    /// <param name="relY">Relative building Y coordinate</param>
    /// <returns>Map absolute X/Y coordinates</returns>
    (int X, int Y) GetCoordinatesAbsolute(ushort relX, ushort relY);

    /// <summary>
    /// Converts absolute map grid coordinates to relative building coordinates.
    /// </summary>
    /// <param name="absX">Map absolute X coordinate</param>
    /// <param name="absY">Map absolute Y coordinate</param>
    /// <returns>Relative building X/Y coordinates</returns>
    (int X, int Y) GetCoordinatesRelative(int absX, int absY);

    Building this[int i] { get; }
    int Count { get; }
}
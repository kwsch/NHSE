using System.Collections.Generic;

namespace NHSE.Core;

/// <summary>
/// Logic for interacting with a map's building layer.
/// </summary>
public sealed record LayerBuilding : ILayerBuilding
{
    public required IReadOnlyList<Building> Buildings { get; init; }

    // Although there is terrain in the Top Row and Left Column, no buildings can be placed there.
    // Buildings can only be placed below that line; per the map layout, there is 2 acres worth of buffer, then our origin starts.

    /// <summary>
    /// Compared to Item Tiles, building tiles are a 16x16 resolution (2x2 item tiles).
    /// When converting between building coordinates and absolute coordinates, we need to account for this.
    /// </summary>
    private const int BuildingResolution = 2;
    private const int BuildingTilesPerAcre = 16;
    private const int AcreBufferEdge = 2;

    public (int X, int Y) GetCoordinatesAbsolute(ushort relX, ushort relY)
    {
        int absX = (relX * BuildingResolution) + (AcreBufferEdge * BuildingTilesPerAcre);
        int absY = (relY * BuildingResolution) + (AcreBufferEdge * BuildingTilesPerAcre);
        return (absX, absY);
    }

    public (int X, int Y) GetCoordinatesRelative(int absX, int absY)
    {
        int relX = (absX - (AcreBufferEdge * BuildingTilesPerAcre)) / BuildingResolution;
        int relY = (absY - (AcreBufferEdge * BuildingTilesPerAcre)) / BuildingResolution;
        return (relX, relY);
    }

    public Building this[int i] => Buildings[i];
    public int Count => Buildings.Count;
}
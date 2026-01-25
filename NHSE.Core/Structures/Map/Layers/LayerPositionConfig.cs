using System;
using System.Diagnostics.CodeAnalysis;

namespace NHSE.Core;

/// <summary>
/// Configures how a layer rests within the Map's grid, relative to a "chunk" or "acre".
/// </summary>
/// <param name="CountWidth">Number of acres in the width direction.</param>
/// <param name="CountHeight">Number of acres in the height direction.</param>
/// <param name="ShiftWidth">Horizontal acre shift from the map's origin.</param>
/// <param name="ShiftHeight">Vertical acre shift from the map's origin.</param>
/// <param name="TilesPerAcre">Number of tiles per acre in one dimension (16 or 32).</param>
/// <param name="TileBitShift">Bit shift value to convert between tiles and acres (4 for 16 tiles, 5 for 32 tiles).</param>
/// <param name="MetaTileSize">Size of tile compared to the smallest tile possible (2 for 16 tiles, 1 for 32 tiles).</param>
public readonly record struct LayerPositionConfig(
    byte CountWidth, byte CountHeight,
    byte ShiftWidth, byte ShiftHeight,
    [ConstantExpected] byte TilesPerAcre, byte TileBitShift,
    [ConstantExpected(Max = 2, Min = 1)] byte MetaTileSize)
{
    // Maps in Animal Crossing: New Horizons are made up of acres that are 9 tiles wide and 8 tiles high.
    // 5 columns in the center are land, surrounded by 2 tiles of beach and 2 tiles of sea on each side.
    // 4 rows in the center are land, surrounded by 2 rows of beach and 2 rows of sea on each side.
    // +-----------+
    // | ~~~~~~~~~ |
    // | ~*******~ |
    // | ~*=====*~ |
    // | ~*=====*~ |
    // | ~*=====*~ |
    // | ~*=====*~ |
    // | ~*******~ |
    // | ~~~~~~~~~ |
    // +-----------+

    // Main Island Map Config - True Dimensions
    private const byte MapAcreWidth = 9; // 2 sea, 2 beach, 5 land
    private const byte MapAcreHeight = 8; // 2 sea, 2 beach, 4 land

    // Optimize some calculations away by using bit-shift instead of mul/div, as we're always a multiple of 2.
    private const byte Grid32 = 32;
    private const byte Grid16 = 16;
    private const byte Shift32 = 5; // div32 is same as sh 5
    private const byte Shift16 = 4; // div16 is same as sh 4

    /// <summary>
    /// Creates a new <see cref="LayerPositionConfig"/> instance, centering the layer within the acre.
    /// </summary>
    /// <param name="width">Width of the layer in acres.</param>
    /// <param name="height">Height of the layer in acres.</param>
    /// <param name="tilesPerAcre">Number of tiles per acre (16 or 32).</param>
    /// <param name="metaTileSize">Size of tile compared to the smallest tile possible (2 for 16 tiles, 1 for 32 tiles).</param>
    /// <returns>A new <see cref="LayerPositionConfig"/> instance.</returns>
    public static LayerPositionConfig Create(byte width, byte height,
        [ConstantExpected(Min = Grid16, Max = Grid32)] byte tilesPerAcre,
        [ConstantExpected(Min = 1, Max = 2)] byte metaTileSize)
    {
        var shiftW = (byte)((MapAcreWidth - width) / 2); // centered
        var shiftH = (byte)((MapAcreHeight - height) / 2); // centered

        var bitShift = tilesPerAcre == Grid16 ? Shift16 : Shift32;
#pragma warning disable CA1857
        return new LayerPositionConfig(width, height, shiftW, shiftH, tilesPerAcre, bitShift, metaTileSize);
#pragma warning restore CA1857
    }

    public (int X, int Y) GetCoordinatesAbsolute(int relX, int relY)
    {
        var absX = relX - ((ShiftWidth * MetaTileSize) << TileBitShift);
        var absY = relY - ((ShiftHeight * MetaTileSize) << TileBitShift);
        return (absX, absY);
    }

    public (int X, int Y) GetCoordinatesRelative(int absX, int absY)
    {
        var relX = absX + ((ShiftWidth * MetaTileSize) << TileBitShift);
        var relY = absY + ((ShiftHeight * MetaTileSize) << TileBitShift);
        return (relX, relY);
    }

    /// <summary>
    /// Determines whether the specified absolute X and Y coordinates are within the valid bounds of the map.
    /// </summary>
    /// <param name="relX">The absolute X coordinate to validate. Must be within the horizontal bounds of the map.</param>
    /// <param name="relY">The absolute Y coordinate to validate. Must be within the vertical bounds of the map.</param>
    /// <returns><see langword="true"/> if the coordinates are valid; otherwise, <see langword="false"/>.</returns>
    public bool IsCoordinateValidRelative(int relX, int relY)
    {
        var index = GetIndexTileRelative(relX, relY);
        return (uint)index < (CountWidth * CountHeight << (TileBitShift * 2));
    }

    /// <summary>
    /// Gets the requested tile index within the layer, given relative tile coordinates.
    /// </summary>
    /// <returns>The tile index within the layer.</returns>
    public int GetIndexTileRelative(int relX, int relY)
    {
        // Tile ordering is top-down, left-to-right.
        // In other words, Item[1] is X=0,Y=1
        return (relX * (CountHeight << TileBitShift)) + relY;
    }

    public bool IsCoordinateValidAbsolute(int absX, int absY)
    {
        var (relX, relY) = GetCoordinatesRelative(absX, absY);
        return IsCoordinateValidRelative(relX, relY);
    }
}
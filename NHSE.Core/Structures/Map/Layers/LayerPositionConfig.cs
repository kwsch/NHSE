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
public readonly record struct LayerPositionConfig(
    byte CountWidth, byte CountHeight,
    byte ShiftWidth, byte ShiftHeight,
    [ConstantExpected] byte TilesPerAcre, byte TileBitShift)
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
    /// <returns>A new <see cref="LayerPositionConfig"/> instance.</returns>
    public static LayerPositionConfig Create(byte width, byte height, [ConstantExpected(Min = Grid16, Max = Grid32)] byte tilesPerAcre)
    {
        var shiftW = (byte)((MapAcreWidth - width) / 2); // centered
        var shiftH = (byte)((MapAcreHeight - height) / 2); // centered

        var bitShift = tilesPerAcre == Grid16 ? Shift16 : Shift32;
#pragma warning disable CA1857
        return new LayerPositionConfig(width, height, shiftW, shiftH, tilesPerAcre, bitShift);
#pragma warning restore CA1857
    }

    /// <summary>
    /// Converts absolute coordinates to coordinates relative to the stored layer.
    /// </summary>
    /// <param name="absX">Absolute X coordinate on the map.</param>
    /// <param name="absY">Absolute Y coordinate on the map.</param>
    /// <param name="relX">Relative X coordinate in the layer.</param>
    /// <param name="relY">Relative Y coordinate in the layer.</param>
    /// <returns><see langword="true"/> if the absolute coordinates are within the layer; otherwise, <see langword="false"/>.</returns>
    public bool TryGetRelativeCoordinates(int absX, int absY, out int relX, out int relY)
    {
        relX = 0;
        relY = 0;

        // Get relative acre
        var (acreX, acreY) = GetAbsoluteAcre(absX, absY);
        acreX -= ShiftWidth;
        acreY -= ShiftHeight;

        // Performance: single if-check by using underflow casting to unsigned
        if ((uint)acreX >= CountWidth)
            return false;
        if ((uint)acreY >= CountHeight)
            return false;

        // Return relative position
        relX = absX - (ShiftWidth << TileBitShift);
        relY = absY - (ShiftHeight << TileBitShift);
        return true;
    }

    /// <summary>
    /// Determines whether the specified absolute X and Y coordinates are within the valid bounds of the map.
    /// </summary>
    /// <param name="absX">The absolute X coordinate to validate. Must be within the horizontal bounds of the map.</param>
    /// <param name="absY">The absolute Y coordinate to validate. Must be within the vertical bounds of the map.</param>
    /// <returns><see langword="true"/> if the coordinates are valid; otherwise, <see langword="false"/>.</returns>
    public bool IsAbsoluteCoordinateValid(int absX, int absY)
    {
        if ((uint)absX >= ((uint)MapAcreWidth << TileBitShift))
            return false;
        if ((uint)absY >= ((uint)MapAcreHeight << TileBitShift))
            return false;
        return true;
    }

    /// <summary>
    /// Gets the absolute acre coordinates from absolute tile coordinates.
    /// </summary>
    public (int X, int Y) GetAbsoluteAcre(int absX, int absY)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual((uint)absX, (uint)MapAcreWidth << TileBitShift);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual((uint)absY, (uint)MapAcreHeight << TileBitShift);
        var acreX = absX >> TileBitShift;
        var acreY = absY >> TileBitShift;
        return (acreX, acreY);
    }

    /// <summary>
    /// Gets the requested tile index within the layer, given relative tile coordinates.
    /// </summary>
    /// <returns>The tile index within the layer.</returns>
    /// <inheritdoc cref="TryGetRelativeCoordinates(int, int, out int, out int)"/>
    public int GetIndexTileRelative(int relX, int relY)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual((uint)relX, (uint)CountWidth << TileBitShift);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual((uint)relY, (uint)CountHeight << TileBitShift);
        // Tile ordering is top-down, left-to-right.
        // In other words, Item[1] is X=0,Y=1
        return (relX * (CountHeight << TileBitShift)) + relY;
    }

    /// <summary>
    /// Gets the requested tile index within the absolute map boundary, given absolute tile coordinates in the map.
    /// </summary>
    /// <returns>The tile index within the map.</returns>
    /// <inheritdoc cref="TryGetRelativeCoordinates(int, int, out int, out int)"/>
    public int GetIndexTileAbsolute(int absX, int absY)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual((uint)absX, (uint)MapAcreWidth << TileBitShift);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual((uint)absY, (uint)MapAcreHeight << TileBitShift);
        // Tile ordering is top-down, left-to-right.
        // In other words, Item[1] is X=0,Y=1
        return (absX * (MapAcreHeight << TileBitShift)) + absY;
    }

    /// <summary>
    /// Gets the acre index (not the value selection of the acre) based on the absolute coordinates on the map.
    /// </summary>
    /// <returns>The acre index within the map.</returns>
    /// <inheritdoc cref="TryGetRelativeCoordinates(int, int, out int, out int)"/>
    public int GetIndexAcre(int absX, int absY)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual((uint)absX, MapAcreWidth);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual((uint)absY, MapAcreHeight);

        // Acre ordering is top-down, left-to-right.
        var (x, y) = GetAbsoluteAcre(absX, absY);
        return (x * MapAcreHeight) + y;
    }
}
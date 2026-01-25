using System;
using System.Diagnostics.CodeAnalysis;

namespace NHSE.Core;

/// <summary>
/// Basic configuration of a narrow view for interacting with the larger manipulatable tile grid.
/// </summary>
/// <param name="ViewWidth">Viewable amount of viewable tiles wide</param>
/// <param name="ViewHeight">Viewable amount of viewable tiles high</param>
/// <param name="Columns">Columns of view available</param>
/// <param name="Rows">Rows of view available</param>
public readonly record struct TileGridViewport([ConstantExpected] byte ViewWidth, [ConstantExpected] byte ViewHeight, byte Columns, byte Rows)
{
    /// <summary>
    /// Total width of the entire grid (including the view).
    /// </summary>
    public int TotalWidth => Columns * ViewWidth;

    /// <summary>
    /// Total height of the entire grid (including the view).
    /// </summary>
    public int TotalHeight => Rows * ViewHeight;

    /// <summary>
    /// Amount of tiles present in the grid.
    /// </summary>
    public int ViewCount => ViewWidth * ViewHeight;

    /// <summary>
    /// Amount of ALL tiles present in the entire grid (including the grid).
    /// </summary>
    public int TotalCount => TotalWidth * TotalHeight;

    /// <summary>
    /// Gets the dimensions of the viewable area (an acre-worth).
    /// </summary>
    public (int X, int Y) DimAcre => (ViewWidth, ViewHeight);

    /// <summary>
    /// Gets the total dimensions of the entire grid (including the view).
    /// </summary>
    public (int X, int Y) DimTotal => (TotalWidth, TotalHeight);

    /// <summary>
    /// Gets the absolute index of the absolute tile in the grid based on the x/y coordinates.
    /// </summary>
    /// <param name="relX">Relative X-coordinate of the tile in the grid</param>
    /// <param name="relY">Relative Y-coordinate of the tile in the grid</param>
    /// <returns>Absolute index of the tile in the grid</returns>
    public int GetTileIndex(in int relX, in int relY) => (TotalHeight * relX) + relY;

    /// <summary>
    /// Clamps the specified relative X and Y coordinates so that they remain within the valid bounds of the area.
    /// </summary>
    /// <remarks>
    /// Use this method to prevent coordinates from exceeding the valid area,
    /// which may help avoid out-of-bounds errors when working with grid-based data or images.
    /// </remarks>
    /// <param name="relX">The relative X coordinate to clamp.</param>
    /// <param name="relY">The relative Y coordinate to clamp.</param>
    public void ClampInside(ref int relX, ref int relY)
        => ClampCoordinatesTo(ref relX, ref relY, TotalWidth - 1, TotalHeight - 1);

    private static void ClampCoordinatesTo(ref int relX, ref int relY, int maxX, int maxY)
    {
        relX = Math.Clamp(relX, 0, maxX);
        relY = Math.Clamp(relY, 0, maxY);
    }

    /// <summary>
    /// Determines whether the specified relative coordinates are within the bounds of the area.
    /// </summary>
    /// <param name="relX">The horizontal coordinate, relative to the left edge of the area.</param>
    /// <param name="relY">The vertical coordinate, relative to the top edge of the area.</param>
    /// <returns><see langword="true"/> if the specified coordinates are within the bounds; otherwise, <see langword="false"/>.</returns>
    public bool Contains(int relX, int relY) => !((uint)relX >= TotalWidth || (uint)relY >= TotalHeight);
}
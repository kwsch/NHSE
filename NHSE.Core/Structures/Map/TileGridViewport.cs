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

    public (int X, int Y) DimAcre => (ViewWidth, ViewHeight);
    public (int X, int Y) DimTotal => (TotalWidth, TotalHeight);

    public int GetTileIndex(int acreX, int acreY, int gridX, int gridY)
    {
        var x = (acreX * ViewWidth) + gridX;
        var y = (acreY * ViewHeight) + gridY;
        return GetTileIndex(x, y);
    }

    /// <summary>
    /// Gets the absolute index of the absolute tile in the grid based on the x/y coordinates.
    /// </summary>
    /// <param name="x">Absolute x coordinate of the tile in the grid</param>
    /// <param name="y">Absolute y coordinate of the tile in the grid</param>
    /// <returns>Absolute index of the tile in the grid</returns>
    public int GetTileIndex(in int x, in int y) => (TotalHeight * x) + y;

    public void ClampInside(ref int x, ref int y) => ClampCoordinatesTo(ref x, ref y, TotalWidth - 1, TotalHeight - 1);

    private static void ClampCoordinatesTo(ref int x, ref int y, int maxX, int maxY)
    {
        x = Math.Clamp(x, 0, maxX);
        y = Math.Clamp(y, 0, maxY);
    }

    public void GetViewAnchorCoordinates(ref int x, ref int y, in bool centerReticle)
    {
        // If we aren't snapping the reticle to the nearest acre
        // we want to put the middle of the reticle rectangle where the cursor is.
        // Adjust the view coordinate
        if (!centerReticle)
        {
            // Reticle size is GridWidth, center = /2
            x -= ViewWidth / 2;
            y -= ViewWidth / 2;
        }

        // Clamp to viewport dimensions, and center to nearest acre if desired.
        // Clamp to boundaries so that we always have a full grid to view.
        SetTopLeftNearest(ref x, ref y);
    }

    private void SetTopLeftNearest(ref int x, ref int y)
    {
        int maxX = TotalWidth - ViewWidth;
        int maxY = TotalHeight - ViewHeight;
        ClampCoordinatesTo(ref x, ref y, maxX, maxY);
    }
}
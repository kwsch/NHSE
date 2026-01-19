using System;
using System.ComponentModel.DataAnnotations;

namespace NHSE.Core;

public sealed record MapViewState
{
    private const int MaxX = LayerFieldItem.TilesPerAcreDim * AcreCoordinate.CountAcreExteriorWidth;
    private const int MaxY = LayerFieldItem.TilesPerAcreDim * AcreCoordinate.CountAcreExteriorHeight;
    private const int EdgeBuffer = LayerFieldItem.TilesPerAcreDim;

    /// <summary>
    /// Amount the X/Y coordinates change when using arrow movement.
    /// </summary>
    [Range(1, 8)] public uint ArrowViewInterval { get; set; } = 2;

    [Range(0, 1)] public int ItemLayerIndex
    {
        get;
        set
        {
            if (value is not (0 or 1))
                throw new ArgumentOutOfRangeException(nameof(value), "Item layer index must be 0 or 1.");
            field = value;
        }
    }

    /// <summary>
    /// Top-left-origin X coordinate of the view.
    /// </summary>
    public int X
    {
        get;
        private set
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual((uint)value, (uint)MaxX);
            field = value;
        }
    }

    /// <summary>
    /// Top-left-origin Y coordinate of the view.
    /// </summary>
    public int Y
    {
        get;
        private set
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual((uint)value, (uint)MaxY);
            field = value;
        }
    }

    public bool CanUp => Y != 0;
    public bool CanDown => Y != MaxY;
    public bool CanLeft => X != 0;
    public bool CanRight => X != MaxX;

    /// <summary>
    /// Moves the view up by <see cref="ArrowViewInterval"/> tiles.
    /// </summary>
    /// <returns><see langword="true"/> if the view changed; otherwise, <see langword="false"/>.</returns>
    public bool ArrowUp()
    {
        if (!CanUp)
            return false;
        Y = Math.Max(0, Y - (int)ArrowViewInterval);
        return true;
    }

    /// <summary>
    /// Moves the view left by <see cref="ArrowViewInterval"/> tiles.
    /// </summary>
    /// <returns><see langword="true"/> if the view changed; otherwise, <see langword="false"/>.</returns>
    public bool ArrowLeft()
    {
        if (!CanLeft)
            return false;
        X = Math.Max(0, X - (int)ArrowViewInterval);
        return true;
    }

    /// <summary>
    /// Moves the view right by <see cref="ArrowViewInterval"/> tiles.
    /// </summary>
    /// <returns><see langword="true"/> if the view changed; otherwise, <see langword="false"/>.</returns>
    public bool ArrowRight()
    {
        if (!CanRight)
            return false;
        X = Math.Min(MaxX - EdgeBuffer, X + (int)ArrowViewInterval);
        return true;
    }

    /// <summary>
    /// Moves the view down by <see cref="ArrowViewInterval"/> tiles.
    /// </summary>
    /// <returns><see langword="true"/> if the view changed; otherwise, <see langword="false"/>.</returns>
    public bool ArrowDown()
    {
        if (!CanDown)
            return false;
        Y = Math.Min(MaxY - EdgeBuffer, Y + (int)ArrowViewInterval);
        return true;
    }

    /// <summary>
    /// Applies the requested coordinates (sanity checked).
    /// </summary>
    /// <returns><see langword="true"/> if the view changed; otherwise, <see langword="false"/>.</returns>
    public bool SetViewTo(in int absX, in int absY)
    {
        var (x, y) = (X, Y);
        X = Math.Clamp(absX, 0, MaxX - EdgeBuffer);
        Y = Math.Clamp(absY, 0, MaxY - EdgeBuffer);
        return x != X || y != Y;
    }

    /// <summary>
    /// Sets the view to the top-left of the specified acre.
    /// </summary>
    /// <remarks>
    /// Acres are ordered Y-down-first.
    /// </remarks>
    /// <param name="acre">Acre index to set the view to.</param>
    public void SetViewToAcre(int acre)
    {
        var acreX = acre % (MaxX / EdgeBuffer);
        var acreY = acre / (MaxX / EdgeBuffer);
        SetViewTo(acreX * EdgeBuffer, acreY * EdgeBuffer);
    }
}
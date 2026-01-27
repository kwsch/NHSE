using System;

namespace NHSE.Core;

/// <summary>
/// Logic for managing field item flags within a layer.
/// </summary>
public interface ILayerFieldItemFlag
{
    /// <summary>
    /// Gets the active state of the field item flag at the specified relative coordinates.
    /// </summary>
    /// <param name="relX">Relative X coordinate within the array.</param>
    /// <param name="relY">Relative Y coordinate within the array.</param>
    /// <returns>The active state of the field item flag.</returns>
    bool GetIsActive(int relX, int relY);

    /// <summary>
    /// Sets the active state of the field item flag at the specified relative coordinates.
    /// </summary>
    /// <param name="relX">Relative X coordinate within the array.</param>
    /// <param name="relY">Relative Y coordinate within the array.</param>
    /// <param name="value">The active state to set.</param>
    void SetIsActive(int relX, int relY, bool value = true);

    bool this[int relX, int relY]
    {
        get => GetIsActive(relX, relY);
        set => SetIsActive(relX, relY, value);
    }

    /// <summary>
    /// Deactivates all field item flags.
    /// </summary>
    void DeactivateAll();

    /// <summary>
    /// Saves the (in)active flags into the provided destination span.
    /// </summary>
    /// <param name="dest">Destination span to save the flags into.</param>
    void Save(Span<byte> dest);

    /// <summary>
    /// Imports the (in)active flags from the provided source span.
    /// </summary>
    /// <param name="src">Source span containing the flags to import.</param>
    void Import(Span<byte> src);

    /// <summary>
    /// Fetched for exporting operations.
    /// </summary>
    ReadOnlySpan<byte> ExistingData { get; }
}
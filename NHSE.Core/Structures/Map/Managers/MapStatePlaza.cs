namespace NHSE.Core;

/// <summary>
/// Value storage for plaza position in the map.
/// </summary>
public sealed class MapStatePlaza
{
    /// <summary>
    /// Plaza Position X coordinate.
    /// </summary>

    public required uint X { get; set; }

    /// <summary>
    /// Plaza Position Z coordinate.
    /// </summary>
    public required uint Z { get; set; }
}
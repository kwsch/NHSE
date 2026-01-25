namespace NHSE.Core;

/// <summary>
/// Represents a list of item data tiles to be injected to a Field Item Layer.
/// </summary>
/// <remarks>
/// Extension tiles underneath the actual item root are included; extension tiles to the right are not.
/// </remarks>
/// <param name="RelativeX">X Coordinate within the Field Item Layer</param>
/// <param name="RelativeY">Y Coordinate within the Field Item Layer</param>
/// <param name="Offset">Offset relative to the start of the Field Item Layer</param>
/// <param name="Data">Data for this column</param>
public sealed record FieldItemColumn(int RelativeX, int RelativeY, int Offset, byte[] Data);
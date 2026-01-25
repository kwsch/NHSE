namespace NHSE.Core;

/// <summary>
/// Flagging various issues when trying to place an item.
/// </summary>
public enum PlacedItemPermission : byte
{
    /// <summary>
    /// Item does not have any of its tiles overlapping with any other items.
    /// </summary>
    NoCollision = 0,

    /// <summary>
    /// Item tiles are overlapping with another item.
    /// </summary>
    Collision = 1,

    /// <summary>
    /// Item tiles would overflow out-of-bounds.
    /// </summary>
    OutOfBounds = 2,
}
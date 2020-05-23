namespace NHSE.Core
{
    /// <summary>
    /// Flagging various issues when trying to place an item.
    /// </summary>
    public enum PlacedItemPermission
    {
        /// <summary>
        /// Item does not have any of its tiles overlapping with any other items.
        /// </summary>
        NoCollision,

        /// <summary>
        /// Item tiles are overlapping with another item.
        /// </summary>
        Collision,

        /// <summary>
        /// Item tiles would overflow out-of-bounds.
        /// </summary>
        OutOfBounds,
    }
}

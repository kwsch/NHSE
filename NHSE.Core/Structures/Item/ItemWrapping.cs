namespace NHSE.Core
{
    /// <summary>
    /// Type of wrapping an <see cref="Item"/> has
    /// </summary>
    public enum ItemWrapping : byte
    {
        Nothing = 0,
        WrappingPaper = 1,
        Present = 2,
        Delivery = 3
    }
}

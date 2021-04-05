namespace NHSE.Core
{
    /// <summary>
    /// Interface describing how items should be configured prior to being dropped by the player.
    /// </summary>
    public interface IConfigItem
    {
        /// <summary>
        /// Checks if the item should have wrapping paper applied.
        /// </summary>
        bool WrapAllItems { get; }

        /// <summary>
        /// Wrapping paper type applied if <see cref="WrapAllItems"/> is set.
        /// </summary>
        ItemWrappingPaper WrappingPaper { get; }

        /// <summary>
        /// Checks if the Drop Compatibility check should be skipped.
        /// </summary>
        bool SkipDropCheck { get; }
    }
}

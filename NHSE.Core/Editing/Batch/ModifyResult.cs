namespace NHSE.Core
{
    /// <summary>
    /// Batch Editor Modification result for an individual item.
    /// </summary>
    public enum ModifyResult
    {
        /// <summary>
        /// The data has invalid data and is not a suitable candidate for modification.
        /// </summary>
        Invalid,

        /// <summary>
        /// An error was occurred while iterating modifications for this data.
        /// </summary>
        Error,

        /// <summary>
        /// The data was skipped due to a matching Filter.
        /// </summary>
        Filtered,

        /// <summary>
        /// The data was modified.
        /// </summary>
        Modified,
    }
}

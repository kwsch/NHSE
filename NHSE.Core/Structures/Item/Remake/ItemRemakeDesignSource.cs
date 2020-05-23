using System;

namespace NHSE.Core
{
    /// <summary>
    /// Determines how an item's secondary customization value is used.
    /// </summary>
    [Flags]
    public enum ItemRemakeDesignSource
    {
        None = 0,
        Common = 1,
        MyDesign = 2,
        CommonAndMyDesign = Common | MyDesign,
    }
}

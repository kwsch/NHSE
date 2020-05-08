using System;

namespace NHSE.Core
{
    [Flags]
    public enum ItemRemakeDesignSource
    {
        None = 0,
        Common = 1,
        MyDesign = 2,
        CommonAndMyDesign = Common | MyDesign,
    }
}

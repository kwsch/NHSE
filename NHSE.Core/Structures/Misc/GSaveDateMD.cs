using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct GSaveDateMD
    {
        public const int SIZE = 2;
        public override string ToString() => $"{Month:00}-{Day:00}";

        public byte Month { get; set; }
        public byte Day { get; set; }
    }
}

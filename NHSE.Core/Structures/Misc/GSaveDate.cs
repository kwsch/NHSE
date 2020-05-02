using System.ComponentModel;
using System.Runtime.InteropServices;

#pragma warning disable CS8618, CA1815, CA1819, IDE1006
namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct GSaveDate
    {
        public const int SIZE = 4;
        public override string ToString() => $"{Year:0000}-{Month:00}-{Day:00}";

        public ushort Year { get; set; }
        public byte Month { get; set; }
        public byte Day { get; set; }
    }
}

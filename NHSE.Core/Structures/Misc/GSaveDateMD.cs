using System.ComponentModel;
using System.Runtime.InteropServices;

#pragma warning disable CS8618, CA1815, CA1819, IDE1006
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

    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct GSavePlayerHandleName
    {
        public const int SIZE = 0xA;

        public ushort ModifierId { get; set; }
        public byte ModifierLevel { get; set; }

        public ushort NounId { get; set; }
        public byte NounLevel { get; set; }
        public byte NounGenderType { get; set; }
        public byte _fa0a936b { get; set; }
    };
}

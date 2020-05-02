using System.ComponentModel;
using System.Runtime.InteropServices;

#pragma warning disable CS8618, CA1815, CA1819, IDE1006
namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct GSavePlayerBaseId
    {
        public const int SIZE = 0x1C;
        public override string ToString() => Name;

        public uint Id { get; set; }

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string Name { get; set; }

        public Gender Gender { get; set; }
    }
}

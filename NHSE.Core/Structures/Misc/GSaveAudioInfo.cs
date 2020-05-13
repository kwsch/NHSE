using System.ComponentModel;
using System.Runtime.InteropServices;

#pragma warning disable CS8618, CA1815, CA1819, IDE1006
namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, Size = SIZE)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct GSaveAudioInfo
    {
        public const int SIZE = 0x4;

        public short PlayingAudioMusicID { get; set; }
        public sbyte Unknown { get; set; }

        [field: MarshalAs(UnmanagedType.I1, SizeConst = 1)]
        public bool IsShuffle { get; set; }
    };
}

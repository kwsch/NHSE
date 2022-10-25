using System.ComponentModel;
using System.Runtime.InteropServices;

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

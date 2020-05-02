using System.ComponentModel;
using System.Runtime.InteropServices;
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global

#pragma warning disable CS8618, CA1815, CA1819, IDE1006
namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct GSaveBulletinBoard
    {
        public const int SIZE = 0xe0ae8;
        public override string ToString() => $"{BuiltDate}: {Stock}";

        public GSaveDate BuiltDate { get; set; }                            // @0x0 size 0x4, align 2
        public bool _3347e149 { get; set; }                                 // @0x4 size 0x1, align 1
        public BulletinBoardStock Stock { get; set; }                       // @0x8 size 0xe0ad8, align 8
        public uint LatestUniqueId { get; set; }                            // @0xe0ae0 size 0x4, align 4
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct BulletinBoardStock
    {
        public const int SIZE = 0xe0ad8;
        public const int MaxCount = 30;
        public override string ToString() => "Bulletin Board";

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxCount)]
        public GSaveBBS[] Buffer { get; set; }                                // @0x0 size 0x77d0, align 8

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxCount)]
        public int[] IndexTable { get; set; }                                 // @0xe0a60 size 0x4, align 4
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Unicode)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct GSaveBBS
    {
        public const int SIZE = 0x77d0;
        public override string ToString() => $"{Date}: {Body}";

        public GSaveDate Date { get; set; }                                      // @0x0 size 0x4, align 2

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 240)]
        public string Body { get; set; }                                         // @0x4 size 0x1e0, align 2

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
        public string Footer { get; set; }                                       // @0x1e4 size 0x60, align 2

        public Handwriting HandWrite { get; set; }                               // @0x244 size 0x7538, align 4
        public GSavePlayerId PlayerId { get; set; }                              // @0x777c size 0x38, align 4
#pragma warning disable IDE1006 // Naming Styles
        public ushort _5d1fcb04 { get; set; }                                    // @0x77b4 size 0x2, align 2
#pragma warning restore IDE1006 // Naming Styles
        public ushort DesignId { get; set; }                                     // @0x77b6 size 0x2, align 2
        public ulong PopId { get; set; }                                         // @0x77b8 size 0x8, align 8
        public ulong NsaId { get; set; }                                         // @0x77c0 size 0x8, align 8
        public uint UniqueId { get; set; }                                       // @0x77c8 size 0x4, align 4
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct Handwriting
    {
        public const int SIZE = 0x7538;

        public const int InkCount = 30_000;
        public const int PaletteCount = 4;

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = InkCount)]
        public byte[] Image { get; set; }

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = PaletteCount)]
        public byte[] Palette { get; set; }

        public uint VerticesNum { get; set; }
    }
}
#pragma warning restore CS8618, CA1815, CA1819, IDE1006

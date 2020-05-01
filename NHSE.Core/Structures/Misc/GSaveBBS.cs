using System.Runtime.InteropServices;
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global

#pragma warning disable CS8618, CA1815
namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = SIZE, CharSet = CharSet.Unicode)]
    public struct GSaveBulletinBoard
    {
        public const int SIZE = 0xe0ae8;

        public GSaveDate BuiltDate;                            // @0x0 size 0x4, align 2
        public bool _3347e149;                                 // @0x4 size 0x1, align 1
        public BulletinBoardStock Stock;                       // @0x8 size 0xe0ad8, align 8
        public uint LatestUniqueId;                            // @0xe0ae0 size 0x4, align 4
    };

    public struct BulletinBoardStock
    {
        public const int SIZE = 0xe0ad8;
        public const int MaxCount = 30;

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxCount)]
        public GSaveBBS[] Buffer;                                // @0x0 size 0x77d0, align 8

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxCount)]
        public int[] IndexTable;                                 // @0xe0a60 size 0x4, align 4
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = SIZE, CharSet = CharSet.Unicode)]
    public struct GSaveBBS
    {
        public const int SIZE = 0x77d0;

        public GSaveDate Date;                                      // @0x0 size 0x4, align 2

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 240/2)]
        public string Body;                                         // @0x4 size 0x1e0, align 2

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48/2)]
        public string Footer;                                       // @0x1e4 size 0x60, align 2

        public Handwriting HandWrite;                               // @0x244 size 0x7538, align 4
        public GSavePlayerId PlayerId;                              // @0x777c size 0x38, align 4
        public ushort _5d1fcb04;                                    // @0x77b4 size 0x2, align 2
        public ushort DesignId;                                     // @0x77b6 size 0x2, align 2
        public ulong PopId;                                         // @0x77b8 size 0x8, align 8
        public ulong NsaId;                                         // @0x77c0 size 0x8, align 8
        public uint UniqueId;                                       // @0x77c8 size 0x4, align 4
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = SIZE)]
    public struct GSaveDate
    {
        public const int SIZE = 4;

        public ushort Year;
        public byte Month;
        public byte Day;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = SIZE)]
    public struct Handwriting
    {
        public const int SIZE = 0x7538;

        public const int InkCount = 30_000;

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = InkCount)]
        public byte[] Image;

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Palette;

        public uint VerticesNum;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = SIZE)]
    public struct GSavePlayerId
    {
        public const int SIZE = 0x38;
        public GSaveLandId LandId;
        public GSavePlayerBaseId BaseId;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = SIZE, CharSet = CharSet.Unicode)]
    public struct GSaveLandId
    {
        public const int SIZE = 0x1C;

        public uint Id;

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x14 / 2)]
        public string Name;

        public byte IslandRubyType;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = SIZE, CharSet = CharSet.Unicode)]
    public struct GSavePlayerBaseId
    {
        public const int SIZE = 0x1C;

        public uint Id;

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x14 / 2)]
        public string Name;

        public int Gender; // enum
    }
}
#pragma warning restore CS8618, CA1815

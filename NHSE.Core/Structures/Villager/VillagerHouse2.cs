using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

public sealed class VillagerHouse2(Memory<byte> raw) : VillagerHouse1(raw)
{
    public new const int SIZE = 0x12E8;
    public override string Extension => "nhvh2";

    // 0x1D4-0x12DB -- 0x1108 sized structure
    // 0x12DC -- 8 byte item
    // 0x12E4 -- 1 byte

    public s_f9acc222 ReadCustom() => Data.Slice(0x1D4, s_f9acc222.SIZE).ToStructure<s_f9acc222>();
    public void WriteCustom(s_f9acc222 value) => value.ToBytes().CopyTo(Data[0x1D4..]);

    public Item ExtraItem
    {
        get => new(ReadUInt64LittleEndian(Data[0x12DC..]));
        set => WriteUInt64LittleEndian(Data[0x12DC..], value.RawValue);
    }

    public byte Flag { get => Data[0x12E4]; set => Data[0x12E4] = value; }

    public VillagerHouse1 Downgrade()
    {
        var result = new byte[VillagerHouse1.SIZE];
        Data.CopyTo(result);
        return new VillagerHouse1(result);
    }

    internal static ReadOnlySpan<byte> Footer =>
    [
        0x4B, 0x13, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4B, 0x13, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x9B, 0x13, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF8, 0x00, 0xF8, 0x00, 0xF8, 0x00, 0x40,
        0x10, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFE, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0xFE, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFE, 0xFF, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
    ];
}

#pragma warning disable CS8618, CA1815, CA1819, IDE1006, RCS1170
[StructLayout(LayoutKind.Sequential, Pack = 4, Size = SIZE)]
[TypeConverter(typeof(ValueTypeTypeConverter))]
public struct s_f9acc222
{
    public const int SIZE = 0x1108;         /* 0x1108 big, align 4 */
    public byte _599b2c0c { get; set; }                               // @0x0 size 0x1, align 1
    public s_e74059db _7ec757ba { get; set; }                         // @0x4 size 0xb10, align 4
    public s_a7a72585 _9d2fe4d0 { get; set; }                         // @0xb14 size 0x588, align 2
    public GSaveRoomFloorWall RoomFloorWall { get; set; }             // @0x109c size 0x24, align 4
    public s_e13a81f4 _cfb139b9 { get; set; }                         // @0x10c0 size 0x14, align 4
    public GSaveItemName _428c13b4 { get; set; }                      // @0x10d4 size 0x8, align 4
    public GSaveItemName _eb46f399 { get; set; }                      // @0x10dc size 0x8, align 4
    public GSaveAudioRegister AudioRegister { get; set; }             // @0x10e4 size 0x20, align 4
    public byte _81845564 { get; set; }                               // @0x1104 size 0x1, align 1
}

[StructLayout(LayoutKind.Sequential, Pack = 4, Size = SIZE)]
[TypeConverter(typeof(ValueTypeTypeConverter))]
public struct s_e13a81f4
{
    public const int SIZE = 0x14; /* 0x14 big, align 4 */
    public byte _ba0f8ef3 { get; set; }                              // @0x0 size 0x1, align 1
    public byte _99bc9d5c { get; set; }                              // @0x1 size 0x1, align 1
    public byte _7dd80307 { get; set; }                              // @0x2 size 0x1, align 1
    public byte Reserve { get; set; }                                // @0x3 size 0x1, align 1
    public ushort InfoBit { get; set; }                              // @0x4 size 0x2, align 2
    public ushort _da6790dc { get; set; }                            // @0x6 size 0x2, align 2
    public float _a5b1bb4b { get; set; }                             // @0x8 size 0x4, align 4
    public ushort _bb77b980 { get; set; }                            // @0xc size 0x2, align 2
    public ushort _f32a8316 { get; set; }                            // @0xe size 0x2, align 2
    public ushort _cec1a6ec { get; set; }                            // @0x10 size 0x2, align 2
    public ushort _c3971e28 { get; set; }                            // @0x12 size 0x2, align 2
}

[StructLayout(LayoutKind.Sequential, Pack = 4, Size = SIZE)]
[TypeConverter(typeof(ValueTypeTypeConverter))]
public struct GSaveAudioRegister
{
    public const int SIZE = 0x20;/* 0x20 big, align 4 */
    [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public uint[] RegisterBitList { get; set; }                        // @0x0 size 0x20, align 4
}

[StructLayout(LayoutKind.Sequential, Pack = 4, Size = SIZE)]
[TypeConverter(typeof(ValueTypeTypeConverter))]
public struct s_e74059db
{
    public const int SIZE = 0xB10; /* 0xb10 big, align 4 */

    [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 236)]
    public s_c642ef36[] _7ec757ba { get; set; } // @0x0 size 0xc, align 4
}

[StructLayout(LayoutKind.Sequential, Pack = 2, Size = SIZE)]
[TypeConverter(typeof(ValueTypeTypeConverter))]
public struct s_a7a72585
{
    public const int SIZE = 0x588; /* 0x588 big, align 2 */

    [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 236)]
    public s_bd80e9c8[] _9d2fe4d0 { get; set; }                         // @0x0 size 0x6, align 2
}

[StructLayout(LayoutKind.Sequential, Pack = 2, Size = SIZE)]
[TypeConverter(typeof(ValueTypeTypeConverter))]
public struct s_bd80e9c8
{
    public const int SIZE = 0x6; /* 0x6 big, align 2 */
    public ushort _c929122c { get; set; }                             // @0x0 size 0x2, align 2
    public sbyte _2814d70c { get; set; }                              // @0x2 size 0x1, align 1
    public sbyte _3dbac09d { get; set; }                              // @0x3 size 0x1, align 1
    public sbyte Layer { get; set; }                                  // @0x4 size 0x1, align 1
}

[StructLayout(LayoutKind.Sequential, Pack = 4, Size = SIZE)]
[TypeConverter(typeof(ValueTypeTypeConverter))]
public struct s_c642ef36
{
    public const int SIZE = 0xC; /* 0xc big, align 4 */
    public GSaveItemName Item { get; set; }                          // @0x0 size 0x8, align 4
    public sbyte _2814d70c { get; set; }                             // @0x8 size 0x1, align 1
    public sbyte _3dbac09d { get; set; }                             // @0x9 size 0x1, align 1
    public sbyte Layer { get; set; }                                 // @0xa size 0x1, align 1
    public byte Buffer { get; set; }                                 // @0xb size 0x1, align 1
}
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    public class PlayerRoom2 : PlayerRoom1
    {
        public new const int SIZE = 0x6C24;
        public new virtual string Extension => "nhpr2";

        public PlayerRoom2(byte[] data) : base(data) { }

        /*
          s_665e9093                        ExtraEffectLayerList[2];                   // @0x65c8 size 0x320, align 2
          GSaveMusicBoxInfo                 MusicBoxInfo;                              // @0x6c08 size 0x4, align 2
          u8                                SoundAmbient;                              // @0x6c0c size 0x1, align 1
          u8 gap_6c0d[3];
          s_e13a81f4                        _cfb139b9;                                 // @0x6c10 size 0x14, align 4
         */

        public s_665e9093[] ExtraEffectLayerList
        {
            get
            {
                var result = new s_665e9093[2];
                for (int i = 0; i < result.Length; i++)
                {
                    var slice = Data.Slice(0x65C8 + (i * s_665e9093.SIZE), s_665e9093.SIZE);
                    result[i] = slice.ToStructure<s_665e9093>();
                }
                return result;
            }

            set
            {
                for (int i = 0; i < value.Length; i++)
                    value[i].ToBytes().CopyTo(Data, 0x65C8 + (i * s_665e9093.SIZE));
            }
        }

        public GSaveMusicBoxInfo MusicBoxInfo
        {
            get => Data.Slice(0x6C08, GSaveMusicBoxInfo.SIZE).ToStructure<GSaveMusicBoxInfo>();
            set => value.ToBytes().CopyTo(Data, 0x6C08);
        }

        public SoundAmbientKind SoundAmbientUniqueID { get => (SoundAmbientKind)Data[0x6C0C]; set => Data[0x6C0C]= (byte)value; }

        // 3 bytes padding

        public s_e13a81f4 _cfb139b9
        {
            get => Data.Slice(0x6C10, s_e13a81f4.SIZE).ToStructure<s_e13a81f4>();
            set => value.ToBytes().CopyTo(Data, 0x6C10);
        }

        public PlayerRoom1 Downgrade()
        {
            var result = new byte[PlayerRoom1.SIZE];
            Array.Copy(Data, result, PlayerRoom1.SIZE);
            return new PlayerRoom1(result);
        }
    }

#pragma warning disable CS8618, CA1815, CA1819, IDE1006, RCS1170
    [StructLayout(LayoutKind.Sequential, Pack = 2, Size = SIZE)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct s_665e9093
    {
        public const int SIZE = 0x320; /* 0x320 big, align 2 */

        [field: MarshalAs(UnmanagedType.LPArray, SizeConst = 400)]
        public GSaveItemExtraEffect[] ItemExtraEffectBuffer { get; set; } // @0x0 size 0x2, align 2
    }

    [StructLayout(LayoutKind.Sequential, Pack = 2, Size = SIZE)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct GSaveItemExtraEffect
    {
        public const int SIZE = 0x2; /* 0x2 big, align 2 */

        public ushort InnerData { get; set; } // @0x0 size 0x2, align 2
    }

    [StructLayout(LayoutKind.Sequential, Pack = 2, Size = SIZE)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct GSaveMusicBoxInfo
    {
        public const int SIZE = 0x4; /* 0x4 big, align 2 */

        public ushort PlayingAudioMusicID { get; set; } // @0x0 size 0x2, align 2
        public byte _749b78c2 { get; set; } // @0x2 size 0x1, align 1
    }
}

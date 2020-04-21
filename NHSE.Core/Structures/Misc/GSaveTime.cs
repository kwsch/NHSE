using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 1)]
    public struct GSaveTime
    {
        public const int SIZE = 0x08;
        [field: FieldOffset(0x00)] public ushort Year { get; set; }
        [field: FieldOffset(0x02)] public byte Month { get; set; }
        [field: FieldOffset(0x03)] public byte Day { get; set; }
        [field: FieldOffset(0x04)] public byte Hour { get; set; }
        [field: FieldOffset(0x05)] public byte Minute { get; set; }
        [field: FieldOffset(0x06)] public byte Second { get; set; }

        // 0x07 unused, alignment

        public string TimeStamp => $"{Year:0000}-{Month:00}-{Day:00} {Hour:00}:{Minute:00}:{Second:00}";

        public override int GetHashCode() => TimeStamp.GetHashCode();
        public override bool Equals(object obj) => obj is GSaveTime i && i.Equals(this);
        public bool Equals(GSaveTime obj) => TimeStamp == obj.TimeStamp;
        public static bool operator ==(GSaveTime left, GSaveTime right) => left.Equals(right);
        public static bool operator !=(GSaveTime left, GSaveTime right) => !(left == right);
    }
}

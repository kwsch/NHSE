using System;
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

        private GSaveDate(int year, int month, int day)
        {
            Year = (ushort) year;
            Month = (byte) month;
            Day = (byte) day;
        }

        public bool IsEmpty => Year == 0 && Month == 0 && Day == 0;

        public static implicit operator GSaveDate(DateTime dt) => dt == DateTime.MinValue ? new GSaveDate() : new GSaveDate(dt.Year, dt.Month, dt.Day);
        public static implicit operator DateTime(GSaveDate dt) => dt.IsEmpty ? DateTime.MinValue : new DateTime(dt.Year, dt.Month, dt.Day);
    }
}

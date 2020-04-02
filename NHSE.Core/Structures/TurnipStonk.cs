using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public class TurnipStonk
    {
        public const int SIZE = sizeof(uint) * (1 + (2 * 7));

        public uint BuyPrice { get; set; }

        public uint SellSunday1 { get; set; }
        public uint SellSunday2 { get; set; }

        public uint SellMonday1 { get; set; }
        public uint SellMonday2 { get; set; }

        public uint SellTuesday1 { get; set; }
        public uint SellTuesday2 { get; set; }

        public uint SellWednesday1 { get; set; }
        public uint SellWednesday2 { get; set; }

        public uint SellThursday1 { get; set; }
        public uint SellThursday2 { get; set; }

        public uint SellFriday1 { get; set; }
        public uint SellFriday2 { get; set; }

        public uint SellSaturday1 { get; set; }
        public uint SellSaturday2 { get; set; }
    }
}

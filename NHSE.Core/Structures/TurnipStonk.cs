using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public class TurnipStonk
    {
        public const int SIZE = sizeof(uint) * (1 + (2 * 7));

        public uint BuyPrice { get; set; }

        public uint SellSundayAM { get; set; }
        public uint SellSundayPM { get; set; }

        public uint SellMondayAM { get; set; }
        public uint SellMondayPM { get; set; }

        public uint SellTuesdayAM { get; set; }
        public uint SellTuesdayPM { get; set; }

        public uint SellWednesdayAM { get; set; }
        public uint SellWednesdayPM { get; set; }

        public uint SellThursdayAM { get; set; }
        public uint SellThursdayPM { get; set; }

        public uint SellFridayAM { get; set; }
        public uint SellFridayPM { get; set; }

        public uint SellSaturdayAM { get; set; }
        public uint SellSaturdayPM { get; set; }
    }
}

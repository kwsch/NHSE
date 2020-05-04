using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential, Size = SIZE)]
    public class TurnipStonk // GSaveShopKabu
    {
        public const int SIZE = 0x44;

        private const string Buy = nameof(Buy);
        private const string Sell = nameof(Sell);
        private const string Info = nameof(Info);

        [Category(Buy)] public uint BuyPrice { get; set; } // KaburibaKabuka

        [Category(Sell)] public uint SellSundayAM { get; set; }
        [Category(Sell)] public uint SellSundayPM { get; set; }

        [Category(Sell)] public uint SellMondayAM { get; set; }
        [Category(Sell)] public uint SellMondayPM { get; set; }

        [Category(Sell)] public uint SellTuesdayAM { get; set; }
        [Category(Sell)] public uint SellTuesdayPM { get; set; }

        [Category(Sell)] public uint SellWednesdayAM { get; set; }
        [Category(Sell)] public uint SellWednesdayPM { get; set; }

        [Category(Sell)] public uint SellThursdayAM { get; set; }
        [Category(Sell)] public uint SellThursdayPM { get; set; }

        [Category(Sell)] public uint SellFridayAM { get; set; }
        [Category(Sell)] public uint SellFridayPM { get; set; }

        [Category(Sell)] public uint SellSaturdayAM { get; set; }
        [Category(Sell)] public uint SellSaturdayPM { get; set; }

        [Category(Info)] public TurnipPattern Pattern { get; set; } // KabukaPattern
        [Category(Info)] public uint FeverStart { get; set; }
    }

    public enum TurnipPattern : uint
    {
        Fluctuating,
        LargeSpike,
        Decreasing,
        SmallSpike,
    }
}

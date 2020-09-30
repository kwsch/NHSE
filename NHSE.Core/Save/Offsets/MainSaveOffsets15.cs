namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="MainSaveOffsets"/>
    /// </summary>
    public class MainSaveOffsets15 : MainSaveOffsets
    {
        #region GSaveLand
        public const int GSaveLandStart = 0x110;
        public override int Animal => GSaveLandStart + 0x10;

        public override int LandMyDesign => GSaveLandStart + 0x1e2600;
        public override int PatternsPRO => LandMyDesign + (PatternCount * DesignPattern.SIZE);
        public override int PatternFlag => PatternsPRO + (PatternCount * DesignPatternPRO.SIZE);
        public override int PatternTailor => PatternFlag + DesignPattern.SIZE;

        public const int GSaveWeather = GSaveLandStart + 0x1e23B0;
        public override int WeatherArea => GSaveWeather + 0x14; // Hemisphere
        public override int WeatherRandSeed => GSaveWeather + 0x18;

        public override int EventFlagLand => GSaveLandStart + 0x20c40c;

        // GSaveMainField
        public const int GSaveMainFieldStart = GSaveLandStart + 0x20cc0c;
        public override int FieldItem => GSaveMainFieldStart + 0x00000;
        public override int LandMakingMap => GSaveMainFieldStart + 0xAAA00;
        public override int MainFieldStructure => GSaveMainFieldStart + 0xCF600;
        public override int OutsideField => GSaveMainFieldStart + 0xCF998;
        public override int MyDesignMap => GSaveMainFieldStart + 0xCFA34;

        public override int PlayerHouseList => GSaveLandStart + 0x2e7638;
        public override int NpcHouseList => GSaveLandStart + 0x419638;

        public const int GSaveShop = GSaveLandStart + 0x41a880;
        public override int ShopKabu => GSaveShop + 0x2b10; // part of shop
        public override int Museum => GSaveLandStart + 0x41d904;
        public override int Visitor => GSaveLandStart + 0x420d08;
        public override int SaveFg => GSaveLandStart + 0x420f38;
        public override int BulletinBoard => GSaveLandStart + 0x421880;
        public override int AirportThemeColor => GSaveLandStart + 0x502488;
        #endregion

        #region GSaveLandOther
        public const int GSaveLandOtherStart = 0x5061e0;

        public override int LostItemBox => GSaveLandOtherStart + 0x6159f0;
        public override int LastSavedTime => GSaveLandOtherStart + 0x61a288;
        #endregion
    }
}

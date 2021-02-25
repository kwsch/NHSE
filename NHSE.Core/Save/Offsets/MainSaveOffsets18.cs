namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="MainSaveOffsets"/>
    /// </summary>
    /// <remarks>Same as <see cref="MainSaveOffsets17"/></remarks>.
    public class MainSaveOffsets18 : MainSaveOffsets
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

        public override int EventFlagLand => GSaveLandStart + 0x20a408;

        // GSaveMainField
        public const int GSaveMainFieldStart = GSaveLandStart + 0x20ac08;
        public override int FieldItem => GSaveMainFieldStart + 0x00000;
        public override int LandMakingMap => GSaveMainFieldStart + 0xAAA00;
        public override int MainFieldStructure => GSaveMainFieldStart + 0xCF600;
        public override int OutsideField => GSaveMainFieldStart + 0xCF998;
        public override int MyDesignMap => GSaveMainFieldStart + 0xCFA34;

        public override int PlayerHouseList => GSaveLandStart + 0x2e5634;
        public override int NpcHouseList => GSaveLandStart + 0x417634;

        public const int GSaveShop = GSaveLandStart + 0x41887c;
        public override int ShopKabu => GSaveShop + 0x2cb0; // part of shop; tailor increased size
        public override int Museum => GSaveLandStart + 0x41bba0;
        public override int Visitor => GSaveLandStart + 0x41efa4;
        public override int SaveFg => GSaveLandStart + 0x41f1d4;
        public override int BulletinBoard => GSaveLandStart + 0x41fb18;
        public override int AirportThemeColor => GSaveLandStart + 0x500720;
        #endregion

        #region GSaveLandOther
        public const int GSaveLandOtherStart = 0x504470;

        public override int LostItemBox => GSaveLandOtherStart + 0x340680;
        public override int LastSavedTime => GSaveLandOtherStart + 0x344f18;
        #endregion

        public override int VillagerSize => Villager2.SIZE;
        public override IVillager ReadVillager(byte[] data) => new Villager2(data);
    }
}

namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="MainSaveOffsets"/>
    /// </summary>
    public class MainSaveOffsets110 : MainSaveOffsets
    {
        public override int PatternCount => PatternCount2;

        #region GSaveLand
        public const int GSaveLandStart = 0x110;
        public override int Animal => GSaveLandStart + 0x10;

        public override int LandMyDesign => GSaveLandStart + 0x1e2610;
        public override int PatternsPRO => LandMyDesign + (PatternCount2 * DesignPattern.SIZE);
        public override int PatternFlag => PatternsPRO + (PatternCount2 * DesignPatternPRO.SIZE);
        public override int PatternTailor => PatternFlag + DesignPattern.SIZE;

        public const int GSaveWeather = GSaveLandStart + 0x1e23c0;
        public override int WeatherArea => GSaveWeather + 0x14; // Hemisphere
        public override int WeatherRandSeed => GSaveWeather + 0x18;

        public override int EventFlagLand => GSaveLandStart + 0x22d9b8;

        // GSaveMainField
        public const int GSaveMainFieldStart = GSaveLandStart + 0x22e1b8;
        public override int FieldItem => GSaveMainFieldStart + 0x00000;
        public override int LandMakingMap => GSaveMainFieldStart + 0xAAA00;
        public override int MainFieldStructure => GSaveMainFieldStart + 0xCF600;
        public override int OutsideField => GSaveMainFieldStart + 0xCF998;
        public override int MyDesignMap => GSaveMainFieldStart + 0xCFA34;

        public override int PlayerHouseList => GSaveLandStart + 0x308be4;
        public override int NpcHouseList => GSaveLandStart + 0x43abe4;

        public const int GSaveShop = GSaveLandStart + 0x43be2c;
        public override int ShopKabu => GSaveShop + 0x2d40; // part of shop; tailor & zakka increased size
        public override int Museum => GSaveLandStart + 0x43f1e0;
        public override int Visitor => GSaveLandStart + 0x4425e4;
        public override int SaveFg => GSaveLandStart + 0x442814;
        public override int BulletinBoard => GSaveLandStart + 0x443158;
        public override int AirportThemeColor => GSaveLandStart + 0x523d60;
        #endregion

        #region GSaveLandOther
        public const int GSaveLandOtherStart = 0x527ab0;

        public override int LostItemBox => GSaveLandOtherStart + 0x3408c0;
        public override int LastSavedTime => GSaveLandOtherStart + 0x345220;
        #endregion

        public override int VillagerSize => Villager2.SIZE;
        public override IVillager ReadVillager(byte[] data) => new Villager2(data);
    }
}

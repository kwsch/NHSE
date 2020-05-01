namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="MainSaveOffsets"/>
    /// </summary>
    public class MainSaveOffsets11 : MainSaveOffsets
    {
        #region GSaveLand
        public const int GSaveLandStart = 0x110;
        public override int Animal => GSaveLandStart + 0x10;

        public override int LandMyDesign => GSaveLandStart + 0x1D7200;
        public override int PatternsPRO => LandMyDesign + (PatternCount * DesignPattern.SIZE);
        public override int PatternFlag => PatternsPRO + (PatternCount * DesignPatternPRO.SIZE);

        public override int EventFlagLand => GSaveLandStart + 0x20100C;

        // GSaveMainField
        public const int GSaveMainFieldStart = GSaveLandStart + 0x20180C;
        public override int FieldItem => GSaveMainFieldStart + 0x00000;
        public override int LandMakingMap => GSaveMainFieldStart + 0xAAA00;
        public override int MainFieldStructure => GSaveMainFieldStart + 0xCF600;
        public override int OutsideField => GSaveMainFieldStart + 0xCF998;

        public override int PlayerHouseList => GSaveLandStart + 0x2DC238;
        public override int NpcHouseList => GSaveLandStart + 0x40E238;
        public override int BulletinBoard => GSaveLandStart + 0x416190;

        public const int GSaveShop = GSaveLandStart + 0x40F480;
        public override int ShopKabu => GSaveShop + 0x2AD0; // part of shop
        #endregion

        #region GSaveLandOther
        public const int GSaveLandOtherStart = 0x4FAA80;

        public override int LostItemBox => GSaveLandOtherStart + 0x5C33F0;
        public override int LastSavedTime => GSaveLandOtherStart + 0x5C7D48;
        #endregion
    }
}

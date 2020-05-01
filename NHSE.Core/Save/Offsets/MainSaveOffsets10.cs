namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="MainSaveOffsets"/>
    /// </summary>
    public class MainSaveOffsets10 : MainSaveOffsets
    {
        #region GSaveLand
        public const int GSaveLandStart = 0x108;
        public override int Animal => GSaveLandStart + 0x08;

        public override int LandMyDesign => GSaveLandStart + 0x1D71E8;
        public override int PatternsPRO => LandMyDesign + (PatternCount * DesignPattern.SIZE);
        public override int PatternFlag => PatternsPRO + (PatternCount * DesignPatternPRO.SIZE);

        public override int EventFlagLand => GSaveLandStart + 0x200FF4;

        // GSaveMainField
        public const int GSaveMainFieldStart = GSaveLandStart + 0x2017F4;
        public override int FieldItem => GSaveMainFieldStart + 0x00000;
        public override int LandMakingMap => GSaveMainFieldStart + 0xAAA00;
        public override int MainFieldStructure => GSaveMainFieldStart + 0xCF600;
        public override int OutsideField => GSaveMainFieldStart + 0xCF998;

        public override int PlayerHouseList => GSaveLandStart + 0x2DBAA0;
        public override int NpcHouseList => GSaveLandStart + 0x40DAA0;
        public override int BulletinBoard => GSaveLandStart + 0x4159F8;

        public const int GSaveShop = GSaveLandStart + 0x40ECE8;
        public override int ShopKabu => GSaveShop + 0x2AD0; // part of shop
        #endregion

        #region GSaveLandOther
        public const int GSaveLandOtherStart = 0x4FA1E0;

        public override int LostItemBox => GSaveLandOtherStart + 0x5C1E20;
        public override int LastSavedTime => GSaveLandOtherStart + 0x5C6748;
        #endregion
    }
}
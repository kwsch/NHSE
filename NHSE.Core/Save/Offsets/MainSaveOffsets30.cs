using System;

namespace NHSE.Core;

/// <summary>
/// <inheritdoc cref="MainSaveOffsets"/>
/// </summary>
/// <remarks>Same as <see cref="MainSaveOffsets110"/></remarks>
public class MainSaveOffsets30 : MainSaveOffsets
{
    public override int PatternCount => PatternCount2;

    #region GSaveLand
    public const int GSaveLandStart = 0x110;
    public override int Animal => GSaveLandStart + 0x10;

    public override int LandMyDesign => GSaveLandStart + 0x1e3848;
    public override int PatternsPRO => LandMyDesign + (PatternCount2 * DesignPattern.SIZE);
    public override int PatternFlag => PatternsPRO + (PatternCount2 * DesignPatternPRO.SIZE);
    public override int PatternTailor => PatternFlag + DesignPattern.SIZE;

    public override int PatternsEditFlagStart => GSaveLandStart + 0x8BE150; // x100, HasPlayerEdited?
    public override int PatternsProEditFlagStart => PatternsEditFlagStart + 0x64; // x100, HasPlayerEdited?

    public const int GSaveWeather = GSaveLandStart + 0x1e35f0;
    public override int WeatherArea => GSaveWeather + 0x14; // Hemisphere
    public override int WeatherRandSeed => GSaveWeather + 0x18;

    public override int EventFlagLand => GSaveLandStart + 0x22ebf0;

    // GSaveMainField
    public const int GSaveMainFieldStart = GSaveLandStart + 0x22f3f0;
    public override int FieldItem => GSaveMainFieldStart + 0x00000;
    public override int LandMakingMap => GSaveMainFieldStart + 0xAAA00;
    public override int MainFieldStructure => GSaveMainFieldStart + 0xCF600;
    public override int OutsideField => GSaveMainFieldStart + 0xCF998;
    public override int MyDesignMap => GSaveMainFieldStart + 0xCFA34;

    public override int PlayerHouseList => GSaveLandStart + 0x30a6bc;
    public override int NpcHouseList => GSaveLandStart + 0x44f7fc;

    public const int GSaveShop = GSaveLandStart + 0x45b50c;
    public override int ShopKabu => GSaveShop + 0x2d40; // part of shop; tailor & zakka increased size
    public override int Museum => GSaveLandStart + 0x45ec44;
    public override int Visitor => GSaveLandStart + 0x462048;
    public override int SaveFg => GSaveLandStart + 0x462278;
    public override int BulletinBoard => GSaveLandStart + 0x462bc0;
    public override int AirportThemeColor => GSaveLandStart + 0x5437c8;
    #endregion

    #region GSaveLandOther
    public const int GSaveLandOtherStart = 0x547520;

    public override int LostItemBox => GSaveLandOtherStart + 0x3726c0;
    public override int LastSavedTime => GSaveLandOtherStart + 0x377020;
    #endregion

    public override int VillagerSize => Villager2.SIZE;
    public override IVillager ReadVillager(Memory<byte> data) => new Villager2(data);

    public override int VillagerHouseSize => VillagerHouse2.SIZE;
    public override IVillagerHouse ReadVillagerHouse(Memory<byte> data) => new VillagerHouse2(data);

    public override int PlayerHouseSize => PlayerHouse2.SIZE;
    public override IPlayerHouse ReadPlayerHouse(Memory<byte> data) => new PlayerHouse2(data);
    public override int PlayerRoomSize => PlayerRoom2.SIZE;
    public override IPlayerRoom ReadPlayerRoom(Memory<byte> data) => new PlayerRoom2(data);
}
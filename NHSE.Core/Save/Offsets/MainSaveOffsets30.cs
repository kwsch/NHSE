using System;

namespace NHSE.Core;

/// <summary>
/// <inheritdoc cref="MainSaveOffsets"/>
/// </summary>
public class MainSaveOffsets30 : MainSaveOffsets
{
    public override int PatternCount => PatternCount2;

    #region GSaveLand
    public const int GSaveLandStart = 0x110;

    // GSaveNpc @ 0x000
    public override int Animal => GSaveLandStart + 0x10;

    // GSaveWeather
    public const int GSaveWeather = GSaveLandStart + 0x1e35f0;
    public override int WeatherArea => GSaveWeather + 0x14; // Hemisphere
    public override int WeatherRandSeed => GSaveWeather + 0x18;

    // GSaveLandMyDesign
    public override int LandMyDesign => GSaveLandStart + 0x1e3848;
    public override int PatternsPRO => LandMyDesign + (PatternCount2 * DesignPattern.SIZE);
    public override int PatternFlag => PatternsPRO + (PatternCount2 * DesignPatternPRO.SIZE);
    public override int PatternTailor => PatternFlag + DesignPattern.SIZE;

    // GSaveEventFlagLand
    public override int EventFlagLand => GSaveLandStart + 0x22ebf0;

    // GSaveMainField
    public const int GSaveMainFieldStart = GSaveLandStart + 0x22f3f0;

    // Map size increased to accommodate the Hotel, by adding 2 columns of acres!
    public override byte FieldItemAcreWidth => 9; // from 7 to 9
    // does this actually impact anything? We'll eventually find out if so; I hope it is just 2 columns of unused.

    // Layer0: 54000 => 6C000
    // Layer1: 54000 => 6C000
    // ItemSwitch0 1500 => 1B00
    // ItemSwitch1 1500 => 1B00
    // MainField 398 => 3AC
    public override int FieldItem => GSaveMainFieldStart + 0x00000;
    public override int LandMakingMap => GSaveMainFieldStart + 0xdb600; // CHANGED*** all following are shifted.
    public override int MainFieldStructure => GSaveMainFieldStart + 0x100200;
    public override int OutsideField => GSaveMainFieldStart + 0x1005ac;
    public override int MyDesignMap => GSaveMainFieldStart + 0x100648;

    // GSavePlayerHouseList
    public override int PlayerHouseList => GSaveLandStart + 0x33cad0;

    // GSaveNpcHouseList
    public override int NpcHouseList => GSaveLandStart + 0x481c10;

    // GSaveShop
    public const int GSaveShop = GSaveLandStart + 0x48d920;
    public override int ShopKabu => GSaveShop + 0x2d40; // part of shop; tailor & zakka increased size

    // GSaveMuseum
    public override int Museum => GSaveLandStart + 0x491110;
    // GSaveVisitorNpc
    public override int Visitor => GSaveLandStart + 0x494514;
    // GSaveSaveFg
    public override int SaveFg => GSaveLandStart + 0x494760;
    // GSaveBulletinBoard
    public override int BulletinBoard => GSaveLandStart + 0x4950a8;
    public override int AirportThemeColor => GSaveLandStart + 0x575cb0;
    #endregion

    #region GSaveLandOther
    public const int GSaveLandOtherStart = 0x5b3d50;

    public const int GSaveMyDesignHolderList = GSaveLandOtherStart + 0x3c9640;
    public override int PatternsEditFlagStart => GSaveMyDesignHolderList; // x100, HasPlayerEdited? NormalHolders
    public override int PatternsProEditFlagStart => PatternsEditFlagStart + 0x64; // x100, HasPlayerEdited? // ProHolders

    public override int LostItemBox => GSaveLandOtherStart + 0x3c4fc0;
    public override int LastSavedTime => GSaveLandOtherStart + 0x3c9920;
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
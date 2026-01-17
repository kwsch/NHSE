using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// main.dat
/// </summary>
public sealed class MainSave : EncryptedFilePair
{
    public readonly MainSaveOffsets Offsets;
    public MainSave(ISaveFileProvider provider) : base(provider, "main") => Offsets = MainSaveOffsets.GetOffsets(Info);

    public Hemisphere Hemisphere { get => (Hemisphere)Data[Offsets.WeatherArea]; set => Data[Offsets.WeatherArea] = (byte)value; }
    public AirportColor AirportThemeColor { get => (AirportColor)Data[Offsets.AirportThemeColor]; set => Data[Offsets.AirportThemeColor] = (byte)value; }

    public uint WeatherSeed
    {
        get => ReadUInt32LittleEndian(Data[Offsets.WeatherRandSeed..]);
        set => WriteUInt32LittleEndian(Data[Offsets.WeatherRandSeed..], value);
    }

    public IVillager GetVillager(int index) => Offsets.ReadVillager(Data, index);
    public void SetVillager(IVillager value, int index) => Offsets.WriteVillager(value, Data, index);

    public IVillagerHouse GetVillagerHouse(int index) => Offsets.ReadVillagerHouse(Data, index);
    public void SetVillagerHouse(IVillagerHouse value, int index) => Offsets.WriteVillagerHouse(value, Data, index);

    public IVillager[] GetVillagers()
    {
        var villagers = new IVillager[MainSaveOffsets.VillagerCount];
        for (int i = 0; i < villagers.Length; i++)
            villagers[i] = GetVillager(i);
        return villagers;
    }

    public void SetVillagers(IReadOnlyList<IVillager> villagers)
    {
        for (int i = 0; i < villagers.Count; i++)
            SetVillager(villagers[i], i);
    }

    public IVillagerHouse[] GetVillagerHouses()
    {
        var villagers = new IVillagerHouse[MainSaveOffsets.VillagerCount];
        for (int i = 0; i < villagers.Length; i++)
            villagers[i] = GetVillagerHouse(i);
        return villagers;
    }

    public void SetVillagerHouses(IReadOnlyList<IVillagerHouse> villagers)
    {
        for (int i = 0; i < villagers.Count; i++)
            SetVillagerHouse(villagers[i], i);
    }

    public DesignPattern GetDesign(int index) => Offsets.ReadPattern(Data, index);
    public void SetDesign(DesignPattern value, int index, Span<byte> playerID, Span<byte> townID) => Offsets.WritePattern(value, Data, index, playerID, townID);
    public DesignPatternPRO GetDesignPRO(int index) => Offsets.ReadPatternPRO(Data, index);
    public void SetDesignPRO(DesignPatternPRO value, int index, Span<byte> playerID, Span<byte> townID) => Offsets.WritePatternPRO(value, Data, index, playerID, townID);

    public IReadOnlyList<Item> RecycleBin
    {
        get => Item.GetArray(Data.Slice(Offsets.LostItemBox, MainSaveOffsets.RecycleBinCount * Item.SIZE));
        set => Item.SetArray(value).CopyTo(Data[Offsets.LostItemBox..]);
    }

    public IReadOnlyList<Building> Buildings
    {
        get => Building.GetArray(Data.Slice(Offsets.MainFieldStructure, MainSaveOffsets.BuildingCount * Building.SIZE));
        set => Building.SetArray(value).CopyTo(Data[Offsets.MainFieldStructure..]);
    }

    public IPlayerHouse GetPlayerHouse(int index) => Offsets.ReadPlayerHouse(Data, index);
    public void SetPlayerHouse(IPlayerHouse value, int index) => Offsets.WritePlayerHouse(value, Data, index);

    public IPlayerHouse[] GetPlayerHouses()
    {
        var players = new IPlayerHouse[MainSaveOffsets.PlayerCount];
        for (int i = 0; i < players.Length; i++)
            players[i] = GetPlayerHouse(i);
        return players;
    }

    public void SetPlayerHouses(IReadOnlyList<IPlayerHouse> houses)
    {
        for (int i = 0; i < houses.Count; i++)
            SetPlayerHouse(houses[i], i);
    }

    public DesignPattern[] GetDesigns()
    {
        var result = new DesignPattern[Offsets.PatternCount];
        for (int i = 0; i <result.Length; i++)
            result[i] = GetDesign(i);
        return result;
    }

    public void SetDesigns(IReadOnlyList<DesignPattern> value, Span<byte> playerID, Span<byte> townID)
    {
        var count = Math.Min(Offsets.PatternCount, value.Count);
        for (int i = 0; i < count; i++)
            SetDesign(value[i], i, playerID, townID);
    }

    public DesignPatternPRO[] GetDesignsPRO()
    {
        var result = new DesignPatternPRO[Offsets.PatternCount];
        for (int i = 0; i < result.Length; i++)
            result[i] = GetDesignPRO(i);
        return result;
    }

    public void SetDesignsPRO(IReadOnlyList<DesignPatternPRO> value, Span<byte> playerID, Span<byte> townID)
    {
        var count = Math.Min(Offsets.PatternCount, value.Count);
        for (int i = 0; i < count; i++)
            SetDesignPRO(value[i], i, playerID, townID);
    }

    public DesignPattern FlagMyDesign
    {
        get => MainSaveOffsets.ReadPatternAtOffset(Data, Offsets.PatternFlag);
        set => value.Data.CopyTo(Data[Offsets.PatternFlag..]);
    }

    public DesignPatternPRO[] GetDesignsTailor()
    {
        var result = new DesignPatternPRO[MainSaveOffsets.PatternTailorCount];
        for (int i = 0; i < result.Length; i++)
            result[i] = MainSaveOffsets.ReadPatternPROAtOffset(Data, Offsets.PatternTailor + (i * DesignPatternPRO.SIZE));
        return result;
    }

    public void SetDesignsTailor(IReadOnlyList<DesignPatternPRO> value)
    {
        var count = Math.Min(Offsets.PatternCount, value.Count);
        for (int i = 0; i < count; i++)
            value[i].Data.CopyTo(Data[(Offsets.PatternTailor + (i * DesignPatternPRO.SIZE))..]);
    }

    private const int EventFlagsSaveCount = 0x400;

    public Span<short> EventFlagLand => MemoryMarshal.Cast<byte, short>(Data.Slice(Offsets.EventFlagLand, sizeof(short) * EventFlagsSaveCount));

    public TurnipStonk Turnips
    {
        get => Data.Slice(Offsets.ShopKabu, TurnipStonk.SIZE).ToArray().ToClass<TurnipStonk>();
        set => value.ToBytesClass().CopyTo(Data[Offsets.ShopKabu..]);
    }

    public Museum Museum
    {
        get => new(Data.Slice(Offsets.Museum, Museum.SIZE).ToArray());
        set => value.Data.CopyTo(Data[Offsets.Museum..]);
    }

    // Acre Layout/Selection of which baselayer is selected for an acre.
    private const int AcreWidth = 7 + (2 * 1); // 1 on each side cannot be traversed
    private const int AcreHeight = 6 + (2 * 1); // 1 on each side cannot be traversed
    private const int AcreMax = AcreWidth * AcreHeight;
    private const int AcreSizeAll = AcreMax * 2;

    public ushort GetAcre(int index)
    {
        if ((uint)index > AcreMax)
            throw new ArgumentOutOfRangeException(nameof(index));
        return ReadUInt16LittleEndian(Data[(Offsets.OutsideField + (index * 2))..]);
    }

    public void SetAcre(int index, ushort value)
    {
        if ((uint)index > AcreMax)
            throw new ArgumentOutOfRangeException(nameof(index));
        WriteUInt16LittleEndian(Data[(Offsets.OutsideField + (index * 2))..], value);
    }

    public byte[] GetAcreBytes() => Data.Slice(Offsets.OutsideField, AcreSizeAll).ToArray();

    public void SetAcreBytes(ReadOnlySpan<byte> data)
    {
        if (data.Length != AcreSizeAll)
            throw new ArgumentOutOfRangeException(nameof(data.Length));
        data.CopyTo(Data[Offsets.OutsideField..]);
    }

    public byte FieldItemAcreWidth => Offsets.FieldItemAcreWidth; // 3.0.0 updated from 7 => 9
    public byte FieldItemAcreHeight => 6; // always 6
    private int FieldItemAcreCount => FieldItemAcreWidth * FieldItemAcreHeight;

    private const int TotalTerrainTileCount = TerrainLayer.TilesPerAcreDim * TerrainLayer.TilesPerAcreDim * (7 * 6);
    private int TotalFieldItemTileCount => FieldItemLayer.TilesPerAcreDim * FieldItemLayer.TilesPerAcreDim * FieldItemAcreCount;

    public TerrainTile[] GetTerrainTiles() => TerrainTile.GetArray(Data.Slice(Offsets.LandMakingMap, TotalTerrainTileCount * TerrainTile.SIZE));
    public void SetTerrainTiles(IReadOnlyList<TerrainTile> array) => TerrainTile.SetArray(array).CopyTo(Data[Offsets.LandMakingMap..]);

    public const ushort MapDesignNone = 0xF800;

    public Memory<byte> MapDesignTileData => Raw.Slice(Offsets.MyDesignMap, 112 * 96 * sizeof(ushort));
    public ushort[] GetMapDesignTiles() => MemoryMarshal.Cast<byte, ushort>(MapDesignTileData.Span).ToArray();
    public void SetMapDesignTiles(ReadOnlySpan<ushort> value) => MemoryMarshal.Cast<ushort, byte>(value).CopyTo(MapDesignTileData.Span);

    public void ClearDesignTiles()
    {
        var tiles = GetMapDesignTiles();
        tiles.AsSpan().Fill(MapDesignNone);
        SetMapDesignTiles(tiles);
    }

    private int FieldItemLayerSize => TotalFieldItemTileCount * Item.SIZE;
    private int FieldItemFlagSize => TotalFieldItemTileCount / sizeof(byte); // bitflags

    private int FieldItemLayer1 => Offsets.FieldItem;
    private int FieldItemLayer2 => Offsets.FieldItem + FieldItemLayerSize;
    public int FieldItemFlag1 => Offsets.FieldItem + (FieldItemLayerSize * 2);
    public int FieldItemFlag2 => Offsets.FieldItem + (FieldItemLayerSize * 2) + FieldItemFlagSize;

    public Item[] GetFieldItemLayer1() => Item.GetArray(Data.Slice(FieldItemLayer1, FieldItemLayerSize));
    public void SetFieldItemLayer1(IReadOnlyList<Item> array) => Item.SetArray(array).CopyTo(Data[FieldItemLayer1..]);

    public Item[] GetFieldItemLayer2() => Item.GetArray(Data.Slice(FieldItemLayer2, FieldItemLayerSize));
    public void SetFieldItemLayer2(IReadOnlyList<Item> array) => Item.SetArray(array).CopyTo(Data[FieldItemLayer2..]);

    public ushort OutsideFieldTemplateUniqueId
    {
        get => ReadUInt16LittleEndian(Data[(Offsets.OutsideField + AcreSizeAll)..]);
        set => WriteUInt16LittleEndian(Data[(Offsets.OutsideField + AcreSizeAll)..], value);
    }

    public ushort MainFieldParamUniqueID
    {
        get => ReadUInt16LittleEndian(Data[(Offsets.OutsideField + AcreSizeAll + 2)..]);
        set => WriteUInt16LittleEndian(Data[(Offsets.OutsideField + AcreSizeAll + 2)..], value);
    }

    public uint EventPlazaLeftUpX
    {
        get => ReadUInt32LittleEndian(Data[(Offsets.OutsideField + AcreSizeAll + 4)..]);
        set => WriteUInt32LittleEndian(Data[(Offsets.OutsideField + AcreSizeAll + 4)..], value);
    }

    public uint EventPlazaLeftUpZ
    {
        get => ReadUInt32LittleEndian(Data[(Offsets.OutsideField + AcreSizeAll + 8)..]);
        set => WriteUInt32LittleEndian(Data[(Offsets.OutsideField + AcreSizeAll + 8)..], value);
    }

    public GSaveVisitorNpc Visitor
    {
        get => Data.Slice(Offsets.Visitor, GSaveVisitorNpc.SIZE).ToArray().ToClass<GSaveVisitorNpc>();
        set => value.ToBytesClass().CopyTo(Data[Offsets.Visitor..]);
    }

    public GSaveFg SaveFg
    {
        get => Data.Slice(Offsets.SaveFg, GSaveFg.SIZE).ToArray().ToClass<GSaveFg>();
        set => value.ToBytesClass().CopyTo(Data[Offsets.SaveFg..]);
    }

    public GSaveTime LastSaved => Data.Slice(Offsets.LastSavedTime, GSaveTime.SIZE).ToStructure<GSaveTime>();

    public GSaveBulletinBoard Bulletin
    {
        get => Data.Slice(Offsets.BulletinBoard, GSaveBulletinBoard.SIZE).ToStructure<GSaveBulletinBoard>();
        set => value.ToBytes().CopyTo(Data[Offsets.BulletinBoard..]);
    }
}
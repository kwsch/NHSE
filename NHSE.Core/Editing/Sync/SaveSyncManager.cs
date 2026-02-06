using System.Collections.Generic;
using System.Linq;

namespace NHSE.Core;

/// <summary>
/// Manages synchronization of data between two save files.
/// </summary>
public sealed class SaveSyncManager
{
    private readonly HorizonSave _target;
    private readonly HorizonSave _source;

    public SaveSyncManager(HorizonSave target, HorizonSave source)
    {
        _target = target;
        _source = source;
    }

    /// <summary>
    /// Gets the target save file being modified.
    /// </summary>
    public HorizonSave Target => _target;

    /// <summary>
    /// Gets the source save file to sync from.
    /// </summary>
    public HorizonSave Source => _source;

    /// <summary>
    /// Checks if the source and target saves are compatible for syncing.
    /// </summary>
    public bool IsCompatible => _target.Main.Offsets.GetType() == _source.Main.Offsets.GetType();

    /// <summary>
    /// Gets a preview of all syncable data from the source save.
    /// </summary>
    public SaveSyncPreviewCollection GetPreview()
    {
        var previews = new List<SaveSyncPreview>();
        var isCompatible = IsCompatible;

        previews.Add(GetVillagerPreview());
        previews.Add(GetVillagerHousesPreview());
        previews.Add(GetBuildingsPreview());
        previews.Add(GetPlayerHousesPreview());
        previews.Add(GetDesignPatternsPreview());
        previews.Add(GetDesignPatternsPROPreview());
        previews.Add(GetFieldItemsPreview());
        previews.Add(GetTerrainPreview());
        previews.Add(GetMuseumPreview());
        previews.Add(GetTurnipPreview());
        previews.Add(GetWeatherSeedPreview());
        previews.Add(GetRecycleBinPreview());
        previews.Add(GetAcresPreview());

        var sourceName = _source.Players.Count > 0 ? _source.Players[0].Personal.TownName : "Unknown";
        var sourceVersion = _source.Main.Offsets.GetType().Name;

        return new SaveSyncPreviewCollection
        {
            Previews = previews,
            IsCompatible = isCompatible,
            CompatibilityMessage = isCompatible ? null : "Save versions are different. Some data may not sync correctly.",
            SourceSaveName = sourceName,
            SourceSaveVersion = sourceVersion,
        };
    }

    /// <summary>
    /// Syncs the specified categories from source to target.
    /// </summary>
    public void Sync(SaveSyncCategory categories)
    {
        if (categories.HasFlag(SaveSyncCategory.Villagers))
            SyncVillagers();
        if (categories.HasFlag(SaveSyncCategory.VillagerHouses))
            SyncVillagerHouses();
        if (categories.HasFlag(SaveSyncCategory.Buildings))
            SyncBuildings();
        if (categories.HasFlag(SaveSyncCategory.PlayerHouses))
            SyncPlayerHouses();
        if (categories.HasFlag(SaveSyncCategory.DesignPatterns))
            SyncDesignPatterns();
        if (categories.HasFlag(SaveSyncCategory.DesignPatternsPRO))
            SyncDesignPatternsPRO();
        if (categories.HasFlag(SaveSyncCategory.FieldItems))
            SyncFieldItems();
        if (categories.HasFlag(SaveSyncCategory.Terrain))
            SyncTerrain();
        if (categories.HasFlag(SaveSyncCategory.Museum))
            SyncMuseum();
        if (categories.HasFlag(SaveSyncCategory.TurnipPrices))
            SyncTurnipPrices();
        if (categories.HasFlag(SaveSyncCategory.WeatherSeed))
            SyncWeatherSeed();
        if (categories.HasFlag(SaveSyncCategory.RecycleBin))
            SyncRecycleBin();
        if (categories.HasFlag(SaveSyncCategory.Acres))
            SyncAcres();
    }

    #region Preview Methods

    private SaveSyncPreview GetVillagerPreview()
    {
        var villagers = _source.Main.GetVillagers();
        var names = villagers.Select(v => v.InternalName).Where(n => !string.IsNullOrEmpty(n)).ToList();
        var summary = names.Count > 0 ? string.Join(", ", names.Take(5)) + (names.Count > 5 ? "..." : "") : "No villagers";

        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.Villagers,
            Summary = summary,
            ItemCount = names.Count,
            IsAvailable = true,
        };
    }

    private SaveSyncPreview GetVillagerHousesPreview()
    {
        var houses = _source.Main.GetVillagerHouses();
        // Check if house is occupied by checking NPC1 >= 0 (NPC1 is villager index, -1 means empty)
        var count = houses.Count(h => h.NPC1 >= 0);

        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.VillagerHouses,
            Summary = $"{count} villager houses",
            ItemCount = count,
            IsAvailable = true,
        };
    }

    private SaveSyncPreview GetBuildingsPreview()
    {
        var buildings = _source.Main.Buildings;
        var count = buildings.Count(b => b.BuildingType != BuildingType.None);
        var types = buildings.Where(b => b.BuildingType != BuildingType.None)
            .GroupBy(b => b.BuildingType)
            .Select(g => $"{g.Key}: {g.Count()}")
            .Take(3);

        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.Buildings,
            Summary = string.Join(", ", types),
            ItemCount = count,
            IsAvailable = true,
        };
    }

    private SaveSyncPreview GetPlayerHousesPreview()
    {
        var houses = _source.Main.GetPlayerHouses();
        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.PlayerHouses,
            Summary = $"{houses.Length} player houses",
            ItemCount = houses.Length,
            IsAvailable = true,
        };
    }

    private SaveSyncPreview GetDesignPatternsPreview()
    {
        var designs = _source.Main.GetDesigns();
        // Check if design is not empty by checking Hash != 0
        var count = designs.Count(d => d.Hash != 0);
        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.DesignPatterns,
            Summary = $"{count} design patterns",
            ItemCount = count,
            IsAvailable = true,
        };
    }

    private SaveSyncPreview GetDesignPatternsPROPreview()
    {
        var designs = _source.Main.GetDesignsPRO();
        // Check if design is not empty by checking Hash != 0
        var count = designs.Count(d => d.Hash != 0);
        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.DesignPatternsPRO,
            Summary = $"{count} PRO design patterns",
            ItemCount = count,
            IsAvailable = true,
        };
    }

    private SaveSyncPreview GetFieldItemsPreview()
    {
        var layer0 = _source.Main.GetFieldItemLayer0();
        var layer1 = _source.Main.GetFieldItemLayer1();
        var count0 = layer0.Count(i => !i.IsNone);
        var count1 = layer1.Count(i => !i.IsNone);
        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.FieldItems,
            Summary = $"Layer0: {count0}, Layer1: {count1} items",
            ItemCount = count0 + count1,
            IsAvailable = IsCompatible,
            ErrorMessage = IsCompatible ? null : "Field item layout differs between versions",
        };
    }

    private SaveSyncPreview GetTerrainPreview()
    {
        var terrain = _source.Main.GetTerrainTiles();
        // Check if terrain is modified (has non-base model or elevation > 0)
        var modified = terrain.Count(t => t.UnitModel != TerrainUnitModel.Base || t.Elevation > 0);
        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.Terrain,
            Summary = $"{terrain.Length} tiles ({modified} modified)",
            ItemCount = terrain.Length,
            IsAvailable = true,
        };
    }

    private SaveSyncPreview GetMuseumPreview()
    {
        var museum = _source.Main.Museum;
        var items = museum.GetItems();
        var donated = items.Count(i => !i.IsNone);
        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.Museum,
            Summary = $"{donated} donations",
            ItemCount = donated,
            IsAvailable = true,
        };
    }

    private SaveSyncPreview GetTurnipPreview()
    {
        var turnip = _source.Main.Turnips;
        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.TurnipPrices,
            Summary = $"Pattern: {turnip.Pattern}, Buy: {turnip.BuyPrice}",
            ItemCount = 1,
            IsAvailable = true,
        };
    }

    private SaveSyncPreview GetWeatherSeedPreview()
    {
        var seed = _source.Main.WeatherSeed;
        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.WeatherSeed,
            Summary = $"Seed: 0x{seed:X8}",
            ItemCount = 1,
            IsAvailable = true,
        };
    }

    private SaveSyncPreview GetRecycleBinPreview()
    {
        var items = _source.Main.RecycleBin;
        var count = items.Count(i => !i.IsNone);
        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.RecycleBin,
            Summary = $"{count} items in recycle bin",
            ItemCount = count,
            IsAvailable = true,
        };
    }

    private SaveSyncPreview GetAcresPreview()
    {
        var acres = _source.Main.GetAcreBytes();
        return new SaveSyncPreview
        {
            Category = SaveSyncCategory.Acres,
            Summary = $"{acres.Length / 2} acres",
            ItemCount = acres.Length / 2,
            IsAvailable = true,
        };
    }

    #endregion

    #region Sync Methods

    private void SyncVillagers()
    {
        var sourceVillagers = _source.Main.GetVillagers();
        var targetOrigin = _target.Players[0].Personal;

        foreach (var villager in sourceVillagers)
        {
            villager.ChangeOrigins(targetOrigin, villager.Write());
        }

        _target.Main.SetVillagers(sourceVillagers);
    }

    private void SyncVillagerHouses()
    {
        var sourceHouses = _source.Main.GetVillagerHouses();
        _target.Main.SetVillagerHouses(sourceHouses);
    }

    private void SyncBuildings()
    {
        var sourceBuildings = _source.Main.Buildings;
        _target.Main.Buildings = sourceBuildings;
    }

    private void SyncPlayerHouses()
    {
        var sourceHouses = _source.Main.GetPlayerHouses();
        _target.Main.SetPlayerHouses(sourceHouses);
    }

    private void SyncDesignPatterns()
    {
        var sourceDesigns = _source.Main.GetDesigns();
        var playerID = _target.Players[0].Personal.GetPlayerIdentity();
        var townID = _target.Players[0].Personal.GetTownIdentity();
        _target.Main.SetDesigns(sourceDesigns, playerID, townID);
    }

    private void SyncDesignPatternsPRO()
    {
        var sourceDesigns = _source.Main.GetDesignsPRO();
        var playerID = _target.Players[0].Personal.GetPlayerIdentity();
        var townID = _target.Players[0].Personal.GetTownIdentity();
        _target.Main.SetDesignsPRO(sourceDesigns, playerID, townID);
    }

    private void SyncFieldItems()
    {
        if (!IsCompatible)
            return;

        var layer0 = _source.Main.GetFieldItemLayer0();
        var layer1 = _source.Main.GetFieldItemLayer1();
        _target.Main.SetFieldItemLayer0(layer0);
        _target.Main.SetFieldItemLayer1(layer1);
    }

    private void SyncTerrain()
    {
        var terrain = _source.Main.GetTerrainTiles();
        _target.Main.SetTerrainTiles(terrain);
    }

    private void SyncMuseum()
    {
        var museum = _source.Main.Museum;
        _target.Main.Museum = museum;
    }

    private void SyncTurnipPrices()
    {
        var turnip = _source.Main.Turnips;
        _target.Main.Turnips = turnip;
    }

    private void SyncWeatherSeed()
    {
        _target.Main.WeatherSeed = _source.Main.WeatherSeed;
    }

    private void SyncRecycleBin()
    {
        var items = _source.Main.RecycleBin;
        _target.Main.RecycleBin = items;
    }

    private void SyncAcres()
    {
        var acres = _source.Main.GetAcreBytes();
        _target.Main.SetAcreBytes(acres);
    }

    #endregion
}


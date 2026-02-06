using System;

namespace NHSE.Core;

/// <summary>
/// Categories of data that can be synced between save files.
/// </summary>
[Flags]
public enum SaveSyncCategory
{
    None = 0,

    /// <summary>
    /// All 10 villagers on the island.
    /// </summary>
    Villagers = 1 << 0,

    /// <summary>
    /// All 10 villager houses.
    /// </summary>
    VillagerHouses = 1 << 1,

    /// <summary>
    /// All buildings (shops, bridges, inclines, etc.).
    /// </summary>
    Buildings = 1 << 2,

    /// <summary>
    /// All player houses (up to 8).
    /// </summary>
    PlayerHouses = 1 << 3,

    /// <summary>
    /// Normal design patterns (50).
    /// </summary>
    DesignPatterns = 1 << 4,

    /// <summary>
    /// PRO design patterns (50).
    /// </summary>
    DesignPatternsPRO = 1 << 5,

    /// <summary>
    /// Field items on the island (layer 0 and 1).
    /// </summary>
    FieldItems = 1 << 6,

    /// <summary>
    /// Terrain tiles (elevation, rivers, cliffs).
    /// </summary>
    Terrain = 1 << 7,

    /// <summary>
    /// Museum donation records.
    /// </summary>
    Museum = 1 << 8,

    /// <summary>
    /// Turnip price patterns.
    /// </summary>
    TurnipPrices = 1 << 9,

    /// <summary>
    /// Weather random seed.
    /// </summary>
    WeatherSeed = 1 << 10,

    /// <summary>
    /// Recycle bin items.
    /// </summary>
    RecycleBin = 1 << 11,

    /// <summary>
    /// Acre layout data.
    /// </summary>
    Acres = 1 << 12,

    /// <summary>
    /// All design-related data.
    /// </summary>
    AllDesigns = DesignPatterns | DesignPatternsPRO,

    /// <summary>
    /// All villager-related data.
    /// </summary>
    AllVillagers = Villagers | VillagerHouses,

    /// <summary>
    /// All map-related data.
    /// </summary>
    AllMap = FieldItems | Terrain | Acres | Buildings,

    /// <summary>
    /// All syncable data.
    /// </summary>
    All = Villagers | VillagerHouses | Buildings | PlayerHouses |
          DesignPatterns | DesignPatternsPRO | FieldItems | Terrain |
          Museum | TurnipPrices | WeatherSeed | RecycleBin | Acres,
}


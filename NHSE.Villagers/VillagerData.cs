using System;

namespace NHSE.Villagers;

/// <summary>
/// Tuple-like record struct to hold villager and house memory segments.
/// </summary>
public readonly record struct VillagerData(Memory<byte> Villager, Memory<byte> House);
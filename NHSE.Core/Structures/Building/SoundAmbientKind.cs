namespace NHSE.Core;

/// <summary>
/// Ambient sound for a house.
/// </summary>
public enum SoundAmbientKind : byte
{
    Silence = 0x0,
    Rain = 0x1,
    Sea = 0x2,
    InWater = 0x3,
    Wind = 0x4,
    Plateau = 0x5,
    Jungle = 0x6,
    Crowd = 0x7,
    Cheers = 0x8,
    City = 0x9,
    Train = 0xA,
    Construction = 0xB,
    Space = 0xC,
    Echo = 0xD,
    Storm = 0xE,
    Cave = 0x10,
    Earthquake = 0x11,
    Squeak = 0x12,
    Country = 0x14,
    Factory = 0x15,
    Cyber = 0x1A,
    Healing = 0x1B,
    Forest = 0x1C,
    Duct = 0x1D,
}
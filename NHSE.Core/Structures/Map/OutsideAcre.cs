using System.Collections.Generic;
using System.Drawing;

namespace NHSE.Core
{
    public enum OutsideAcre : ushort
    {
        Flat = 00,

        FldOutNShip00 = 16,

        FldOutW00 = 20,
        FldOutW01 = 21,
        FldOutW02 = 22,
        FldOutW03 = 23,

        FldOutWRiver00 = 27,

        FldOutE00 = 29,
        FldOutE01 = 30,
        FldOutE02 = 31,
        FldOutE03 = 32,

        FldOutSW00 = 38,
        FldOutS00 = 39,
        FldOutSRiver00 = 40,
        FldOutSAirPortLeft00 = 41,
        FldOutSE00 = 42,
        FldOutSeaN00 = 43,
        FldOutSeaNW00 = 44,
        FldOutSeaNE00 = 45,
        FldOutSeaW00 = 46,

        FldOutSeaE00 = 48,

        FldOutSeaSW00 = 50,
        FldOutSeaS00 = 51,
        FldOutSeaSE00 = 52,

        FldOutE04 = 62,

        FldOutERiver00 = 91,
        FldOutSW01 = 92,
        FldOutSAirPortRight00 = 93,

        FldOutS01 = 97,
        FldOutSE01 = 98,
        FldOutSE03 = 99,
        FldOutSE02 = 100,
        FldOutSW03 = 101,
        FldOutSW02 = 102,
        FldOutS03 = 103,
        FldOutS02 = 104,
        FldOutS04 = 105,
        FldOutNEStone00 = 106,
        FldOutNStone03 = 107,
        FldOutNStone02 = 108,
        FldOutNStone01 = 109,
        FldOutNStoneR00 = 110,
        FldOutNStoneL00 = 111,
        FldOutNStone00 = 112,
        FldOutNStone04 = 113,

        FldOutEIslandDown01 = 115,
        FldOutEIslandDown00 = 116,
        FldOutEIslandUp00 = 117,
        FldOutEIslandUp01 = 118,
        FldOutWStone01 = 119,
        FldOutWStone00 = 120,
        FldOutEStone00 = 121,
        FldOutEStone01 = 122,
        FldOutNEStone01 = 123,
        FldOutNWStone01 = 124,
        FldOutNWStone00 = 125,
        FldOutWCliff00 = 126,
        FldOutW04 = 127,
        FldOutNShip02 = 128,
        FldOutNShip01 = 129,

        FldOutWCliff01 = 131,
        FldOutSRiver01 = 132,
        FldOutWRiver01 = 133,
        FldOutERiver01 = 134,
        FldOutSWBridge01 = 135,
        FldOutSWBridge00 = 136,
        FldOutSEBridge01 = 137,
        FldOutSEBridge00 = 138,
        FldOutECliff01 = 139,
        FldOutECliff00 = 140,
        FldOutWIslandDown00 = 141,
        FldOutWIslandDown01 = 142,
        FldOutWIslandUp00 = 143,
        FldOutWIslandUp01 = 144,
        FldOutEStone02 = 145,
        FldOutWStone02 = 146,
        FldOutSeaN02 = 147,
        FldOutSeaN01 = 148,

        FldOutSeaW02 = 151,
        FldOutSeaW01 = 152,

        FldOutSeaS02 = 155,
        FldOutSeaS01 = 156,
        FldOutSeaSW02 = 157,
        FldOutSeaSW01 = 158,
        FldOutSeaNW02 = 159,
        FldOutSeaNW01 = 160,
        FldOutSeaN05 = 161,
        FldOutSeaN04 = 162,
        FldOutSeaN03 = 163,
        FldOutSeaN08 = 164,
        FldOutSeaN07 = 165,
        FldOutSeaN06 = 166,

        FldOutSeaNW03 = 172,
        FldOutSeaW08 = 173,
        FldOutSeaW07 = 174,
        FldOutSeaW06 = 175,
        FldOutSeaW04 = 176,
        FldOutSeaW05 = 177,
        FldOutSeaW03 = 178,

        FldOutSeaSW03 = 184,

        FldOutSeaS05 = 191,
        FldOutSeaS04 = 192,
        FldOutSeaS03 = 193,
        FldOutSeaS08 = 194,
        FldOutSeaS07 = 195,
        FldOutSeaS06 = 196,
        FldOutSeaSE02 = 197,
        FldOutSeaSE01 = 198,

        FldOutSeaSE03 = 200,

        FldOutSeaE05 = 205,
        FldOutSeaE04 = 206,
        FldOutSeaE03 = 207,
        FldOutSeaE01 = 208,
        FldOutSeaE02 = 209,
        FldOutSeaE08 = 210,
        FldOutSeaE06 = 211,
        FldOutSeaE07 = 212,

        FldOutSeaNE03 = 216,
        FldOutSeaNE01 = 219,
        FldOutSeaNE02 = 220,

        FldOutSBridge00 = 222,
        FldOutWIslandDown02 = 223,
        FldOutWIslandUp02 = 224,
        FldOutEIslandDown02 = 225,
        FldOutEIslandUp02 = 226,
        FldOutECliff02 = 227,
        FldOutWCliff02 = 228,
        FldOutNEStone02 = 229,
        FldOutNWStone02 = 230,
        FldOutEStone03 = 231,
        FldOutWStone03 = 232,
        FldOutSRiver02 = 233,

        FldOutPhotoSBridge00 = 240,
        FldOutPhotoSE00 = 241,
        FldOutPhotoSW00 = 242,
        FldOutSBridge02 = 243,
        FldOutSBridge01 = 244
    }

    public static class CollisionUtil
    {
        public static readonly Dictionary<byte, Color> Dict = new Dictionary<byte, Color>
        {
            {00, Color.FromArgb( 70, 120,  64)}, // Grass
            {01, Color.FromArgb(128, 215, 195)}, // River
            {03, Color.FromArgb(192, 192, 192)}, // Stone
            {04, Color.FromArgb(240, 230, 170)}, // Sand
            {05, Color.FromArgb(128, 215, 195)}, // Sea
            {06, Color.FromArgb(255, 128, 128)}, // Wood
            {07, Color.FromArgb(0  ,   0,   0)}, // Null
            {08, Color.FromArgb(32 ,  32,  32)}, // Building
            {09, Color.FromArgb(255,   0,   0)}, // ??
            {10, Color.FromArgb(48 ,  48,  48)}, // Door
            {12, Color.FromArgb(128, 215, 195)}, // Water at mouths of river
            {15, Color.FromArgb(128, 215, 195)}, // Strip of water between river mouth and river
            {22, Color.FromArgb(190,  98,  98)}, // Wood (thin)
            {28, Color.FromArgb(255,   0,   0)}, // ?? this one isn't even in ColGroundAttributeParam...
            {29, Color.FromArgb(232, 222, 162)}, // Edge of beach, next to sea
            {41, Color.FromArgb(118, 122, 132)}, // Rocks at top of map
            {42, Color.FromArgb(128, 133, 147)}, // Taller regions, rocks at top of map
            {43, Color.Cyan}, // Tide pool
            {44, Color.FromArgb( 62, 112,  56)}, // Edge connecting grass and beach
            {45, Color.FromArgb(118, 122, 132)}, // Some kind of rock
            {46, Color.FromArgb(120, 207, 187)}, // Edge of sea, next to beach
            {47, Color.FromArgb(128, 128,   0)}, // Sandstone
            {49, Color.FromArgb(190,  98,  98)}, // Pier
            {51, Color.FromArgb(32 , 152,  32)}, // "Grass-growing building"??
        };
    }
}

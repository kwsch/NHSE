namespace NHSE.Core;

/// <summary>
/// Sizes of Items
/// </summary>
public enum ItemSizeType : byte
{
    S_0_5x1_0_Wall,
    S_0x2B28C88F,
    S_1_0x0_5,
    S_1_0x0_5_Wall,
    S_1_0x1_0,
    S_1_0x1_0_Rug,
    S_1_0x1_0_Wall,
    S_1_0x1_5_Wall,
    S_1_0x2_0_Wall,
    S_1_5x1_5,
    S_2_0x0_5,
    S_2_0x1_0,
    S_2_0x1_0_Rug,
    S_2_0x1_0_Wall,
    S_2_0x1_5_Wall,
    S_2_0x2_0,
    S_2_0x2_0_Rug,
    S_2_0x2_0_Wall,
    S_3_0x1_0,
    S_3_0x2_0,
    S_3_0x2_0_Rug,
    S_3_0x3_0,
    S_3_0x3_0_Rug,
    S_4_0x3_0_Rug,
    S_4_0x4_0_Rug,
    S_5_0x5_0_Rug,

    S_5_0x4_0_Rug, // not used by any items; manually added since it's in ItemSize
    Unknown = byte.MaxValue,
}
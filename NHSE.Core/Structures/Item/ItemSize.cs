using System.Collections.Generic;

namespace NHSE.Core
{
    /// <summary>
    /// Detail about an item's dimensions
    /// </summary>
    public class ItemSize
    {
        public readonly int Width;
        public readonly int Height;

        public ItemSize(int w, int h)
        {
            Width = w; Height = h;
        }
    }

    public static class ItemSizeExtensions
    {
        public const string EnumPrefix = "S_";

        private static readonly Dictionary<ItemSizeType, ItemSize> Dictionary = new Dictionary<ItemSizeType, ItemSize>
        {
            {ItemSizeType.S_1_0x1_0     , new ItemSize( 2,  2)}, // 1x1
            {ItemSizeType.S_2_0x1_0     , new ItemSize( 4,  2)}, // 2x1
            {ItemSizeType.S_2_0x2_0     , new ItemSize( 4,  4)}, // 2x2
            {ItemSizeType.S_3_0x1_0     , new ItemSize( 6,  2)}, // 3x1
            {ItemSizeType.S_3_0x2_0     , new ItemSize( 6,  4)}, // 3x2
            {ItemSizeType.S_3_0x3_0     , new ItemSize( 6,  6)}, // 3x3
            {ItemSizeType.S_1_0x0_5     , new ItemSize( 2,  1)}, // 1x0.5
            {ItemSizeType.S_2_0x0_5     , new ItemSize( 4,  1)}, // 2x0.5
            {ItemSizeType.S_1_5x1_5     , new ItemSize( 3,  3)}, // 1.5x1.5
            {ItemSizeType.S_1_0x0_5_Wall, new ItemSize( 2,  1)}, // 1x0.5(壁)
            {ItemSizeType.S_0_5x1_0_Wall, new ItemSize( 1,  2)}, // 0.5x1(壁)
            {ItemSizeType.S_1_0x1_0_Wall, new ItemSize( 2,  2)}, // 1x1(壁)
            {ItemSizeType.S_1_0x1_5_Wall, new ItemSize( 2,  3)}, // 1x1.5 (壁)
            {ItemSizeType.S_1_0x2_0_Wall, new ItemSize( 2,  4)}, // 1x2　 (壁)
            {ItemSizeType.S_2_0x1_0_Wall, new ItemSize( 4,  2)}, // 2x1(壁)
            {ItemSizeType.S_2_0x1_5_Wall, new ItemSize( 4,  3)}, // 2x1.5 (壁)
            {ItemSizeType.S_2_0x2_0_Wall, new ItemSize( 4,  4)}, // 2x2(壁)
            {ItemSizeType.S_1_0x1_0_Rug , new ItemSize( 2,  2)}, // 1x1(ラグ)
            {ItemSizeType.S_2_0x1_0_Rug , new ItemSize( 4,  2)}, // 2x1(ラグ)
            {ItemSizeType.S_2_0x2_0_Rug , new ItemSize( 4,  4)}, // 2x2(ラグ)
            {ItemSizeType.S_3_0x2_0_Rug , new ItemSize( 6,  4)}, // 3x2(ラグ）
            {ItemSizeType.S_3_0x3_0_Rug , new ItemSize( 6,  6)}, // 3x3(ラグ）
            {ItemSizeType.S_4_0x3_0_Rug , new ItemSize( 8,  6)}, // 4x3(ラグ)
            {ItemSizeType.S_4_0x4_0_Rug , new ItemSize( 8,  8)}, // 4x4(ラグ)
            {ItemSizeType.S_5_0x4_0_Rug , new ItemSize(10,  8)}, // 5x4(ラグ)
            {ItemSizeType.S_5_0x5_0_Rug , new ItemSize(10, 10)}, // 5x5(ラグ)
        };

        public static int GetWidth(this ItemSizeType s) => Dictionary.TryGetValue(s, out var val) ? val.Width : 2;
        public static int GetHeight(this ItemSizeType s) => Dictionary.TryGetValue(s, out var val) ? val.Height : 2;
    }
}

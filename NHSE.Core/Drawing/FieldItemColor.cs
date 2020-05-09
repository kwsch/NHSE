using System.Drawing;

namespace NHSE.Core
{
    public static class FieldItemColor
    {
        public static Color GetItemColor(Item item)
        {
            if (item.DisplayItemId >= Item.FieldItemMin)
                return GetItemColor60000(item);
            var kind = ItemInfo.GetItemKind(item);
            return ColorUtil.Colors[(int)kind];
        }

        private static Color GetItemColor60000(Item item)
        {
            var id = item.DisplayItemId;
            if (id == Item.NONE)
                return Color.Transparent;

            if (!FieldItemList.Items.TryGetValue(id, out var def))
                return Color.DarkGreen;

            var kind = def.Kind;
            if (kind.IsTree())
                return GetTreeColor(id);
            if (kind.IsFlower())
                return Color.HotPink;
            if (kind.IsWeed())
                return Color.DarkOliveGreen;
            if (kind.IsFence())
                return Color.LightCoral;
            if (kind == FieldItemKind.UnitIconHole)
                return Color.Black;
            if (kind.IsBush())
                return Color.LightGreen;
            if (kind.IsStone())
                return Color.LightGray;

            return Color.DarkGreen; // shouldn't reach here, but ok
        }

        private static Color GetTreeColor(ushort id)
        {
            if (0xEC9C <= id && id <= 0xECA0) // money tree
                return Color.Gold;

            return id switch
            {
                // Fruit
                0xEA61 => Color.Red,       // "PltTreeApple"
                0xEA62 => Color.Orange,    // "PltTreeOrange"
                0xEAC8 => Color.Lime,      // "PltTreePear"
                0xEAC9 => Color.DarkRed,   // "PltTreeCherry"
                0xEACA => Color.PeachPuff, // "PltTreePeach"

                // Cedar
                0xEA69 => Color.SaddleBrown, // "PltTreeCedar4"
                0xEAB6 => Color.SaddleBrown, // "PltTreeCedar2"
                0xEAB7 => Color.SaddleBrown, // "PltTreeCedar1"
                0xEAB8 => Color.SaddleBrown, // "PltTreeCedar3"

                // Palm
                0xEA77 => Color.LightGoldenrodYellow, // "PltTreePalm4"
                0xEAC0 => Color.LightGoldenrodYellow, // "PltTreePalm2"
                0xEAC1 => Color.LightGoldenrodYellow, // "PltTreePalm1"
                0xEAC2 => Color.LightGoldenrodYellow, // "PltTreePalm3"

                0xEA76 => Color.MediumSeaGreen, // "PltTreeBamboo4"
                0xEAC4 => Color.MediumSeaGreen, // "PltTreeBamboo0"
                0xEAC5 => Color.MediumSeaGreen, // "PltTreeBamboo2"
                0xEAC6 => Color.MediumSeaGreen, // "PltTreeBamboo1"
                0xEAC7 => Color.MediumSeaGreen, // "PltTreeBamboo3"

                _ => Color.SandyBrown,
            };
        }
    }
}

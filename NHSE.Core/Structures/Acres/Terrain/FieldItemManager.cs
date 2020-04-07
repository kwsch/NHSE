using System;

namespace NHSE.Core
{
    public class FieldItemManager
    {
        public readonly FieldItemLayer Layer1;
        public readonly FieldItemLayer Layer2;

        public FieldItemManager(FieldItem[] layer1, FieldItem[] layer2)
        {
            Layer1 = new FieldItemLayer(layer1);
            Layer2 = new FieldItemLayer(layer2);
        }

        public FieldItemManager(FieldItem[] items, int layers = 2) // Two halves; split and assign.
            : this(items.Slice(0, items.Length / 2), items.SliceEnd(items.Length / 2))
        {
            if (layers != 2)
                throw new ArgumentOutOfRangeException(nameof(layers));
        }

        public FieldItem GetTile(int layer, int x, int y) => GetLayer(layer).GetTile(x, y);
        public FieldItem GetTile(int layer, int acreX, int acreY, int gridX, int gridY) => GetLayer(layer).GetTile(acreX, acreY, gridX, gridY);
        public FieldItem GetAcreTile(int layer, int acreIndex, int tileIndex) => GetLayer(layer).GetAcreTile(acreIndex, tileIndex);

        public FieldItemLayer GetLayer(int layer)
        {
            if ((uint) layer >= 2)
                throw new ArgumentOutOfRangeException(nameof(layer));
            return layer == 0 ? Layer1 : Layer2;
        }

        public bool IsOccupied(int x, int y) => !Layer1.GetTile(x, y).IsNone || !Layer2.GetTile(x, y).IsNone;
    }
}

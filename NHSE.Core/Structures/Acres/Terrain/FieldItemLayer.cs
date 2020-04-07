using System.Diagnostics;

namespace NHSE.Core
{
    public class FieldItemLayer : MapGrid
    {
        public readonly FieldItem[] Tiles;

        public FieldItemLayer(FieldItem[] tiles) : base(32, 32)
        {
            Tiles = tiles;
            Debug.Assert(MapTileCount == tiles.Length);
        }

        public FieldItem GetTile(int x, int y) => this[GetTileIndex(x, y)];
        public FieldItem GetTile(int acreX, int acreY, int gridX, int gridY) => this[GetTileIndex(acreX, acreY, gridX, gridY)];
        public FieldItem GetAcreTile(int acreIndex, int tileIndex) => this[GetAcreTileIndex(acreIndex, tileIndex)];

        public FieldItem this[int index]
        {
            get => Tiles[index];
            set => Tiles[index] = value;
        }
    }
}

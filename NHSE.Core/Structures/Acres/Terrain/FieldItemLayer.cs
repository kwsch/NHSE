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

        public byte[] DumpAcre(int acre)
        {
            int count = AcreTileCount;
            var result = new byte[FieldItem.SIZE * count];
            for (int i = 0; i < count; i++)
            {
                var tile = GetAcreTile(acre, i);
                var bytes = tile.ToBytesClass();
                bytes.CopyTo(result, i * FieldItem.SIZE);
            }
            return result;
        }

        public byte[] DumpAllAcres()
        {
            var result = new byte[Tiles.Length * FieldItem.SIZE];
            for (int i = 0; i < Tiles.Length; i++)
                Tiles[i].ToBytesClass().CopyTo(result, i * FieldItem.SIZE);
            return result;
        }

        public void ImportAllAcres(byte[] data)
        {
            var tiles = FieldItem.GetArray(data);
            for (int i = 0; i < tiles.Length; i++)
                Tiles[i].CopyFrom(tiles[i]);
        }

        public void ImportAcre(int acre, byte[] data)
        {
            int count = AcreTileCount;
            var tiles = FieldItem.GetArray(data);
            for (int i = 0; i < count; i++)
            {
                var tile = GetAcreTile(acre, i);
                tile.CopyFrom(tiles[i]);
            }
        }
    }
}

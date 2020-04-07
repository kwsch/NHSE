using System.Diagnostics;

namespace NHSE.Core
{
    public class TerrainManager : MapGrid
    {
        public readonly TerrainTile[] Tiles;

        public TerrainManager(TerrainTile[] tiles) : base(16, 16)
        {
            Tiles = tiles;
            Debug.Assert(MapTileCount == tiles.Length);
        }

        public TerrainTile GetTile(int x, int y) => this[GetTileIndex(x, y)];
        public TerrainTile GetTile(int acreX, int acreY, int gridX, int gridY) => this[GetTileIndex(acreX, acreY, gridX, gridY)];
        public TerrainTile GetAcreTile(int acreIndex, int tileIndex) => this[GetAcreTileIndex(acreIndex, tileIndex)];

        public TerrainTile this[int index]
        {
            get => Tiles[index];
            set => Tiles[index] = value;
        }

        public byte[] DumpAllAcres()
        {
            var result = new byte[Tiles.Length * TerrainTile.SIZE];
            for (int i = 0; i < Tiles.Length; i++)
                Tiles[i].ToBytesClass().CopyTo(result, i * TerrainTile.SIZE);
            return result;
        }

        public byte[] DumpAcre(int acre)
        {
            int count = AcreTileCount;
            var result = new byte[TerrainTile.SIZE * count];
            for (int i = 0; i < count; i++)
            {
                var tile = GetAcreTile(acre, i);
                var bytes = tile.ToBytesClass();
                bytes.CopyTo(result, i * TerrainTile.SIZE);
            }
            return result;
        }

        public void ImportAllAcres(byte[] data)
        {
            var tiles = TerrainTile.GetArray(data);
            for (int i = 0; i < tiles.Length; i++)
                Tiles[i].CopyFrom(tiles[i]);
        }

        public void ImportAcre(int acre, byte[] data)
        {
            int count = AcreTileCount;
            var tiles = TerrainTile.GetArray(data);
            for (int i = 0; i < count; i++)
            {
                var tile = GetAcreTile(acre, i);
                tile.CopyFrom(tiles[i]);
            }
        }
    }
}

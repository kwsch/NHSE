using System.Diagnostics;

namespace NHSE.Core
{
    public class TerrainManager
    {
        public readonly TerrainTile[] Tiles;
        public readonly AcreCoordinate[] Acres = AcreCoordinate.GetGrid(AcreWidth, AcreHeight);

        public const int GridWidth = 16;
        public const int GridHeight = 16;

        public const int AcreWidth = 7;
        public const int AcreHeight = 6;
        public const int AcreSize = GridWidth * GridHeight;

        public const int MapHeight = AcreHeight * GridHeight; // 92
        public const int MapWidth = AcreWidth * GridWidth; // 112
        public const int TileCount = MapWidth * MapHeight; // 0x2A00

        public TerrainManager(TerrainTile[] tiles)
        {
            Debug.Assert(TileCount == tiles.Length);
            Tiles = tiles;
        }

        public static int GetIndex(int x, int y) => (MapHeight * x) + y;

        public TerrainTile GetTile(int x, int y) => this[GetIndex(x, y)];

        public TerrainTile GetTile(int acreX, int acreY, int gridX, int gridY)
        {
            var x = (acreX * GridWidth) + gridX;
            var y = (acreY * GridHeight) + gridY;
            return this[GetIndex(x, y)];
        }

        public TerrainTile GetAcreTile(int acreIndex, int tileIndex)
        {
            var acre = Acres[acreIndex];
            var x = (tileIndex % GridWidth);
            var y = (tileIndex / GridHeight);
            return GetTile(acre.X, acre.Y, x, y);
        }

        public static int GetAcre(int x, int y) => (x / GridWidth) + ((y / GridHeight) * AcreWidth);

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
            const int count = (GridWidth * GridHeight);
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
            const int count = (GridWidth * GridHeight);
            var tiles = TerrainTile.GetArray(data);
            for (int i = 0; i < count; i++)
            {
                var tile = GetAcreTile(acre, i);
                tile.CopyFrom(tiles[i]);
            }
        }
    }
}

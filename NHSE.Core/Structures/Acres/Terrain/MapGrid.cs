namespace NHSE.Core
{
    /// <summary>
    /// Basic logic implementation for interacting with the manipulatable map grid.
    /// </summary>
    public abstract class MapGrid
    {
        public static readonly AcreCoordinate[] Acres = AcreCoordinate.GetGrid(AcreWidth, AcreHeight);

        public const int GridWidth = 16;
        public const int GridHeight = 16;

        public const int AcreWidth = 7;
        public const int AcreHeight = 6;
        public const int AcreSize = GridWidth * GridHeight;

        public const int MapHeight = AcreHeight * GridHeight; // 92
        public const int MapWidth = AcreWidth * GridWidth; // 112
        public const int TileCount = MapWidth * MapHeight; // 0x2A00

        public static int GetTileIndex(int x, int y) => (MapHeight * x) + y;

        public static int GetTileIndex(int acreX, int acreY, int gridX, int gridY)
        {
            var x = (acreX * GridWidth) + gridX;
            var y = (acreY * GridHeight) + gridY;
            return GetTileIndex(x, y);
        }

        public static int GetAcreTileIndex(int acreIndex, int tileIndex)
        {
            var acre = Acres[acreIndex];
            var x = (tileIndex % GridWidth);
            var y = (tileIndex / GridHeight);
            return GetTileIndex(acre.X, acre.Y, x, y);
        }

        public static int GetAcre(int x, int y) => (x / GridWidth) + ((y / GridHeight) * AcreWidth);
        public static int GetIndex(int x, int y) => (MapHeight * x) + y;
    }
}
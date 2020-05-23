namespace NHSE.Core
{
    /// <summary>
    /// Basic logic implementation for interacting with the manipulatable map grid.
    /// </summary>
    public abstract class MapGrid : TileGrid
    {
        public static readonly AcreCoordinate[] Acres = AcreCoordinate.GetGrid(AcreWidth, AcreHeight);

        public const int AcreWidth = 7;
        public const int AcreHeight = 6;
        public const int AcreCount = AcreWidth * AcreHeight;

        public const int MapTileCount16x16 = 16 * 16 * AcreCount;
        public const int MapTileCount32x32 = 32 * 32 * AcreCount;

        protected MapGrid(int gw, int gh, int mw, int mh) : base(gw, gh, mw, mh) { }

        protected int GetTileIndex(int acreX, int acreY, int gridX, int gridY)
        {
            var x = (acreX * GridWidth) + gridX;
            var y = (acreY * GridHeight) + gridY;
            return GetTileIndex(x, y);
        }

        protected int GetAcreTileIndex(int acreIndex, int tileIndex)
        {
            var acre = Acres[acreIndex];
            var x = (tileIndex % GridWidth);
            var y = (tileIndex / GridHeight);
            return GetTileIndex(acre.X, acre.Y, x, y);
        }

        public int GetAcre(int x, int y) => (x / GridWidth) + ((y / GridHeight) * AcreWidth);

        public void GetViewAnchorCoordinates(int acre, out int x, out int y)
        {
            x = (acre % AcreWidth) * GridWidth;
            y = (acre / AcreWidth) * GridHeight;
        }
    }
}

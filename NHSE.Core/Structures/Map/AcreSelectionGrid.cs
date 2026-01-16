namespace NHSE.Core;

/// <summary>
/// Basic logic implementation for interacting with the manipulatable map grid.
/// </summary>
public abstract record AcreSelectionGrid(TileGridViewport TileInfo)
{
    protected int GetAcreTileIndex(int acreIndex, int tileIndex)
    {
        var acre = AcreCoordinate.Acres[acreIndex];
        var x = (tileIndex % TileInfo.ViewWidth);
        var y = (tileIndex / TileInfo.ViewHeight);
        return TileInfo.GetTileIndex(acre.X, acre.Y, x, y);
    }

    public int GetAcre(int x, int y) => (x / TileInfo.ViewWidth) + ((y / TileInfo.ViewHeight) * TileInfo.Columns);

    public void GetViewAnchorCoordinates(int acre, out int x, out int y)
    {
        x = (acre % TileInfo.Columns) * TileInfo.ViewWidth;
        y = (acre / TileInfo.Columns) * TileInfo.ViewHeight;
    }
}
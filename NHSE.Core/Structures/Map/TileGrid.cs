using System;

namespace NHSE.Core
{
    /// <summary>
    /// Basic logic implementation for interacting with the manipulatable tile grid.
    /// </summary>
    /// <remarks>
    /// Certain <see cref="TileGrid"/> use this as a viewport on a subsection of the entire tile-set.
    /// </remarks>
    public abstract class TileGrid
    {
        /// <summary> Amount of viewable tiles wide </summary>
        public readonly int GridWidth;

        /// <summary> Amount of viewable tiles high </summary>
        public readonly int GridHeight;

        /// <summary> Max amount of tiles wide the entire grid is </summary>
        public readonly int MaxWidth;

        /// <summary> Max amount of tiles high the entire grid is </summary>
        public readonly int MaxHeight;

        protected TileGrid(in int gw, in int gh, in int mw, in int mh)
        {
            GridWidth = gw;
            GridHeight = gh;
            MaxWidth = mw;
            MaxHeight = mh;
        }

        /// <summary>
        /// Amount of tiles present in the grid.
        /// </summary>
        public int GridTileCount => GridWidth * GridHeight;

        /// <summary>
        /// Amount of ALL tiles present in the entire grid (including the grid).
        /// </summary>
        public int MaxTileCount => MaxWidth * MaxHeight;

        protected int GetTileIndex(in int x, in int y) => (MaxHeight * x) + y;

        public void ClampCoordinatesInsideGrid(ref int x, ref int y) => ClampCoordinatesTo(ref x, ref y, MaxWidth - 1, MaxHeight - 1);

        public void ClampCoordinatesTopLeft(ref int x, ref int y)
        {
            int maxX = MaxWidth - GridWidth;
            int maxY = MaxHeight - GridHeight;
            ClampCoordinatesTo(ref x, ref y, maxX, maxY);
        }

        private static void ClampCoordinatesTo(ref int x, ref int y, int maxX, int maxY)
        {
            x = Math.Max(0, Math.Min(x, maxX));
            y = Math.Max(0, Math.Min(y, maxY));
        }

        public void GetViewAnchorCoordinates(ref int x, ref int y, in bool centerReticle)
        {
            // If we aren't snapping the reticle to the nearest acre
            // we want to put the middle of the reticle rectangle where the cursor is.
            // Adjust the view coordinate
            if (!centerReticle)
            {
                // Reticle size is GridWidth, center = /2
                x -= GridWidth / 2;
                y -= GridWidth / 2;
            }

            // Clamp to viewport dimensions, and center to nearest acre if desired.
            // Clamp to boundaries so that we always have 16x16 to view.
            ClampCoordinatesTopLeft(ref x, ref y);
        }
    }
}

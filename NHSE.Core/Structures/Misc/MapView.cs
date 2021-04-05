using System;

namespace NHSE.Core
{
    public class MapView
    {
        private const int ViewInterval = 2;
        public readonly MapManager Map;

        public int MapScale { get; } = 1;
        public int AcreScale { get; }
        public int TerrainScale => AcreScale * 2;

        // Top Left Anchor Coordinates
        public int X { get; set; }
        public int Y { get; set; }

        protected MapView(MapManager m, int scale = 16)
        {
            AcreScale = scale;
            Map = m;
        }

        public bool CanUp => Y != 0;
        public bool CanDown => Y < Map.CurrentLayer.MaxHeight - Map.CurrentLayer.GridHeight;
        public bool CanLeft => X != 0;
        public bool CanRight => X < Map.CurrentLayer.MaxWidth - Map.CurrentLayer.GridWidth;

        public bool ArrowUp()
        {
            if (Y <= 0)
                return false;
            Y -= ViewInterval;
            return true;
        }

        public bool ArrowLeft()
        {
            if (X <= 0)
                return false;
            X -= ViewInterval;
            return true;
        }

        public bool ArrowRight()
        {
            if (X >= Map.CurrentLayer.MaxWidth - 2)
                return false;
            X += ViewInterval;
            return true;
        }

        public bool ArrowDown()
        {
            if (Y >= Map.CurrentLayer.MaxHeight - ViewInterval)
                return false;
            Y += ViewInterval;
            return true;
        }

        public bool SetViewTo(in int x, in int y)
        {
            var info = Map.CurrentLayer;
            var newX = Math.Max(0, Math.Min(x, info.MaxWidth - info.GridWidth));
            var newY = Math.Max(0, Math.Min(y, info.MaxHeight - info.GridHeight));
            bool diff = X != newX || Y != newY;
            X = newX;
            Y = newY;
            return diff;
        }

        public void SetViewToAcre(in int acre)
        {
            var layer = Map.Items.Layer1;
            layer.GetViewAnchorCoordinates(acre, out var x, out var y);
            SetViewTo(x, y);
        }

        public int ModifyFieldItems(Func<int, int, int, int, int> action, in bool wholeMap)
        {
            var layer = Map.CurrentLayer;
            return wholeMap
                ? action(0, 0, layer.MaxWidth, layer.MaxHeight)
                : action(X, Y, layer.GridWidth, layer.GridHeight);
        }

        public int ReplaceFieldItems(Item oldItem, Item newItem, in bool wholeMap)
        {
            var layer = Map.CurrentLayer;
            return wholeMap
                ? layer.ReplaceAll(oldItem, newItem, 0, 0, layer.MaxWidth, layer.MaxHeight)
                : layer.ReplaceAll(oldItem, newItem, X, Y, layer.GridWidth, layer.GridHeight);
        }

        public void GetCursorCoordinates(in int mX, in int mY, out int x, out int y)
        {
            x = mX / MapScale;
            y = mY / MapScale;
        }

        public void GetViewAnchorCoordinates(int mX, int mY, out int x, out int y, bool centerReticle)
        {
            GetCursorCoordinates(mX, mY, out x, out y);
            var layer = Map.Items.Layer1;
            layer.GetViewAnchorCoordinates(ref x, ref y, centerReticle);
        }
    }
}

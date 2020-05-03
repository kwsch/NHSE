using System;
using System.Drawing;
using NHSE.Core;
using NHSE.Sprites;

namespace NHSE.WinForms
{
    public sealed class MapViewer : MapView, IDisposable
    {
        // Cached acre view objects to remove allocation/GC
        private readonly int[] Scale1;
        private readonly int[] ScaleX;
        private readonly Bitmap ScaleAcre;
        private readonly int[] MapPixels;
        private readonly Bitmap MapReticle;

        public MapViewer(MapManager m) : base(m)
        {
            var l1 = m.Items.Layer1;
            Scale1 = new int[l1.GridWidth * l1.GridHeight];
            ScaleX = new int[Scale1.Length * AcreScale * AcreScale];
            ScaleAcre = new Bitmap(l1.GridWidth * AcreScale, l1.GridHeight * AcreScale);

            MapPixels = new int[l1.MapWidth * l1.MapHeight * MapScale * MapScale];
            MapReticle = new Bitmap(l1.MapWidth * MapScale, l1.MapHeight * MapScale);
        }

        public void Dispose()
        {
            ScaleAcre.Dispose();
            MapReticle.Dispose();
        }

        public Bitmap GetLayerAcre(int t) => GetLayerAcre(X, Y, t);
        public Bitmap GetBackgroundAcre(Font f, int index = -1) => GetBackgroundAcre(X, Y, f, index);
        public Bitmap GetMapWithReticle(int t) => GetMapWithReticle(X, Y, t, Map.CurrentLayer);

        public Bitmap GetBackgroundTerrain(int index = -1)
        {
            return TerrainSprite.GetMapWithBuildings(Map.Terrain, Map.Buildings, (ushort)Map.PlazaX, (ushort)Map.PlazaY, null, 2, index);
        }

        private Bitmap GetLayerAcre(int topX, int topY, int t)
        {
            var layer = Map.CurrentLayer;
            return FieldItemSpriteDrawer.GetBitmapLayerAcre(layer, topX, topY, AcreScale, Scale1, ScaleX, ScaleAcre, t);
        }

        private Bitmap GetBackgroundAcre(int topX, int topY, Font f, int index = -1)
        {
            return TerrainSprite.GetAcre(topX / 2, topY / 2, Map.Terrain, AcreScale * 2, Map.Buildings,
                (ushort)Map.PlazaX, (ushort)Map.PlazaY, f, index);
        }

        private Bitmap GetMapWithReticle(int topX, int topY, int t, FieldItemLayer layer)
        {
            return FieldItemSpriteDrawer.GetBitmapLayer(layer, topX, topY, MapPixels, MapReticle, t);
        }
    }
}
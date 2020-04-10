using System;
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

        public int ClearFieldPlanted(Func<FieldItemKind, bool> criteria)
        {
            int count = 0;
            var fi = FieldItemList.Items;
            foreach (var t in Tiles)
            {
                var disp = t.DisplayItemId;
                if (!fi.TryGetValue(disp, out var val))
                    continue;

                if (!criteria(val.Kind))
                    continue;
                t.Delete();
                count++;
            }

            return count;
        }

        public int RemoveAll(Func<FieldItem, bool> criteria)
        {
            int count = 0;
            foreach (var t in Tiles)
            {
                if (!criteria(t))
                    continue;
                t.Delete();
                count++;
            }

            return count;
        }

        public int RemoveAllHoles() => ClearFieldPlanted(z => z == FieldItemKind.UnitIconHole);
        public int RemoveAllWeeds() => ClearFieldPlanted(z => z.IsWeed());
        public int RemoveAllPlants() => ClearFieldPlanted(_ => true);
    }
}

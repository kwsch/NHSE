using System.Collections.Generic;
using System.Diagnostics;

namespace NHSE.Core
{
    public class FieldItemManager
    {
        public readonly FieldItemLayer Layer1;
        public readonly FieldItemLayer Layer2;

        public readonly MainSave SAV;

        public FieldItemManager(MainSave sav)
        {
            Layer1 = new FieldItemLayer(sav.GetFieldItemLayer1());
            Layer2 = new FieldItemLayer(sav.GetFieldItemLayer2());
            SAV = sav;
        }

        public void Save()
        {
            SAV.SetFieldItemLayer1(Layer1.Tiles);
            SAV.SetFieldItemLayer2(Layer2.Tiles);

            SetTileActiveFlags(Layer1, SAV.FieldItemFlag1);
            SetTileActiveFlags(Layer2, SAV.FieldItemFlag2);
        }

        public List<string> GetUnsupportedTiles()
        {
            var result = new List<string>();
            for (int x = 0; x < 224; x++)
            {
                for (int y = 0; y < 192; y++)
                {
                    var tile = Layer2.GetTile(x, y);
                    if (tile.IsNone)
                        continue;

                    var support = Layer1.GetTile(x, y);
                    if (!support.IsNone)
                        continue; // dunno how to check if the tile can actually have an item put on top of it...

                    result.Add($"{x:000},{y:000}");
                }
            }
            return result;
        }

        private void SetTileActiveFlags(FieldItemLayer tiles, int ofs)
        {
            // Although the Tiles are arranged y-column (y-x) based, the 'isActive' flags are arranged x-row (x-y) based.
            // We can turn the isActive flag off if the item is not a root or the item cannot be animated.
            for (int x = 0; x < 224; x++)
            {
                for (int y = 0; y < 192; y++)
                {
                    var tile = tiles.GetTile(x, y);
                    var isActive = IsActive(ofs, x, y);
                    if (!isActive)
                        continue;

                    bool empty = tile.IsNone;
                    if (empty)
                        Debug.WriteLine($"Flag at ({x},{y}) is not a root object.");
                }
            }
        }

        public bool IsActive(bool baseLayer, int x, int y) => IsActive(baseLayer ? SAV.FieldItemFlag1 : SAV.FieldItemFlag2, x, y);
        private bool IsActive(int ofs, int x, int y) => FlagUtil.GetFlag(SAV.Data, ofs, (y * 224) + x);
        public bool IsOccupied(int x, int y) => !Layer1.GetTile(x, y).IsNone || !Layer2.GetTile(x, y).IsNone;
    }
}

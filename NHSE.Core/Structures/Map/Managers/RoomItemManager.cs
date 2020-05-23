using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NHSE.Core
{
    public class RoomItemManager
    {
        public readonly RoomItemLayer[] Layers;

        public readonly PlayerRoom Room;
        private const int LayerCount = 8;

        public RoomItemManager(PlayerRoom room)
        {
            Layers = room.GetItemLayers();
            Room = room;
            Debug.Assert(Layers.Length == LayerCount);
        }

        public void Save() => Room.SetItemLayers(Layers);

        public bool IsOccupied(int layer, int x, int y)
        {
            if ((uint)layer >= LayerCount)
                throw new ArgumentOutOfRangeException(nameof(layer));

            var l = Layers[layer];
            var tile = l.GetTile(x, y);
            return !tile.IsNone || (layer == (int)RoomLayerSurface.FloorSupported && IsOccupied((int)RoomLayerSurface.Floor, x, y));
        }

        public List<string> GetUnsupportedTiles()
        {
            var lBase = Layers[(int)RoomLayerSurface.Floor];
            var lSupport = Layers[(int)RoomLayerSurface.FloorSupported];
            var result = new List<string>();
            for (int x = 0; x < lBase.MaxWidth; x++)
            {
                for (int y = 0; y < lBase.MaxHeight; y++)
                {
                    var tile = lSupport.GetTile(x, y);
                    if (tile.IsNone)
                        continue;

                    var support = lBase.GetTile(x, y);
                    if (!support.IsNone)
                        continue; // dunno how to check if the tile can actually have an item put on top of it...

                    result.Add($"{x:000},{y:000}");
                }
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NHSE.Core;

public sealed class RoomManager
{
    public readonly LayerRoomItem[] Layers;

    public readonly IPlayerRoom Room;

    /// <summary>
    /// <see cref="RoomLayerSurface"/>
    /// </summary>
    private const int LayerCount = 8;

    public RoomManager(IPlayerRoom room)
    {
        Layers = room.GetItemLayers();
        Room = room;
        Debug.Assert(Layers.Length == LayerCount);
    }

    public void Save() => Room.SetItemLayers(Layers);

    public bool IsOccupied(RoomLayerSurface layer, int x, int y)
    {
        if ((uint)layer >= LayerCount)
            throw new ArgumentOutOfRangeException(nameof(layer));

        var l = Layers[(int)layer];
        var tile = l.GetTile(x, y);
        return !tile.IsNone || (layer == RoomLayerSurface.FloorSupported && IsOccupied(RoomLayerSurface.Floor, x, y));
    }

    public List<string> GetUnsupportedTiles()
    {
        var lBase = Layers[(int)RoomLayerSurface.Floor];
        var lSupport = Layers[(int)RoomLayerSurface.FloorSupported];
        var result = new List<string>();

        var (width, height) = lBase.TileInfo.DimTotal;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
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
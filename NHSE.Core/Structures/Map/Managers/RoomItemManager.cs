using System.Diagnostics;

namespace NHSE.Core
{
    public class RoomItemManager
    {
        // Layer 1: Base Layer Placed Items
        // Layer 2: Supported Layer Placed Items
        // Layer 3: North Wall
        // Layer 4: ???
        // Layer 5: ???
        // Layer 6: ???
        // Layer 7: Rug
        // Layer 8: ???

        public readonly RoomItemLayer[] Layers;

        public readonly PlayerRoom Room;

        public RoomItemManager(PlayerRoom room)
        {
            Layers = room.GetItemLayers();
            Room = room;
            Debug.Assert(Layers.Length == 8);
        }

        public void Save() => Room.SetItemLayers(Layers);

        // public bool IsOccupied(int x, int y) => Layers.Any(z => !z.GetTile(x, y).IsNone);
    }
}

using System.Collections.Generic;

namespace NHSE.Core
{
    public interface IPlayerRoom
    {
        /// <summary> Returns the inner data buffer of the object, flushing any pending changes. </summary>
        byte[] Write();

        string Extension { get; }
        RoomItemLayer[] GetItemLayers();
        void SetItemLayers(IReadOnlyList<RoomItemLayer> value);
        IPlayerRoom Upgrade();
    }
}

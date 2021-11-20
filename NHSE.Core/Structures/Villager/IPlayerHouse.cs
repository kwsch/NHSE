namespace NHSE.Core
{
    public interface IPlayerHouse : IHouseInfo
    {
        /// <summary> Returns the inner data buffer of the object, flushing any pending changes. </summary>
        byte[] Write();

        sbyte NPC1 { get; set; }
        sbyte NPC2 { get; set; }
        string Extension { get; }
        short[] GetEventFlags();
        void SetEventFlags(short[] value);
        IPlayerRoom GetRoom(int roomIndex);
        void SetRoom(int roomIndex, IPlayerRoom room);
    }
}

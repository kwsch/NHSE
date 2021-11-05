namespace NHSE.Core
{
    public interface IVillagerHouse : IHouseInfo
    {
        /// <summary> Returns the inner data buffer of the object, flushing any pending changes. </summary>
        byte[] Write();

        sbyte NPC1 { get; set; }
        sbyte NPC2 { get; set; }
        string Extension { get; }
        sbyte BuildPlayer { get; }
    }
}

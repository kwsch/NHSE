namespace NHSE.Core
{
    public interface IHeldItem
    {
        ushort ItemId { get; set; }
        byte SystemParam { get; set; }
        byte AdditionalParam { get; set; }
        ushort Count { get; set; }
        ushort UseCount { get; set; }
    }
}

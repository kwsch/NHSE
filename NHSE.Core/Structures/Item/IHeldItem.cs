namespace NHSE.Core
{
    public interface IHeldItem
    {
        ushort ItemId { get; set; }
        byte Flags0 { get; set; }
        byte Flags1 { get; set; }
        ushort Count { get; set; }
        ushort UseCount { get; set; }
    }
}

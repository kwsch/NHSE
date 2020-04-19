namespace NHSE.Core
{
    public interface IHouseInfo
    {
        uint HouseLevel { get; set; }
        ushort WallUniqueID { get; set; }
        ushort RoofUniqueID { get; set; }
        ushort DoorUniqueID { get; set; }
        ushort OrderWallUniqueID { get; set; }
        ushort OrderRoofUniqueID { get; set; }
        ushort OrderDoorUniqueID { get; set; }
        GSaveItemName DoorDecoItemName { get; set; }
    }

    public static class HouseInfoExtensions
    {
        public static void CopyFrom(this IHouseInfo dest, IHouseInfo src)
        {
            dest.HouseLevel   = src.HouseLevel;
            dest.WallUniqueID = src.WallUniqueID;
            dest.RoofUniqueID = src.RoofUniqueID;
            dest.DoorUniqueID = src.DoorUniqueID;
            dest.OrderWallUniqueID = src.OrderWallUniqueID;
            dest.OrderRoofUniqueID = src.OrderRoofUniqueID;
            dest.OrderDoorUniqueID = src.OrderDoorUniqueID;
            dest.DoorDecoItemName = src.DoorDecoItemName;
        }
    }
}

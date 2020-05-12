namespace NHSE.Core
{
    public interface IHouseInfo
    {
        uint HouseLevel { get; set; }
        WallType WallUniqueID { get; set; }
        RoofType RoofUniqueID { get; set; }
        DoorKind DoorUniqueID { get; set; }
        WallType OrderWallUniqueID { get; set; }
        RoofType OrderRoofUniqueID { get; set; }
        DoorKind OrderDoorUniqueID { get; set; }
        Item DoorDecoItemName { get; set; }
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

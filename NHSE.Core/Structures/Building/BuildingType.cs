namespace NHSE.Core
{
    /// <summary>
    /// Building model &amp; interior that is loaded when the <see cref="Building"/> is entered.
    /// </summary>
#pragma warning disable CA1027 // Mark enums with FlagsAttribute
    public enum BuildingType : ushort
#pragma warning restore CA1027 // Mark enums with FlagsAttribute
    {
        None = 0,
        PlayerHouse1 = 1,
        PlayerHouse2 = 2,
        PlayerHouse3 = 3,
        PlayerHouse4 = 4,
        PlayerHouse5 = 5,
        PlayerHouse6 = 6,
        PlayerHouse7 = 7,
        PlayerHouse8 = 8,
        Villager1 = 9,
        Villager2 = 10,
        Villager3 = 11,
        Villager4 = 12,
        Villager5 = 13,
        Villager6 = 14,
        Villager7 = 15,
        Villager8 = 16,
        Villager9 = 17,
        Villager10 = 18,
        NooksCranny = 19,
        ResidentCenterStructure = 20,
        Museum = 21,
        Airport = 22,
        ResidentCenterTent = 23,
        AblesSisters = 24,
        Campsite = 25,
        Bridge = 26,
        Incline = 27,
        ReddsTreasureTrawler = 28,
        Studio = 29,
    }
}

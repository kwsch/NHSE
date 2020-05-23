namespace NHSE.Core
{
    /// <summary>
    /// Incline / Slope model
    /// </summary>
    public enum SlopeType : ushort
    {
        SlopeStoneStair = 0x00,
        SlopeIronStair = 0x01,
        SlopeWood = 0x02,
        SlopeWoodStair = 0x03,
        SlopeBrickStair = 0x04,
        SlopeReserved = 0x05,
        SlopeNatural = 0x1D,
        SlopeWoodBlue = 0x1E,
        SlopeIronStairBlue = 0x1F,
    }
}

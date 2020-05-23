namespace NHSE.Core
{
    /// <summary>
    /// Material used for a <see cref="BridgeType"/> construction (footstep sounds?).
    /// </summary>
    public enum BridgeMaterial : byte
    {
        BridgeStone = 0x00,
        BridgeSuspension = 0x01,
        BridgeJapanese = 0x02,
        BridgeLog = 0x04,
        BridgeRed = 0x05,
        BridgeIron = 0x06,
        BridgeReserved = 0x07,
        BridgeWood = 0x0A,
        BridgeBricks = 0x0B,
    }
}

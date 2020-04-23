namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="MainSaveOffsets"/>
    /// </summary>
    public class MainSaveOffsets11 : MainSaveOffsets
    {
        public override int Villager => 0x120;
        public override int Patterns => 0x1D7310; // +0x20 from v1.0

        public override int EventFlagLand => FieldItem - 0x800;

        // GSaveMainField
        public override int FieldItem => 0x20191C; // +0x20 from v1.0 // Layer 1&2, and 2*0x1500
        public override int Terrain => Buildings - 0x24C00;// +0x20 from v1.0 // LandMakingMap
        public override int Buildings => 0x2D0F1C; // +0x20 from v1.0
        public override int Acres => 0x2D12B4; // +0x20 from v1.0

        public override int PlayerHouseList => FieldItem + 0xDAA2C;
        public override int NpcHouseList => PlayerHouseList + (PlayerCount * PlayerHouse.SIZE);

        public override int TurnipExchange => 0x412060; // +0x7A0 from v1.0
        public override int RecycleBin => 0xABDE70; // +0x1E70 from v1.0
        public override int LastSavedTime => RecycleBin + 0x4958;
    }
}

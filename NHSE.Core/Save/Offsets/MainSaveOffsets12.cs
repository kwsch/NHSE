namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="MainSaveOffsets"/>
    /// </summary>
    public class MainSaveOffsets12 : MainSaveOffsets
    {
        public override int Villager => 0x120;
        public override int Patterns => 0x1D7310;

        public override int EventFlagLand => FieldItem - 0x800;

        // GSaveMainField
        public override int FieldItem => 0x20191C;
        public override int Terrain => Buildings - 0x24C00;
        public override int Buildings => 0x2D0F1C;
        public override int Acres => 0x2D12B4;

        public override int PlayerHouseList => FieldItem + 0xDAA2C;
        public override int NpcHouseList => PlayerHouseList + (PlayerCount * PlayerHouse.SIZE);

        public override int TurnipExchange => 0x412060;
        public override int RecycleBin => 0xACA0A0; // +0xC230 from v1.1
        public override int LastSavedTime => RecycleBin + 0x4958;
    }
}

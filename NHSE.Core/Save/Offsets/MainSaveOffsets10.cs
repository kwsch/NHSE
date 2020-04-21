namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="MainSaveOffsets"/>
    /// </summary>
    public class MainSaveOffsets10 : MainSaveOffsets
    {
        public override int Villager => 0x110;
        public override int Patterns => 0x1D72F0;

        public override int EventFlagLand => FieldItem - 0x800;
        public override int FieldItem => 0x2018FC;
        public override int Terrain => Buildings - 0x24C00;
        public override int Buildings => 0x2D0EFC;
        public override int Acres => 0x2D1294;

        public override int PlayerHouseList => FieldItem + 0xDAA2C;
        public override int NpcHouseList => PlayerHouseList + (PlayerCount * PlayerHouse.SIZE);

        public override int TurnipExchange => 0x4118C0;
        public override int RecycleBin => 0xABC000; // yep.
        public override int LastSavedTime => RecycleBin + 0x4928;
    }
}
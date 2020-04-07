namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="MainSaveOffsets"/>
    /// </summary>
    public class MainSaveOffsets10 : MainSaveOffsets
    {
        public override int Villager => 0x110;
        public override int Patterns => 0x1D72F0;
        public override int FieldItem => 0x2018FC;
        public override int Terrain => Buildings - 0x24C00; // dunno where exactly it starts???
        public override int Buildings => 0x2D0EFC;
        public override int Acres => 0x2D1294;
        public override int TurnipExchange => 0x4118C0;
        public override int RecycleBin => 0xABC000; // yep.
    }
}
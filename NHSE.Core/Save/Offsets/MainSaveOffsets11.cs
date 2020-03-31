namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="MainSaveOffsets"/>
    /// </summary>
    public class MainSaveOffsets11 : MainSaveOffsets
    {
        public override int Villager => 0x120;
        public override int Patterns => 0x1D7310; // +0x20 from v1.0
        public override int Buildings => 0x2D0F1C; // +0x20 from v1.0
        public override int RecycleBin => 0xABDE70; // +0x1E70 from v1.0
    }
}
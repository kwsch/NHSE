namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="PersonalOffsets"/>
    /// </summary>
    public sealed class PersonalOffsets12 : PersonalOffsets
    {
        public override int PersonalId => 0xB0B8;
        public override int EventFlagsPlayer => PersonalId + 0x38;
        public override int Activity => 0xCF84;
        public override int NookMiles => 0x11588;
        public override int Photo => 0x117C4; // +0x3FC from v1.1

        public override int Pockets1 => 0x35E50; // +0x230 from v1.1
        public override int Pockets2 => Pockets1 + (8 * Pockets1Count) + 0x18;
        public override int Wallet => Pockets2 + (8 * Pockets2Count) + 0x18;
        public override int Storage => Wallet + 0xC;
        public override int ReceivedItems => 0x3FE98; // +0x230 from v1.1

        public override int Bank => 0x6A424; // +0x17F0 from v1.1
        public override int Recipes => Bank + 0x10;

        public override int MaxRecipeID { get; } = 0x2CB;
    }
}

namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="PersonalOffsets"/>
    /// </summary>
    public sealed class PersonalOffsets10 : PersonalOffsets
    {
        public override int PersonalId => 0xB0A0;
        public override int EventFlagsPlayer => PersonalId + 0x38; // +0x18 from v1.0, +0x18 after player name start
        public override int Activity => 0xCF6C;
        public override int Wallet => 0x11578;
        public override int NookMiles => 0x11570;
        public override int Photo => 0x11598;

        public override int Pockets1 => 0x35BD4;
        public override int Pockets2 => Pockets1 + (8 * Pockets1Count) + 0x18;
        public override int Storage => Pockets2 + (8 * Pockets2Count) + 0x24;
        public override int ReceivedItems => 0x3FC1C;

        public override int Bank => 0x68BE4;
        public override int Recipes => 0x68BF4;
    }
}
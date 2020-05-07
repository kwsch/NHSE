namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="PersonalOffsets"/>
    /// </summary>
    public sealed class PersonalOffsets10 : PersonalOffsets
    {
        private const int Player = 0x108;

        public override int PersonalId => Player + 0xAF98;
        public override int EventFlagsPlayer => Player + 0xAFD0;

        private const int GSaveLifeSupport = Player + 0xBFD0;
        public override int CountAchievement => GSaveLifeSupport + 0xE98; // CountAchievement

        public override int NowPoint => GSaveLifeSupport + 0x5498; // Nook Miles
        public override int TotalPoint => NowPoint + 8; // Total Nook Miles Earned

        private const int GSaveNetPlayerProfile = Player + 0x11480;
        public override int Photo => GSaveNetPlayerProfile + 0x24;

        // end player

        private const int PlayerOther = 0x35BD0;

        public override int Pockets1 => PlayerOther + 0x4;
        public override int Pockets2 => Pockets1 + (8 * Pockets1Count) + 0x18;
        public override int Wallet => Pockets2 + (8 * Pockets2Count) + 0x18;
        public override int ItemChest => PlayerOther + 0x18C;
        public override int ItemCollectBit => PlayerOther + 0xA04C;
        public override int ItemRemakeCollectBit => PlayerOther + 0xA7A0;
        public override int Bank => PlayerOther + 0x33014;
        public override int Recipes => Bank + 0x10;

        public override int MaxRecipeID => 0x2A0;
        public override int MaxRemakeBitFlag => 0x754 * 32;
    }
}

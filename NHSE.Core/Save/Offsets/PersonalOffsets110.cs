namespace NHSE.Core
{
    /// <summary>
    /// <inheritdoc cref="PersonalOffsets"/>
    /// </summary>
    /// <remarks>Same as <see cref="PersonalOffsets18"/>.</remarks>
    public sealed class PersonalOffsets110 : PersonalOffsets
    {
        private const int Player = 0x110;

        public override int PersonalId => Player + 0xAFA8;
        public override int EventFlagsPlayer => Player + 0xAFE0;

        private const int GSaveLifeSupport = Player + 0xBFE0;
        public override int CountAchievement => GSaveLifeSupport + 0xE98; // CountAchievement

        public override int NowPoint => GSaveLifeSupport + 0x5498; // Nook Miles
        public override int TotalPoint => NowPoint + 8; // Total Nook Miles Earned
        public override int Birthday => Player + 0x1228c;

        public override int ProfileMain => Player + 0x122a0;
        public override int ProfilePhoto => ProfileMain + 0x14;
        public override int ProfileBirthday => ProfileMain + 0x23058;
        public override int ProfileFruit => ProfileMain + 0x2305C;
        public override int ProfileTimestamp => ProfileMain + 0x230CC;
        public override int ProfileIsMakeVillage => ProfileMain + 0x230D0;

        // end player

        private const int PlayerOther = 0x36a50;

        public override int Pockets1 => PlayerOther + 0x10;
        public override int Pockets2 => Pockets1 + (8 * Pockets1Count) + 0x18;
        public override int Wallet => Pockets2 + (8 * Pockets2Count) + 0x18;
        public override int ItemChest => PlayerOther + 0x18C;
        public override int ItemCollectBit => PlayerOther + 0xA058;
        public override int ItemRemakeCollectBit => PlayerOther + 0xA7AC;
        public override int Manpu => PlayerOther + 0xAF7C;
        public override int Bank => PlayerOther + 0x22594;
        public override int Recipes => Bank + 0x10;

        public override int MaxRecipeID => 0x308;
        public override int MaxRemakeBitFlag => 0x7D0 * 32;

        public override IReactionStore ReadReactions(byte[] data) => data.Slice(Manpu, GSavePlayerManpu15.SIZE).ToStructure<GSavePlayerManpu15>();
        public override void SetReactions(byte[] data, IReactionStore value) => ((GSavePlayerManpu15)value).ToBytes().CopyTo(data, Manpu);
    }
}

using System;

namespace NHSE.Core
{
    /// <summary>
    /// Offset info and object retrieval logic for <see cref="Personal"/>
    /// </summary>
    public abstract class PersonalOffsets
    {
        public abstract int PersonalId { get; }
        public abstract int EventFlagsPlayer { get; }
        public abstract int CountAchievement { get; }
        public abstract int Wallet { get; }
        public abstract int NowPoint { get; }
        public abstract int TotalPoint { get; }
        public abstract int Photo { get; }

        public abstract int Pockets1 { get; }
        public abstract int Pockets2 { get; }
        public abstract int ItemChest { get; }
        public abstract int ItemCollectBit { get; }

        public abstract int Bank { get; }
        public abstract int Recipes { get; }

        public int MaxAchievementID { get; } = 512;
        public int Pockets1Count { get; } = 20;
        public int Pockets2Count { get; } = 20;
        public int ItemChestCount { get; } = 5000;
        public abstract int MaxRecipeID { get; }

        public static PersonalOffsets GetOffsets(FileHeaderInfo Info)
        {
            var rev = Info.GetKnownRevisionIndex();
            return rev switch
            {
                0 => new PersonalOffsets10(),
                1 => new PersonalOffsets11(),
                2 => new PersonalOffsets11(),
                3 => new PersonalOffsets11(),
                4 => new PersonalOffsets11(),
                5 => new PersonalOffsets11(),
                6 => new PersonalOffsets12(),
                _ => throw new IndexOutOfRangeException("Unknown revision!"),
            };
        }
    }
}
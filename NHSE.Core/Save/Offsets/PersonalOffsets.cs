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
        public abstract int Birthday { get; }

        public abstract int ProfileMain { get; }
        public abstract int ProfilePhoto { get; }
        public abstract int ProfileBirthday { get; }
        public abstract int ProfileFruit { get; }
        public abstract int ProfileTimestamp { get; }
        public abstract int ProfileIsMakeVillage { get; }

        public abstract int Pockets1 { get; }
        public abstract int Pockets2 { get; }
        public abstract int ItemChest { get; }
        public abstract int ItemCollectBit { get; }
        public abstract int ItemRemakeCollectBit { get; }
        public abstract int Manpu { get; } // reactions

        public abstract int Bank { get; }
        public abstract int Recipes { get; }

        public int MaxAchievementID { get; } = 512;
        public int Pockets1Count { get; } = 20;
        public int Pockets2Count { get; } = 20;
        public int ItemChestCount { get; } = 5000;
        public abstract int MaxRecipeID { get; }
        public abstract int MaxRemakeBitFlag { get; }

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
                7 => new PersonalOffsets12(),
                8 => new PersonalOffsets13(),
                9 => new PersonalOffsets13(),
                10 => new PersonalOffsets14(),
                11 => new PersonalOffsets14(),
                12 => new PersonalOffsets14(),
                13 => new PersonalOffsets15(),
                14 => new PersonalOffsets15(),
                15 => new PersonalOffsets16(),
                16 => new PersonalOffsets17(),
                17 => new PersonalOffsets18(),
                18 => new PersonalOffsets19(),
                19 => new PersonalOffsets110(),
                _ => throw new IndexOutOfRangeException("Unknown revision!" + Environment.NewLine + Info),
            };
        }

        public abstract IReactionStore ReadReactions(byte[] data);
        public abstract void SetReactions(byte[] data, IReactionStore value);
    }
}
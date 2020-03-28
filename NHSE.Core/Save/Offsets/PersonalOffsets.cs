using System;

namespace NHSE.Core
{
    public abstract class PersonalOffsets
    {
        public abstract int PersonalId { get; }
        public abstract int Wallet { get; }
        public abstract int Bank { get; }
        public abstract int NookMiles { get; }
        public abstract int Photo { get; }

        public abstract int Pockets1 { get; }
        public abstract int Pockets2 { get; }
        public abstract int Storage { get; }

        public virtual int Pockets1Count { get; } = 20;
        public virtual int Pockets2Count { get; } = 20;
        public virtual int StorageCount { get; } = 5000;

        public static PersonalOffsets GetOffsets(FileHeaderInfo Info)
        {
            var rev = Info.GetKnownRevisionIndex();
            return rev switch
            {
                0 => new PersonalOffsets10(),
                1 => new PersonalOffsets11(),
                2 => new PersonalOffsets11(),
                _ => throw new IndexOutOfRangeException("Unknown revision!"),
            };
        }
    }
}
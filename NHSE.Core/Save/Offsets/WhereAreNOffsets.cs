using System;

namespace NHSE.Core
{
    /// <summary>
    /// Offset info and object retrieval logic for <see cref="Personal"/>
    /// </summary>
    public abstract class WhereAreNOffsets
    {
        public abstract int Poki { get; }

        public static WhereAreNOffsets GetOffsets(FileHeaderInfo Info)
        {
            var rev = Info.GetKnownRevisionIndex();
            return rev switch
            {
                22 => new WhereAreNOffsets20(),
                23 => new WhereAreNOffsets20(),
                24 => new WhereAreNOffsets20(),
                25 => new WhereAreNOffsets20(),
                26 => new WhereAreNOffsets20(),
                27 => new WhereAreNOffsets20(),
                28 => new WhereAreNOffsets20(),
                _ => throw new IndexOutOfRangeException("Unknown revision!" + Environment.NewLine + Info),
            };
        }
    }
}
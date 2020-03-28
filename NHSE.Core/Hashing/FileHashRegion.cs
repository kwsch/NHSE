namespace NHSE.Core
{
    /// <summary>
    /// Specifies the region that a validation hash is calculated over.
    /// </summary>
    public readonly struct FileHashRegion
    {
        /// <summary>
        /// Offset of the calculated hash.
        /// </summary>
        public readonly int HashOffset;

        /// <summary>
        /// Offset where the data to be hashed starts at.
        /// </summary>
        public readonly int BeginOffset;

        /// <summary>
        /// Length of the hashed data.
        /// </summary>
        public readonly int Size;

        /// <summary>
        /// Offset where the data to be hashed ends at (calculated).
        /// </summary>
        public int EndOffset => BeginOffset + Size;

        public FileHashRegion(int hashOfs, int begOfs, int size)
        {
            HashOffset = hashOfs;
            BeginOffset = begOfs;
            Size = size;
        }

        #region Equality Comparison
        public override bool Equals(object obj) => obj is FileHashRegion r && r == this;
        public override int GetHashCode() => BeginOffset.GetHashCode();

        public static bool operator !=(FileHashRegion left, FileHashRegion right) => !(left == right);

        public static bool operator ==(FileHashRegion left, FileHashRegion right)
        {
            if (left.HashOffset != right.HashOffset)
                return false;
            if (left.BeginOffset != right.BeginOffset)
                return false;
            if (left.Size != right.Size)
                return false;
            return true;
        }
        #endregion
    }
}
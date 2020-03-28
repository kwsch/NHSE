namespace NHSE.Core
{
    public readonly struct CryptoFile
    {
        public readonly byte[] Data;
        public readonly byte[] Key;
        public readonly byte[] Ctr;

        public CryptoFile(byte[] data, byte[] key, byte[] ctr)
        {
            Data = data;
            Key = key;
            Ctr = ctr;
        }

        #region Equality Comparison
        public override bool Equals(object obj) => obj is CryptoFile r && r == this;
        public override int GetHashCode() => Data.GetHashCode();
        public static bool operator !=(CryptoFile left, CryptoFile right) => !(left == right);
        public static bool operator ==(CryptoFile left, CryptoFile right) => left.Data == right.Data;
        #endregion
    }
}
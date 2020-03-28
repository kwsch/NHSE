namespace NHSE.Core
{
    public readonly struct EncryptedSaveFile
    {
        public readonly byte[] Data;
        public readonly byte[] Header;

        public EncryptedSaveFile(byte[] data, byte[] header)
        {
            Data = data;
            Header = header;
        }

        #region Equality Comparison
        public override bool Equals(object obj) => obj is EncryptedSaveFile r && r == this;
        public override int GetHashCode() => Data.GetHashCode();
        public static bool operator !=(EncryptedSaveFile left, EncryptedSaveFile right) => !(left == right);
        public static bool operator ==(EncryptedSaveFile left, EncryptedSaveFile right) => left.Data == right.Data && left.Header == right.Header;
        #endregion
    }
}
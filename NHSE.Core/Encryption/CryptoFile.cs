namespace NHSE.Core
{
    internal readonly ref struct CryptoFile
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
    }
}

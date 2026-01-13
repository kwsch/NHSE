namespace NHSE.Core;

internal readonly record struct CryptoFile(byte[] Data, byte[] Key, byte[] Ctr);
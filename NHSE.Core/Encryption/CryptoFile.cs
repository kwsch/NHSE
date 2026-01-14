using System;

namespace NHSE.Core;

internal record struct CryptoFile(Memory<byte> Data, Memory<byte> Key, Memory<byte> Ctr);
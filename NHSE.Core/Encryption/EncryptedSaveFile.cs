using System;

namespace NHSE.Core;

public readonly record struct EncryptedSaveFile(ReadOnlyMemory<byte> Data, ReadOnlyMemory<byte> Header);
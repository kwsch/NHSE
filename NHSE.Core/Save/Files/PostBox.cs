namespace NHSE.Core;

/// <summary>
/// postbox.dat
/// </summary>
public sealed class PostBox(ISaveFileProvider provider) : EncryptedFilePair(provider, "postbox");
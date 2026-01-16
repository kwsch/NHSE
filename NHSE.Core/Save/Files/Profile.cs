namespace NHSE.Core;

/// <summary>
/// profile.dat
/// </summary>
/// <remarks>
/// pretty much just a jpeg -- which is also stored in Personal.
/// </remarks>
public sealed class Profile(ISaveFileProvider provider) : EncryptedFilePair(provider, "profile");
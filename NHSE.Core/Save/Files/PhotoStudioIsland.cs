namespace NHSE.Core;

/// <summary>
/// photo_studio_island.dat
/// </summary>
public sealed class PhotoStudioIsland(ISaveFileProvider provider) : EncryptedFilePair(provider, "photo_studio_island");
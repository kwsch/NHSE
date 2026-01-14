using System.Collections.Generic;

namespace NHSE.Core;

/// <summary>
/// Contains the <see cref="HashRegions"/> for a <see cref="FileName"/>.
/// </summary>
/// <param name="FileName">Name of the File that these <see cref="HashRegions"/> apply to.</param>
/// <param name="FileSize">Expected file size of the <see cref="FileName"/>.</param>
/// <param name="HashRegions">Hash specs that are done in this file.</param>
/// <remarks>Checking equality is fine to do the regular shallow check; length essentially governs hash regions.</remarks>
public sealed record FileHashDetails(string FileName, uint FileSize, IReadOnlyList<FileHashRegion> HashRegions);
namespace NHSE.Core;

/// <summary>
/// Stores file sizes for various savedata files at different patch revisions.
/// </summary>
public sealed record SaveFileSizes(
    uint Main,
    uint Personal,
    uint PhotoStudioIsland,
    uint PostBox,
    uint Profile,
    uint WhereAreN = 0);
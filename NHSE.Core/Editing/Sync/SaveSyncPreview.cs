using System.Collections.Generic;

namespace NHSE.Core;

/// <summary>
/// Preview information for a sync category from a source save.
/// </summary>
public sealed class SaveSyncPreview
{
    public required SaveSyncCategory Category { get; init; }
    public required string Summary { get; init; }
    public required int ItemCount { get; init; }
    public required bool IsAvailable { get; init; }
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// Collection of sync previews for all categories from a source save.
/// </summary>
public sealed class SaveSyncPreviewCollection
{
    public required IReadOnlyList<SaveSyncPreview> Previews { get; init; }
    public required bool IsCompatible { get; init; }
    public string? CompatibilityMessage { get; init; }
    public required string SourceSaveName { get; init; }
    public required string SourceSaveVersion { get; init; }
}


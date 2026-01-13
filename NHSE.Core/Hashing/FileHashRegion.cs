namespace NHSE.Core;

/// <summary>
/// Specifies the region that a validation hash is calculated over.
/// </summary>
/// <param name="HashOffset">Offset of the calculated hash.</param>
/// <param name="Size">Length of the hashed data.</param>
public readonly record struct FileHashRegion(int HashOffset, int Size)
{
    /// <summary>
    /// Offset where the data to be hashed starts at (calculated).
    /// </summary>
    public int BeginOffset => HashOffset + 4;

    /// <summary>
    /// Offset where the data to be hashed ends at (calculated).
    /// </summary>
    public int EndOffset => BeginOffset + Size;

    public override string ToString() => $"0x{HashOffset:X}: (0x{BeginOffset:X}-0x{EndOffset:X})";
}
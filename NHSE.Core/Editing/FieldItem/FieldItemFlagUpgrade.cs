using System;

namespace NHSE.Core;

/// <summary>
/// Provides functionality to upgrade or downgrade field item flag data between different formats.
/// </summary>
public static class FieldItemFlagUpgrade
{
    private const int ColumnCountOld = 7;
    private const int ColumnCountNew = 9; // +1 column on each side
    private const int RowCount = 6;

    private const byte SizeDim = LayerFieldItem.TilesPerAcreDim;

    // Tile dimensions across the entire map
    private const int TileRowCount = RowCount * SizeDim; // 192 tile rows
    private const int TilesPerRowOld = ColumnCountOld * SizeDim; // 224 tiles per row
    private const int TilesPerRowNew = ColumnCountNew * SizeDim; // 288 tiles per row

    // Bytes per tile-row (1 bit per tile, 8 tiles per byte)
    private const int BytesPerRowOld = TilesPerRowOld / 8; // 28 bytes
    private const int BytesPerRowNew = TilesPerRowNew / 8; // 36 bytes

    // Bytes for one acre column per row (32 tiles / 8 bits per byte = 4 bytes)
    private const int BytesPerAcreColumnPerRow = SizeDim / 8; // 4 bytes

    // Total sizes
    private const int FlagSizeOld = TileRowCount * BytesPerRowOld; // 5,376 bytes
    private const int FlagSizeNew = TileRowCount * BytesPerRowNew; // 6,912 bytes

    // Active flags are stored in row-major order.
    // Since the upgrade adds a column on each side, it's not possible to simply prepend and append default columns.
    // For each row of data, we need to add default flags at the start and end of the row.
    // Repeat for all rows.

    /// <summary>
    /// Checks if an update is needed based on the current size and expected size.
    /// </summary>
    /// <param name="current">Current size of the data.</param>
    /// <param name="expect">Desired size of the data.</param>
    /// <returns><see langword="true"/> if an update is needed; otherwise <see langword="false"/>.</returns>
    public static bool IsUpdateNeeded(long current, int expect) => expect switch
    {
        FlagSizeOld => current == FlagSizeNew,
        FlagSizeNew => current == FlagSizeOld,
        _ => false,
    };

    /// <summary>
    /// Detects and performs an update on the field item flag data if needed.
    /// </summary>
    /// <param name="data">Data to update.</param>
    /// <param name="expect">Desired size of the data.</param>
    /// <returns><see langword="true"/> if an update was performed; otherwise <see langword="false"/>.</returns>
    /// <remarks>Pre-check <see cref="IsUpdateNeeded(long, int)"/> to ensure a conversion is available.</remarks>
    public static bool DetectUpdate(ref byte[] data, int expect)
    {
        if (expect == FlagSizeNew && data.Length == FlagSizeOld)
            data = Inflate(data);
        else if (expect == FlagSizeOld && data.Length == FlagSizeNew)
            data = Deflate(data);
        else // No change needed/supported.
            return false;
        return true;
    }

    /// <inheritdoc cref="Inflate(ReadOnlySpan{byte}, Span{byte})"/>
    public static byte[] Inflate(ReadOnlySpan<byte> data)
    {
        if (data.Length != FlagSizeOld)
            throw new ArgumentException($"Data length {data.Length} does not match expected old size {FlagSizeOld}.");

        var result = new byte[FlagSizeNew];
        Inflate(data, result);
        return result;
    }

    /// <summary>
    /// Inflates old field item flag data to the new format.
    /// </summary>
    /// <param name="data">Old field item flag data.</param>
    /// <param name="result">Span to write new field item flag data to.</param>
    /// <exception cref="ArgumentException"></exception>
    public static void Inflate(ReadOnlySpan<byte> data, Span<byte> result)
    {
        if (data.Length != FlagSizeOld)
            throw new ArgumentException($"Data length {data.Length} does not match expected old size {FlagSizeOld}.");
        if (result.Length < FlagSizeNew)
            throw new ArgumentException($"Result length {result.Length} is less than expected new size {FlagSizeNew}.");

        // For each tile row:
        // - 4 bytes of zeros for new left column (result is already zeroed)
        // - Copy 28 bytes from old data (existing flags)
        // - 4 bytes of zeros for new right column (result is already zeroed)

        for (int row = 0; row < TileRowCount; row++)
        {
            var srcOffset = row * BytesPerRowOld;
            var dstOffset = (row * BytesPerRowNew) + BytesPerAcreColumnPerRow;
            data.Slice(srcOffset, BytesPerRowOld).CopyTo(result[dstOffset..]);
        }
    }

    /// <inheritdoc cref="Deflate(ReadOnlySpan{byte}, Span{byte})"/>
    public static byte[] Deflate(ReadOnlySpan<byte> data)
    {
        if (data.Length != FlagSizeNew)
            throw new ArgumentException($"Data length {data.Length} does not match expected new size {FlagSizeNew}.");

        var result = new byte[FlagSizeOld];
        Deflate(data, result);
        return result;
    }

    /// <summary>
    /// Deflates new field item flag data to the old format.
    /// </summary>
    /// <param name="data">New field item flag data.</param>
    /// <param name="result">Span to write old field item flag data to.</param>
    /// <exception cref="ArgumentException"></exception>
    public static void Deflate(ReadOnlySpan<byte> data, Span<byte> result)
    {
        if (data.Length != FlagSizeNew)
            throw new ArgumentException($"Data length {data.Length} does not match expected new size {FlagSizeNew}.");
        if (result.Length < FlagSizeOld)
            throw new ArgumentException($"Result length {result.Length} is less than expected old size {FlagSizeOld}.");

        // For each tile row:
        // - Skip 4 bytes for new left column
        // - Copy 28 bytes to result (existing flags)
        // - Skip 4 bytes for new right column

        for (int row = 0; row < TileRowCount; row++)
        {
            var srcOffset = (row * BytesPerRowNew) + BytesPerAcreColumnPerRow;
            var dstOffset = row * BytesPerRowOld;
            data.Slice(srcOffset, BytesPerRowOld).CopyTo(result[dstOffset..]);
        }
    }
}
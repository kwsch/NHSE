using System;
using System.Runtime.InteropServices;

namespace NHSE.Core;

/// <summary>
/// Provides functionality to upgrade or downgrade field item data between different formats.
/// </summary>
public static class FieldItemUpgrade
{
    private const int ColumnCountOld = 7;
    private const int ColumnCountNew = 9; // +1 column on each side
    private const int RowCount = 6;

    private const byte SizeDim = LayerFieldItem.TilesPerAcreDim;
    private const int TilesPerAcre = SizeDim * SizeDim;
    private const int FieldItemSizeSingleColumn = RowCount * TilesPerAcre * Item.SIZE;
    private const int FieldItemSizeOld = ColumnCountOld * FieldItemSizeSingleColumn;
    private const int FieldItemSizeNew = ColumnCountNew * FieldItemSizeSingleColumn;

    /// <summary>
    /// Checks if an update is needed based on the current size and expected size.
    /// </summary>
    /// <param name="current">Current size of the data.</param>
    /// <param name="expect">Desired size of the data.</param>
    /// <returns><see langword="true"/> if an update is needed; otherwise <see langword="false"/>.</returns>
    public static bool IsUpdateNeeded(long current, int expect) => expect switch
    {
        FieldItemSizeOld => current == FieldItemSizeNew,
        FieldItemSizeNew => current == FieldItemSizeOld,
        _ => false,
    };

    /// <summary>
    /// Detects and performs an update on the field item data if needed.
    /// </summary>
    /// <param name="data">Data to update.</param>
    /// <param name="expect">Desired size of the data.</param>
    /// <returns><see langword="true"/> if an update was performed; otherwise <see langword="false"/>.</returns>
    /// <remarks>Pre-check <see cref="IsUpdateNeeded(long, int)"/> to ensure a conversion is available.</remarks>
    public static bool DetectUpdate(ref byte[] data, int expect)
    {
        if (expect == FieldItemSizeNew && data.Length == FieldItemSizeOld)
            data = Inflate(data);
        else if (expect == FieldItemSizeOld && data.Length == FieldItemSizeNew)
            data = Deflate(data);
        else // No change needed/supported.
            return false;
        return true;
    }

    /// <inheritdoc cref="Inflate(ReadOnlySpan{byte}, Span{byte})"/>
    public static byte[] Inflate(ReadOnlySpan<byte> data)
    {
        if (data.Length != FieldItemSizeOld)
            throw new ArgumentException($"Data length {data.Length} does not match expected old size {FieldItemSizeOld}.");

        var result = new byte[FieldItemSizeNew];
        Inflate(data, result);
        return result;
    }

    /// <summary>
    /// Inflates old field item data to the new format.
    /// </summary>
    /// <param name="data">Old field item data.</param>
    /// <param name="result">Span to write new field item data to.</param>
    /// <returns>New field item data.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static void Inflate(ReadOnlySpan<byte> data, Span<byte> result)
    {
        if (data.Length != FieldItemSizeOld)
            throw new ArgumentException($"Data length {data.Length} does not match expected old size {FieldItemSizeOld}.");
        if (result.Length < FieldItemSizeNew)
            throw new ArgumentException($"Result length {result.Length} is less than expected new size {FieldItemSizeNew}.");

        // The first acre column is default field items.
        // Then, the existing data is present.
        // Finally, an acre column is default field items.

        // Prepare a default column of no items.
        Span<byte> defaultColumn = stackalloc byte[FieldItemSizeSingleColumn];
        FillColumnWithItem(defaultColumn, Item.NONE);

        // First default column
        defaultColumn.CopyTo(result);
        // Existing data
        data.CopyTo(result[FieldItemSizeSingleColumn..]);
        // Last default column
        defaultColumn.CopyTo(result[^FieldItemSizeSingleColumn..]);
    }

    private static void FillColumnWithItem(Span<byte> defaultColumn, ulong tileValue)
    {
        if (!BitConverter.IsLittleEndian)
            tileValue = System.Buffers.Binary.BinaryPrimitives.ReverseEndianness(tileValue);
        var cast = MemoryMarshal.Cast<byte, ulong>(defaultColumn);
        foreach (ref var value in cast)
            value = tileValue;
    }

    /// <inheritdoc cref="Deflate(ReadOnlySpan{byte}, Span{byte})"/>
    public static byte[] Deflate(ReadOnlySpan<byte> data)
    {
        if (data.Length != FieldItemSizeNew)
            throw new ArgumentException($"Data length {data.Length} does not match expected new size {FieldItemSizeNew}.");
        return data.Slice(FieldItemSizeSingleColumn, FieldItemSizeOld).ToArray();
    }

    /// <summary>
    /// Deflates new field item data to the old format.
    /// </summary>
    /// <param name="data">New field item data.</param>
    /// <param name="result">Span to write old field item data to.</param>
    /// <returns>Old field item data.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static void Deflate(ReadOnlySpan<byte> data, Span<byte> result)
    {
        if (data.Length != FieldItemSizeNew)
            throw new ArgumentException($"Data length {data.Length} does not match expected new size {FieldItemSizeNew}.");
        if (result.Length < FieldItemSizeOld)
            throw new ArgumentException($"Result length {result.Length} is less than expected old size {FieldItemSizeOld}.");
        data.Slice(FieldItemSizeSingleColumn, FieldItemSizeOld).CopyTo(result);
    }
}
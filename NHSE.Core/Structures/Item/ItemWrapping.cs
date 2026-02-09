using System.Collections.Generic;

namespace NHSE.Core;

/// <summary>
/// Type of wrapping an <see cref="Item"/> has
/// </summary>
public enum ItemWrapping : byte
{
    Nothing = 0,
    WrappingPaper = 1,
    Present = 2,
    Delivery = 3,

    // These values are handled with special logic. Only 2 bits are allocated to be stored.
    Festive = 4,
}

/// <summary>
/// Provides extended wrapping and box skin information for items.
/// </summary>
/// <remarks>
/// Contains lookup dictionaries for item wrapping paper colors and delivery box types.
/// </remarks>
public sealed class ItemWrappingExtended
{
    /// <summary>
    /// Dictionary mapping wrapping skin identifiers to their corresponding <see cref="WrappingInfo"/>.
    /// </summary>
    /// <remarks>
    /// Keys are hexadecimal identifiers representing different wrapping paper colors and styles.
    /// Includes cultural variants (Lucky Red Envelope, Bokjumeoni Pouch, Otoshidama Envelope).
    /// Can return a string for the skin name, or an index for UI ordering or selection use.
    /// </remarks>
    // TODO: Build new string resource: "text_wrappers_xx.txt" and convert WrappingInfo.name to a key to lookup against it for translations.
    public static readonly Dictionary<int, WrappingInfo> ItemWrappingSkin = new() // 
    {
        { 0x00, new("wrap00", 0) },
        { 0x02, new("wrap01", 1) },
        { 0x01, new("wrap02", 2) },
        { 0x05, new("wrap03", 3) },
        { 0x09, new("wrap04", 4) },
        { 0x0D, new("wrap05", 5) },
        { 0x11, new("wrap06", 6) },
        { 0x15, new("wrap07", 7) },
        { 0x19, new("wrap08", 8) },
        { 0x1D, new("wrap09", 9) },
        { 0x21, new("wrap10", 10) },
        { 0x25, new("wrap11", 11) },
        { 0x29, new("wrap12", 12) },
        { 0x2D, new("wrap13", 13) },
        { 0x31, new("wrap14", 14) },
        { 0x35, new("wrap15", 15) },
        { 0x39, new("wrap16", 16) },
        { 0x3D, new("wrap17", 17) },
        { 0x3F, new("wrap18", 18) },
        { 0x33, new("wrap19", 19) },
        { 0x37, new("wrap20", 20) },
        { 0x3B, new("wrap21", 21) },
    };
    /// <summary>
    /// Represents information about a wrapping paper type.
    /// </summary>
    /// <param name="name">The display name of the wrapping paper.</param>
    /// <param name="index">The index used for UI ordering or selection.</param>
    public record WrappingInfo(string name, int index);

    /// <summary>
    /// Dictionary mapping box skin identifiers to their corresponding <see cref="BoxInfo"/>.
    /// </summary>
    /// <remarks>
    /// Keys are hexadecimal identifiers representing different delivery boxes.
    /// Includes service-specific boxes (Nook Shopping Box, Hotel Box, Paradise Planning Box).
    /// </remarks>
    // TODO: Build new string resource: "text_wrappers_xx.txt" and convert WrappingInfo.name to a key to lookup against it for translations.
    public static readonly Dictionary<int, BoxInfo> ItemBoxSkin = new()
    {
        { 0x00, new("box00", 0) },
        { 0x43, new("box01", 1) },
        { 0x6B, new("box02", 2) },
        { 0x6F, new("box03", 3) },
    };
    /// <summary>
    /// Represents information about a delivery box type.
    /// </summary>
    /// <param name="name">The display name of the box type.</param>
    /// <param name="index">The index used for UI ordering or selection.</param>
    public record BoxInfo(string name, int index);
}
namespace NHSE.Core;

/// <summary>
/// Details for field items -- items with <see cref="Item.ItemId"/> at or above 60,000.
/// </summary>
/// <remarks>
/// These details are extracted from FgMainParam.bcsv
/// </remarks>
/// <param name="Index">Item ID</param>
/// <param name="Dig">Item ID that the player receives if the item is dug up. Is <see cref="Item.NONE"/> if it cannot be dug up.</param>
/// <param name="Pick">Item ID that the player receives if the item is picked up. Is <see cref="Item.NONE"/> if it cannot be picked up.</param>
/// <param name="Name">Internal Name of the Item</param>
/// <param name="Kind">Classification of item.</param>
public sealed record FieldItemDefinition(ushort Index, ushort Dig, ushort Pick, string Name, FieldItemKind Kind) : INamedValue
{
    /// <summary>
    /// When the field item is picked up, this is the held item ID.
    /// </summary>
    /// <remarks>
    /// If the item cannot be picked up, the <see cref="Index"/> is returned as a fallback rather than <see cref="Item.NONE"/>.
    /// </remarks>
    public ushort HeldItemId => Pick != Item.NONE ? Pick : Dig != Item.NONE ? Dig : Index;
}
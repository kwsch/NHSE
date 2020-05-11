namespace NHSE.Core
{
    /// <summary>
    /// Details for field items -- items with <see cref="Item.ItemId"/> at or above 60,000.
    /// </summary>
    /// <remarks>
    /// These details are extracted from FgMainParam.bcsv
    /// </remarks>
    public class FieldItemDefinition : INamedValue
    {
        /// <summary>
        /// Item ID
        /// </summary>
        public ushort Index { get; }

        /// <summary>
        /// Internal Name of the Item
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Item ID that the player receives if the item is dug up.
        /// </summary>
        /// <remarks>Is <see cref="Item.NONE"/> if it cannot be dug up.</remarks>
        public readonly ushort Dig;

        /// <summary>
        /// Item ID that the player receives if the item is dug up.
        /// </summary>
        /// <remarks>Is <see cref="Item.NONE"/> if it cannot be picked up.</remarks>
        public readonly ushort Pick;

        /// <summary>
        /// Classification of item.
        /// </summary>
        public readonly FieldItemKind Kind;

        public FieldItemDefinition(ushort id, ushort dig, ushort pick, string name, FieldItemKind kind)
        {
            Index = id;
            Dig = dig;
            Pick = pick;
            Name = name;
            Kind = kind;
        }

        /// <summary>
        /// When the field item is picked up, this is the held item ID.
        /// </summary>
        /// <remarks>
        /// If the item cannot be picked up, the <see cref="Index"/> is returned as a fallback rather than <see cref="Item.NONE"/>.
        /// </remarks>
        public ushort HeldItemId => Pick != Item.NONE ? Pick : Dig != Item.NONE ? Dig : Index;
    }
}

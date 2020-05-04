namespace NHSE.Core
{
    public class FieldItemDefinition : INamedValue
    {
        public ushort Index { get; }
        public string Name { get; }

        public readonly FieldItemKind Kind;

        public FieldItemDefinition(ushort id, string name, FieldItemKind kind)
        {
            Index = id;
            Name = name;
            Kind = kind;
        }
    }
}

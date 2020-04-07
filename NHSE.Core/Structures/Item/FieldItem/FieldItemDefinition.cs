namespace NHSE.Core
{
    public class FieldItemDefinition
    {
        public readonly ushort Index;
        public readonly string Name;
        public readonly FieldItemKind Kind;

        public FieldItemDefinition(ushort id, string name, FieldItemKind kind)
        {
            Index = id;
            Name = name;
            Kind = kind;
        }
    }
}

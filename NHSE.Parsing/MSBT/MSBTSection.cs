namespace NHSE.Parsing;

public abstract class MSBTSection(string identifier, byte[] padding)
{
    public string Identifier { get; set; } = identifier;
    public uint SectionSize { get; set; } // Begins after Unknown1
    public byte[] Padding1 { get; set; } = padding; // Always 0x0000 0000
}
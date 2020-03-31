namespace NHSE.Parsing
{
    public class MSBTSection
    {
        public string Identifier;
        public uint SectionSize; // Begins after Unknown1
        public byte[] Padding1; // Always 0x0000 0000
    }
}
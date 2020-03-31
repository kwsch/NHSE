namespace NHSE.Parsing
{
    public class MSBTHeader
    {
        public string Identifier; // MsgStdBn
        public byte[] ByteOrderMark;
        public ushort Unknown1; // Always 0x0000
        public MSBTEncodingByte EncodingByte;
        public byte Unknown2; // Always 0x03
        public ushort NumberOfSections;
        public ushort Unknown3; // Always 0x0000
        public uint FileSize;
        public byte[] Unknown4; // Always 0x0000 0000 0000 0000 0000

        public uint FileSizeOffset;
    }
}
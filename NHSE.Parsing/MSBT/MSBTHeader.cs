using System;

namespace NHSE.Parsing
{
    public class MSBTHeader
    {
        public readonly string Identifier; // MsgStdBn
        public readonly byte[] ByteOrderMark;
        public readonly ushort Unknown1; // Always 0x0000
        public readonly MSBTEncodingByte EncodingByte;
        public readonly byte Unknown2; // Always 0x03
        public readonly ushort NumberOfSections;
        public readonly ushort Unknown3; // Always 0x0000
        public readonly uint FileSize;
        public readonly byte[] Unknown4; // Always 0x0000 0000 0000 0000 0000

        public uint FileSizeOffset;

        internal MSBTHeader(BinaryReaderX br)
        {
            // Header
            Identifier = br.ReadString(8);
            if (Identifier != "MsgStdBn")
                throw new ArgumentException("The file provided is not a valid MSBT file.");

            // Byte Order
            ByteOrderMark = br.ReadBytes(2);
            br.ByteOrder = ByteOrderMark[0] > ByteOrderMark[1] ? ByteOrder.LittleEndian : ByteOrder.BigEndian;

            Unknown1 = br.ReadUInt16();

            // Encoding
            EncodingByte = (MSBTEncodingByte)br.ReadByte();

            Unknown2 = br.ReadByte();
            NumberOfSections = br.ReadUInt16();
            Unknown3 = br.ReadUInt16();
            FileSizeOffset = (uint)br.BaseStream.Position; // Record offset for future use
            FileSize = br.ReadUInt32();
            Unknown4 = br.ReadBytes(10);

            if (FileSize != br.BaseStream.Length)
                throw new ArgumentException("The file provided is not a valid MSBT file.");
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Parsing;

internal class BinaryReaderX(Stream input, ByteOrder byteOrder = ByteOrder.LittleEndian) : BinaryReader(input)
{
    public ByteOrder ByteOrder { get; set; } = byteOrder;

    public override ushort ReadUInt16()
    {
        if (ByteOrder == ByteOrder.LittleEndian)
            return base.ReadUInt16();
        var buffer = base.ReadBytes(sizeof(ushort));
        if (buffer.Length != sizeof(ushort))
            throw new EndOfStreamException();
        return ReadUInt16BigEndian(buffer);
    }

    public override uint ReadUInt32()
    {
        if (ByteOrder == ByteOrder.LittleEndian)
            return base.ReadUInt32();
        var buffer = base.ReadBytes(sizeof(uint));
        if (buffer.Length != sizeof(uint))
            throw new EndOfStreamException();
        return ReadUInt32BigEndian(buffer);
    }

    public string ReadString(int length)
    {
        return Encoding.ASCII.GetString(ReadBytes(length)).TrimEnd('\0');
    }

    public string PeekString(int length = 4)
    {
        List<byte> bytes = [];
        long startOffset = BaseStream.Position;

        for (int i = 0; i < length; i++)
            bytes.Add(ReadByte());

        BaseStream.Seek(startOffset, SeekOrigin.Begin);

        return Encoding.ASCII.GetString(bytes.ToArray());
    }
}
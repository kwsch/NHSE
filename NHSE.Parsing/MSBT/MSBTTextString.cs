using System;
using System.Text;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Parsing;

public sealed record MSBTTextString(Memory<byte> Value, uint Index)
{
    public static readonly MSBTTextString Empty = new(default, 0);

    public override string ToString() => (Index + 1).ToString();

    public string ToString(Encoding encoding) => encoding.GetString(Value.Span);

    public string ToStringNoAtoms() => GetTextWithoutAtoms(Value.Span);

    public static string GetTextWithoutAtoms(ReadOnlySpan<byte> data)
    {
        var sb = new StringBuilder(data.Length / 2);
        for (int i = 0; i < data.Length; i += 2)
        {
            var c = (char)ReadUInt16LittleEndian(data[i..]);
            if (c == 0xE) // atom
            {
                // skip over atom and the u16,u16
                i += 2 * 3;
                var len = ReadUInt16LittleEndian(data[i..]);
                i += len; // skip over extra atom data
                continue;
            }

            if (c == '\0')
                break;
            sb.Append(c);
        }

        return sb.ToString();
    }
}
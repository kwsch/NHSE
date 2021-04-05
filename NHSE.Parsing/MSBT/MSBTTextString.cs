using System;
using System.Text;

namespace NHSE.Parsing
{
    public class MSBTTextString
    {
        public readonly byte[] Value;
        public readonly uint Index;

        public static readonly MSBTTextString Empty = new(Array.Empty<byte>(), 0);

        public MSBTTextString(byte[] v, uint i)
        {
            Value = v;
            Index = i;
        }

        public override string ToString() => (Index + 1).ToString();

        public string ToString(Encoding encoding) => encoding.GetString(Value);

        public string ToStringNoAtoms() => GetTextWithoutAtoms(Value);

        public static string GetTextWithoutAtoms(byte[] data)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < data.Length; i += 2)
            {
                char c = BitConverter.ToChar(data, i);
                if (c == 0xE) // atom
                {
                    // skip over atom and the u16,u16
                    i += 2 * 3;
                    var len = BitConverter.ToUInt16(data, i);
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
}

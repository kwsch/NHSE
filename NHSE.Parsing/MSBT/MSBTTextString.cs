using System.Text;

namespace NHSE.Parsing
{
    public class MSBTTextString
    {
        public readonly byte[] Value;
        public readonly uint Index;

        public MSBTTextString(byte[] v, uint i)
        {
            Value = v;
            Index = i;
        }

        public override string ToString() => (Index + 1).ToString();

        public string ToString(Encoding encoding) => encoding.GetString(Value);
    }
}
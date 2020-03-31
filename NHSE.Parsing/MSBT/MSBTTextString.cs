using System.Text;

namespace NHSE.Parsing
{
    public class MSBTTextString : IMSBTEntry
    {
        public byte[] Value { get; set; }
        public uint Index { get; set; }

        public override string ToString()
        {
            return (Index + 1).ToString();
        }

        public string ToString(Encoding encoding)
        {
            return encoding.GetString(Value);
        }
    }
}
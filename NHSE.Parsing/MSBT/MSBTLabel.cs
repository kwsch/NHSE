using System.Text;

namespace NHSE.Parsing
{
    public class MSBTLabel : IMSBTEntry
    {
        public uint Length;
        public string Name;
        public MSBTTextString String;

        public byte[] Value
        {
            get => String.Value;
            set => String.Value = value;
        }

        public uint Index { get; set; }
        public override string ToString() => Length > 0 ? Name : (Index + 1).ToString();
        public string ToString(Encoding encoding) => Length > 0 ? Name : (Index + 1).ToString();
    }
}
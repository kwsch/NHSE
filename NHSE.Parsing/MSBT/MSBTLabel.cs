using System.Text;

namespace NHSE.Parsing
{
    public class MSBTLabel
    {
        public uint Length;
        public string Name;
        public MSBTTextString String;

        public uint Index { get; set; }
        public override string ToString() => Length > 0 ? Name : (Index + 1).ToString();
        public string ToString(Encoding encoding) => encoding.GetString(String.Value);
    }
}
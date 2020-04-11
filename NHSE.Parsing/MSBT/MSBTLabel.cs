using System.Text;

namespace NHSE.Parsing
{
    public class MSBTLabel
    {
        public uint Length;
        public readonly string Name;
        public MSBTTextString String;

        public MSBTLabel(string name)
        {
            Name = name;
            String = MSBTTextString.Empty;
        }

        public uint Index { get; set; }
        public override string ToString() => Length > 0 ? Name : (Index + 1).ToString();
        public string ToString(Encoding encoding) => encoding.GetString(String.Value);
    }
}
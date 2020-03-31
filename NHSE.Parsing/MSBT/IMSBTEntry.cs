using System.Text;

namespace NHSE.Parsing
{
    public interface IMSBTEntry
    {
        string ToString();
        string ToString(Encoding encoding);
        byte[] Value { get; set; }
        uint Index { get; set; }
    }
}
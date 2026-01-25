using System.Text;

namespace NHSE.Parsing;

public sealed record MSBTLabel
{
    public required uint Length { get; init; }
    public required uint Index { get; init; }
    public required string Name { get; init; }

    public MSBTTextString String { get; set; } = MSBTTextString.Empty;

    public override string ToString() => Length > 0 ? Name : (Index + 1).ToString();
    public string ToString(Encoding encoding) => encoding.GetString(String.Value.Span);
}
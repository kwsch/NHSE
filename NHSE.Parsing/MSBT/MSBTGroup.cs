namespace NHSE.Parsing;

public sealed record MSBTGroup
{
    public required uint NumberOfLabels { get; init; }
    public required uint Offset { get; init; }
}
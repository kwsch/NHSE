namespace NHSE.Parsing;

public sealed record BCSVFieldParam(uint ColumnKey, int Offset, int Index)
{
    public const int SIZE = 8;
}
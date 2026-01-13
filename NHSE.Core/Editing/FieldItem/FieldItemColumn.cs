namespace NHSE.Core;

public sealed class FieldItemColumn
{
    /// <summary> X Coordinate within the Field Item Layer </summary>
    public readonly int X;

    /// <summary> Y Coordinate within the Field Item Layer </summary>
    public readonly int Y;

    /// <summary> Offset relative to the start of the Field Item Layer </summary>
    public readonly int Offset;

    public readonly byte[] Data;

    public FieldItemColumn(int x, int y, int offset, byte[] data)
    {
        X = x;
        Y = y;
        Offset = offset;
        Data = data;
    }
}
namespace NHSE.Parsing
{
    public class BCSVFieldParam
    {
        public const int SIZE = 8;
        public readonly uint ColumnKey;
        public readonly int Offset;
        public readonly int Index;

        public BCSVFieldParam(uint key, int offset, int index)
        {
            ColumnKey = key;
            Offset = offset;
            Index = index;
        }
    }
}
namespace NHSE.Core
{
    /// <summary>
    /// Navigation metadata for acre coordinates.
    /// </summary>
    public class AcreCoordinate
    {
        public readonly string Name;
        public readonly int X, Y;

        public AcreCoordinate(int x, int y) : this((char)('0' + x), (char)('A' + y), x, y) { }

        public AcreCoordinate(char xName, char yName, int x, int y)
        {
            Name = $"{yName}{xName}";
            X = x;
            Y = y;
        }

        public static AcreCoordinate[] GetGrid(int width, int height)
        {
            var result = new AcreCoordinate[width * height];
            int i = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    result[i++] = new AcreCoordinate(x, y);
            }
            return result;
        }

        public static AcreCoordinate[] GetGridWithExterior(int width, int height)
        {
            var result = new AcreCoordinate[width * height];
            int i = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var xn = (x == 0) ? '<' : x == width - 1 ? '>' : (char)('0' + x - 1);
                    var yn = (y == 0) ? '^' : y == height - 1 ? 'V' : (char)('A' + y - 1);
                    result[i++] = new AcreCoordinate(xn, yn, x, y);
                }
            }
            return result;
        }
    }
}

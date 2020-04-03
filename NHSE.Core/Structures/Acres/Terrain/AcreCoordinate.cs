namespace NHSE.Core
{
    public class AcreCoordinate
    {
        public readonly string Name;
        public readonly int X, Y;

        public AcreCoordinate(int x, int y)
        {
            char yName = (char)('A' + y);
            char xName = (char)('0' + x);
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
    }
}

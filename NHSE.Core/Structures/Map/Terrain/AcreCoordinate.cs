using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace NHSE.Core;

/// <summary>
/// Navigation metadata for acre coordinates.
/// </summary>
[DebuggerDisplay("{Name} ({X}, {Y})")]
public readonly record struct AcreCoordinate(char XChar, char YChar, byte X, byte Y)
{
    public const int CountTerrainAcreWidth = 7;
    public const int CountTerrainAcreHeight = 6;
    public const int CountAcreExteriorWidth = 9;
    public const int CountAcreExteriorHeight = 8;

    /// <summary>
    /// Terrain Acre grid coordinates.
    /// </summary>
    public static readonly AcreCoordinate[] Acres = GetGrid(CountTerrainAcreWidth, CountTerrainAcreHeight);

    /// <summary>
    /// Entire grid including exterior acre coordinates (bordered by acres of deep sea->shoreline=>terrain).
    /// </summary>
    public static readonly AcreCoordinate[] Exterior = GetGridWithExterior(CountAcreExteriorWidth, CountAcreExteriorHeight);

    public string Name => $"{YChar}{XChar}";

    private AcreCoordinate(byte x, byte y) : this((char)('0' + x), (char)('A' + y), x, y) { }

    private static AcreCoordinate[] GetGrid([ConstantExpected] byte width, [ConstantExpected] byte height)
    {
        var result = new AcreCoordinate[width * height];
        int i = 0;
        for (byte y = 0; y < height; y++)
        {
            for (byte x = 0; x < width; x++)
                result[i++] = new AcreCoordinate(x, y);
        }
        return result;
    }

    private static AcreCoordinate[] GetGridWithExterior([ConstantExpected] int width, [ConstantExpected] int height)
    {
        var result = new AcreCoordinate[width * height];
        int i = 0;
        for (byte y = 0; y < height; y++)
        {
            for (byte x = 0; x < width; x++)
            {
                var xn = (x == 0) ? '<' : x == width - 1 ? '>' : (char)('0' + x - 1);
                var yn = (y == 0) ? '^' : y == height - 1 ? 'V' : (char)('A' + y - 1);
                result[i++] = new AcreCoordinate(xn, yn, x, y);
            }
        }
        return result;
    }
}
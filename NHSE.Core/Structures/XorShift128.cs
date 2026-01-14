namespace NHSE.Core;

/// <summary>
/// Xorshift128 RNG Implementation (xor128)
/// <see href="https://en.wikipedia.org/wiki/Xorshift#Example_implementation"/>
/// </summary>
internal ref struct XorShift128
{
    private uint a, b, c, d;
    private const int Mersenne = 0x6C078965;

    /// <summary>
    /// Initialize the generator from a seed.
    /// </summary>
    /// <param name="seed">Ticks, usually.</param>
    public XorShift128(uint seed)
    {
        // Unrolled Mersenne Twister initialization loop
        a = (Mersenne * (seed ^ (seed >> 30))) + 1;
        b = (Mersenne * (  a  ^ (  a  >> 30))) + 2;
        c = (Mersenne * (  b  ^ (  b  >> 30))) + 3;
        d = (Mersenne * (  c  ^ (  c  >> 30))) + 4;
    }

    /// <summary>
    /// Returns the next random uint.
    /// </summary>
    public uint Next()
    {
        uint t = a;
        a = b;
        b = c;
        c = d;
        t ^= t << 11;
        t ^= t >> 8;
        return d = t ^ d ^ (d >> 19);
    }

    public ulong Next64() => ((ulong)Next() << 32) | Next();
}
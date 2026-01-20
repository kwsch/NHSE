using System;

namespace NHSE.Injection;

public static class Decoder
{
    private static bool IsNum(char c) => (uint)(c - '0') <= 9;
    private static bool IsHexUpper(char c) => (uint)(c - 'A') <= 5;

    public static byte[] ConvertHexByteStringToBytes(ReadOnlySpan<byte> bytes)
    {
        var dest = new byte[bytes.Length / 2];
        LoadHexBytesTo(bytes, dest, 2);
        return dest;
    }

    public static void LoadHexBytesTo(ReadOnlySpan<byte> str, Span<byte> dest, int tupleSize)
    {
        // The input string is 2-char hex values optionally separated.
        // The destination array should always be larger or equal than the bytes written. Let the runtime bounds check us.
        // Iterate through the string without allocating.
        for (int i = 0, j = 0; i < str.Length; i += tupleSize)
            dest[j++] = DecodeTuple((char)str[i + 0], (char)str[i + 1]);
    }

    private static byte DecodeTuple(char _0, char _1)
    {
        return (byte)(DecodeChar(_0) << 4 | DecodeChar(_1));

        static int DecodeChar(char x)
        {
            if (char.IsAsciiDigit(x))
                return (byte)(x - '0');
            if (char.IsAsciiHexDigitUpper(x))
                return (byte)(x - 'A' + 10);
            if (char.IsAsciiHexDigitLower(x))
                return (byte)(x - 'a' + 10);
            throw new ArgumentOutOfRangeException(nameof(_0));
        }
    }
}
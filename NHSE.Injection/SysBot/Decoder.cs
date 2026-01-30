using System;

namespace NHSE.Injection;

public static class Decoder
{
    public static byte[] ConvertHexByteStringToBytes(byte[] bytes)
        => Convert.FromHexString(bytes.AsSpan(0, bytes.Length - 1));
}
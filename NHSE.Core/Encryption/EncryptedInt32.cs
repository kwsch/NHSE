using System;
using System.Diagnostics;
using System.Numerics;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// Represents an encrypted 32-bit integer with associated encryption parameters.
/// </summary>
[DebuggerDisplay("{Value}")]
public sealed record EncryptedInt32(uint OriginalEncrypted, ushort Adjust = 0, byte Shift = 0, byte Checksum = 0)
{
    // Encryption constant used to encrypt the int.
    private const uint ENCRYPTION_CONSTANT = 0x80E32B11;
    // Base shift count used in the encryption.
    private const byte SHIFT_BASE = 3;

    public uint Value { get; set; } = Decrypt(OriginalEncrypted, Shift, Adjust);

    public static implicit operator uint(EncryptedInt32 encryptedInt32) => encryptedInt32.Value;

    public void Write(Span<byte> data) => Write(this, data);
    public void Write(byte[] data, int offset) => Write(data.AsSpan(offset));

    // Calculates a checksum for a given encrypted value
    // Checksum calculation is every byte of the encrypted in added together minus 0x2D.
    public static byte CalculateChecksum(uint value)
    {
        var byteSum = value + (value >> 16) + (value >> 24) + (value >> 8);
        return (byte)(byteSum - 0x2D);
    }

    public static uint Decrypt(uint encrypted, byte shift, ushort adjust)
    {
        var rotated = BitOperations.RotateRight(encrypted, shift + SHIFT_BASE);
        return rotated + ENCRYPTION_CONSTANT - adjust;
    }

    public static uint Encrypt(uint value, byte shift, ushort adjust)
    {
        var adjusted = value + adjust - ENCRYPTION_CONSTANT;
        return BitOperations.RotateLeft(adjusted, shift + SHIFT_BASE);
    }

    public static EncryptedInt32 ReadVerify(ReadOnlySpan<byte> data, int offset)
    {
        var val = Read(data[offset..]);
        if (val.Checksum != CalculateChecksum(val.OriginalEncrypted))
            throw new ArgumentException($"Failed to verify the {nameof(EncryptedInt32)} at {nameof(offset)} 0x{offset:X8}.");
        return val;
    }

    public static EncryptedInt32 Read(ReadOnlySpan<byte> data)
    {
        var encrypted = ReadUInt32LittleEndian(data);
        var adjust = ReadUInt16LittleEndian(data[4..]);
        var shift = data[6];
        var chk = data[7];
        return new EncryptedInt32(encrypted, adjust, shift, chk);
    }

    public static void Write(EncryptedInt32 value, Span<byte> data)
    {
        var encrypted = Encrypt(value.Value, value.Shift, value.Adjust);
        WriteUInt32LittleEndian(data, encrypted);
        WriteUInt16LittleEndian(data[4..], value.Adjust);
        data[6] = value.Shift;
        data[7] = CalculateChecksum(encrypted);
    }
}
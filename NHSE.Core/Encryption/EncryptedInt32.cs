using System;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

public sealed class EncryptedInt32
{
    // Encryption constant used to encrypt the int.
    private const uint ENCRYPTION_CONSTANT = 0x80E32B11;
    // Base shift count used in the encryption.
    private const byte SHIFT_BASE = 3;

    public readonly uint OriginalEncrypted;
    public readonly ushort Adjust;
    public readonly byte Shift;
    public readonly byte Checksum;

    public uint Value;

    public override string ToString() => Value.ToString();

    public EncryptedInt32(uint encryptedValue, ushort adjust = 0, byte shift = 0, byte checksum = 0)
    {
        OriginalEncrypted = encryptedValue;
        Adjust = adjust;
        Shift = shift;
        Checksum = checksum;
        Value = Decrypt(encryptedValue, shift, adjust);
    }

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
        // Decrypt the encrypted int using the given params.
        ulong val = ((ulong) encrypted) << ((32 - SHIFT_BASE - shift) & 0x3F);
        val += val >> 32;
        return ENCRYPTION_CONSTANT - adjust + (uint)val;
    }

    public static uint Encrypt(uint value, byte shift, ushort adjust)
    {
        ulong val = (ulong) (value + unchecked(adjust - ENCRYPTION_CONSTANT)) << (shift + SHIFT_BASE);
        return (uint) ((val >> 32) + val);
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
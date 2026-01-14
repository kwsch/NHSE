using System;
using System.Security.Cryptography;

namespace NHSE.Core;

/// <summary>
/// AES Counter (CTR) mode encryption/decryption using modern .NET one-shot APIs.
/// </summary>
internal static class AesCtr
{
    private const int BlockSize = 16;

    /// <summary>
    /// Encrypts or decrypts data in-place using AES-CTR mode.
    /// </summary>
    /// <remarks>AES-CTR is symmetric, so encryption and decryption are the same operation.</remarks>
    /// <param name="data">Data to transform in-place.</param>
    /// <param name="key">16-byte AES key.</param>
    /// <param name="counter">16-byte initial counter value (will be modified).</param>
    public static void Crypt(Span<byte> data, ReadOnlySpan<byte> key, Span<byte> counter)
    {
        using var aes = Aes.Create();
        aes.Key = key.ToArray();
        aes.Mode = CipherMode.ECB;

        Span<byte> encryptedCounter = stackalloc byte[BlockSize];

        for (int offset = 0; offset < data.Length; offset += BlockSize)
        {
            // Encrypt the counter block using ECB mode
            aes.EncryptEcb(counter, encryptedCounter, PaddingMode.None);

            // XOR the encrypted counter with the data block
            int blockLength = Math.Min(BlockSize, data.Length - offset);
            var dataBlock = data.Slice(offset, blockLength);

            for (int i = 0; i < blockLength; i++)
                dataBlock[i] ^= encryptedCounter[i];

            // Increment counter (big-endian)
            IncrementCounter(counter);
        }
    }

    /// <summary>
    /// Encrypts data using AES-CTR mode, returning a new buffer.
    /// </summary>
    /// <param name="data">Data to encrypt.</param>
    /// <param name="key">16-byte AES key.</param>
    /// <param name="counter">16-byte initial counter value (will be copied, not modified).</param>
    /// <returns>New buffer containing the encrypted data.</returns>
    public static byte[] Encrypt(ReadOnlySpan<byte> data, ReadOnlySpan<byte> key, ReadOnlySpan<byte> counter)
    {
        var result = new byte[data.Length];
        data.CopyTo(result);

        Span<byte> counterCopy = stackalloc byte[BlockSize];
        counter.CopyTo(counterCopy);

        Crypt(result, key, counterCopy);
        return result;
    }

    private static void IncrementCounter(Span<byte> counter)
    {
        for (int i = counter.Length - 1; i >= 0; i--)
        {
            if (++counter[i] != 0)
                break;
        }
    }
}

using System;

namespace NHSE.Core
{
    /// <summary>
    /// MurmurHash implementation used by Animal Crossing New Horizons
    /// </summary>
    public static class Murmur3
    {
        private static uint Murmur32_Scramble(uint k)
        {
            k = (k * 0x16A88000) | ((k * 0xCC9E2D51) >> 17);
            k *= 0x1B873593;
            return k;
        }

        /// <summary>
        /// Updates the hash at the specified offset, using the input parameters.
        /// </summary>
        /// <param name="data">Data to hash</param>
        /// <param name="offset">Where the data-to-be-hashed starts</param>
        /// <param name="size">Amount of data to hash</param>
        /// <param name="seed">Initial Murmur seed (optional)</param>
        /// <returns>Calculated hash.</returns>
        public static uint GetMurmur3Hash(byte[] data, int offset, uint size, uint seed = 0)
        {
            uint checksum = seed;
            if (size > 3)
            {
                for (var i = 0; i < (size / sizeof(uint)); i++)
                {
                    var val = BitConverter.ToUInt32(data, offset);
                    checksum ^= Murmur32_Scramble(val);
                    checksum = (checksum >> 19) | (checksum << 13);
                    checksum = (checksum * 5) + 0xE6546B64;
                    offset += 4;
                }
            }

            var remainder = size % sizeof(uint);
            if (remainder != 0)
            {
                uint val = BitConverter.ToUInt32(data, (int)((offset + size) - remainder));
                for (var i = 0; i < (sizeof(uint) - remainder); i++)
                    val >>= 8;
                checksum ^= Murmur32_Scramble(val);
            }

            checksum ^= size;
            checksum ^= checksum >> 16;
            checksum *= 0x85EBCA6B;
            checksum ^= checksum >> 13;
            checksum *= 0xC2B2AE35;
            checksum ^= checksum >> 16;
            return checksum;
        }

        /// <summary>
        /// Updates the hash at the specified offset, using the input parameters.
        /// </summary>
        /// <param name="data">Data to hash</param>
        /// <param name="hashOffset">Offset to write the hash</param>
        /// <param name="readOffset">Where the data-to-be-hashed starts</param>
        /// <param name="readSize">Amount of data to hash</param>
        /// <returns>Calculated hash that was written back to the data.</returns>
        public static uint UpdateMurmur32(byte[] data, int hashOffset, int readOffset, uint readSize)
        {
            var newHash = GetMurmur3Hash(data, readOffset, readSize);
            var hashBytes = BitConverter.GetBytes(newHash);
            hashBytes.CopyTo(data, hashOffset);
            return newHash;
        }

        /// <summary>
        /// Checks the hash at the specified offset to see if the stored value matches the calculated value.
        /// </summary>
        /// <param name="data">Data to hash</param>
        /// <param name="hashOffset">Offset to write the hash</param>
        /// <param name="readOffset">Where the data-to-be-hashed starts</param>
        /// <param name="readSize">Amount of data to hash</param>
        /// <returns>Calculated hash matches the currently stored hash.</returns>
        public static bool VerifyMurmur32(byte[] data, int hashOffset, int readOffset, uint readSize)
            => BitConverter.ToUInt32(data, hashOffset) == GetMurmur3Hash(data, readOffset, readSize);
    }
}

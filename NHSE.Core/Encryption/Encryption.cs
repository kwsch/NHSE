using System;

namespace NHSE.Core
{
    public static class Encryption
    {
        private static byte[] GetParam(uint[] data, in int index)
        {
            var sead = new SEADRandom(data[data[index] & 0x7F]);
            var prms = data[data[index + 1] & 0x7F] & 0x7F;

            var rndRollCount = (prms & 0xF) + 1;
            for (var i = 0; i < rndRollCount; i++)
                sead.GetU64();

            var result = new byte[0x10];
            for (var i = 0; i < result.Length; i++)
                result[i] = (byte)(sead.GetU32() >> 24);

            return result;
        }

        /// <summary>
        /// Decrypts the <see cref="encData"/> using the <see cref="headerData"/> in place.
        /// </summary>
        /// <param name="headerData">Header Data</param>
        /// <param name="encData">Encrypted SaveData</param>
        public static void Decrypt(byte[] headerData, byte[] encData)
        {
            // First 256 bytes go unused
            var importantData = new uint[0x80];
            Buffer.BlockCopy(headerData, 0x100, importantData, 0, 0x200);

            // Set up Key
            var key = GetParam(importantData, 0);

            // Set up counter
            var counter = GetParam(importantData, 2);

            // Do the AES
            using var aesCtr = new Aes128CounterMode(counter);
            var transform = aesCtr.CreateDecryptor(key, counter);

            transform.TransformBlock(encData, 0, encData.Length, encData, 0);
        }

        private static CryptoFile GenerateHeaderFile(uint seed, byte[] versionData)
        {
            // Generate 128 Random uints which will be used for params
            var random = new SEADRandom(seed);
            var encryptData = new uint[128];
            for (var i = 0; i < encryptData.Length; i++)
                encryptData[i] = random.GetU32();

            var headerData = new byte[0x300];
            Buffer.BlockCopy(versionData, 0, headerData, 0, 0x100);
            Buffer.BlockCopy(encryptData, 0, headerData, 0x100, 0x200);
            return new CryptoFile(headerData, GetParam(encryptData, 0), GetParam(encryptData, 2));
        }

        /// <summary>
        /// Encrypts the <see cref="data"/> (savedata) using the provided <see cref="seed"/>.
        /// </summary>
        /// <param name="data">SaveData to encrypt</param>
        /// <param name="seed">Seed to encrypt with</param>
        /// <param name="versionData">Version data to encrypt with</param>
        /// <returns>Encrypted SaveData, and associated headerData</returns>
        public static EncryptedSaveFile Encrypt(byte[] data, uint seed, byte[] versionData)
        {
            // Generate header file and get key and counter
            var header = GenerateHeaderFile(seed, versionData);

            // Encrypt file
            using var aesCtr = new Aes128CounterMode(header.Ctr);
            var transform = aesCtr.CreateEncryptor(header.Key, header.Ctr);
            var encData = new byte[data.Length];
            transform.TransformBlock(data, 0, data.Length, encData, 0);

            return new EncryptedSaveFile(encData, header.Data);
        }
    }
}

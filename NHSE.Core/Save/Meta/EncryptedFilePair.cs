using System;
using System.Collections.Generic;
using System.IO;

namespace NHSE.Core
{
    /// <summary>
    /// Represents two files -- <see cref="DataPath"/> and <see cref="HeaderPath"/> and their decrypted data.
    /// </summary>
    public abstract class EncryptedFilePair
    {
        public readonly byte[] Data;
        public readonly byte[] Header;

        public readonly FileHeaderInfo Info;

        public readonly string DataPath;
        public readonly string HeaderPath;
        public readonly string NameData;
        public readonly string NameHeader;

        protected EncryptedFilePair(string folder, string name)
        {
            NameData = $"{name}.dat";
            NameHeader = $"{name}Header.dat";
            var hdr = Path.Combine(folder, NameHeader);
            var dat = Path.Combine(folder, NameData);

            var hd = File.ReadAllBytes(hdr);
            var md = File.ReadAllBytes(dat);

            Encryption.Decrypt(hd, md);

            Header = hd;
            Data = md;
            DataPath = dat;
            HeaderPath = hdr;

            Info = Header.Slice(0, FileHeaderInfo.SIZE).ToClass<FileHeaderInfo>();
        }

        public void Save(uint seed)
        {
            var encrypt = Encryption.Encrypt(Data, seed, Header);
            File.WriteAllBytes(DataPath, encrypt.Data);
            File.WriteAllBytes(HeaderPath, encrypt.Header);
        }

        /// <summary>
        /// Updates all hashes of <see cref="Data"/>.
        /// </summary>
        public void Hash()
        {
            var ver = Info.GetKnownRevisionIndex();
            var hash = RevisionChecker.HashInfo[ver];
            var details = hash.GetFile(NameData);
            if (details == null)
                throw new ArgumentNullException(nameof(NameData));
            foreach (var h in details.HashRegions)
                Murmur3.UpdateMurmur32(Data, h.HashOffset, h.BeginOffset, (uint)h.Size);
        }

        public IEnumerable<FileHashRegion> InvalidHashes()
        {
            var ver = Info.GetKnownRevisionIndex();
            var hash = RevisionChecker.HashInfo[ver];
            var details = hash.GetFile(NameData);
            if (details == null)
                throw new ArgumentNullException(nameof(NameData));
            foreach (var h in details.HashRegions)
            {
                var current = Murmur3.GetMurmur3Hash(Data, h.BeginOffset, (uint)h.Size);
                var saved = BitConverter.ToUInt32(Data, h.HashOffset);
                if (current != saved)
                    yield return h;
            }
        }

        protected string GetString(int offset, int maxLength) => StringUtil.GetString(Data, offset, maxLength);
        protected static byte[] GetBytes(string value, int maxLength) => StringUtil.GetBytes(value, maxLength);
    }
}
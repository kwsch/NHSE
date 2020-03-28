using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NHSE.Core
{
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

            var decrypted = Encryption.Decrypt(hd, md);

            Header = hd;
            Data = decrypted;
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

        public string GetString(int offset, int maxLength)
        {
            var str = Encoding.Unicode.GetString(Data, offset, maxLength * 2);
            return StringUtil.TrimFromZero(str);
        }

        public static byte[] GetBytes(string value, int maxLength)
        {
            if (value.Length > maxLength)
                value = value.Substring(0, maxLength);
            else if (value.Length < maxLength)
                value = value.PadRight(maxLength, '\0');
            return Encoding.Unicode.GetBytes(value);
        }
    }
}
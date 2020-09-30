using System.Collections.Generic;
using System.Linq;

namespace NHSE.Core
{
#pragma warning disable CA2237 // Mark ISerializable types with serializable
    public sealed class FileHashInfo : Dictionary<uint, FileHashDetails>
#pragma warning restore CA2237 // Mark ISerializable types with serializable
    {
        public FileHashInfo(IEnumerable<FileHashDetails> hashSets)
        {
            foreach (var hashSet in hashSets)
                this[hashSet.FileSize] = hashSet;
        }

        public FileHashDetails? GetFile(string nameData)
        {
            return this.FirstOrDefault(z => z.Value.FileName == nameData).Value;
        }
    }
}

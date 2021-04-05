using System.Collections.Generic;
using System.Linq;

namespace NHSE.Core
{
    public sealed class FileHashInfo
    {
        private readonly IReadOnlyDictionary<uint, FileHashDetails> List;

        public FileHashInfo(FileHashInfo dupe) : this(dupe.List.Values) { }

        public FileHashInfo(IEnumerable<FileHashDetails> hashSets)
        {
            var list = new Dictionary<uint, FileHashDetails>();
            foreach (var hashSet in hashSets)
                list[hashSet.FileSize] = hashSet;
            List = list;
        }

        public FileHashDetails? GetFile(string nameData)
        {
            return List.Values.FirstOrDefault(z => z.FileName == nameData);
        }
    }
}

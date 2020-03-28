using System.Collections.Generic;

namespace NHSE.Core
{
    /// <summary>
    /// Contains the <see cref="HashRegions"/> for a <see cref="FileName"/>.
    /// </summary>
    public sealed class FileHashDetails
    {
        /// <summary>
        /// Name of the File that these <see cref="HashRegions"/> apply to.
        /// </summary>
        public readonly string FileName;

        /// <summary>
        /// Expected file size of the <see cref="FileName"/>.
        /// </summary>
        public readonly uint FileSize;

        /// <summary>
        /// Hash specs that are done in this file.
        /// </summary>
        public readonly IReadOnlyList<FileHashRegion> HashRegions;

        public FileHashDetails(string fileName, uint fileSize, IReadOnlyList<FileHashRegion> regions)
        {
            FileName = fileName;
            FileSize = fileSize;
            HashRegions = regions;
        }
    }
}
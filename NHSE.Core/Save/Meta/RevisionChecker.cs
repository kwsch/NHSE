using System;
using System.Collections.Generic;

namespace NHSE.Core
{
    /// <summary>
    /// Logic for detecting a <see cref="EncryptedFilePair"/> revision.
    /// </summary>
    public static class RevisionChecker
    {
        // Patches where the sizes of individual files changed
        private static readonly SaveFileSizes[] SizesByRevision =
        {
            new SaveFileSizes(0xAC0938, 0x6BC50, 0x263B4, 0xB44580, 0x69508), // 1.0.0
            new SaveFileSizes(0xAC2AA0, 0x6BED0, 0x263C0, 0xB44590, 0x69560), // 1.1.0
            new SaveFileSizes(0xACECD0, 0x6D6C0, 0x2C9C0, 0xB44590, 0x69560), // 1.2.0
        };

        private static readonly FileHeaderInfo[] RevisionInfo =
        {
            new FileHeaderInfo { Major = 0x67, Minor = 0x6F, HeaderRevision = 0, Unk1 = 2, SaveRevision = 0, Unk2 = 2 }, // 1.0.0
            new FileHeaderInfo { Major = 0x6D, Minor = 0x78, HeaderRevision = 0, Unk1 = 2, SaveRevision = 1, Unk2 = 2 }, // 1.1.0
            new FileHeaderInfo { Major = 0x6D, Minor = 0x78, HeaderRevision = 0, Unk1 = 2, SaveRevision = 2, Unk2 = 2 }, // 1.1.1
            new FileHeaderInfo { Major = 0x6D, Minor = 0x78, HeaderRevision = 0, Unk1 = 2, SaveRevision = 3, Unk2 = 2 }, // 1.1.2
            new FileHeaderInfo { Major = 0x6D, Minor = 0x78, HeaderRevision = 0, Unk1 = 2, SaveRevision = 4, Unk2 = 2 }, // 1.1.3
            new FileHeaderInfo { Major = 0x6D, Minor = 0x78, HeaderRevision = 0, Unk1 = 2, SaveRevision = 5, Unk2 = 2 }, // 1.1.4
            new FileHeaderInfo { Major = 0x20006, Minor = 0x20008, HeaderRevision = 0, Unk1 = 2, SaveRevision = 6, Unk2 = 2 }, // 1.2.0
            new FileHeaderInfo { Major = 0x20006, Minor = 0x20008, HeaderRevision = 0, Unk1 = 2, SaveRevision = 7, Unk2 = 2 }, // 1.2.1
        };

        public static readonly IReadOnlyList<SaveFileSizes> SizeInfo = new[]
        {
            SizesByRevision[0], // 1.0.0
            SizesByRevision[1], // 1.1.0
            SizesByRevision[1], // 1.1.1
            SizesByRevision[1], // 1.1.2
            SizesByRevision[1], // 1.1.3
            SizesByRevision[1], // 1.1.4
            SizesByRevision[2], // 1.2.0
            SizesByRevision[2], // 1.2.1
        };

        public static readonly IReadOnlyList<FileHashInfo> HashInfo = new[]
        {
            FileHashRevision.REV_100, // 1.0.0
            FileHashRevision.REV_110, // 1.1.0
            FileHashRevision.REV_110, // 1.1.1
            FileHashRevision.REV_110, // 1.1.2
            FileHashRevision.REV_110, // 1.1.3
            FileHashRevision.REV_110, // 1.1.4
            FileHashRevision.REV_120, // 1.2.0
            FileHashRevision.REV_120, // 1.2.1
        };

        public static bool IsRevisionKnown(this FileHeaderInfo info) => info.GetKnownRevisionIndex() >= 0;
        public static int GetKnownRevisionIndex(this FileHeaderInfo info) => Array.FindIndex(RevisionInfo, z => z.Equals(info));
    }
}
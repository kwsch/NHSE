using System;
using System.Collections.Generic;
using static NHSE.Core.FileHashRevision;

namespace NHSE.Core
{
    /// <summary>
    /// Logic for detecting a <see cref="EncryptedFilePair"/> revision.
    /// </summary>
    public static class RevisionChecker
    {
        /// <summary>
        /// Unique save file size list by patch.
        /// </summary>
        private static readonly SaveFileSizes[] SizesByRevision =
        {
            new(REV_100_MAIN, REV_100_PERSONAL, REV_100_PHOTO, REV_100_POSTBOX, REV_100_PROFILE), // 1.0.0
            new(REV_110_MAIN, REV_110_PERSONAL, REV_110_PHOTO, REV_110_POSTBOX, REV_110_PROFILE), // 1.1.0
            new(REV_120_MAIN, REV_120_PERSONAL, REV_120_PHOTO, REV_120_POSTBOX, REV_120_PROFILE), // 1.2.0
            new(REV_130_MAIN, REV_130_PERSONAL, REV_130_PHOTO, REV_130_POSTBOX, REV_130_PROFILE), // 1.3.0
            new(REV_140_MAIN, REV_140_PERSONAL, REV_140_PHOTO, REV_140_POSTBOX, REV_140_PROFILE), // 1.4.0
            new(REV_150_MAIN, REV_150_PERSONAL, REV_150_PHOTO, REV_150_POSTBOX, REV_150_PROFILE), // 1.5.0
            new(REV_160_MAIN, REV_160_PERSONAL, REV_160_PHOTO, REV_160_POSTBOX, REV_160_PROFILE), // 1.6.0
            new(REV_170_MAIN, REV_170_PERSONAL, REV_170_PHOTO, REV_170_POSTBOX, REV_170_PROFILE), // 1.7.0
            new(REV_180_MAIN, REV_180_PERSONAL, REV_180_PHOTO, REV_180_POSTBOX, REV_180_PROFILE), // 1.8.0
            new(REV_190_MAIN, REV_190_PERSONAL, REV_190_PHOTO, REV_190_POSTBOX, REV_190_PROFILE), // 1.9.0
            new(REV_1100_MAIN,REV_1100_PERSONAL,REV_1100_PHOTO,REV_1100_POSTBOX,REV_1100_PROFILE),// 1.10.0
        };

        private static readonly FileHeaderInfo[] RevisionInfo =
        {
            new() { Major = 0x00067, Minor = 0x0006F, HeaderRevision = 0, Unk1 = 2, SaveRevision = 00, Unk2 = 2 }, // 1.0.0
            new() { Major = 0x0006D, Minor = 0x00078, HeaderRevision = 0, Unk1 = 2, SaveRevision = 01, Unk2 = 2 }, // 1.1.0
            new() { Major = 0x0006D, Minor = 0x00078, HeaderRevision = 0, Unk1 = 2, SaveRevision = 02, Unk2 = 2 }, // 1.1.1
            new() { Major = 0x0006D, Minor = 0x00078, HeaderRevision = 0, Unk1 = 2, SaveRevision = 03, Unk2 = 2 }, // 1.1.2
            new() { Major = 0x0006D, Minor = 0x00078, HeaderRevision = 0, Unk1 = 2, SaveRevision = 04, Unk2 = 2 }, // 1.1.3
            new() { Major = 0x0006D, Minor = 0x00078, HeaderRevision = 0, Unk1 = 2, SaveRevision = 05, Unk2 = 2 }, // 1.1.4
            new() { Major = 0x20006, Minor = 0x20008, HeaderRevision = 0, Unk1 = 2, SaveRevision = 06, Unk2 = 2 }, // 1.2.0
            new() { Major = 0x20006, Minor = 0x20008, HeaderRevision = 0, Unk1 = 2, SaveRevision = 07, Unk2 = 2 }, // 1.2.1
            new() { Major = 0x40002, Minor = 0x40008, HeaderRevision = 0, Unk1 = 2, SaveRevision = 08, Unk2 = 2 }, // 1.3.0
            new() { Major = 0x40002, Minor = 0x40008, HeaderRevision = 0, Unk1 = 2, SaveRevision = 09, Unk2 = 2 }, // 1.3.1
            new() { Major = 0x50001, Minor = 0x5000B, HeaderRevision = 0, Unk1 = 2, SaveRevision = 10, Unk2 = 2 }, // 1.4.0
            new() { Major = 0x50001, Minor = 0x5000B, HeaderRevision = 0, Unk1 = 2, SaveRevision = 11, Unk2 = 2 }, // 1.4.1
            new() { Major = 0x50001, Minor = 0x5000B, HeaderRevision = 0, Unk1 = 2, SaveRevision = 12, Unk2 = 2 }, // 1.4.2
            new() { Major = 0x60001, Minor = 0x6000C, HeaderRevision = 0, Unk1 = 2, SaveRevision = 13, Unk2 = 2 }, // 1.5.0
            new() { Major = 0x60001, Minor = 0x6000C, HeaderRevision = 0, Unk1 = 2, SaveRevision = 14, Unk2 = 2 }, // 1.5.1
            new() { Major = 0x70001, Minor = 0x70006, HeaderRevision = 0, Unk1 = 2, SaveRevision = 15, Unk2 = 2 }, // 1.6.0
            new() { Major = 0x74001, Minor = 0x74005, HeaderRevision = 0, Unk1 = 2, SaveRevision = 16, Unk2 = 2 }, // 1.7.0
            new() { Major = 0x78001, Minor = 0x78001, HeaderRevision = 0, Unk1 = 2, SaveRevision = 17, Unk2 = 2 }, // 1.8.0
            new() { Major = 0x7C001, Minor = 0x7C006, HeaderRevision = 0, Unk1 = 2, SaveRevision = 18, Unk2 = 2 }, // 1.9.0
            new() { Major = 0x7D001, Minor = 0x7D004, HeaderRevision = 0, Unk1 = 2, SaveRevision = 19, Unk2 = 2 }, // 1.10.0
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
            SizesByRevision[3], // 1.3.0
            SizesByRevision[3], // 1.3.1
            SizesByRevision[4], // 1.4.0
            SizesByRevision[4], // 1.4.1
            SizesByRevision[4], // 1.4.2
            SizesByRevision[5], // 1.5.0
            SizesByRevision[5], // 1.5.1
            SizesByRevision[6], // 1.6.0
            SizesByRevision[7], // 1.7.0
            SizesByRevision[8], // 1.8.0
            SizesByRevision[9], // 1.9.0
            SizesByRevision[10], // 1.10.0
        };

        public static readonly IReadOnlyList<FileHashInfo> HashInfo = new[]
        {
            REV_100, // 1.0.0
            REV_110, // 1.1.0
            REV_110, // 1.1.1
            REV_110, // 1.1.2
            REV_110, // 1.1.3
            REV_110, // 1.1.4
            REV_120, // 1.2.0
            REV_120, // 1.2.1
            REV_130, // 1.3.0
            REV_130, // 1.3.1
            REV_140, // 1.4.0
            REV_140, // 1.4.1
            REV_140, // 1.4.2
            REV_150, // 1.5.0
            REV_150, // 1.5.1
            REV_160, // 1.6.0
            REV_170, // 1.7.0
            REV_180, // 1.8.0
            REV_190, // 1.9.0
            REV_1100, // 1.10.0
        };

        public static bool IsRevisionKnown(this FileHeaderInfo info) => info.GetKnownRevisionIndex() >= 0;
        public static int GetKnownRevisionIndex(this FileHeaderInfo info) => Array.FindIndex(RevisionInfo, z => z.Equals(info));
    }
}
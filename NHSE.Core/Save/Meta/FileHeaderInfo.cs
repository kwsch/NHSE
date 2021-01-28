using System.Runtime.InteropServices;
// ReSharper disable NonReadonlyMemberInGetHashCode

namespace NHSE.Core
{
    /// <summary>
    /// Metadata stored in a file's Header, indicating the revision information.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public sealed record FileHeaderInfo
    {
        public const int SIZE = 0x40;

        [field: FieldOffset(0x00)] public uint Major { get; init; }
        [field: FieldOffset(0x04)] public uint Minor { get; init; }
        [field: FieldOffset(0x08)] public ushort Unk1 { get; init; }
        [field: FieldOffset(0x0A)] public ushort HeaderRevision { get; init; }
        [field: FieldOffset(0x0C)] public ushort Unk2 { get; init; }
        [field: FieldOffset(0x0E)] public ushort SaveRevision { get; init; }
    }
}

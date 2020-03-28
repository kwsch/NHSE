using System;
using System.Runtime.InteropServices;
// ReSharper disable NonReadonlyMemberInGetHashCode

namespace NHSE.Core
{
    /// <summary>
    /// Metadata stored in a file's Header, indicating the revision information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class FileHeaderInfo : IEquatable<FileHeaderInfo>
    {
        public const int SIZE = 0x40;

        /* 0x00 */ public uint Major;
        /* 0x04 */ public uint Minor;
        /* 0x08 */ public ushort Unk1;
        /* 0x0A */ public ushort HeaderRevision;
        /* 0x0C */ public ushort Unk2;
        /* 0x0E */ public ushort SaveRevision;

        public bool Equals(FileHeaderInfo? other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;

            if (Major != other.Major)
                return false;
            if (Minor != other.Minor)
                return false;
            if (Unk1 != other.Unk1)
                return false;
            if (HeaderRevision != other.HeaderRevision)
                return false;
            if (Unk2 != other.Unk2)
                return false;
            if (SaveRevision != other.SaveRevision)
                return false;
            return true;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((FileHeaderInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Major;
                hashCode = (hashCode * 397) ^ (int) Minor;
                hashCode = (hashCode * 397) ^ Unk1.GetHashCode();
                hashCode = (hashCode * 397) ^ HeaderRevision.GetHashCode();
                hashCode = (hashCode * 397) ^ Unk2.GetHashCode();
                hashCode = (hashCode * 397) ^ SaveRevision.GetHashCode();
                return hashCode;
            }
        }
    }
}
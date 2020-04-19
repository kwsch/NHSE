using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 1)]
    public struct GSaveItemName
    {
        public const int SIZE = 0x08;
        [field: FieldOffset(0x00)] public ushort UniqueID { get; set; }
        [field: FieldOffset(0x02)] public byte SystemParam { get; set; }
        [field: FieldOffset(0x03)] public byte AdditionalParam { get; set; }
        [field: FieldOffset(0x04)] public uint FreeParam { get; set; }

        // ReSharper disable once NonReadonlyMemberInGetHashCode
        public override int GetHashCode() => UniqueID;
        public override bool Equals(object obj) => obj is GSaveItemName i && i.Equals(this);
        public bool Equals(GSaveItemName obj) => obj.UniqueID == UniqueID && obj.SystemParam == SystemParam && obj.AdditionalParam == AdditionalParam;
        public static bool operator ==(GSaveItemName left, GSaveItemName right) => left.Equals(right);
        public static bool operator !=(GSaveItemName left, GSaveItemName right) => !(left == right);
    }
}

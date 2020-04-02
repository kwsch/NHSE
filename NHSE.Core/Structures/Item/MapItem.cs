using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public class MapItem : Item
    {
        public new const int SIZE = 0x10;

        public ushort X1, X2, X3, X4;
        public new static MapItem[] GetArray(byte[] data) => data.GetArray<MapItem>(SIZE);
        public static byte[] SetArray(IReadOnlyList<MapItem> data) => data.SetArray(SIZE);
    }
}

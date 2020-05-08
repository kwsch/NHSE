using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class VillagerItem : Item, ICopyableItem<VillagerItem>
    {
        public new const int SIZE = 0x2C;
        public new static readonly VillagerItem NO_ITEM = new VillagerItem { ItemId = NONE };

        public uint U08;
        public uint U0C;
        public uint U10;
        public uint U14;
        public uint U18;
        public uint U1C;
        public uint U20;
        public uint U24;
        public uint U28;

        public new static VillagerItem[] GetArray(byte[] data) => data.GetArray<VillagerItem>(SIZE);
        public static byte[] SetArray(IReadOnlyList<VillagerItem> data) => data.SetArray(SIZE);

        public void CopyFrom(VillagerItem item)
        {
            CopyFrom((Item) item);
            U08 = item.U08;
            U0C = item.U0C;
            U10 = item.U10;
            U14 = item.U14;
            U18 = item.U18;
            U1C = item.U1C;
            U20 = item.U20;
            U24 = item.U24;
            U28 = item.U28;
        }

        public new void Delete() => CopyFrom(NO_ITEM);

        public override int Size => SIZE;
    }
}

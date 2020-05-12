using System.ComponentModel;
using System.Runtime.InteropServices;

#pragma warning disable CS8618, CA1815, CA1819, IDE1006
namespace NHSE.Core
{
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 1)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct GSaveItemName
    {
        public const int SIZE = 0x08;
        public override string ToString() => UniqueID.ToString();

        [field: FieldOffset(0x00)] public ushort UniqueID { get; set; }
        [field: FieldOffset(0x02)] public byte SystemParam { get; set; }
        [field: FieldOffset(0x03)] public byte AdditionalParam { get; set; }
        [field: FieldOffset(0x04)] public int FreeParam { get; set; }

        public Item ToItem() => this.ToBytes().ToClass<Item>();

        public void CopyFrom(Item item)
        {
            UniqueID = item.ItemId;
            SystemParam = item.SystemParam;
            AdditionalParam = item.AdditionalParam;
            FreeParam = item.FreeParam;
        }
    }
}

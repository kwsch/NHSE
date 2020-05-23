using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    /// <summary>
    /// Interact-able structure that can be entered by the player.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = SIZE, Pack = 1)]
    public class Building
    {
        public const int SIZE = 0x14;

        [field: FieldOffset(0x00)] public BuildingType BuildingType { get; set; }
        [field: FieldOffset(0x02)] public ushort X { get; set; }
        [field: FieldOffset(0x04)] public ushort Y { get; set; }

        [field: FieldOffset(0x06)] public byte Angle { get; set; }
        [field: FieldOffset(0x07)] public sbyte Bit { get; set; }

        [field: FieldOffset(0x08)] public ushort Type { get; set; }
        [field: FieldOffset(0x0A)] public byte TypeArg { get; set; }

        [field: FieldOffset(0x0C)] public ushort UniqueID { get; set; }
        [field: FieldOffset(0x10)] public uint Unused { get; set; }

        public void Clear()
        {
            BuildingType = 0;
            X = Y = Angle = 0;
            Bit = 0;
            Type = TypeArg = 0;
            UniqueID = 0;
            Unused = 0;
        }

        public void CopyFrom(Building building)
        {
            BuildingType = building.BuildingType;
            X = building.X;
            Y = building.Y;
            Angle = building.Angle;
            Bit = building.Bit;
            Type = building.Type;
            TypeArg = building.TypeArg;
            UniqueID = building.UniqueID;
            Unused = building.Unused;
        }

        public static Building[] GetArray(byte[] data) => data.GetArray<Building>(SIZE);
        public static byte[] SetArray(IReadOnlyList<Building> data) => data.SetArray(SIZE);
        public override string ToString() => $"{X:000},{Y:000} - {BuildingType}";
    }
}

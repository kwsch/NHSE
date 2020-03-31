using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public class Building : INamedObject
    {
        public const int SIZE = 0x14;
        private const string Details = nameof(Details);

        [Category(Details), Description("Type of Building")]
        public ushort BuildingId { get; set; }

        [Category(Details), Description("X Coordinate of Building")]
        public ushort X { get; set; }

        [Category(Details), Description("Y Coordinate of Building")]
        public ushort Y { get; set; }

        public ushort Z { get; set; } // Guess

        public uint Unk08 { get; set; }
        public uint Unk0C { get; set; }
        public uint Unk10 { get; set; }

        public void Clear()
        {
            BuildingId = 0;
            X = Y = Z = 0;
            Unk08 = Unk0C = Unk10 = 0;
        }

        public static Building[] GetArray(byte[] data) => data.GetArray<Building>(SIZE);
        public static byte[] SetArray(IReadOnlyList<Building> data) => data.SetArray(SIZE);
        public override string ToString() => ToString(Array.Empty<string>());

        public string ToString(IReadOnlyList<string> names) =>
            $"{X:000},{Y:000} - {(BuildingId >= names.Count ? $"0x{BuildingId:X2}" : names[BuildingId])}";
    }
}

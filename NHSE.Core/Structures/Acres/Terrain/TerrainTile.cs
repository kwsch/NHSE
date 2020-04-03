using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public class TerrainTile
    {
        public const int SIZE = 0xE;
        private const string Details = nameof(Details);

        [Category(Details), Description("Terrain model to be loaded for this tile.")]
        public TerrainUnitModel UnitModel { get; set; }

        public ushort Unk2 { get; set; }
        public ushort Unk4 { get; set; }
        public ushort Unk6 { get; set; }
        public ushort Unk8 { get; set; }
        public ushort UnkA { get; set; }

        [Category(Details), Description("How high the terrain tile is elevated.")]
        public ushort Elevation { get; set; }

        public static TerrainTile[] GetArray(byte[] data) => data.GetArray<TerrainTile>(SIZE);
        public static byte[] SetArray(IReadOnlyList<TerrainTile> data) => data.SetArray(SIZE);

        public void Clear()
        {
            UnitModel = 0;
            Unk2 = Unk4 = Unk6 = Unk8 = UnkA = Elevation = 0;
        }

        public void CopyFrom(TerrainTile source)
        {
            UnitModel = source.UnitModel;
            Unk2 = source.Unk2;
            Unk4 = source.Unk4;
            Unk6 = source.Unk6;
            Unk8 = source.Unk8;
            UnkA = source.UnkA;
            Elevation = source.Elevation;
        }
    }
}

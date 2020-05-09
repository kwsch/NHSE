using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace NHSE.Parsing
{
    public class PBC
    {
        private const uint MAGIC = 0x00636270; // pbc\0

        public readonly byte[] Data;

        public PBC(byte[] data)
        {
            Data = data;
            Debug.Assert(Magic == MAGIC);

            Tiles = GetTiles();
        }

        public readonly byte[] Tiles;

        private byte[] GetTiles()
        {
            int offset = 0x14;
            var w = Width;
            var h = Height;
            byte[] data = new byte[w * h * 4];

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    var ofs = offset + 0x30;
                    data[(x * 2) + (w * 2 * (y * 2))] = Data[ofs + 0];
                    data[(x * 2) + (w * 2 * ((y * 2) + 1))] = Data[ofs + 1];
                    data[(x * 2) + (w * 2 * ((y * 2) + 1)) + 1] = Data[ofs + 2];
                    data[(x * 2) + (w * 2 * (y * 2)) + 1] = Data[ofs + 3];
                    offset += 0x34;
                }
            }

            return data;
        }

        public byte GetTile(int x, int y) => Tiles[(y * Width) + x];
        public Color GetTileColor(int x, int y) => Dict[GetTile(x, y)];

        public uint Magic => BitConverter.ToUInt32(Data, 0x00);
        public uint Width => BitConverter.ToUInt32(Data, 0x04);
        public uint Height => BitConverter.ToUInt32(Data, 0x08);

        public static readonly Dictionary<byte, Color> Dict = new Dictionary<byte, Color>
        {
            {00, Color.FromArgb( 70, 120,  64)}, // Grass
            {01, Color.FromArgb(128, 215, 195)}, // River
            {03, Color.FromArgb(192, 192, 192)}, // Stone
            {04, Color.FromArgb(240, 230, 170)}, // Sand
            {05, Color.FromArgb(128, 215, 195)}, // Sea
            {06, Color.FromArgb(255, 128, 128)}, // Wood
            {07, Color.FromArgb(0  ,   0,   0)}, // Null
            {08, Color.FromArgb(32 ,  32,  32)}, // Building
            {09, Color.FromArgb(255,   0,   0)}, // ??
            {10, Color.FromArgb(48 ,  48,  48)}, // Door
            {12, Color.FromArgb(128, 215, 195)}, // Water at mouths of river
            {15, Color.FromArgb(128, 215, 195)}, // Strip of water between river mouth and river
            {22, Color.FromArgb(190,  98,  98)}, // Wood (thin)
            {28, Color.FromArgb(255,   0,   0)}, // ?? this one isn't even in ColGroundAttributeParam...
            {29, Color.FromArgb(232, 222, 162)}, // Edge of beach, next to sea
            {41, Color.FromArgb(118, 122, 132)}, // Rocks at top of map
            {42, Color.FromArgb(128, 133, 147)}, // Taller regions, rocks at top of map
            {44, Color.FromArgb( 62, 112,  56)}, // Edge connecting grass and beach
            {45, Color.FromArgb(118, 122, 132)}, // Some kind of rock
            {46, Color.FromArgb(120, 207, 187)}, // Edge of sea, next to beach
            {47, Color.FromArgb(128, 128,   0)}, // Sandstone
            {49, Color.FromArgb(190,  98,  98)}, // Pier
            {51, Color.FromArgb(32 , 152,  32)}, // "Grass-growing building"??
        };
    }
}

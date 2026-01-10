using System;
using System.Diagnostics;
using System.Drawing;
using NHSE.Core;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Parsing;

public class PBC
{
    private const uint MAGIC = 0x00636270; // pbc\0

    public readonly Memory<byte> Raw;
    private Span<byte> Data => Raw.Span;

    public PBC(Memory<byte> data)
    {
        Raw = data;
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
    public Color GetTileColor(int x, int y) => CollisionUtil.Dict[GetTile(x, y)];

    public uint Magic => ReadUInt32LittleEndian(Data);
    public uint Width => ReadUInt32LittleEndian(Data[0x04..]);
    public uint Height => ReadUInt32LittleEndian(Data[0x08..]);
}
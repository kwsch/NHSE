using System;

namespace NHSE.Core
{
    /// <summary>
    /// Simple design pattern
    /// </summary>
    public class DesignPattern : IVillagerOrigin
    {
        public const int Width = 32;
        public const int Height = 32;

        public const int SIZE = 0x2A8; // 3 bytes unused at end
        private const int PersonalOffset = 0x38;
        private const int PaletteDataStart = 0x78;
        public const int PaletteColorCount = 15; // y not 16???
        private const int PaletteColorSize = 3; // R, G, B
        private const int PixelDataOffset = PaletteDataStart + (PaletteColorCount * PaletteColorSize); // 0xA5
        private const int PixelCount = 0x400; // Width * Height
        //private const int PixelDataSize = PixelCount / 2; // 4bit|4bit pixel packing

        public readonly byte[] Data;

        public DesignPattern(byte[] data) => Data = data;

        public uint Hash
        {
            get => BitConverter.ToUInt32(Data, 0x00);
            set => BitConverter.GetBytes(value).CopyTo(Data, 0x00);
        }

        public uint Version
        {
            get => BitConverter.ToUInt32(Data, 0x04);
            set => BitConverter.GetBytes(value).CopyTo(Data, 0x04);
        }

        public string DesignName
        {
            get => StringUtil.GetString(Data, 0x10, 20);
            set => StringUtil.GetBytes(value, 20).CopyTo(Data, 0x10);
        }

        public uint TownID
        {
            get => BitConverter.ToUInt32(Data, PersonalOffset);
            set => BitConverter.GetBytes(value).CopyTo(Data, PersonalOffset);
        }

        public string TownName
        {
            get => StringUtil.GetString(Data, PersonalOffset + 0x04, 10);
            set => StringUtil.GetBytes(value, 10).CopyTo(Data, PersonalOffset + 0x04);
        }

        public byte[] GetTownIdentity() => Data.Slice(PersonalOffset + 0x00, 4 + 20);

        public uint PlayerID
        {
            get => BitConverter.ToUInt32(Data, PersonalOffset + 0x1C);
            set => BitConverter.GetBytes(value).CopyTo(Data, PersonalOffset + 0x1C);
        }

        public string PlayerName
        {
            get => StringUtil.GetString(Data, PersonalOffset + 0x20, 10);
            set => StringUtil.GetBytes(value, 10).CopyTo(Data, PersonalOffset + 0x20);
        }

        public byte[] GetPlayerIdentity() => Data.Slice(PersonalOffset + 0x1C, 4 + 20);

        /// <summary>
        /// Gets/Sets the color choice (1-15) for the pixel at the given <see cref="index"/>.
        /// </summary>
        /// <param name="index">Pixel index</param>
        public int this[int index]
        {
            get
            {
                var ofs = PixelDataOffset + (index / 2);
                var val = Data[ofs];
                return (index & 1) == 0 ? (val & 0x0F) : (val >> 4);
            }
            set
            {
                var ofs = PixelDataOffset + (index / 2);
                var val = Data[ofs];
                var update = ((index & 1) == 0)
                    ? (val & 0xF0) | (value & 0xF)
                    : (value & 0xF) << 4 | (val & 0xF);
                Data[ofs] = (byte)update;
            }
        }

        public static int GetPixelIndex(int x, int y) => (y * Height) + x;

        public int GetPixel(int x, int y)
        {
            if ((uint)x >= Width)
                throw new ArgumentException($"Argument out of range (0-{Width})", nameof(x));
            if ((uint)y >= Height)
                throw new ArgumentException($"Argument out of range (0-{Height})", nameof(y));

            var index = GetPixelIndex(x, y);
            return this[index];
        }

        public static int GetColorOffset(int index)
        {
            if ((uint)index >= PaletteColorCount)
                throw new ArgumentException($"Argument out of range (0-{PaletteColorCount})", nameof(index));
            return PaletteDataStart + (index * PaletteColorSize);
        }

        /// <summary>
        /// Builds a new array with unpacked 32bit pixel data.
        /// </summary>
        public byte[] GetBitmap()
        {
            byte[] data = new byte[4 * Width * Height];
            for (int i = 0; i < PixelCount; i++)
            {
                var choice = this[i];
                if (choice == PaletteColorCount)
                    continue; // transparent?
                var palette = GetColorOffset(choice);
                var ofs = i * 4;
                data[ofs + 2] = Data[palette + 0];
                data[ofs + 1] = Data[palette + 1];
                data[ofs + 0] = Data[palette + 2];
                data[ofs + 3] = 0xFF; // opaque
            }
            return data;
        }

        /// <summary>
        /// Returns a raw slice of data containing the 24bit color pixels.
        /// </summary>
        public byte[] GetPaletteBitmap()
        {
            var result = new byte[3 * PaletteColorCount];
            for (int i = 0; i < PaletteColorCount; i++)
            {
                var ofs = PaletteDataStart + (i * 3);
                result[(i * 3) + 2] = Data[ofs + 0];
                result[(i * 3) + 1] = Data[ofs + 1];
                result[(i * 3) + 0] = Data[ofs + 2];
            }
            return result;
        }
    }
}

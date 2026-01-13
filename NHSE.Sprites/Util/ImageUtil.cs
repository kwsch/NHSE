using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NHSE.Core;

namespace NHSE.Sprites;

public static class ImageUtil
{
    extension(DesignPattern bg)
    {
        public Bitmap GetImage() => GetBitmap(bg.GetBitmap(), DesignPattern.Width, DesignPattern.Height);

        public Bitmap GetPalette() => GetBitmap(bg.GetPaletteBitmap(), DesignPattern.PaletteColorCount, 1, PixelFormat.Format24bppRgb);
    }

    extension(DesignPatternPRO bg)
    {
        public Bitmap GetImage(int sheet) => GetBitmap(bg.GetBitmap(sheet), DesignPatternPRO.Width, DesignPatternPRO.Height);

        public Bitmap GetPalette() => GetBitmap(bg.GetPaletteBitmap(), DesignPatternPRO.PaletteColorCount, 1, PixelFormat.Format24bppRgb);
    }

    public static Bitmap GetBitmap(ReadOnlySpan<byte> data, int width, int height, PixelFormat format = PixelFormat.Format32bppArgb)
    {
        var bmp = new Bitmap(width, height, format);
        var bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, format);
        var length = data.Length;
        var span = MemoryMarshal.CreateSpan(ref Unsafe.AddByteOffset(ref Unsafe.NullRef<byte>(), bmpData.Scan0), length);
        data[..length].CopyTo(span);
        bmp.UnlockBits(bmpData);
        return bmp;
    }

    public static Bitmap GetBitmap(int[] data, int width, int height, PixelFormat format = PixelFormat.Format32bppArgb)
    {
        var bmp = new Bitmap(width, height, format);
        SetBitmapData(bmp, data, format);
        return bmp;
    }

    public static void SetBitmapData(Bitmap bmp, int[] data, PixelFormat format = PixelFormat.Format32bppArgb)
    {
        var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, format);
        var ptr = bmpData.Scan0;
        Marshal.Copy(data, 0, ptr, data.Length);
        bmp.UnlockBits(bmpData);
    }

    public static void GetBitmapData(Bitmap bmp, int[] data, PixelFormat format = PixelFormat.Format32bppArgb)
    {
        var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, format);
        var ptr = bmpData.Scan0;
        Marshal.Copy(ptr, data, 0, data.Length);
        bmp.UnlockBits(bmpData);
    }

    // https://stackoverflow.com/a/24199315
    public static Bitmap ResizeImage(Image image, int width, int height)
    {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using var wrapMode = new ImageAttributes();
        wrapMode.SetWrapMode(WrapMode.TileFlipXY);

        using var graphics = Graphics.FromImage(destImage);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);

        return destImage;
    }

    public static int[] ScalePixelImage(ReadOnlySpan<int> data, int scale, int w, int h, out int fW, out int fH)
    {
        fW = scale * w;
        fH = scale * h;
        var scaled = new int[fW * fH];

        ScalePixelImage(data, scaled, fW, fH, scale);

        return scaled;
    }

    public static void ScalePixelImage(ReadOnlySpan<int> data, Span<int> scaled, int fW, int fH, int scale)
    {
        // For each pixel, copy to the X indexes, then block copy the row to the other rows.
        int i = 0;
        for (int y = 0; y < fH; y += scale)
        {
            // Fill the X pixels
            var baseIndex = y * fW;
            for (int x = 0; x < fW; x += scale)
            {
                var v = data[i];
                var xi = baseIndex + x;
                for (int x1 = 0; x1 < scale; x1++)
                    scaled[xi + x1] = v;
                i++;
            }

            // Copy entire pixel row down
            for (int y1 = 1; y1 < scale; y1++)
            {
                var src = scaled.Slice(baseIndex, fW);
                var dest = scaled.Slice(baseIndex + (y1 * fW), fW);
                src.CopyTo(dest);
            }
        }
    }

    /// <summary>
    /// Sets a bitwise and of the requested transparency; this is assuming the pixel value is 0xFF_xx_xx_xx. Single operation laziness!
    /// </summary>
    public static void ClampAllTransparencyTo(Span<int> data, int trans)
    {
        for (int i = 0; i < data.Length; i++)
            data[i] &= trans;
    }
}
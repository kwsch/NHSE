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

    extension(Bitmap bmp)
    {
        public Span<byte> GetBitmapData(out BitmapData bmpData)
        {
            var format = bmp.PixelFormat;
            bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, format);
            var bpp = Image.GetPixelFormatSize(format) / 8;
            return GetSpan(bmpData.Scan0, bmp.Width * bmp.Height * bpp);
        }

        public void GetBitmapData(Span<byte> data)
        {
            var span = bmp.GetBitmapData(out var bmpData);
            span.CopyTo(data);
            bmp.UnlockBits(bmpData);
        }

        public void GetBitmapData(Span<int> data)
        {
            var span = bmp.GetBitmapData(out var bmpData);
            var src = MemoryMarshal.Cast<byte, int>(span);
            src.CopyTo(data);
            bmp.UnlockBits(bmpData);
        }

        public void SetBitmapData(ReadOnlySpan<byte> data)
        {
            var span = bmp.GetBitmapData(out var bmpData);
            data.CopyTo(span);
            bmp.UnlockBits(bmpData);
        }

        public void SetBitmapData(Span<int> data)
        {
            var span = bmp.GetBitmapData(out var bmpData);
            var dest = MemoryMarshal.Cast<byte, int>(span);
            data.CopyTo(dest);
            bmp.UnlockBits(bmpData);
        }
    }

    public static Bitmap GetBitmap(ReadOnlySpan<int> data, int width, int height, PixelFormat format = PixelFormat.Format32bppArgb)
    {
        var span = MemoryMarshal.Cast<int, byte>(data);
        return GetBitmap(span, width, height, format);
    }

    public static Bitmap GetBitmap(ReadOnlySpan<byte> data, int width, int height, PixelFormat format = PixelFormat.Format32bppArgb)
    {
        var bmp = new Bitmap(width, height, format);
        var span = bmp.GetBitmapData(out var bmpData);
        data[..span.Length].CopyTo(span);
        bmp.UnlockBits(bmpData);
        return bmp;
    }

    private static Span<byte> GetSpan(IntPtr ptr, int length)
        => MemoryMarshal.CreateSpan(ref Unsafe.AddByteOffset(ref Unsafe.NullRef<byte>(), ptr), length);

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

    public static int[] ScalePixelImage(ReadOnlySpan<int> data, int imgScale, int imgWidthSingle, int imgHeightSingle, out int imgWidthUpscaled, out int imgHeightUpscaled)
    {
        imgWidthUpscaled = imgScale * imgWidthSingle;
        imgHeightUpscaled = imgScale * imgHeightSingle;
        var scaled = new int[imgWidthUpscaled * imgHeightUpscaled];
        ScalePixelImage(data, scaled, imgWidthUpscaled, imgHeightUpscaled, imgScale);
        return scaled;
    }

    public static void ScalePixelImage(ReadOnlySpan<int> data, Span<int> scaled, int imgWidth, int imgHeight, int imgScale)
    {
        // For each pixel, copy to the X indexes, then block copy the row to the other rows.
        int i = 0;
        for (int y = 0; y < imgHeight; y += imgScale)
        {
            // Fill the X pixels
            var baseIndex = y * imgWidth;
            for (int x = 0; x < imgWidth; x += imgScale)
            {
                var v = data[i];
                var xi = baseIndex + x;
                for (int x1 = 0; x1 < imgScale; x1++)
                    scaled[xi + x1] = v;
                i++;
            }

            // Copy entire pixel row down
            for (int y1 = 1; y1 < imgScale; y1++)
            {
                var src = scaled.Slice(baseIndex, imgWidth);
                var dest = scaled.Slice(baseIndex + (y1 * imgWidth), imgWidth);
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

    public static void ClampAllTransparencyTo(Span<byte> data, byte trans)
    {
        for (int i = 0; i < data.Length; i += 4)
            data[i + 3] &= trans;
    }
}
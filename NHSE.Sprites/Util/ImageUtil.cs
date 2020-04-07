using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using NHSE.Core;

namespace NHSE.Sprites
{
    public static class ImageUtil
    {
        public static Bitmap GetImage(this DesignPattern bg)
        {
            return GetBitmap(bg.GetBitmap(), DesignPattern.Width, DesignPattern.Height);
        }

        public static Bitmap GetPalette(this DesignPattern bg)
        {
            return GetBitmap(bg.GetPaletteBitmap(), DesignPattern.PaletteColorCount, 1, PixelFormat.Format24bppRgb);
        }

        public static Bitmap GetBitmap(byte[] data, int width, int height, PixelFormat format = PixelFormat.Format32bppArgb)
        {
            var bmp = new Bitmap(width, height, format);
            var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, format);
            var ptr = bmpData.Scan0;
            Marshal.Copy(data, 0, ptr, data.Length);
            bmp.UnlockBits(bmpData);
            return bmp;
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
    }
}

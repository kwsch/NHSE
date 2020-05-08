using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using NHSE.Core;
using NHSE.Sprites.Properties;

namespace NHSE.Sprites
{
    public static class ItemSprite
    {
        private static readonly Dictionary<string, string> FileLookup = new Dictionary<string, string>();
        private static string[] ItemNames = Array.Empty<string>();

        public static void Initialize(string path, string[] itemNames)
        {
            if (FileLookup.Count > 0)
                return;

            ItemNames = itemNames;

            var files = Directory.EnumerateFiles(path, "*.png", SearchOption.AllDirectories);
            foreach (var f in files)
            {
                var fn = Path.GetFileNameWithoutExtension(f);
                FileLookup.Add(fn, f);
            }
        }

        public static Bitmap GetItemMarkup(IHeldItem item, Font font, int width, int height, Bitmap backing)
        {
            return CreateFake(item, font, width, height, backing);
        }

        public static Image? GetItemSprite(IHeldItem item)
        {
            var id = item.ItemId;

            if (id == Item.NONE)
                return null;

            if (!GetItemImageSprite(id, out var path))
                return Resources.leaf;

            try
            {
                return Image.FromFile(path);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                Console.WriteLine(ex.Message);
                return Resources.leaf;
            }
        }

        private static bool GetItemImageSprite(ushort id, out string? path)
        {
            path = string.Empty;
            var str = ItemNames;
            if (id >= str.Length)
                return false;

            var name = str[id];
            return FileLookup.TryGetValue(name, out path);
        }

        public static Bitmap? GetImage(IHeldItem item, Font font, int width, int height)
        {
            if (item.ItemId == Item.NONE)
                return null;

            return CreateFake(item, font, width, height);
        }

        private static readonly StringFormat Center = new StringFormat
        { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        public static Bitmap CreateFake(IHeldItem item, Font font, int width, int height)
        {
            var bmp = new Bitmap(width, height);
            return CreateFake(item, font, width, height, bmp);
        }

        private static Bitmap CreateFake(IHeldItem item, Font font, int width, int height, Bitmap bmp)
        {
            using var gfx = Graphics.FromImage(bmp);
            DrawItemAt(gfx, item, font, width, height);
            return bmp;
        }

        public static void DrawItemAt(Graphics gfx, IHeldItem item, Font font, int width, int height)
        {
            DrawInfo(gfx, font, item, width, height, Brushes.Black);
        }

        private static void DrawInfo(Graphics gfx, Font font, IHeldItem item, int width, int height, Brush brush)
        {
            if (item.Count != 0)
                gfx.DrawString(item.Count.ToString(), font, brush, 0, 0);
            if (item.UseCount != 0)
                gfx.DrawString(item.UseCount.ToString(), font, brush, width >> 1, height >> 1, Center);
            if (item.SystemParam != 0)
                gfx.DrawString(item.SystemParam.ToString(), font, brush, width - 12, 0);
            if (item.AdditionalParam != 0)
                gfx.DrawString(item.AdditionalParam.ToString(), font, brush, 0, height - 12);
        }
    }
}

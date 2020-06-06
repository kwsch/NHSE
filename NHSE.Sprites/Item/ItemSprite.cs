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
            var lookup = FileLookup;
            if (lookup.Count > 0)
                return;

            ItemNames = itemNames;

            //create items folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var files = Directory.EnumerateFiles(path, "*.png", SearchOption.AllDirectories);
            foreach (var f in files)
            {
                var fn = Path.GetFileNameWithoutExtension(f);
                if (fn == null)
                    continue;
                lookup[fn.ToLower()] = f;
                var index = fn.IndexOf('(');
                if (index < 0)
                    continue;

                var simplerName = fn.Substring(0, index - 1);
                if (!lookup.ContainsKey(simplerName))
                    lookup.Add(simplerName, f);
            }
        }

        public static Bitmap GetItemMarkup(Item item, Font font, int width, int height, Bitmap backing)
        {
            return CreateFake(item, font, width, height, backing);
        }

        public static Image? GetItemSprite(Item item)
        {
            var id = item.ItemId;
            return GetItemSprite(id);
        }

        public static Image? GetItemSprite(ushort id)
        {
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
            {
                if (!FieldItemList.Items.TryGetValue(id, out var definition))
                    return false;

                var remap = definition.HeldItemId;
                if (remap >= str.Length)
                    return false;

                id = remap;
            }

            var name = str[id].ToLower();
            if (FileLookup.TryGetValue(name, out path))
                return true;

            var index = name.IndexOf('(');
            if (index <= 0)
                return false;

            var simple = name.Substring(0, index - 1);
            return FileLookup.TryGetValue(simple, out path);
        }

        public static Bitmap? GetImage(Item item, Font font, int width, int height)
        {
            if (item.ItemId == Item.NONE)
                return null;

            return CreateFake(item, font, width, height);
        }

        private static readonly StringFormat Center = new StringFormat
        { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        public static Bitmap CreateFake(Item item, Font font, int width, int height)
        {
            var bmp = new Bitmap(width, height);
            return CreateFake(item, font, width, height, bmp);
        }

        private static Bitmap CreateFake(Item item, Font font, int width, int height, Bitmap bmp)
        {
            using var gfx = Graphics.FromImage(bmp);
            DrawItemAt(gfx, item, font, width, height);
            return bmp;
        }

        public static void DrawItemAt(Graphics gfx, Item item, Font font, int width, int height)
        {
            DrawInfo(gfx, font, item, width, height, Brushes.Black);
        }

        private static void DrawInfo(Graphics gfx, Font font, Item item, int width, int height, Brush brush)
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

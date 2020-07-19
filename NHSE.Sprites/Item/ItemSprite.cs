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
        private const string PointerFilename = "SpritePointer.txt";

        private static readonly Dictionary<string, string> FileLookup = new Dictionary<string, string>();
        private static string[] ItemNames = Array.Empty<string>(); // currently only used as length check for FieldItem

        // %appdata%/NHSE
        public static string PlatformAppDataPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), nameof(NHSE));
        public static string PlatformAppDataImagePath { get; } = Path.Combine(PlatformAppDataPath, "img");
        public static bool SpritePointerExists { get => File.Exists(Path.Combine(PlatformAppDataImagePath, PointerFilename)); }

        public static void Initialize(string[] itemNames)
        {
            var lookup = FileLookup;
            if (lookup.Count > 0)
                return;

            ItemNames = itemNames;

            if (!Directory.Exists(PlatformAppDataImagePath))
                Directory.CreateDirectory(PlatformAppDataImagePath);

            var pointerPath = Path.Combine(PlatformAppDataImagePath, PointerFilename);
            if (File.Exists(pointerPath))
                foreach (var itemId in File.ReadLines(pointerPath))
                    lookup.Add(itemId.Split(',')[0], Path.Combine(PlatformAppDataImagePath, itemId.Split(',')[1] + ".png"));
        }

        public static Bitmap GetItemMarkup(Item item, Font font, int width, int height, Bitmap backing)
        {
            return CreateFake(item, font, width, height, backing);
        }

        public static Image? GetItemSprite(Item item)
        {
            var id = item.ItemId;
            var count = item.Count;
            return GetItemSprite(id, count);
        }

        public static Image? GetItemSprite(ushort id, ushort count = 0)
        {
            if (id == Item.NONE)
                return null;

            if (!GetItemImageSprite(id, out var path, count))
            {
                if (!GetMenuIconSprite(id, out var img))
                    return Resources.leaf;
                else
                    return img;
            }

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

        private static bool GetMenuIconSprite(ushort id, out Image? img)
        {
            ItemMenuIconType iconType = ItemInfo.GetMenuIcon(id);
            img = (Image?)Resources.ResourceManager.GetObject(iconType == ItemMenuIconType.Leaf ? iconType.ToString() + "1" : iconType.ToString()); // the 1 stops the original "leaf" being overwritten
            return img != null;
        }

        private static bool GetItemImageSprite(ushort id, out string? path, ushort count = 0)
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

            var sItemdId = id.ToString("X");
            var bodyVal = (count & 0xF).ToString();
            var fabricVal = (((count & 0xFF) - (count & 0xF)) / 32u).ToString();

            // right now this brute force checks possible body and fabric values, cleanup requires more research because there are so many items that have nonconforming _X_X body and fabric values
            var name = string.Format("{0}_{1}_{2}", sItemdId, bodyVal, fabricVal);
            if (FileLookup.TryGetValue(name, out path))
                return true;

            name = string.Format("{0}_{1}", sItemdId, bodyVal);
            if (FileLookup.TryGetValue(name, out path))
                return true;

            if (FileLookup.TryGetValue(sItemdId, out path))
                return true;

            return false;
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

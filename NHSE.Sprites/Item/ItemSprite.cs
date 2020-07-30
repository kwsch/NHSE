using System;
using System.Drawing;
using System.IO;
using System.Linq;
using NHSE.Core;
using NHSE.Sprites.Properties;

namespace NHSE.Sprites
{
    public static class ItemSprite
    {
        private static string[] ItemNames = Array.Empty<string>(); // currently only used as length check for FieldItem

        // %appdata%/NHSE
        public static string PlatformAppDataPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), nameof(NHSE));
        public static string PlatformAppDataImagePath { get; } = Path.Combine(PlatformAppDataPath, "img");
        public static bool SingleSpriteExists { get => Directory.EnumerateFileSystemEntries(PlatformAppDataImagePath).Any(); }

        public static void Initialize(string[] itemNames)
        {
            ItemNames = itemNames;

            if (!Directory.Exists(PlatformAppDataImagePath))
                Directory.CreateDirectory(PlatformAppDataImagePath);
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

            if (!TryGetItemImageSprite(id, out var path, count))
            {
                if (!TryGetMenuIconSprite(id, out var img))
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

        private static bool TryGetMenuIconSprite(ushort id, out Image? img)
        {
            id = TryGetFieldItemId(id, ItemNames.Length);
            var iconType = ItemInfo.GetMenuIcon(id);

            // the 1 stops the original "leaf" being overwritten
            var name = iconType == ItemMenuIconType.Leaf ? $"{iconType}1" : iconType.ToString();

            img = (Image?)Resources.ResourceManager.GetObject(name); 
            return img != null;
        }

        private static bool TryGetItemImageSprite(ushort id, out string path, ushort count = 0)
        {
            id = TryGetFieldItemId(id, ItemNames.Length);

            var name = $"{id:00000}_{count}";
            if (SpriteFileExists(name, out path))
                return true;

            name = $"{id:00000}_0"; // fallback to no variation
            if (SpriteFileExists(name, out path))
                return true;

            return false;
        }

        private static bool SpriteFileExists(string filename, out string path)
        {
            path = Path.Combine(PlatformAppDataImagePath, filename + ".png");
            return File.Exists(path);
        }

        private static ushort TryGetFieldItemId(ushort id, int length)
        {
            if (id < length)
                return id;
            if (!FieldItemList.Items.TryGetValue(id, out var definition))
                return id;

            var remap = definition.HeldItemId;
            return remap >= length ? id : remap;
        }

        private static readonly StringFormat Center = new StringFormat
        { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

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

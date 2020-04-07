using System.Drawing;
using NHSE.Core;
using NHSE.Sprites.Properties;

namespace NHSE.Sprites
{
    public class ItemSpriteDrawer : IGridItem
    {
        public int Width { get; set; } = 32;
        public int Height { get; set; } = 32;

        public readonly Image HoverBackground = Resources.itemHover;

        public Bitmap GetImage(Item item, Font font) => ItemSprite.GetImage(item, font, Width, Height);
        public Bitmap GetImage(Item item) => ItemSprite.GetImage(item, Width, Height);
    }
}

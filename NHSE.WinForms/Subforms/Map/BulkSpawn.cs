using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class BulkSpawn : Form
    {
        private readonly IItemLayerEditor Editor;

        public BulkSpawn(IItemLayerEditor editor, int x = 0, int y = 0)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);

            Editor = editor;

            CB_SpawnType.Items.AddRange(Enum.GetNames(typeof(SpawnType)));
            CB_SpawnArrange.Items.AddRange(Enum.GetNames(typeof(SpawnArrangement)));

            CB_SpawnType.SelectedIndex = 0;
            CB_SpawnArrange.SelectedIndex = 0;
            NUD_SpawnX.Value = x;
            NUD_SpawnY.Value = y;
        }

        private void B_Apply_Click(object sender, EventArgs e)
        {
            var type = (SpawnType)CB_SpawnType.SelectedIndex;
            var arrange = (SpawnArrangement)CB_SpawnArrange.SelectedIndex;
            var x = (int)NUD_SpawnX.Value;
            var y = (int)NUD_SpawnY.Value;
            var count = (int)NUD_SpawnCount.Value;

            IEnumerable<Item> items;
            int sizeX;
            int sizeY;
            if (type == SpawnType.SequentialDIY)
            {
                var min = (ushort)NUD_DIYStart.Value;
                var max = (ushort)NUD_DIYStop.Value;
                var diy = RecipeList.Recipes
                    .Where(z => min <= z.Key && z.Key <= max)
                    .Select(z => z.Key)
                    .Select(z => new Item(Item.DIYRecipe) {FreeParam = z});

                items = Enumerable.Repeat(diy, count).SelectMany(z => z);
                sizeX = sizeY = 2;
            }
            else
            {
                var item = Editor.ItemProvider.SetItem(new Item());
                items = Enumerable.Repeat(item, count);
                var size = ItemInfo.GetItemSize(item);
                sizeX = size.GetWidth();
                sizeY = size.GetHeight();
            }

            if (sizeX % 2 == 1)
                sizeX++;
            if (sizeY % 2 == 1)
                sizeY++;

            var ctr = SpawnItems(Editor.SpawnLayer, items.ToArray(), x, y, arrange, sizeX, sizeY, true);
            if (ctr == 0)
            {
                WinFormsUtil.Alert(MessageStrings.MsgFieldItemModifyNone);
                return;
            }
            Editor.ReloadItems();
            WinFormsUtil.Alert(string.Format(MessageStrings.MsgFieldItemModifyCount, count));
        }

        private static int SpawnItems(ItemLayer layer, IReadOnlyList<Item> items, int x, int y, SpawnArrangement arrange, int sizeX, int sizeY, bool noOverwrite)
        {
            int x0 = x;
            var newline = arrange == SpawnArrangement.Square ? (int)Math.Sqrt(items.Count * sizeX * sizeY) : items.Count;

            int ctr = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                var permission = layer.IsOccupied(item, x, y);
                switch (permission)
                {
                    case PlacedItemPermission.OutOfBounds when y >= layer.MaxHeight:
                        return ctr;
                    case PlacedItemPermission.OutOfBounds:
                    case PlacedItemPermission.Collision when noOverwrite:
                        i--;
                        break;

                    default:
                        var exist = layer.GetTile(x, y);
                        layer.DeleteExtensionTiles(exist, x, y);

                        // Set new placed data
                        layer.SetExtensionTiles(item, x, y);
                        exist.CopyFrom(item);
                        ctr++;
                        break;
                }

                x += sizeX;
                if (x - x0 >= newline)
                {
                    y += sizeY;
                    x = x0;
                }
            }

            return ctr;
        }

        private void CB_SpawnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = (SpawnType)CB_SpawnType.SelectedIndex;
            L_DIYStart.Visible = L_DIYStop.Visible = NUD_DIYStart.Visible = NUD_DIYStop.Visible = index == SpawnType.SequentialDIY;
            NUD_SpawnCount.Value = index switch
            {
                SpawnType.SequentialDIY => 1,
                _ => 8,
            };
        }

        private enum SpawnType
        {
            ItemFromEditor,
            SequentialDIY,
        }

        private enum SpawnArrangement
        {
            Square,
            Horizontal,
        }
    }
}

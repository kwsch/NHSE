using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;

namespace NHSE.WinForms
{
    public partial class ItemGridEditor : UserControl
    {
        private static readonly GridSize Sprites = new GridSize();
        private readonly ItemEditor Editor;
        private readonly IReadOnlyList<Item> Items;

        private IList<PictureBox> SlotPictureBoxes = Array.Empty<PictureBox>();
        private int Count => Items.Count;
        private int Page;
        private int ItemsPerPage;
        public Action? ItemChanged { private get; set; }
        private void ItemUpdated() => ItemChanged?.Invoke();

        public ItemGridEditor(ItemEditor editor, IReadOnlyList<Item> items)
        {
            Editor = editor;
            Items = items;
            InitializeComponent();

            L_ItemName.Text = string.Empty;
        }

        public void InitializeGrid(int width, int height, int itemWidth, int itemHeight)
        {
            Sprites.Width = itemWidth;
            Sprites.Height = itemHeight;
            ItemsPerPage = width * height;
            ItemGrid.InitializeGrid(width, height, Sprites);
            InitializeSlots();
        }

        private void InitializeSlots()
        {
            SlotPictureBoxes = ItemGrid.Entries;
            foreach (var pb in SlotPictureBoxes)
            {
                pb.MouseEnter += Slot_MouseEnter;
                pb.MouseLeave += Slot_MouseLeave;
                pb.MouseClick += Slot_MouseClick;
                pb.MouseWheel += Slot_MouseWheel;
                pb.ContextMenuStrip = CM_Hand;
            }
            ChangePage();
        }

        private void Slot_MouseWheel(object sender, MouseEventArgs e)
        {
            var delta = e.Delta < 0 ? 1 : -1; // scrolling down increases page #
            var newpage = Math.Min(PageCount - 1, Math.Max(0, Page + delta));
            if (newpage == Page)
                return;
            Page = newpage;
            ChangePage();
        }

        public void Slot_MouseEnter(object? sender, EventArgs e)
        {
            if (!(sender is PictureBox pb))
                return;
            var index = SlotPictureBoxes.IndexOf(pb);
            var item = GetItem(index);

            var text = GetItemText(item);
            HoverTip.SetToolTip(pb, text);
            L_ItemName.Text = text;
        }

        public void Slot_MouseLeave(object? sender, EventArgs e)
        {
            if (!(sender is PictureBox))
                return;
            L_ItemName.Text = string.Empty;
            HoverTip.RemoveAll();
        }

        public static string GetItemText(Item item) => GameInfo.Strings.GetItemName(item);

        public void Slot_MouseClick(object sender, MouseEventArgs e)
        {
            switch (ModifierKeys)
            {
                case Keys.Control | Keys.Alt: ClickClone(sender, e); break;
                case Keys.Control: ClickView(sender, e); break;
                case Keys.Shift: ClickSet(sender, e); break;
                case Keys.Alt: ClickDelete(sender, e); break;
                default:
                    return;
            }
            // restart hovering since the mouse event isn't fired
            Slot_MouseEnter(sender, e);
        }

        public Item LoadItem(int index) => Editor.LoadItem(GetItem(index));
        public Item SetItem(int index) => Editor.SetItem(GetItem(index));

        private Item GetItem(int index)
        {
            index += Page * ItemsPerPage;
            return Items[index];
        }

        private void ClickView(object sender, EventArgs e)
        {
            var pb = WinFormsUtil.GetUnderlyingControl<PictureBox>(sender);
            if (pb == null)
                return;
            var index = SlotPictureBoxes.IndexOf(pb);
            LoadItem(index);
        }

        private void ClickSet(object sender, EventArgs e)
        {
            var pb = WinFormsUtil.GetUnderlyingControl<PictureBox>(sender);
            if (pb == null)
                return;
            var index = SlotPictureBoxes.IndexOf(pb);
            var item = SetItem(index);
            SetItemSprite(item, pb);
            ItemUpdated();
        }

        private void ClickDelete(object sender, EventArgs e)
        {
            var pb = WinFormsUtil.GetUnderlyingControl<PictureBox>(sender);
            if (pb == null)
                return;
            var index = SlotPictureBoxes.IndexOf(pb);
            var item = GetItem(index);
            item.Delete();
            SetItemSprite(item, pb);
            ItemUpdated();
        }

        private void ClickClone(object sender, EventArgs e)
        {
            var pb = WinFormsUtil.GetUnderlyingControl<PictureBox>(sender);
            if (pb == null)
                return;
            var index = SlotPictureBoxes.IndexOf(pb);
            var item = GetItem(index);
            for (int i = 0; i < SlotPictureBoxes.Count; i++)
            {
                if (i == index)
                    continue;
                var dest = GetItem(i);
                dest.CopyFrom(item);
                SetItemSprite(item, SlotPictureBoxes[i]);
                ItemUpdated();
            }
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void SetItemSprite(Item item, PictureBox pb)
        {
            var dw = Sprites.Width;
            var dh = Sprites.Height;
            var font = L_ItemName.Font;
            pb.BackColor = ItemColor.GetItemColor(item);
            pb.BackgroundImage = ItemSprite.GetItemSprite(item);
            var backing = new Bitmap(dw, dh);
            pb.Image = ItemSprite.GetItemMarkup(item, font, dw, dh, backing);
        }

        private int GetPageJump()
        {
            return ModifierKeys switch
            {
                Keys.Control => 10,
                Keys.Alt => 25,
                Keys.Shift => 1000,
                _ => 1
            };
        }

        private void B_Up_Click(object sender, EventArgs e)
        {
            if (Page == 0)
                return;
            Page = Math.Max(0, Page - GetPageJump());
            ChangePage();
        }

        private void B_Down_Click(object sender, EventArgs e)
        {
            if (ItemsPerPage * (Page + 1) == Count)
                return;
            Page = Math.Min(PageCount - 1, Page + GetPageJump());
            ChangePage();
        }

        private int PageCount => Count / ItemsPerPage;

        private void ChangePage()
        {
            bool hasPages = Count > ItemsPerPage;
            B_Up.Visible = hasPages && Page > 0;
            B_Down.Visible = hasPages && Page < PageCount;
            L_Page.Visible = hasPages;

            L_Page.Text = $"{Page + 1}/{Count / ItemsPerPage}";
            LoadItems();
        }

        public void LoadItems()
        {
            for (int i = 0; i < SlotPictureBoxes.Count; i++)
            {
                var item = GetItem(i);
                SetItemSprite(item, SlotPictureBoxes[i]);
            }
            ItemUpdated();
        }

        private static void ShowContextMenuBelow(ToolStripDropDown c, Control n) => c.Show(n.PointToScreen(new Point(0, n.Height)));
        private void B_Clear_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_Remove, B_Clear);


        private void ClearItemIf(Func<Item, bool> criteria)
        {
            bool all = ModifierKeys == Keys.Shift;
            int start = 0, end = Items.Count - 1;
            if (!all)
            {
                start = ItemsPerPage * Page;
                end = start + ItemsPerPage;
            }
            for (int i = start; i < end; i++)
            {
                var item = Items[i];
                if (criteria(item))
                    item.Delete();
            }
            LoadItems();
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_ClearAll_Click(object sender, EventArgs e) => ClearItemIf(_ => true);
        private void B_ClearClothing_Click(object sender, EventArgs e) => ClearItemIf(z => ItemInfo.GetItemKind(z).IsClothing());
        private void B_ClearCrafting_Click(object sender, EventArgs e) => ClearItemIf(z => ItemInfo.GetItemKind(z).IsCrafting());
        private void B_ClearFurniture_Click(object sender, EventArgs e) => ClearItemIf(z => ItemInfo.GetItemKind(z).IsFurniture());
        private void B_ClearBugs_Click(object sender, EventArgs e) => ClearItemIf(z => GameLists.Bugs.Contains(z.ItemId));
        private void B_ClearFish_Click(object sender, EventArgs e) => ClearItemIf(z => GameLists.Fish.Contains(z.ItemId));

        private class GridSize : IGridItem
        {
            public int Width { get; set; } = 64;
            public int Height { get; set; } = 64;
        }
    }
}

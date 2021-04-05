using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Injection;

namespace NHSE.WinForms
{
    public partial class PlayerItemEditor : Form
    {
        private readonly Action LoadItems;
        private readonly ItemGridEditor ItemGrid;
        private readonly ItemArrayEditor<Item> ItemArray;

        public PlayerItemEditor(IReadOnlyList<Item> array, int width, int height, bool sysbot = false)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            ItemArray = new ItemArrayEditor<Item>(array);

            var Editor = ItemGrid = new ItemGridEditor(ItemEditor, array) {Dock = DockStyle.Fill};
            Editor.InitializeGrid(width, height, 64, 64);
            PAN_Items.Controls.Add(Editor);

            ItemEditor.Initialize(GameInfo.Strings.ItemDataSource);
            Editor.LoadItems();
            DialogResult = DialogResult.Cancel;
            LoadItems = () => Editor.LoadItems();
            B_Inject.Visible = sysbot;

            EnableDragDrop(this, ItemEditor_DragEnter, PlayerItemEditor_DragDrop);
            EnableDragDrop(PAN_Items, ItemEditor_DragEnter, PlayerItemEditor_DragDrop);
            EnableDragDrop(ItemEditor, ItemEditor_DragEnter, PlayerItemEditor_DragDrop);
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void B_Dump_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Inventory (*.nhi)|*.nhi|All files (*.*)|*.*",
                FileName = "items.nhi",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            var bytes = ItemArray.Write();
            File.WriteAllBytes(sfd.FileName, bytes);
        }

        private void B_Load_Click(object sender, EventArgs e)
        {
            bool skipOccupiedSlots = (ModifierKeys & Keys.Alt) != 0;
            bool importCheatClipboard = (ModifierKeys & Keys.Control) != 0;
            if (importCheatClipboard && Clipboard.ContainsText())
            {
                var text = Clipboard.GetText();
                var bytes = ItemCheatCode.ReadCode(text);
                if (bytes.Length % ItemArray.ItemSize == 0)
                {
                    ImportItemData(bytes, skipOccupiedSlots);
                    return;
                }
            }

            using var sfd = new OpenFileDialog
            {
                Filter = "New Horizons Inventory (*.nhi)|*.nhi|All files (*.*)|*.*",
                FileName = "items.nhi",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var data = File.ReadAllBytes(sfd.FileName);
            ImportItemData(data, skipOccupiedSlots);
        }

        private void ImportItemData(byte[] data, bool skipOccupiedSlots, int start = 0)
        {
            ItemArray.ImportItemDataX(data, skipOccupiedSlots, start);

            LoadItems();
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_Inject_Click(object sender, EventArgs e)
        {
            var exist = WinFormsUtil.FirstFormOfType<SysBotUI>();
            if (exist != null)
            {
                exist.Show();
				exist.BringToFront();
				exist.CenterToForm(this);
                return;
            }

            void AfterRead(InjectionResult r)
            {
                if (r == InjectionResult.Success)
                    LoadItems();
            }

            static void AfterWrite(InjectionResult r)
            {
                Debug.WriteLine($"Write result: {r}");
                System.Media.SystemSounds.Asterisk.Play();
            }

            var sb = new SysBotController(InjectionType.Pouch);
            var pockInject = new PocketInjector(ItemArray.Items, sb.Bot);
            var ai = new AutoInjector(pockInject, AfterRead, AfterWrite);
            var ub = new USBBotController();
            var pockInjectUSB = new PocketInjector(ItemArray.Items, ub.Bot);
            var aiUSB = new AutoInjector(pockInjectUSB, AfterRead, AfterWrite);

            ItemGrid.ItemChanged = () => ai.Write();
            var sysbot = new SysBotUI(ai, sb, aiUSB, ub);
            sysbot.Show();
        }

        private void ItemEditor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void PlayerItemEditor_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length != 1 || Directory.Exists(files[0]))
                return;

            string path = files[0]; // open first D&D
            var fi = new FileInfo(path);
            if (fi.Length > ItemArray.TotalSize || fi.Length % Item.SIZE != 0)
                return;

            System.Media.SystemSounds.Asterisk.Play();
            var data = File.ReadAllBytes(path);
            if (sender == ItemEditor)
            {
                var item = new Item(BitConverter.ToUInt64(data, 0));
                ItemEditor.LoadItem(item);
            }
            else
            {
                bool skipOccupiedSlots = (ModifierKeys & Keys.Alt) != 0;
                ImportItemData(data, skipOccupiedSlots);
            }
        }

        public static void EnableDragDrop(Control parent, DragEventHandler enter, DragEventHandler drop)
        {
            parent.AllowDrop = true;
            parent.DragEnter += enter;
            parent.DragDrop += drop;
            foreach (var control in parent.Controls.OfType<PictureBox>())
            {
                control.AllowDrop = true;
                control.DragEnter += enter;
                control.DragDrop += drop;
            }
        }
    }
}

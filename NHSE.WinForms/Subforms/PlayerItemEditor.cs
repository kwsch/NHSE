using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Injection;

namespace NHSE.WinForms
{
    public partial class PlayerItemEditor<T> : Form where T : Item
    {
        private readonly IReadOnlyList<T> Items;
        private readonly Action LoadItems;
        private readonly ItemGridEditor ItemGrid;

        public PlayerItemEditor(IReadOnlyList<T> array, int width, int height, bool sysbot = false)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            Items = array;

            var Editor = ItemGrid = new ItemGridEditor(ItemEditor, Items) {Dock = DockStyle.Fill};
            Editor.InitializeGrid(width, height);
            PAN_Items.Controls.Add(Editor);

            ItemEditor.Initialize(GameInfo.Strings.ItemDataSource);
            Editor.LoadItems();
            DialogResult = DialogResult.Cancel;
            LoadItems = () => Editor.LoadItems();
            B_Inject.Visible = sysbot;
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
            var bytes = Items.SetArray(Items[0].ToBytesClass().Length);
            File.WriteAllBytes(sfd.FileName, bytes);
        }

        private void B_Load_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control && Clipboard.ContainsText())
            {
                var text = Clipboard.GetText();
                var bytes = ItemCheatCode.ReadCode(text);
                var expect = Items[0].ToBytesClass().Length;
                if (bytes.Length % expect == 0)
                {
                    ImportItemData(bytes, expect);
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
            ImportItemData(data, Items[0].ToBytesClass().Length);
        }

        private void ImportItemData(byte[] data, int expect)
        {
            var import = data.GetArray<T>(expect);
            for (int i = 0; i < import.Length; i++)
                Items[i].CopyFrom(import[i]);

            LoadItems();
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_Inject_Click(object sender, EventArgs e)
        {
            var exist = WinFormsUtil.FirstFormOfType<SysBotUI>();
            if (exist != null)
            {
                exist.Show();
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
            var pockInject = new PocketInjector(Items, sb.Bot);
            var ai = new AutoInjector(pockInject, AfterRead, AfterWrite);

            ItemGrid.ItemChanged = () => ai.Write(true);
            var sysbot = new SysBotUI(ai, sb);
            sysbot.Show();
        }
    }
}

using System;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class SingleItemEditor : Form
    {
        public Item Item { get; }

        public SingleItemEditor(Item item)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);

            // disassociate from original reference
            Item = item.ToBytesClass().ToClass<Item>();

            ItemEditor.Initialize(GameInfo.Strings.ItemDataSource);
            ItemEditor.LoadItem(Item);
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            ItemEditor.SetItem(Item);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

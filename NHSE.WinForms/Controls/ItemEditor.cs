using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class ItemEditor : UserControl
    {
        public ItemEditor()
        {
            InitializeComponent();
        }

        public void Initialize(string[] itemnames)
        {
            foreach (var item in itemnames)
                CB_ItemID.Items.Add(item);

            LoadItem(Item.NO_ITEM);
        }

        public Item LoadItem(Item item)
        {
            var id = item.ItemId;
            if (id == Item.NONE)
                id = 0;
            CB_ItemID.SelectedIndex = id;
            NUD_Count.Value = item.Count;
            NUD_Uses.Value = item.UseCount;
            NUD_Flag0.Value = item.Flags0;
            NUD_Flag1.Value = item.Flags1;
            NUD_Flag2.Value = item.Flags2;
            return item;
        }

        public Item SetItem(Item item)
        {
            var id = CB_ItemID.SelectedIndex;
            if (id <= 0)
                id = Item.NONE;
            item.ItemId = (ushort) id;
            item.Count = (byte) NUD_Count.Value;
            item.UseCount = (ushort) NUD_Uses.Value;
            item.Flags0 = (byte) NUD_Flag0.Value;
            item.Flags1 = (byte) NUD_Flag1.Value;
            item.Flags2 = (byte) NUD_Flag2.Value;
            return item;
        }
    }
}

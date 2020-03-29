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
            var none = itemnames[0];
            itemnames[0] = string.Empty;
            var dataSource = ComboItemUtil.GetArray(itemnames);
            dataSource.Add(new ComboItem(none, Item.NONE));
            dataSource.SortByText();

            CB_ItemID.DisplayMember = nameof(ComboItem.Text);
            CB_ItemID.ValueMember = nameof(ComboItem.Value);
            CB_ItemID.DataSource = dataSource;

            LoadItem(Item.NO_ITEM);
        }

        public Item LoadItem(Item item)
        {
            CB_ItemID.SelectedValue = (int)item.ItemId;
            NUD_Count.Value = item.Count;
            NUD_Uses.Value = item.UseCount;
            NUD_Flag0.Value = item.Flags0;
            NUD_Flag1.Value = item.Flags1;
            NUD_Flag2.Value = item.Flags2;
            return item;
        }

        public Item SetItem(Item item)
        {
            var id = WinFormsUtil.GetIndex(CB_ItemID);
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

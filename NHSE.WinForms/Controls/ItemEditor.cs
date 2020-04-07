using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class ItemEditor : UserControl
    {
        private readonly List<ComboItem> Recipes = GameInfo.Strings.CreateItemDataSource(RecipeList.Recipes, false);

        public ItemEditor() => InitializeComponent();

        private ItemKind kind;
        private ushort itemID;

        public void Initialize(List<ComboItem> items)
        {
            CB_ItemID.DisplayMember = nameof(ComboItem.Text);
            CB_ItemID.ValueMember = nameof(ComboItem.Value);
            CB_ItemID.DataSource = items;

            CB_NamedItemArgument.DisplayMember = nameof(ComboItem.Text);
            CB_NamedItemArgument.ValueMember = nameof(ComboItem.Value);
            CB_NamedItemArgument.DataSource = Recipes;

            LoadItem(Item.NO_ITEM);
        }

        public Item LoadItem(Item item)
        {
            CB_ItemID.SelectedValue = (int)item.ItemId;
            NUD_Count.Value = item.Count;
            NUD_Uses.Value = item.UseCount;
            NUD_Flag0.Value = item.Flags0;
            NUD_Flag1.Value = item.Flags1;
            return item;
        }

        public Item SetItem(Item item)
        {
            var id = WinFormsUtil.GetIndex(CB_ItemID);
            item.ItemId = (ushort) id;
            item.Count = (ushort) NUD_Count.Value;
            item.UseCount = (ushort) NUD_Uses.Value;
            item.Flags0 = (byte) NUD_Flag0.Value;
            item.Flags1 = (byte) NUD_Flag1.Value;
            return item;
        }

        private void CB_ItemID_SelectedValueChanged(object sender, EventArgs e)
        {
            itemID = (ushort)WinFormsUtil.GetIndex(CB_ItemID);
            kind = ItemInfo.GetItemKind(itemID);

            switch (kind)
            {
                case ItemKind.Kind_DIYRecipe:
                    CB_NamedItemArgument.SelectedValue = (int) NUD_Count.Value;

                    CB_NamedItemArgument.Visible = true;
                    FLP_Uses.Visible = FLP_Count.Visible = FLP_Flag0.Visible = FLP_Flag1.Visible = false;
                    break;

                default:
                    CB_NamedItemArgument.Visible = false;
                    FLP_Uses.Visible = FLP_Count.Visible = FLP_Flag0.Visible = FLP_Flag1.Visible = true;
                    break;
            }
        }

        private void CB_NamedItemArgument_SelectedValueChanged(object sender,EventArgs e)
        {
            var val = WinFormsUtil.GetIndex(CB_NamedItemArgument);
            NUD_Count.Value = Math.Max(0, Math.Min(NUD_Count.Maximum, val));
        }

        private void NUD_Count_ValueChanged(object sender, EventArgs e)
        {
            if (kind == ItemKind.Kind_DIYRecipe)
                CB_NamedItemArgument.SelectedValue = (int) NUD_Count.Value;
        }
    }
}

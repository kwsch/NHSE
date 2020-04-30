using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class ItemEditor : UserControl
    {
        private readonly List<ComboItem> Recipes = GameInfo.Strings.CreateItemDataSource(RecipeList.Recipes, false);
        private readonly CheckBox[] Watered;

        public ItemEditor()
        {
            InitializeComponent();

            Watered = new[]
            {
                CHK_WV0, CHK_WV1,
                CHK_WV2, CHK_WV3,
                CHK_WV4, CHK_WV5,
                CHK_WV6, CHK_WV7,
                CHK_WV8, CHK_WV9,
            };
        }

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

            if (kind.IsFlower())
            {
                LoadGenes(item.Genes);
                CHK_Gold.Checked = item.IsWateredGold;
                CHK_IsWatered.Checked = item.IsWatered;
                NUD_WaterDays.Value = item.DaysWatered;
                for (int i = 0; i < Watered.Length; i++)
                    Watered[i].Checked = item.GetIsWateredByVisitor(i);
            }
            else
            {
                NUD_Count.Value = item.Count;
                NUD_Uses.Value = item.UseCount;
                NUD_Flag0.Value = item.Flags0;
                NUD_Flag1.Value = item.Flags1;
            }

            return item;
        }

        public Item SetItem(Item item)
        {
            var id = WinFormsUtil.GetIndex(CB_ItemID);
            item.ItemId = (ushort) id;
            if (kind.IsFlower())
            {
                item.Genes = SaveGenes();
                item.DaysWatered = (int) NUD_WaterDays.Value;
                item.IsWateredGold = CHK_Gold.Checked;
                item.IsWatered = CHK_IsWatered.Checked;
                for (int i = 0; i < Watered.Length; i++)
                    item.SetIsWateredByVisitor(i, Watered[i].Checked);
            }
            else
            {
                item.Count = (ushort)NUD_Count.Value;
                item.UseCount = (ushort)NUD_Uses.Value;
                item.Flags0 = (byte)NUD_Flag0.Value;
                item.Flags1 = (byte)NUD_Flag1.Value;
            }
            return item;
        }

        private void CB_ItemID_SelectedValueChanged(object sender, EventArgs e)
        {
            itemID = (ushort)WinFormsUtil.GetIndex(CB_ItemID);
            kind = ItemInfo.GetItemKind(itemID);

            if (kind.IsFlower())
            {
                CB_NamedItemArgument.Visible = false;
                FLP_Uses.Visible = FLP_Count.Visible = FLP_Flag0.Visible = FLP_Flag1.Visible = false;
                FLP_FlowerFlags.Visible = FLP_Genetics.Visible = true;
                return;
            }

            switch (kind)
            {
                case ItemKind.Kind_DIYRecipe:
                    CB_NamedItemArgument.SelectedValue = (int) NUD_Count.Value;

                    CB_NamedItemArgument.Visible = true;
                    FLP_Uses.Visible = FLP_Count.Visible = FLP_Flag0.Visible = FLP_Flag1.Visible = false;
                    FLP_FlowerFlags.Visible = FLP_Genetics.Visible = false;
                    break;

                default:
                    CB_NamedItemArgument.Visible = false;
                    FLP_Uses.Visible = FLP_Count.Visible = FLP_Flag0.Visible = FLP_Flag1.Visible = true;
                    FLP_FlowerFlags.Visible = FLP_Genetics.Visible = false;
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

        private void LoadGenes(FlowerGene genes)
        {
            CHK_R1.Checked = (genes & FlowerGene.R1) != 0;
            CHK_R2.Checked = (genes & FlowerGene.R2) != 0;
            CHK_Y1.Checked = (genes & FlowerGene.Y1) != 0;
            CHK_Y2.Checked = (genes & FlowerGene.Y2) != 0;
            CHK_W1.Checked = (genes & FlowerGene.W1) != 0;
            CHK_W2.Checked = (genes & FlowerGene.W2) != 0;
            CHK_S1.Checked = (genes & FlowerGene.S1) != 0;
            CHK_S2.Checked = (genes & FlowerGene.S2) != 0;
        }

        private FlowerGene SaveGenes()
        {
            var val = FlowerGene.None;
            if (CHK_R1.Checked) val |= FlowerGene.R1;
            if (CHK_R2.Checked) val |= FlowerGene.R2;
            if (CHK_Y1.Checked) val |= FlowerGene.Y1;
            if (CHK_Y2.Checked) val |= FlowerGene.Y2;
            if (CHK_W1.Checked) val |= FlowerGene.W1;
            if (CHK_W2.Checked) val |= FlowerGene.W2;
            if (CHK_S1.Checked) val |= FlowerGene.S1;
            if (CHK_S2.Checked) val |= FlowerGene.S2;
            return val;
        }

        private void L_WaterDays_Click(object sender, EventArgs e)
        {
            bool value = (ModifierKeys & Keys.Alt) == 0;
            CHK_Gold.Checked = value;
            CHK_IsWatered.Checked = value;
            NUD_WaterDays.Value = value ? 31 : 0;
            foreach (var v in Watered)
                v.Checked = value;
        }
    }
}

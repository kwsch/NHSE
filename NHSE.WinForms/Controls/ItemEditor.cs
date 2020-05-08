using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class ItemEditor : UserControl
    {
        private readonly List<ComboItem> Recipes = GameInfo.Strings.CreateItemDataSource(RecipeList.Recipes, false);
        private readonly List<ComboItem> Fossils = GameInfo.Strings.CreateItemDataSource(GameLists.Fossils, false);
        private readonly CheckBox[] Watered;

        private bool Loading = true;

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

        public void Initialize(List<ComboItem> items)
        {
            CB_ItemID.DisplayMember = nameof(ComboItem.Text);
            CB_ItemID.ValueMember = nameof(ComboItem.Value);
            CB_ItemID.DataSource = items;

            CB_Recipe.DisplayMember = nameof(ComboItem.Text);
            CB_Recipe.ValueMember = nameof(ComboItem.Value);
            CB_Recipe.DataSource = Recipes;

            CB_Fossil.DisplayMember = nameof(ComboItem.Text);
            CB_Fossil.ValueMember = nameof(ComboItem.Value);
            CB_Fossil.DataSource = Fossils;

            LoadItem(Item.NO_ITEM);
        }

        public Item LoadItem(Item item)
        {
            Loading = true;
            CB_ItemID.SelectedValue = (int)item.ItemId;
            var kind = ItemInfo.GetItemKind(item.ItemId);

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
                NUD_Flag0.Value = item.SystemParam;
                NUD_Flag1.Value = item.AdditionalParam;

                LoadItemTypeValues(kind);
            }

            Loading = false;
            return item;
        }

        public Item SetItem(Item item)
        {
            var id = (ushort)WinFormsUtil.GetIndex(CB_ItemID);
            var kind = ItemInfo.GetItemKind(id);

            item.ItemId = id;
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
                item.SystemParam = (byte)NUD_Flag0.Value;
                item.AdditionalParam = (byte)NUD_Flag1.Value;
            }
            return item;
        }

        private void CB_ItemID_SelectedValueChanged(object sender, EventArgs e)
        {
            var itemID = (ushort)WinFormsUtil.GetIndex(CB_ItemID);
            var kind = ItemInfo.GetItemKind(itemID);

            ToggleEditorVisibility(kind);
            if (!Loading)
                LoadItemTypeValues(kind);

            var remake = ItemRemakeUtil.GetRemakeIndex(itemID);
            if (remake < 0)
            {
                L_RemakeBody.Visible = false;
                L_RemakeFabric.Visible = false;
            }
            else
            {
                var info = ItemRemakeInfoData.List[remake];
                var body = info.GetBodySummary();
                L_RemakeBody.Text = body;
                L_RemakeBody.Visible = body.Length != 0;

                var fabric = info.GetFabricSummary();
                L_RemakeFabric.Text = fabric;
                L_RemakeFabric.Visible = fabric.Length != 0;
            }
        }

        private void LoadItemTypeValues(ItemKind k)
        {
            switch (k)
            {
                case ItemKind.Kind_FossilUnknown:
                    CB_Fossil.SelectedValue = (int) NUD_Count.Value;
                    break;

                case ItemKind.Kind_DIYRecipe:
                case ItemKind.Kind_MessageBottle:
                    CB_Recipe.SelectedValue = (int) NUD_Count.Value;
                    break;
            }
        }

        private void ToggleEditorVisibility(ItemKind k)
        {
            if (k.IsFlower())
            {
                CB_Recipe.Visible = false;
                FLP_Uses.Visible = FLP_Count.Visible = FLP_Flag0.Visible = FLP_Flag1.Visible = false;
                FLP_FlowerFlags.Visible = FLP_Genetics.Visible = true;
                return;
            }

            switch (k)
            {
                case ItemKind.Kind_FossilUnknown:
                    CB_Fossil.Visible = true;

                    CB_Recipe.Visible = false;
                    FLP_Uses.Visible = FLP_Count.Visible = FLP_Flag0.Visible = FLP_Flag1.Visible = false;
                    FLP_FlowerFlags.Visible = FLP_Genetics.Visible = false;
                    break;

                case ItemKind.Kind_DIYRecipe:
                case ItemKind.Kind_MessageBottle:
                    CB_Recipe.Visible = true;

                    CB_Fossil.Visible = false;
                    FLP_Uses.Visible = FLP_Count.Visible = FLP_Flag0.Visible = FLP_Flag1.Visible = false;
                    FLP_FlowerFlags.Visible = FLP_Genetics.Visible = false;
                    break;

                default:
                    CB_Fossil.Visible = false;
                    CB_Recipe.Visible = false;
                    FLP_Uses.Visible = FLP_Count.Visible = FLP_Flag0.Visible = FLP_Flag1.Visible = true;
                    FLP_FlowerFlags.Visible = FLP_Genetics.Visible = false;
                    break;
            }
        }

        private void CB_CountAlias_SelectedValueChanged(object sender,EventArgs e)
        {
            var val = WinFormsUtil.GetIndex((ComboBox)sender);
            NUD_Count.Value = Math.Max(0, Math.Min(NUD_Count.Maximum, val));
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

        private void CB_KeyDown(object sender, KeyEventArgs e) => WinFormsUtil.RemoveDropCB(sender, e);
    }
}

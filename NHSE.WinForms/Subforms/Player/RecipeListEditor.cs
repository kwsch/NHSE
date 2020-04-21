using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class RecipeListEditor : Form
    {
        private readonly Player Player;
        private readonly bool[] Known;
        private const string Unknown = "???";

        public RecipeListEditor(Player player)
        {
            Player = player;
            Known = Player.Personal.GetRecipeList();
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);

            var gotoSource = FillCheckBoxes();
            gotoSource.SortByText();
            CB_Goto.DisplayMember = nameof(ComboItem.Text);
            CB_Goto.ValueMember = nameof(ComboItem.Value);
            CB_Goto.DataSource = new BindingSource(gotoSource, null);
        }

        private List<ComboItem> FillCheckBoxes()
        {
            var recipes = RecipeList.Recipes;
            var max = (ushort)Known.Length - 1;

            var strings = GameInfo.Strings.itemlist;
            var gotoSource = new List<ComboItem>();
            for (ushort i = 0; i <= max; i++)
            {
                bool exists = recipes.TryGetValue(i, out var value);
                string item = exists ? strings[value] : Unknown;
                if (string.IsNullOrEmpty(item))
                    item = value.ToString();
                string name = $"0x{i:X3} - {item}";
                CLB_Recipes.Items.Add(name, Known[i]);
                if (exists)
                    gotoSource.Add(new ComboItem(item, i));
            }
            return gotoSource;
        }

        private void B_All_Click(object sender, EventArgs e)
        {
            var recipes = RecipeList.Recipes;
            for (ushort i = 0; i < CLB_Recipes.Items.Count; i++)
            {
                bool exists = recipes.ContainsKey(i);
                CLB_Recipes.SetItemChecked(i, exists);
            }
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Known.Length; i++)
                Known[i] = CLB_Recipes.GetItemChecked(i);
            Player.Personal.SetRecipeList(Known);
            Close();
        }

        private void CB_Goto_SelectedValueChanged(object sender, EventArgs e) => CLB_Recipes.SelectedIndex = WinFormsUtil.GetIndex(CB_Goto);
    }
}

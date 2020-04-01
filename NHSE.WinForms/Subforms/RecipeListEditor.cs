using System;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Core.Structures;

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
            FillCheckBoxes();
        }

        private void FillCheckBoxes()
        {
            var recipes = RecipeList.Recipes;
            var max = (ushort)Known.Length - 1;

            var strings = GameInfo.Strings.itemlist;
            for (ushort i = 0; i <= max; i++)
            {
                bool exists = recipes.TryGetValue(i, out var value);
                string item = exists ? strings[value] : Unknown;
                if (string.IsNullOrEmpty(item))
                    item = value.ToString();
                string name = $"0x{i:X3} - {item}";
                CLB_Recipes.Items.Add(name, Known[i]);
            }
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
    }
}

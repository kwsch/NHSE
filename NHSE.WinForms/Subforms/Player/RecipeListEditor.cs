using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class RecipeListEditor : Form
    {
        private readonly Player Player;
        private readonly RecipeBook Book;
        private const string Unknown = "???";

        public RecipeListEditor(Player player)
        {
            Player = player;
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);

            Book = player.Personal.GetRecipeBook();
            var gotoSource = FillCheckBoxes();
            gotoSource.SortByText();
            CB_Goto.DisplayMember = nameof(ComboItem.Text);
            CB_Goto.ValueMember = nameof(ComboItem.Value);
            CB_Goto.DataSource = new BindingSource(gotoSource, null);
        }

        private List<ComboItem> FillCheckBoxes()
        {
            var book = Book;
            var recipes = RecipeList.Recipes;
            var strings = GameInfo.Strings.itemlist;
            const ushort max = RecipeBook.RecipeCount;
            FillListBox(max, recipes, strings, book);

            var gotoSource = new List<ComboItem>();
            return GetJumpList(max, recipes, strings, gotoSource);
        }

        private void FillListBox(ushort max, IReadOnlyDictionary<ushort, ushort> recipes, string[] strings, RecipeBook book)
        {
            Loading = true;
            for (ushort i = 0; i <= max; i++)
            {
                var name = GetItemName(i, recipes, strings);
                var text = GetEntryText(book, i, name);
                LB_Recipes.Items.Add(text);
            }
            Loading = false;
        }

        private static List<ComboItem> GetJumpList(ushort max, IReadOnlyDictionary<ushort, ushort> recipes, string[] strings, List<ComboItem> gotoSource)
        {
            for (ushort i = 0; i <= max; i++)
            {
                var name = GetItemName(i, recipes, strings);
                if (recipes.ContainsKey(i))
                    gotoSource.Add(new ComboItem(name, i));
            }

            return gotoSource;
        }

        private static string GetItemName(ushort index, IReadOnlyDictionary<ushort, ushort> recipes, string[] itemNames)
        {
            bool exists = recipes.TryGetValue(index, out var value);
            string item = exists ? itemNames[value] : Unknown;
            if (string.IsNullOrEmpty(item))
                item = value.ToString();
            return item;
        }

        private static object GetEntryText(RecipeBook recipeBook, ushort index, string item)
        {
            var known = recipeBook.GetIsKnown(index) ? "✅" : "❌";
            return $"0x{index:X3} - {known} {item}";
        }

        private void B_All_Click(object sender, EventArgs e) => DoAll(() => Book.GiveAll(RecipeList.Recipes));
        private void B_ClearAll_Click(object sender, EventArgs e) => DoAll(Book.ClearAll);
        private void B_CraftAll_Click(object sender, EventArgs e) => DoAll(Book.CraftAll);

        private void DoAll(Action action)
        {
            var index = LB_Recipes.SelectedIndex;
            var book = Book;
            var recipes = RecipeList.Recipes;
            var strings = GameInfo.Strings.itemlist;
            const ushort max = RecipeBook.RecipeCount;

            action();
            LB_Recipes.Items.Clear();
            FillListBox(max, recipes, strings, book);
            LoadIndex(index);
            LB_Recipes.SelectedIndex = index;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            Player.Personal.SetRecipeBook(Book);
            Close();
        }

        private void CB_Goto_SelectedValueChanged(object sender, EventArgs e) => LB_Recipes.SelectedIndex = WinFormsUtil.GetIndex(CB_Goto);

        private int Index = -1;
        private bool Loading;
        private void LB_Recipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            SaveIndex(Index);
            Index = LB_Recipes.SelectedIndex;
            Loading = true;
            LoadIndex(Index);
            Loading = false;
        }

        private void LoadIndex(in int index)
        {
            if (index < 0)
                return;
            var book = Book;
            CHK_Known.Checked = book.GetIsKnown(index);
            CHK_New.Checked = book.GetIsNew(index);
            CHK_Made.Checked = book.GetIsMade(index);
            CHK_Favorite.Checked = book.GetIsFavorite(index);
        }

        private void SaveIndex(in int index)
        {
            if (index < 0)
                return;
            var book = Book;
            book.SetIsKnown(index, CHK_Known.Checked);
            book.SetIsNew(index, CHK_New.Checked);
            book.SetIsMade(index, CHK_Made.Checked);
            book.SetIsFavorite(index, CHK_Favorite.Checked);
        }

        private void CHK_Known_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            Loading = true;
            var book = Book;
            book.SetIsKnown(Index, CHK_Known.Checked);
            var recipes = RecipeList.Recipes;
            var strings = GameInfo.Strings.itemlist;
            var name = GetItemName((ushort)Index, recipes, strings);
            LB_Recipes.Items[Index] = GetEntryText(book, (ushort)Index, name);
            Loading = false;
        }
    }
}

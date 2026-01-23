using NHSE.Core;
using NHSE.Sprites;
using System;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Forms;

namespace NHSE.WinForms;

public partial class FruitsFlowersEditor : Form
{
    private readonly Player Player;
    private readonly MainSave Save;

    public FruitsFlowersEditor(Player p, MainSave s)
    {
        InitializeComponent();
        this.TranslateInterface(GameInfo.CurrentLanguage);
        Player = p;
        Save = s;

        var fruitsSpecialty = ComboItemUtil.GetArray(GameLists.Fruits, GameInfo.Strings.itemlistdisplay);
        RIS_ProfileFruit.Initialize(fruitsSpecialty);

        var fruitsSister = ComboItemUtil.GetArray(GameLists.Fruits, GameInfo.Strings.itemlistdisplay);
        RIS_SisterFruit.Initialize(fruitsSister);

        LoadFruitsFlowers();
    }

    private void LoadFruitsFlowers()
    {
        var p = Player;
        var pers = p.Personal;

        var sav = Save;

        RIS_ProfileFruit.Value = pers.ProfileFruit;
        RIS_SisterFruit.Value = sav.SisterFruit;

        var flowersProfile = Enum.GetNames<IslandFlowers>();
        CB_ProfileFlower.Items.AddRange(flowersProfile);
        CB_ProfileFlower.SelectedIndex = (int)sav.SpecialtyFlower;

        var flowersSister = Enum.GetNames<IslandFlowers>();
        CB_SisterFlower.Items.AddRange(flowersSister);
        CB_SisterFlower.SelectedIndex = (int)sav.SisterFlower;
    }

    private void B_Cancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void B_Save_Click(object sender, EventArgs e)
    {
        SaveFruitsFlowers();

        DialogResult = DialogResult.OK;
        Close();
    }

    public void UpdateFruitFlags(MainSave sav)
    {
        var fruit = new byte[] { 00, 00, 00, 00, 00 };
        switch (sav.SpecialtyFruit)
        {
            case 2213: // Apple
                fruit[0] = 01;
                break;
            case 2287: // Cherry
                fruit[4] = 01;
                break;
            case 2214: // Orange
                fruit[1] = 01;
                break;
            case 2286: // Peach
                fruit[3] = 01;
                break;
            case 2285: // Pear
                fruit[2] = 01;
                break;
        }
        sav.FruitFlags = fruit;
    }

    private void SaveFruitsFlowers()
    {
        var p = Player;
        var pers = p.Personal;

        var sav = Save;

        pers.ProfileFruit = RIS_ProfileFruit.Value;
        sav.SpecialtyFruit = RIS_ProfileFruit.Value;
        sav.SisterFruit = RIS_SisterFruit.Value;
        UpdateFruitFlags(sav);

        sav.SpecialtyFlower = (IslandFlowers)CB_ProfileFlower.SelectedIndex;
        sav.SisterFlower = (IslandFlowers)CB_SisterFlower.SelectedIndex;
    }
}


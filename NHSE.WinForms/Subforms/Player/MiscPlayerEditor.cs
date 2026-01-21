using NHSE.Core;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace NHSE.WinForms;

public partial class MiscPlayerEditor : Form
{
    private readonly Player Player;
    private readonly MainSave Save;

    public MiscPlayerEditor(Player p, MainSave s)
    {
        InitializeComponent();
        this.TranslateInterface(GameInfo.CurrentLanguage);
        Player = p;
        Save = s;

        var fruitsSpecialty = ComboItemUtil.GetArray(GameLists.Fruits, GameInfo.Strings.itemlistdisplay);
        RIS_ProfileFruit.Initialize(fruitsSpecialty);

        var fruitsSister = ComboItemUtil.GetArray(GameLists.Fruits, GameInfo.Strings.itemlistdisplay);
        RIS_SisterFruit.Initialize(fruitsSister);

        LoadPlayer();
    }

    private void LoadPlayer()
    {
        var p = Player;
        var pers = p.Personal;

        var sav = Save;

        var bd = pers.Birthday;
        NUD_BirthDay.Value = bd.Day;
        NUD_BirthMonth.Value = bd.Month;

        CHK_ProfileMadeVillage.Checked = pers.ProfileIsMakeVillage;

        RIS_ProfileFruit.Value = pers.ProfileFruit;
        RIS_SisterFruit.Value = sav.SisterFruit;

        var flowersProfile = Enum.GetNames<IslandFlowers>();
        CB_ProfileFlower.Items.AddRange(flowersProfile);
        CB_ProfileFlower.SelectedIndex = (int)sav.SpecialtyFlower;

        var flowersSister = Enum.GetNames<IslandFlowers>();
        CB_SisterFlower.Items.AddRange(flowersSister);
        CB_SisterFlower.SelectedIndex = (int)sav.SisterFlower;

        CAL_ProfileTimestamp.Value = pers.ProfileTimestamp;
    }

    private void B_Cancel_Click(object sender, EventArgs e) => Close();

    private void B_Save_Click(object sender, EventArgs e)
    {
        SavePlayer();
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

    private void SavePlayer()
    {
        var p = Player;
        var pers = p.Personal;

        var sav = Save;

        var bd = pers.Birthday;
        bd.Day = (byte) NUD_BirthDay.Value;
        bd.Month = (byte) NUD_BirthMonth.Value;

        pers.Birthday = bd;
        pers.ProfileBirthday = bd;
        pers.ProfileIsMakeVillage = CHK_ProfileMadeVillage.Checked;

        pers.ProfileFruit = RIS_ProfileFruit.Value;
        sav.SpecialtyFruit = RIS_ProfileFruit.Value;
        sav.SisterFruit = RIS_SisterFruit.Value;

        UpdateFruitFlags(sav);

        sav.SpecialtyFlower = (IslandFlowers)CB_ProfileFlower.SelectedIndex;
        sav.SisterFlower = (IslandFlowers)CB_SisterFlower.SelectedIndex;

        pers.ProfileTimestamp = CAL_ProfileTimestamp.Value;
    }
}
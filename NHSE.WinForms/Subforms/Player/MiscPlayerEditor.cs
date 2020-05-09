using System;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class MiscPlayerEditor : Form
    {
        private readonly Player Player;

        public MiscPlayerEditor(Player p)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            Player = p;

            var fruits = ComboItemUtil.GetArray(GameLists.Fruits, GameInfo.Strings.itemlistdisplay);
            ProfileFruit.Initialize(fruits);

            LoadPlayer();
        }

        private void LoadPlayer()
        {
            var p = Player;
            var pers = p.Personal;

            var bd = pers.Birthday;
            NUD_BirthDay.Value = bd.Day;
            NUD_BirthMonth.Value = bd.Month;

            CHK_ProfileMadeVillage.Checked = pers.ProfileIsMakeVillage;
            ProfileFruit.Value = pers.ProfileFruit;
            CAL_ProfileTimestamp.Value = pers.ProfileTimestamp;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            SavePlayer();
            Close();
        }

        private void SavePlayer()
        {
            var p = Player;
            var pers = p.Personal;

            var bd = pers.Birthday;
            bd.Day = (byte) NUD_BirthDay.Value;
            bd.Month = (byte) NUD_BirthMonth.Value;

            pers.Birthday = bd;
            pers.ProfileBirthday = bd;
            pers.ProfileIsMakeVillage = CHK_ProfileMadeVillage.Checked;
            pers.ProfileFruit = ProfileFruit.Value;
            pers.ProfileTimestamp = CAL_ProfileTimestamp.Value;
        }
    }
}

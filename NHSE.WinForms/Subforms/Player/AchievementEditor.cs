using System;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class AchievementEditor : Form
    {
        private readonly uint[] Counts;

        public AchievementEditor(uint[] counts)
        {
            Counts = counts;
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            for (int i = 0; i < counts.Length; i++)
                LB_Counts.Items.Add(LifeSupportAchievement.GetName(i, counts[i]));
            DialogResult = DialogResult.Cancel;
            LB_Counts.SelectedIndex = 0;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private int Index;

        private void NUD_Count_ValueChanged(object sender, EventArgs e)
        {
            if (Index < 0)
                return;

            Counts[Index] = (uint) NUD_Count.Value;
            LB_Counts.Items[Index] = LifeSupportAchievement.GetName(Index, Counts[Index]);
        }

        private void LB_Counts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Counts.SelectedIndex < 0)
                return;

            var val = Counts[Index = LB_Counts.SelectedIndex];
            NUD_Count.Value = (int) val;
        }
    }
}

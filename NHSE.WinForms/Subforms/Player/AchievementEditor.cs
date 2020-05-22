using System;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class AchievementEditor : Form
    {
        private readonly Personal Personal;
        private readonly AchievementList List;
        private readonly AchievementRow[] Rows;

        private int Index = -1;

        public AchievementEditor(Personal personal)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);

            Personal = personal;
            var list = List = personal.Achievements;
            var str = GameInfo.Strings.InternalNameTranslation;
            for (int i = 0; i < list.Counts.Length; i++)
                LB_Counts.Items.Add(LifeSupportAchievement.GetName(i, list.Counts[i], str));

            Rows = new[] {AR_1, AR_2, AR_3, AR_4, AR_5, AR_6};

            LB_Counts.SelectedIndex = 0;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            SaveIndex(Index);
            Personal.Achievements = List;
            Close();
        }

        private void NUD_Count_ValueChanged(object sender, EventArgs e)
        {
            if (Index < 0)
                return;

            List.Counts[Index] = (uint) NUD_Count.Value;

            for (int i = 0; i < Rows.Length; i++)
                Rows[i].ChangeCount(Index, i, List.Counts[Index]);

            SetEntryDescription(Index);
        }

        private void SetEntryDescription(int index)
        {
            LB_Counts.Items[index] = LifeSupportAchievement.GetName(index, List.Counts[index], GameInfo.Strings.InternalNameTranslation);
        }

        private void LB_Counts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Counts.SelectedIndex < 0)
                return;

            SaveIndex(Index);
            LoadIndex(Index = LB_Counts.SelectedIndex);
        }

        private void LoadIndex(int index)
        {
            if (index < 0)
                return;

            for (int i = 0; i < Rows.Length; i++)
                Rows[i].LoadRow(List, Index, i);

            NUD_Unk.Value = List.Flags[index];

            var val = List.Counts[index];
            NUD_Count.Value = (int)val;
        }

        private void SaveIndex(in int index)
        {
            if (index < 0)
                return;

            for (int i = 0; i < Rows.Length; i++)
                Rows[i].SaveRow(List, index, i);

            List.Flags[index] = (byte)NUD_Unk.Value;

            // count updated on value changed
        }

        private void B_Clear_Click(object sender, EventArgs e)
        {
            List.ClearAll(Index);
            LoadIndex(Index);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_Max_Click(object sender, EventArgs e)
        {
            List.GiveAll(Index, DateTime.Now);
            LoadIndex(Index);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_GiveAll_Click(object sender, EventArgs e)
        {
            SaveIndex(Index);
            var index = Index;
            Index = -1;

            List.GiveAll(DateTime.Now);
            for (int i = 0; i < List.Counts.Length; i++)
                SetEntryDescription(i);

            LoadIndex(Index = index);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_ClearAll_Click(object sender, EventArgs e)
        {
            SaveIndex(Index);
            var index = Index;
            Index = -1;

            List.ClearAll();
            for (int i = 0; i < List.Counts.Length; i++)
                SetEntryDescription(i);

            LoadIndex(Index = index);
            System.Media.SystemSounds.Asterisk.Play();
        }
    }
}

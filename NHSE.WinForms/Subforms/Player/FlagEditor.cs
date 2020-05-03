using System;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class FlagEditor : Form
    {
        private readonly short[] Counts;

        public FlagEditor(short[] counts)
        {
            Counts = counts;
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            var str = GameInfo.Strings.InternalNameTranslation;
            for (ushort i = 0; i < counts.Length; i++)
                LB_Counts.Items.Add(EventFlagPlayer.GetName(i, counts[i], str));
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

            Counts[Index] = (short) NUD_Count.Value;
            LB_Counts.Items[Index] = EventFlagPlayer.GetName((ushort)Index, Counts[Index], GameInfo.Strings.InternalNameTranslation);
        }

        private void LB_Counts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Counts.SelectedIndex < 0)
                return;

            NUD_Count.Value = Counts[Index = LB_Counts.SelectedIndex];
        }
    }
}

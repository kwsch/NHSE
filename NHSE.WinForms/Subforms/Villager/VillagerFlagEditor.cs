using System;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class VillagerFlagEditor : Form
    {
        private readonly ushort[] Counts;

        public VillagerFlagEditor(ushort[] counts)
        {
            Counts = counts;
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            var str = GameInfo.Strings.InternalNameTranslation;
            for (ushort i = 0; i < counts.Length; i++)
                LB_Counts.Items.Add(EventFlagVillager.GetName(i, counts[i], str));
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

            Counts[Index] = (ushort) NUD_Count.Value;
            LB_Counts.Items[Index] = EventFlagVillager.GetName((ushort)Index, Counts[Index], GameInfo.Strings.InternalNameTranslation);
        }

        private void LB_Counts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Counts.SelectedIndex < 0)
                return;

            NUD_Count.Value = Counts[Index = LB_Counts.SelectedIndex];
        }

        private void B_Dump_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[Counts.Length * 2];
            Buffer.BlockCopy(Counts, 0, data, 0, data.Length);
            MiscDumpHelper.DumpFlags(data, nameof(EventFlagVillager));
        }

        private void B_Load_Click(object sender, EventArgs e)
        {
            var data = MiscDumpHelper.LoadFlags(Counts.Length * 2, nameof(EventFlagVillager));
            if (data.Length != 0)
                Buffer.BlockCopy(data, 0, Counts, 0, data.Length);
            LB_Counts.SelectedIndex = LB_Counts.SelectedIndex;
        }
    }
}

using System;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class MuseumEditor : Form
    {
        private readonly Core.MuseumEditor Editor;
        private int Index = -1;

        public MuseumEditor(Museum museum)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);

            Editor = new Core.MuseumEditor(museum);
            CAL_Date.MinDate = DateTime.MinValue;

            var str = GameInfo.Strings;
            ItemEdit.Initialize(str.ItemDataSource);
            for (int i = 0; i < Editor.Dates.Length; i++)
                LB_Donations.Items.Add(Editor.GetDonationText(str, i));

            DialogResult = DialogResult.Cancel;
            LB_Donations.SelectedIndex = 0;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Editor.Save();
            Close();
        }

        private void LB_Counts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Donations.SelectedIndex < 0 || Changing)
                return;

            SaveIndex(Index);
            Index = LB_Donations.SelectedIndex;
            LoadIndex(Index);
        }

        private void LoadIndex(in int index)
        {
            if (index < 0)
                return;

            var date = (DateTime)Editor.Dates[index];
            if (date < CAL_Date.MinDate)
                date = CAL_Date.MinDate;
            CAL_Date.Value = date;
            NUD_Player.Value = Editor.Players[index];
            ItemEdit.LoadItem(Editor.Items[index]);
        }

        private void SaveIndex(in int index)
        {
            if (index < 0)
                return;

            var date = CAL_Date.Value;
            if (date == CAL_Date.MinDate)
                date = DateTime.MinValue;
            Editor.Dates[index] = date;
            Editor.Players[index] = (byte)NUD_Player.Value;
            ItemEdit.SetItem(Editor.Items[index]);

            SetNameForIndex(index);
        }

        private bool Changing;

        private void SetNameForIndex(in int index)
        {
            Changing = true;
            LB_Donations.Items[index] = Editor.GetDonationText(GameInfo.Strings, index);
            Changing = false;
        }

        private void B_Dump_Click(object sender, EventArgs e)
        {
            Editor.Save();
            MiscDumpHelper.DumpMuseum(Editor.Museum);
        }

        private void B_Load_Click(object sender, EventArgs e)
        {
            if (!MiscDumpHelper.LoadMuseum(Editor.Museum))
                return;

            // data imported, mark as saved and close
            DialogResult = DialogResult.OK;
            Close();
        }

        private void B_GiveAll_Click(object sender, EventArgs e)
        {
            SaveIndex(Index);
            Editor.GiveAll(GameInfo.GetStrings("en").itemlist, 1000);
            Editor.Save();
            System.Media.SystemSounds.Asterisk.Play();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void B_SortDate_Click(object sender, EventArgs e)
        {
            SaveIndex(Index);
            Editor.SortAll();
            Editor.Save();
            System.Media.SystemSounds.Asterisk.Play();
            DialogResult = DialogResult.OK;
            Close();
        }

        private static void ShowContextMenuBelow(ToolStripDropDown c, Control n) => c.Show(n.PointToScreen(new System.Drawing.Point(0, n.Height)));
        private void B_Tools_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_Tools, B_Tools);
    }
}

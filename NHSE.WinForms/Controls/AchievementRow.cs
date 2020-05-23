using System;
using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class AchievementRow : UserControl
    {
        public AchievementRow()
        {
            InitializeComponent();
            CAL_Date.MinDate = DateTime.MinValue;
        }

        public void LoadRow(AchievementList list, in int index, in int row)
        {
            if (!LifeSupportAchievement.List.TryGetValue(index, out var detail))
            {
                L_Threshold.Text = "N/A";
            }
            else
            {
                if (row >= detail.AchievementCount)
                {
                    L_Threshold.Text = string.Empty;
                }
                else
                {
                    var threshold = detail.GetThresholdValue(row);
                    L_Threshold.Text = threshold <= 0 ? "N/A" : threshold.ToString();
                }
            }

            var date = list.Date[index][row];
            if (date < CAL_Date.MinDate)
                date = CAL_Date.MinDate;
            CAL_Date.Value = date;

            CHK_Read.Checked = list.Read[index][row];
        }

        public void SaveRow(AchievementList list, in int index, in int row)
        {
            list.Date[index][row] = CAL_Date.Value;
            list.Read[index][row] = CHK_Read.Checked;
        }

        public void ChangeCount(in int index, in int row, in uint count)
        {
            if (!LifeSupportAchievement.List.TryGetValue(index, out var detail))
                return;

            bool satisfied = detail.GetIsSatisfied(row, count);
            L_Threshold.ForeColor = satisfied ? Color.Red : CHK_Read.ForeColor;
        }

        private void CAL_Date_MouseDown(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Alt) != 0 && e.Button == MouseButtons.Left)
                CAL_Date.Value = CAL_Date.MinDate;
        }
    }
}

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class AcreEditor : Form
    {
        private readonly NumericUpDown[] Acres;
        private readonly MainSave SAV;

        public AcreEditor(MainSave sav)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            SAV = sav;

            Acres = new[]
            {
                NUD_00, NUD_01, NUD_02, NUD_03, NUD_04, NUD_05, NUD_06, NUD_07, NUD_08,
                NUD_09, NUD_0A, NUD_0B, NUD_0C, NUD_0D, NUD_0E, NUD_0F, NUD_10, NUD_11,
                NUD_12, NUD_13, NUD_14, NUD_15, NUD_16, NUD_17, NUD_18, NUD_19, NUD_1A,
                NUD_1B, NUD_1C, NUD_1D, NUD_1E, NUD_1F, NUD_20, NUD_21, NUD_22, NUD_23,
                NUD_24, NUD_25, NUD_26, NUD_27, NUD_28, NUD_29, NUD_2A, NUD_2B, NUD_2C,
                NUD_2D, NUD_2E, NUD_2F, NUD_30, NUD_31, NUD_32, NUD_33, NUD_34, NUD_35,
                NUD_36, NUD_37, NUD_38, NUD_39, NUD_3A, NUD_3B, NUD_3C, NUD_3D, NUD_3E,
                NUD_3F, NUD_40, NUD_41, NUD_42, NUD_43, NUD_44, NUD_45, NUD_46, NUD_47,
            };

            LoadAcres();

            LoadHintComboBox();
            for (var i = 0; i < Acres.Length; i++)
            {
                var a = Acres[i];
                var x = i % MainSave.AcreWidth;
                var y = i / MainSave.AcreWidth;
                a.MouseEnter += (sender, args) => UpdateAcre((ushort)a.Value, x, y);
                a.ValueChanged += (sender, args) => UpdateAcre((ushort)a.Value, x, y);
            }
        }

        private void UpdateAcre(ushort val, int x, int y)
        {
            var name = OutsideAcreList.GetName(val);
            L_Hovered.Text = $"{x},{y} - 0x{val:X2} = {name}";
            L_Hovered.Visible = true;
        }

        private void LoadHintComboBox()
        {
            var acres = OutsideAcreList.Names.Select(z => $"{z.Value} - {z.Key:X}").ToList();
            acres.Sort();
            foreach (var name in acres)
                CB_AcreNames.Items.Add(name);
            CB_AcreNames.SelectedIndex = 0;
        }

        private void LoadAcres()
        {
            for (int i = 0; i < Acres.Length; i++)
                Acres[i].Value = SAV.GetAcre(i);
        }

        private void SaveAcres()
        {
            for (int i = 0; i < Acres.Length; i++)
                SAV.SetAcre(i, (ushort)Acres[i].Value);
        }

        private void B_Save_Click(object sender, EventArgs e) { SaveAcres(); Close(); }
        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Export_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Acres (*.nha)|*.nha|All files (*.*)|*.*",
                FileName = "acres.nha",
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var original = SAV.GetAcreBytes();
            SaveAcres();
            var modified = SAV.GetAcreBytes();
            SAV.SetAcreBytes(original);

            File.WriteAllBytes(sfd.FileName, modified);
        }

        private void B_Import_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Acres (*.nha)|*.nha|All files (*.*)|*.*",
                FileName = "acres.nha",
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var path = ofd.FileName;
            var original = SAV.GetAcreBytes();
            var modified = File.ReadAllBytes(path);
            if (original.Length != modified.Length)
            {
                WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, modified.Length, original.Length), path);
                return;
            }
            SAV.SetAcreBytes(modified);
            LoadAcres();
            SAV.SetAcreBytes(original);
        }
    }
}

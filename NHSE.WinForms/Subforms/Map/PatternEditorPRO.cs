using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;

namespace NHSE.WinForms
{
    public partial class PatternEditorPRO : Form
    {
        private readonly DesignPatternPRO[] Patterns;

        private int Index;
        private const int scale = 4;

        public PatternEditorPRO(DesignPatternPRO[] patterns)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            Patterns = patterns;
            DialogResult = DialogResult.Cancel;

            foreach (var p in patterns)
                LB_Items.Items.Add(GetPatternSummary(p));

            LB_Items.SelectedIndex = 0;
            SetCM_DLDesign();
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LB_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Items.SelectedIndex < 0)
                return;
            LoadPattern(Patterns[Index = LB_Items.SelectedIndex]);
        }

        private static string GetPatternSummary(DesignPatternPRO p) => p.DesignName;
        private static void ShowContextMenuBelow(ToolStripDropDown c, Control n) => c.Show(n.PointToScreen(new Point(0, n.Height)));
        private void B_DumpLoadDesign_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_DLDesign, B_DumpLoadDesign);
        private void B_DumpDesign_Click(object sender, EventArgs e)
        {
            if ((string)((System.Windows.Forms.ToolStripMenuItem)sender).Name == "B_DumpDesignAll")
            {
                using var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                var dir = Path.GetDirectoryName(fbd.SelectedPath);
                if (dir == null || !Directory.Exists(dir))
                    return;
                Patterns.Dump(fbd.SelectedPath);
                return;
            }

            var original = Patterns[Index];
            var name = original.DesignName;
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons PRO Design (*.nhpd)|*.nhpd|All files (*.*)|*.*",
                FileName = $"{name}.nhpd",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var d = original;
            File.WriteAllBytes(sfd.FileName, d.Data);
        }

        private void B_LoadDesign_Click(object sender, EventArgs e)
        {
            if ((string)((System.Windows.Forms.ToolStripMenuItem)sender).Name == "B_LoadDesignAll")
            {
                using var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                var dir = Path.GetDirectoryName(fbd.SelectedPath);
                if (dir == null || !Directory.Exists(dir))
                    return;
                var result = WinFormsUtil.Prompt(MessageBoxButtons.YesNoCancel, MessageStrings.MsgAskUpdateValues);
                Patterns.Load(fbd.SelectedPath, result == DialogResult.Yes);
                LoadPattern(Patterns[Index]);
                RepopulateList(Index);
                return;
            }

            var original = Patterns[Index];
            var name = original.DesignName;
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons PRO Design (*.nhpd)|*.nhpd|All files (*.*)|*.*",
                FileName = $"{name}.nhpd",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var file = ofd.FileName;
            var expectLength = original.Data.Length;
            var fi = new FileInfo(file);
            if (fi.Length != expectLength)
            {
                var msg = string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength);
                WinFormsUtil.Error(MessageStrings.MsgCanceling, msg);
                return;
            }

            var data = File.ReadAllBytes(ofd.FileName);
            var d = new DesignPatternPRO(data);
            var player0 = original;
            if (!d.IsOriginatedFrom(player0))
            {
                var notHost = string.Format(MessageStrings.MsgDataDidNotOriginateFromHost_0, player0.PlayerName);
                var result = WinFormsUtil.Prompt(MessageBoxButtons.YesNoCancel, notHost, MessageStrings.MsgAskUpdateValues);
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    d.ChangeOrigins(player0, d.Data);
            }

            Patterns[Index] = d;
            LoadPattern(d);
            RepopulateList(Index);
        }

        private void RepopulateList(int index)
        {
            LB_Items.Items.Clear();
            foreach (var p in Patterns)
                LB_Items.Items.Add(GetPatternSummary(p));
            LB_Items.SelectedIndex = index;
            return;
        }

        private void LoadPattern(DesignPatternPRO dp)
        {
            const int w = DesignPatternPRO.Width * scale;
            const int h = DesignPatternPRO.Height * scale;
            PB_Sheet0.Image = ImageUtil.ResizeImage(dp.GetImage(0), w, h);
            PB_Sheet1.Image = ImageUtil.ResizeImage(dp.GetImage(1), w, h);
            PB_Sheet2.Image = ImageUtil.ResizeImage(dp.GetImage(2), w, h);
            PB_Sheet3.Image = ImageUtil.ResizeImage(dp.GetImage(3), w, h);

            PB_Palette.Image = ImageUtil.ResizeImage(dp.GetPalette(), 150, 10);
            L_PatternName.Text = dp.DesignName + Environment.NewLine +
                                 dp.TownName + Environment.NewLine +
                                 dp.PlayerName;
        }

        private void PB_Pattern_MouseEnter(object sender, EventArgs e) => PB_Sheet0.BackColor = Color.GreenYellow;
        private void PB_Pattern_MouseLeave(object sender, EventArgs e) => PB_Sheet0.BackColor = Color.Transparent;

        private void Menu_SavePNG_Click(object sender, EventArgs e)
        {
            var pb = WinFormsUtil.GetUnderlyingControl<PictureBox>(sender);
            if (pb?.Image == null)
            {
                WinFormsUtil.Alert(MessageStrings.MsgNoPictureLoaded);
                return;
            }

            var name = Patterns[Index].DesignName;
            using var sfd = new SaveFileDialog
            {
                Filter = "png file (*.png)|*.png|All files (*.*)|*.*",
                FileName = $"{name}.png",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var bmp = pb.Image;
            bmp.Save(sfd.FileName, ImageFormat.Png);
        }
    }
}

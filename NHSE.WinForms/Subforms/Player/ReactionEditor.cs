using System;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class ReactionEditor : Form
    {
        private readonly Personal Personal;

        public ReactionEditor(Personal p)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);

            Personal = p;
            var manpu = p.Data.Slice(p.Offsets.Manpu, GSavePlayerManpu.SIZE).ToStructure<GSavePlayerManpu>();

            PG_Manpu.SelectedObject = manpu;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            var val = (GSavePlayerManpu) PG_Manpu.SelectedObject;
            var bytes = val.ToBytes();
            bytes.CopyTo(Personal.Data, Personal.Offsets.Manpu);
            Close();
        }

        private void B_GiveAll_Click(object sender, EventArgs e)
        {
            var val = (GSavePlayerManpu)PG_Manpu.SelectedObject;
            val.AddMissingReactions();
            PG_Manpu.SelectedObject = val;
            System.Media.SystemSounds.Asterisk.Play();
        }
    }
}

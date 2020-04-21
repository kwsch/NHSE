using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Injection;

namespace NHSE.WinForms
{
    public partial class SimpleHexEditor : Form
    {
        public byte[] Bytes;

        public SimpleHexEditor(byte[] originalBytes)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            RTB_RAM.Text = string.Join(" ", originalBytes.Select(z => $"{z:X2}"));
            Bytes = originalBytes;
        }

        private void Update_Click(object sender, System.EventArgs e)
        {
            var bytestring = RTB_RAM.Text.Replace("\t", "").Replace(" ", "").Trim();
            Bytes = Decoder.StringToByteArray(bytestring);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

using System;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Injection;

namespace NHSE.WinForms
{
    public partial class SysBotUI : Form
    {
        private readonly Func<byte[]> ByteFetch;
        private readonly Action<byte[]> ByteSet;
        private readonly SysBotController Bot;

        public SysBotUI(Action<byte[]> read, Func<byte[]> write, InjectionType type)
        {
            InitializeComponent();
            Bot = new SysBotController(type);
            ByteFetch = write;
            ByteSet = read;
            RamOffset.Text = Bot.GetDefaultOffset().ToString("X8");

            TB_IP.Text = Bot.IP;
            TB_Port.Text = Bot.Port;

            Bot.PopPrompt();
        }

        private void B_Connect_Click(object sender, EventArgs e)
        {
            if (!Bot.Connect(TB_IP.Text, TB_Port.Text))
                return;
            GB_Inject.Enabled = true;
        }

        private void B_WriteCurrent_Click(object sender, EventArgs e)
        {
            var offset = StringUtil.GetHexValue(RamOffset.Text);
            if (offset == 0)
            {
                WinFormsUtil.Error("Incorrect hex offset.");
                return;
            }

            try
            {
                var data = ByteFetch();
                Bot.WriteBytes(data, offset);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message);
            }
        }

        private void B_ReadCurrent_Click(object sender, EventArgs e)
        {
            var offset = StringUtil.GetHexValue(RamOffset.Text);
            if (offset == 0)
            {
                WinFormsUtil.Error("Incorrect hex offset.");
                return;
            }

            try
            {
                var data = ByteFetch();
                var result = Bot.ReadBytes(offset, data.Length);
                ByteSet(result);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message);
            }
        }
    }
}

using System;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Injection;

namespace NHSE.WinForms
{
    public partial class SysBotRAMEdit : Form
    {
        private readonly SysBotController Bot;

        public SysBotRAMEdit(InjectionType type)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            Bot = new SysBotController(type);
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

        private void B_Edit_Click(object sender, EventArgs e)
        {
            var offset = StringUtil.GetHexValue(RamOffset.Text);
            if (offset == 0)
            {
                WinFormsUtil.Error(MessageStrings.MsgInvalidHexValue);
                return;
            }

            var length = (int)NUD_Offset.Value;
            Bot.HexEdit(offset, length);
        }
    }
}

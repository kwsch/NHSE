using System;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Injection;

namespace NHSE.WinForms
{
    public partial class SysBotUI : Form
    {
        private readonly AutoInjector Injector;
        private readonly SysBotController Bot;

        public SysBotUI(AutoInjector injector, SysBotController c)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            Bot = c;
            Injector = injector;

            var offset = Bot.GetDefaultOffset();
            Injector.SetWriteOffset(offset);
            RamOffset.Text = offset.ToString("X8");

            TB_IP.Text = Bot.IP;
            TB_Port.Text = Bot.Port;

            Bot.PopPrompt();

            TIM_Interval.Tick += (s, e) => injector.Read();
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
                WinFormsUtil.Error(MessageStrings.MsgInvalidHexValue);
                return;
            }

            Injector.SetWriteOffset(offset);

            try
            {
                var result = Injector.Write(true);
                if (result != InjectionResult.Success)
                    WinFormsUtil.Alert(result.ToString());
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
            try
            {
                var result = Injector.Read(true);
                if (result != InjectionResult.Success)
                    WinFormsUtil.Alert(result.ToString());
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message);
            }
        }

        private void CHK_AutoWrite_CheckedChanged(object sender, EventArgs e) => Injector.AutoInjectEnabled = CHK_AutoWrite.Checked;
        private void CHK_AutoRead_CheckedChanged(object sender, EventArgs e) => TIM_Interval.Enabled = CHK_AutoRead.Checked;
        private void CHK_Validate_CheckedChanged(object sender, EventArgs e) => Injector.ValidateEnabled = CHK_Validate.Checked;

        private void RamOffset_TextChanged(object sender, EventArgs e)
        {
            var offset = StringUtil.GetHexValue(RamOffset.Text);
            if (offset == 0)
            {
                WinFormsUtil.Error(MessageStrings.MsgInvalidHexValue);
                return;
            }

            Injector.SetWriteOffset(offset);
        }
    }
}

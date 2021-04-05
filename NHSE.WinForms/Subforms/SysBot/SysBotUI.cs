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
        private readonly AutoInjector InjectorUSB;
        private readonly USBBotController BotUSB;

        public SysBotUI(AutoInjector injector, SysBotController c, AutoInjector injectorUSB, USBBotController b)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            Bot = c;
            Injector = injector;
            BotUSB = b;
            InjectorUSB = injectorUSB;

            var offset = Bot.GetDefaultOffset();
            Injector.SetWriteOffset(offset);
            RamOffset.Text = offset.ToString("X8");
            RamOffsetUSB.Text = offset.ToString("X8");

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

        private void SysBotUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            TurnOffAuto();
            if (!Bot.Bot.Connected)
                return;

            try
            {
                Bot.Bot.Disconnect();
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                Console.WriteLine(ex.Message);
            }
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
                InjectionResult result;
                if (Injector.Injector is PocketInjector p)
                {
                    p.SpoofInventoryWrite = ModifierKeys == Keys.Control;
                    result = Injector.Write(true);
                    p.SpoofInventoryWrite = false;
                }
                else
                {
                    result = Injector.Write(true);
                }
                if (result == InjectionResult.Success)
                    return;
                WinFormsUtil.Alert(result.ToString());
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message);
            }
            TurnOffAuto();
        }

        private void B_ReadCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                var result = Injector.Read(true);
                if (result == InjectionResult.Success)
                    return;
                WinFormsUtil.Alert(result.ToString());
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message);
            }
            TurnOffAuto();
        }

        private void TurnOffAuto()
        {
            if (CHK_AutoRead.Checked)
                CHK_AutoRead.Checked = false;
            if (CHK_AutoWrite.Checked)
                CHK_AutoWrite.Checked = false;
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
            Bot.SetOffset(offset);
        }

        private void ReadUSB_Click(object sender, EventArgs e)
        {
            if (!BotUSB.Connect())
                return;

            var offset = StringUtil.GetHexValue(RamOffsetUSB.Text);
            if (offset == 0)
            {
                WinFormsUtil.Error(MessageStrings.MsgInvalidHexValue);
                return;
            }

            InjectorUSB.SetWriteOffset(offset);
            Bot.SetOffset(offset);

            try
            {
                var result = InjectorUSB.Read(true);
                if (result == InjectionResult.Success)
                    return;
                WinFormsUtil.Alert(result.ToString());
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message);
            }

            BotUSB.Disconnect();
        }

        private void WriteUSB_Click(object sender, EventArgs e)
        {
            if (!BotUSB.Connect())
                return;

            var offset = StringUtil.GetHexValue(RamOffsetUSB.Text);
            if (offset == 0)
            {
                WinFormsUtil.Error(MessageStrings.MsgInvalidHexValue);
                return;
            }

            InjectorUSB.SetWriteOffset(offset);
            Bot.SetOffset(offset);

            try
            {
                var result = InjectorUSB.Write(true);
                if (result == InjectionResult.Success)
                    return;
                WinFormsUtil.Alert(result.ToString());
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message);
            }

            BotUSB.Disconnect();
        }

        private void RamOffsetUSB_TextChanged(object sender, EventArgs e)
        {
            var offset = StringUtil.GetHexValue(RamOffsetUSB.Text);
            if (offset == 0)
            {
                WinFormsUtil.Error(MessageStrings.MsgInvalidHexValue);
                return;
            }

            Injector.SetWriteOffset(offset);
            Bot.SetOffset(offset);
        }
    }
}

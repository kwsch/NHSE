using System;
using System.Security.Cryptography;
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
        private HashAlgorithm HashSetup = HashAlgorithm.Create();
        private byte[] LastHash;
        private PlayerItemEditor<Item> PlayerEditorInstance;
        private bool DoIntialRead = false;
        public SysBotUI(Action<byte[]> read, Func<byte[]> write, InjectionType type, PlayerItemEditor<Item> playerItemEditor)
        {
            InitializeComponent();
            PlayerEditorInstance = playerItemEditor;
            Bot = new SysBotController(type);
            ByteFetch = write;
            ByteSet = read;
            RamOffset.Text = Bot.GetDefaultOffset().ToString("X8");

            TB_IP.Text = Bot.IP;
            TB_Port.Text = Bot.Port;

            Bot.PopPrompt();
            LastHash = HashSetup.ComputeHash(new byte[]{0});
        }
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
            LastHash = HashSetup.ComputeHash(new byte[] { 0 });
        }

        private void B_Connect_Click(object sender, EventArgs e)
        {
            if (!Bot.Connect(TB_IP.Text, TB_Port.Text))
                return;
            GB_Inject.Enabled = true;
        }

        private void B_WriteCurrent_Click(object sender, EventArgs e)
        {
            WriteItemsToMemory();
        }

        private void WriteItemsToMemory()
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
            ReadItmsFromMemory();
        }

        private void ReadItmsFromMemory()
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
                var innerResult = HashSetup.ComputeHash(result);
                if (innerResult != LastHash)
                {
                    LastHash = innerResult;
                    ByteSet(result);
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message);
            }
        }

        private void AutoSyncCheck_Changed(object sender, EventArgs e)
        {
            if (AutoSyncCheck.Checked)
            {
                AutoSyncBox.Enabled = true;
            }
            else
            {
                AutoSyncBox.Enabled = false;
                AutoSyncRead.Checked = false;
                AutoSyncWrite.Checked = false;
            }
        }

        private void AutoSyncWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoSyncWrite.Checked)
            {
                PlayerEditorInstance.Paint += OnPlayerEditorInstanceOnPaint;
            }
            else
            {
                PlayerEditorInstance.Paint -= OnPlayerEditorInstanceOnPaint;
            }
        }

        private void OnPlayerEditorInstanceOnPaint(object o, PaintEventArgs args)
        {
            if (!DoIntialRead)
            {
                ReadItmsFromMemory();
                DoIntialRead = true;
            }
            WriteItemsToMemory();
        }

        private void AutoSyncRead_CheckedChanged(object sender, EventArgs e)
        {
            AutoReadTimer.Enabled = AutoSyncRead.Checked;
        }

        private void AutoReadTimer_Tick(object sender, EventArgs e)
        {
            ReadItmsFromMemory();
        }
    }
}

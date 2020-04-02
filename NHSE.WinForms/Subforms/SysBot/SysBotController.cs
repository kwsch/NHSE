using System;
using System.Windows.Forms;
using NHSE.Injection;
using NHSE.WinForms.Properties;

namespace NHSE.WinForms
{
    public class SysBotController
    {
        public SysBotController(InjectionType type) => Type = type;

        private readonly InjectionType Type;
        private readonly SysBot Bot = new SysBot();
        private readonly Settings Settings = Settings.Default;

        public string IP => Settings.SysBotIP;
        public string Port => Settings.SysBotPort.ToString();

        public bool Connect(string ip, string port)
        {
            if (!int.TryParse(port, out var p))
                p = 6000;

            try
            {
                Bot.Connect(ip, p);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message);
                return false;
            }

            var settings = Settings;
            settings.SysBotIP = ip;
            settings.SysBotPort = p;
            settings.Save();

            return true;
        }

        public uint GetDefaultOffset()
        {
            var settings = Settings;
            return Type switch
            {
                InjectionType.Generic => settings.SysBotGenericOffset,
                InjectionType.Pouch => settings.SysBotPouchOffset,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void SetOffset(uint value)
        {
            var settings = Settings;
            switch (Type)
            {
                case InjectionType.Generic: settings.SysBotGenericOffset = value; break;
                case InjectionType.Pouch: settings.SysBotPouchOffset = value; break;
                default: return;
            }
            settings.Save();
        }

        public void HexEdit(uint offset, int length)
        {
            var read = ReadBytes(offset, length);
            using var ram = new SimpleHexEditor(read);
            if (ram.ShowDialog() != DialogResult.OK)
                return;

            var write = ram.Bytes;
            if (read.Length != write.Length)
            {
                var prompt = WinFormsUtil.Prompt(MessageBoxButtons.OKCancel,
                    $"Read size (0x{read.Length:X}) != Write Size (0x{write.Length})",
                    "Write anyway?");

                if (prompt != DialogResult.OK)
                    return;
            }

            WriteBytes(ram.Bytes, offset);
            SetOffset(offset);
            System.Media.SystemSounds.Asterisk.Play();
        }

        public void PopPrompt()
        {
            if (Settings.SysBotPrompted)
                return;

            const string info = "This SysBot reads and writes RAM directly to your game when called to Read/Write.";
            const string reqd = "Using this functionality requires the sys-botbase sysmodule running on the console." +
                                "Your console must be on the same network as the PC running this program.";
            WinFormsUtil.Alert(info, reqd);
            Settings.SysBotPrompted = true;
            Settings.Save();
        }

        public void WriteBytes(byte[] data, uint offset)
        {
            Bot.WriteBytes(data, offset);
            SetOffset(offset);
        }

        public byte[] ReadBytes(uint offset, int length)
        {
            var result = Bot.ReadBytes(offset, length);
            SetOffset(offset);
            return result;
        }
    }
}
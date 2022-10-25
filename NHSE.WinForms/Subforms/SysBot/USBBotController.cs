using System;
using NHSE.Injection;

namespace NHSE.WinForms
{
    public class USBBotController
    {
        public readonly USBBot Bot = new();

        public bool Connect()
        {
            try
            {
                return Bot.Connect();
            }
            catch (Exception ex)
            {
                WinFormsUtil.Error(ex.Message);
                return false;
            }
        }

        public void Disconnect()
        {
            Bot.Disconnect();
        }

        //todo: this
        //public uint GetDefaultOffset()
        //{
        //    return Settings.Default.SysBotPouchOffset;
        //}

        //public void PopPrompt()
        //{
        //}

        public void WriteBytes(byte[] data, uint offset)
        {
            Bot.WriteBytes(data, offset);
            //SetOffset(offset);
        }

        public byte[] ReadBytes(uint offset, int length)
        {
            var result = Bot.ReadBytes(offset, length);
            //SetOffset(offset);
            return result;
        }
    }
}

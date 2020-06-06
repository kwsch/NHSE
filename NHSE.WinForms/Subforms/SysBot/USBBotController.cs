using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using LibUsbDotNet;
using LibUsbDotNet.Info;
using LibUsbDotNet.Main;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Threading;
using NHSE.Injection;
using NHSE.WinForms.Properties;

namespace NHSE.WinForms
{
    public class USBBotController
    {

        public readonly USBBot Bot = new USBBot();

        public USBBotController()
        {

        }

        public bool Connect()
        {
            bool retvalue = false;
            try
            {
                retvalue = Bot.Connect();
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message);
                return false;
            }

            return retvalue;
        }

        public void Disconnect()
        {
            Bot.Disconnect();
        }

        //todo: this
        public uint GetDefaultOffset()
        {
            return Settings.Default.SysBotPouchOffset;
        }

        public void PopPrompt()
        {

        }

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

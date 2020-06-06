using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LibUsbDotNet;
using LibUsbDotNet.Info;
using LibUsbDotNet.Main;
using NHSE.Core;

namespace NHSE.Injection
{
    public class USBBot : IRAMReadWriter
    {
        private UsbDevice? SwDevice;
        private UsbEndpointReader? reader;
        private UsbEndpointWriter? writer;

        public bool Connected { get; private set; }

        private readonly object _sync = new object();

        public bool Connect()
        {
            lock (_sync)
            {
                
                // Find and open the usb device.
                //SwDevice = UsbDevice.OpenUsbDevice(SwFinder);
                foreach (UsbRegistry ur in UsbDevice.AllDevices)
                {
                    if (ur.Vid == 1406 && ur.Pid == 12288)
                        SwDevice = ur.Device;
                }
                //SwDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);

                // If the device is open and ready
                if (SwDevice == null)
                {
                    throw new Exception("Device Not Found.");
                }

                if (SwDevice.IsOpen)
                    SwDevice.Close();
                SwDevice.Open();

                    
                IUsbDevice? wholeUsbDevice = SwDevice as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    // This is a "whole" USB device. Before it can be used, 
                    // the desired configuration and interface must be selected.

                    // Select config #1
                    bool res = wholeUsbDevice.SetConfiguration(1);

                    // Claim interface #0.
                    bool resagain = wholeUsbDevice.ClaimInterface(0);
                    if (resagain == false)
                    {
                        wholeUsbDevice.ReleaseInterface(0);
                        resagain = wholeUsbDevice.ClaimInterface(0);
                    }
                }
                else
                {
                    Disconnect();
                    throw new Exception("Device is using WinUSB driver. Use libusbK and create a filter");
                }

                // open read write endpoints 1.
                reader = SwDevice.OpenEndpointReader(ReadEndpointID.Ep01);
                writer = SwDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
                
                Connected = true;
                return true;
            }
        }

        public void Disconnect()
        {
            lock (_sync)
            {
                if (SwDevice != null)
                {
                    if (SwDevice.IsOpen)
                    {
                        IUsbDevice? wholeUsbDevice = SwDevice as IUsbDevice;
                        if (!ReferenceEquals(wholeUsbDevice, null))
                        {
                            wholeUsbDevice.ReleaseInterface(0);
                        }
                        SwDevice.Close();
                    }
                }
                if (!ReferenceEquals(reader, null))
                    reader.Dispose(); 
                if (!ReferenceEquals(writer, null))
                    writer.Dispose();
                Connected = false;
            }
        }

        private int ReadInternal(byte[] buffer)
        {
            byte[] sizeOfReturn = new byte[4];
            ErrorCode ec = ErrorCode.None;
            int lenNew = 0;
            int lenVal = 0;

            //read size, no error checking as of yet, should be the required 368 bytes
            if (!ReferenceEquals(reader, null))
                ec = reader.Read(sizeOfReturn, 5000, out lenNew);
            else
                throw new Exception("USB writer is null, you may have disconnected the device during previous function");

            //read stack
            reader.Read(buffer, 5000, out lenVal);
            return lenVal;
        }

        private int SendInternal(byte[] buffer)
        {
            int l;
            uint pack = (uint)buffer.Length + 2;
            ErrorCode ec;
            if (!ReferenceEquals(writer, null))
                ec = writer.Write(BitConverter.GetBytes(pack), 2000, out l);
            else
                throw new Exception("USB writer is null, you may have disconnected the device during previous function");

            if (ec != ErrorCode.None)
            {
                Disconnect();
                throw new Exception(UsbDevice.LastErrorString);
            }
            ec = writer.Write(buffer, 2000, out l);
            if (ec != ErrorCode.None)
            {
                Disconnect();
                throw new Exception(UsbDevice.LastErrorString);
            }
            return l;
        }

        public int Read(byte[] buffer)
        {
            lock (_sync)
            {
                return ReadInternal(buffer);
            }
        }

        public byte[] ReadBytes(uint offset, int length)
        {
            lock (_sync)
            {
                var cmd = SwitchCommand.PeekRaw(offset, length);
                SendInternal(cmd);

                // give it time to push data back
                Thread.Sleep((length / 256) + 100);
                
                var buffer = new byte[length];
                var _ = ReadInternal(buffer);
                //return Decoder.ConvertHexByteStringToBytes(buffer);
                return buffer;
            }
        }

        public void WriteBytes(byte[] data, uint offset)
        {
            lock (_sync)
            {
                SendInternal(SwitchCommand.Poke(offset, data));

                // give it time to push data back
                Thread.Sleep((data.Length / 256) + 100);
            }
        }

    }
}

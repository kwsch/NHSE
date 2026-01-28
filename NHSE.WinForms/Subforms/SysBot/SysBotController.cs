using System;
using System.Windows.Forms;
using NHSE.Injection;

namespace NHSE.WinForms;

public sealed class SysBotController(InjectionType type)
{
    public readonly SysBot Bot = new();

    private static SysBotSettings Config => Program.Settings.SysBot;

    public string IP => Config.IP;
    public string Port => Config.Port.ToString();

    public bool Connect(string ip, string port)
    {
        if (!int.TryParse(port, out var p))
            p = 6000;

        try
        {
            Bot.Connect(ip, p);
        }
        catch (Exception ex)
        {
            WinFormsUtil.Error(ex.Message);
            return false;
        }

        Config.IP = ip;
        Config.Port = p;

        return true;
    }

    public uint GetDefaultOffset() => type switch
    {
        InjectionType.Generic => Config.GenericOffset,
        InjectionType.Pouch => Config.PouchOffset,
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
    };

    public void SetOffset(uint value)
    {
        switch (type)
        {
            case InjectionType.Generic: Config.GenericOffset = value; break;
            case InjectionType.Pouch: Config.PouchOffset = value; break;
            default: return;
        }
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
                string.Format(MessageStrings.MsgDataSizeMismatchRAM, read.Length, write.Length),
                MessageStrings.MsgAskWriteAnyway);

            if (prompt != DialogResult.OK)
                return;
        }

        WriteBytes(ram.Bytes, offset);
        SetOffset(offset);
        System.Media.SystemSounds.Asterisk.Play();
    }

    public void PopPrompt()
    {
        if (Config.Prompted)
            return;

        WinFormsUtil.Alert(MessageStrings.MsgSysBotInfo, MessageStrings.MsgSysBotRequired);
        Config.Prompted = true;
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
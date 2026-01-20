using System;
using System.Windows.Forms;
using NHSE.Injection;
using NHSE.WinForms.Properties;

namespace NHSE.WinForms;

public sealed class SysBotController(InjectionType type)
{
    public readonly SysBot Bot = new();
    private readonly Settings _settings = Settings.Default;

    public string IP => _settings.SysBotIP;
    public string Port => _settings.SysBotPort.ToString();

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

        _settings.SysBotIP = ip;
        _settings.SysBotPort = p;
        _settings.Save();

        return true;
    }

    public uint GetDefaultOffset() => type switch
    {
        InjectionType.Generic => _settings.SysBotGenericOffset,
        InjectionType.Pouch => _settings.SysBotPouchOffset,
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
    };

    public void SetOffset(uint value)
    {
        switch (type)
        {
            case InjectionType.Generic: _settings.SysBotGenericOffset = value; break;
            case InjectionType.Pouch: _settings.SysBotPouchOffset = value; break;
            default: return;
        }
        _settings.Save();
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
        if (_settings.SysBotPrompted)
            return;

        WinFormsUtil.Alert(MessageStrings.MsgSysBotInfo, MessageStrings.MsgSysBotRequired);
        _settings.SysBotPrompted = true;
        _settings.Save();
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
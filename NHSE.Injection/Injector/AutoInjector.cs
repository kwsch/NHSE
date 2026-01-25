using System;
using System.Diagnostics;

namespace NHSE.Injection;

public sealed record AutoInjector(IDataInjector Injector, Action<InjectionResult> DoRead, Action<InjectionResult> DoWrite)
{
    public bool AutoInjectEnabled { private get; set; }

    public bool ValidateEnabled
    {
        get => Injector.ValidateEnabled;
        set => Injector.ValidateEnabled = value;
    }

    public void Validate() => Injector.Validate();

    public InjectionResult Read(bool force = false)
    {
        if ((!AutoInjectEnabled && !force) || !Injector.Connected)
            return InjectionResult.Skipped;

        try
        {
            var result = Injector.Read();
            DoRead(result);
            return result;
        }
        catch (IndexOutOfRangeException ex)
        {
            Debug.WriteLine(ex.Message);
            return InjectionResult.FailConnectionError;
        }
    }

    public InjectionResult Write(bool force = false)
    {
        if ((!AutoInjectEnabled && !force) || !Injector.Connected)
            return InjectionResult.Skipped;
        try
        {
            var result = Injector.Write();
            DoWrite(result);
            return result;
        }
        catch (IndexOutOfRangeException ex)
        {
            Debug.WriteLine(ex.Message);
            return InjectionResult.FailConnectionError;
        }
    }

    public void SetWriteOffset(in uint offset)
    {
        Injector.WriteOffset = offset;
    }
}
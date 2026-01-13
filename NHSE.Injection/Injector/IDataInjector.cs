using System;

namespace NHSE.Injection;

public interface IDataInjector
{
    bool ReadValidate(out byte[] data);
    InjectionResult Read();
    InjectionResult Write();

    bool Validate();
    bool Validate(ReadOnlySpan<byte> data);
    uint WriteOffset { set; }
    bool Connected { get; }
    bool ValidateEnabled { get; set; }
}
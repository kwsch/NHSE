using System;

namespace NHSE.Injection
{
    public class AutoInjector
    {
        private readonly IDataInjector Injector;
        private readonly Action<InjectionResult> AfterRead;
        private readonly Action<InjectionResult> AfterWrite;

        public bool AutoInjectEnabled { private get; set; }

        public bool ValidateEnabled
        {
            get => Injector.ValidateEnabled;
            set => Injector.ValidateEnabled = value;
        }

        public AutoInjector(IDataInjector inj, Action<InjectionResult> read, Action<InjectionResult> write)
        {
            Injector = inj;
            AfterRead = read;
            AfterWrite = write;
        }

        public void Validate() => Injector.Validate();

        public InjectionResult Read(bool force = false)
        {
            if ((!AutoInjectEnabled && !force) || !Injector.Connected)
                return InjectionResult.Skipped;
            var result = Injector.Read();
            AfterRead(result);
            return result;
        }

        public InjectionResult Write(bool force = false)
        {
            if ((!AutoInjectEnabled && !force) || !Injector.Connected)
                return InjectionResult.Skipped;
            var result = Injector.Write();
            AfterWrite(result);
            return result;
        }

        public void SetWriteOffset(in uint offset)
        {
            Injector.WriteOffset = offset;
        }
    }
}
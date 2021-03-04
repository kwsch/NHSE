using System;
using System.Diagnostics;

namespace NHSE.Injection
{
    public class AutoInjector
    {
        public readonly IDataInjector Injector;
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

            try
            {
                var result = Injector.Read();
                AfterRead(result);
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
                AfterWrite(result);
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
}
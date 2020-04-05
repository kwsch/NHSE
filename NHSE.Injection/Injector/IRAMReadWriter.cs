namespace NHSE.Injection
{
    public interface IRAMReadWriter
    {
        bool Connected { get; }
        byte[] ReadBytes(uint offset, int length);
        void WriteBytes(byte[] data, uint offset);
    }
}
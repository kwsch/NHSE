using System;

namespace NHSE.Core;

public sealed class Personal30(Memory<byte> raw)
{
    public Span<byte> Data => raw.Span;

    public EncryptedInt32 HotelTickets // @0x0 size 0x8, align 4
    {
        get => EncryptedInt32.ReadVerify(Data, 0);
        set => value.Write(Data);
    }
}

public interface IPersonal30
{
    public int Offset30s_064c1881 { get; }
    public int Length30s_064c1881 { get; }
}

public static class Personal30Extensions
{
    extension(IPersonal30 personal)
    {
        public Personal30 Get30s_064c1881(Memory<byte> data)
            => new(data.Slice(personal.Offset30s_064c1881, personal.Length30s_064c1881));
    }
}

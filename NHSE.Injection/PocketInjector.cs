using System.Collections.Generic;
using System.Linq;
using NHSE.Core;

namespace NHSE.Injection
{
    public class PocketInjector : IDataInjector
    {
        private readonly IReadOnlyList<Item> Items;
        private readonly IRAMReadWriter Bot;
        public bool Connected => Bot.Connected;

        public uint WriteOffset { private get; set; }
        public bool ValidateEnabled { get; set; } = true;

        public PocketInjector(IReadOnlyList<Item> items, IRAMReadWriter bot)
        {
            Items = items;
            Bot = bot;
        }

        public bool ReadValidate(out byte[] data)
        {
            PlayerItemSet.GetOffsetLength(WriteOffset, out var offset, out var size);
            data = Bot.ReadBytes(offset, size);
            return Validate(data);
        }

        private byte[]? LastData;

        public InjectionResult Read()
        {
            if (!ReadValidate(out var data))
                return InjectionResult.FailValidate;

            if (LastData?.SequenceEqual(data) == true)
                return InjectionResult.Same;

            PlayerItemSet.ReadPlayerInventory(data, Items);

            LastData = data;

            return InjectionResult.Success;
        }

        public InjectionResult Write()
        {
            if (!ReadValidate(out var data))
                return InjectionResult.FailValidate;

            var orig = (byte[])data.Clone();

            PlayerItemSet.WritePlayerInventory(data, Items);

            if (data.SequenceEqual(orig))
                return InjectionResult.Same;

            PlayerItemSet.GetOffsetLength(WriteOffset, out var offset, out var size);
            if (size != data.Length)
                return InjectionResult.FailBadSize;

            Bot.WriteBytes(data, offset);

            LastData = data;

            return InjectionResult.Success;
        }

        public bool Validate() => ReadValidate(out _);

        public bool Validate(byte[] data)
        {
            if (!ValidateEnabled)
                return true;

            return PlayerItemSet.ValidateItemBinary(data);
        }
    }
}

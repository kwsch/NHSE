using System;
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

        private const int pocket = Item.SIZE * 20;
        private const int size = (pocket * 2) + 0x18;
        private const int shift = -0x18 - (Item.SIZE * 20);

        private uint DataOffset => (uint)(WriteOffset + shift);

        public bool ReadValidate(out byte[] data)
        {
            data = Bot.ReadBytes(DataOffset, size);
            return Validate(data);
        }

        private byte[]? LastData;

        public InjectionResult Read()
        {
            if (!ReadValidate(out var data))
                return InjectionResult.FailValidate;

            if (LastData?.SequenceEqual(data) == true)
                return InjectionResult.Same;

            var pocket2 = Items.Take(20).ToArray();
            var pocket1 = Items.Skip(20).ToArray();
            var p1 = Item.GetArray(data.Slice(0, pocket));
            var p2 = Item.GetArray(data.Slice(pocket + 0x18, pocket));

            for (int i = 0; i < pocket1.Length; i++)
                pocket1[i].CopyFrom(p1[i]);

            for (int i = 0; i < pocket2.Length; i++)
                pocket2[i].CopyFrom(p2[i]);

            LastData = data;

            return InjectionResult.Success;
        }

        public InjectionResult Write()
        {
            if (!ReadValidate(out var data))
                return InjectionResult.FailValidate;

            var orig = (byte[])data.Clone();

            var pocket2 = Items.Take(20).ToArray();
            var pocket1 = Items.Skip(20).ToArray();
            var p1 = Item.SetArray(pocket1);
            var p2 = Item.SetArray(pocket2);

            p1.CopyTo(data, 0);
            p2.CopyTo(data, pocket + 0x18);

            if (data.SequenceEqual(orig))
                return InjectionResult.Same;

            Bot.WriteBytes(data, DataOffset);

            LastData = data;

            return InjectionResult.Success;
        }

        public bool Validate() => ReadValidate(out _);

        public bool Validate(byte[] data)
        {
            if (!ValidateEnabled)
                return true;

            // Check the unlocked slot count -- expect 0,10,20
            var bagCount = BitConverter.ToUInt32(data, pocket);
            if (bagCount > 20 || bagCount % 10 != 0) // pouch21-39 count
                return false;

            // Check the item wheel binding -- expect -1 or [0,7]
            // Disallow duplicate binds!
            var bound = new List<byte>();
            for (int i = 0; i < 20; i++)
            {
                var bind = data[pocket + 4 + i];
                if (bind == 0xFF)
                    continue;
                if (bind > 7)
                    return false;
                if (bound.Contains(bind))
                    return false;
                bound.Add(bind);
            }

            return true;
        }
    }
}

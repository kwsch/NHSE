using System;
using System.Collections.Generic;
using System.Text;

namespace NHSE.Core
{
    public class Villager : IVillagerOrigin
    {
        public readonly byte[] Data;
        public Villager(byte[] data) => Data = data;

        public byte Species
        {
            get => Data[0];
            set => Data[0] = value;
        }

        public byte Variant
        {
            get => Data[1];
            set => Data[1] = value;
        }

        public VillagerPersonality Personality
        {
            get => (VillagerPersonality)Data[2];
            set => Data[2] = (byte)value;
        }

        public uint TownID
        {
            get => BitConverter.ToUInt32(Data, 0x04);
            set => BitConverter.GetBytes(value).CopyTo(Data, 0x04);
        }

        public string TownName
        {
            get => GetString(0x08, 10);
            set => GetBytes(value, 10).CopyTo(Data, 0x08);
        }
        public byte[] GetTownIdentity() => Data.Slice(0x04, 4 + 20);

        public uint PlayerID
        {
            get => BitConverter.ToUInt32(Data, 0x20);
            set => BitConverter.GetBytes(value).CopyTo(Data, 0x20);
        }

        public string PlayerName
        {
            get => GetString(0x24, 10);
            set => GetBytes(value, 10).CopyTo(Data, 0x24);
        }

        public byte[] GetPlayerIdentity() => Data.Slice(0x20, 4 + 20);

        public string TownName2
        {
            get => GetString(0x5CC, 10);
            set => GetBytes(value, 10).CopyTo(Data, 0x5CC);
        }

        public string CatchPhrase
        {
            get => GetString(0x10014, 2 * 12);
            set => GetBytes(value, 2 * 12).CopyTo(Data, 0x10014);
        }

        public IReadOnlyList<VillagerItem> Furniture
        {
            get => VillagerItem.GetArray(Data.Slice(0x105EC, 16 * VillagerItem.SIZE));
            set => VillagerItem.SetArray(value).CopyTo(Data, 0x105EC);
        }

        // State Flags
        public byte BirthType { get => Data[0x11EF8]; set => Data[0x11EF8] = value; }
        public byte InducementType { get => Data[0x11EF9]; set => Data[0x11EF9] = value; }
        public byte MoveType { get => Data[0x11EFA]; set => Data[0x11EFA] = value; }
        public bool MovingOut { get => (MoveType & 2) == 2; set => MoveType = (byte)((MoveType & ~2) | (value ? 2 : 0)); }

        // EventFlagsNPCSaveParam
        private const int EventFlagsSaveCount = 0x100; // Future-proof allocation! Release version used <20% of the amount allocated.

        public ushort[] GetEventFlagsSave()
        {
            var value = new ushort[EventFlagsSaveCount];
            Buffer.BlockCopy(Data, 0x11EFC, value, 0, sizeof(ushort) * value.Length);
            return value;
        }

        public void SetEventFlagsSave(ushort[] value)
        {
            Buffer.BlockCopy(value, 0, Data, 0x11EFC, sizeof(ushort) * value.Length);
        }

        public override string ToString() => InternalName;
        public string InternalName => VillagerUtil.GetInternalVillagerName((VillagerSpecies) Species, Variant);
        public int Gender => ((int)Personality / 4) & 1; // 0 = M, 1 = F

        public string GetString(int offset, int maxLength)
        {
            var str = Encoding.Unicode.GetString(Data, offset, maxLength * 2);
            return StringUtil.TrimFromZero(str);
        }

        public static byte[] GetBytes(string value, int maxLength)
        {
            if (value.Length > maxLength)
                value = value.Substring(0, maxLength);
            else if (value.Length < maxLength)
                value = value.PadRight(maxLength, '\0');
            return Encoding.Unicode.GetBytes(value);
        }
    }
}
using System;
using System.Collections.Generic;

namespace NHSE.Core
{
    /// <summary>
    /// Villager object format starting with update 1.5
    /// </summary>
    public sealed class Villager2 : IVillager
    {
        public const int SIZE = 0x13230; // + 160*0xC (0x780) -- GSaveLightMemory increased size.
        public string Extension => "nhv2";

        public readonly byte[] Data;
        public Villager2(byte[] data) => Data = data;
        public byte[] Write() => Data;

        public byte Species { get => Data[0]; set => Data[0] = value; }
        public byte Variant { get => Data[1]; set => Data[1] = value; }
        public VillagerPersonality Personality { get => (VillagerPersonality)Data[2]; set => Data[2] = (byte)value; }

        public string TownName => GetMemory(0).TownName;
        public Span<byte> GetTownIdentity() => GetMemory(0).GetTownIdentity();
        public string PlayerName => GetMemory(0).PlayerName;
        public Span<byte> GetPlayerIdentity() => GetMemory(0).GetPlayerIdentity();

        public const int PlayerMemoryCount = 8;

        public GSaveMemory GetMemory(int index)
        {
            if ((uint)index >= PlayerMemoryCount)
                throw new ArgumentOutOfRangeException(nameof(index));

            var bytes = Data.Slice(0x4 + (index * GSaveMemory.SIZE), GSaveMemory.SIZE);
            return new GSaveMemory(bytes);
        }

        public GSaveMemory[] GetMemories()
        {
            var memories = new GSaveMemory[PlayerMemoryCount];
            for (int i = 0; i < memories.Length; i++)
                memories[i] = GetMemory(i);
            return memories;
        }

        public void SetMemory(GSaveMemory memory, int index)
        {
            if ((uint)index >= PlayerMemoryCount)
                throw new ArgumentOutOfRangeException(nameof(index));

            memory.Data.CopyTo(Data, 0x4 + (index * GSaveMemory.SIZE));
        }

        public void SetMemories(IReadOnlyList<GSaveMemory> memories)
        {
            for (int i = 0; i < memories.Count; i++)
                SetMemory(memories[i], i);
        }

        public string CatchPhrase
        {
            get => StringUtil.GetString(Data, 0x10768 + 0x2C, 2 * 12);
            set => StringUtil.GetBytes(value, 2 * 12).CopyTo(Data, 0x10768 + 0x2C);
        }

        private const int WearCount = 24;

        public IReadOnlyList<VillagerItem> WearStockList
        {
            get => VillagerItem.GetArray(Data.Slice(0x1094c, WearCount * VillagerItem.SIZE));
            set => VillagerItem.SetArray(value).CopyTo(Data, 0x1094c);
        }

        private const int FurnitureCount = 32;

        public IReadOnlyList<VillagerItem> FtrStockList
        {
            get => VillagerItem.GetArray(Data.Slice(0x10d6c, FurnitureCount * VillagerItem.SIZE));
            set => VillagerItem.SetArray(value).CopyTo(Data, 0x10d6c);
        }

        // State Flags
        public byte BirthType { get => Data[0x12678]; set => Data[0x12678] = value; }
        public byte InducementType { get => Data[0x12679]; set => Data[0x12679] = value; }
        public byte MoveType { get => Data[0x1267a]; set => Data[0x1267a] = value; }
        public bool MovingOut { get => (MoveType & 2) == 2; set => MoveType = (byte)((MoveType & ~2) | (value ? 2 : 0)); }

        // EventFlagsNPCSaveParam
        private const int EventFlagsSaveCount = 0x100; // Future-proof allocation! Release version used <20% of the amount allocated.

        public ushort[] GetEventFlagsSave()
        {
            var value = new ushort[EventFlagsSaveCount];
            Buffer.BlockCopy(Data, 0x1267c, value, 0, sizeof(ushort) * value.Length);
            return value;
        }

        public void SetEventFlagsSave(ushort[] value)
        {
            Buffer.BlockCopy(value, 0, Data, 0x1267c, sizeof(ushort) * value.Length);
        }

        public override string ToString() => InternalName;
        public string InternalName => VillagerUtil.GetInternalVillagerName((VillagerSpecies)Species, Variant);
        public int Gender => ((int)Personality / 4) & 1; // 0 = M, 1 = F

        public GSaveRoomFloorWall Room
        {
            get => Data.Slice(0x12880, GSaveRoomFloorWall.SIZE).ToStructure<GSaveRoomFloorWall>();
            set => value.ToBytes().CopyTo(Data, 0x12880);
        }

        public DesignPatternPRO Design
        {
            get => new(Data.Slice(0x128a8, DesignPatternPRO.SIZE));
            set => value.Data.CopyTo(Data, 0x128a8);
        }

        public byte DIYEndHour { get => Data[0x13151]; set => Data[0x13151] = value; }
        public byte DIYEndMinute { get => Data[0x13152]; set => Data[0x13152] = value; }
        public byte DIYEndSecond { get => Data[0x13153]; set => Data[0x13153] = value; }
        public ushort DIYRecipeIndex { get => BitConverter.ToUInt16(Data, 0x13154); set => BitConverter.GetBytes(value).CopyTo(Data, 0x13154); }

        public void SetFriendshipAll(byte value = byte.MaxValue)
        {
            for (int i = 0; i < PlayerMemoryCount; i++)
            {
                var m = GetMemory(i);
                if (string.IsNullOrEmpty(m.PlayerName))
                    continue;
                m.Friendship = value;
                SetMemory(m, i);
            }
        }
    }
}

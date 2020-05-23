using System;
using System.Runtime.InteropServices;

#pragma warning disable CS8618, CA1815, CA1819, IDE1006
namespace NHSE.Core
{
    /// <summary>
    /// Custom structure to wrap logic for editing all <see cref="LifeSupportAchievement"/> milestone data.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct AchievementList
    {
        /*
            u32        CountAchievement[512];
            bool       ReadAchievement[512][6];
            GSaveDate  DateAchievement[512][6];
            _44c6787c  NewAchievement[512]; 
         */

        public const int MaxCount = 512;
        public const int SIZE = MaxCount * (4 + (6 * 1) + (6 * 4) + 1);

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxCount)]
        public uint[] Counts { get; set; }

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxCount)]
        public AchievementReadSet[] Read { get; set; }

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxCount)]
        public AchievementDateSet[] Date { get; set; }

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxCount)]
        public byte[] Flags { get; set; }

        public readonly void GiveAll(DateTime t)
        {
            for (int i = 0; i < Counts.Length; i++)
                GiveAll(i, t);
        }

        public readonly void GiveAll(in int index, DateTime t)
        {
            if (!LifeSupportAchievement.List.TryGetValue(index, out var detail))
            {
                ClearAll(index);
                return;
            }

            var max = detail.MaxThreshold;
            if (max != 0)
                Counts[index] = Math.Max(Counts[index], max);
            Flags[index] = 1; // visible

            for (int i = 0; i < detail.AchievementCount; i++)
            {
                if (Read[index][i])
                    continue;
                if (!Date[index][i].IsEmpty)
                    continue;

                Date[index][i] = t;
                Read[index][i] = true;
                t = t.AddDays(1);
            }
        }

        public readonly void ClearAll()
        {
            for (int i = 0; i < Counts.Length; i++)
                ClearAll(i);
        }

        public readonly void ClearAll(int index)
        {
            Read[index].Clear();
            Date[index].Clear();
            Flags[index] = 0;
            Counts[index] = 0;
        }
    }

    public struct AchievementReadSet
    {
        public const int MaxCount = 6;

        [field: MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = MaxCount)]
        public bool[] Read { get; set; }

        public bool this[int index]
        {
            get => Read[index];
            set => Read[index] = value;
        }

        public void Clear()
        {
            for (int i = 0; i < Read.Length; i++)
                Read[i] = false;
        }
    }

    public struct AchievementDateSet
    {
        public const int MaxCount = 6;

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxCount)]
        public GSaveDate[] Dates { get; set; }

        public GSaveDate this[int index]
        {
            get => Dates[index];
            set => Dates[index] = value;
        }

        public void Clear()
        {
            for (int i = 0; i < Dates.Length; i++)
                Dates[i] = new GSaveDate();
        }
    }
}
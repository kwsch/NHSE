using System;

namespace NHSE.Core
{
    public static class VillagerConverter
    {
        public static bool IsCompatible(int size, int expect)
        {
            switch (expect)
            {
                case Villager1.SIZE:
                case Villager2.SIZE:
                    return size == Villager1.SIZE || size == Villager2.SIZE;

                default:
                    return false;
            }
        }

        public static byte[] GetCompatible(byte[] data, int expect)
        {
            if (data.Length == expect)
                return data;

            return expect switch
            {
                Villager1.SIZE when data.Length == Villager2.SIZE => Convert12(data),
                Villager2.SIZE when data.Length == Villager1.SIZE => Convert21(data),
                _ => data
            };
        }

        public static byte[] Convert12(byte[] v1)
        {
            byte[] v2 = new byte[Villager2.SIZE];

            // Copy pre-GSaveLightMemory[160]
            Array.Copy(v1, 0, v2, 0, 0x2f84);

            // Copy each entry, with each adding 0xC empty bytes.
            for (int i = 0; i < 160; i++)
            {
                var src = 0x2f84 + (0x14C * i);
                var dest = 0x2f84 + (0x158 * i);

                Array.Copy(v1, src, v2, dest, 0x14C);
            }

            // Copy after-GSaveLightMemory[160]
            Array.Copy(v1, 0xff04, v2, 0x10684, v1.Length - 0xff04);

            return v2;
        }

        public static byte[] Convert21(byte[] v2)
        {
            byte[] v1 = new byte[Villager1.SIZE];

            // Copy pre-GSaveLightMemory[160]
            Array.Copy(v2, 0, v1, 0, 0x2f84);

            // Copy each entry, with each skipping last 0xC bytes.
            for (int i = 0; i < 160; i++)
            {
                var src = 0x2f84 + (0x14C * i);
                var dest = 0x2f84 + (0x158 * i);

                Array.Copy(v2, dest, v1, src, 0x14C);
            }

            // Copy after-GSaveLightMemory[160]
            Array.Copy(v2, 0x10684, v1, 0xff04, v2.Length - 0x10684);

            return v1;
        }
    }
}

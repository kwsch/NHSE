using System;

namespace NHSE.Core
{
    /// <summary>
    /// Converts Villager objects to different revisions.
    /// </summary>
    public static class VillagerConverter
    {
        /// <summary>
        /// Checks to see if the <see cref="size"/> matches any of the Villager object sizes.
        /// </summary>
        /// <param name="size">Size of the byte array that might represent a Villager object.</param>
        /// <returns>True if it matches any size.</returns>
        public static bool IsVillager(int size)
        {
            return size == Villager1.SIZE || size == Villager2.SIZE;
        }

        /// <summary>
        /// Checks to see if the input <see cref="size"/> can be converted to the <see cref="expect"/> size.
        /// </summary>
        /// <param name="size">Current villager file size</param>
        /// <param name="expect">Expected villager file size</param>
        /// <returns>True if can be converted, false if no conversion available.</returns>
        public static bool IsCompatible(int size, int expect)
        {
            switch (expect)
            {
                // Can convert to any format
                case Villager1.SIZE:
                case Villager2.SIZE:
                    return IsVillager(size);

                // No conversion available
                default:
                    return false;
            }
        }

        /// <summary>
        /// Converts the Villager data format to another format.
        /// </summary>
        /// <remarks>
        /// Before calling this method, check that a conversion method exists via <see cref="IsCompatible"/> and that the length of the <see cref="data"/> is not the same as what you <see cref="expect"/>.
        /// If the sizes are the same, it will return the input <see cref="data"/>.
        /// If no conversion path exists, it will return the input <see cref="data"/>.
        /// </remarks>
        /// <param name="data">Current format</param>
        /// <param name="expect">Target size</param>
        /// <returns>Converted data</returns>
        public static byte[] GetCompatible(byte[] data, int expect)
        {
            if (data.Length == expect)
                return data;

            return expect switch
            {
                Villager1.SIZE when data.Length == Villager2.SIZE => Convert21(data),
                Villager2.SIZE when data.Length == Villager1.SIZE => Convert12(data),
                _ => data
            };
        }

        /// <summary>
        /// Converts a <see cref="Villager1"/> object byte array to a <see cref="Villager2"/>
        /// </summary>
        /// <param name="v1"><see cref="Villager1"/> object byte array</param>
        /// <returns><see cref="Villager2"/> object byte array</returns>
        public static byte[] Convert12(byte[] v1)
        {
            // In v1.5, the GSaveLightMemory object structure increased in size by 0xC bytes.
            // To convert to v1.5 format, we need to expand each of those entries within our structure.

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

        /// <summary>
        /// Converts a <see cref="Villager2"/> object byte array to a <see cref="Villager1"/>
        /// </summary>
        /// <param name="v2"><see cref="Villager2"/> object byte array</param>
        /// <returns><see cref="Villager1"/> object byte array</returns>
        public static byte[] Convert21(byte[] v2)
        {
            // In v1.5, the GSaveLightMemory object structure increased in size by 0xC bytes.
            // To revert back to Version 1.4, we need to truncate each of those entries within our structure.

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

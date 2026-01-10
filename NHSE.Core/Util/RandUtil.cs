using System;
using System.Collections.Generic;

namespace NHSE.Core
{
    /// <summary>
    /// Logic for providing random values
    /// </summary>
    public static class RandUtil
    {
        // Multi-thread safe rand, ha
        public static Random Rand => Random.Shared;

        public static uint Rand32() => Rand32(Rand);
        public static uint Rand32(Random rnd) => (uint)rnd.Next(1 << 30) << 2 | (uint)rnd.Next(1 << 2);

        /// <summary>
        /// Shuffles the order of items within a collection of items.
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="items">Item collection</param>
        public static void Shuffle<T>(IList<T> items) => Shuffle(items, 0, items.Count, Rand);

        /// <summary>
        /// Shuffles the order of items within a collection of items.
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="items">Item collection</param>
        /// <param name="start">Starting position</param>
        /// <param name="end">Ending position</param>
        /// <param name="rnd">RNG object to use</param>
        public static void Shuffle<T>(IList<T> items, int start, int end, Random rnd)
        {
            for (int i = start; i < end; i++)
            {
                int index = i + rnd.Next(end - i);
                (items[index], items[i]) = (items[i], items[index]);
            }
        }
    }
}
﻿namespace NHSE.Core
{
    /// <summary>
    /// Converts Player Room objects to different revisions.
    /// </summary>
    public static class PlayerRoomConverter
    {
        /// <summary>
        /// Checks to see if the <see cref="size"/> matches any of the Room object sizes.
        /// </summary>
        /// <param name="size">Size of the byte array that might represent a Room object.</param>
        /// <returns>True if it matches any size.</returns>
        public static bool IsRoom(int size)
        {
            return size == PlayerRoom1.SIZE || size == PlayerRoom2.SIZE;
        }

        /// <summary>
        /// Checks to see if the input <see cref="size"/> can be converted to the <see cref="expect"/> size.
        /// </summary>
        /// <param name="size">Current room file size</param>
        /// <param name="expect">Expected room file size</param>
        /// <returns>True if can be converted, false if no conversion available.</returns>
        public static bool IsCompatible(int size, int expect)
        {
            return expect switch
            {
                // Can convert to any format
                PlayerRoom1.SIZE or PlayerRoom2.SIZE => IsRoom(size),
                // No conversion available
                _ => false,
            };
        }

        /// <summary>
        /// Converts the Room data format to another format.
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
                PlayerRoom1.SIZE when data.Length == PlayerRoom2.SIZE => Convert21(data),
                PlayerRoom2.SIZE when data.Length == PlayerRoom1.SIZE => Convert12(data),
                _ => data,
            };
        }

        /// <summary>
        /// Converts a <see cref="PlayerRoom1"/> object byte array to a <see cref="PlayerRoom2"/>
        /// </summary>
        /// <param name="h1"><see cref="PlayerRoom1"/> object byte array</param>
        /// <returns><see cref="PlayerRoom2"/> object byte array</returns>
        private static byte[] Convert12(byte[] h1) => new PlayerRoom1(h1).Upgrade().Write();

        /// <summary>
        /// Converts a <see cref="PlayerRoom2"/> object byte array to a <see cref="PlayerRoom1"/>
        /// </summary>
        /// <param name="h2"><see cref="PlayerRoom2"/> object byte array</param>
        /// <returns><see cref="PlayerRoom1"/> object byte array</returns>
        private static byte[] Convert21(byte[] h2) => new PlayerRoom2(h2).Downgrade().Write();
    }
}

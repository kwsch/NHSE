using System.Runtime.CompilerServices;

namespace NHSE.Core
{
    /// <summary>
    /// Logic for manipulating strings
    /// </summary>
    public static class StringUtil
    {
        /// <summary>
        /// Trims a string at the first instance of a 0x0000 terminator.
        /// </summary>
        /// <param name="input">String to trim.</param>
        /// <returns>Trimmed string.</returns>
        public static string TrimFromZero(string input) => TrimFromFirst(input, '\0');

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string TrimFromFirst(string input, char c)
        {
            int index = input.IndexOf(c);
            return index < 0 ? input : input.Substring(0, index);
        }
    }
}
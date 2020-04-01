using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

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

        public static string GetString(byte[] data, int offset, int maxLength)
        {
            var str = Encoding.Unicode.GetString(data, offset, maxLength * 2);
            return TrimFromZero(str);
        }

        public static byte[] GetBytes(string value, int maxLength)
        {
            if (value.Length > maxLength)
                value = value.Substring(0, maxLength);
            else if (value.Length < maxLength)
                value = value.PadRight(maxLength, '\0');
            return Encoding.Unicode.GetBytes(value);
        }

        public static string CleanFileName(string fileName)
        {
            return string.Concat(fileName.Split(Path.GetInvalidFileNameChars()));
        }

        /// <summary>
        /// Parses the hex string into a <see cref="uint"/>, skipping all characters except for valid digits.
        /// </summary>
        /// <param name="value">Hex String to parse</param>
        /// <returns>Parsed value</returns>
        public static uint GetHexValue(string value)
        {
            uint result = 0;
            if (string.IsNullOrEmpty(value))
                return result;

            foreach (var c in value)
            {
                if (IsNum(c))
                {
                    result <<= 4;
                    result += (uint)(c - '0');
                }
                else if (IsHexUpper(c))
                {
                    result <<= 4;
                    result += (uint)(c - 'A' + 10);
                }
                else if (IsHexLower(c))
                {
                    result <<= 4;
                    result += (uint)(c - 'a' + 10);
                }
            }
            return result;
        }

        private static bool IsNum(char c) => (uint)(c - '0') <= 9;
        private static bool IsHexUpper(char c) => (uint)(c - 'A') <= 5;
        private static bool IsHexLower(char c) => (uint)(c - 'a') <= 5;
    }
}
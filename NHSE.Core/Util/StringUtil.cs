using System;
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
            return index < 0 ? input : input[..index];
        }

        public static string GetString(byte[] data, int offset, int maxLength)
        {
            var str = Encoding.Unicode.GetString(data, offset, maxLength * 2);
            return TrimFromZero(str);
        }

        public static byte[] GetBytes(string value, int maxLength)
        {
            if (value.Length > maxLength)
                value = value[..maxLength];
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
        public static uint GetHexValue(ReadOnlySpan<char> value)
        {
            uint result = 0;
            if (value.Length == 0)
                return result;

            foreach (var c in value)
            {
                if (char.IsAsciiDigit(c))
                {
                    result <<= 4;
                    result |= (uint)(c - '0');
                }
                else if (char.IsAsciiHexDigitUpper(c))
                {
                    result <<= 4;
                    result |= (uint)(c - 'A' + 10);
                }
                else if (char.IsAsciiHexDigitLower(c))
                {
                    result <<= 4;
                    result |= (uint)(c - 'a' + 10);
                }
            }
            return result;
        }
    }
}
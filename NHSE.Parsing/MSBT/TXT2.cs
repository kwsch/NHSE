using System;
using System.Collections.Generic;

namespace NHSE.Parsing
{
    public class TXT2 : MSBTSection
    {
        public uint NumberOfStrings;

        public readonly List<MSBTTextString> Strings = new List<MSBTTextString>();

        public TXT2() : base(string.Empty, Array.Empty<byte>())
        {
        }
    }
}

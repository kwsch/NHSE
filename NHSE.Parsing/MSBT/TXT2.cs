using System.Collections.Generic;

namespace NHSE.Parsing
{
    public class TXT2 : MSBTSection
    {
        public uint NumberOfStrings;

        public readonly List<MSBTTextString> Strings = new List<MSBTTextString>();
    }
}
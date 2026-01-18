using System.Collections.Generic;

namespace NHSE.Parsing;

public sealed class TXT2() : MSBTSection(string.Empty, [])
{
    public uint NumberOfStrings;

    public readonly List<MSBTTextString> Strings = [];
}
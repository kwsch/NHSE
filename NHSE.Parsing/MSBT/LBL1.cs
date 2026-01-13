using System.Collections.Generic;

namespace NHSE.Parsing;

public class LBL1() : MSBTSection(string.Empty, [])
{
    public uint NumberOfGroups;

    public readonly List<MSBTGroup> Groups = [];
    public readonly List<MSBTLabel> Labels = [];
}
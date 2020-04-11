using System;
using System.Collections.Generic;

namespace NHSE.Parsing
{
    public class LBL1 : MSBTSection
    {
        public uint NumberOfGroups;

        public readonly List<MSBTGroup> Groups = new List<MSBTGroup>();
        public readonly List<MSBTLabel> Labels = new List<MSBTLabel>();

        public LBL1() : base(string.Empty, Array.Empty<byte>())
        {
        }
    }
}

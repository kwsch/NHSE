using System.Collections.Generic;

namespace NHSE.Parsing
{
    public class LBL1 : MSBTSection
    {
        public uint NumberOfGroups;

        public List<MSBTGroup> Groups = new List<MSBTGroup>();
        public List<MSBTLabel> Labels = new List<MSBTLabel>();
    }
}
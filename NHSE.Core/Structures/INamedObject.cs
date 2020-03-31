using System.Collections.Generic;

namespace NHSE.Core
{
    public interface INamedObject
    {
        string ToString(IReadOnlyList<string> names);
    }
}

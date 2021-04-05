using System.Collections.Generic;

namespace NHSE.Core
{
    public abstract class BatchMutator<T> where T : class
    {
        protected const string CONST_RAND = "$rand";

        public abstract ModifyResult Modify(T item, IEnumerable<StringInstruction> filters, IEnumerable<StringInstruction> modifications);
    }
}

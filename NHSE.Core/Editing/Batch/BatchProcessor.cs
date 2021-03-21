using System;
using System.Collections.Generic;
using System.Linq;

namespace NHSE.Core
{
    /// <summary>
    /// Carries out a batch edit and contains information summarizing the results.
    /// </summary>
    public abstract class BatchProcessor<T> where T : class
    {
        private int Modified { get; set; }
        private int Iterated { get; set; }
        private int Failed { get; set; }

        protected readonly BatchMutator<T> Mutator;
        protected BatchProcessor(BatchMutator<T> mut) => Mutator = mut;

        protected abstract bool CanModify(T item);
        protected abstract bool Finalize(T item);

        /// <summary>
        /// Tries to modify the <see cref="item"/>.
        /// </summary>
        /// <param name="item">Object to modify.</param>
        /// <param name="filters">Filters which must be satisfied prior to any modifications being made.</param>
        /// <param name="modifications">Modifications to perform on the item.</param>
        /// <returns>Result of the attempted modification.</returns>
        public bool Process(T item, IEnumerable<StringInstruction> filters, IEnumerable<StringInstruction> modifications)
        {
            if (!CanModify(item))
                return false;

            var result = Mutator.Modify(item, filters, modifications);
            if (result != ModifyResult.Invalid)
                Iterated++;
            if (result == ModifyResult.Error)
                Failed++;
            if (result != ModifyResult.Modified)
                return false;

            Finalize(item);
            Modified++;
            return true;
        }

        /// <summary>
        /// Gets a message indicating the overall result of all modifications performed across multiple Batch Edit jobs.
        /// </summary>
        /// <param name="sets">Collection of modifications.</param>
        /// <returns>Friendly (multi-line) string indicating the result of the batch edits.</returns>
        public string GetEditorResults(ICollection<StringInstructionSet> sets)
        {
            if (sets.Count == 0)
                return "No instructions present.";
            int ctr = Modified / sets.Count;
            int len = Iterated / sets.Count;
            string maybe = sets.Count == 1 ? string.Empty : "~";
            string result = $"Success: {maybe}{ctr}/{len}";
            if (Failed > 0)
                result += Environment.NewLine + maybe + $"Failed: {Failed} not processed.";
            return result;
        }

        public void Execute(IList<string> lines, IEnumerable<T> data)
        {
            var sets = StringInstructionSet.GetBatchSets(lines).ToArray();
            foreach (var pk in data)
            {
                foreach (var set in sets)
                    Process(pk, set.Filters, set.Instructions);
            }
        }

        protected abstract void Initialize(StringInstructionSet[] sets);

        public void Process(StringInstructionSet[] sets, IReadOnlyList<T> items)
        {
            Initialize(sets);
            foreach (var s in sets)
            {
                foreach (var i in items)
                    Process(i, s.Filters, s.Instructions);
            }
        }
    }
}

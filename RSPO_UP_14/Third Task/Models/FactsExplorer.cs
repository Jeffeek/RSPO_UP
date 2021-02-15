#region Using derectives

using System.Collections;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace RSPO_UP_14.Third_Task.Models
{
    public sealed class FactsExplorer : IEnumerable<Fact>
    {
        private readonly Fact[] _facts;

        public FactsExplorer(IEnumerable<Fact> facts) => _facts = facts.ToArray();

        public Fact this[int index] => _facts[index];

        public Fact this[string eventText] => _facts.First(x => x.Text == eventText);

        #region Implementation of IEnumerable

        /// <inheritdoc />
        public IEnumerator<Fact> GetEnumerator() => _facts.Where((t, i) => i % 3 == 0).GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
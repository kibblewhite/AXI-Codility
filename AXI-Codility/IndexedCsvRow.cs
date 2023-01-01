using System.Collections.Generic;
using System.Collections.Immutable;

namespace AXICodility
{
    public struct IndexedCsvRow
    {
        public IReadOnlyList<string> Row { get; private set; }
        public int Index { get; private set; }

        private IndexedCsvRow(IEnumerable<string> row, int index)
        {
            Row = row.ToImmutableList();
            Index = index;
        }

        public static IndexedCsvRow Create(IEnumerable<string> row, int idx)
        {
            return new IndexedCsvRow(row, idx);
        }
    }
}

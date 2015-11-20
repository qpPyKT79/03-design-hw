using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Readers
{
    public class ListReader : ITextReader
    {
        public ListReader() { }
        public IEnumerable<string> ReadWords(ISourceReader source, IFilter[] filters, string sourceName)
        {
            var text = source.ReadWords(sourceName);
            return filters.Aggregate(text, (current, filter) => filter.FilterWords(current));
        }
    }
}

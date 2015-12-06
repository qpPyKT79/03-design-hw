using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.SourceReaders
{
    public class FilteringFileReader
    {
        public List<string> FilterInputData(
            Func<Func<string>, List<string>> read,
            Func<List<string>, List<string>>[] filters,
            Func<string> sourceName)
        {
            var filteredWords = read(sourceName);
            return filters.Aggregate(filteredWords, (current, filter) => filter(current));
        } 
    }
}

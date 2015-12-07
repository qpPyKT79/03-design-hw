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
            Func<string, List<string>> read,
            Func<List<string>, List<string>>[] filters,
            string sourceName)
        {
            var filteredWords = read(sourceName);
            foreach (var filter in filters)
                filteredWords = filter(filteredWords);
            return filteredWords;
        } 
    }
}

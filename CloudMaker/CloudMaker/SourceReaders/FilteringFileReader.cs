using System;
using System.Collections.Generic;

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

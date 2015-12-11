using System;
using System.Collections.Generic;

namespace CloudMaker.SourceReaders
{
    public class Filter
    {
        public List<string> ReadAndFilterInputData(
            Func<string, List<string>> readFunc,
            List<Func<List<string>, List<string>>> filters,
            string sourceName)
        {
            var filteredWords = readFunc(sourceName);
            foreach (var filter in filters)
                filteredWords = filter(filteredWords);
            return filteredWords;
        } 
    }
}

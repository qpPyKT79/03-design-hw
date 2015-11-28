using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CloudMaker.SourceReaders
{
    public class ListFileReader :ISourceReader
    {
        public List<string> ReadWords(string sourceName, IFilter[] filters)
        {
            var words = GetTextFromFile(sourceName);
            return filters.Aggregate(words, (current, filter) => filter.FilterWords(current).ToList());
        }

        protected static List<string> GetTextFromFile(string sourceName) => 
            File.Exists(sourceName) ?
            File.ReadAllText(sourceName).Split(' ', '\n').Where(word => !string.IsNullOrWhiteSpace(word)).Select(word => word.Replace("\r", "").ToLower()).ToList()
            : new List<string>();
    }
}

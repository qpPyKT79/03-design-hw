using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CloudMaker.Filters
{
    public class BoringWordsFilter
    {
        private HashSet<string> boringWords { get;} 
        public List<string> FilterWords(List<string> words) => words.Where(NotBoring).ToList();

        public BoringWordsFilter()
        {
            boringWords = new HashSet<string>(File.ReadAllText("BoringWordsFilter.txt").Split('\n').Select(word=> word.Replace("\r", "")));
        }

        private bool NotBoring(string word) => !boringWords.Contains(word);
    }
}

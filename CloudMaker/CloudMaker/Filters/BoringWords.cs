using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Filters
{
    public class BoringWords :IFilter
    {
        private HashSet<string> boringWords { get;} 
        public IEnumerable<string> FilterWords(IEnumerable<string> words) => words.Where(NotBoring);

        public BoringWords()
        {
            boringWords = new HashSet<string>(File.ReadAllText("BoringWords.txt").Split('\n').Select(word=> word.Replace("\r", "")));
        }

        private bool NotBoring(string word) => !boringWords.Contains(word);
    }
}

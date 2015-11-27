using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHunspell;

namespace CloudMaker.Filters
{
    public class Normalizer: IFilter
    {
        public IEnumerable<string> FilterWords(IEnumerable<string> words) => Normalize(words).Where(word => !string.IsNullOrEmpty(word));

        private List<string> Normalize(IEnumerable<string> words)
        {
            var newWords = new List<string>();
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
                foreach (var word in words)
                    newWords.Add(hunspell.Stem(word).FirstOrDefault());
            return newWords;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using NHunspell;

namespace CloudMaker.Filters
{
    public class Normalizer: IFilter
    {
        public List<string> FilterWords(List<string> words) => Normalize(words).Where(word => !string.IsNullOrEmpty(word)).ToList();

        private static List<string> Normalize(List<string> words)
        {
            var newWords = new List<string>();
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
                foreach (var word in words)
                    newWords.Add(hunspell.Stem(word).FirstOrDefault());
            return newWords;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHunspell;

namespace CloudMaker.Filters
{
    public class Normalizer: IFilter
    {
        public IEnumerable<string> FilterWords(IEnumerable<string> words) => words.Select(Normalize);

        private string Normalize(string word)
        {
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
                return hunspell.Stem(word).First();
        }
    }
}

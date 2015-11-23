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
        public Normalizer()
        {
        }

        public IEnumerable<string> FilterWords(IEnumerable<string> words)
        {
            words.Select(Normalize);
            return null;
        }

        protected string Normalize(string word)
        {
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
                return hunspell.Stem(word).First();
        }/*
        var tag = new CloudTag("wat");
        tag.SetFrequency(4);
            SizeF a;
            using (Image tempImage = new Bitmap(100, 100))
            using (var g = Graphics.FromImage(tempImage))
                a = g.MeasureString("wat", new Font("Times New Roman", 4));
            Assert.AreEqual(a, null);*/
    }
}

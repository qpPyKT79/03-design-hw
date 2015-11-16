using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHunspell;

namespace CloudMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            // просто смотрел как эта штука работает
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
            {
                Console.WriteLine("Find the word stem of the word 'decompressed'");
                List<string> stems = hunspell.Stem("decompressed");
                foreach (string stem in stems)
                {
                    Console.WriteLine("Word Stem is: " + stem);
                }
            }
            
        }
    }
}

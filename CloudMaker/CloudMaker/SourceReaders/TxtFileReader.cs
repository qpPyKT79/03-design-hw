using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Readers
{
    class TxtFileReader :ISourceReader
    {
        public IEnumerable<string> ReadWords(string sourceName)
        {
            return File.Exists(sourceName) ? File.ReadAllText(sourceName).Split(' ', '\n').Where(word => !string.IsNullOrWhiteSpace(word)) : null;
        }
    }
}

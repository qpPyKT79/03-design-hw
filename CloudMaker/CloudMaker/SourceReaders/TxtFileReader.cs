using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Readers
{
    public class TxtFileReader :ISourceReader
    {
        public TxtFileReader() { }
        public List<string> ReadWords(string sourceName, IFilter[] filters) => 
            File.Exists(sourceName) ? 
            File.ReadAllText(sourceName).Split(' ', '\n').Where(word => !string.IsNullOrWhiteSpace(word)).Select(word => word.Replace("\r", "")).ToList() 
            : null ;
    }
}

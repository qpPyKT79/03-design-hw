using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CloudMaker.SourceReaders
{
    public class FileReader
    {
        public List<string> ReadFromFile(string sourceName)=> 
            File.Exists(sourceName) ?
            File.ReadAllText(sourceName).Split(' ', '\n').Where(word => !string.IsNullOrWhiteSpace(word)).Select(word => word.Replace("\r", "").ToLower()).ToList()
            : new List<string>();
    }
}

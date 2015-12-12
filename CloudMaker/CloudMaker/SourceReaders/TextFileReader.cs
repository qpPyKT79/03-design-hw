using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CloudMaker.SourceReaders
{
    public class TextFileReader
    {
        private readonly static HashSet<char> Symbols = new HashSet<char>
        {
            ',','.','!','&','?','\"','\\','/','<','>',':',';','-','+','*','`','^','~','%','#','@','\r',' '
        };
        public List<string> ReadFromFile(string sourceName) =>
            File.Exists(sourceName)
                ? File.ReadAllText(sourceName)
                    .Split(' ', '\n')
                    .Where(word => !string.IsNullOrWhiteSpace(word))
                    .Select(word => word.TrimStart(Symbols.ToArray()).TrimEnd(Symbols.ToArray()).ToLower())
                    .ToList()
                : new List<string>();
    }
}

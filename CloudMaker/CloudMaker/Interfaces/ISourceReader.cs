using System.Collections.Generic;

namespace CloudMaker
{
    public interface ISourceReader
    {
        List<string> ReadWords(string sourceName, IFilter[] filters);
    }
}

using System.Collections.Generic;

namespace CloudMaker
{
    interface ISourceReader
    {
        List<string> ReadWords(string sourceName, IFilter[] filters);
    }
}

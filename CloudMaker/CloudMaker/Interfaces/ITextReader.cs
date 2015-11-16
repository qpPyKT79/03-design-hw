using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker
{
    interface ITextReader
    {
        IEnumerable<string> ReadWords(ISourceReader source, IFilter[] filters, string sourceName);
    }
}

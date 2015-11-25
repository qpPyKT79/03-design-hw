using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker
{
    interface ISourceReader
    {
        List<string> ReadWords(string sourceName, IFilter[] filters);
    }
}

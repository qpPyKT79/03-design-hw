using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Readers
{
    class DocFileReader : ISourceReader
    {
        // todo: документация по .doc формату на 500 страниц... может лучше сделать какой нибудь NetworkReader?
        public IEnumerable<string> ReadWords(string sourceName)
        {
            throw new NotImplementedException();
        }
    }
}

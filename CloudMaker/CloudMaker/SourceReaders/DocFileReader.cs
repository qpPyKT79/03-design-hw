using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Readers
{
    public class DocFileReader : ISourceReader
    {
        // todo: документация по .doc формату на 500 страниц... может лучше сделать какой нибудь NetworkReader?
        public List<string> ReadWords(string sourceName, IFilter[] filters)
        {
            throw new NotImplementedException();
        }
    }
}

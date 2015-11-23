using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker
{
    interface IWriter
    {
        void WriteTo(IEnumerable<CloudTag> tags, string outputSourceName);
    }
}

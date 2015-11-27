using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker
{
    public interface IFilter
    {
        List<string> FilterWords(List<string> words);

    }
}

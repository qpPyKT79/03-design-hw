using System.Collections.Generic;

namespace CloudMaker
{
    public interface IFilter
    {
        List<string> FilterWords(List<string> words);
    }
}
